Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles
Imports CapaPresentacion.TexboxConPlaceholder

Public Class frm_Empleado
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
        txtCedula.AutoSize = False
        txtCedula.Size = New Size(297, 35)

        txt_Nombres.AutoSize = False
        txt_Nombres.Size = New Size(297, 35)

        txt_Apellidos.AutoSize = False
        txt_Apellidos.Size = New Size(297, 35)

        txt_Correo.AutoSize = False
        txt_Correo.Size = New Size(297, 35)

        txt_Direccion.AutoSize = False
        txt_Direccion.Size = New Size(297, 35)

        txt_Edad.AutoSize = False
        txt_Edad.Size = New Size(297, 35)

        txt_FechaNacimiento.AutoSize = False
        txt_FechaNacimiento.Size = New Size(297, 35)

        txt_Telefono.AutoSize = False
        txt_Telefono.Size = New Size(297, 35)






    End Sub

    Private Sub frm_Empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me



        End With
    End Sub




#End Region


End Class