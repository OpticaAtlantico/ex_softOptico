Imports CapaEntidad
Imports CapaNegocio
Imports CapaDatos
Imports FontAwesome.Sharp

Public Class frmCompras
    Private producto As New Repositorio_Productos

    Private grvCompras As New DataGridComprasUI()
    Private cargandoCombo As Boolean = False
    Private llenarCombo As New LlenarComboBox
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

        'llenarCombo.Cargar(cmbProveedor, llenarCombo.SQL_PROVEEDOR, "NombreEmpresa", "ProveedorID")
        'cmbProveedor.FinalizarCarga()

        'llenarCombo.Cargar(cmbTipoPago, llenarCombo.SQL_TIPOPAGO, "Nombre", "TipoPagoID")
        'cmbTipoPago.FinalizarCarga()

        'llenarCombo.Cargar(cmbSucursal, llenarCombo.SQL_SUCURSALES, "NombreUbicacion", "UbicacionID")
        'cmbSucursal.FinalizarCarga()

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
        'Inicia los componentes 
        CustomizeComponents()
        'Mostrar los datos si DatosCompra no es nothing
        Try

            If DatosCompra IsNot Nothing Then

                With DatosCompra

                    lblOrden.Texto = FormatearConCeros(._ordenCompra).ToString()
                    cmbSucursal.OrbitalCombo.Text = ._sucursal.ToString()
                    txtNumeroControl.TextoUsuario = ._nControl.ToString()
                    txtNumeroFactura.TextoUsuario = ._nFactura.ToString()
                    txtFechaEmision.FechaSeleccionada = ._fecha
                    cmbProveedor.OrbitalCombo.Text = ._proveedor.ToString()
                    txtDomicilio.TextString = ._direccion.ToString()
                    txtRifCI.TextoUsuario = ._rif.ToString()
                    txtTelefonos.TextoUsuario = ._telefono.ToString()
                    cmbTipoPago.OrbitalCombo.Text = ._tPago.ToString()
                    txtObservacion.TextString = ._observacion.ToString()

                    ' --- DETALLE ---
                    grvCompras.LimpiarGrid()
                    For Each det In ._detalle
                        With det
                            grvCompras.AgregarProductoEdit(._codigoProducto,
                                                           ._descripcion, 'producto.ObtenerNombreProducto(det.ProductoID),
                                                           ._cantidad,
                                                           ._modoCargo,
                                                           ._costoUnitario,
                                                           ._descuento)
                        End With
                    Next

                End With

                'Propiedades de los controles 
                Select Case NombreBoton
                    Case "Actualizar..."
                        ActivarControles(0)
                    Case "Eliminar..."
                        ActivarControles(1)
                End Select
            Else
                'Obtener ordenCompra max 
                ObtenerNumeroOrdenCompra()
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)

        End Try
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Dim overlay As New FondoOverlayUI()
        overlay.Show()

        Dim frmLista As New frmListarProductos() With {
            .FormularioDestino = Me,
            .StartPosition = FormStartPosition.CenterScreen
        }
        frmLista.ShowDialog()
        overlay.Close()

    End Sub
    Private Sub cmbProveedor_SelectedIndexChangedCustom(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChangedCustom, cmbSucursal.SelectedIndexChangedCustom

        Dim seleccionado As LlenarComboBox.ComboItem = cmbProveedor.ItemSeleccionado

        Try

            If seleccionado IsNot Nothing Then
                Dim idprovedor = Convert.ToInt32(seleccionado.Valor)
                Dim nombreProveedor = seleccionado.Texto

                Dim proveedor As New Repositorio_Proveedor
                Dim datos = proveedor.GetById(idprovedor)

                If datos IsNot Nothing Then
                    txtTelefonos.TextoUsuario = datos._telefono
                    txtRifCI.TextoUsuario = datos._rif
                    txtDomicilio.TextString = datos._direccion
                Else
                    ' Limpiar campos si no se encuentra el proveedor
                    txtTelefonos.TextoUsuario = String.Empty
                    txtRifCI.TextoUsuario = String.Empty
                    txtDomicilio.TextString = String.Empty
                End If

            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End Try
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
            Dim OrdenCompra = lblOrden.Texto
            Dim ncontrol = txtNumeroControl.TextoUsuario.Trim
            Dim nfactura = txtNumeroFactura.TextoUsuario.Trim
            Dim fecha As Date = txtFechaEmision.FechaSeleccionada
            Dim proveedor = cmbProveedor.TextoSeleccionado.Trim
            Dim domicilio = txtDomicilio.TextString.Trim
            Dim rif = txtRifCI.TextoUsuario.Trim
            Dim telefono = txtTelefonos.TextoUsuario.Trim
            Dim tipoPago = cmbTipoPago.TextoSeleccionado.Trim

            If {ncontrol, nfactura, fecha, proveedor, domicilio, rif, telefono, tipoPago
                        }.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                     MensajesUI.DatosIncompletos,
                                     MessageBoxUI.TipoMensaje.Errorr,
                                     MessageBoxUI.TipoBotones.Aceptar)

            Else

                'Desbloquear el panel de grid
                ActivarControles(3)

            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
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
                                    producto.Precio,
                                    producto.Descuento
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
                c.TextString = ""

            ElseIf TypeOf ctrl Is ToggleSwitchUI Then
                CType(ctrl, ToggleSwitchUI).Checked = False

            ElseIf ctrl.HasChildren Then
                ' Llamada recursiva para paneles o groupboxes
                LimpiarControles(ctrl)
            End If
        Next

        pnlContenidoDatos.AutoScrollPosition = New Point(0, 0)

        container.ResumeLayout()
        container.PerformLayout()
    End Sub

    Private Sub LimpiarGrids()
        If grvCompras.TieneDatos Then
            Dim resultado = MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                                 MensajesUI.ConfirmarAccion,
                                                 MessageBoxUI.TipoMensaje.Informacion,
                                                 MessageBoxUI.TipoBotones.SiNo)
            If resultado = DialogResult.Yes Then
                grvCompras.LimpiarGrid()
                ActivarControles(3) ' Activar controles para nueva compra)
            End If
        Else
            MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                 MensajesUI.GridSinDatos,
                                 MessageBoxUI.TipoMensaje.Informacion,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End If
    End Sub

    Private Sub AdminCompra(opcion As Integer)
        Dim datosID As Integer = 0
        ' Opción 0: Registrar nueva compra
        Select Case opcion
            Case 0
                ' Case 0: Registrar nueva compra
                If Not grvCompras.TieneDatos Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                         MensajesUI.GridSinDatos,
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)
                    Return
                End If

            Case 1
                ' Case 1: Actualizar compra existente
                If Not grvCompras.TieneDatos Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                         MensajesUI.CompletarDatos,
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)
                    Return
                End If
            Case 2 ' Eliminar compra existente
                Dim repo As New Repositorio_Compra
                Dim resultado = repo.Remove(DatosCompra._ordenCompra)

                If resultado Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloExito,
                                         MensajesUI.EliminacionExitosa,
                                         MessageBoxUI.TipoMensaje.Exito,
                                         MessageBoxUI.TipoBotones.Aceptar)
                    LimpiarCeldas()
                    ActivarControles(2)
                    Return
                Else
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         MensajesUI.OperacionFallida,
                                         MessageBoxUI.TipoMensaje.Errorr,
                                         MessageBoxUI.TipoBotones.Aceptar)
                    Return
                End If
        End Select
        ' Opción 1: Actualizar compra existente

        Dim compra As New TCompra With {
                    .CompraID = If(IsNothing(DatosCompra), 1, Integer.Parse(DatosCompra._compraID.ToString())),
                    .OrdenCompra = Convert.ToInt32(lblOrden.Texto),
                    .NumeroControl = txtNumeroControl.TextoUsuario.Trim(),
                    .NumeroFactura = txtNumeroFactura.TextoUsuario.Trim(),
                    .FechaCompra = txtFechaEmision.TextValue,
                    .EmpleadoID = CInt(Sesion.UsuarioID),
                    .AlicuotaID = 1,
                    .UbicacionDestinoID = CInt(cmbSucursal.ItemSeleccionado.Valor),
                    .ProveedorID = CInt(cmbProveedor.ItemSeleccionado.Valor),
                    .TipoPagoID = CInt(cmbTipoPago.ItemSeleccionado.Valor),
                    .Observacion = txtObservacion.TextString.Trim(),
                    .TotalCompra = grvCompras.CalcularTotal(),
                    .Detalle = grvCompras.GetDetalleList()
                }
        Dim service As New ComprasService()
        Try

            Select Case opcion
                Case 0
                    ' Case 0: Registrar nueva compra y retorna el id almacenado en resultado
                    Dim resultado As Integer = service.RegistrarCompra(compra)
                    If resultado > 0 And resultado <> -2627 Then
                        MessageBoxUI.Mostrar(MensajesUI.TituloExito,
                                             MensajesUI.RegistroExitoso,
                                             MessageBoxUI.TipoMensaje.Exito,
                                             MessageBoxUI.TipoBotones.Aceptar)

                        ObtenerNumeroOrdenCompra()
                        LimpiarCeldas()
                        ActivarControles(2)

                    ElseIf resultado = -2627 Then 'Si es duplicado mostrar el mensaje de error de duplicado
                        MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                             MensajesUI.RegistroDuplicado,
                                             MessageBoxUI.TipoMensaje.Informacion,
                                             MessageBoxUI.TipoBotones.Aceptar)

                    ElseIf resultado = -547 Then 'Si el valor co coincide en la base de datos
                        MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                             MensajesUI.OperacionFallida,
                                             MessageBoxUI.TipoMensaje.Informacion,
                                             MessageBoxUI.TipoBotones.Aceptar)
                    Else
                        MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                             MensajesUI.OperacionFallida,
                                             MessageBoxUI.TipoMensaje.Errorr,
                                             MessageBoxUI.TipoBotones.Aceptar)
                    End If
                Case 1
                    ' Case 1: Actualizar compra existente
                    Dim resultado As Boolean = service.ActualizarCompra(compra)
                    If resultado Then
                        MessageBoxUI.Mostrar(MensajesUI.TituloExito,
                                             MensajesUI.ActualizacionExitosa,
                                             MessageBoxUI.TipoMensaje.Exito,
                                             MessageBoxUI.TipoBotones.Aceptar)

                        ObtenerNumeroOrdenCompra()
                        LimpiarCeldas()
                        ActivarControles(2)
                    Else
                        MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                             MensajesUI.OperacionFallida,
                                             MessageBoxUI.TipoMensaje.Errorr,
                                             MessageBoxUI.TipoBotones.Aceptar)
                    End If
            End Select

        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
        End Try

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

    Private Sub ObtenerNumeroOrdenCompra()
        Dim OrdenMax As New Repositorio_Compra
        Dim resultado As Integer = OrdenMax.GetMax()
        lblOrden.Texto = FormatearConCeros(resultado)
    End Sub



#End Region

End Class
