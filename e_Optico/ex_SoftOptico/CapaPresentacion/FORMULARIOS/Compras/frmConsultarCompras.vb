Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frmConsultarCompras

    Public Event AbrirFormularioHijo As Action(Of Form)
    Private layoutOrbital As DataGridViewUI
    Private ReadOnly repositorioCompra As IRepositorio_Compra = New Repositorio_Compra()

#Region "CONSTRUCTOR"
    Public Sub New()
        InitializeComponent()
        FadeManagerUI.ShowWithFade(Me, 0.2)

        With Me.dgvCompras.lblTitulo
            .Titulo = "Consulta de Compras"
            .Subtitulo = "Listado de compras realizadas"
            .ForeColor = Color.FromArgb(57, 103, 208)
            .ColorTexto = Color.FromArgb(57, 103, 208)
            .Icono = IconChar.ShoppingCart
        End With

        CargarDatosCompras()
    End Sub
#End Region

#Region "EVENTOS DEL FORMULARIO"
    Private Sub frmConsultaCompras_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler AbrirFormularioHijo, AddressOf frm_Principal.SolicitarAbrirFormularioHijo

        dgvCompras.MetodoCargaDatos = AddressOf ObtenerCompras
        dgvCompras.RefrescarTodo()

        AddHandler dgvCompras.BExportarGrid.Click, Sub()
                                                       ExcelExportManagerUI.ExportarDesdeGridEstilizado(dgvCompras.GrvOrbital, "Compras")
                                                   End Sub
    End Sub
#End Region

#Region "PROCEDIMIENTOS"

    Private Sub CargarDatosCompras()
        dgvCompras.DataOriginal = Nothing
        dgvCompras.DataCompleta = Nothing
        dgvCompras.Grid.Rows.Clear()
        dgvCompras.Grid.Columns.Clear()

        Dim listaCompras = repositorioCompra.GetAll().ToList()
        Dim tabla = ConvertirListaADataTable(listaCompras)

        Dim columnasVisibles = {"CompraID", "Fecha", "NControl", "NFactura", "Sucursal", "Proveedor", "TPago", "SubTotal"}
        Dim anchos = New Dictionary(Of String, Integer) From {
            {"CompraID", 80},
            {"Fecha", 120},
            {"NControl", 100},
            {"NFactura", 100},
            {"Sucursal", 150},
            {"Proveedor", 200},
            {"TPago", 120},
            {"SubTotal", 100}
        }
        Dim nombres = New Dictionary(Of String, String) From {
            {"CompraID", "ID"},
            {"Fecha", "Fecha de Compra"},
            {"NControl", "N° Control"},
            {"NFactura", "N° Factura"},
            {"Sucursal", "Sucursal"},
            {"Proveedor", "Proveedor"},
            {"TPago", "Tipo de Pago"},
            {"SubTotal", "Subtotal"}
        }

        dgvCompras.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombres)
        AgregarColumnasBotonesSiFaltan()
        AgregarToolTipsBotones()
        dgvCompras.CargarDatos(tabla)
        dgvCompras.Grid.Refresh()
    End Sub

    Private Sub AgregarToolTipsBotones()
        Dim dgv = dgvCompras.GrvOrbital
        dgv.Columns("Agregar").ToolTipText = "Ver detalle de compra"
        dgv.Columns("Editar").ToolTipText = "Editar compra"
        dgv.Columns("Eliminar").ToolTipText = "Eliminar compra"
    End Sub

    Private Sub AgregarColumnasBotonesSiFaltan()
        Dim dgv = dgvCompras.GrvOrbital

        If Not dgv.Columns.Contains("Agregar") Then
            Dim colAgregar As New DataGridViewImageColumn With {
                .Name = "Agregar", .HeaderText = "", .Width = 35,
                .ImageLayout = DataGridViewImageCellLayout.Zoom, .Frozen = True
            }
            dgv.Columns.Insert(0, colAgregar)
            colAgregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If Not dgv.Columns.Contains("Editar") Then
            Dim colEditar As New DataGridViewImageColumn With {
                .Name = "Editar", .HeaderText = "", .Width = 35,
                .ImageLayout = DataGridViewImageCellLayout.Zoom, .Frozen = True
            }
            dgv.Columns.Insert(1, colEditar)
            colEditar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If Not dgv.Columns.Contains("Eliminar") Then
            Dim colEliminar As New DataGridViewImageColumn With {
                .Name = "Eliminar", .HeaderText = "", .Width = 35,
                .ImageLayout = DataGridViewImageCellLayout.Zoom, .Frozen = True
            }
            dgv.Columns.Insert(2, colEliminar)
            colEliminar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

#End Region

#Region "FUNCIONES"
    Private Function ObtenerCompras() As DataTable
        Dim lista = repositorioCompra.GetAll().ToList()
        Return ConvertirListaADataTable(lista)
    End Function
#End Region

End Class