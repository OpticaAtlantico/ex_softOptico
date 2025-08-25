Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp



Public Class TabPanelUI
    Inherits Control

    Public Event TabChanged(index As Integer, titulo As String)

    Public Property Tabs As New List(Of TabItemOrbitalAdv)
    Public Property TabHeight As Integer = 44
    Private currentIndex As Integer = 0
    Public Property ActiveContent As Control = Nothing

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Font = New Font("Century Gothic", 10, FontStyle.Bold)
        Me.BackColor = Color.Transparent
    End Sub

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

    Public Sub AddTab(tab As TabItemOrbitalAdv)
        Tabs.Add(tab)
        If Tabs.Count = 1 Then MostrarContenido()
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        Dim tabWidth = Me.Width \ Math.Max(1, Tabs.Count)

        For i = 0 To Tabs.Count - 1
            Dim rect = New Rectangle(i * tabWidth, 0, tabWidth, TabHeight)
            DibujarPestañaConIcono(g, Tabs(i), rect, i = currentIndex)
        Next
    End Sub

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

    Private Sub MostrarContenido()
        If ActiveContent IsNot Nothing AndAlso Me.Controls.Contains(ActiveContent) Then
            Me.Controls.Remove(ActiveContent)
        End If

        ActiveContent = Tabs(currentIndex).Contenido
        If ActiveContent IsNot Nothing Then
            ActiveContent.Location = New Point(0, TabHeight)
            ActiveContent.Size = New Size(Me.Width, Me.Height - TabHeight)
            ActiveContent.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom
            Me.Controls.Add(ActiveContent)
            ActiveContent.BringToFront()
        End If
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

End Class
