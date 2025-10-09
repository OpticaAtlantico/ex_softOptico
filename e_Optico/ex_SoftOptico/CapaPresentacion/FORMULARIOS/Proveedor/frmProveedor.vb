Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Imports Microsoft.Data.SqlClient
Imports OfficeOpenXml.Drawing.Slicer.Style

Public Class frmProveedor

    Private rutaImagenSeleccionada As String = ""
    Public Property DatosProveedor As VProveedor = Nothing
    Public Property NombreBoton As String = String.Empty

    Public Event CerrarProveedor As EventHandler

#Region "CONSTRUCTOR"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        FormStylerUI.Apply(Me)

        ' Add any initialization after the InitializeComponent() call.
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

        'CargarCombos.CargarComboDesacoplado(cmbSiglas, GetType(Siglas))

        If DatosProveedor IsNot Nothing Then
            CargarDatos(DatosProveedor)
        End If

        btnAccion.Cursor = Cursors.Hand
        btnAccion.ColorTexto = Color.DarkSlateBlue
        Select Case NombreBoton
            Case "Actualizar..."
                btnAccion.Texto = "Actualizar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPen
            Case "Eliminar..."
                btnAccion.Texto = "Eliminar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserTimes
            Case Else
                btnAccion.Texto = "Guardar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPlus
        End Select

        With Me.lblEncabezado
            .Titulo = "Nuevo Proveedor"
            .Subtitulo = "Administracion de los datos del proveedor activo..."
            .Icono = IconChar.UserCheck
            .ColorFondo = Color.FromArgb(0, 191, 192)
            .ColorTexto = Color.WhiteSmoke
        End With
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
            Case "Actualizar..."
                ' Aquí puedes implementar la lógica para actualizar el empleado
                If DatosProveedor IsNot Nothing Then
                    ProcesarProveedor(esNuevo:=False)
                Else
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         MensajesUI.OperacionFallida,
                                         MessageBoxUI.TipoMensaje.Errorr,
                                         MessageBoxUI.TipoBotones.Aceptar)
                End If
            Case "Eliminar..."
                ' Aquí puedes implementar la lógica para eliminar el empleado
                Dim ProveedorId As Integer = DatosProveedor._proveedorID
                Dim confirmacion = MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                                        MensajesUI.ConfirmarAccion,
                                                        MessageBoxUI.TipoMensaje.Advertencia,
                                                        MessageBoxUI.TipoBotones.AceptarCancelar)

                If confirmacion = DialogResult.Yes Then
                    'EliminarProveedor(empleadoId)
                    Me.Close() ' Cierra el formulario después de eliminar
                    frm_Principal.btnSalirFrmHijo.Visible = False ' Deshabilita botones de la ventana principal  
                End If

            Case "Guardar..."
                ' Aquí puedes implementar la lógica para guardar un nuevo empleado
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

    Private Sub LimpiarControles(container As Control)
        container.SuspendLayout()

        ' Recorre todos los controles dentro del contenedor y limpia sus valores

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

        container.ResumeLayout()
        container.PerformLayout()
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
                cmbSiglas.OrbitalCombo.Text = proveedor._sigla
                txtRif.TextoUsuario = proveedor._rif
                txtTelefono.TextoUsuario = proveedor._telefono
                txtContacto.TextoUsuario = proveedor._contacto
                txtDireccion.TextString = proveedor._direccion
            End With
        End If
    End Sub

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

        Dim repositorio As New Repositorio_Proveedor()
        Dim exito As Boolean = False

        Try
            If esNuevo Then
                exito = repositorio.Add(datos.Proveedor)
            Else
                exito = repositorio.Edit(datos.Proveedor)
            End If

            'exito es para 
            If exito Then
                Dim mensaje As New ToastUI(If(esNuevo,
                                           MensajesUI.RegistroExitoso,
                                           MensajesUI.ActualizacionExitosa),
                                           TipoToastUI.Success)
                mensaje.Mostrar()

                LimpiarControles(Me)

            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                    MensajesUI.ErrorInesperado,
                                    MessageBoxUI.TipoMensaje.Errorr,
                                    MessageBoxUI.TipoBotones.Aceptar)
            End If
        Catch ex As Exception
            If TypeOf ex.InnerException Is SqlException Then
                Dim sqlEx = CType(ex.InnerException, SqlException)
                If sqlEx.Number = 2627 Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                             MensajesUI.RegistroDuplicado,
                                             MessageBoxUI.TipoMensaje.Errorr,
                                             MessageBoxUI.TipoBotones.Aceptar)
                    Exit Sub
                End If
            End If
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                MessageBoxUI.TipoMensaje.Errorr,
                                MessageBoxUI.TipoBotones.Aceptar)
        End Try
    End Sub

    Private Sub frmProveedor_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        RaiseEvent CerrarProveedor(Me, EventArgs.Empty)
    End Sub

#End Region

End Class