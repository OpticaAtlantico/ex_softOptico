Public Class frmPruebaDrawer
    Inherits Form

    Private PanelEncabezado As New Panel()
    Private PanelMenu As New Panel()
    Private PanelContenido As New Panel()
    Private DrawerPanel As New Panel()
    Private BotonDrawer As New Button()
    Private WithEvents DrawerTimer As New Timer()

    ' Control de animación
    Private DrawerVisible As Boolean = False
    Private DrawerTargetX As Integer = 60
    Private DrawerSpeed As Integer = 20

    Public Sub New()
        Me.Text = "Ejemplo de Drawer UI con Slide"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.White

        DrawerTimer.Interval = 15
        InicializarLayout()
    End Sub

    Private Sub InicializarLayout()
        ' === Panel Encabezado ===
        PanelEncabezado.BackColor = Color.DarkSlateGray
        PanelEncabezado.Dock = DockStyle.Top
        PanelEncabezado.Height = 50
        Me.Controls.Add(PanelEncabezado)

        ' === Panel Menú ===
        PanelMenu.BackColor = Color.LightGray
        PanelMenu.Dock = DockStyle.Left
        PanelMenu.Width = 60
        Me.Controls.Add(PanelMenu)

        ' === Panel Contenido ===
        PanelContenido.BackColor = Color.WhiteSmoke
        PanelContenido.Dock = DockStyle.Fill
        Me.Controls.Add(PanelContenido)

        ' === Botón para activar el Drawer ===
        BotonDrawer.Text = "≡"
        BotonDrawer.Size = New Size(40, 40)
        BotonDrawer.Location = New Point(10, 5)
        PanelEncabezado.Controls.Add(BotonDrawer)
        AddHandler BotonDrawer.Click, AddressOf ToggleDrawer

        ' === Drawer Panel ===
        DrawerPanel.BackColor = Color.FromArgb(245, 245, 245)
        DrawerPanel.BorderStyle = BorderStyle.FixedSingle
        DrawerPanel.Size = New Size(200, Me.Height - PanelEncabezado.Height)
        DrawerPanel.Location = New Point(-DrawerPanel.Width, PanelEncabezado.Height)
        DrawerPanel.Visible = True ' Visible siempre, pero fuera de vista
        DrawerPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left

        ' Contenido de ejemplo
        Dim lblDrawer As New Label With {
            .Text = "Opciones del Drawer",
            .AutoSize = True,
            .Location = New Point(10, 10),
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
        }
        DrawerPanel.Controls.Add(lblDrawer)

        Me.Controls.Add(DrawerPanel)
        DrawerPanel.BringToFront()
    End Sub

    Private Sub ToggleDrawer(sender As Object, e As EventArgs)
        ' Determinar destino de animación
        DrawerVisible = Not DrawerVisible
        DrawerTargetX = If(DrawerVisible, 60, -DrawerPanel.Width)
        DrawerTimer.Start()
    End Sub

    Private Sub DrawerTimer_Tick(sender As Object, e As EventArgs) Handles DrawerTimer.Tick
        Dim posActual = DrawerPanel.Left
        Dim destino = DrawerTargetX

        If posActual < destino Then
            posActual += DrawerSpeed
            If posActual > destino Then posActual = destino
        ElseIf posActual > destino Then
            posActual -= DrawerSpeed
            If posActual < destino Then posActual = destino
        End If

        DrawerPanel.Left = posActual

        If posActual = destino Then
            DrawerTimer.Stop()
        End If
    End Sub


End Class
