Imports System.Runtime.InteropServices
Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.IdentityModel.Tokens
Public Class frm_Login

    Private llenarCombo As New LlenarComboBox

#Region "Form Behaviors"
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        MessageBoxUI.Mostrar("Cerrando el Sistema...", "Estas saliendo de la App Sistemas de Gestión para Óptica, Vuelve pronto... ", TipoMensaje.Informacion, Botones.Aceptar)
        'Application.Exit()
        Me.Close()
    End Sub
    Private Sub btnMinimizar_Click_1(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        WindowState = FormWindowState.Minimized
    End Sub

#End Region

#Region "Drag Form"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub pnlContenido_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlContenido.MouseMove
        ReleaseCapture()
        SendMessage(Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub frm_Login_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region

#Region "Customicer Control"
    Private Sub CustomizeComponent()
        With Me
            .FormBorderStyle = FormBorderStyle.None
            StartPosition = FormStartPosition.CenterScreen
        End With

    End Sub

#End Region

#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormStylerUI.Apply(Me)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CustomizeComponent()
    End Sub

#End Region

#Region "Formulario y Controles"

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        FadeManagerUI.StartFade(Me, 0.02)
        'LLENAR COMBO
        llenarCombo.Cargar(cmbLocal, llenarCombo.SQL_LOCALIDAD, "NombreUbicacion", "UbicacionID")
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        IniciarApp()
    End Sub
    Private Sub Logout(sender As Object, e As FormClosedEventArgs)
        txtUsuario.TextString = ""
        txtPass.TextString = ""
        cmbLocal.Limpiar()
        Me.Show()
    End Sub

    Private Sub txtPass_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPass.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtUsuario_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

#End Region


#Region "Procedimiento"
    Private Sub IniciarApp()
        ' Validar todos los campos requeridos
        Dim primerInvalido As Control = Nothing
        Dim esFormularioValido As Boolean = True

        For Each ctrl As Control In pnlContenido.Controls
            ' Validamos si el control implementa la interfaz IValidable
            If TypeOf ctrl Is IValidable Then
                Dim campo As IValidable = CType(ctrl, IValidable)
                If Not campo.EsValido() Then
                    esFormularioValido = False
                    If primerInvalido Is Nothing Then primerInvalido = CType(ctrl, Control)
                    Exit For
                End If
            End If
        Next

        If Not esFormularioValido Then
            MessageBoxUI.Mostrar("Campos Vacíos...", "Hay campos obligatorios sin completar, por favor verifique", TipoMensaje.Advertencia, Botones.Aceptar)
            primerInvalido?.Focus()
            Exit Sub
        End If

        'VALIDA EL CAMPO LOCALIAD
        If cmbLocal.cmbCampo.SelectedIndex = -1 Then
            MessageBoxUI.Mostrar("Datos incorrectos...", "Debe seleccionar una ubicación", TipoMensaje.Errors, Botones.Aceptar)
            cmbLocal.Focus()
            Exit Sub
        End If

        'Valida los datos del usuario
        Dim userModel As New Repositorio_Login
        Dim validUser = userModel.GetUserPass(txtUsuario.TextValue, txtPass.TextValue)
        If validUser.IsNullOrEmpty Then
            MessageBoxUI.Mostrar("Datos incorrectos...", "Nombre de usuario o contraseña incorrecto", TipoMensaje.Errors, Botones.Aceptar)
            txtUsuario.TextString = vbEmpty
            txtPass.TextString = vbEmpty
            cmbLocal.LimpiarComboBox()
            txtUsuario.Focus()
            Exit Sub
        End If

        Dim Usuario = validUser.FirstOrDefault()

        'INICIO DE VARIABLES DE SESION 
        Sesion.NombreUsuario = Usuario.Nombre & ", " & Usuario.Apellido
        Sesion.Cargo = Usuario.Cargo
        Sesion.NombreRol = Usuario.Permisos
        Sesion.NombreUbicacion = Usuario.Central
        Sesion.UsuarioID = Usuario.ID
        Sesion.UbicacionID = Usuario.UbicacionID

        Dim frm As New frm_Principal
        frm.Show()
        AddHandler frm.FormClosed, AddressOf Logout
        Hide()
    End Sub

#End Region


End Class