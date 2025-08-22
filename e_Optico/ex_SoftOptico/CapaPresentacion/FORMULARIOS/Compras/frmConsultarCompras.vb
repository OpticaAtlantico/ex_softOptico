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
        FormStylerUI.Apply(Me)

        With Me.dgvCompras.lblTitulo
            .Titulo = "Consulta de Compras"
            .Subtitulo = "Listado de compras realizadas"
            .ForeColor = Color.FromArgb(57, 103, 208)
            .ColorTexto = Color.FromArgb(57, 103, 208)
            .Icono = IconChar.ShoppingCart
        End With

        'Cambirle los iconos de acciones del DataGridView
        dgvCompras.IconosPorAccion("Agregar") = IconChar.EyeLowVision
        dgvCompras.IconosPorAccion("Editar") = IconChar.Pen
        dgvCompras.IconosPorAccion("Eliminar") = IconChar.TrashAlt

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
        AddHandler dgvCompras.BNuevo.Click, Sub()
                                                AgregarNuevaCompra()
                                            End Sub
        AddHandler dgvCompras.EditarRegistro, AddressOf EditarCompra
        AddHandler dgvCompras.EliminarRegistro, AddressOf EliminarCompraUnico
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

        Dim columnasVisibles = {"_ordenCompra", "_fecha", "_nControl", "_nFactura", "_sucursal", "_proveedor", "_tPago", "_subTotal"}
        Dim anchos = New Dictionary(Of String, Integer) From {
            {"_ordenCompra", 100},
            {"_fecha", 180},
            {"_nControl", 200},
            {"_nFactura", 200},
            {"_sucursal", 300},
            {"_proveedor", 300},
            {"_tPago", 250},
            {"_subTotal", 120}
        }
        Dim nombres = New Dictionary(Of String, String) From {
            {"_ordenCompra", "# Orden"},
            {"_fecha", "Fecha de Compra"},
            {"_nControl", "N° Control"},
            {"_nFactura", "N° Factura"},
            {"_sucursal", "Sucursal"},
            {"_proveedor", "Proveedor"},
            {"_tPago", "Tipo de Pago"},
            {"_subTotal", "Subtotal"}
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

    Private Sub AgregarNuevaCompra()
        Dim frm As New frmCompras()
        Me.Close()
        RaiseEvent AbrirFormularioHijo(frm)
    End Sub

    Private Sub EditarCompra(id As Integer)
        Try
            Dim repositorio As New Repositorio_Compra()
            Dim CompraEncontrado As VCompras = repositorio.GetById(id)

            If CompraEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmCompras()
                formularioHijo.DatosCompra = CompraEncontrado
                formularioHijo.NombreBoton = "Actualizar..."

                ' En vez de abrir el formulario directamente, disparar evento
                RaiseEvent AbrirFormularioHijo(formularioHijo)
            Else
                MessageBoxUI.Mostrar("Búsqueda fallida...", "No se pudo localizar los datos del proveedor seleccionado, por favor verifique que los datos sean correctos", TipoMensaje.Informacion, Botones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error de edición...", "Error al intentar editar el proveedor" & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

    Private Sub EliminarCompraUnico(id As Integer)
        Try
            Dim confirmar = MessageBoxUI.Mostrar("Remover datos...", "¿Deseas eliminar la compra seleccionada?", TipoMensaje.Advertencia, Botones.SiNo)

            If confirmar = DialogResult.No Then Exit Sub

            Dim repositorio As New Repositorio_Compra()
            Dim compra As VCompras = repositorio.GetById(id)

            If compra Is Nothing Then
                MessageBoxUI.Mostrar("Buscando...", "No se encontró la compra.", TipoMensaje.Errors, Botones.Aceptar)
                Exit Sub
            End If

            Dim eliminar = repositorio.Remove(id)

            If eliminar Then
                MessageBoxUI.Mostrar("Éxito", "Proveedor eliminado correctamente.", TipoMensaje.Exito, Botones.Aceptar)
                CargarDatosCompras()
            Else
                MessageBoxUI.Mostrar("Error al eliminar", "No se pudo eliminar el proveedor.", TipoMensaje.Errors, Botones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar("Error... ", "Error al eliminar proveedor" & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

#Region "FUNCIONES"
    Private Function ObtenerCompras() As DataTable
        Dim lista = repositorioCompra.GetAll().ToList()
        Return ConvertirListaADataTable(lista)
    End Function
#End Region

End Class