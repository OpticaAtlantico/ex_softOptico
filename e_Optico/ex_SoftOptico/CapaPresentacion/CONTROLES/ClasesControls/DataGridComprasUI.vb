Imports System.ComponentModel
Imports CapaEntidad

Public Class DataGridComprasUI
    Inherits UserControl

#Region "Campos"

    Private dgv As New DataGridView()
    Private panelTotales As New FlowLayoutPanel()
    Private lblTotalExento As New Label()
    Private lblBaseImponible As New Label()
    Private lblIva As New Label()
    Private lblTotalGeneral As New Label()
    Private _ivaPorcentaje As Decimal = 16D

#End Region

#Region "Eventos"

    Public Event TotalActualizado(totalExento As Decimal, baseImponible As Decimal, iva As Decimal, totalGeneral As Decimal)

#End Region

#Region "Propiedades"

    ''' <summary>
    ''' IVA % (Ejemplo: 13)
    ''' </summary>
    Public Property IvaPorcentaje As Decimal
        Get
            Return _ivaPorcentaje
        End Get
        Set(value As Decimal)
            _ivaPorcentaje = value
            CalcularTotales()
        End Set
    End Property
    Public ReadOnly Property TieneDatos As Boolean
        Get
            Return dgv.Rows.Count > 0
        End Get
    End Property

    <Browsable(False)>
    Public ReadOnly Property InnerGridView As DataGridView
        Get
            Return dgv
        End Get
    End Property

#End Region

#Region "Inicializar"

    Public Sub Inicializar()

        PrepararEstiloVisual()

        ' Asegúrate de estar limpiando las columnas antes de volver a agregarlas
        If dgv.Columns.Count > 0 Then
            dgv.Columns.Clear()
        End If

        ' Luego define y agrega tus columnas con los anchos deseados
        Dim colProducto As New DataGridViewTextBoxColumn With {
            .Name = "Producto",
            .HeaderText = "Producto",
            .ReadOnly = True,
            .Width = 420,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim colCantidad As New DataGridViewTextBoxColumn With {
            .Name = "Cantidad",
            .HeaderText = "Cantidad",
            .Width = 100,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim colExG As New DataGridViewTextBoxColumn With {
            .Name = "ExG",
            .HeaderText = "Ex / G",
            .ReadOnly = True,
            .Width = 80,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim colPrecio As New DataGridViewTextBoxColumn With {
            .Name = "Precio",
            .HeaderText = "Precio",
            .Width = 130,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim colSubtotal As New DataGridViewTextBoxColumn With {
            .Name = "Subtotal",
            .HeaderText = "Subtotal",
            .ReadOnly = True,
            .Width = 130,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim btnEliminar As New DataGridViewButtonColumn With {
            .Name = "Eliminar",
            .Text = "🗑",
            .UseColumnTextForButtonValue = True,
            .Width = 50,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        dgv.Columns.AddRange({colProducto, colCantidad, colExG, colPrecio, colSubtotal, btnEliminar})

        ' Eventos
        AddHandler dgv.CellValueChanged, AddressOf CalcularTotales
        AddHandler dgv.CellClick, AddressOf EliminarFila
        AddHandler dgv.EditingControlShowing, AddressOf ManejarCambioEdicion

        ' Panel de totales
        panelTotales.Dock = DockStyle.Bottom
        panelTotales.Height = 40
        panelTotales.FlowDirection = FlowDirection.LeftToRight
        panelTotales.Padding = New Padding(10)
        panelTotales.WrapContents = False

        lblTotalExento.Text = "Exento: 0.00"
        lblBaseImponible.Text = "Base: 0.00"
        lblIva.Text = "IVA: 0.00"
        lblTotalGeneral.Text = "Total: 0.00"

        panelTotales.Controls.AddRange({lblTotalExento, lblBaseImponible, lblIva, lblTotalGeneral})

        ' Agregar al control
        Me.Controls.Add(dgv)
        Me.Controls.Add(panelTotales)
    End Sub

    Private Sub PrepararEstiloVisual()
        ActivarDoubleBuffering(dgv)

        dgv = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .BackgroundColor = Color.White,
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Century Gothic", 10),
            .AllowUserToAddRows = False,
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        }

        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .Alignment = DataGridViewContentAlignment.MiddleLeft,
            .Padding = New Padding(6, 10, 6, 10),
            .BackColor = Color.FromArgb(220, 240, 255),
            .ForeColor = Color.FromArgb(45, 45, 45)
        }

        dgv.DefaultCellStyle = New DataGridViewCellStyle With {
            .Font = New Font("Century Gothic", 10),
            .ForeColor = Color.Black,
            .BackColor = Color.White,
            .SelectionBackColor = Color.LightSteelBlue,
            .SelectionForeColor = Color.Black,
            .Padding = New Padding(3)
        }

        dgv.RowTemplate.Height = 29
        dgv.GridColor = Color.LightBlue
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgv.ColumnHeadersHeight = 38
    End Sub

    Private Sub ActivarDoubleBuffering(grid As DataGridView)
        Dim tipo As Type = grid.GetType()
        Dim prop = tipo.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If prop IsNot Nothing Then prop.SetValue(grid, True, Nothing)
    End Sub

    Private Sub ConfigurarColumnas()
        dgv.Columns.Clear()

        ' === COLUMNA: Código ===
        Dim colCodigo As New DataGridViewTextBoxColumn()
        colCodigo.Name = "Codigo"
        colCodigo.HeaderText = "Código"
        colCodigo.Width = 80
        colCodigo.ReadOnly = True
        dgv.Columns.Add(colCodigo)

        ' === COLUMNA: Descripción ===
        Dim colDescripcion As New DataGridViewTextBoxColumn()
        colDescripcion.Name = "Descripcion"
        colDescripcion.HeaderText = "Descripción del Producto"
        colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colDescripcion.ReadOnly = True
        dgv.Columns.Add(colDescripcion)

        ' === COLUMNA: Cantidad (Editable) ===
        Dim colCantidad As New DataGridViewTextBoxColumn()
        colCantidad.Name = "Cantidad"
        colCantidad.HeaderText = "Cant."
        colCantidad.Width = 60
        colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns.Add(colCantidad)

        ' === COLUMNA: Precio Unitario (Editable) ===
        Dim colPrecio As New DataGridViewTextBoxColumn()
        colPrecio.Name = "Precio"
        colPrecio.HeaderText = "Precio"
        colPrecio.Width = 90
        colPrecio.DefaultCellStyle.Format = "C2"
        colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgv.Columns.Add(colPrecio)

        ' === COLUMNA: Total (calculado, solo lectura) ===
        Dim colTotal As New DataGridViewTextBoxColumn()
        colTotal.Name = "Total"
        colTotal.HeaderText = "Total"
        colTotal.Width = 100
        colTotal.DefaultCellStyle.Format = "C2"
        colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        colTotal.ReadOnly = True
        dgv.Columns.Add(colTotal)

        ' === COLUMNA: Botón Eliminar ===
        Dim colEliminar As New DataGridViewButtonColumn()
        colEliminar.Name = "Eliminar"
        colEliminar.HeaderText = ""
        colEliminar.Width = 30
        colEliminar.Text = "✕"
        colEliminar.UseColumnTextForButtonValue = True
        dgv.Columns.Add(colEliminar)
    End Sub


#End Region

#Region "Métodos Públicos"

    Public Sub AgregarProducto(productoID As Integer, nombre As String, exG As String, precio As Decimal)
        dgv.Rows.Add(nombre, 1, exG, precio, precio)
        dgv.Rows(dgv.Rows.Count - 1).Cells("Producto").Tag = productoID
        CalcularTotales()
    End Sub

    Public Sub AgregarProductoEdit(productoID As Integer, nombre As String, cantidad As Integer, exG As String, precio As Decimal)
        dgv.Rows.Add(nombre, cantidad, exG, precio, precio)
        dgv.Rows(dgv.Rows.Count - 1).Cells("Producto").Tag = productoID
        CalcularTotales()
    End Sub

    Public Function GetDetalleList() As List(Of TDetalleCompra)
        Dim lista As New List(Of TDetalleCompra)

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For

            Dim detalle As New TDetalleCompra()

            detalle.ProductoID = Convert.ToInt32(row.Cells("Producto").Tag)
            'detalle.ProductoName = Convert.ToInt32(row.Cells("Producto").Value)
            detalle.Cantidad = Convert.ToDecimal(row.Cells("Cantidad").Value)
            detalle.PrecioUnitario = Convert.ToDecimal(row.Cells("Precio").Value)
            detalle.Subtotal = Convert.ToDecimal(row.Cells("Subtotal").Value)

            ' Campo opcional ExG
            If dgv.Columns.Contains("ExG") Then
                detalle.ModoCargo = Convert.ToString(row.Cells("ExG").Value)
            Else
                detalle.ModoCargo = String.Empty
            End If

            lista.Add(detalle)
        Next

        Return lista
    End Function

    ' Método público para cargar productos desde el formulario frmCompras
    Public Sub CargarDatos(listaProductos As List(Of ProductoSeleccionado))
        If listaProductos Is Nothing Then Return

        dgv.Rows.Clear()
        For Each producto In listaProductos
            dgv.Rows.Add(
            producto.Codigo,
            producto.Nombre,
            producto.Cantidad,
            producto.Precio,
            producto.Total
        )
        Next

        ' Actualiza totales
        CalcularTotales()
    End Sub

    Public Sub LimpiarGrid()
        dgv.Rows.Clear()
        lblTotalExento.Text = "Exento: 0.00"
        lblBaseImponible.Text = "Base: 0.00"
        lblIva.Text = "IVA: 0.00"
        lblTotalGeneral.Text = "Total: 0.00"
    End Sub

#End Region

#Region "Lógica de Cálculo"

    Private Sub CalcularTotales()
        Dim totalExento As Decimal = 0
        Dim baseImponible As Decimal = 0

        For Each fila As DataGridViewRow In dgv.Rows
            If fila.IsNewRow Then Continue For

            Dim cantidad As Decimal = Convert.ToDecimal(fila.Cells("Cantidad").Value)
            Dim precio As Decimal = Convert.ToDecimal(fila.Cells("Precio").Value)
            Dim subtotal As Decimal = cantidad * precio
            fila.Cells("Subtotal").Value = subtotal

            Dim exg As String = fila.Cells("ExG").Value?.ToString()?.Trim()?.ToUpper()
            If exg = "EX" Then
                totalExento += subtotal
            Else
                baseImponible += subtotal
            End If
        Next

        Dim iva = Math.Round((baseImponible * IvaPorcentaje) / 100, 2)
        Dim totalGeneral = totalExento + baseImponible + iva

        lblTotalExento.Text = $"Exento: {totalExento:N2}"
        lblBaseImponible.Text = $"Base: {baseImponible:N2}"
        lblIva.Text = $"IVA ({IvaPorcentaje}%): {iva:N2}"
        lblTotalGeneral.Text = $"Total: {totalGeneral:N2}"

        RaiseEvent TotalActualizado(totalExento, baseImponible, iva, totalGeneral)
    End Sub

    Public Function CalcularTotal() As Decimal
        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For
            total += Convert.ToDecimal(row.Cells("Subtotal").Value)
        Next

        Return total
    End Function

#End Region

#Region "Eventos de Fila"

    Private Sub EliminarFila(sender As Object, e As DataGridViewCellEventArgs)
        If dgv.Columns(e.ColumnIndex).Name = "Eliminar" Then
            dgv.Rows.RemoveAt(e.RowIndex)
            CalcularTotales()
        End If
    End Sub

    Private Sub ManejarCambioEdicion(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        RemoveHandler CType(e.Control, Control).TextChanged, AddressOf CeldaEditada
        AddHandler CType(e.Control, Control).TextChanged, AddressOf CeldaEditada
    End Sub

    Private Sub CeldaEditada(sender As Object, e As EventArgs)
        CalcularTotales()
    End Sub


#End Region

End Class


















'Imports CapaEntidad
'Imports FontAwesome.Sharp
'Imports System.Reflection
'Imports System.Windows.Forms

'Public Class DataGridComprasUI
'    Inherits UserControl

'#Region "Campos"

'    Private dgv As New DataGridView()
'    Private panelTotales As New FlowLayoutPanel()
'    Private lblTotalExento As New Label()
'    Private lblBaseImponible As New Label()
'    Private lblIva As New Label()
'    Private lblTotalGeneral As New Label()
'    Private _ivaPorcentaje As Decimal = 13D

'#End Region

'#Region "Eventos"

'    Public Event TotalActualizado(totalExento As Decimal, baseImponible As Decimal, iva As Decimal, totalGeneral As Decimal)

'#End Region

'#Region "Propiedades"

'    ''' <summary>
'    ''' IVA % (Ejemplo: 13)
'    ''' </summary>
'    Public Property IvaPorcentaje As Decimal
'        Get
'            Return _ivaPorcentaje
'        End Get
'        Set(value As Decimal)
'            _ivaPorcentaje = value
'            CalcularTotales()
'        End Set
'    End Property

'#End Region

'#Region "Inicializar"

'    Public Sub Inicializar()
'        ' DataGridView
'        dgv.Dock = DockStyle.Fill
'        dgv.AllowUserToAddRows = False
'        dgv.RowHeadersVisible = False
'        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

'        ' Columnas
'        dgv.Columns.Clear()

'        Dim colProducto As New DataGridViewTextBoxColumn With {.Name = "Producto", .HeaderText = "Producto", .ReadOnly = True}
'        Dim colCantidad As New DataGridViewNumericUpDownColumn With {.Name = "Cantidad", .HeaderText = "Cantidad"}
'        Dim colExG As New DataGridViewTextBoxColumn With {.Name = "ExG", .HeaderText = "Ex / G", .ReadOnly = True}
'        Dim colPrecio As New DataGridViewTextBoxColumn With {.Name = "Precio", .HeaderText = "Precio"}
'        Dim colSubtotal As New DataGridViewTextBoxColumn With {.Name = "Subtotal", .HeaderText = "Subtotal", .ReadOnly = True}

'        Dim btnEliminar As New DataGridViewButtonColumn With {
'            .Name = "Eliminar",
'            .Text = "🗑",
'            .UseColumnTextForButtonValue = True
'        }

'        dgv.Columns.AddRange({colProducto, colCantidad, colExG, colPrecio, colSubtotal, btnEliminar})

'        ' Eventos
'        AddHandler dgv.CellValueChanged, AddressOf CalcularTotales
'        AddHandler dgv.CellClick, AddressOf EliminarFila
'        AddHandler dgv.EditingControlShowing, AddressOf ManejarCambioEdicion

'        ' Panel de totales
'        panelTotales.Dock = DockStyle.Bottom
'        panelTotales.Height = 40
'        panelTotales.FlowDirection = FlowDirection.LeftToRight
'        panelTotales.Padding = New Padding(10)

'        lblTotalExento.Text = "Exento: 0.00"
'        lblBaseImponible.Text = "Base: 0.00"
'        lblIva.Text = "IVA: 0.00"
'        lblTotalGeneral.Text = "Total: 0.00"

'        panelTotales.Controls.AddRange({lblTotalExento, lblBaseImponible, lblIva, lblTotalGeneral})

'        ' Agregar al control
'        Me.Controls.Add(dgv)
'        Me.Controls.Add(panelTotales)
'    End Sub

'#End Region

'#Region "Métodos Públicos"

'    Public Sub AgregarProducto(productoID As Integer, nombre As String, exG As String, precio As Decimal)
'        dgv.Rows.Add(nombre, 1, exG, precio, precio)
'        dgv.Rows(dgv.Rows.Count - 1).Cells("Producto").Tag = productoID
'        CalcularTotales()
'    End Sub

'#End Region

'#Region "Lógica de Cálculo"

'    Private Sub CalcularTotales()
'        Dim totalExento As Decimal = 0
'        Dim baseImponible As Decimal = 0

'        For Each fila As DataGridViewRow In dgv.Rows
'            Dim cantidad As Decimal = Convert.ToDecimal(fila.Cells("Cantidad").Value)
'            Dim precio As Decimal = Convert.ToDecimal(fila.Cells("Precio").Value)
'            Dim subtotal As Decimal = cantidad * precio
'            fila.Cells("Subtotal").Value = subtotal

'            Dim exg As String = fila.Cells("ExG").Value?.ToString()?.Trim()?.ToUpper()
'            If exg = "EX" Then
'                totalExento += subtotal
'            Else
'                baseImponible += subtotal
'            End If
'        Next

'        Dim iva = Math.Round((baseImponible * ivaPorcentaje) / 100, 2)
'        Dim totalGeneral = totalExento + baseImponible + iva

'        lblTotalExento.Text = $"Exento: {totalExento:N2}"
'        lblBaseImponible.Text = $"Base: {baseImponible:N2}"
'        lblIva.Text = $"IVA ({ivaPorcentaje}%): {iva:N2}"
'        lblTotalGeneral.Text = $"Total: {totalGeneral:N2}"

'        RaiseEvent TotalActualizado(totalExento, baseImponible, iva, totalGeneral)
'    End Sub

'#End Region

'#Region "Eventos de Fila"

'    Private Sub EliminarFila(sender As Object, e As DataGridViewCellEventArgs)
'        If dgv.Columns(e.ColumnIndex).Name = "Eliminar" Then
'            dgv.Rows.RemoveAt(e.RowIndex)
'            CalcularTotales()
'        End If
'    End Sub

'    Private Sub ManejarCambioEdicion(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
'        AddHandler CType(e.Control, Control).TextChanged, Sub()
'                                                              CalcularTotales()
'                                                          End Sub
'    End Sub

'#End Region


'    'Private dgv As New DataGridView()
'    'Public Event TotalActualizado(subtotal As Decimal, impuesto As Decimal, totalFinal As Decimal)

'    'Public Sub New()
'    '    InitializeComponent()
'    '    Inicializar()
'    'End Sub

'    'Public Sub Inicializar()
'    '    dgv.Dock = DockStyle.Fill
'    '    dgv.AllowUserToAddRows = False
'    '    dgv.Columns.Clear()

'    '    dgv.Columns.Add("Producto", "Producto")

'    '    ' Cantidad con NumericUpDown
'    '    Dim colCantidad As New DataGridViewNumericUpDownColumn() With {
'    '        .Name = "Cantidad",
'    '        .HeaderText = "Cantidad",
'    '        .Width = 90
'    '    }
'    '    dgv.Columns.Add(colCantidad)

'    '    dgv.Columns.Add("CostoUnitario", "Costo Unitario")
'    '    dgv.Columns.Add("Subtotal", "Subtotal")

'    '    ' Columna ícono eliminar
'    '    Dim colEliminar As New DataGridViewImageColumn() With {
'    '        .Name = "Eliminar",
'    '        .HeaderText = "",
'    '        .Image = IconCharToBitmap(IconChar.TrashAlt, Color.Firebrick, 18),
'    '        .Width = 40
'    '    }
'    '    dgv.Columns.Add(colEliminar)

'    '    AplicarEstiloVisual()
'    '    Me.Controls.Add(dgv)

'    '    AddHandler dgv.CellValueChanged, AddressOf CalcularTotales
'    '    AddHandler dgv.CellClick, AddressOf EliminarFila
'    'End Sub

'    'Private Sub AplicarEstiloVisual()
'    '    Dim tipo As Type = dgv.GetType()
'    '    Dim prop = tipo.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
'    '    If prop IsNot Nothing Then prop.SetValue(dgv, True, Nothing)

'    '    dgv.EnableHeadersVisualStyles = False
'    '    dgv.ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
'    '        .BackColor = Color.FromArgb(220, 240, 255),
'    '        .ForeColor = Color.FromArgb(45, 45, 45),
'    '        .Font = New Font("Century Gothic", 10, FontStyle.Bold),
'    '        .Alignment = DataGridViewContentAlignment.MiddleLeft,
'    '        .Padding = New Padding(6, 10, 6, 10)
'    '    }

'    '    dgv.DefaultCellStyle = New DataGridViewCellStyle With {
'    '        .Font = New Font("Century Gothic", 10),
'    '        .ForeColor = Color.Black,
'    '        .BackColor = Color.White,
'    '        .SelectionBackColor = Color.LightSteelBlue,
'    '        .SelectionForeColor = Color.Black,
'    '        .Padding = New Padding(3)
'    '    }

'    '    dgv.RowTemplate.Height = 29
'    '    dgv.GridColor = Color.LightBlue
'    '    dgv.BorderStyle = BorderStyle.None
'    '    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
'    '    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
'    '    dgv.ColumnHeadersHeight = 38
'    'End Sub

'    'Private Function IconCharToBitmap(icono As IconChar, color As Color, size As Integer) As Bitmap
'    '    Dim bmp As New Bitmap(size, size)
'    '    Using g As Graphics = Graphics.FromImage(bmp)
'    '        Dim icon As New IconPictureBox With {
'    '            .IconChar = icono,
'    '            .IconColor = color,
'    '            .BackColor = Color.Transparent,
'    '            .IconSize = size,
'    '            .Size = New Size(size, size)
'    '        }
'    '        icon.DrawToBitmap(bmp, New Rectangle(Point.Empty, bmp.Size))
'    '    End Using
'    '    Return bmp
'    'End Function

'    'Public Sub AgregarProducto(productoID As Integer, nombre As String, costo As Decimal)
'    '    Dim filaIndex As Integer = dgv.Rows.Add(nombre, 1D, costo, costo, Nothing)
'    '    dgv.Rows(filaIndex).Cells("Producto").Tag = productoID
'    '    CalcularTotales()
'    'End Sub

'    'Private Sub EliminarFila(sender As Object, e As DataGridViewCellEventArgs)
'    '    If e.RowIndex >= 0 AndAlso dgv.Columns(e.ColumnIndex).Name = "Eliminar" Then
'    '        dgv.Rows.RemoveAt(e.RowIndex)
'    '        CalcularTotales()
'    '    End If
'    'End Sub

'    'Private Sub CalcularTotales()
'    '    For Each fila As DataGridViewRow In dgv.Rows
'    '        Dim cantidad As Decimal = 0
'    '        Dim costo As Decimal = 0

'    '        Decimal.TryParse(fila.Cells("Cantidad").Value?.ToString(), cantidad)
'    '        Decimal.TryParse(fila.Cells("CostoUnitario").Value?.ToString(), costo)

'    '        fila.Cells("Subtotal").Value = cantidad * costo
'    '    Next

'    '    Dim subtotal = CalcularTotal()
'    '    Dim impuesto = subtotal * 0.13D
'    '    Dim total = subtotal + impuesto
'    '    RaiseEvent TotalActualizado(subtotal, impuesto, total)
'    'End Sub

'    'Public Function CalcularTotal() As Decimal
'    '    Dim total As Decimal = 0
'    '    For Each fila As DataGridViewRow In dgv.Rows
'    '        Dim subtotal As Decimal = 0
'    '        Decimal.TryParse(fila.Cells("Subtotal").Value?.ToString(), subtotal)
'    '        total += subtotal
'    '    Next
'    '    Return total
'    'End Function

'    'Public Function ObtenerDetalle() As List(Of TDetalleCompra)
'    '    Dim lista As New List(Of TDetalleCompra)
'    '    For Each fila As DataGridViewRow In dgv.Rows
'    '        Dim detalle As New TDetalleCompra With {
'    '            .ProductoID = Convert.ToInt32(fila.Cells("Producto").Tag),
'    '            .Cantidad = Convert.ToInt32(fila.Cells("Cantidad").Value),
'    '            .CostoUnitario = Convert.ToDecimal(fila.Cells("CostoUnitario").Value),
'    '            .Subtotal = Convert.ToDecimal(fila.Cells("Subtotal").Value),
'    '            .ModoCargo = "Ex"
'    '        }
'    '        lista.Add(detalle)
'    '    Next
'    '    Return lista
'    'End Function

'End Class


'' ================================================
''  NumericUpDown personalizado para DataGridView
'' ================================================
'Public Class DataGridViewNumericUpDownCell
'    Inherits DataGridViewTextBoxCell

'    Public Sub New()
'        Me.Style.Format = "N0"
'    End Sub

'    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
'        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

'        Dim ctl As NumericUpDownEditingControl = CType(DataGridView.EditingControl, NumericUpDownEditingControl)
'        Dim valor As Object = Me.Value

'        If valor Is Nothing OrElse Not IsNumeric(valor) Then
'            ctl.Value = 1
'        Else
'            ctl.Value = Math.Max(Convert.ToDecimal(valor), ctl.Minimum)
'        End If
'    End Sub

'    Public Overrides ReadOnly Property EditType As Type
'        Get
'            Return GetType(NumericUpDownEditingControl)
'        End Get
'    End Property

'    Public Overrides ReadOnly Property ValueType As Type
'        Get
'            Return GetType(Decimal)
'        End Get
'    End Property

'    Public Overrides ReadOnly Property DefaultNewRowValue As Object
'        Get
'            Return 1D
'        End Get
'    End Property
'End Class

'Public Class DataGridViewNumericUpDownColumn
'    Inherits DataGridViewColumn

'    Public Sub New()
'        MyBase.New(New DataGridViewNumericUpDownCell())
'    End Sub
'End Class

'Public Class NumericUpDownEditingControl
'    Inherits NumericUpDown
'    Implements IDataGridViewEditingControl

'    Private dataGridViewControl As DataGridView
'    Private valueIsChanged As Boolean = False
'    Private rowIndexNum As Integer

'    Public Sub New()
'        Me.Minimum = 1
'        Me.Maximum = 1000
'        Me.DecimalPlaces = 0
'    End Sub

'    Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
'        Get
'            Return Me.Value.ToString("N0")
'        End Get
'        Set(value As Object)
'            If TypeOf value Is String Then
'                Dim v As Decimal
'                If Decimal.TryParse(value, v) Then
'                    Me.Value = v
'                End If
'            End If
'        End Set
'    End Property

'    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
'        Return Me.Value.ToString("N0")
'    End Function

'    Public Sub ApplyCellStyleToEditingControl(cellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
'        Me.Font = cellStyle.Font
'        Me.ForeColor = cellStyle.ForeColor
'        Me.BackColor = cellStyle.BackColor
'    End Sub

'    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
'        Get
'            Return rowIndexNum
'        End Get
'        Set(value As Integer)
'            rowIndexNum = value
'        End Set
'    End Property

'    Public Function EditingControlWantsInputKey(key As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
'        Return True
'    End Function

'    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
'    End Sub

'    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
'        Get
'            Return False
'        End Get
'    End Property

'    Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
'        Get
'            Return dataGridViewControl
'        End Get
'        Set(value As DataGridView)
'            dataGridViewControl = value
'        End Set
'    End Property

'    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
'        Get
'            Return valueIsChanged
'        End Get
'        Set(value As Boolean)
'            Me.valueIsChanged = valueIsChanged
'        End Set
'    End Property

'    Public ReadOnly Property EditingControlCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
'        Get
'            Return MyBase.Cursor
'        End Get
'    End Property
'End Class
