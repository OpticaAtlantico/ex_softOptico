Imports System.ComponentModel
Imports System.Data
Imports System.IO
Imports System.Text
Imports CapaDatos
Imports ClosedXML.Excel
Imports FontAwesome.Sharp
Public Class DataGridListaComprasUI
    Inherits UserControl

    ' 🎯 Eventos
    Public Event EditarRegistro(id As Integer)
    Public Event EliminarRegistro(id As Integer)
    Public Event AgregarRegistro()
    Public Event ExportarExcelN()
    Public Event RefrescarSolicitado()

    Private _dataCompleta As DataTable
    Public Event ExportarExcelSolicitado()

    ' 🧩 Componentes visuales
    Private dgvOrbital As DataGridView
    Private filtro As TextboxFiltroUI
    Private paginador As FlowLayoutPanel
    Private lblPaginaInfo As Label
    Private btnPrev, btnNext, btnInicio, btnFin As CommandButtonUI
    Private spinner As OverlayDataGridSpinnerUI
    Private panelBotonesUI As FlowLayoutPanel

    ' 🧠 Datos y paginación
    Private dataTableOriginal As DataTable
    Private paginaActual As Integer = 1
    Private registrosPorPagina As Integer = 20
    Private totalPaginas As Integer = 1
    Public Property MetodoCargaDatos As Func(Of DataTable)

    ' 🎨 Botones y encabezado
    Private btnNuevo As New CommandButtonUI() With {
        .Texto = "Nuevo",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary,
        .Icono = IconChar.Plus
    }
    Private btnRefrescar As New CommandButtonUI() With {
        .Texto = "Refrescar",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Success,
        .Icono = IconChar.SyncAlt
    }
    Private btnExportarGrid As New CommandButtonUI() With {
        .Texto = "Exportar Grid",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Info,
        .Icono = IconChar.FileExcel
    }
    Private btnExportarTabla As New CommandButtonUI() With {
        .Texto = "Exportar Tabla",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Info,
        .Icono = IconChar.FileExcel
    }

    Private headerUI As New HeaderUI() With {
        .Dock = DockStyle.Fill,
        .ColorFondo = Color.White,
        .ColorTexto = Color.FromArgb(45, 45, 45),
        .Font = New Font("Century Gothic", 10, FontStyle.Bold),
        .Icono = IconChar.CircleInfo,
        .Titulo = "Registros Orbitales",
        .Subtitulo = "Gestión de registros con paginación y filtros",
        .MostrarSeparador = False
    }

    ' 🚀 Constructor orbital
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.WhiteSmoke

        PrepararLayout()
        PrepararEstiloVisualOrbital()

        spinner = New OverlayDataGridSpinnerUI()
        Me.Controls.Add(spinner)

        ' 🔧 Panel de botones superiores
        Dim PanelContenedorBotonesUI As New Panel With {.Dock = DockStyle.Top, .Height = 68}

        Dim PanelIzquierdo As New Panel With {.Dock = DockStyle.Left, .Width = 600, .BackColor = Color.Green}
        Dim PanelDerecho As New FlowLayoutPanel With {
            .Dock = DockStyle.Fill,
            .FlowDirection = FlowDirection.RightToLeft,
            .WrapContents = False,
            .Padding = New Padding(12, 8, 12, 8),
            .BackColor = Color.White
        }

        PanelIzquierdo.Controls.Add(lblTitulo)
        PanelDerecho.Controls.AddRange({btnNuevo, BRefrescar, BExportarGrid, BExportarTabla})
        PanelContenedorBotonesUI.Controls.AddRange({PanelDerecho, PanelIzquierdo})
        Me.Controls.Add(PanelContenedorBotonesUI)

        AddHandler BNuevo.Click, Sub() RaiseEvent AgregarRegistro()
        AddHandler btnRefrescar.Click, Sub() RefrescarTodo()
        AddHandler btnExportarGrid.Click, Sub()
                                              RaiseEvent ExportarExcelSolicitado()
                                          End Sub
        AddHandler btnExportarTabla.Click, Sub()
                                               RaiseEvent ExportarExcelSolicitado()
                                           End Sub


        ' 🔁 Conexión del filtro reactivo
        If filtro IsNot Nothing Then
            AddHandler filtro.TextChanged, AddressOf FiltrarRegistros
        End If
    End Sub

    ' 🧩 Layout visual
    Private Sub PrepararLayout()
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
        AddHandler dgvOrbital.CellClick, AddressOf dgvOrbital_CellClick

        paginador = New FlowLayoutPanel() With {
            .Dock = DockStyle.Bottom,
            .Height = 55,
            .FlowDirection = FlowDirection.LeftToRight,
            .BackColor = Color.WhiteSmoke,
            .Padding = New Padding(10, 0, 10, 10)
        }

        btnPrev = CrearBotonPaginadorUI("Anterior")
        btnNext = CrearBotonPaginadorUI("Siguiente")
        btnInicio = CrearBotonPaginadorUI("Primero")
        btnFin = CrearBotonPaginadorUI("Último")
        AddHandler btnPrev.Click, AddressOf IrPaginaAnterior
        AddHandler btnNext.Click, AddressOf IrPaginaSiguiente
        AddHandler btnInicio.Click, Sub()
                                        paginaActual = 1
                                        RefrescarPaginacion(FuenteActual())
                                    End Sub

        AddHandler btnFin.Click, Sub()
                                     paginaActual = totalPaginas
                                     RefrescarPaginacion(FuenteActual())
                                 End Sub

        AddHandler btnRefrescar.Click, Sub()
                                           RaiseEvent RefrescarSolicitado()
                                           'RefrescarGridInterno() ' Descomenta si también quieres que se actualice interno
                                       End Sub

        lblPaginaInfo = New Label With {
            .Text = "Página 1 de 1",
            .Font = New Font("Century Gothic", 9, FontStyle.Italic),
            .AutoSize = True,
            .Margin = New Padding(12, 19, 0, 0)
        }

        paginador.Controls.AddRange({btnInicio, btnPrev, btnNext, btnFin, lblPaginaInfo})
        Me.Controls.AddRange({dgvOrbital, paginador, filtro})

    End Sub
    Public Sub RefrescarTodo()
        If MetodoCargaDatos IsNot Nothing Then
            filtro.Texto = ""
            Dim nuevaTabla As DataTable = MetodoCargaDatos.Invoke()
            CargarDatos(nuevaTabla)
        End If
    End Sub

    Private Function CrearBotonPaginadorUI(texto As String) As CommandButtonUI
        Dim btn As New CommandButtonUI() With {
                .Texto = texto,
                .EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary,
                .Width = 110
            }

        ' Establecer el ícono según el texto
        Select Case texto.ToLower()
            Case "anterior"
                btn.Icono = FontAwesome.Sharp.IconChar.AngleLeft
            Case "siguiente"
                btn.Icono = FontAwesome.Sharp.IconChar.AngleRight
            Case "primero"
                btn.Icono = FontAwesome.Sharp.IconChar.AngleDoubleLeft
            Case "último"
                btn.Icono = FontAwesome.Sharp.IconChar.AngleDoubleRight
            Case Else
                btn.Icono = FontAwesome.Sharp.IconChar.Circle
        End Select

        Return btn
    End Function

    Private Sub PrepararEstiloVisualOrbital()
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


    Public Sub ConfigurarColumnasVisualesPorTipo(tabla As DataTable,
                                             columnasVisibles As String(),
                                             anchosDefinidos As Dictionary(Of String, Integer),
                                             nombresVisuales As Dictionary(Of String, String))

        'dgvOrbital.Columns.Clear()
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
                        estilo.Format = "N0"
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

    Private Sub dgvOrbital_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim grid = DirectCast(sender, DataGridView)
        Dim id = Convert.ToInt32(grid.Rows(e.RowIndex).Cells(3).Value) ' Columna ID

        Select Case e.ColumnIndex
            Case 0 ' Icono Plus
                Dim idCompra = Convert.ToInt32(grid.Rows(e.RowIndex).Cells("CompraID").Value)
                MostrarDetalleCompra(idCompra, e.RowIndex)
            Case 1 ' Icono Editar
                RaiseEvent EditarRegistro(id)
            Case 2 ' Icono Eliminar
                RaiseEvent EliminarRegistro(id)
        End Select
    End Sub

    ' 📦 Cargar datos orbitales
    Public Sub CargarDatos(datos As DataTable)
        If dataTableOriginal Is Nothing OrElse dataTableOriginal.Rows.Count = 0 Then
            dataTableOriginal = datos.Copy()
        End If
        paginaActual = 1
        totalPaginas = Math.Max(1, Math.Ceiling(dataTableOriginal.Rows.Count / registrosPorPagina))
        RefrescarPaginacion(dataTableOriginal)
    End Sub

    ' 🧠 Filtro reactivo
    Private Sub FiltrarRegistros(sender As Object, e As EventArgs)
        Dim texto = filtro.TextoFiltrado.Trim().ToLower()
        Dim fuenteFiltrado As DataTable =
            If(String.IsNullOrEmpty(texto), dataTableOriginal, FiltrarTabla(dataTableOriginal, texto))

        paginaActual = 1
        totalPaginas = Math.Max(1, Math.Ceiling(fuenteFiltrado.Rows.Count / registrosPorPagina))
        RefrescarPaginacion(fuenteFiltrado)
    End Sub

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

    Public Sub CrearFilaDesdeRow(row As DataRow)
        Dim nuevaFila As New DataGridViewRow()
        nuevaFila.CreateCells(dgvOrbital)

        For i As Integer = 0 To dgvOrbital.Columns.Count - 1
            Dim nombreColumna As String = dgvOrbital.Columns(i).Name

            Select Case nombreColumna
                Case "Agregar"
                    nuevaFila.Cells(i).Value = IconCharToBitmap(IconChar.Plus, Color.SeaGreen, 18)
                Case "Editar"
                    nuevaFila.Cells(i).Value = IconCharToBitmap(IconChar.Pen, Color.SteelBlue, 18)
                Case "Eliminar"
                    nuevaFila.Cells(i).Value = IconCharToBitmap(IconChar.TrashAlt, Color.Firebrick, 18)
                Case Else
                    If row.Table.Columns.Contains(nombreColumna) Then
                        nuevaFila.Cells(i).Value = row(nombreColumna)
                    Else
                        nuevaFila.Cells(i).Value = Nothing
                    End If
            End Select
        Next

        ' Luego puedes agregar filas
        dgvOrbital.Rows.Add(nuevaFila)
        NeutralizarFondoIconos(dgvOrbital)
    End Sub
    Public Sub AgregarColumnasBotones()
        If Not dgvOrbital.Columns.Contains("Agregar") Then
            Dim colAgregar As New DataGridViewImageColumn() With {
            .Name = "Agregar",
            .HeaderText = "",
            .Width = 40,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
            colAgregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOrbital.Columns.Add(colAgregar)
        End If

        If Not dgvOrbital.Columns.Contains("Editar") Then
            Dim colEditar As New DataGridViewImageColumn() With {
            .Name = "Editar",
            .HeaderText = "",
            .Width = 40,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
            colEditar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOrbital.Columns.Add(colEditar)
        End If

        If Not dgvOrbital.Columns.Contains("Eliminar") Then
            Dim colEliminar As New DataGridViewImageColumn() With {
            .Name = "Eliminar",
            .HeaderText = "",
            .Width = 40,
            .ImageLayout = DataGridViewImageCellLayout.Zoom
        }
            colEliminar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvOrbital.Columns.Add(colEliminar)
        End If
    End Sub

    Public Sub NeutralizarFondoIconos(grid As DataGridView)
        For Each col As DataGridViewColumn In grid.Columns
            If TypeOf col Is DataGridViewImageColumn Then
                col.DefaultCellStyle.BackColor = Color.White
                col.DefaultCellStyle.SelectionBackColor = Color.White
                col.DefaultCellStyle.SelectionForeColor = Color.White
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
        Next
    End Sub

    Private Sub IrPaginaAnterior(sender As Object, e As EventArgs)
        If paginaActual > 1 Then
            paginaActual -= 1
            RefrescarPaginacion(FuenteActual())
        End If
    End Sub

    Private Sub IrPaginaSiguiente(sender As Object, e As EventArgs)
        If paginaActual < totalPaginas Then
            paginaActual += 1
            RefrescarPaginacion(FuenteActual())
        End If
    End Sub

    Private Function FuenteActual() As DataTable
        Dim texto = filtro.TextoFiltrado.Trim().ToLower()
        Return If(String.IsNullOrEmpty(texto), dataTableOriginal, FiltrarTabla(dataTableOriginal, texto))
    End Function
    Private Function FiltrarTabla(dt As DataTable, texto As String) As DataTable
        Dim textoFiltrado = texto.ToLower().Trim()
        If String.IsNullOrWhiteSpace(textoFiltrado) Then Return dt

        Dim columnas = dt.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName)

        Dim vista = dt.AsEnumerable().Where(Function(row)
                                                Return columnas.Any(Function(col)
                                                                        Dim valor = If(row(col), "").ToString().ToLower()
                                                                        Return valor.Contains(textoFiltrado)
                                                                    End Function)
                                            End Function)

        Return If(vista.Any(), vista.CopyToDataTable(), dt.Clone())
    End Function

    Private Sub MostrarDetalleCompra(idCompra As Integer, filaIndex As Integer)
        'Enviar idCompra al frmDetallesCompra
        Dim overlay As New FondoOverlayUI()
        overlay.Show()

        Dim frmDetalles As New frmDetallesCompra() With {
            .idCompra = idCompra
        }
        frmDetalles.ShowDialog()
        overlay.Close()
    End Sub

    Public Sub ExportarConEstiloExcel(Optional nombreArchivo As String = "ExportEstilizado")
        If dgvOrbital Is Nothing OrElse dgvOrbital.Rows.Count = 0 Then
            MostrarToast("No hay datos para exportar", TipoToastUI.Warning)
            Exit Sub
        End If

        Using sfd As New SaveFileDialog With {
        .Filter = "Archivo Excel (*.xlsx)|*.xlsx",
        .FileName = $"{nombreArchivo}_{Now:yyyyMMdd_HHmm}.xlsx"
    }
            If sfd.ShowDialog() = DialogResult.OK Then
                Dim tabla = ObtenerTablaDesdeGrid(dgvOrbital, excluirPrimeras:=3)
                ExcelExporterUI.ExportarToExcelStyle(tabla, sfd.FileName)
                MostrarToast("Exportación completada con éxito", TipoToastUI.Success)
            End If
        End Using
    End Sub

    ''' <summary>
    ''' Convierte el contenido del DataGridView a DataTable excluyendo columnas iniciales.
    ''' </summary>
    Public Function ObtenerTablaDesdeGrid(grid As DataGridView, Optional excluirPrimeras As Integer = 0) As DataTable
        Dim tabla As New DataTable()
        Dim columnas = grid.Columns.Cast(Of DataGridViewColumn)().
        Where(Function(c) c.Visible AndAlso c.Index >= excluirPrimeras).ToList()

        For Each col In columnas
            Dim tipoDato = If(col.ValueType, GetType(String))
            tabla.Columns.Add(col.HeaderText, tipoDato)
        Next

        For Each fila As DataGridViewRow In grid.Rows
            If Not fila.IsNewRow Then
                Dim valores = columnas.Select(Function(c) fila.Cells(c.Index).Value).ToArray()
                tabla.Rows.Add(valores)
            End If
        Next

        Return tabla
    End Function

    Private Sub MostrarToast(mensaje As String, tipo As TipoToastUI)
        Dim toast As New ToastUI(mensaje, tipo)
        toast.Mostrar()
    End Sub

    Private Sub ActivarDoubleBuffering(grid As DataGridView)
        Dim tipo As Type = grid.GetType()
        Dim prop = tipo.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If prop IsNot Nothing Then
            prop.SetValue(grid, True, Nothing)
        End If
    End Sub

    Public Property DataOriginal As DataTable
        Get
            Return dataTableOriginal
        End Get
        Set(value As DataTable)
            dataTableOriginal = value
        End Set
    End Property

    Public Property lblTitulo As HeaderUI
        Get
            Return headerUI
        End Get
        Set(value As HeaderUI)
            headerUI = value
        End Set
    End Property

    Public Property BNuevo As CommandButtonUI
        Get
            Return btnNuevo
        End Get
        Set(value As CommandButtonUI)
            btnNuevo = value
        End Set
    End Property

    Public Property BRefrescar As CommandButtonUI
        Get
            Return btnRefrescar
        End Get
        Set(value As CommandButtonUI)
            btnRefrescar = value
        End Set
    End Property

    Public Property BExportarGrid As CommandButtonUI
        Get
            Return btnExportarGrid
        End Get
        Set(value As CommandButtonUI)
            btnExportarGrid = value
        End Set
    End Property

    Public Property BExportarTabla As CommandButtonUI
        Get
            Return btnExportarTabla
        End Get
        Set(value As CommandButtonUI)
            btnExportarTabla = value
        End Set
    End Property

    Public ReadOnly Property Filtros As TextboxFiltroUI
        Get
            Return filtro
        End Get
    End Property
    Public ReadOnly Property GrvOrbital As DataGridView
        Get
            Return Me.dgvOrbital
        End Get
    End Property

    ' Acceso al grid real
    Public ReadOnly Property Grid As DataGridView
        Get
            Return dgvOrbital
        End Get
    End Property

    ' Fuente completa de datos (por si usas paginación)
    Public Property DataCompleta As DataTable
        Get
            Return _dataCompleta
        End Get
        Set(value As DataTable)
            _dataCompleta = value
            dgvOrbital.DataSource = value
        End Set
    End Property

End Class
