Imports System.Data
Imports System.DirectoryServices.ActiveDirectory
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class ExportManagerUI

    Public Shared Sub ExportarDesdeGrid(grid As DataGridView, nombreArchivo As String)
        If grid Is Nothing OrElse grid.Rows.Count = 0 Then Exit Sub

        Using sfd As New SaveFileDialog() With {
                .Filter = "Archivo CSV (*.csv)|*.csv",
                .FileName = $"Export_{nombreArchivo}_{Now:yyyyMMdd_HHmm}.csv"
            }
            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(sfd.FileName, False, Encoding.UTF8)
                    Dim headers = String.Join(",", grid.Columns.Cast(Of DataGridViewColumn).Select(Function(c) EscaparCSV(c.HeaderText)))
                    sw.WriteLine(headers)

                    For Each row As DataGridViewRow In grid.Rows
                        If Not row.IsNewRow Then
                            Dim valores = String.Join(",", row.Cells.Cast(Of DataGridViewCell).Select(Function(cell) EscaparCSV(cell.Value?.ToString())))
                            sw.WriteLine(valores)
                        End If
                    Next
                End Using
                MostrarToasts(grid.FindForm(), $"Página actual exportada correctamente.")
            End If
        End Using
    End Sub

    Public Shared Sub ExportarDesdeDataTable(dt As DataTable, nombreArchivo As String, formHost As Form)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub

        Using sfd As New SaveFileDialog() With {
            .Filter = "Archivo CSV (*.csv)|*.csv",
            .FileName = $"Export_{nombreArchivo}_{Now:yyyyMMdd_HHmm}.csv"
        }
            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(sfd.FileName, False, Encoding.UTF8)
                    sw.WriteLine(String.Join(",", dt.Columns.Cast(Of DataColumn).Select(Function(c) EscaparCSV(c.ColumnName))))

                    For Each fila As DataRow In dt.Rows
                        Dim valores = String.Join(",", fila.ItemArray.Select(Function(valor) EscaparCSV(valor.ToString())))
                        sw.WriteLine(valores)
                    Next
                End Using
                MostrarToasts(formHost, $"Datos completos exportados correctamente.")
            End If
        End Using
    End Sub

    Private Shared Function EscaparCSV(texto As String) As String
        If texto Is Nothing Then Return ""
        If texto.Contains(",") OrElse texto.Contains("""") Then
            texto = texto.Replace("""", """""")
            Return $"""{texto}"""
        End If
        Return texto
    End Function

    Private Shared Sub MostrarToasts(formHost As Form, mensaje As String)
        Dim toast As New ToastUI("Guardado exitosamente...", TipoToastUI.Success)
        toast.Mostrar()
    End Sub

End Class

