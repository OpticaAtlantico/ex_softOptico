Imports CapaDatos
Imports CapaEntidad
Imports CapaNegocio
Imports FontAwesome.Sharp
Imports Microsoft.Data.SqlClient
Imports OfficeOpenXml.Drawing.Slicer.Style
Imports System.Reflection

Public Class frmProveedor
    Implements INotificaCierreFrm

    'Para noticar al frmPrincipal el evento de cierre del formulario empleado
    Public Event FormularioFinalizado As EventHandler Implements INotificaCierreFrm.FormularioFinalizado

    Private rutaImagenSeleccionada As String = ""
    Public Property DatosProveedor As VProveedor = Nothing
    Public Property NombreBoton As String = String.Empty

#Region "CONSTRUCTOR"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        FormStylerUI.Apply(Me)

    End Sub

    ' Aplica WS_EX_COMPOSITED para suavizar repintado de todo el formulario
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

#End Region

#Region "EVENTOS DE FORMULARIO"
    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.SuspendLayout()

        CargarCombos.CargarComboDesacoplado(cmbSiglas, GetType(Siglas))
        If DatosProveedor IsNot Nothing Then
            CargarDatos(DatosProveedor)
        End If

        btnAccion.Cursor = Cursors.Hand
        btnAccion.ColorTexto = Color.DarkSlateBlue
        Select Case NombreBoton
            Case "Actualizar"
                btnAccion.Texto = "Actualizar"
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPen
            Case "Eliminar"
                btnAccion.Texto = "Eliminar"
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserTimes
            Case Else
                btnAccion.Texto = "Guardar"
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPlus
        End Select

        With Me.lblEncabezado
            .Titulo = btnAccion.Texto & " Proveedor"
            .Subtitulo = "Aministrar los datos del proveedor..."
            .Icono = btnAccion.Icono
            .ColorFondo = AppColors._cEncabezado
            .ColorTexto = AppColors._cBlancoOscuro
            .Dock = DockStyle.Fill
            .Anchor = AnchorStyles.Top And AnchorStyles.Left
        End With

        With Me.pnlDatos
            .BackColorContenedor = AppColors._cBack
            .BorderColor = AppColors._cLinea
            .ShadowColor = AppColors._cShadow
            .BorderRadius = 20
            .BorderSize = 1
            .CardBackColor = AppColors._cBlanco
            .Estilo = PanelUI.EstiloCard.None
        End With

        With Me.pnlEncabezado
            .BackColor = AppColors._cFooter
            .Dock = DockStyle.Top
            .Height = 60
        End With

        With Me.pnlFooter
            .BackColor = AppColors._cFooter
            .Dock = DockStyle.Bottom
            .Height = 50
        End With

        Me.ResumeLayout()
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

    Private Sub txtNombreEmpresa_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreEmpresa.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtRazonSocial_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRazonSocial.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtCorreo_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtRif_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRif.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtTelefono_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtContacto_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContacto.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

#End Region

#Region "PROCEDIMIENTOS"
    Private Sub bntAccion_Click(sender As Object, e As EventArgs) Handles btnAccion.Click
        Select Case btnAccion.Texto
            Case "Actualizar"
                ' Validación centralizada antes de procesar
                If Not ValidarControles() Then Exit Sub

                If DatosProveedor IsNot Nothing Then
                    ProcesarProveedor(esNuevo:=False)
                Else
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         MensajesUI.SinResultados,
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)
                End If
            Case "Eliminar"
                ' No se requiere validación al eliminar
                Try
                    Dim id As Integer = Convert.ToInt32(DatosProveedor._proveedorID)

                    Dim service As New ServiceProveedor()
                    Dim ok As Boolean = service.Eliminar(id)

                    If ok Then
                        Dim toast As New ToastUI("Proveedor eliminado correctamente.", TipoToastUI.Success)

                        RaiseEvent FormularioFinalizado(Me, EventArgs.Empty)
                        Me.Close()
                        toast.Mostrar()
                    Else
                        MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                            (MensajesUI.ErrorInesperado),
                                            MessageBoxUI.TipoMensaje.Errorr,
                                            MessageBoxUI.TipoBotones.Aceptar)
                    End If

                Catch ex As Exception
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                    MessageBoxUI.TipoMensaje.Errorr,
                                    MessageBoxUI.TipoBotones.Aceptar)
                End Try

            Case "Guardar"
                ' Validación centralizada antes de guardar
                If Not ValidarControles() Then Exit Sub

                If DatosProveedor Is Nothing Then
                    ProcesarProveedor(esNuevo:=True)
                Else
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         MensajesUI.RegistroDuplicado,
                                         MessageBoxUI.TipoMensaje.Errorr,
                                         MessageBoxUI.TipoBotones.Aceptar)
                End If
            Case Else
                MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                     MensajesUI.OperacionFallida,
                                     MessageBoxUI.TipoMensaje.Errorr,
                                     MessageBoxUI.TipoBotones.Aceptar)
        End Select
    End Sub

    ' Recibe un objeto TEmpleados y rellena los controles del formulario.
    Public Sub CargarDatos(ByVal proveedor As VProveedor)
        ' Primero, verificamos que el objeto no sea nulo para evitar errores.
        If proveedor IsNot Nothing Then
            ' Asignamos los datos del objeto a los controles
            With Me
                txtNombreEmpresa.TextString = proveedor._nombreEmpresa
                txtRazonSocial.TextString = proveedor._razonSocial
                txtCorreo.TextString = proveedor._correo
                cmbSiglas.Texto = proveedor._sigla
                txtRif.TextString = proveedor._rif
                txtTelefono.TextString = proveedor._telefono
                txtContacto.TextString = proveedor._contacto
                txtDireccion.TextString = proveedor._direccion
            End With
        End If
    End Sub

#End Region

#Region "VALIDACIÓN REUTILIZABLE"
    Private Function ValidarControles() As Boolean
        Dim vr = FormValidator.ValidateContainer(Me)

        If Not vr.IsValid Then
            Try
                Dim foco = FormValidator.FindFocusableChild(If(vr.FirstInvalid, Me))
                If foco IsNot Nothing Then
                    foco.Focus()
                ElseIf vr.FirstInvalid IsNot Nothing Then
                    vr.FirstInvalid.Focus()
                End If
            Catch
            End Try

            Try
                MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                     vr.Message,
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            Catch
                MessageBox.Show(vr.Message, MensajesUI.TituloAdvertencia, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            Return False
        End If

        Return True
    End Function
#End Region

#Region "SQL"
    Private Function ObtenerDatosProveedor(Optional ByVal incluirID As Boolean = False) As ResultadoProveedor
        Dim resultado As New ResultadoProveedor()
        Try
            Dim id As Integer = If(incluirID, DatosProveedor._proveedorID, 0)
            Dim nombre = txtNombreEmpresa.TextValue.Trim()
            Dim razonSocial = txtRazonSocial.TextValue.Trim()
            Dim correo = txtCorreo.TextValue.Trim()
            Dim sigla = Convert.ToInt32(cmbSiglas.IndiceSeleccionado)
            Dim rif = txtRif.TextValue.Trim()
            Dim telefono = txtTelefono.TextValue.Trim()
            Dim contacto = txtContacto.TextValue.Trim()
            Dim direccion = txtDireccion.TextValue.Trim()

            If {id, nombre, razonSocial, correo, sigla, rif, telefono, contacto, direccion}.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                     MensajesUI.DatosIncompletos,
                                     MessageBoxUI.TipoMensaje.Errorr,
                                     MessageBoxUI.TipoBotones.Aceptar)

                resultado.EsValido = False
                Return resultado
            End If

            resultado.Proveedor = New TProveedor With {
                                                        .ProveedorID = id,
                                                        .nombreEmpresa = nombre,
                                                        .razonSocial = razonSocial,
                                                        .correo = correo,
                                                        .sigla = sigla,
                                                        .rif = rif,
                                                        .telefono = telefono,
                                                        .contacto = contacto,
                                                        .direccion = direccion
                                                    }

            resultado.EsValido = True
        Catch ex As Exception

            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)

            resultado.EsValido = False
        End Try

        Return resultado
    End Function

    Private Sub ProcesarProveedor(esNuevo As Boolean)
        Dim datos = ObtenerDatosProveedor(incluirID:=Not esNuevo)

        If Not datos.EsValido Then Exit Sub

        Dim service As New ServiceProveedor()

        Try
            Dim exito As Boolean
            If esNuevo Then
                exito = service.Guardar(datos.Proveedor)
            Else
                exito = service.Actualizar(datos.Proveedor)
            End If

            If exito Then
                Dim mensaje As New ToastUI(If(esNuevo, MensajesUI.RegistroExitoso,
                                                   MensajesUI.ActualizacionExitosa),
                                                   TipoToastUI.Success)

                RaiseEvent FormularioFinalizado(Me, EventArgs.Empty)
                Me.Close()
                mensaje.Mostrar()
            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 MensajesUI.OperacionFallida,
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                             ex.Message,
                             MessageBoxUI.TipoMensaje.Errorr,
                             MessageBoxUI.TipoBotones.Aceptar)

        End Try

    End Sub
#End Region

End Class