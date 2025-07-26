Public Module GridManagerUI

    Public Sub OcultarColumnas(grid As DataGridView, Optional soloIndice As Integer = -1)
        For Each col In grid.Columns
            Dim ocultar As Boolean = False

            ' Si se quiere ocultar solo una columna específica
            If soloIndice >= 0 And col.Index = soloIndice Then
                ocultar = True

                ' Si se quiere ocultar todas las columnas sin nombre o de tipo imagen
            ElseIf soloIndice = -1 Then
                If String.IsNullOrWhiteSpace(col.Name) OrElse TypeOf col Is DataGridViewImageColumn Then
                    ocultar = True
                End If
            End If

            If ocultar Then col.Visible = False
        Next
    End Sub


    Public Sub AlinearIconos(grid As DataGridView, Optional paddingLeft As Integer = 6)
        For Each col In grid.Columns
            If TypeOf col Is DataGridViewImageColumn Then
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                col.DefaultCellStyle.Padding = New Padding(paddingLeft, 0, 0, 0)
                col.DefaultCellStyle.BackColor = Color.White
                col.DefaultCellStyle.SelectionBackColor = Color.White
            End If
        Next
    End Sub

    Public Sub AjusteAuto(grid As DataGridView)
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

End Module


'como utilizar
'GridUIManager.OcultarColumnas(grid, 0)
