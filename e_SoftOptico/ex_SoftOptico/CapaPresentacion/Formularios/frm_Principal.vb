Imports System.Runtime.InteropServices
Imports System.Windows
Imports System.Windows.Forms
Imports CapaEntidad

Public Class frm_principal

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

#End Region

#Region "Funciones del Formulario"
    Private Sub btn_Cerrar_Click(sender As Object, e As EventArgs) Handles btn_Cerrar.Click
        If MsgBox("¿Está usted seguro de salir del sistema?", MessageBoxButton.YesNo + MessageBoxIcon.Question, "Exit") = DialogResult.Yes Then
            End
        End If

    End Sub

    Private Sub btn_Maximizar_Click(sender As Object, e As EventArgs) Handles btn_Maximizar.Click
        btn_Maximizar.Visible = False
        btn_Restore.Visible = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btn_Minimizar_Click(sender As Object, e As EventArgs) Handles btn_Minimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_Restore_Click(sender As Object, e As EventArgs) Handles btn_Restore.Click
        btn_Restore.Visible = False
        btn_Maximizar.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub tmr_OcultarMenu_Tick(sender As Object, e As EventArgs) Handles tmr_OcultarMenu.Tick
        If pnl_Menu.Width <= 60 Then
            Me.tmr_OcultarMenu.Enabled = False
        Else
            Me.pnl_Menu.Width = pnl_Menu.Width - 40
        End If
    End Sub

    Private Sub tmr_MostrarMenu_Tick(sender As Object, e As EventArgs) Handles tmr_MostrarMenu.Tick
        If pnl_Menu.Width >= 220 Then
            Me.tmr_MostrarMenu.Enabled = False
        Else
            Me.pnl_Menu.Width = pnl_Menu.Width + 40
        End If
    End Sub
#End Region

    Private Sub IconButton2_Click(sender As Object, e As EventArgs) Handles IconButton2.Click
        If pnl_Menu.Width = 220 Then
            tmr_OcultarMenu.Enabled = True
        ElseIf pnl_Menu.Width = 60 Then
            tmr_MostrarMenu.Enabled = True
        End If
    End Sub

    Private Sub AbrirFrmPanel(ByVal FrmHijo As Object)
        With Me
            If .pnl_Contenedor.Controls.Count > 0 Then
                .pnl_Contenedor.Controls.RemoveAt(0)
            End If
            Dim frm As Form = TryCast(FrmHijo, Form)
            frm.TopLevel = False
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            .pnl_Contenedor.Controls.Add(frm)
            .pnl_Contenedor.Tag = frm
            frm.Show()
        End With
    End Sub

    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        AbrirFrmPanel(New frm_Usuario)
    End Sub

    Private Sub btn_Logout_Click(sender As Object, e As EventArgs) Handles btn_Logout.Click
        If MsgBox("¿Está usted seguro de cerrar sesión?", MessageBoxButton.YesNo + MessageBoxIcon.Question, "Cerrar Sesión") = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub frm_principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Me
            .lbl_Posicion.Text = ActiveUser.Posicion
            .lbl_Correo.Text = ActiveUser.Usuario
            .lbl_Usuario.Text = ActiveUser.Nombre
        End With

    End Sub
End Class