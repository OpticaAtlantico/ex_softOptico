Imports CapaEntidad
Imports CapaNegocio
Imports CapaDatos
Imports FontAwesome.Sharp

Public Class frmCompras

    Private grvCompras As New DataGridComprasUI()
    Private cargandoCombo As Boolean = False
    Private fadeTimer As New Timer()
    Private fadeStep As Double = 0.1

    Public Property DatosCompra As TCompra = Nothing
    Public Property NombreBoton As String = String.Empty

#Region "CONSTRUCTORES"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()

        ' Oculta al inicio para cargar limpio
        Me.Opacity = 0
        Me.Visible = False

        ' Timer para fade-in
        AddHandler fadeTimer.Tick, AddressOf FadeIn
        fadeTimer.Interval = 30

        Me.ResumeLayout()

    End Sub

    Private Sub CustomizeComponents()
        grvCompras.Dock = DockStyle.Fill
        grvCompras.IvaPorcentaje = 16D ' IVA por defecto si aplica
        grvCompras.Inicializar()

        ' Inicializar con lista vacía
        grvCompras.CargarDatos(New List(Of ProductoSeleccionado)())

        ' Suscribir evento de totales
        AddHandler grvCompras.TotalActualizado, AddressOf ActualizarEtiquetasTotales

        ' Limpiar el panel contenedor
        pnlDataGrid.Controls.Clear()

        ' Agregar al panel contenedor
        pnlDataGrid.Controls.Add(grvCompras)
        grvCompras.BringToFront()
        cmbProveedor.IniciarCarga()

        'llenar combos desde la base de datos
        Dim llenarCombo As New LlenarComboBox

        Dim sql As String = "SELECT ProveedorID, NombreEmpresa FROM TProveedor"
        llenarCombo.Cargar(cmbProveedor, sql, "NombreEmpresa", "ProveedorID")
        cmbProveedor.FinalizarCarga()

        sql = "SELECT TipoPagoID, Nombre FROM TTipoPago"
        llenarCombo.Cargar(cmbTipoPago, sql, "Nombre", "TipoPagoID")
        cmbTipoPago.FinalizarCarga()

        sql = "SELECT UbicacionID, NombreUbicacion FROM TUbicaciones"
        llenarCombo.Cargar(cmbSucursal, sql, "NombreUbicacion", "UbicacionID")
        cmbSucursal.FinalizarCarga()

        'Bloquea el panel de grid hasta que se agregue un producto
        pnlDataGrid.Enabled = False
        pnlTotales.Enabled = False

        lblTextoIva.Text = "IVA (" & grvCompras.IvaPorcentaje & "%)"

        With lblEncabezado
            .Titulo = "Modulo de Compras"
            .Subtitulo = "Inclucion y administración de Compras de productos..."
            .Icono = IconChar.CartShopping
            .ColorTexto = Color.Black
        End With
    End Sub

#End Region

#Region "FORMULARIO Y CONTROLES"

    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomizeComponents()
    End Sub
    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Dim frmLista As New frmListarProductos
        frmLista.FormularioDestino = Me
        frmLista.ShowDialog()

    End Sub
    Private Sub cmbProveedor_SelectedIndexChangedCustom(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChangedCustom, cmbSucursal.SelectedIndexChangedCustom

        Dim seleccionado As LlenarComboBox.ComboItem = cmbProveedor.ItemSeleccionado

        If seleccionado IsNot Nothing Then
            Dim idprovedor = Convert.ToInt32(seleccionado.Valor)
            Dim nombreProveedor = seleccionado.Texto

            Dim proveedor As New Repositorio_Proveedor
            Dim datos = proveedor.BuscarProveedorPorID(idprovedor)
            Try
                If datos IsNot Nothing Then
                    txtTelefonos.TextoUsuario = datos.telefono
                    txtRifCI.TextoUsuario = datos.rif
                    txtDomicilio.TextoUsuario = datos.direccion
                Else
                    ' Limpiar campos si no se encuentra el proveedor
                    txtTelefonos.TextoUsuario = String.Empty
                    txtRifCI.TextoUsuario = String.Empty
                    txtDomicilio.TextoUsuario = String.Empty
                End If
            Catch ex As Exception
                MessageBoxUI.Mostrar("Error...", "Error al buscar el proveedor: " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
            End Try

        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim compra As New TCompra With {
                .NumeroControl = txtNumeroControl.TextoUsuario.Trim(),
                .NumeroFactura = txtNumeroFactura.TextoUsuario.Trim(),
                .FechaCompra = txtFechaEmision.TextValue,
                .EmpleadoID = CInt(Sesion.UsuarioID),
                .AlicuotaID = 1,
                .UbicacionDestinoID = CInt(cmbSucursal.ItemSeleccionado.Valor),
                .ProveedorID = CInt(cmbProveedor.ItemSeleccionado.Valor),
                .TipoPagoID = CInt(cmbTipoPago.ItemSeleccionado.Valor),
                .Observacion = txtObservacion.TextoUsuario.Trim(),
                .TotalCompra = grvCompras.CalcularTotal(),
                .Detalle = grvCompras.GetDetalleList()
            }

            Dim service As New ComprasService()
            Dim idGenerado As Integer = service.RegistrarCompra(compra)

            MessageBoxUI.Mostrar("Éxito", $"Compra registrada con éxito. ID: {idGenerado}", TipoMensaje.Exito, Botones.Aceptar)
            LimpiarCeldas()
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error...", "Error al registrar la compra: " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try

    End Sub

    Private Sub btnLimpiarGrid_Click(sender As Object, e As EventArgs) Handles btnLimpiarGrid.Click
        LimpiarGrids()
    End Sub

    Private Sub btnLimpiarCeldas_Click(sender As Object, e As EventArgs) Handles btnLimpiarCeldas.Click
        LimpiarCeldas()
    End Sub
    Private Sub btnSiguiente_Click_1(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Try
            Dim ncontrol = txtNumeroControl.TextoUsuario.Trim
            Dim nfactura = txtNumeroFactura.TextoUsuario.Trim
            Dim fecha As Date = txtFechaEmision.TextValue
            Dim proveedor = cmbProveedor.TextoSeleccionado.Trim
            Dim domicilio = txtDomicilio.TextoUsuario.Trim
            Dim rif = txtRifCI.TextoUsuario.Trim
            Dim telefono = txtTelefonos.TextoUsuario.Trim
            Dim tipoPago = cmbTipoPago.TextoSeleccionado.Trim

            If {ncontrol, nfactura, fecha, proveedor, domicilio, rif, telefono, tipoPago
                        }.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar("Cargando...",
                                         "Por favor, complete todos los campos obligatorios.",
                                          TipoMensaje.Errors, Botones.Aceptar)

            Else

                'Desbloquear el panel de grid
                pnlDataGrid.Enabled = True
                pnlTotales.Enabled = True

            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error...", "Error al procesar los datos: " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

#Region "PROCEDIMIENTO"

    Private Sub ActualizarEtiquetasTotales(totalExento As Decimal, baseImponible As Decimal, iva As Decimal, totalGeneral As Decimal)
        ' Aquí puedes actualizar labels o campos fuera del control
        lblExento.Text = totalExento.ToString("N2")
        lblBaseImponible.Text = baseImponible.ToString("N2")
        lblIva.Text = iva.ToString("N2")
        lblTotalGeneral.Text = totalGeneral.ToString("N2")
    End Sub
    Public Sub AgregarProductoAlDetalle(producto As ProductoSeleccionado)
        grvCompras.AgregarProducto(
            producto.Codigo,
            producto.Nombre,
            producto.ExG,
            producto.Precio
)
    End Sub
    Private Sub LimpiarCeldas()
        LimpiarControles(Me.pnlContenidoDatos)

        ' Limpiar el grid de compras
        grvCompras.LimpiarGrid()

        ' Deshabilitar paneles
        pnlDataGrid.Enabled = False
        pnlTotales.Enabled = False

    End Sub
    Private Sub LimpiarControles(container As Control)
        container.SuspendLayout()

        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is TextBoxLabelUI Then
                Dim c = CType(ctrl, TextBoxLabelUI)
                c.TextoUsuario = ""

            ElseIf TypeOf ctrl Is ComboBoxLabelUI Then
                Dim c = CType(ctrl, ComboBoxLabelUI)
                c.Limpiar()

            ElseIf TypeOf ctrl Is MaskedTextBoxLabelUI Then
                Dim c = CType(ctrl, MaskedTextBoxLabelUI)
                c.TextoUsuario = ""

            ElseIf TypeOf ctrl Is MultilineTextBoxLabelUI Then
                Dim c = CType(ctrl, MultilineTextBoxLabelUI)
                c.TextoUsuario = ""

            ElseIf TypeOf ctrl Is ToggleSwitchUI Then
                CType(ctrl, ToggleSwitchUI).Checked = False

            ElseIf ctrl.HasChildren Then
                ' Llamada recursiva para paneles o groupboxes
                LimpiarControles(ctrl)
            End If
        Next

        container.ResumeLayout()
        container.PerformLayout()
    End Sub

    Private Sub LimpiarGrids()
        If grvCompras.TieneDatos Then
            Dim resultado = MessageBoxUI.Mostrar("Confirmación",
                                                 "¿Está seguro de que desea limpiar el detalle de la compra?",
                                                 TipoMensaje.Informacion, Botones.SiNo)
            If resultado = DialogResult.Yes Then
                grvCompras.LimpiarGrid()
                pnlDataGrid.Enabled = False
                pnlTotales.Enabled = False

            End If
        Else
            MessageBoxUI.Mostrar("Información", "No hay productos en el detalle para limpiar.", TipoMensaje.Informacion, Botones.Aceptar)
        End If
    End Sub
    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 1 Then
            Me.Opacity += fadeStep
        Else
            fadeTimer.Stop()
        End If
    End Sub

    Private Function GetDetalleFromGrid() As List(Of TDetalleCompra)
        Dim list As New List(Of TDetalleCompra)
        For Each row As DataGridViewRow In grvCompras.InnerGridView.Rows
            If row.IsNewRow Then Continue For
            Dim idProd As Integer = If(row.Cells("ProductoID").Value IsNot Nothing, Convert.ToInt32(row.Cells("ProductoID").Value), 0)
            Dim cantidad As Decimal = If(row.Cells("Cantidad").Value IsNot Nothing, Convert.ToDecimal(row.Cells("Cantidad").Value), 0D)
            Dim precio As Decimal = If(row.Cells("PrecioUnitario").Value IsNot Nothing, Convert.ToDecimal(row.Cells("PrecioUnitario").Value), 0D)
            Dim subtotal As Decimal = If(row.Cells("SubTotal").Value IsNot Nothing, Convert.ToDecimal(row.Cells("SubTotal").Value), cantidad * precio)

            list.Add(New TDetalleCompra With {
                .ProductoID = idProd,
                .Cantidad = cantidad,
                .PrecioUnitario = precio,
                .Subtotal = subtotal
            })
        Next
        Return list
    End Function

    Private Function CalculateTotalFromGrid() As Decimal
        Dim total As Decimal = 0D
        For Each row As DataGridViewRow In grvCompras.InnerGridView.Rows
            If row.IsNewRow Then Continue For
            Dim subtotal As Decimal = If(row.Cells("SubTotal").Value IsNot Nothing, Convert.ToDecimal(row.Cells("SubTotal").Value), 0D)
            total += subtotal
        Next
        Return total
    End Function

#End Region

End Class






'Private Function GetDetalleFromGrid() As List(Of TDetalleCompra)
'    Dim list As New List(Of TDetalleCompra)
'    For Each row As DataGridViewRow In grvCompras.InnerGridView.Rows
'        If row.IsNewRow Then Continue For
'        Dim idProd As Integer = If(row.Cells("ProductoID").Value IsNot Nothing, Convert.ToInt32(row.Cells("ProductoID").Value), 0)
'        Dim cantidad As Decimal = If(row.Cells("Cantidad").Value IsNot Nothing, Convert.ToDecimal(row.Cells("Cantidad").Value), 0D)
'        Dim precio As Decimal = If(row.Cells("PrecioUnitario").Value IsNot Nothing, Convert.ToDecimal(row.Cells("PrecioUnitario").Value), 0D)
'        Dim subtotal As Decimal = If(row.Cells("SubTotal").Value IsNot Nothing, Convert.ToDecimal(row.Cells("SubTotal").Value), cantidad * precio)

'        list.Add(New TDetalleCompra With {
'            .ProductoID = idProd,
'            .Cantidad = cantidad,
'            .PrecioUnitario = precio,
'            .Subtotal = subtotal
'        })
'    Next
'    Return list
'End Function

'Private Function CalculateTotalFromGrid() As Decimal
'    Dim total As Decimal = 0D
'    For Each row As DataGridViewRow In grvCompras.InnerGridView.Rows
'        If row.IsNewRow Then Continue For
'        Dim subtotal As Decimal = If(row.Cells("SubTotal").Value IsNot Nothing, Convert.ToDecimal(row.Cells("SubTotal").Value), 0D)
'        total += subtotal
'    Next
'    Return total
'End Function






















