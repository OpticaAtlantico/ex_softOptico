Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class DrawerUI
    Inherits Form

    Public Property BackgroundColor As Color = Color.White
    Public Property ShadowColor As Color = Color.FromArgb(30, Color.Black)
    Public Property BorderRadius As Integer = 12
    Public Property DrawerWidth As Integer = 280

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.StartPosition = FormStartPosition.Manual
        Me.TopMost = True
        Me.Size = New Size(DrawerWidth, Screen.PrimaryScreen.WorkingArea.Height)
        Me.Opacity = 0
        Me.BackColor = BackgroundColor
        Me.DoubleBuffered = True
    End Sub

    Public Sub MostrarDesdeDerecha(parentForm As Form)
        Dim x = parentForm.Location.X + parentForm.Width - Me.Width
        Dim y = parentForm.Location.Y
        Me.Location = New Point(x, y)

        Me.Height = parentForm.Height
        Me.Show()
        FadeIn()
    End Sub

    Private Async Sub FadeIn()
        While Me.Opacity < 1
            Await Task.Delay(10)
            Me.Opacity += 0.05
        End While
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path = RoundedPath(rect, BorderRadius)

        Using sombraBrush As New SolidBrush(ShadowColor)
            e.Graphics.FillRectangle(sombraBrush, New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height))
        End Using

        Using fondoBrush As New SolidBrush(BackgroundColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using
    End Sub

    Private Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    ' 🎨 Tema orbital
    Public Sub AplicarEstiloDesdeTema()
        BackgroundColor = ThemeManagerUI.ColorFondoBase
        ShadowColor = ThemeManagerUI.ColorSombra
        Me.Invalidate()
    End Sub

    'Dim drawer As New DrawerUI()
    'drawer.MostrarDesdeDerecha(Me)

    'drawer.Controls.Add(miBotonOrbital)


End Class
