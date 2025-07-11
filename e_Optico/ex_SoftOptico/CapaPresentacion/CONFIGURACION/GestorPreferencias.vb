Public Class GestorPreferencias

    Public Shared Sub GuardarTemaActual()
        Dim tema = ThemeManagerWUI.TemaActual.ToString()
        My.Settings.TemaWUI = tema
        My.Settings.Save()
    End Sub

    Public Shared Function RecuperarTema() As TemaVisual
        Dim temaGuardado = My.Settings.TemaWUI
        If String.IsNullOrWhiteSpace(temaGuardado) Then
            Return TemaVisual.Claro
        End If

        Return If(temaGuardado = "Oscuro", TemaVisual.Oscuro, TemaVisual.Claro)
    End Function

    Public Shared Sub AplicarTemaGuardado()
        Dim tema = RecuperarTema()
        ThemeManagerWUI.CambiarTema(tema)
    End Sub

    'AL INICIAR LA APLICACION   

    'GestorPreferencias.AplicarTemaGuardado()

End Class
