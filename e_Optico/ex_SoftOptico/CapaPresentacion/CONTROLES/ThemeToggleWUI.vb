Imports System.Drawing
Imports System.Windows.Forms
Public Class ThemeToggleWUI
    Inherits UserControl

    Private _isDarkTheme As Boolean = False
    Private _lightColor As Color = Color.White
    Private _darkColor As Color = Color.FromArgb(30, 30, 30)
    Private _lightTextColor As Color = Color.Black
    Private _darkTextColor As Color = Color.White
    Private _fontAwesomeFont As New Font("Font Awesome 6 Free Solid", 10)

    Public Event TemaCambiado As EventHandler(Of Boolean)

    Public Sub New()
        Me.Size = New Size(140, 35)
        Me.BackColor = _lightColor
        Me.ForeColor = _lightTextColor
        Me.DoubleBuffered = True
    End Sub

    Public Property IsDarkTheme As Boolean
        Get
            Return _isDarkTheme
        End Get
        Set(value As Boolean)
            _isDarkTheme = value
            Me.BackColor = If(value, _darkColor, _lightColor)
            Me.ForeColor = If(value, _darkTextColor, _lightTextColor)
            Me.Invalidate()
            RaiseEvent TemaCambiado(Me, value)
        End Set
    End Property

    ' Cambiar al hacer clic
    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        IsDarkTheme = Not IsDarkTheme
    End Sub

    ' Render visual con ícono
    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(Me.BackColor)

        Dim icon = If(_isDarkTheme, ChrW(&HF186), ChrW(&HF185)) ' fa-moon / fa-sun
        Dim texto = If(_isDarkTheme, " Oscuro", " Claro")
        Dim textoCompleto = icon & texto

        TextRenderer.DrawText(g, textoCompleto, _fontAwesomeFont, Me.ClientRectangle, Me.ForeColor,
                                  TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub
End Class
