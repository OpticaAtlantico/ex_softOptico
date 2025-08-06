' DataGridViewGUI - Control personalizado profesional con filtros, paginación y eventos
Imports System.ComponentModel
Imports System.Data
Imports ClosedXML.Excel
Imports FontAwesome.Sharp

Public Class DataGridViewGUI
    Inherits UserControl

    ' === Eventos ===
    Public Event RefrescarSolicitado()
    Public Event EnviarProducto()
    Public Event ProductoSeleccionado(producto As DataRow)

    ' === Propiedades públicas ===
    Public Property MetodoCargaDatos As Func(Of DataTable)
    Public Property DataCompleta As DataTable
        Get
            Return _dataCompleta
        End Get
        Set(value As DataTable)
            _dataCompleta = value
            dgvOrbital.DataSource = value
        End Set
    End Property

    Public ReadOnly Property Grid As DataGridView
        Get
            Return dgvOrbital
        End Get
    End Property

    Public ReadOnly Property Filtros As TextboxFiltroUI
        Get
            Return filtro
        End Get
    End Property

    ' === Campos ===
    Private _dataCompleta As DataTable
    Private dataTableOriginal As DataTable
    Private paginaActual As Integer = 1
    Private registrosPorPagina As Integer = 20
    Private totalPaginas As Integer = 1

    ' === Componentes ===
    Private WithEvents dgvOrbital As DataGridView
    Private WithEvents filtro As TextboxFiltroUI
    Private paginador As FlowLayoutPanel
    Private lblPaginaInfo As Label
    Private btnPrev, btnNext, btnInicio, btnFin As CommandButtonUI
    Private spinner As OverlayDataGridSpinnerUI

    Private headerUI As HeaderUI
    Private btnEnviar As CommandButtonUI
    Private btnRefrescar As CommandButtonUI

    ' === Constructor ===
    Public Sub New()
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.WhiteSmoke

        InicializarControles()
        PrepararLayout()
        PrepararEstiloVisual()

        AddHandler filtro.TextChanged, AddressOf FiltrarRegistros
        AddHandler btnEnviar.Click, Sub()
                                        Dim producto As DataRow = ObtenerProductoSeleccionado()
                                        If producto IsNot Nothing Then RaiseEvent ProductoSeleccionado(producto)
                                    End Sub
        AddHandler btnRefrescar.Click, Sub() RaiseEvent RefrescarSolicitado()
    End Sub

    ' === Inicialización ===
    Private Sub InicializarControles()
        filtro = New TextboxFiltroUI() With {
            .Dock = DockStyle.Top,
            .PlaceholderText = "Buscar registros...",
            .Icono = IconChar.Search,
            .IconColor = Color.DarkGray
        }

        dgvOrbital = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Century Gothic", 10),
            .AllowUserToAddRows = False,
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }

        paginador = New FlowLayoutPanel() With {
            .Dock = DockStyle.Bottom,
            .Height = 55,
            .FlowDirection = FlowDirection.LeftToRight,
            .BackColor = Color.WhiteSmoke,
            .Padding = New Padding(10, 0, 10, 10)
        }

        btnInicio = CrearBotonPaginador("Primero", IconChar.AngleDoubleLeft)
        btnPrev = CrearBotonPaginador("Anterior", IconChar.AngleLeft)
        btnNext = CrearBotonPaginador("Siguiente", IconChar.AngleRight)
        btnFin = CrearBotonPaginador("Último", IconChar.AngleDoubleRight)

        lblPaginaInfo = New Label With {
            .Text = "Página 1 de 1",
            .Font = New Font("Century Gothic", 9, FontStyle.Italic),
            .AutoSize = True,
            .Margin = New Padding(12, 19, 0, 0)
        }

        btnEnviar = New CommandButtonUI() With {
            .Texto = "Enviar",
            .EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary,
            .Icono = IconChar.Plus
        }

        btnRefrescar = New CommandButtonUI() With {
            .Texto = "Refrescar",
            .EstiloBoton = CommandButtonUI.EstiloBootstrap.Success,
            .Icono = IconChar.SyncAlt
        }

        headerUI = New HeaderUI() With {
            .Dock = DockStyle.Fill,
            .ColorFondo = Color.White,
            .ColorTexto = Color.FromArgb(45, 45, 45),
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .Icono = IconChar.CircleInfo,
            .Titulo = "Registros Orbitales",
            .Subtitulo = "Gestión de registros con paginación y filtros",
            .MostrarSeparador = False
        }

        spinner = New OverlayDataGridSpinnerUI()
    End Sub

    Private Function CrearBotonPaginador(texto As String, icono As IconChar) As CommandButtonUI
        Return New CommandButtonUI() With {
            .Texto = texto,
            .EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary,
            .Width = 110,
            .Icono = icono
        }
    End Function

    Private Sub PrepararLayout()
        Dim panelTop As New Panel With {.Dock = DockStyle.Top, .Height = 68}
        Dim panelBotones As New FlowLayoutPanel With {
            .Dock = DockStyle.Right,
            .FlowDirection = FlowDirection.RightToLeft,
            .WrapContents = False,
            .Padding = New Padding(12, 8, 12, 8),
            .BackColor = Color.White,
            .Width = 450
        }
        panelBotones.Controls.AddRange({btnEnviar, btnRefrescar})
        panelTop.Controls.Add(headerUI)
        panelTop.Controls.Add(panelBotones)

        paginador.Controls.AddRange({btnInicio, btnPrev, btnNext, btnFin, lblPaginaInfo})
        Me.Controls.AddRange({spinner, dgvOrbital, paginador, filtro, panelTop})
    End Sub

    Private Sub PrepararEstiloVisual()
        ActivarDoubleBuffering(dgvOrbital)

        dgvOrbital.EnableHeadersVisualStyles = False
        dgvOrbital.ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .Alignment = DataGridViewContentAlignment.MiddleLeft,
            .Padding = New Padding(6, 10, 6, 10),
            .BackColor = Color.FromArgb(220, 240, 255),
            .ForeColor = Color.FromArgb(45, 45, 45)
        }

        dgvOrbital.DefaultCellStyle = New DataGridViewCellStyle With {
            .Font = New Font("Century Gothic", 10),
            .ForeColor = Color.Black,
            .BackColor = Color.White,
            .SelectionBackColor = Color.LightSteelBlue,
            .SelectionForeColor = Color.Black,
            .Padding = New Padding(3)
        }

        dgvOrbital.RowTemplate.Height = 29
        dgvOrbital.GridColor = Color.LightBlue
        dgvOrbital.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgvOrbital.ColumnHeadersHeight = 38
    End Sub

    Private Sub ActivarDoubleBuffering(grid As DataGridView)
        Dim tipo As Type = grid.GetType()
        Dim prop = tipo.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If prop IsNot Nothing Then prop.SetValue(grid, True, Nothing)
    End Sub

    ' === Funciones ===
    Public Sub RefrescarTodo()
        If MetodoCargaDatos IsNot Nothing Then
            filtro.Texto = ""
            Dim nuevaTabla As DataTable = MetodoCargaDatos.Invoke()
            CargarDatos(nuevaTabla)
        End If
    End Sub

    Public Sub CargarDatos(datos As DataTable)
        If datos Is Nothing Then Exit Sub
        dataTableOriginal = datos.Copy()
        paginaActual = 1
        totalPaginas = Math.Max(1, Math.Ceiling(dataTableOriginal.Rows.Count / registrosPorPagina))
        RefrescarPaginacion(FuenteActual())
    End Sub

    Private Sub FiltrarRegistros(sender As Object, e As EventArgs)
        Dim texto = filtro.TextoFiltrado.Trim().ToLower()
        Dim fuenteFiltrado As DataTable =
            If(String.IsNullOrEmpty(texto), dataTableOriginal, FiltrarTabla(dataTableOriginal, texto))

        paginaActual = 1
        totalPaginas = Math.Max(1, Math.Ceiling(fuenteFiltrado.Rows.Count / registrosPorPagina))
        RefrescarPaginacion(fuenteFiltrado)
    End Sub

    Private Function FuenteActual() As DataTable
        Dim texto = filtro.TextoFiltrado.Trim().ToLower()
        Return If(String.IsNullOrEmpty(texto), dataTableOriginal, FiltrarTabla(dataTableOriginal, texto))
    End Function

    Private Function FiltrarTabla(dt As DataTable, texto As String) As DataTable
        Dim columnas = dt.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName)
        Dim vista = dt.AsEnumerable().Where(Function(row)
                                                Return columnas.Any(Function(col)
                                                                        Dim valor = If(row(col), "").ToString().ToLower()
                                                                        Return valor.Contains(texto)
                                                                    End Function)
                                            End Function)

        Return If(vista.Any(), vista.CopyToDataTable(), dt.Clone())
    End Function

    Public Sub RefrescarPaginacion(tablaBase As DataTable)
        Dim inicio = (paginaActual - 1) * registrosPorPagina
        Dim subTabla = tablaBase.Clone()

        For i = inicio To Math.Min(inicio + registrosPorPagina - 1, tablaBase.Rows.Count - 1)
            subTabla.ImportRow(tablaBase.Rows(i))
        Next

        dgvOrbital.Rows.Clear()
        For Each row As DataRow In subTabla.Rows
            CrearFilaDesdeRow(row)
        Next

        lblPaginaInfo.Text = $"Página {paginaActual} de {totalPaginas}"
    End Sub

    Private Sub CrearFilaDesdeRow(row As DataRow)
        Dim nuevaFila As New DataGridViewRow()
        nuevaFila.CreateCells(dgvOrbital)

        For i As Integer = 0 To dgvOrbital.Columns.Count - 1
            AsignarValorCelda(nuevaFila, row, i)
        Next

        dgvOrbital.Rows.Add(nuevaFila)
    End Sub

    Private Sub AsignarValorCelda(fila As DataGridViewRow, row As DataRow, i As Integer)
        Dim nombreColumna As String = dgvOrbital.Columns(i).Name
        Select Case nombreColumna
            Case "Agregar"
                fila.Cells(i).Value = IconCharToBitmap(IconChar.Plus, Color.SeaGreen, 18)
            Case "Editar"
                fila.Cells(i).Value = IconCharToBitmap(IconChar.Pen, Color.SteelBlue, 18)
            Case "Eliminar"
                fila.Cells(i).Value = IconCharToBitmap(IconChar.TrashAlt, Color.Firebrick, 18)
            Case Else
                If row.Table.Columns.Contains(nombreColumna) Then
                    fila.Cells(i).Value = row(nombreColumna)
                Else
                    fila.Cells(i).Value = Nothing
                End If
        End Select
    End Sub

    Private Function IconCharToBitmap(icono As IconChar, color As Color, size As Integer) As Bitmap
        Dim icon As New IconPictureBox With {.IconChar = icono, .IconColor = color, .Size = New Size(size, size)}
        Dim bmp As New Bitmap(icon.Width, icon.Height)
        icon.DrawToBitmap(bmp, icon.ClientRectangle)
        Return bmp
    End Function

    Private Function ObtenerProductoSeleccionado() As DataRow
        If dgvOrbital.SelectedRows.Count = 0 Then Return Nothing

        Dim index As Integer = dgvOrbital.SelectedRows(0).Index
        Dim fuente As DataTable = FuenteActual()

        Dim filaReal = (paginaActual - 1) * registrosPorPagina + index
        If filaReal >= 0 AndAlso filaReal < fuente.Rows.Count Then
            Return fuente.Rows(filaReal)
        End If

        Return Nothing
    End Function

    Private Sub dgvOrbital_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrbital.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim producto = ObtenerProductoSeleccionado()
            If producto IsNot Nothing Then RaiseEvent ProductoSeleccionado(producto)
        End If
    End Sub

    Public Sub ConfigurarColumnasVisualesPorTipo(tabla As DataTable,
                                             columnasVisibles As String(),
                                             anchosDefinidos As Dictionary(Of String, Integer),
                                             nombresVisuales As Dictionary(Of String, String))

        dgvOrbital.Columns.Clear()
        dgvOrbital.AutoGenerateColumns = False

        For Each col As DataColumn In tabla.Columns
            If columnasVisibles Is Nothing OrElse columnasVisibles.Contains(col.ColumnName) Then
                Dim ancho = If(anchosDefinidos IsNot Nothing AndAlso anchosDefinidos.ContainsKey(col.ColumnName),
                       anchosDefinidos(col.ColumnName), 120)

                Dim header = If(nombresVisuales IsNot Nothing AndAlso nombresVisuales.ContainsKey(col.ColumnName),
                        nombresVisuales(col.ColumnName), col.ColumnName)

                Dim estilo = New DataGridViewCellStyle()

                Select Case col.DataType
                    Case GetType(String)
                        estilo.Alignment = DataGridViewContentAlignment.MiddleLeft
                    Case GetType(Integer), GetType(Long), GetType(Decimal), GetType(Double)
                        estilo.Alignment = DataGridViewContentAlignment.MiddleRight
                        estilo.Format = "N2"
                    Case GetType(DateTime)
                        estilo.Alignment = DataGridViewContentAlignment.MiddleCenter
                        estilo.Format = "dd/MM/yyyy"
                    Case GetType(Boolean)
                        estilo.Alignment = DataGridViewContentAlignment.MiddleCenter
                End Select

                Dim columnaVisual As New DataGridViewTextBoxColumn() With {
                .Name = col.ColumnName,
                .HeaderText = header,
                .Width = ancho,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                .DefaultCellStyle = estilo,
                .Resizable = DataGridViewTriState.True
            }

                dgvOrbital.Columns.Add(columnaVisual)
            End If
        Next

        dgvOrbital.ScrollBars = ScrollBars.Both
        dgvOrbital.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None
        dgvOrbital.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
    End Sub


End Class

