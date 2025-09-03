Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports FontAwesome.Sharp

Public Class HeaderUI
    Inherits Control

    Private iconControl As New IconPictureBox()

#Region "PROPIEDADES"
    <Category("Contenido UI")>
    Public Property Titulo As String = "Título Principal"

    <Category("Contenido UI")>
    Public Property Subtitulo As String = "Subtítulo opcional"

    <Category("Contenido UI")>
    Public Property Icono As IconChar = IconChar.InfoCircle

    <Category("Estilo UI")>
    Public Property ColorFondo As Color = AppColors._cHeaderBackcolor

    <Category("Estilo UI")>
    Public Property ColorTexto As Color = AppColors._cHeaderTexto

    <Category("Estilo UI")>
    Public Property MostrarSeparador As Boolean = True
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(300, 60)
        Me.Font = New Font(AppFonts.Century, AppFonts.SizeSmall, AppFonts.Bold)

        iconControl.IconChar = Icono
        iconControl.IconColor = ColorTexto
        iconControl.BackColor = Color.Transparent
        iconControl.SizeMode = PictureBoxSizeMode.CenterImage
        iconControl.Size = New Size(40, 40)
        iconControl.Enabled = False
        Me.Controls.Add(iconControl)
    End Sub
#End Region

#Region "DIBUJO"
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.Clear(ColorFondo)

        ' 🟪 Título
        Dim tituloFont = New Font(AppFonts.Century, AppFonts.SizeMedium, AppFonts.Bold)
        Using brush As New SolidBrush(ColorTexto)
            g.DrawString(Titulo, tituloFont, brush, 45, 8)
        End Using

        ' 🔹 Subtítulo
        Dim subtituloFont = New Font(AppFonts.Century, AppFonts.SizeMini, AppFonts.Regular)
        Using brush As New SolidBrush(ColorTexto)
            g.DrawString(Subtitulo, subtituloFont, brush, 45, 28)
        End Using

        ' ⚡ Separador
        If MostrarSeparador Then
            Using p As New Pen(ColorTexto, 1)
                g.DrawLine(p, 0, Me.Height - 2, Me.Width, Me.Height - 2)
            End Using
        End If

        ' 🎯 Posición del ícono
        iconControl.IconChar = Icono
        iconControl.IconColor = ColorTexto
        iconControl.Location = New Point(5, (Me.Height - iconControl.Height) \ 2)
    End Sub
#End Region

End Class