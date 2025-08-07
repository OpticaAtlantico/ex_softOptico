Imports CapaEntidad

Public Class frmCompras

    Private grvCompras As New DataGridComprasUI()

    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar configuración del DataGridComprasUI
        grvCompras.Dock = DockStyle.Fill
        grvCompras.IvaPorcentaje = 16D ' IVA por defecto si aplica
        grvCompras.Inicializar()

        ' Inicializar con lista vacía
        grvCompras.CargarDatos(New List(Of ProductoSeleccionado)())

        ' Suscribir evento de totales
        AddHandler grvCompras.TotalActualizado, AddressOf ActualizarEtiquetasTotales

        ' Limpiar el panel contenedor
        pnlDataGrid.Controls.Clear()

        ' Agregar al panel contenedor
        pnlDataGrid.Controls.Add(grvCompras)
        grvCompras.BringToFront()
    End Sub

    Private Sub ActualizarEtiquetasTotales(totalExento As Decimal, baseImponible As Decimal, iva As Decimal, totalGeneral As Decimal)
        ' Aquí puedes actualizar labels o campos fuera del control
        lblExento.Text = totalExento.ToString("N2")
        lblBaseImponible.Text = baseImponible.ToString("N2")
        lblIva.Text = iva.ToString("N2")
        lblTotalGeneral.Text = totalGeneral.ToString("N2")
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Dim frmLista As New frmListarProductos
        frmLista.FormularioDestino = Me
        frmLista.ShowDialog()

    End Sub

    ' Método para agregar un producto desde otro formulario
    Public Sub AgregarProductoAlDetalle(producto As ProductoSeleccionado)
        grvCompras.AgregarProducto(
            producto.Codigo,
            producto.Nombre,
            producto.ExG,
            producto.Precio
        )
    End Sub


End Class

























' Formulario de compras que usa DataGridViewGUI para seleccionar productos
'Public Class frmCompras

'    Private WithEvents grvCompras As New DataGridComprasUI()
'    Private lblSubtotal, lblImpuesto, lblTotal As Label
'    Private btnAgregarProducto As Button

'    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Me.Text = "Nueva Compra"
'        Me.Size = New Size(800, 600)
'        Me.BackColor = Color.White

'        PrepararControles()
'    End Sub

'    Private Sub PrepararControles()
'        ' 🔷 Botón para agregar productos
'        btnAgregarProducto = New Button With {
'            .Text = "Agregar Producto",
'            .Width = 150,
'            .Height = 35,
'            .Top = 10,
'            .Left = 10
'        }
'        AddHandler btnAgregarProducto.Click, AddressOf AbrirFormularioProductos

'        ' 🔷 Labels de totales
'        lblSubtotal = CrearLabel("Subtotal: 0.00", 600, 10)
'        lblImpuesto = CrearLabel("Impuesto: 0.00", 600, 40)
'        lblTotal = CrearLabel("Total: 0.00", 600, 70)

'        ' 🔷 DataGridComprasUI
'        grvCompras.Dock = DockStyle.Fill
'        grvCompras.Top = 100
'        grvCompras.Left = 10

'        ' 🔷 Panel contenedor
'        Dim panelTop As New Panel With {.Height = 100, .Dock = DockStyle.Top}
'        panelTop.Controls.AddRange({btnAgregarProducto, lblSubtotal, lblImpuesto, lblTotal})

'        ' 🔷 Agregar al formulario
'        Me.pnlContenedorGrid.Controls.Add(grvCompras)
'        Me.pnlContenedorGrid.Controls.Add(panelTop)
'    End Sub

'    Private Function CrearLabel(texto As String, x As Integer, y As Integer) As Label
'        Return New Label With {
'            .Text = texto,
'            .AutoSize = True,
'            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
'            .Left = x,
'            .Top = y
'        }
'    End Function

'    ' 🔁 Evento desde el UserControl cuando cambian los totales
'    Private Sub grvCompras_TotalActualizado(subtotal As Decimal, impuesto As Decimal, totalFinal As Decimal) Handles grvCompras.TotalActualizado
'        lblSubtotal.Text = $"Subtotal: {subtotal:N2}"
'        lblImpuesto.Text = $"Impuesto: {impuesto:N2}"
'        lblTotal.Text = $"Total: {totalFinal:N2}"
'    End Sub

'    ' 🔍 Abrir formulario de productos
'    Private Sub AbrirFormularioProductos(sender As Object, e As EventArgs)
'        Dim formProductos As New frmListarProductos()
'        formProductos.FormularioDestino = Me
'        formProductos.ShowDialog()

'    End Sub

'    ' ✅ Método para que frmListarProducto pueda agregar un producto
'    Public Sub AgregarProductoAlDetalle(producto As DataRow)
'        Dim id As Integer = Convert.ToInt32(producto("Codigo")) ' Ajusta según tu DataTable
'        Dim nombre As String = producto("Nombre").ToString()
'        Dim precio As Decimal = Convert.ToDecimal(producto("Precio"))

'        grvCompras.AgregarProducto(id, nombre, precio)
'    End Sub

'End Class






' Suponiendo que este control está en el formulario
'Private WithEvents productosGrid As New DataGridViewGUI()

'' Grid donde se agregan los productos seleccionados
'Private dgvDetalleCompra As New DataGridView()

'Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'    PrepararGrillaDetalle()
'    PrepararGrillaProductos()
'End Sub

'Private Sub PrepararGrillaDetalle()
'    dgvDetalleCompra.Dock = DockStyle.Bottom
'    dgvDetalleCompra.Height = 250
'    dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
'    dgvDetalleCompra.AllowUserToAddRows = False
'    dgvDetalleCompra.RowHeadersVisible = False

'    dgvDetalleCompra.Columns.Add("Codigo", "Código")
'    dgvDetalleCompra.Columns.Add("Descripcion", "Descripción")
'    dgvDetalleCompra.Columns.Add("Precio", "Precio Unit.")
'    dgvDetalleCompra.Columns.Add("Cantidad", "Cantidad")
'    dgvDetalleCompra.Columns.Add("Subtotal", "Subtotal")

'    Me.pnlContenedorGrid.Controls.Add(dgvDetalleCompra)
'End Sub

'Private Sub PrepararGrillaProductos()
'    productosGrid.Dock = DockStyle.Fill
'    AddHandler productosGrid.ProductoSeleccionado, AddressOf AgregarProductoAlDetalle

'    ' Simulamos una carga de productos
'    productosGrid.MetodoCargaDatos = Function()
'                                         Dim tabla As New DataTable()
'                                         tabla.Columns.Add("Codigo")
'                                         tabla.Columns.Add("Descripcion")
'                                         tabla.Columns.Add("PrecioVenta", GetType(Decimal))

'                                         tabla.Rows.Add("P001", "Producto 1", 12.5D)
'                                         tabla.Rows.Add("P002", "Producto 2", 18D)
'                                         tabla.Rows.Add("P003", "Producto 3", 9.99D)
'                                         Return tabla
'                                     End Function

'    productosGrid.RefrescarTodo()
'    Me.Controls.Add(productosGrid)
'End Sub

'Public Sub AgregarProductoAlDetalle(producto As DataRow)
'    If producto Is Nothing Then Exit Sub

'    Dim codigo = producto("Codigo").ToString()
'    Dim descripcion = producto("Descripcion").ToString()
'    Dim precio = Convert.ToDecimal(producto("PrecioVenta"))

'    ' Validar si ya fue agregado
'    For Each fila As DataGridViewRow In dgvDetalleCompra.Rows
'        If fila.Cells("Codigo").Value?.ToString() = codigo Then
'            fila.Cells("Cantidad").Value = CInt(fila.Cells("Cantidad").Value) + 1
'            fila.Cells("Subtotal").Value = precio * CInt(fila.Cells("Cantidad").Value)
'            Return
'        End If
'    Next

'    ' Si no existe, agregar nuevo
'    Dim index As Integer = dgvDetalleCompra.Rows.Add()
'    dgvDetalleCompra.Rows(index).Cells("Codigo").Value = codigo
'    dgvDetalleCompra.Rows(index).Cells("Descripcion").Value = descripcion
'    dgvDetalleCompra.Rows(index).Cells("Precio").Value = precio
'    dgvDetalleCompra.Rows(index).Cells("Cantidad").Value = 1
'    dgvDetalleCompra.Rows(index).Cells("Subtotal").Value = precio
'End Sub


