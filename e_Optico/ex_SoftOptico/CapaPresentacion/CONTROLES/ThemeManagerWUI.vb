Imports System.Drawing
Imports System.Windows.Forms

Public Enum TemaVisual
    Claro
    Oscuro
End Enum

Module ThemeManagerWUI
    Public Shared Property TemaActual As TemaVisual = TemaVisual.Claro
    Public Sub ApplyLightTheme(formulario As Form)
        formulario.BackColor = Color.White

        For Each ctrl In formulario.Controls
            If TypeOf ctrl Is TextBoxWUI Then
                With CType(ctrl, TextBoxWUI)
                    .BackgroundColorCustom = Color.White
                    .TextBoxRef.ForeColor = Color.Black
                    .BorderColor = Color.Gray
                    .FocusBorderColor = Color.DeepSkyBlue
                End With
            ElseIf TypeOf ctrl Is ComboBoxWUI Then
                With CType(ctrl, ComboBoxWUI)
                    .BackgroundColorCustom = Color.White
                    .TextColor = Color.Black
                    .BorderColor = Color.Gray
                    .FocusColor = Color.DeepSkyBlue
                End With
            ElseIf TypeOf ctrl Is OptionButtonWUI Then
                With CType(ctrl, OptionButtonWUI)
                    .TextColor = Color.Black
                    .CheckedColor = Color.DeepSkyBlue
                End With
            ElseIf TypeOf ctrl Is CommandButtonWUI Then
                With CType(ctrl, CommandButtonWUI)
                    .BaseColor = Color.SteelBlue
                    .TextColor = Color.White
                End With
            ElseIf TypeOf ctrl Is ButtonWUI Then
                With CType(ctrl, ButtonWUI)
                    .BaseColor = Color.SteelBlue
                    .TextColor = Color.White
                    .RippleColor = Color.FromArgb(120, Color.White)
                End With
            ElseIf TypeOf ctrl Is TextBoxIconWUI Then
                With CType(ctrl, TextBoxIconWUI)
                    .BackgroundColorCustom = Color.White
                    .TextBoxRef.ForeColor = Color.Black
                    .FocusColor = Color.DeepSkyBlue
                End With
            ElseIf TypeOf ctrl Is MaskedTextBoxFechaWUI Then
                With CType(ctrl, MaskedTextBoxFechaWUI)
                    .BackgroundColorCustom = Color.White
                    .MaskedRef.ForeColor = Color.Black
                    .FocusColor = Color.DeepSkyBlue
                End With
            End If
        Next
    End Sub

    Public Sub ApplyDarkTheme(formulario As Form)
        formulario.BackColor = Color.FromArgb(30, 30, 30)

        For Each ctrl In formulario.Controls
            If TypeOf ctrl Is TextBoxWUI Then
                With CType(ctrl, TextBoxWUI)
                    .BackgroundColorCustom = Color.FromArgb(45, 45, 45)
                    .TextBoxRef.ForeColor = Color.White
                    .BorderColor = Color.MediumPurple
                    .FocusBorderColor = Color.MediumPurple
                End With
            ElseIf TypeOf ctrl Is ComboBoxWUI Then
                With CType(ctrl, ComboBoxWUI)
                    .BackgroundColorCustom = Color.FromArgb(45, 45, 45)
                    .TextColor = Color.White
                    .BorderColor = Color.MediumPurple
                    .FocusColor = Color.MediumPurple
                End With
            ElseIf TypeOf ctrl Is OptionButtonWUI Then
                With CType(ctrl, OptionButtonWUI)
                    .TextColor = Color.White
                    .CheckedColor = Color.MediumPurple
                End With
            ElseIf TypeOf ctrl Is CommandButtonWUI Then
                With CType(ctrl, CommandButtonWUI)
                    .BaseColor = Color.MediumPurple
                    .TextColor = Color.White
                End With
            ElseIf TypeOf ctrl Is ButtonWUI Then
                With CType(ctrl, ButtonWUI)
                    .BaseColor = Color.MediumPurple
                    .TextColor = Color.White
                    .RippleColor = Color.FromArgb(120, Color.White)
                End With
            ElseIf TypeOf ctrl Is TextBoxIconWUI Then
                With CType(ctrl, TextBoxIconWUI)
                    .BackgroundColorCustom = Color.FromArgb(45, 45, 45)
                    .TextBoxRef.ForeColor = Color.White
                    .FocusColor = Color.MediumPurple
                End With
            ElseIf TypeOf ctrl Is MaskedTextBoxFechaWUI Then
                With CType(ctrl, MaskedTextBoxFechaWUI)
                    .BackgroundColorCustom = Color.FromArgb(45, 45, 45)
                    .MaskedRef.ForeColor = Color.White
                    .FocusColor = Color.MediumPurple
                End With
            End If
        Next
    End Sub

    'Como usarlo


    'AddHandler toggleTema.TemaCambiado, Sub(s, isDark)
    'If isDark Then
    '    ThemeManagerWilmerUI.ApplyDarkTheme(Me)
    'Else
    '    ThemeManagerWilmerUI.ApplyLightTheme(Me)
    'End If
    'End Sub

End Module
