Imports System.Drawing
Imports System.Windows.Forms

Public Class DataGridViewWUI
    Inherits UserControl

    Private _grid As New DataGridView()
    Private _panelPaginador As New Panel()
    Private _btnPrimero As New ButtonWUI()
    Private _btnAnterior As New ButtonWUI()
    Private _btnSiguiente As New ButtonWUI()
    Private _btnUltimo As New ButtonWUI()
    Private _lblPaginaInfo As New Label()
    Private _txtBuscar As New TextBox()
    Private _dataOriginal As DataTable
    Private _paginaActual As Integer = 1
    Private _registrosPorPagina As Integer = 10
    Private _totalPaginas As Integer = 1
    Private _dataFiltrada As DataTable

    Public Sub New()
        Me.Size = New Size(650, 380)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        ' Grid
        _grid.Size = New Size(Me.Width - 20, Me.Height - 100)
        _grid.Location = New Point(10, 50)
        _grid.ReadOnly = True
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        _grid.AllowUserToAddRows = False
        _grid.BorderStyle = BorderStyle.None
        _grid.BackgroundColor = Color.White
        _grid.DefaultCellStyle.BackColor = Color.White
        _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255)
        _grid.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
        _grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        _grid.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        _grid.EnableHeadersVisualStyles = False
        Me.Controls.Add(_grid)

        ' Buscador
        _txtBuscar.Location = New Point(10, 10)
        _txtBuscar.Size = New Size(200, 25)
        AddHandler _txtBuscar.TextChanged, Sub() AplicarFiltro()
        Me.Controls.Add(_txtBuscar)

        ' Paginador
        _panelPaginador.Size = New Size(Me.Width, 40)
        _panelPaginador.Location = New Point(0, Me.Height - 45)

        _btnPrimero.BotonTexto = "⏮ Primero"
        _btnPrimero.Size = New Size(90, 28)
        _btnPrimero.Location = New Point(10, 5)
        AddHandler _btnPrimero.BotonClick, Sub() Navegar("primero")

        _btnAnterior.BotonTexto = "◀ Anterior"
        _btnAnterior.Size = New Size(90, 28)
        _btnAnterior.Location = New Point(105, 5)
        AddHandler _btnAnterior.BotonClick, Sub() Navegar("anterior")

        _btnSiguiente.BotonTexto = "Siguiente ▶"
        _btnSiguiente.Size = New Size(90, 28)
        _btnSiguiente.Location = New Point(200, 5)
        AddHandler _btnSiguiente.BotonClick, Sub() Navegar("siguiente")

        _btnUltimo.BotonTexto = "Último ⏭"
        _btnUltimo.Size = New Size(90, 28)
        _btnUltimo.Location = New Point(295, 5)
        AddHandler _btnUltimo.BotonClick, Sub() Navegar("ultimo")

        _lblPaginaInfo.Font = New Font("Segoe UI", 9, FontStyle.Bold)
        _lblPaginaInfo.Size = New Size(120, 25)
        _lblPaginaInfo.Location = New Point(400, 8)
        _lblPaginaInfo.Text = "Página 1 / 1"

        _panelPaginador.Controls.AddRange({_btnPrimero, _btnAnterior, _btnSiguiente, _btnUltimo, _lblPaginaInfo})
        Me.Controls.Add(_panelPaginador)
    End Sub

    Public Property RegistrosPorPagina As Integer
        Get
            Return _registrosPorPagina
        End Get
        Set(value As Integer)
            _registrosPorPagina = value
        End Set
    End Property

    Public Sub CargarDatos(dt As DataTable)
        _dataOriginal = dt.Copy()
        _paginaActual = 1
        AplicarFiltro()
    End Sub

    Private Sub AplicarFiltro()
        Dim filtro = _txtBuscar.Text.ToLower()
        If String.IsNullOrEmpty(filtro) Then
            _dataFiltrada = _dataOriginal.Copy()
        Else
            _dataFiltrada = _dataOriginal.Clone()
            For Each row In _dataOriginal.Rows
                Dim concatenado = String.Join(" ", DirectCast(row, DataRow).ItemArray).ToLower()
                If concatenado.Contains(filtro) Then
                    _dataFiltrada.ImportRow(row)
                End If
            Next
        End If
        _totalPaginas = Math.Max(1, Math.Ceiling(_dataFiltrada.Rows.Count / _registrosPorPagina))
        _paginaActual = Math.Min(_paginaActual, _totalPaginas)
        MostrarPagina()
    End Sub

    Private Sub Navegar(accion As String)
        Select Case accion
            Case "primero" : _paginaActual = 1
            Case "anterior" : _paginaActual = Math.Max(1, _paginaActual - 1)
            Case "siguiente" : _paginaActual = Math.Min(_totalPaginas, _paginaActual + 1)
            Case "ultimo" : _paginaActual = _totalPaginas
        End Select
        MostrarPagina()
    End Sub

    Private Sub MostrarPagina()
        If _dataFiltrada Is Nothing Then Exit Sub
        Dim dtTemp = _dataFiltrada.Clone()
        Dim start = (_paginaActual - 1) * _registrosPorPagina
        Dim finish = Math.Min(start + _registrosPorPagina, _dataFiltrada.Rows.Count)

        For i = start To finish - 1
            dtTemp.ImportRow(_dataFiltrada.Rows(i))
        Next

        _grid.DataSource = dtTemp
        _lblPaginaInfo.Text = $"Página {_paginaActual} / {_totalPaginas}"
    End Sub
End Class
