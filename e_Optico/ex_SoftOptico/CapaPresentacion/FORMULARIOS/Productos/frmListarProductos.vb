Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Public Class frmListarProductos
    Public Property FormularioDestino As frmCompras
    Private WithEvents productosGrid As New DataGridViewGUI()

#Region "CONSTRUCTOR"
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormStylerUI.Apply(Me)
        ' Agregar cualquier inicialización después de la llamada a InitializeComponent().
        productosGrid = New DataGridViewGUI()
    End Sub

#End Region

#Region "CONTROLES Y FORMULARIOS"
    Private Sub frmListarProducto_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        ' Limpiar el formulario destino al cerrar
        If FormularioDestino IsNot Nothing Then
            FormularioDestino = Nothing
        End If
    End Sub

    Private Sub frmListarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararControl()
        Componentes()
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub
#End Region

#Region "PROCEDIMIENTOS"
    Private Sub Componentes()
        Me.Text = "Listado de Productos"
        Me.MinimumSize = New Size(900, 600)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.BackColor = Color.White
        Me.MaximumSize = New Size(1000, 700)
        Me.StartPosition = FormStartPosition.CenterScreen

        productosGrid.Titulo = "LISTADO DE PRODUCTOS GENERAL"
        productosGrid.Subtitulo = "Seleccione un producto para ser agregado al detalle de compra"
        productosGrid.Icono = IconChar.ShoppingCart
    End Sub

    Private Sub PrepararControl()
        productosGrid.Dock = DockStyle.Fill

        ' Repositorio
        Dim repo As New Repositorio_Productos()

        Dim listaProductos As List(Of VProductos) = repo.GetAll()
        Dim tabla As DataTable = ConvertirListaADataTable(listaProductos)

        ' Configurar columnas y cargar
        Dim columnasVisibles = {"_codigo", "_nombre", "_categoria", "_subCategoria", "_stock"}
        Dim anchos = New Dictionary(Of String, Integer) From {
        {"_codigo", 70},
        {"_nombre", 380},
        {"_categoria", 180},
        {"_subCategoria", 180},
        {"_stock", 100}
    }
        Dim nombresColumnas = New Dictionary(Of String, String) From {
        {"_sodigo", "Código"},
        {"_nombre", "Descripción"},
        {"_categoria", "Categoría"},
        {"_subCategoria", "Subcategoría"},
        {"_stock", "Stock"}
    }

        productosGrid.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombresColumnas)
        productosGrid.MetodoCargaDatos = Function() tabla
        productosGrid.CargarDatos(tabla)

        AddHandler productosGrid.ProductoSeleccionado, AddressOf ProductoSeleccionado
        Me.Controls.Add(productosGrid)
    End Sub

    Private Sub ProductoSeleccionado(producto As DataRow)
        If FormularioDestino IsNot Nothing Then
            ' Crear objeto limpio

            Dim idCategoria As Integer = Convert.ToInt32(producto("_categoriaID"))
            Dim ExG As String = "Ex"

            If idCategoria = 2 Then
                ExG = "G"
            End If

            Dim seleccionado As New ProductoSeleccionado With {
            .Codigo = Convert.ToString(producto("_codigo")),
            .Nombre = producto("_nombre").ToString(),
            .Precio = 0,
            .ExG = ExG
        }

            FormularioDestino.AgregarProductoAlDetalle(seleccionado)
            FadeManagerUI.ApplyOut(Me, 60)
        End If
    End Sub

#End Region

End Class
