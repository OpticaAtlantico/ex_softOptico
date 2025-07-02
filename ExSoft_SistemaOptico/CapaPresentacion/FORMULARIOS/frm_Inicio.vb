Imports System.Runtime.InteropServices
Imports CapaDatos
Imports CapaEntidad
Imports CapaNegocio
Imports FontAwesome.Sharp

Public Class frm_Inicio

    Private currentButton As Button
    Private random As Random
    Private tempIndex As Integer
    Private activeForms As Form
    Private themeColor As New ThemeColors

    Dim loginmodelo = listLogin

#Region "CONSTRUCTOR"
    Public Sub New()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Esta llamada es exigida por el diseñador.

        InitializeComponent()

        random = New Random()
        currentButton = New Button()
        Me.btnCloseChildForm.Visible = False
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
    End Sub

#End Region

#Region "METODO"
    Private Function SelectThemeColor() As Color
        Dim index As Integer = random.[Next](themeColor.ColorList.Count)
        While tempIndex = index
            index = random.Next(themeColor.ColorList.Count)
        End While
        tempIndex = index
        Dim color As String = themeColor.ColorList(index)

        Return ColorTranslator.FromHtml(color)
    End Function
#End Region

#Region "PROCEDIMIENTOS"
    Private Sub ActivateButton(btnSender As Object)
        If btnSender IsNot Nothing Then
            If currentButton.Name <> CType(btnSender, Button).Name Then
                DisableButton()
                Dim color As Color = SelectThemeColor()
                currentButton = CType(btnSender, Button)
                currentButton.BackColor = color
                currentButton.ForeColor = Color.White
                currentButton.Font = New System.Drawing.Font("Century Gothic", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
                If currentButton.Name = "btnEditarPerfil" Then currentButton.Font = New System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
                btn_Minimizar.BackColor = color
                btn_Maximizar.BackColor = color
                btnCerrar.BackColor = color
                pnl_Encabezado.BackColor = color
                pnl_Logo.BackColor = themeColor.ChangeColorBrightness(color, -0.3)
                themeColor.PrimaryColor = color
                themeColor.SecondaryColor = themeColor.ChangeColorBrightness(color, -0.3)
                icoMenu.BackColor = themeColor.ChangeColorBrightness(color, -0.3)
                btnEditarPerfil.BackColor = themeColor.ChangeColorBrightness(color, -0.3)
                btnCloseChildForm.Visible = True
            End If
        End If
    End Sub
    Private Sub DisableButton()
        btn_Maximizar.BackColor = Color.FromArgb(0, 150, 136)
        btn_Minimizar.BackColor = Color.FromArgb(0, 150, 136)
        btnCerrar.BackColor = Color.FromArgb(0, 150, 136)
        For Each previousBtn As Control In pnl_Menu.Controls
            If previousBtn.[GetType]() = GetType(IconButton) Then
                previousBtn.BackColor = Color.FromArgb(51, 51, 76)
                previousBtn.ForeColor = Color.Gainsboro
                previousBtn.Font = New System.Drawing.Font("Century Gothic", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
            End If
        Next
        For Each previousBtn As Control In pnl_Logo.Controls
            If previousBtn.[GetType]() = GetType(IconButton) Then
                previousBtn.BackColor = Color.FromArgb(39, 39, 58)
                previousBtn.ForeColor = Color.WhiteSmoke
                previousBtn.Font = New System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
            End If
        Next
    End Sub
    Private Sub OpenChildForm(childForm As Form, btnSender As Object)
        If activeForms IsNot Nothing Then activeForms.Close()
        ActivateButton(btnSender)
        activeForms = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Me.pnl_Contenedor.Controls.Add(childForm)
        Me.pnl_Contenedor.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
        lbl_Titulo.Text = childForm.Text

    End Sub
    Private Sub Reset()
        DisableButton()
        lbl_Titulo.Text = "HOME"
        pnl_Encabezado.BackColor = Color.FromArgb(0, 150, 136)
        pnl_Logo.BackColor = Color.FromArgb(39, 39, 58)
        currentButton = New Button()
        btnCloseChildForm.Visible = False
    End Sub

#End Region

#Region "DRAG FORM"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
#End Region

#Region "CONTROLES"
    Private Sub btnCloseChildForm_Click(sender As Object, e As EventArgs) Handles btnCloseChildForm.Click
        If (Not (activeForms) Is Nothing) Then
            activeForms.Close()
        End If
        Reset()
    End Sub
    Private Sub pnl_Encabezado_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_Encabezado.MouseDown
        'Funcion para permitir mover el formulario por todas partes
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
#End Region

    'EVENTS

    'CLOSE, MAXIMIZE, MINIMIZE FORM MAIN'
    Private Sub btn_Minimizar_Click(sender As Object, e As EventArgs) Handles btn_Minimizar.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_Maximizar_Click(sender As Object, e As EventArgs) Handles btn_Maximizar.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        listLogin.clear()
        Me.Close()
    End Sub
    Private Sub tmr_OcultarMenu_Tick(sender As Object, e As EventArgs) Handles tmr_OcultarMenu.Tick
        If pnl_Menu.Width <= 60 Then
            Me.tmr_OcultarMenu.Enabled = False
        Else
            Me.pnl_Menu.Width = pnl_Menu.Width - 40
            imgLogo.Width = 55
            btnEditarPerfil.Visible = False
        End If
    End Sub

    Private Sub tmr_MostrarMenu_Tick(sender As Object, e As EventArgs) Handles tmr_MostrarMenu.Tick
        If pnl_Menu.Width >= 220 Then
            Me.tmr_MostrarMenu.Enabled = False
        Else
            Me.pnl_Menu.Width = pnl_Menu.Width + 40
            imgLogo.Width = 87
            btnEditarPerfil.Visible = True
        End If
    End Sub

    Private Sub icoMenu_Click(sender As Object, e As EventArgs)
        If pnl_Menu.Width = 220 Then
            tmr_OcultarMenu.Enabled = True
        ElseIf pnl_Menu.Width = 60 Then
            tmr_MostrarMenu.Enabled = True
        End If
    End Sub

    Private Sub imgLogo_Click(sender As Object, e As EventArgs) Handles imgLogo.Click
        If btnEditarPerfil.Visible = False Then
            OpenChildForm(New frm_Usuario, sender)
        End If

    End Sub
    Private Sub btnEditarPerfil_Click(sender As Object, e As EventArgs) Handles btnEditarPerfil.Click
        OpenChildForm(New frmPerfilUsuario, sender)
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs)
        OpenChildForm(New frm_Usuario, sender)
    End Sub

    Private Sub frm_Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        lblUsuario.Text = listLogin.item(0).Nombre.ToString()
        lblCargo.Text = listLogin.item(0).Posicion.ToString()
    End Sub

    Private Sub btn_1_Click(sender As Object, e As EventArgs) Handles btn_1.Click
        MessageBox.Show("Hola")
    End Sub
End Class