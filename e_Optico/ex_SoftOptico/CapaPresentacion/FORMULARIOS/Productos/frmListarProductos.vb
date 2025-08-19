Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Public Class frmListarProductos
    Public Property FormularioDestino As frmCompras
    Private WithEvents productosGrid As New DataGridViewGUI()

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormStylerUI.Apply(Me)
        ' Agregar cualquier inicialización después de la llamada a InitializeComponent().
        productosGrid = New DataGridViewGUI()
    End Sub

    Private Sub frmListarProducto_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        ' Limpiar el formulario destino al cerrar
        If FormularioDestino IsNot Nothing Then
            FormularioDestino = Nothing
        End If
    End Sub

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
        productosGrid.Subtitulo = "Seleccione un producto para agregar al detalle de la compra"
        productosGrid.Icono = IconChar.ShoppingCart
    End Sub

    Private Sub frmListarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararControl()
        Componentes()
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

    Private Sub PrepararControl()
        productosGrid.Dock = DockStyle.Fill

        ' Repositorio
        Dim repo As New Repositorio_VProductos()

        Dim listaProductos As List(Of TVProductos) = repo.GetAll()
        Dim tabla As DataTable = ConvertirListaADataTable(listaProductos)

        ' Configurar columnas y cargar
        Dim columnasVisibles = {"Codigo", "Nombre", "Stock", "Categoria", "SubCategoria", "Precio"}
        Dim anchos = New Dictionary(Of String, Integer) From {
        {"Codigo", 100},
        {"Nombre", 280},
        {"Stock", 80},
        {"Categoria", 150},
        {"SubCategoria", 150},
        {"Precio", 120}
    }
        Dim nombresColumnas = New Dictionary(Of String, String) From {
        {"Codigo", "Código"},
        {"Nombre", "Descripción"},
        {"Stock", "Stock"},
        {"Categoria", "Categoría"},
        {"SubCategoria", "Subcategoría"},
        {"Precio", "Precio Venta"}
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

            Dim idCategoria As Integer = Convert.ToInt32(producto("CategoriaID"))
            Dim ExG As String = "Ex"

            If idCategoria = 2 Then
                ExG = "G"
            End If

            Dim seleccionado As New ProductoSeleccionado With {
            .Codigo = Convert.ToString(producto("Codigo")),
            .Nombre = producto("Nombre").ToString(),
            .Precio = 0,
            .ExG = ExG
        }

            FormularioDestino.AgregarProductoAlDetalle(seleccionado)
            FadeManagerUI.ApplyOut(Me, 60)
        End If
    End Sub
End Class
