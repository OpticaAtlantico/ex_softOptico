Imports FontAwesome.Sharp
Imports System.Drawing
Imports System.Runtime.CompilerServices

Public Module IconCharExtensions

    ''' <summary>
    ''' Renderiza un ícono FontAwesome como Bitmap con color y tamaño definidos.
    ''' </summary>
    ''' <param name="icon">IconChar a renderizar</param>
    ''' <param name="color">Color del ícono</param>
    ''' <param name="size">Tamaño en píxeles (alto/ancho)</param>
    ''' <returns>Bitmap con el ícono renderizado</returns>
    <Extension>
    Public Function ToBitmapPaint(icon As IconChar, color As Color, Optional size As Integer = 20) As Bitmap
        Dim iconPbx = New IconPictureBox() With {
            .IconChar = icon,
            .IconColor = color,
            .IconSize = size,
            .Size = New Size(size, size),
            .BackColor = Color.Transparent
        }

        Dim bmp = New Bitmap(size, size)
        iconPbx.DrawToBitmap(bmp, New Rectangle(Point.Empty, bmp.Size))
        Return bmp
    End Function

End Module
