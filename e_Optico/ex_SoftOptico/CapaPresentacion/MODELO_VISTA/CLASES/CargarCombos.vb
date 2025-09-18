Imports System.Windows.Controls

Public Class CargarCombos
    Public Property nombre As String
    Public Property valor As Integer

    Public Shared Sub Cargar(combo As ComboBoxUI, tipoEnum As Type)
        If combo Is Nothing OrElse tipoEnum Is Nothing Then Exit Sub

        Dim listaItems As New List(Of CargarCombos)

        For Each valor As Integer In [Enum].GetValues(tipoEnum)
            listaItems.Add(New CargarCombos With {
                .nombre = [Enum].GetName(tipoEnum, valor),
                .valor = valor
            })
        Next

        combo.DisplayMember = "nombre"
        combo.ValueMember = "valor"
        combo.DataSource = listaItems
    End Sub

    Public Function GetSeleccionCombo(combo As ComboBox) As CargarCombos
        Return TryCast(combo.SelectedItem, CargarCombos)
    End Function


    Private Function GetEnumNames(tipoEnum As Type) As String()
        If tipoEnum Is Nothing Then Return New String() {}
        Return [Enum].GetNames(tipoEnum)
    End Function

    Private Function GetEnumValues(tipoEnum As Type) As Integer()
        If tipoEnum Is Nothing Then Return New Integer() {}
        Return [Enum].GetValues(tipoEnum).Cast(Of Integer)().ToArray()
    End Function

    Public Shared Sub CargarComboDesacoplado(controlUI As ComboBoxLayoutUI, tipoEnum As Type)
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
