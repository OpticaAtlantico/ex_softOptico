Module ProcemientosGenericos
    'Evento para hacer que avance de control
    Public Sub AvanzarConEnter(e As KeyPressEventArgs, actualControl As Control, formulario As Form)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            formulario.SelectNextControl(actualControl, True, True, True, True)
        End If
    End Sub
    Public Sub LimpiarControles(container As Control)
        For Each ctrl As Control In container.Controls
            ' Si el control implementa ILimpiable, lo limpiamos
            If TypeOf ctrl Is ILimpiable Then
                DirectCast(ctrl, ILimpiable).Limpiar()
            End If

            ' Si tiene hijos, entramos en ellos
            If ctrl.HasChildren Then
                LimpiarControles(ctrl)
            End If
        Next
    End Sub

End Module
