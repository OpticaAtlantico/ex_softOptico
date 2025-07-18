Imports System.Drawing

Public Enum TemaVisuales
    Claro
    Oscuro
End Enum

Public Module ThemeManagerUI
    Public TemaActual As TemaVisuales = TemaVisuales.Claro

    Public ColorFondoBase As Color = Color.White
    Public ColorTextoBase As Color = Color.Black
    Public ColorBorde As Color = Color.Silver
    Public ColorPrimario As Color = Color.DeepSkyBlue
    Public ColorSombra As Color = Color.FromArgb(30, Color.Black)

    Public Event TemaCambiado As EventHandler

    Public Sub CambiarTema(nuevoTema As TemaVisuales)
        TemaActual = nuevoTema

        Select Case nuevoTema
            Case TemaVisuales.Claro
                ColorFondoBase = Color.White
                ColorTextoBase = Color.Black
                ColorBorde = Color.Silver
                ColorPrimario = Color.DeepSkyBlue
                ColorSombra = Color.FromArgb(30, Color.Black)

            Case TemaVisuales.Oscuro
                ColorFondoBase = Color.FromArgb(32, 33, 36)
                ColorTextoBase = Color.WhiteSmoke
                ColorBorde = Color.Gray
                ColorPrimario = Color.DeepSkyBlue
                ColorSombra = Color.FromArgb(60, Color.Black)
        End Select

        RaiseEvent TemaCambiado(Nothing, EventArgs.Empty)
    End Sub

    ' Aplicar estilo orbital a todos los controles del formulario
    Public Sub ActualizarControles(container As Control)
        For Each ctrl As Control In container.Controls
            'If TypeOf ctrl Is TextBoxUI Then CType(ctrl, TextBoxUI).AplicarEstiloDesdeTema()
            If TypeOf ctrl Is ComboBoxUI Then CType(ctrl, ComboBoxUI).AplicarEstiloDesdeTema()
            If TypeOf ctrl Is LabelUI Then CType(ctrl, LabelUI).AplicarEstiloDesdeTema()
            If ctrl.HasChildren Then ActualizarControles(ctrl)
        Next
    End Sub
End Module
