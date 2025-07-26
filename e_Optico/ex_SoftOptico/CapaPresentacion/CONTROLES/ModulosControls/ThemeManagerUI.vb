Imports System.Drawing

' Define los temas disponibles
Public Enum AppTheme
    Light
    Dark
End Enum

' Provee colores según el tema activo
Public Class ThemeManagerUI
    Public Shared Property CurrentTheme As AppTheme = AppTheme.Dark

    Public Shared ReadOnly Property BackColor As Color
        Get
            Return If(CurrentTheme = AppTheme.Dark, Color.FromArgb(30, 30, 30), Color.FromArgb(245, 245, 245))
        End Get
    End Property

    Public Shared ReadOnly Property ForeColor As Color
        Get
            Return If(CurrentTheme = AppTheme.Dark, Color.White, Color.Black)
        End Get
    End Property

    Public Shared ReadOnly Property AccentColor As Color
        Get
            Return Color.FromArgb(0, 120, 215)
        End Get
    End Property
End Class




'Imports System.Drawing

'Public Enum TemaVisuales
'    Claro
'    Oscuro
'End Enum

'Public Module ThemeManagerUI
'    Public TemaActual As TemaVisuales = TemaVisuales.Claro

'    Public ColorFondoBase As Color = Color.White
'    Public ColorTextoBase As Color = Color.Black
'    Public ColorBorde As Color = Color.Silver
'    Public ColorPrimario As Color = Color.DeepSkyBlue
'    Public ColorSombra As Color = Color.FromArgb(30, Color.Black)

'    Public Event TemaCambiado As EventHandler

'    Public Sub CambiarTema(nuevoTema As TemaVisuales)
'        TemaActual = nuevoTema

'        Select Case nuevoTema
'            Case TemaVisuales.Claro
'                ColorFondoBase = Color.White
'                ColorTextoBase = Color.Black
'                ColorBorde = Color.Silver
'                ColorPrimario = Color.DeepSkyBlue
'                ColorSombra = Color.FromArgb(30, Color.Black)

'            Case TemaVisuales.Oscuro
'                ColorFondoBase = Color.FromArgb(32, 33, 36)
'                ColorTextoBase = Color.WhiteSmoke
'                ColorBorde = Color.Gray
'                ColorPrimario = Color.DeepSkyBlue
'                ColorSombra = Color.FromArgb(60, Color.Black)
'        End Select

'        RaiseEvent TemaCambiado(Nothing, EventArgs.Empty)
'    End Sub

'    ' Aplicar estilo orbital a todos los controles del formulario
'    Public Sub ActualizarControles(container As Control)
'        For Each ctrl As Control In container.Controls
'            'If TypeOf ctrl Is TextBoxUI Then CType(ctrl, TextBoxUI).AplicarEstiloDesdeTema()
'            If TypeOf ctrl Is ComboBoxUI Then CType(ctrl, ComboBoxUI).AplicarEstiloDesdeTema()
'            If TypeOf ctrl Is LabelUI Then CType(ctrl, LabelUI).AplicarEstiloDesdeTema()
'            If ctrl.HasChildren Then ActualizarControles(ctrl)
'        Next
'    End Sub
'End Module
