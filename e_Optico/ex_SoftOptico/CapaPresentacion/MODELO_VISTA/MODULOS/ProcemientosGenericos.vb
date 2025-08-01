Module ProcemientosGenericos
    'Evento para hacer que avance de control
    Public Sub AvanzarConEnter(e As KeyPressEventArgs, actualControl As Control, formulario As Form)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            formulario.SelectNextControl(actualControl, True, True, True, True)
        End If
    End Sub


End Module
