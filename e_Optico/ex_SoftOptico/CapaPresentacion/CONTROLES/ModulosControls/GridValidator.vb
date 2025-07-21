Module GridValidator

    Public Enum EstadoValidacionOrbital
        Valido
        Advertencia
        Errores
        Ninguno
    End Enum

    ''' <summary>
    ''' Aplica estilo orbital de validación sobre una fila
    ''' </summary>
    Public Sub AplicarEstadoFila(grid As DataGridView, rowIndex As Integer, estado As EstadoValidacionOrbital, Optional mensajeTooltip As String = "")
        If rowIndex < 0 OrElse rowIndex >= grid.Rows.Count Then Exit Sub
        Dim fila = grid.Rows(rowIndex)

        Select Case estado
            Case EstadoValidacionOrbital.Valido
                fila.DefaultCellStyle.BackColor = Color.FromArgb(220, 248, 198)
                fila.DefaultCellStyle.ForeColor = Color.FromArgb(22, 101, 27)
            Case EstadoValidacionOrbital.Advertencia
                fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 249, 196)
                fila.DefaultCellStyle.ForeColor = Color.FromArgb(130, 103, 15)
            Case EstadoValidacionOrbital.Errores
                fila.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210)
                fila.DefaultCellStyle.ForeColor = Color.DarkRed
            Case Else
                fila.DefaultCellStyle.BackColor = Color.White
                fila.DefaultCellStyle.ForeColor = Color.Black
        End Select

        If mensajeTooltip <> "" Then
            For Each celda As DataGridViewCell In fila.Cells
                celda.ToolTipText = mensajeTooltip
            Next
        End If
    End Sub

    'Como usarlo en el form 
    ' Fila 0 válida
    'WilmerGridValidator.AplicarEstadoFila(dgvOrbital, 0, EstadoValidacionOrbital.Valido, "Registro verificado correctamente")

    '' Fila 1 con advertencia
    'WilmerGridValidator.AplicarEstadoFila(dgvOrbital, 1, EstadoValidacionOrbital.Advertencia, "Falta correo electrónico")

    '' Fila 2 con error
    'WilmerGridValidator.AplicarEstadoFila(dgvOrbital, 2, EstadoValidacionOrbital.Error, "Nombre incompleto")
End Module
