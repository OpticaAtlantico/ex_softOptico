Public Class FiltroDemoUI
    Private filtro As New TextBox With {
        .Dock = DockStyle.Top,
        .Font = New Font("Segoe UI", 10),
        .PlaceholderText = "Buscar..."
    }

    Private grid As New DataGridView With {
        .Dock = DockStyle.Fill,
        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        .ReadOnly = True,
        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    }

    Private respaldo As DataTable

    Public Sub New()
        Me.Text = "Filtro Reactivo de Prueba"
        Me.Size = New Size(600, 400)
        Me.Controls.Add(grid)
        Me.Controls.Add(filtro)

        ' Simular datos
        respaldo = New DataTable()
        respaldo.Columns.Add("Nombre")
        respaldo.Columns.Add("Correo")
        respaldo.Rows.Add("Wilmer Duarte", "wilmer@empresa.com")
        respaldo.Rows.Add("Sofía Ramos", "sofia@empresa.com")
        respaldo.Rows.Add("Carlos López", "carlos@empresa.com")

        grid.DataSource = respaldo.Copy()

        AddHandler filtro.TextChanged, Sub()
                                           Dim texto = filtro.Text.Trim().ToLower()

                                           If String.IsNullOrEmpty(texto) Then
                                               grid.DataSource = respaldo.Copy()
                                               Return
                                           End If

                                           Dim resultado = respaldo.AsEnumerable().
                                               Where(Function(r) r("Nombre").ToString().ToLower().Contains(texto) _
                                                   OrElse r("Correo").ToString().ToLower().Contains(texto))

                                           grid.DataSource = If(resultado.Any(), resultado.CopyToDataTable(), Nothing)
                                       End Sub
    End Sub
End Class