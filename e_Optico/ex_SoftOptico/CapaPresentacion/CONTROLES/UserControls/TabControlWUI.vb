Imports System.Drawing
Imports System.Windows.Forms
Public Class TabControlWUI
    Inherits UserControl

    Private _tabButtons As New List(Of ButtonWUI)
    Private _tabPanels As New List(Of PanelWUI)
    Private _selectedIndex As Integer = 0

    Public Sub New()
        Me.Size = New Size(500, 300)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
    End Sub

    Public Sub AgregarTab(titulo As String, contenido As Control)
        Dim index = _tabButtons.Count

        ' Crear botón pestaña
        Dim btn As New ButtonWUI()
        btn.BotonTexto = titulo
        btn.Size = New Size(120, 35)
        btn.Location = New Point(10 + (index * 125), 10)
        btn.BaseColor = Color.LightGray
        btn.TextColor = Color.Black
        AddHandler btn.BotonClick, Sub() MostrarTab(index)
        Me.Controls.Add(btn)
        _tabButtons.Add(btn)

        ' Crear panel asociado
        Dim panel As New PanelWUI()
        panel.Size = New Size(Me.Width - 20, Me.Height - 60)
        panel.Location = New Point(10, 55)
        panel.Visible = index = 0
        panel.BackgroundColorCustom = Color.White
        panel.Controls.Add(contenido)
        Me.Controls.Add(panel)
        _tabPanels.Add(panel)
    End Sub

    Private Sub MostrarTab(index As Integer)
        For i = 0 To _tabPanels.Count - 1
            _tabPanels(i).Visible = (i = index)
            _tabButtons(i).BaseColor = If(i = index, Color.DeepSkyBlue, Color.LightGray)
            _tabButtons(i).TextColor = If(i = index, Color.White, Color.Black)
        Next
        _selectedIndex = index
    End Sub
End Class
