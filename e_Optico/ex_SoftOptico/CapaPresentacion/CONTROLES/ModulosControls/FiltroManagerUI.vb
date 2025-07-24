Public Class FiltroManagerUI
    Public Shared Sub AplicarFiltro(texto As String, datosOriginal As DataTable, ByRef destinoGrid As DataGridView)
        If datosOriginal Is Nothing OrElse datosOriginal.Rows.Count = 0 Then Exit Sub

        Dim textoFiltrado = texto.Trim().ToLower()

        If String.IsNullOrEmpty(textoFiltrado) Then
            destinoGrid.DataSource = datosOriginal.Copy()
            Exit Sub
        End If

        ' 🔎 Filtra por todas las columnas dinámicamente
        Dim columnas = datosOriginal.Columns.Cast(Of DataColumn).Select(Function(col) col.ColumnName)

        Dim vista = datosOriginal.AsEnumerable().Where(Function(row)
                                                           Return columnas.Any(Function(columna)
                                                                                   row(columna).ToString().ToLower().Contains(textoFiltrado)
                                                                               End Function)
                                                       End Function)

        If vista.Any() Then
            destinoGrid.DataSource = vista.CopyToDataTable()
        Else
            destinoGrid.DataSource = Nothing
        End If
    End Sub
End Class
