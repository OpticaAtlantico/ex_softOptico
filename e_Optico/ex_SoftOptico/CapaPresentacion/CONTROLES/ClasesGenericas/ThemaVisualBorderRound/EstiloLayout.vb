Imports System.Drawing.Drawing2D

Public Class EstiloLayout
    Public Enum EstadoVisual
        Normal
        Errors
        Validado
        Hover
        Focus
    End Enum

    Private ReadOnly _tema As ThemaVisualLayout
    Private ReadOnly _estadoFunc As Func(Of EstadoVisual)

    Public Sub New(tema As ThemaVisualLayout, estadoFunc As Func(Of EstadoVisual))
        _tema = tema
        _estadoFunc = estadoFunc
    End Sub

    Public Sub Aplicar(control As Control, obtenerRadio As Func(Of Integer), obtenerBordeSize As Func(Of Integer))
        AddHandler control.Paint,
            Sub(sender, e)
                Dim estado = If(_estadoFunc IsNot Nothing, _estadoFunc.Invoke(), EstadoVisual.Normal)
                Dim radius = obtenerRadio()
                Dim borderSize = obtenerBordeSize()
                Dibujar(DirectCast(sender, Control), e, estado, radius, borderSize)
            End Sub

        AddHandler control.Resize,
            Sub(sender, e)
                Dim ctrl = DirectCast(sender, Control)
                Dim radius = obtenerRadio()
                ctrl.Region = New Region(RoundedPath(ctrl.ClientRectangle, radius))
            End Sub
    End Sub

    Private Sub Dibujar(ctrl As Control, e As PaintEventArgs, estado As EstadoVisual, radius As Integer, borderSize As Integer)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = ctrl.ClientRectangle
        rect.Inflate(-1, -1)

        Using path As GraphicsPath = RoundedPath(rect, radius)
            Using brush As New SolidBrush(ctrl.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using

            Dim colorBorde As Color = _tema.ObtenerColorBorde(estado)
            Using pen As New Pen(colorBorde, borderSize)
                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub

    Public Shared Function RoundedPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function


End Class
