Imports System.Drawing
Imports System.Windows.Forms

Public Enum TemaVisual
    Claro
    Oscuro
End Enum

Public Class ThemeManagerWUI

    Public Shared Property TemaActual As TemaVisual = TemaVisual.Claro
    Public Shared Property ColorBorde As Color = Color.Silver
    Public Shared Property ColorPrimario As Color = Color.DeepSkyBlue


    Public Shared Event TemaCambiado()

    Public Shared Sub CambiarTema(nuevoTema As TemaVisual)
        TemaActual = nuevoTema
        RaiseEvent TemaCambiado()
    End Sub

    Public Shared ReadOnly Property ColorFondoBase As Color
        Get
            Return If(TemaActual = TemaVisual.Claro, Color.White, Color.FromArgb(30, 30, 30))
        End Get
    End Property

    Public Shared ReadOnly Property ColorTextoBase As Color
        Get
            Return If(TemaActual = TemaVisual.Claro, Color.Black, Color.White)
        End Get
    End Property

    Public Shared ReadOnly Property ColorAcento As Color
        Get
            Return If(TemaActual = TemaVisual.Claro, Color.DeepSkyBlue, Color.MediumPurple)
        End Get
    End Property

    Public Shared Sub AplicarEstiloAControl(ctrl As Control)
        If TypeOf ctrl Is TextBoxWUI Then
            With CType(ctrl, TextBoxWUI)
                .BackgroundColor = If(TemaActual = TemaVisual.Claro, Color.White, Color.FromArgb(45, 45, 45))
                .TextBox.ForeColor = ColorTextoBase
                .BorderColor = If(TemaActual = TemaVisual.Claro, Color.Gray, ColorAcento)
                .FocusBorderColor = ColorAcento
            End With
        ElseIf TypeOf ctrl Is ComboBoxWUI Then
            With CType(ctrl, ComboBoxWUI)
                .BackgroundColorCustom = If(TemaActual = TemaVisual.Claro, Color.White, Color.FromArgb(45, 45, 45))
                .TextColor = ColorTextoBase
                .BorderColor = ColorAcento
                .FocusColor = ColorAcento
            End With
        ElseIf TypeOf ctrl Is OptionButtonWUI Then
            With CType(ctrl, OptionButtonWUI)
                .TextColor = ColorTextoBase
                .CheckedColor = ColorAcento
            End With
        ElseIf TypeOf ctrl Is CommandButtonWUI Then
            With CType(ctrl, CommandButtonWUI)
                .BaseColor = ColorAcento
                .TextColor = Color.White
            End With
        ElseIf TypeOf ctrl Is ButtonWUI Then
            With CType(ctrl, ButtonWUI)
                .BaseColor = ColorAcento
                .TextColor = Color.White
                .RippleColor = Color.FromArgb(120, Color.White)
            End With
        ElseIf TypeOf ctrl Is TextBoxIconWUI Then
            With CType(ctrl, TextBoxIconWUI)
                .BackgroundColorCustom = If(TemaActual = TemaVisual.Claro, Color.White, Color.FromArgb(45, 45, 45))
                .TextBoxRef.ForeColor = ColorTextoBase
                .FocusColor = ColorAcento
            End With
        ElseIf TypeOf ctrl Is MaskedTextBoxFechaWUI Then
            With CType(ctrl, MaskedTextBoxFechaWUI)
                .BackgroundColorCustom = If(TemaActual = TemaVisual.Claro, Color.White, Color.FromArgb(45, 45, 45))
                .MaskedRef.ForeColor = ColorTextoBase
                .FocusColor = ColorAcento
            End With
        End If
    End Sub

    Public Shared Sub ActualizarControles(formulario As Control)
        formulario.BackColor = ColorFondoBase
        For Each ctrl In formulario.Controls
            AplicarEstiloAControl(ctrl)
            If ctrl.HasChildren Then ActualizarControles(ctrl) ' Recurse for nested containers
        Next
    End Sub

    'Como usarlo en el formulario principal


    'Private Sub FormLoadHandler() Handles Me.Load
    '    ThemeManagerWilmerUI.ActualizarControles(Me)

    '    AddHandler ThemeManagerWilmerUI.TemaCambiado, Sub()
    '                                                      ThemeManagerWilmerUI.ActualizarControles(Me)
    '                                                  End Sub
    'End Sub

End Class




