Imports System.IO
Imports DocumentFormat.OpenXml.Spreadsheet
Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports OfficeOpenXml.Table

Public Module ExcelExporterUI

    ''' <summary>
    ''' Exporta un DataGridView a Excel con estilo empresarial, alineación semántica y exclusión de columnas con íconos.
    ''' </summary>
    ''' <param name="dgv">Grid de origen visual</param>
    ''' <param name="rutaDestino">Ruta absoluta del archivo .xlsx</param>
    ''' 
    Dim estilosOpenXml As New DocumentFormat.OpenXml.Spreadsheet.TableStyles()

    Public Sub ExportarToExcelStyle(tabla As DataTable, rutaDestino As String, Optional nombreHoja As String = "Datos")
        If tabla Is Nothing OrElse tabla.Rows.Count = 0 Then Exit Sub

        ExcelPackage.License.SetNonCommercialPersonal("Wilmer")

        Using pkg As New ExcelPackage()
            Dim ws = pkg.Workbook.Worksheets.Add(nombreHoja)

            ' Cargar tabla estructurada
            Dim rango = ws.Cells("A1").LoadFromDataTable(tabla, True)
            Dim nombreSeguro = "Tabla_" & Guid.NewGuid().ToString("N").Substring(0, 8)
            Dim tablaExcel = ws.Tables.Add(rango, nombreSeguro)
            tablaExcel.TableStyle = OfficeOpenXml.Table.TableStyles.Medium9

            ' Alineación por tipo de datos
            For i = 0 To tabla.Columns.Count - 1
                Dim col = tabla.Columns(i)
                Dim celda = ws.Cells(2, i + 1, tabla.Rows.Count + 1, i + 1)

                If col.DataType Is GetType(Date) Then
                    celda.Style.Numberformat.Format = "dd/MM/yyyy"
                    celda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                ElseIf col.DataType Is GetType(Decimal) OrElse col.DataType Is GetType(Double) Then
                    celda.Style.Numberformat.Format = "#,##0.00"
                    celda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                ElseIf col.DataType Is GetType(Integer) Then
                    celda.Style.Numberformat.Format = "#,##0"
                    celda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right
                Else
                    celda.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left
                End If
            Next

            ws.Cells.AutoFitColumns()
            pkg.SaveAs(New FileInfo(rutaDestino))
        End Using
    End Sub

End Module
