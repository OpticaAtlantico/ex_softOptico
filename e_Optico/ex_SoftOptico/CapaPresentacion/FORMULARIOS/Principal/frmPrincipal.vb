Public Class frmPrincipal

    Private drawer As DrawerControlUI
    Private drawerAbierto As Boolean = True
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.WindowState = FormWindowState.Maximized
        drawer = New DrawerControlUI()
        drawer.Dock = DockStyle.Left
        pnlMenu.Controls.Add(drawer)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler btnMostrarMenu.Click, Sub() drawer.ToggleDrawer()
    End Sub
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class