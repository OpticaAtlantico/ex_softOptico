Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class TabPanelUI
    Inherits Control

    <Category("Contenido Orbital")>
    Public Property Tabs As New List(Of TabItemOrbitalAdv)

    <Category("Estilo Orbital")>
    Public Property TabHeight As Integer = 44

    <Category("Estado Orbital")>
    Public Property ActiveContent As Control = Nothing

    Public Event TabChanged(index As Integer, title As String)
    Public Event TabClosed(index As Integer, title As String)

    Private currentIndex As Integer = 0
    Private tooltips As New ToolTip With {.ShowAlways = True}
    Private animTimer As New Timer With {.Interval = 10}
    Private animAlpha As Integer = 255
    Private fadingOut As Boolean = False

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.OptimizedDoubleBuffer Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint, True)
        Me.BackColor = Color.Transparent
        AddHandler animTimer.Tick, AddressOf FadeTick
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If Me.Parent IsNot Nothing Then
            Using b As New SolidBrush(Me.Parent.BackColor)
                e.Graphics.FillRectangle(b, Me.ClientRectangle)
            End Using
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim tabWidth = Me.Width \ Math.Max(1, Tabs.Count)

        For i = 0 To Tabs.Count - 1
            Dim tab = Tabs(i)
            Dim rect = New Rectangle(i * tabWidth, 0, tabWidth, TabHeight)
            Dim colorFondo = If(i = currentIndex, tab.ColorBootstrap(), Color.FromArgb(235, 235, 235))
            Dim colorTexto = If(i = currentIndex, Color.White, Color.Black)

            ' Fondo pestaña
            Using b As New SolidBrush(colorFondo)
                g.FillRectangle(b, rect)
            End Using

            ' Línea inferior activa tipo Bootstrap
            If i = currentIndex Then
                g.FillRectangle(New SolidBrush(colorTexto), rect.X, TabHeight - 3, tabWidth, 3)
            End If

            ' Ícono orbital FontAwesome
            If tab.Icono <> IconChar.None Then
                Dim iconChar = Char.ConvertFromUtf32(CInt(tab.Icono))
                Using fnt As New Font("FontAwesome", 14)
                    Dim iconRect = New Rectangle(rect.X + 6, rect.Y + 8, 18, 18)
                    TextRenderer.DrawText(g, iconChar, fnt, iconRect.Location, colorTexto)
                End Using
            End If

            ' Texto orbital
            Dim txtOffset = If(tab.Icono = IconChar.None, 8, 32)
            Dim textoPos = New Point(rect.X + txtOffset, rect.Y + 6)
            TextRenderer.DrawText(g, tab.Titulo, Me.Font, textoPos, colorTexto)

            ' Badge visual
            If Not String.IsNullOrWhiteSpace(tab.BadgeTexto) Then
                Dim badgeRect = New Rectangle(rect.Right - 24, rect.Top + 8, 16, 16)
                Using bBrush As New SolidBrush(Color.White)
                    g.FillEllipse(bBrush, badgeRect)
                    TextRenderer.DrawText(g, tab.BadgeTexto, New Font("Segoe UI", 7, FontStyle.Bold), badgeRect.Location, tab.ColorBootstrap())
                End Using
            End If

            ' Validación visual orbital
            Dim estadoRect = New Rectangle(rect.Right - 42, rect.Top + 10, 12, 12)
            DrawEstadoValidacion(g, tab.EstadoValidacion, estadoRect)

            ' Cierre orbital "X"
            Dim closeRect = New Rectangle(rect.Right - 14, rect.Top + 12, 10, 10)
            Using pen As New Pen(Color.FromArgb(180, colorTexto), 1.5F)
                g.DrawLine(pen, closeRect.Left, closeRect.Top, closeRect.Right, closeRect.Bottom)
                g.DrawLine(pen, closeRect.Left, closeRect.Bottom, closeRect.Right, closeRect.Top)
            End Using
        Next
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        Dim tabWidth = Me.Width \ Math.Max(1, Tabs.Count)
        Dim index = e.X \ tabWidth
        If index >= 0 AndAlso index < Tabs.Count Then
            Dim closeArea = New Rectangle((index + 1) * tabWidth - 14, 12, 10, 10)
            If closeArea.Contains(e.Location) Then
                RaiseEvent TabClosed(index, Tabs(index).Titulo)
                Tabs.RemoveAt(index)
                If currentIndex >= Tabs.Count Then currentIndex = Tabs.Count - 1
                Me.Invalidate()
                Return
            End If

            If index <> currentIndex Then
                fadingOut = True
                animAlpha = 255
                animTimer.Start()
                currentIndex = index
                RaiseEvent TabChanged(index, Tabs(index).Titulo)
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        Dim tabWidth = Me.Width \ Math.Max(1, Tabs.Count)
        Dim index = e.X \ tabWidth
        If index >= 0 AndAlso index < Tabs.Count Then
            Dim txt = Tabs(index).Tooltip
            If Not String.IsNullOrWhiteSpace(txt) Then
                tooltips.SetToolTip(Me, txt)
            End If
        End If
    End Sub

    Private Sub FadeTick(sender As Object, e As EventArgs)
        If fadingOut Then
            animAlpha -= 25
            If animAlpha <= 0 Then
                fadingOut = False
                animAlpha = 0
                animTimer.Stop()
                MostrarContenidoOrbital()
            End If
        End If
    End Sub

    Private Sub MostrarContenidoOrbital()
        If Tabs.Count > currentIndex Then
            ActiveContent = Tabs(currentIndex).Contenido
            If ActiveContent IsNot Nothing Then
                ActiveContent.Location = New Point(0, TabHeight)
                ActiveContent.Size = New Size(Me.Width, Me.Height - TabHeight)
                If Not Me.Controls.Contains(ActiveContent) Then Me.Controls.Add(ActiveContent)
                ActiveContent.BringToFront()
                ActiveContent.Visible = True
            End If
        End If
        Me.Invalidate()
    End Sub

    Public Sub AddTab(tab As TabItemOrbitalAdv)
        Tabs.Add(tab)
        Me.Invalidate()
    End Sub

    Private Sub DrawEstadoValidacion(g As Graphics, estado As TabItemOrbitalAdv.EstadoOrbital, rect As Rectangle)
        Dim iconChar As IconChar = IconChar.None
        Dim colorEstado As Color = Color.Gray

        Select Case estado
            Case TabItemOrbitalAdv.EstadoOrbital.Correcto : iconChar = IconChar.CheckCircle : colorEstado = Color.SeaGreen
            Case TabItemOrbitalAdv.EstadoOrbital.Pendiente : iconChar = IconChar.Clock : colorEstado = Color.DarkOrange
            Case TabItemOrbitalAdv.EstadoOrbital.Errores : iconChar = IconChar.TimesCircle : colorEstado = Color.Red
        End Select

        If iconChar <> IconChar.None Then
            Dim iconText = Char.ConvertFromUtf32(CInt(iconChar))
            Using fnt As New Font("FontAwesome", 10)
                TextRenderer.DrawText(g, iconText, fnt, rect.Location, colorEstado)
            End Using
        End If
    End Sub
End Class