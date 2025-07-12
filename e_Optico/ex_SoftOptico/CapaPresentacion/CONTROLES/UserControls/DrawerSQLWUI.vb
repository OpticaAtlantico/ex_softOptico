Imports System.Drawing
Imports System.Windows.Forms
Imports CapaPresentacion.ThemeManagerWUI

Public Class DrawerSQLWUI
    Inherits UserControl

    Private _drawerWidth As Integer = 220
    Private _isOpen As Boolean = False
    Private _animTimer As New Timer()
    Private _velocidad As Integer = 20
    Private _contenedorBotones As New FlowLayoutPanel()

    Public Event OpcionSeleccionada(texto As String)

    Public Sub New()
        Me.Size = New Size(_drawerWidth, 400)
        Me.BackColor = Color.FromArgb(45, 45, 60)
        Me.Visible = False

        _contenedorBotones.Dock = DockStyle.Fill
        _contenedorBotones.FlowDirection = FlowDirection.TopDown
        _contenedorBotones.WrapContents = False
        _contenedorBotones.AutoScroll = True
        Me.Controls.Add(_contenedorBotones)

        _animTimer.Interval = 1
        AddHandler _animTimer.Tick, AddressOf AnimarDrawer
    End Sub

    Public Sub CargarOpciones(textos As List(Of String), iconos As List(Of String))
        _contenedorBotones.Controls.Clear()
        For i = 0 To textos.Count - 1
            Dim btn As New ButtonWUI()
            Dim icono = If(i < iconos.Count, iconos(i), ChrW(&HF105))
            btn.BotonTexto = icono & " " & textos(i)
            btn.Size = New Size(_drawerWidth - 10, 40)
            btn.BaseColor = Color.Transparent
            btn.Font = New Font("Segoe UI", 9)
            btn.FlatStyle = FlatStyle.Flat
            AddHandler btn.BotonClick, Sub() RaiseEvent OpcionSeleccionada(textos(i))
            _contenedorBotones.Controls.Add(btn)
        Next

        ' 🔄 Aplicar estilo visual del tema
        AplicarTemaDesdeManager()
    End Sub

    Public Sub MostrarDesde(controlOrigen As Control)
        Me.Location = New Point(-_drawerWidth, controlOrigen.Top)
        Me.Visible = True
        _isOpen = True
        _animTimer.Tag = "abrir"
        _animTimer.Start()
    End Sub

    Public Sub MostrarDesdeArriba()
        Me.Location = New Point(-_drawerWidth, 0)
        Me.Visible = True
        _isOpen = True
        _animTimer.Tag = "abrir"
        _animTimer.Start()
    End Sub

    Public Sub OcultarDrawer()
        _isOpen = False
        _animTimer.Tag = "cerrar"
        _animTimer.Start()
    End Sub

    Private Sub AnimarDrawer(sender As Object, e As EventArgs)
        If _animTimer.Tag = "abrir" Then
            If Me.Left < 0 Then
                Me.Left += _velocidad
            Else
                Me.Left = 0
                _animTimer.Stop()
            End If
        Else
            If Me.Left > -_drawerWidth Then
                Me.Left -= _velocidad
            Else
                Me.Left = -_drawerWidth
                Me.Visible = False
                _animTimer.Stop()
            End If
        End If
    End Sub

    Public Sub AplicarTemaDesdeManager()
        Dim tema = ThemeManagerWUI.TemaActual

        If tema = "Oscuro" Then
            Me.BackColor = Color.FromArgb(40, 40, 50)
            For Each btn In _contenedorBotones.Controls.OfType(Of ButtonWUI)()
                btn.BaseColor = Color.Transparent
                btn.TextColor = Color.White
            Next
        Else
            Me.BackColor = Color.WhiteSmoke
            For Each btn In _contenedorBotones.Controls.OfType(Of ButtonWUI)()
                btn.BaseColor = Color.Transparent
                btn.TextColor = Color.Black
            Next
        End If

        Me.Invalidate()
    End Sub


    'COMO UTILIZARLO

    '    Dim drawerSQL As New DrawerWilmerUI()
    '    Me.Controls.Add(drawerSQL)

    '    Dim cadenaConexion = "Data Source=TU_SERVIDOR;Initial Catalog=TU_BD;Integrated Security=True"
    '    Dim (textos, iconos) = MenuDrawerSQL.CargarOpcionesDesdeSQL(cadenaConexion)

    'drawerSQL.CargarOpciones(textos, iconos)
    'drawerSQL.MostrarDesde(btnMisModulos)

    'AddHandler drawerSQL.OpcionSeleccionada, Sub(opcion)
    '    MessageBox.Show("Seleccionaste: " & opcion)
    '    drawerSQL.OcultarDrawer()
    'End Sub

End Class
