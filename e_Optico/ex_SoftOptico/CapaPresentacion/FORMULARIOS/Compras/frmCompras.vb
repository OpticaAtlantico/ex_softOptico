Imports CapaEntidad
Imports CapaNegocio
Imports CapaDatos
Imports FontAwesome.Sharp

Public Class frmCompras
    Private producto As New Repositorio_VProductos

    Private grvCompras As New DataGridComprasUI()
    Private cargandoCombo As Boolean = False

    Public Property DatosCompra As VCompras = Nothing
    Public Property NombreBoton As String = String.Empty

#Region "CONSTRUCTORES"

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormStylerUI.Apply(Me)
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
        'Mostrar los datos si DatosCompra no es nothing
        If DatosCompra IsNot Nothing Then
            cmbSucursal.OrbitalCombo.Text = DatosCompra.Sucursal.ToString()
            txtNumeroControl.TextoUsuario = DatosCompra.NControl.ToString()
            txtNumeroFactura.TextoUsuario = DatosCompra.NFactura.ToString()
            'txtFechaEmision.TextValue = DatosCompra.Fecha
            cmbProveedor.OrbitalCombo.Text = DatosCompra.Proveedor.ToString()
            txtDomicilio.TextoUsuario = DatosCompra.Direccion.ToString()
            txtRifCI.TextoUsuario = DatosCompra.Rif.ToString()
            txtTelefonos.TextoUsuario = DatosCompra.Telefono.ToString()
            cmbTipoPago.OrbitalCombo.Text = DatosCompra.TPago.ToString()
            txtObservacion.TextoUsuario = DatosCompra.Observacion.ToString()

            ' --- DETALLE ---
            grvCompras.LimpiarGrid()
            For Each det In DatosCompra.Detalle
                grvCompras.AgregarProductoEdit(det.CodigoProducto,
                                               det.Descripcion, 'producto.ObtenerNombreProducto(det.ProductoID),
                                               det.Cantidad,
                                               det.ModoCargo,
                                               det.CostoUnitario)
            Next

            'Propiedades de los controles 
            Select Case NombreBoton
                Case "Actualizar..."
                    ActivarControles(0)
                Case "Eliminar..."
                    ActivarControles(1)
            End Select

        End If
        FadeManagerUI.StartFade(Me, 0.05)
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
        Select Case btnAceptar.Texto
            Case "Actualizar..."
                ' Actualizar compra existente
                AdminCompra(1)

            Case "Eliminar..."
                AdminCompra(2)

            Case Else
                ' Caso por defecto: Registrar nueva compra
                AdminCompra(0)
        End Select
    End Sub

    Private Sub btnLimpiarGrid_Click(sender As Object, e As EventArgs) Handles btnLimpiarGrid.Click
        LimpiarGrids()
    End Sub

    Private Sub btnLimpiarCeldas_Click(sender As Object, e As EventArgs) Handles btnLimpiarCeldas.Click
        LimpiarControles(Me.pnlContenidoDatos)
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
                ActivarControles(3)

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
        ActivarControles(2)

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
                ActivarControles(3) ' Activar controles para nueva compra)
            End If
        Else
            MessageBoxUI.Mostrar("Información", "No hay productos en el detalle para limpiar.", TipoMensaje.Informacion, Botones.Aceptar)
        End If
    End Sub

    Private Sub AdminCompra(opcion As Integer)
        Dim datosID As Integer = 0
        ' Opción 0: Registrar nueva compra
        Select Case opcion
            Case 0
                ' Case 0: Registrar nueva compra
                If Not grvCompras.TieneDatos Then
                    MessageBoxUI.Mostrar("Atención", "Debe agregar al menos un producto al detalle de la compra.", TipoMensaje.Advertencia, Botones.Aceptar)
                    Return
                End If

            Case 1
                ' Case 1: Actualizar compra existente
                If Not grvCompras.TieneDatos Then
                    MessageBoxUI.Mostrar("Atención", "Debe agregar al menos un producto al detalle de la compra.", TipoMensaje.Advertencia, Botones.Aceptar)
                    Return
                End If
            Case 2 ' Eliminar compra existente
                Dim repo As New Repositorio_Compra
                Dim resultado = repo.Remove(DatosCompra.CompraID)

                If resultado Then
                    MessageBoxUI.Mostrar("Borrado Correcto", "Compra eliminada correctamente", TipoMensaje.Exito, Botones.Aceptar)
                    LimpiarCeldas()
                    ActivarControles(2)
                    Exit Sub
                Else
                    MessageBoxUI.Mostrar("Fallo...", "No se pudo eliminar la compra", TipoMensaje.Errors, Botones.Aceptar)
                End If
        End Select
        ' Opción 1: Actualizar compra existente

        Dim compra As New TCompra With {
                    .CompraID = If(IsNothing(DatosCompra), 1, Integer.Parse(DatosCompra.CompraID.ToString())),
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
        Select Case opcion
            Case 0
                ' Case 0: Registrar nueva compra
                Dim resultado As Integer = service.RegistrarCompra(compra)
                If resultado > 0 Then
                    MessageBoxUI.Mostrar("Éxito", $"Compra registrada correctamente. ID: {resultado}", TipoMensaje.Exito, Botones.Aceptar)
                    LimpiarCeldas()
                    ActivarControles(2)
                Else
                    MessageBoxUI.Mostrar("Fallo...", "No se pudo registrar la compra", TipoMensaje.Errors, Botones.Aceptar)
                End If
            Case 1
                ' Case 1: Actualizar compra existente
                Dim resultado As Boolean = service.ActualizarCompra(compra)
                If resultado Then
                    MessageBoxUI.Mostrar("Éxito", $"Compra actualizada correctamente. ID: {resultado}", TipoMensaje.Exito, Botones.Aceptar)
                    LimpiarCeldas()
                    ActivarControles(2)
                Else
                    MessageBoxUI.Mostrar("Fallo...", "No se pudo actualizar la compra", TipoMensaje.Errors, Botones.Aceptar)
                End If
        End Select

    End Sub

    Private Sub ActivarControles(opcion)
        Select Case opcion
            Case 0 'Actualizar
                btnAceptar.Texto = NombreBoton.ToString()
                pnlContenidoDatos.Enabled = True
                pnlContenedorGrid.Enabled = True
                pnlDataGrid.Enabled = True
                pnlTotales.Enabled = True
                grvCompras.Enabled = True
            Case 1 'Eliminar
                btnAceptar.Texto = NombreBoton.ToString()
                pnlContenidoDatos.Enabled = False
                pnlContenedorGrid.Enabled = False
                pnlDataGrid.Enabled = False
                pnlTotales.Enabled = False
            Case 2 'Guardar
                btnAceptar.Texto = "Guardar..."
                pnlContenidoDatos.Enabled = True
                pnlContenedorGrid.Enabled = False
                pnlDataGrid.Enabled = False
                pnlTotales.Enabled = False
            Case 3
                ' Deshabilitar todo
                pnlContenedorGrid.Enabled = True
                pnlDataGrid.Enabled = True
                pnlTotales.Enabled = True
                grvCompras.Enabled = True
        End Select
    End Sub

#End Region

End Class






