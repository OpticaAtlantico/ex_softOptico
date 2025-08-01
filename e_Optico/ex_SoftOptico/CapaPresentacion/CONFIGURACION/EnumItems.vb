﻿Imports System.Windows.Controls

Public Enum EstadoCivil
    Soltero = 1
    Casado = 2
    Viudo = 3
    Divorciado = 4
End Enum

Public Enum Nacionalidad
    Venezolano = 1
    Extranjero = 2
End Enum

Public Enum Sexo
    Masculino = 1
    Femenino = 2
End Enum

Public Enum Zona
    Puerto_Ordaz = 1
    San_Felix = 2
End Enum

Public Enum Estado
    Activo = 1
    Inactivo = 2
End Enum

Public Class EnumItems
    Public Property nombre As String
    Public Property valor As Integer

    Public Shared Sub Cargar(combo As ComboBoxUI, tipoEnum As Type)
        If combo Is Nothing OrElse tipoEnum Is Nothing Then Exit Sub

        Dim listaItems As New List(Of EnumItems)

        For Each valor As Integer In [Enum].GetValues(tipoEnum)
            listaItems.Add(New EnumItems With {
                .nombre = [Enum].GetName(tipoEnum, valor),
                .valor = valor
            })
        Next

        combo.DisplayMember = "nombre"
        combo.ValueMember = "valor"
        combo.DataSource = listaItems
    End Sub

    Public Function GetSeleccionCombo(combo As ComboBox) As EnumItems
        Return TryCast(combo.SelectedItem, EnumItems)
    End Function


    Private Function GetEnumNames(tipoEnum As Type) As String()
        If tipoEnum Is Nothing Then Return New String() {}
        Return [Enum].GetNames(tipoEnum)
    End Function

    Private Function GetEnumValues(tipoEnum As Type) As Integer()
        If tipoEnum Is Nothing Then Return New Integer() {}
        Return [Enum].GetValues(tipoEnum).Cast(Of Integer)().ToArray()
    End Function

    Public Shared Sub CargarComboDesacoplado(controlUI As ComboBoxLabelUI, tipoEnum As Type)
        If controlUI Is Nothing OrElse tipoEnum Is Nothing Then Exit Sub
        Dim nombres As String() = [Enum].GetNames(tipoEnum)
        controlUI.AddItems(Nothing, nombres)
    End Sub


    'Public Shared Sub GuardarTemaActual()
    '    Dim tema = ThemeManagerWUI.TemaActual.ToString()
    '    My.Settings.TemaWUI = tema
    '    My.Settings.Save()
    'End Sub

    'Public Shared Function RecuperarTema() As TemaVisual
    '    Dim temaGuardado = My.Settings.TemaWUI
    '    If String.IsNullOrWhiteSpace(temaGuardado) Then
    '        Return TemaVisual.Claro
    '    End If

    '    Return If(temaGuardado = "Oscuro", TemaVisual.Oscuro, TemaVisual.Claro)
    'End Function

    'Public Shared Sub AplicarTemaGuardado()
    '    Dim tema = RecuperarTema()
    '    ThemeManagerWUI.CambiarTema(tema)
    'End Sub

    'AL INICIAR LA APLICACION   

    'GestorPreferencias.AplicarTemaGuardado()

End Class
