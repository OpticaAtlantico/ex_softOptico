Imports System.Runtime.InteropServices
Imports CapaNegocio

Public Class frmPerfilUsuario
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CustomizeComponent()

    End Sub

#Region "Form Behaviors"
    Private Sub btn_Cancelar_Click_1(sender As Object, e As EventArgs)

    End Sub
    Private Sub btn_Close_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btn_Minimizar_Click(sender As Object, e As EventArgs)
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

    Private Sub pnl_Titulo_MouseMove(sender As Object, e As MouseEventArgs)
        ReleaseCapture()
        SendMessage(Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub frmPerfilUsuario_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
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
        txt_PassActual.AutoSize = False
        txt_PassActual.Size = New Size(350, 35)
        txt_PassActual.UseSystemPasswordChar = True

        txt_PassNueva.AutoSize = False
        txt_PassNueva.Size = New Size(350, 35)
        txt_PassNueva.UseSystemPasswordChar = True

        txt_PassConfirmar.AutoSize = False
        txt_PassConfirmar.Size = New Size(350, 35)
        txt_PassConfirmar.UseSystemPasswordChar = True

    End Sub

    Private Sub frmPerfilUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlEditarDatos.Enabled = False
    End Sub

    Private Sub lnk_EditarPerfil_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_EditarPerfil.LinkClicked
        pnlEditarDatos.Enabled = True
        txt_Usuario.Focus()
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        pnlEditarDatos.Enabled = False
        Me.Close()
    End Sub

#End Region


End Class