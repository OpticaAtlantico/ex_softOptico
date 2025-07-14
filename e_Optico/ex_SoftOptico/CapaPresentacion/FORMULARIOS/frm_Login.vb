Imports System.Runtime.InteropServices
Imports System.Windows.Navigation
Imports CapaNegocio
Imports FontAwesome.Sharp
Imports Microsoft.IdentityModel.Tokens
Public Class frm_Login

#Region "Form Behaviors"
    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Application.Exit()
    End Sub

    Private Sub btn_Minimizar_Click(sender As Object, e As EventArgs) Handles btn_Minimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

#Region "Drag Form"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub pnl_Titulo_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_Titulo.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub frm_Login_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region

#Region "Customicer Control"
    Private Sub CustomizeComponent()
        'txt_User
        txt_Usuario.AutoSize = False
        txt_Usuario.Size = New Size(350, 35)

        'txt_Pass
        txt_Password.AutoSize = False
        txt_Password.Size = New Size(350, 35)
        txt_Password.UseSystemPasswordChar = True
    End Sub

    'Aplicar forma redonda a los bordes del boton
    Private Sub btn_Aceptar_Paint(sender As Object, e As PaintEventArgs)
        Dim buttonPath = New Drawing2D.GraphicsPath
        Dim myRectangle = btn_Aceptar.ClientRectangle
        myRectangle.Inflate(0, 10)
        buttonPath.AddEllipse(myRectangle)
        btn_Aceptar.Region = New Region(buttonPath)
    End Sub

#End Region

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CustomizeComponent()
    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click

        Dim ValidarDatos As Boolean = ValidarCampos()

        If ValidarDatos = True Then
            Dim userModel As New LoginModel
            Dim validUser = userModel.FindByUserPass(txt_Usuario.Text, txt_Password.Text)
            If validUser.IsNullOrEmpty Then
                MessageBox.Show("Nombre de Usuario o contraseña incorrecto" + vbCrLf + "Por favor intente nuevamente")
                ClearControls()
                txt_Usuario.Focus()
            Else
                Dim frm As New frm_Inicio
                frm.Show()
                AddHandler frm.FormClosed, AddressOf Logout
                Hide()
            End If
        Else
            MessageBox.Show("Por favor no debe dejar campos vacios" + vbCrLf + "intente nuevamente")
            ClearControls()
        End If
    End Sub

    Private Sub Logout(sender As Object, e As FormClosedEventArgs)
        txt_Usuario.Clear()
        txt_Password.Clear()
        cmb_Sucursal.Text = ""
        Me.Show()
        txt_Usuario.Focus()
    End Sub

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_Usuario.Focus()
        cmb_Sucursal.Items.Add("Atlantico I")
        cmb_Sucursal.Items.Add("Atlantico II")
        cmb_Sucursal.Items.Add("Atlantico III")
        cmb_Sucursal.Items.Add("Atlantico IV")
        cmb_Sucursal.Items.Add("Atlantico V")
        cmb_Sucursal.Items.Add("Atlantico Móvil")
    End Sub

    Private Function ValidarCampos() As Boolean
        Dim CampoVacio As Boolean = IIf(txt_Usuario.Text = "" Or txt_Password.Text = "", False, True)
        Return CampoVacio
    End Function

    Private Sub ClearControls()
        For Each control As Control In pnl_Controles.Controls
            If control.[GetType]() = GetType(TextBox) Then
                control.Text = ""
            End If
        Next
    End Sub

    
End Class