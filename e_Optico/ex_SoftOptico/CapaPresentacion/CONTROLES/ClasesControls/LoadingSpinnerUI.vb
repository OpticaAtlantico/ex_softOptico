Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class LoadingSpinnerUI
    Inherits Control

    ' ✨ Propiedades orbitales
    <Category("Apariencia Orbital")> Public Property SpinnerColor As Color = Color.FromArgb(33, 150, 243)
    <Category("Apariencia Orbital")> Public Property LineWidth As Integer = 4
    <Category("Apariencia Orbital")> Public Property Segments As Integer = 12
    <Category("Apariencia Orbital")> Public Property Speed As Integer = 80
    <Category("Apariencia Orbital")> Public Property TextoCentral As String = ""
    <Category("Apariencia Orbital")>
    Public Property TextoColor As Color = Color.Black

    <Category("Apariencia Orbital")>
    Public Property TextoFont As Font = New Font("Century Gothic", 9, FontStyle.Bold)

    Private angle As Integer = 0
    Private WithEvents spinTimer As New Timer()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(50, 50)
        Me.BackColor = Color.Transparent

        spinTimer.Interval = Speed
        spinTimer.Start()
    End Sub

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        If Me.Parent IsNot Nothing Then
            Using b As New SolidBrush(Me.Parent.BackColor)
                e.Graphics.FillRectangle(b, Me.ClientRectangle)
            End Using
        Else
            MyBase.OnPaintBackground(e)
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim center As Point = New Point(Me.Width \ 2, Me.Height \ 2)
        Dim radius As Integer = Math.Min(Me.Width, Me.Height) \ 2 - LineWidth
        Dim alphaStep As Integer = 255 \ Segments

        For i As Integer = 0 To Segments - 1
            Dim currentAngle = (angle + i * 360 \ Segments) Mod 360
            Dim alpha = Math.Max(30, 255 - i * alphaStep)
            Dim penColor = Color.FromArgb(alpha, SpinnerColor)

            Using p As New Pen(penColor, LineWidth)
                Dim rad = currentAngle * Math.PI / 180
                Dim x1 = center.X + radius * Math.Cos(rad)
                Dim y1 = center.Y + radius * Math.Sin(rad)
                Dim x2 = center.X + (radius - 6) * Math.Cos(rad)
                Dim y2 = center.Y + (radius - 6) * Math.Sin(rad)
                g.DrawLine(p, CSng(x1), CSng(y1), CSng(x2), CSng(y2))
            End Using
        Next

        If Not String.IsNullOrWhiteSpace(TextoCentral) Then
            Dim txtSize = TextRenderer.MeasureText(TextoCentral, Me.Font)
            Dim x = (Me.Width - txtSize.Width) \ 2
            Dim y = (Me.Height - txtSize.Height) \ 2

            Using txtBrush As New SolidBrush(Me.ForeColor)
                TextRenderer.DrawText(g, TextoCentral, Me.Font, New Point(x, y), txtBrush.Color)
            End Using
        End If
    End Sub

    Private Sub spinTimer_Tick(sender As Object, e As EventArgs) Handles spinTimer.Tick
        angle = (angle + 30) Mod 360
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            spinTimer.Start()
        Else
            spinTimer.Stop()
        End If
    End Sub
End Class


'Imports System.ComponentModel
'Imports System.Drawing.Drawing2D

'Public Class LoadingSpinnerUI
'    Inherits Control

'    ' ✨ Propiedades configurables
'    <Category("Apariencia Orbital")>
'    Public Property SpinnerColor As Color = Color.FromArgb(33, 150, 243)

'    <Category("Apariencia Orbital")>
'    Public Property LineWidth As Integer = 4

'    <Category("Apariencia Orbital")>
'    Public Property Segments As Integer = 12

'    <Category("Apariencia Orbital")>
'    Public Property Speed As Integer = 80

'    Private angle As Integer = 0
'    Private WithEvents spinTimer As New Timer()

'    Public Sub New()
'        Me.DoubleBuffered = True
'        Me.Size = New Size(50, 50)
'        Me.BackColor = Color.White

'        spinTimer.Interval = Speed
'        spinTimer.Start()
'    End Sub

'    Protected Overrides Sub OnPaint(e As PaintEventArgs)
'        Dim g = e.Graphics
'        g.SmoothingMode = SmoothingMode.AntiAlias
'        g.Clear(Me.BackColor)

'        Dim center As Point = New Point(Me.Width \ 2, Me.Height \ 2)
'        Dim radius As Integer = Math.Min(Me.Width, Me.Height) \ 2 - LineWidth
'        Dim alphaStep As Integer = 255 \ Segments

'        For i As Integer = 0 To Segments - 1
'            Dim currentAngle = (angle + i * 360 \ Segments) Mod 360
'            Dim alpha = Math.Max(30, 255 - i * alphaStep)
'            Dim penColor = Color.FromArgb(alpha, SpinnerColor)

'            Using p As New Pen(penColor, LineWidth)
'                Dim rad = currentAngle * Math.PI / 180
'                Dim x1 = center.X + radius * Math.Cos(rad)
'                Dim y1 = center.Y + radius * Math.Sin(rad)
'                Dim x2 = center.X + (radius - 6) * Math.Cos(rad)
'                Dim y2 = center.Y + (radius - 6) * Math.Sin(rad)
'                g.DrawLine(p, CSng(x1), CSng(y1), CSng(x2), CSng(y2))
'            End Using
'        Next
'    End Sub

'    Private Sub spinTimer_Tick(sender As Object, e As EventArgs) Handles spinTimer.Tick
'        angle = (angle + 30) Mod 360
'        Me.Invalidate()
'    End Sub

'    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
'        MyBase.OnVisibleChanged(e)
'        If Me.Visible Then
'            spinTimer.Start()
'        Else
'            spinTimer.Stop()
'        End If
'    End Sub
'End Class