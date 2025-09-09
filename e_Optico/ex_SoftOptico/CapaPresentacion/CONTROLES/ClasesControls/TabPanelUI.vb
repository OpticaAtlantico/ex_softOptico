Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Class TabPanelUI
    Inherits Control

    Public Event TabChanged(index As Integer, titulo As String)
    Private ReadOnly PanelContenido As Panel

    Public Property Tabs As New List(Of TabItemOrbitalAdv)
    Public Property TabHeight As Integer = 44
    Private currentIndex As Integer = 0
    Public Property ActiveContent As Control = Nothing


#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                ControlStyles.UserPaint Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Font = New Font(AppFonts.Century, AppFonts.SizeSmall, AppFonts.Bold)
        Me.BackColor = Color.Transparent

        ' 🌌 Panel orbital para contenido desacoplado
        PanelContenido = New Panel With {
            .Dock = DockStyle.None,
            .Location = New Point(0, TabHeight),
            .Size = New Size(Me.Width, Me.Height - TabHeight),
            .Margin = New Padding(0),
            .Padding = New Padding(0),
            .BackColor = Color.Transparent,
            .AutoScroll = True
        }
        Me.Controls.Add(PanelContenido)
        PanelContenido.BringToFront()

    End Sub
#End Region

#Region "DIBUJO"
    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' Simula transparencia orbital heredando el fondo del contenedor padre
        If Me.Parent IsNot Nothing Then
            Using b As New SolidBrush(Me.Parent.BackColor)
                e.Graphics.FillRectangle(b, Me.ClientRectangle)
            End Using
        Else
            MyBase.OnPaintBackground(e) ' Solo si no hay Parent
        End If
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        If PanelContenido IsNot Nothing Then
            PanelContenido.Location = New Point(0, TabHeight)
            PanelContenido.Size = New Size(Me.Width, Me.Height - TabHeight)
        End If

    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        Dim tabWidth = Me.Width \ Math.Max(1, Tabs.Count)

        For i = 0 To Tabs.Count - 1
            Dim rect = New Rectangle(i * tabWidth, 0, tabWidth, TabHeight)
            DibujarPestañaConIcono(g, Tabs(i), rect, i = currentIndex)
        Next
    End Sub

    Private Sub DibujarPestañaConIcono(g As Graphics, tab As TabItemOrbitalAdv, rect As Rectangle, isSelected As Boolean)
        Dim colorFondo = If(isSelected, tab.ColorBootstrap(), Color.LightGray)
        Dim colorTexto = If(isSelected, Color.White, Color.Black)

        Using b As New SolidBrush(colorFondo)
            g.FillRectangle(b, rect)
        End Using

        ' 🧿 Ícono
        Dim iconSize = 20
        Dim iconMargin = 12
        Dim iconX = rect.X + iconMargin
        Dim iconY = rect.Y + (rect.Height - iconSize) \ 2
        Dim textoX = iconX

        If tab.Icono <> IconChar.None Then
            Dim iconChar = Char.ConvertFromUtf32(CInt(tab.Icono))
            Using fnt As New Font("Font Awesome 6 Free Solid", 14)
                TextRenderer.DrawText(g, iconChar, fnt, New Point(iconX, iconY), colorTexto)
            End Using
            textoX += iconSize + 10
        End If

        ' 📝 Texto
        Dim textoY = rect.Y + (rect.Height - Me.Font.Height) \ 2
        TextRenderer.DrawText(g, tab.Titulo, Me.Font, New Point(textoX, textoY), colorTexto)

        ' 🌈 Línea inferior activa tipo Bootstrap
        If isSelected Then
            g.FillRectangle(New SolidBrush(colorTexto), rect.X, rect.Bottom - 3, rect.Width, 3)
        End If
    End Sub

#End Region

#Region "EVENTOS INTERNOS"
    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        Dim tabWidth = Me.Width \ Math.Max(1, Tabs.Count)
        Dim index = e.X \ tabWidth
        If index >= 0 AndAlso index < Tabs.Count Then
            currentIndex = index
            MostrarContenido()
            Me.Invalidate()
        End If

        RaiseEvent TabChanged(index, Tabs(index).Titulo)

    End Sub
#End Region

#Region "PROCEDIMIENTOS"
    Public Sub AddTab(tab As TabItemOrbitalAdv)
        Tabs.Add(tab)
        If Tabs.Count = 1 Then
            SeleccionarPestana(0)
        End If
        Me.Invalidate()
    End Sub

    Public Sub SeleccionarPestana(index As Integer)
        If index >= 0 AndAlso index < Tabs.Count Then
            currentIndex = index
            MostrarContenido()
            Me.Invalidate()
            RaiseEvent TabChanged(index, Tabs(index).Titulo)
        End If
    End Sub

    Private Sub MostrarContenido()

        ' 🧼 Limpieza previa
        PanelContenido.SuspendLayout()

        PanelContenido.Controls.Clear()
        ActiveContent = Tabs(currentIndex).Contenido

        If ActiveContent IsNot Nothing Then
            ActiveContent.Size = PanelContenido.ClientSize
            ActiveContent.Dock = DockStyle.None
            ActiveContent.Location = New Point(0, 0)
            ActiveContent.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            ActiveContent.Margin = New Padding(0)
            ActiveContent.Padding = New Padding(0)
            PanelContenido.Controls.Add(ActiveContent)
            ActiveContent.BringToFront()
        End If

        PanelContenido.ResumeLayout()

    End Sub

    Public Sub AvanzarPestaña()
        If currentIndex < Tabs.Count - 1 Then
            currentIndex += 1
            MostrarContenido()
            Me.Invalidate()
        End If
    End Sub

    Public Sub RetrocederPestaña()
        If currentIndex > 0 Then
            currentIndex -= 1
            MostrarContenido()
            Me.Invalidate()
        End If
    End Sub
#End Region

End Class
