Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class ExcelExportWUI
    Inherits UserControl

    Private WithEvents btnExportarPagina As New ButtonWUI()
    Private WithEvents btnExportarTodo As New ButtonWUI()
    Private _gridOrigen As DataGridView
    Private _tablaCompleta As DataTable

    Public Sub New()
        Me.Size = New Size(280, 40)
        Me.BackColor = Color.Transparent

        ' Botón 1: Página actual
        btnExportarPagina.BotonTexto = ChrW(&HF56E) & " Página"
        btnExportarPagina.Size = New Size(130, 35)
        btnExportarPagina.BaseColor = Color.Teal
        btnExportarPagina.TextColor = Color.White
        btnExportarPagina.Location = New Point(0, 0)
        Me.Controls.Add(btnExportarPagina)

        ' Botón 2: Todo el DataTable
        btnExportarTodo.BotonTexto = ChrW(&HF56E) & " Todo"
        btnExportarTodo.Size = New Size(130, 35)
        btnExportarTodo.BaseColor = Color.DarkSlateGray
        btnExportarTodo.TextColor = Color.White
        btnExportarTodo.Location = New Point(140, 0)
        Me.Controls.Add(btnExportarTodo)
    End Sub

    Public Property GridOrigen As DataGridView
        Get
            Return _gridOrigen
        End Get
        Set(value As DataGridView)
            _gridOrigen = value
        End Set
    End Property

    Public Property TablaCompleta As DataTable
        Get
            Return _tablaCompleta
        End Get
        Set(value As DataTable)
            _tablaCompleta = value
        End Set
    End Property

    Private Sub btnExportarPagina_BotonClick(sender As Object, e As EventArgs) Handles btnExportarPagina.BotonClick
        ExportarDesdeGrid(_gridOrigen, "PaginaActual")
    End Sub

    Private Sub btnExportarTodo_BotonClick(sender As Object, e As EventArgs) Handles btnExportarTodo.BotonClick
        ExportarDesdeDataTable(_tablaCompleta, "TodosLosDatos")
    End Sub

    Private Sub ExportarDesdeGrid(grid As DataGridView, tipo As String)
        If grid Is Nothing OrElse grid.Rows.Count = 0 Then Exit Sub
        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV (.csv)|.csv"
            sfd.FileName = $"Export_{tipo}_{Now:yyyyMMdd_HHmm}.csv"
            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(sfd.FileName, False, Encoding.UTF8)
                    Dim headers = String.Join(",", grid.Columns.Cast(Of DataGridViewColumn).Select(Function(c) c.HeaderText))
                    sw.WriteLine(headers)
                    For Each row As DataGridViewRow In grid.Rows
                        If Not row.IsNewRow Then
                            Dim valores = String.Join(",", row.Cells.Cast(Of DataGridViewCell).Select(Function(cell) cell.Value?.ToString().Replace(",", " ")))
                            sw.WriteLine(valores)
                        End If
                    Next
                End Using

                ' 🎯 Toast visual
                Dim toastExportado As New AlertToastWUI()
                toastExportado.TipoToast = ToastType.Success
                toastExportado.MensajeToast = "Página actual exportada con éxito"
                toastExportado.MostrarToast(Me.FindForm())
            End If
        End Using
    End Sub

    Private Sub ExportarDesdeDataTable(dt As DataTable, tipo As String)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Exit Sub
        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV (.csv)|.csv"
            sfd.FileName = $"Export_{tipo}_{Now:yyyyMMdd_HHmm}.csv"
            If sfd.ShowDialog() = DialogResult.OK Then
                Using sw As New StreamWriter(sfd.FileName, False, Encoding.UTF8)
                    sw.WriteLine(String.Join(",", dt.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName)))
                    For Each fila As DataRow In dt.Rows
                        Dim valores = String.Join(",", fila.ItemArray.Select(Function(item) item.ToString().Replace(",", " ")))
                        sw.WriteLine(valores)
                    Next
                End Using

                ' 🎯 Toast visual
                Dim toastExportado As New AlertToastWUI()
                toastExportado.TipoToast = ToastType.Success
                toastExportado.MensajeToast = "¡Datos completos exportados correctamente!"
                toastExportado.MostrarToast(Me.FindForm())
            End If
        End Using
    End Sub

    'Dim exportador As New ExcelExporterWilmerUI()
    'exportador.Location = New Point(20, 380)
    'exportador.GridOrigen = gridWilmer.Controls.OfType(Of DataGridView).FirstOrDefault()
    'exportador.TablaCompleta = miDataTable
    'Me.Controls.Add(exportador)


End Class
