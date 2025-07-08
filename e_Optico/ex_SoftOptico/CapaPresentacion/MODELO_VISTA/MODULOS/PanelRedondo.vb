Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports MaterialSkin3.Controls.MaterialExpansionPanel

Public Class PanelRedondo
    'Inherits Panel

    Private _radio As Integer = 20
    Private _bordeColor As Color = Color.Gray
    Private _bordeGrosor As Integer = 2
    Private _mostrarSombra As Boolean = True
    Private _colorSombra As Color = Color.FromArgb(50, Color.Black)

    Public Sub New()
        Me.DoubleBuffered = True
        Me.BackColor = Color.White
    End Sub

    <Category("Apariencia")>
    Public Property Radio As Integer
        Get
            Return _radio
        End Get
        Set(value As Integer)
            _radio = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Apariencia")>
    Public Property BordeColor As Color
        Get
            Return _bordeColor
        End Get
        Set(value As Color)
            _bordeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Apariencia")>
    Public Property BordeGrosor As Integer
        Get
            Return _bordeGrosor
        End Get
        Set(value As Integer)
            _bordeGrosor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Apariencia")>
    Public Property MostrarSombra As Boolean
        Get
            Return _mostrarSombra
        End Get
        Set(value As Boolean)
            _mostrarSombra = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Apariencia")>
    Public Property ColorSombra As Color
        Get
            Return _colorSombra
        End Get
        Set(value As Color)
            _colorSombra = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        Dim rect As Rectangle = Me.ClientRectangle
        Dim path As GraphicsPath = CrearRutaRedondeada(rect, _radio)

        ' Sombra
        If _mostrarSombra Then
            Using sombraPath As GraphicsPath = CrearRutaRedondeada(New Rectangle(rect.X + 3, rect.Y + 3, rect.Width - 1, rect.Height - 1), _radio)
                Using sombraBrush As New SolidBrush(_colorSombra)
                    e.Graphics.FillPath(sombraBrush, sombraPath)
                End Using
            End Using
        End If

        ' Fondo
        Using fondoBrush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(fondoBrush, path)
        End Using

        ' Borde
        If _bordeGrosor > 0 Then
            Using pen As New Pen(_bordeColor, _bordeGrosor)
                e.Graphics.DrawPath(pen, path)
            End Using
        End If

        Me.Region = New Region(path)
    End Sub

    Private Function CrearRutaRedondeada(rect As Rectangle, radio As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
        path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90)
        path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90)
        path.CloseFigure()
        Return path
    End Function

End Class

