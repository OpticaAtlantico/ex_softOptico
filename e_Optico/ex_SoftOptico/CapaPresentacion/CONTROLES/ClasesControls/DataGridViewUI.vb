Imports System.ComponentModel
Imports FontAwesome.Sharp
Imports ClosedXML.Excel
Public Class DataGridViewUI
    Inherits UserControl

    ' 🎯 Eventos
    Public Event EditarRegistro(id As Integer)
    Public Event EliminarRegistro(id As Integer)
    Public Event AgregarRegistro()

    ' 🧩 Componentes visuales
    Private dgvOrbital As DataGridView
    Private filtro As TextboxFiltroUI
    Private paginador As FlowLayoutPanel
    Private lblPaginaInfo As Label
    Private btnPrev, btnNext As Button
    Private spinner As OverlayDataGridSpinnerUI
    Private panelBotonesUI As FlowLayoutPanel

    ' 🧠 Datos y paginación
    Private dataTableOriginal As DataTable
    Private paginaActual As Integer = 1
    Private registrosPorPagina As Integer = 10
    Private totalPaginas As Integer = 1

    ' 🎨 Botones y encabezado
    Private btnNuevo As New CommandButtonUI() With {
        .Texto = "Nuevo",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
    }
    Private btnRefrescar As New CommandButtonUI() With {
        .Texto = "Refrescar",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
    }
    Private btnExportar As New CommandButtonUI() With {
        .Texto = "Exportar",
        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Info
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
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.WhiteSmoke

        PrepararLayout()
        PrepararColumnas()
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
        PanelDerecho.Controls.AddRange({btnNuevo, BRefrescar, BExportar})
        PanelContenedorBotonesUI.Controls.AddRange({PanelDerecho, PanelIzquierdo})
        Me.Controls.Add(PanelContenedorBotonesUI)

        AddHandler BNuevo.Click, Sub() RaiseEvent AgregarRegistro()
        'AddHandler btnRefrescar.Click, Sub() RefrescarGrid()
        'AddHandler BExportar.Click, Sub() ExportarExcel()
        'AddHandler BRefrescar.Click, Sub() RestablecerVista()

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
            .Font = New Font("Segoe UI", 10),
            .AllowUserToAddRows = False,
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }
        AddHandler dgvOrbital.CellClick, AddressOf dgvOrbital_CellClick

        paginador = New FlowLayoutPanel() With {
            .Dock = DockStyle.Bottom,
            .Height = 45,
            .FlowDirection = FlowDirection.LeftToRight,
            .BackColor = Color.WhiteSmoke,
            .Padding = New Padding(10)
        }

        btnPrev = CrearBoton("‹ Anterior", Color.DodgerBlue)
        btnNext = CrearBoton("Siguiente ›", Color.DodgerBlue)
        AddHandler btnPrev.Click, AddressOf IrPaginaAnterior
        AddHandler btnNext.Click, AddressOf IrPaginaSiguiente

        lblPaginaInfo = New Label With {
            .Text = "Página 1 de 1",
            .Font = New Font("Segoe UI", 9, FontStyle.Italic),
            .AutoSize = True,
            .Margin = New Padding(12, 12, 0, 0)
        }

        paginador.Controls.AddRange({btnPrev, btnNext, lblPaginaInfo})
        Me.Controls.AddRange({dgvOrbital, paginador, filtro})
    End Sub

    Private Sub PrepararEstiloVisualOrbital()
        dgvOrbital.EnableHeadersVisualStyles = False
        dgvOrbital.ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
        .BackColor = Color.FromArgb(220, 240, 255),
        .ForeColor = Color.FromArgb(45, 45, 45),
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .Alignment = DataGridViewContentAlignment.MiddleLeft,
        .Padding = New Padding(4)
    }

        dgvOrbital.DefaultCellStyle = New DataGridViewCellStyle With {
        .Font = New Font("Segoe UI", 10),
        .ForeColor = Color.Black,
        .BackColor = Color.White,
        .SelectionBackColor = Color.LightSteelBlue,
        .SelectionForeColor = Color.Black,
        .Padding = New Padding(3)
    }

        dgvOrbital.RowTemplate.Height = 32
        dgvOrbital.GridColor = Color.LightGray
    End Sub

    ' 🎨 Columnas orbitales
    Private Sub PrepararColumnas()
        dgvOrbital.Columns.Clear()
        dgvOrbital.AutoGenerateColumns = False

        dgvOrbital.Columns.Add(New DataGridViewImageColumn() With {
            .Image = IconChar.Plus.ToBitmapPaint(Color.SeaGreen, 18),
            .Width = 20,
            .HeaderText = ""
        })
        dgvOrbital.Columns.Add(New DataGridViewImageColumn() With {
            .Image = IconChar.Pen.ToBitmapPaint(Color.SteelBlue, 18),
            .Width = 20,
            .HeaderText = ""
        })
        dgvOrbital.Columns.Add(New DataGridViewImageColumn() With {
            .Image = IconChar.TrashAlt.ToBitmapPaint(Color.Firebrick, 18),
            .Width = 20,
            .HeaderText = ""
        })

        dgvOrbital.Columns.Add("ID", "ID")
        dgvOrbital.Columns.Add("Nombre", "Nombre completo")
        dgvOrbital.Columns.Add("Correo", "Correo electrónico")
    End Sub

    Private Sub dgvOrbital_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Exit Sub

        Dim grid = DirectCast(sender, DataGridView)
        Dim id = Convert.ToInt32(grid.Rows(e.RowIndex).Cells(3).Value) ' Columna ID

        Select Case e.ColumnIndex
            Case 0 ' Icono Plus
                RaiseEvent AgregarRegistro()
            Case 1 ' Icono Editar
                RaiseEvent EditarRegistro(id)
            Case 2 ' Icono Eliminar
                RaiseEvent EliminarRegistro(id)
        End Select
    End Sub

    ' 🔘 Botones Bootstrap
    Private Function CrearBoton(texto As String, color As Color) As Button
        Return New Button With {
            .Text = texto,
            .BackColor = color,
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 9),
            .Width = 110,
            .Height = 40,
            .Margin = New Padding(8)
        }
    End Function

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

    ' 🧩 Paginación
    Private Sub RefrescarPaginacion(tablaBase As DataTable)
        Dim inicio = (paginaActual - 1) * registrosPorPagina
        Dim subTabla = tablaBase.Clone()

        For i = inicio To Math.Min(inicio + registrosPorPagina - 1, tablaBase.Rows.Count - 1)
            subTabla.ImportRow(tablaBase.Rows(i))
        Next

        dgvOrbital.Rows.Clear()
        For Each row As DataRow In subTabla.Rows
            dgvOrbital.Rows.Add(
                IconChar.Plus.ToBitmapPaint(Color.SeaGreen, 18),
                IconChar.Pen.ToBitmapPaint(Color.SteelBlue, 18),
                IconChar.TrashAlt.ToBitmapPaint(Color.Firebrick, 18),
                row("ID"), row("Nombre"), row("Correo")
            )
        Next

        lblPaginaInfo.Text = $"Página {paginaActual} de {totalPaginas}"
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

    Public Property BExportar As CommandButtonUI
        Get
            Return btnExportar
        End Get
        Set(value As CommandButtonUI)
            btnExportar = value
        End Set
    End Property

    Public ReadOnly Property Filtros As TextboxFiltroUI
        Get
            Return filtro
        End Get
    End Property
End Class

'Imports System.ComponentModel
'Imports FontAwesome.Sharp
'Imports ClosedXML.Excel

'Public Class DataGridViewUI
'    Inherits UserControl

'    Public Event EditarRegistro(id As Integer)
'    Public Event EliminarRegistro(id As Integer)
'    Public Event AgregarRegistro()

'    Private dgvOrbital As DataGridView
'    Private filtro As TextboxFiltroUI
'    Private paginador As FlowLayoutPanel
'    Private lblPaginaInfo As Label
'    Private btnPrev, btnNext As Button

'    Private dataTableOriginal As DataTable    ' respaldo maestro, NO tocar al filtrar
'    Private dataTableVista As DataTable    ' para mostrar en el grid
'    Private paginaActual As Integer = 1
'    Private registrosPorPagina As Integer = 10
'    Private totalPaginas As Integer = 1

'    Private spinner As OverlayDataGridSpinnerUI
'    Private panelBotonesUI As FlowLayoutPanel

'    Public Sub New()
'        Me.Dock = DockStyle.Fill
'        Me.BackColor = Color.WhiteSmoke
'        PrepararLayout()
'        PrepararColumnas()
'        PrepararEstiloVisualOrbital()

'        spinner = New OverlayDataGridSpinnerUI()
'        Me.Controls.Add(spinner)

'        'Panel Contenedor
'        Dim PanelContenedorBotonesUI As New Panel With {
'            .Dock = DockStyle.Top,
'            .Height = 68
'        }

'        '🔵 Panel izquierdo con botones externos Nuevo Refrescar y exportar
'        Dim PanelIzquierdo As New Panel With {
'            .Dock = DockStyle.Left,
'            .Width = 600,
'            .BackColor = Color.Green
'        }

'        Dim PanelDerecho As New FlowLayoutPanel() With {
'            .Dock = DockStyle.Fill,
'            .FlowDirection = FlowDirection.RightToLeft,
'            .WrapContents = False,
'            .Padding = New Padding(12, 8, 12, 8),
'            .BackColor = Color.White
'        }

'        'Hace la llamada a la propiedad lblTitulo
'        PanelIzquierdo.Controls.Add(lblTitulo)

'        'Insertar panel izquierdo con botones
'        PanelDerecho.Controls.AddRange({btnNuevo, BRefrescar, BExportar})

'        ' 🧱 Integración completa
'        PanelContenedorBotonesUI.Controls.AddRange({PanelDerecho, PanelIzquierdo})
'        Me.Controls.Add(PanelContenedorBotonesUI)

'        AddHandler BNuevo.Click, Sub() RaiseEvent AgregarRegistro()
'        AddHandler btnRefrescar.Click, Sub() RefrescarGrid()
'        AddHandler BExportar.Click, Sub() ExportarExcel()
'        AddHandler BRefrescar.Click, Sub() RestablecerVista()

'        If filtro IsNot Nothing Then
'            AddHandler filtro.TextChanged, AddressOf FiltrarRegistros
'            Debug.Print("Evento conectado al filtro orbital correctamente")
'        End If

'    End Sub
'    Public Property DataOriginal As DataTable
'        Get
'            Return dataTableOriginal
'        End Get
'        Set(value As DataTable)
'            dataTableOriginal = value
'        End Set
'    End Property

'    Public Property lblTitulo As HeaderUI
'        Get
'            Return headerUI
'        End Get
'        Set(value As HeaderUI)
'            headerUI = value
'        End Set
'    End Property

'    Public Property BNuevo As CommandButtonUI
'        Get
'            Return btnNuevo
'        End Get
'        Set(value As CommandButtonUI)
'            btnNuevo = value
'        End Set
'    End Property

'    Public Property BRefrescar As CommandButtonUI
'        Get
'            Return btnRefrescar
'        End Get
'        Set(value As CommandButtonUI)
'            btnRefrescar = value
'        End Set
'    End Property

'    Public Property BExportar As CommandButtonUI
'        Get
'            Return btnExportar
'        End Get
'        Set(value As CommandButtonUI)
'            btnExportar = value
'        End Set
'    End Property
'    Public ReadOnly Property Filtros As TextboxFiltroUI
'        Get
'            Return filtro
'        End Get
'    End Property


'    Private btnNuevo As New CommandButtonUI() With {
'        .Texto = "Nuevo",
'        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Primary
'    }
'    Private btnRefrescar As New CommandButtonUI() With {
'        .Texto = "Refrescar",
'        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Success
'    }
'    Private btnExportar As New CommandButtonUI() With {
'        .Texto = "Exportar",
'        .EstiloBoton = CommandButtonUI.EstiloBootstrap.Info
'    }

'    Private headerUI As New HeaderUI() With {
'        .Dock = DockStyle.Fill,
'        .ColorFondo = Color.White,
'        .ColorTexto = Color.FromArgb(45, 45, 45),
'        .Font = New Font("Century Gothic", 10, FontStyle.Bold),
'        .Icono = IconChar.CircleInfo,
'        .Titulo = "Registros Orbitales",
'        .Subtitulo = "Gestión de registros con paginación y filtros",
'        .MostrarSeparador = False
'    }

'    '2. Método PrepararLayout con diseño Bootstrap orbita

'    Private Sub PrepararLayout()
'        ' 🔍 TextBox de búsqueda
'        filtro = New TextboxFiltroUI() With {
'                                                    .Dock = DockStyle.Top,
'                                                    .PlaceholderText = "Buscar registros...",
'                                                    .Icono = IconChar.Search,
'                                                    .IconColor = Color.DarkGray
'                                                }

'        ' 📋 DataGridView visual
'        dgvOrbital = New DataGridView() With {
'            .Dock = DockStyle.Fill,
'            .BackgroundColor = Color.White,
'            .BorderStyle = BorderStyle.None,
'            .Font = New Font("Segoe UI", 10),
'            .AllowUserToAddRows = False,
'            .RowHeadersVisible = False,
'            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
'            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
'        }
'        AddHandler dgvOrbital.CellClick, AddressOf dgvOrbital_CellClick

'        ' 📄 Paginador visual tipo Bootstrap
'        paginador = New FlowLayoutPanel() With {
'            .Dock = DockStyle.Bottom,
'            .Height = 45,
'            .FlowDirection = FlowDirection.LeftToRight,
'            .BackColor = Color.WhiteSmoke,
'            .Padding = New Padding(10)
'        }

'        btnPrev = CrearBoton("‹ Anterior", Color.DodgerBlue)
'        btnNext = CrearBoton("Siguiente ›", Color.DodgerBlue)
'        AddHandler btnPrev.Click, AddressOf IrPaginaAnterior
'        AddHandler btnNext.Click, AddressOf IrPaginaSiguiente

'        lblPaginaInfo = New Label With {
'            .Text = "Página 1 de 1",
'            .Font = New Font("Segoe UI", 9, FontStyle.Italic),
'            .AutoSize = True,
'            .Margin = New Padding(12, 12, 0, 0)
'        }

'        panelBotonesUI = New FlowLayoutPanel() With {
'            .Dock = DockStyle.Top,
'            .Height = 64,
'            .FlowDirection = FlowDirection.LeftToRight,
'            .Padding = New Padding(5),
'            .BackColor = Color.WhiteSmoke
'        }

'        paginador.Controls.AddRange({btnPrev, btnNext, lblPaginaInfo})
'        Me.Controls.AddRange({dgvOrbital, paginador, filtro})
'        'AddHandler filtro.TextChanged, AddressOf FiltrarRegistros


'    End Sub

'    '🧰 5. Botón orbital tipo Bootstrap

'    Private Function CrearBoton(texto As String, color As Color) As Button
'        Return New Button With {
'            .Text = texto,
'            .BackColor = color,
'            .ForeColor = Color.White,
'            .FlatStyle = FlatStyle.Flat,
'            .Font = New Font("Segoe UI", 9),
'            .Width = 110,
'            .Height = 40,
'            .Margin = New Padding(8)
'        }
'    End Function

'    '🎨 3. Columnas con íconos orbitales por fil

'    Private Sub PrepararColumnas()
'        dgvOrbital.Columns.Clear()

'        ' 🔘 Botones por fila con íconos orbitales
'        dgvOrbital.Columns.Add(New DataGridViewImageColumn() With {
'        .Image = IconChar.Plus.ToBitmapPaint(Color.SeaGreen, 18),
'        .Width = 15,
'        .HeaderText = ""
'    })

'        dgvOrbital.Columns.Add(New DataGridViewImageColumn() With {
'        .Image = IconChar.Pen.ToBitmapPaint(Color.SteelBlue, 18),
'        .Width = 15,
'        .HeaderText = ""
'    })

'        dgvOrbital.Columns.Add(New DataGridViewImageColumn() With {
'        .Image = IconChar.TrashAlt.ToBitmapPaint(Color.Firebrick, 18),
'        .Width = 15,
'        .HeaderText = ""
'    })

'        ' 🧩 Columnas de datos
'        dgvOrbital.Columns.Add("ID", "ID")
'        dgvOrbital.Columns.Add("Nombre", "Nombre completo")
'        dgvOrbital.Columns.Add("Correo", "Correo electrónico")
'    End Sub

'    Public Sub CargarDatos(datos As DataTable)
'        If dataTableOriginal Is Nothing OrElse dataTableOriginal.Rows.Count = 0 Then
'            dataTableOriginal = datos.Copy() ' solo la primera vez
'        End If

'        dataTableVista = datos.Copy()
'        dgvOrbital.DataSource = dataTableVista
'        paginaActual = 1
'        totalPaginas = Math.Max(1, Math.Ceiling(dataTableVista.Rows.Count / registrosPorPagina))
'        RefrescarPaginacion()
'    End Sub

'    Private Sub FiltrarRegistros(sender As Object, e As EventArgs)
'        Dim texto = filtro.TextoFiltrado.Trim().ToLower()

'        Dim fuenteFiltrado As DataTable =
'        If(String.IsNullOrEmpty(texto), dataTableOriginal,
'           CargarDatos(dataTableOriginal, texto))

'        paginaActual = 1
'        totalPaginas = Math.Max(1, Math.Ceiling(fuenteFiltrado.Rows.Count / registrosPorPagina))
'        RefrescarPaginacion(fuenteFiltrado)
'    End Sub

'    Private Sub RefrescarPaginacion(tablaBase As DataTable)
'        Dim inicio = (paginaActual - 1) * registrosPorPagina
'        Dim subTabla = tablaBase.Clone()

'        For i = inicio To Math.Min(inicio + registrosPorPagina - 1, tablaBase.Rows.Count - 1)
'            subTabla.ImportRow(tablaBase.Rows(i))
'        Next

'        dgvOrbital.Rows.Clear()
'        For Each row As DataRow In subTabla.Rows
'            dgvOrbital.Rows.Add(... valores ...)
'        Next

'        lblPaginaInfo.Text = $"Página {paginaActual} de {totalPaginas}"
'    End Sub

'    Private Sub IrPaginaAnterior(sender As Object, e As EventArgs)
'        If paginaActual > 1 Then
'            paginaActual -= 1
'            RefrescarPaginacion()
'        End If
'    End Sub

'    Private Sub IrPaginaSiguiente(sender As Object, e As EventArgs)
'        If paginaActual < totalPaginas Then
'            paginaActual += 1
'            RefrescarPaginacion()
'        End If
'    End Sub

'    'Private Sub FiltrarRegistros(sender As Object, e As EventArgs)
'    '    Dim texto = filtro.TextoFiltrado.Trim().ToLower()

'    '    If String.IsNullOrEmpty(texto) Then
'    '        CargarDatos(dataTableOriginal) ' 🛠 restaura original
'    '        Return
'    '    End If

'    '    Dim vistaFiltrada = dataTableOriginal.AsEnumerable().
'    '        Where(Function(row)
'    '                  Return row("Nombre").ToString().ToLower().Contains(texto) _
'    '                  OrElse row("Correo").ToString().ToLower().Contains(texto)
'    '              End Function)

'    '    If vistaFiltrada.Any() Then
'    '        CargarDatos(vistaFiltrada.CopyToDataTable())
'    '    Else
'    '        CargarDatos(New DataTable()) ' 🧼 tabla vacía
'    '    End If
'    'End Sub


'    Private Sub dgvOrbital_CellClick(sender As Object, e As DataGridViewCellEventArgs)
'        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

'        Dim id = CInt(dgvOrbital.Rows(e.RowIndex).Cells("ID").Value)

'        Select Case e.ColumnIndex
'            Case 0 : RaiseEvent AgregarRegistro()
'            Case 1 : RaiseEvent EditarRegistro(id)
'            Case 2 : RaiseEvent EliminarRegistro(id)
'        End Select
'    End Sub

'    Private Function CrearBotonBootstrap(texto As String, icono As IconChar, colorFondo As Color) As Button
'        Dim btn = New Button With {
'            .Text = $"  {texto}",
'            .FlatStyle = FlatStyle.Flat,
'            .ForeColor = Color.White,
'            .BackColor = colorFondo,
'            .Font = New Font("Segoe UI", 9),
'            .Height = 32,
'            .Width = 120,
'            .Margin = New Padding(6),
'            .TextAlign = ContentAlignment.MiddleLeft,
'            .ImageAlign = ContentAlignment.MiddleLeft
'        }

'        Dim bmp = icono.ToBitmapPaint(Color.White, 18)
'        btn.Image = bmp
'        Return btn
'    End Function

'    Private Sub ExportarExcel()
'        If dgvOrbital.Rows.Count = 0 Then
'            MessageBox.Show("No hay registros para exportar.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Exit Sub
'        End If

'        Dim wb = New XLWorkbook()
'        Dim ws = wb.Worksheets.Add("Registros")

'        ' 📝 Escribir encabezados
'        Dim colOffset = 3 ' Saltar columnas de íconos
'        For col = colOffset To dgvOrbital.Columns.Count - 1
'            ws.Cell(1, col - colOffset + 1).Value = dgvOrbital.Columns(col).HeaderText
'            ws.Cell(1, col - colOffset + 1).Style.Font.Bold = True
'            ws.Cell(1, col - colOffset + 1).Style.Fill.BackgroundColor = XLColor.LightSteelBlue
'            ws.Cell(1, col - colOffset + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
'            ws.Cell(1, col - colOffset + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin
'        Next

'        ' 📋 Escribir filas
'        For i = 0 To dgvOrbital.Rows.Count - 1
'            For j = colOffset To dgvOrbital.Columns.Count - 1
'                ws.Cell(i + 2, j - colOffset + 1).Value = dgvOrbital.Rows(i).Cells(j).Value?.ToString()
'            Next
'        Next

'        ws.Columns().AdjustToContents()

'        ' 📄 Guardar archivo
'        Dim dlg As New SaveFileDialog() With {
'        .Filter = "Archivo Excel (*.xlsx)|*.xlsx",
'        .FileName = $"RegistrosOrbital_{Now:yyyyMMdd_HHmm}.xlsx"
'    }

'        If dlg.ShowDialog() = DialogResult.OK Then
'            wb.SaveAs(dlg.FileName)
'            MessageBox.Show("Exportación completada correctamente.", "Excel orbital", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        End If
'    End Sub

'    Private Sub RefrescarGrid()
'        If dataTableOriginal IsNot Nothing Then
'            CargarDatos(dataTableOriginal)
'        End If
'    End Sub

'    Public Sub RestablecerVista()
'        ' 🗘 Borrar filtro visual si usas TextboxFiltroUI integrado
'        For Each ctrl In Me.Controls
'            If TypeOf ctrl Is TextboxFiltroUI Then
'                DirectCast(ctrl, TextboxFiltroUI).PlaceholderText = "Buscar..."
'                DirectCast(ctrl, TextboxFiltroUI).Text = ""
'            End If
'        Next

'        ' 🧹 Reiniciar datos si hay tabla original
'        If dataTableOriginal IsNot Nothing Then
'            CargarDatos(dataTableOriginal)
'        End If

'        ' ⏮ Volver a primera página orbital
'        paginaActual = 1
'        totalPaginas = Math.Max(1, Math.Ceiling(dataTableOriginal.Rows.Count / registrosPorPagina))
'        RefrescarPaginacion()
'    End Sub

'    Private Sub PrepararEstiloVisualOrbital()
'        With dgvOrbital
'            ' 🔷 General visual
'            .RowTemplate.Height = 34
'            .Font = New Font("Segoe UI", 10)
'            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
'            .DefaultCellStyle.Padding = New Padding(4)
'            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255)

'            ' 🧾 Bordes tipo Bootstrap
'            .GridColor = Color.Silver
'            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
'            .BorderStyle = BorderStyle.None

'            ' 🎨 Encabezado visual
'            .EnableHeadersVisualStyles = False
'            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(235, 240, 255)
'            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
'            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
'            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
'            .ColumnHeadersHeight = 25
'            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
'        End With

'        ' 🔘 Eventos de hover orbital
'        AddHandler dgvOrbital.CellMouseEnter, AddressOf dgvOrbital_CellMouseEnter
'        AddHandler dgvOrbital.CellMouseLeave, AddressOf dgvOrbital_CellMouseLeave
'    End Sub

'    Private Sub dgvOrbital_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs)
'        If e.RowIndex >= 0 Then
'            dgvOrbital.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255)
'        End If
'    End Sub

'    Private Sub dgvOrbital_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs)
'        If e.RowIndex >= 0 Then
'            dgvOrbital.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
'        End If
'    End Sub



'    'Como usarlo en el formulario:

'    'Private WithEvents gridUI As New GridModuloUI()

'    'Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'    '    Me.Controls.Add(gridUI)

'    '    ' Cargar registros simulados
'    '    Dim dt As New DataTable()
'    '    dt.Columns.Add("ID", GetType(Integer))
'    '    dt.Columns.Add("Nombre")
'    '    dt.Columns.Add("Correo")

'    '    dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
'    '    dt.Rows.Add(2, "Sofía Ramos", "sofia@empresa.com")
'    '    dt.Rows.Add(3, "Carlos López", "carlos@empresa.com")

'    '    gridUI.CargarDatos(dt)
'    'End Sub

'    '' Eventos públicos orbitando 🚀
'    'Private Sub gridUI_EditarRegistro(id As Integer) Handles gridUI.EditarRegistro
'    '    MessageBox.Show($"Editar: {id}")
'    'End Sub

'    'Private Sub gridUI_EliminarRegistro(id As Integer) Handles gridUI.EliminarRegistro
'    '    MessageBox.Show($"Eliminar: {id}")
'    'End Sub

'    'Private Sub gridUI_AgregarRegistro() Handles gridUI.AgregarRegistro
'    '    MessageBox.Show("Agregar nuevo registro")
'    'End Sub

'End Class