Imports System.Data
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports ClosedXML.Excel
Imports OfficeOpenXml
Imports OfficeOpenXml.Style

Public Class ExcelExportManagerUI

    Public Shared Sub ExportarDesdeGridEstilizado(grid As DataGridView, Optional nombreArchivo As String = "ExportEstilizado", Optional excluirPrimeras As Integer = 3)
        If grid Is Nothing OrElse grid.Rows.Count = 0 Then
            MostrarToasts("No hay datos para exportar.", TipoToastUI.Warning)
            Exit Sub
        End If

        Using sfd As New SaveFileDialog With {
        .Filter = "Archivo Excel (*.xlsx)|*.xlsx",
        .FileName = $"Export_{nombreArchivo}_{Now:yyyyMMdd_HHmm}.xlsx"
    }
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim tabla = ObtenerTablaDesdeGrid(grid, excluirPrimeras)
                'Llama del modulo de exportación ExcelExporterUI
                ExcelExporterUI.ExportarToExcelStyle(tabla, sfd.FileName)
                MostrarToasts("Exportación completada con éxito.", TipoToastUI.Success)
            End If
        End Using
    End Sub

    Private Shared Function ObtenerTablaDesdeGrid(grid As DataGridView, Optional excluirPrimeras As Integer = 0) As DataTable
        Dim tabla As New DataTable()

        For i = excluirPrimeras To grid.Columns.Count - 1
            tabla.Columns.Add(grid.Columns(i).HeaderText)
        Next

        For Each fila As DataGridViewRow In grid.Rows
            If Not fila.IsNewRow AndAlso fila.Visible Then
                Dim valores As New List(Of String)
                For i = excluirPrimeras To grid.Columns.Count - 1
                    valores.Add(fila.Cells(i).Value?.ToString())
                Next
                tabla.Rows.Add(valores.ToArray())
            End If
        Next

        Return tabla
    End Function

    Private Shared Sub MostrarToasts(formHost As Form, mensaje As String)
        Dim toast As New ToastUI(mensaje, TipoToastUI.Success)
        toast.Mostrar()
    End Sub

    Private Shared Sub MostrarToasts(mensaje As String, tipomensaje As TipoToastUI)
        Dim toast As New ToastUI(mensaje, TipoToastUI.Success)
        toast.Mostrar()
    End Sub

End Class
