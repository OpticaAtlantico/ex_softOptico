Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class CommandButtonUI
    Inherits Control

    ' ⭐ Propiedades orbitales
    <Category("Apariencia Orbital")>
    Public Property Texto As String = "Aceptar"

    <Category("Apariencia Orbital")>
    Public Property Icono As IconChar = IconChar.Check

    <Category("Apariencia Orbital")>
    Public Property ColorBase As Color = Color.FromArgb(33, 150, 243)

    <Category("Apariencia Orbital")>
    Public Property ColorHover As Color = Color.FromArgb(30, 136, 229)

    <Category("Apariencia Orbital")>
    Public Property ColorDown As Color = Color.Silver

    <Category("Apariencia Orbital")>
    Public Property ColorTexto As Color = Color.White

    <Category("Apariencia Orbital")>
    Public Property AnimarHover As Boolean = True

    <Category("Apariencia Orbital")>
    Public Property RadioBorde As Integer = 8

    Private hovering As Boolean = False
    Private presionado As Boolean = False
    Private clickTimer As New Timer With {.Interval = 100}
    Private iconControl As New IconPictureBox()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(160, 45)
        Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.Cursor = Cursors.Hand

        iconControl.IconChar = Icono
        iconControl.IconColor = ColorTexto
        iconControl.BackColor = Color.Transparent
        iconControl.Size = New Size(24, 24)
        iconControl.SizeMode = PictureBoxSizeMode.CenterImage
        Me.Controls.Add(iconControl)

        AddHandler clickTimer.Tick, Sub()
                                        presionado = False
                                        clickTimer.Stop()
                                        Me.Invalidate()
                                    End Sub
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.PixelOffsetMode = PixelOffsetMode.HighQuality

        ' 🟦 Fondo con borde orbital
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Using path = BordeRedondeado(rect, RadioBorde)
            Dim baseColor = If(hovering AndAlso AnimarHover, ColorHover, ColorBase)
            If presionado Then baseColor = OscurecerColor(baseColor, 0.25F)
            Using brush = New SolidBrush(ColorBase)
                g.FillPath(brush, path)
            End Using
        End Using

        ' 🎨 Texto alineado a la izquierda
        Dim txtSize = g.MeasureString(Texto, Me.Font)
        Dim txtX = 10
        Dim txtY = (Me.Height - txtSize.Height) / 2
        Using txtBrush = New SolidBrush(ColorTexto)
            g.DrawString(Texto, Me.Font, txtBrush, txtX, txtY)
        End Using

        ' 🎯 Ícono alineado a la derecha
        iconControl.IconChar = Icono
        iconControl.IconColor = ColorTexto
        iconControl.Location = New Point(Me.Width - iconControl.Width - 10, (Me.Height - iconControl.Height) \ 2)
    End Sub

    Private Function BordeRedondeado(rect As Rectangle, radio As Integer) As GraphicsPath
        Dim path = New GraphicsPath()
        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
        path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90)
        path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Function OscurecerColor(colorOriginal As Color, factorOscurecer As Single) As Color
        Dim r = CInt(colorOriginal.R * (1.0F - factorOscurecer))
        Dim g = CInt(colorOriginal.G * (1.0F - factorOscurecer))
        Dim b = CInt(colorOriginal.B * (1.0F - factorOscurecer))
        Return Color.FromArgb(colorOriginal.A, r, g, b)
    End Function

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        hovering = True
        Me.Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        hovering = False
        Me.Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        presionado = True
        clickTimer.Start()
        Me.Invalidate()
        MyBase.OnClick(e)
    End Sub
End Class

'Imports System.ComponentModel
'Imports System.Drawing.Drawing2D
'Imports FontAwesome.Sharp

'Public Class CommandButtonUI
'    Inherits Control

'    ' 🔧 Propiedades para el diseñador
'    <Category("Apariencia Orbital")>
'    Public Property Texto As String = "Aceptar"

'    <Category("Apariencia Orbital")>
'    Public Property Icono As IconChar = IconChar.Check

'    <Category("Apariencia Orbital")>
'    Public Property ColorBase As Color = Color.FromArgb(33, 150, 243)

'    <Category("Apariencia Orbital")>
'    Public Property ColorHover As Color = Color.FromArgb(30, 136, 229)

'    <Category("Apariencia Orbital")>
'    Public Property ColorTexto As Color = Color.White

'    <Category("Apariencia Orbital")>
'    Public Property AnimarHover As Boolean = True

'    <Category("Apariencia Orbital")>
'    Public Property RadioBorde As Integer = 8

'    <Category("Apariencia Orbital")>
'    Public Property ColorPresionado As Color = Color.FromArgb(25, 118, 210)

'    Private hovering As Boolean = False
'    Private iconControl As New IconPictureBox()

'    Private presionado As Boolean = False
'    Private clickTimer As New Timer With {.Interval = 100}

'    Public Sub New()
'        Me.DoubleBuffered = True
'        Me.Size = New Size(160, 45)
'        Me.Font = New Font("Segoe UI", 10, FontStyle.Bold)
'        Me.Cursor = Cursors.Hand

'        iconControl.IconChar = Icono
'        iconControl.IconColor = ColorTexto
'        iconControl.BackColor = Color.Transparent
'        iconControl.Size = New Size(24, 24)
'        iconControl.SizeMode = PictureBoxSizeMode.CenterImage
'        Me.Controls.Add(iconControl)

'        AddHandler clickTimer.Tick, Sub()
'                                        presionado = False
'                                        clickTimer.Stop()
'                                        Me.Invalidate()
'                                    End Sub

'    End Sub

'    Protected Overrides Sub OnPaint(e As PaintEventArgs)
'        Dim g = e.Graphics
'        g.SmoothingMode = SmoothingMode.AntiAlias
'        g.PixelOffsetMode = PixelOffsetMode.HighQuality

'        ' 🌒 Sombra orbital
'        'DibujarSombra(g)

'        ' 🟦 Fondo orbital
'        'Dim rect = New Rectangle(0, 0, Me.Width, Me.Height)
'        'Using path = BordeRedondeado(rect, RadioBorde)
'        '    Dim brushColor = If(presionado, ColorPresionado, If(hovering AndAlso AnimarHover, ColorHover, ColorBase))
'        '    Using brush = New SolidBrush(brushColor)
'        '        g.FillPath(brush, path)
'        '    End Using
'        'End Using

'        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
'        Using path = BordeRedondeado(rect, RadioBorde)
'            Dim baseColor = If(hovering AndAlso AnimarHover, ColorHover, ColorBase)
'            If presionado Then baseColor = OscurecerColor(baseColor, 0.25F)
'            Using brush = New SolidBrush(ColorBase)
'                g.FillPath(brush, path)
'            End Using
'        End Using

'        ' 🎨 Texto alineado a la izquierda
'        Dim txtSize = g.MeasureString(Texto, Me.Font)
'        Dim txtX = 10
'        Dim txtY = (Me.Height - txtSize.Height) / 2
'        Using txtBrush = New SolidBrush(ColorTexto)
'            g.DrawString(Texto, Me.Font, txtBrush, txtX, txtY)
'        End Using

'        ' 🎯 Posicionar ícono alineado a la derecha
'        iconControl.IconChar = Icono
'        iconControl.IconColor = ColorTexto
'        iconControl.BackColor = Color.Transparent
'        iconControl.Location = New Point(Me.Width - iconControl.Width - 10, (Me.Height - iconControl.Height) \ 2)
'        Me.BringToFront()
'    End Sub

'    Private Function OscurecerColor(colorOriginal As Color, factorOscurecer As Single) As Color
'        Dim r = CInt(colorOriginal.R * (1.0F - factorOscurecer))
'        Dim g = CInt(colorOriginal.G * (1.0F - factorOscurecer))
'        Dim b = CInt(colorOriginal.B * (1.0F - factorOscurecer))
'        Return Color.FromArgb(colorOriginal.A, r, g, b)
'    End Function

'    Private Sub DibujarSombra(g As Graphics)
'        Dim sombraColor As Color = Color.FromArgb(60, 0, 0, 0)
'        Dim offset = 4
'        Dim rect = New Rectangle(offset, offset, Me.Width - 2, Me.Height - 2)
'        Using path = BordeRedondeado(rect, RadioBorde)
'            Using shadowBrush = New SolidBrush(sombraColor)
'                g.FillPath(shadowBrush, path)
'            End Using
'        End Using
'    End Sub

'    Private Function BordeRedondeado(rect As Rectangle, radio As Integer) As GraphicsPath
'        Dim path = New GraphicsPath()
'        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
'        path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90)
'        path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90)
'        path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function

'    Protected Overrides Sub OnMouseEnter(e As EventArgs)
'        hovering = True
'        Me.Invalidate()
'        MyBase.OnMouseEnter(e)
'    End Sub

'    Protected Overrides Sub OnMouseLeave(e As EventArgs)
'        hovering = False
'        Me.Invalidate()
'        MyBase.OnMouseLeave(e)
'    End Sub
'    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
'        If e.Button = MouseButtons.Left Then
'            presionado = True
'            clickTimer.Start()
'            Me.Invalidate()
'        End If
'        MyBase.OnMouseDown(e)
'    End Sub
'    Protected Overrides Sub OnClick(e As EventArgs)
'        presionado = True
'        clickTimer.Start()
'        Me.Invalidate()
'        MyBase.OnClick(e)
'    End Sub

'End Class