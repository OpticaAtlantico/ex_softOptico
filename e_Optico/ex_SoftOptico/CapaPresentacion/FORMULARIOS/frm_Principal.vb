Imports MaterialSkin
Imports MaterialSkin.Controls

Public Class frm_Principal
    Inherits MaterialForm
    Private drawerPanel As Panel
    Private WithEvents showTimer As Timer
    Private WithEvents hideTimer As Timer
    Private drawerVisible As Boolean = False

    Private Sub frm_Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' MaterialSkin setup
        Dim skinManager = MaterialSkinManager.Instance
        skinManager.AddFormToManage(Me)
        skinManager.Theme = MaterialSkinManager.Themes.LIGHT
        skinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)

        ' Drawer panel
        drawerPanel = New Panel()
        drawerPanel.Size = New Size(200, Me.Height)
        drawerPanel.Location = New Point(-200, 0) ' Oculto a la izquierda
        drawerPanel.BackColor = Color.White
        drawerPanel.Visible = True
        drawerPanel.BorderStyle = BorderStyle.FixedSingle
        'drawerPanel.Opacity = 0 ' Requiere extensión (ver más abajo)
        Me.Controls.Add(drawerPanel)

        ' Botón para alternar
        Dim toggleBtn As New MaterialButton()
        toggleBtn.Text = "☰"
        toggleBtn.Location = New Point(10, 10)
        AddHandler toggleBtn.Click, AddressOf ToggleDrawer
        Me.Controls.Add(toggleBtn)

        ' Temporizadores
        showTimer = New Timer() With {.Interval = 10}
        hideTimer = New Timer() With {.Interval = 10}

    End Sub

    Private Sub ToggleDrawer(sender As Object, e As EventArgs)
        If drawerVisible Then
            hideTimer.Start()
        Else
            drawerPanel.Location = New Point(-200, 0)
            drawerPanel.Visible = True
            'drawerPanel.Opacity = 0
            showTimer.Start()
        End If
    End Sub



    Private Sub ToggleDrawer_Click(sender As Object, e As EventArgs)
        drawerPanel.Visible = Not drawerPanel.Visible
    End Sub

End Class