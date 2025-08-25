Imports System.ComponentModel
Imports CapaEntidad

Public Class DataGridViewProveedorUI
    Inherits UserControl

#Region "Campos"

    Private dgv As New DataGridView()

#End Region

#Region "Eventos"


#End Region

#Region "Propiedades"

    ''' <summary>
    ''' IVA % (Ejemplo: 13)
    ''' </summary>

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
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        PrepararEstiloVisual()

        ' Asegúrate de estar limpiando las columnas antes de volver a agregarlas
        If dgv.Columns.Count > 0 Then
            dgv.Columns.Clear()
        End If

        ' Luego define y agrega tus columnas con los anchos deseados
        Dim colItem As New DataGridViewTextBoxColumn With {
            .Name = "Item",
            .HeaderText = "Item",
            .ReadOnly = True,
            .Width = 60,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim colCodigo As New DataGridViewTextBoxColumn With {
            .Name = "Codigo",
            .HeaderText = "Codigo",
            .Width = 130,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim colDescripcion As New DataGridViewTextBoxColumn With {
            .Name = "Descripcion",
            .HeaderText = "Descripción",
            .Width = 500,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        Dim btnEliminar As New DataGridViewButtonColumn With {
            .Name = "Eliminar",
            .Text = "🗑",
            .UseColumnTextForButtonValue = True,
            .Width = 80,
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        }

        dgv.Columns.AddRange({colItem, colCodigo, colDescripcion, btnEliminar})

        ' Eventos
        AddHandler dgv.CellClick, AddressOf EliminarFila

        ' Agregar al control
        Me.Controls.Add(dgv)
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
            .Padding = New Padding(6, 4, 6, 4),
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

#End Region

#Region "Métodos Públicos"

    Public Sub AgregarProducto(productoID As Integer, nombre As String, exG As String, precio As Decimal, descuento As Decimal)
        dgv.Rows.Add(nombre, 1, exG, precio, descuento, precio)
        dgv.Rows(dgv.Rows.Count - 1).Cells("Producto").Tag = productoID
    End Sub

    Public Function GetDetalleList() As List(Of TDetalleCompra)
        Dim lista As New List(Of TDetalleCompra)

        For Each row As DataGridViewRow In dgv.Rows
            If row.IsNewRow Then Continue For

            Dim detalle As New TDetalleCompra()

            detalle.ProductoID = Convert.ToInt32(row.Cells("Producto").Tag)
            detalle.Cantidad = Convert.ToDecimal(row.Cells("Cantidad").Value)
            detalle.PrecioUnitario = Convert.ToDecimal(row.Cells("Precio").Value)
            detalle.Descuento = Convert.ToDecimal(row.Cells("Descuento").Value)
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
            producto.Descuento,
            producto.Total
        )
        Next

    End Sub

    Public Sub LimpiarGrid()
        dgv.Rows.Clear()
    End Sub

#End Region


#Region "Eventos de Fila"

    Private Sub EliminarFila(sender As Object, e As DataGridViewCellEventArgs)
        If dgv.Columns(e.ColumnIndex).Name = "Eliminar" Then
            dgv.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

#End Region

End Class

