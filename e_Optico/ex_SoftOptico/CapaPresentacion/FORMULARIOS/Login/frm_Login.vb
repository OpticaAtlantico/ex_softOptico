Imports System.Runtime.InteropServices
Imports System.Windows.Navigation
Imports CapaDatos
Imports CapaNegocio
Imports DocumentFormat.OpenXml.Drawing.Charts
Imports FontAwesome.Sharp
Imports Microsoft.IdentityModel.Tokens
Public Class frm_Login

    Private animacionTimer As Timer
    Private tamanoInicial As Size
    Private ubicacionFinal As Point
    Private pasoActual As Integer = 0
    Private pasosTotales As Integer = 20

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

    Private Sub fadeTimer_Tick(sender As Object, e As EventArgs) Handles fadeTimer.Tick
        If Me.Opacity < 1.0 Then
            Me.Opacity += 0.05
        Else
            fadeTimer.Stop()
        End If
    End Sub

    Private Sub CerrarConFade()
        Dim cerrarTimer As New Timer()
        cerrarTimer.Interval = 20
        AddHandler cerrarTimer.Tick, Sub()
                                         If Me.Opacity > 0 Then
                                             Me.Opacity -= 0.05
                                         Else
                                             cerrarTimer.Stop()
                                             cerrarTimer.Dispose()
                                             Me.Close()
                                         End If
                                     End Sub
        cerrarTimer.Start()
    End Sub

#End Region
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CustomizeComponent()
    End Sub

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Opacity = 0
        fadeTimer.Start()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ' Validar todos los campos requeridos
        Dim primerInvalido As TextBoxLabelUI = Nothing
        Dim esFormularioValido As Boolean = True

        For Each ctrl As Control In pnlContenido.Controls
            If TypeOf ctrl Is TextBoxLabelUI Then
                Dim campo As TextBoxLabelUI = CType(ctrl, TextBoxLabelUI)
                If Not campo.EsValido() Then
                    esFormularioValido = False
                    If primerInvalido Is Nothing Then primerInvalido = campo
                End If
            End If
        Next

        If Not esFormularioValido Then
            MessageBoxUI.Mostrar("Campos Vacios...", "Hay campos obligatorios sin completar, por favor verifique", TipoMensaje.Advertencia, Botones.Aceptar)
            primerInvalido?.Focus()
            Exit Sub
        End If

        'VALIDA LOS USUARIOS Y CONTRASEÑAS
        Dim userModel As New Repositorio_VLogin
        Dim validUser = userModel.GetAllUserPass(txtUsuario.TextValue, txtPass.TextValue)
        If validUser.IsNullOrEmpty Then
            MessageBoxUI.Mostrar("Datos incorrectos...", "Nombre de usuario o contraseña incorrecto", TipoMensaje.Errors, Botones.Aceptar)
            txtUsuario.Text = vbEmpty
            txtPass.Text = vbEmpty
            txtUsuario.Focus()
            Exit Sub
        End If

        Dim Usuario = validUser.FirstOrDefault()

        Dim frm As New frm_Principal
        With frm
            .lblUsuario.Text = Usuario.Nombre & ", " & Usuario.Apellido
            .lblCargo.Text = Usuario.Permisos
        End With

        frm.Show()
        AddHandler frm.FormClosed, AddressOf Logout
        Hide()

    End Sub

    Private Sub Logout(sender As Object, e As FormClosedEventArgs)
        txtUsuario.TextoUsuario = ""
        txtPass.TextoUsuario = ""
        Me.Show()
    End Sub

End Class