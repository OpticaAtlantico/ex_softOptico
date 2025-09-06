Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles
Imports CapaPresentacion.TexboxConPlaceholder
Imports Microsoft.Data

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

        'cmbUno.AddItems("", "Caracas", "Puerto Ordaz", "Maracaibo", "Valencia")

        Dim manager As New LlenarComboBox()
        Dim sql As String = "SELECT CargoEmpleadoID, Descripcion FROM VCargoEmpleado"
        manager.Cargar(cmbCargo, sql, "Descripcion", "CargoEmpleadoID")
        'cmbUno.OrbitalCombo.SelectedIndex = -1


        'pnlEntrada.Enabled = False

    End Sub

    Private Sub frm_Empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomizeComponent()

    End Sub

    Private Sub lnk_EditarUsuario_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_EditarUsuario.LinkClicked
        With Me
            If .pnlEntrada.Enabled Then

            Else
                .pnlEntrada.Enabled = True

            End If
        End With
    End Sub

    Private Sub CommandButtonui1_Click(sender As Object, e As EventArgs)

    End Sub



#End Region


End Class