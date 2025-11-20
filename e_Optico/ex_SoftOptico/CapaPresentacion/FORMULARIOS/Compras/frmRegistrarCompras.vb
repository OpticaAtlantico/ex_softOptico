Imports CapaDatos
Imports CapaEntidad
Imports CapaNegocio
Imports FontAwesome.Sharp

Public Class frmRegistrarCompras

    ' Referencias a los usercontrols (se crean en tiempo de carga)
    Private cDatosProveedor1 As cDatosProveedor
    Private cDatosProductos1 As cDatosProductos

    Private DatosCompra As VCompras = Nothing
    Private NombreBoton As String = String.Empty

    Private Sub frmRegistrarCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Crear instancias de usercontrols
        cDatosProductos1 = New cDatosProductos()
        cDatosProveedor1 = New cDatosProveedor()

        ' Construir pestañas
        Dim tab1 As New TabItemOrbitalAdv With {
            .Titulo = "Datos del Proveedor",
            .Icono = IconChar.ExchangeAlt,
            .Contenido = cDatosProveedor1
        }

        Dim tab2 As New TabItemOrbitalAdv With {
            .Titulo = "Datos de los Productos",
            .Icono = IconChar.Boxes,
            .Contenido = cDatosProductos1
        }

        Dim tabPanel As New TabPanelUI With {
            .Dock = DockStyle.Fill,
            .TabHeight = 48
        }

        tabPanel.AddTab(tab1)
        tabPanel.AddTab(tab2)

        Me.pnlContenido.Controls.Clear()
        Me.pnlContenido.Controls.Add(tabPanel)

        ' Permitir navegación entre pestañas desde los usercontrols
        cDatosProductos1.TabPanelRef = tabPanel
        cDatosProveedor1.TabPanelRef = tabPanel

        tabPanel.SeleccionarPestana(0)

        AddHandler tabPanel.TabChanged, AddressOf TabPanel_TabChanged

        ' Inicializar número de orden
        ObtenerNumeroOrdenCompra()
    End Sub

    Private Sub TabPanel_TabChanged(index As Integer, titulo As String)
        ' Placeholder: acciones al cambiar de pestaña (si necesitas)
    End Sub

    Private Sub ObtenerNumeroOrdenCompra()
        Dim OrdenMax As New Repositorio_Compra
        Dim resultado As Integer = OrdenMax.GetMax()
        ' En este formulario el diseñador expone lblTitulo (HeaderUI). Uso Subtitulo para mostrar el número.
        lblTitulo.Subtitulo = resultado.ToString().PadLeft(6, "0"c)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            ' 1) Recoger info desde los usercontrols
            Dim provInfo = cDatosProveedor1.GetProveedorInfo() ' Debe devolver DTO con NumeroControl, NumeroFactura, FechaEmision, ProveedorID, etc.
            Dim detalle As List(Of TDetalleCompra) = cDatosProductos1.GetDetalleList()   ' Ahora devuelve List(Of TDetalleCompra)

            If detalle Is Nothing OrElse detalle.Count = 0 Then
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo, MensajesUI.GridSinDatos, MessageBoxUI.TipoMensaje.Advertencia, MessageBoxUI.TipoBotones.Aceptar)
                Return
            End If

            ' 2) Validaciones mínimas proveedor
            If provInfo Is Nothing OrElse
               String.IsNullOrWhiteSpace(provInfo.NumeroControl) OrElse
               String.IsNullOrWhiteSpace(provInfo.NumeroFactura) OrElse
               Not provInfo.FechaEmision.HasValue OrElse
               Not provInfo.ProveedorID.HasValue Then

                MessageBoxUI.Mostrar(MensajesUI.TituloInfo, MensajesUI.DatosIncompletos, MessageBoxUI.TipoMensaje.Errorr, MessageBoxUI.TipoBotones.Aceptar)
                Return
            End If

            ' 2b) Validaciones por línea de detalle
            For i As Integer = 0 To detalle.Count - 1
                Dim d = detalle(i)
                If d.ProductoID <= 0 Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo, $"Línea {i + 1}: Producto inválido (ProductoID = 0).", MessageBoxUI.TipoMensaje.Advertencia, MessageBoxUI.TipoBotones.Aceptar)
                    Return
                End If
                If d.Cantidad <= 0 Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo, $"Línea {i + 1}: La cantidad debe ser mayor que cero.", MessageBoxUI.TipoMensaje.Advertencia, MessageBoxUI.TipoBotones.Aceptar)
                    Return
                End If
                If d.PrecioUnitario < 0D Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo, $"Línea {i + 1}: Precio unitario inválido.", MessageBoxUI.TipoMensaje.Advertencia, MessageBoxUI.TipoBotones.Aceptar)
                    Return
                End If
            Next

            ' 3) Construir TCompra
            Dim orden As Integer = 0
            Integer.TryParse(lblTitulo.Subtitulo, orden)

            Dim compra As New TCompra With {
                .CompraID = If(IsNothing(DatosCompra), 1, Integer.Parse(DatosCompra._compraID.ToString())),
                .OrdenCompra = orden,
                .NumeroControl = provInfo.NumeroControl.Trim(),
                .NumeroFactura = provInfo.NumeroFactura.Trim(),
                .FechaCompra = If(provInfo.FechaEmision.HasValue, provInfo.FechaEmision.Value, Date.Now),
                .EmpleadoID = CInt(Sesion.UsuarioID),
                .AlicuotaID = 1,
                .UbicacionDestinoID = If(provInfo.SucursalID.HasValue, provInfo.SucursalID.Value, 1),
                .ProveedorID = If(provInfo.ProveedorID.HasValue, provInfo.ProveedorID.Value, 0),
                .TipoPagoID = If(provInfo.TipoPagoID.HasValue, provInfo.TipoPagoID.Value, 1),
                .Observacion = If(provInfo.Observacion, String.Empty).Trim(),
                .TotalCompra = 0D,
                .Detalle = detalle
            }

            ' Calcular total del detalle
            Dim total As Decimal = 0D
            For Each d As TDetalleCompra In compra.Detalle
                Dim lineaTotal = (d.PrecioUnitario * d.Cantidad) - d.Descuento
                total += lineaTotal
            Next
            compra.TotalCompra = total

            ' 4) Llamar al servicio para registrar
            Dim service As New ComprasService()
            Dim resultado As Integer = service.RegistrarCompra(compra)

            If resultado > 0 And resultado <> -2627 Then
                MessageBoxUI.Mostrar(MensajesUI.TituloExito, MensajesUI.RegistroExitoso, MessageBoxUI.TipoMensaje.Exito, MessageBoxUI.TipoBotones.Aceptar)
                ObtenerNumeroOrdenCompra()
            ElseIf resultado = -2627 Then
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo, MensajesUI.RegistroDuplicado, MessageBoxUI.TipoMensaje.Informacion, MessageBoxUI.TipoBotones.Aceptar)
            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError, MensajesUI.OperacionFallida, MessageBoxUI.TipoMensaje.Errorr, MessageBoxUI.TipoBotones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError, String.Format(MensajesUI.ErrorInesperado, ex.Message), MessageBoxUI.TipoMensaje.Errorr, MessageBoxUI.TipoBotones.Aceptar)
        End Try
    End Sub

    ' Optional: limpia los usercontrols tras un guardado exitoso
    Private Sub LimpiarUserControls()
        Try
            ' Si tus controles exponen métodos de limpieza, úsalos; aquí limpiamos manualmente si es necesario.
            ' Ejemplo hipotético:
            ' cDatosProveedor1.Limpiar()
            ' cDatosProductos1.Limpiar()
        Catch
        End Try
    End Sub

End Class