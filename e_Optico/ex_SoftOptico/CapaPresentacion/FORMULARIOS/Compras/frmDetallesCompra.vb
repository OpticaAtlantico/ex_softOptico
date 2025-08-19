Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Public Class frmDetallesCompra
    Public Property FormularioDestino As frmCompras
    Private WithEvents productosGrid As New DataGridViewGUI()
    Public idCompra As Integer

#Region "Drag Form"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub

    Private Sub pnlMove_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlMove.MouseMove
        MoverFormulario()
    End Sub

#End Region

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormStylerUI.Apply(Me)

        ' Agregar cualquier inicialización después de la llamada a InitializeComponent().
        productosGrid = New DataGridViewGUI()

    End Sub

    Private Sub MoverFormulario()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub Componentes()
        Me.MinimumSize = New Size(900, 600)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White
        Me.MaximumSize = New Size(1000, 700)
        Me.StartPosition = FormStartPosition.CenterScreen

        productosGrid.Titulo = "DETALLE DE COMPRA"
        productosGrid.Subtitulo = "Listado de productos comprados..."
        productosGrid.Icono = IconChar.ShoppingCart

        With productosGrid.btnEnviar
            .Visible = True
            .Texto = "Salir..."
            '.BackColor = Color.FromArgb(57, 103, 208)
            .ForeColor = Color.White
            .Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .Cursor = Cursors.Hand
            .Icono = IconChar.DoorOpen
        End With

        AddHandler productosGrid.btnEnviar.Click, Sub()
                                                      FadeManagerUI.ApplyOut(Me, 60)
                                                  End Sub
    End Sub

    Private Sub frmListarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepararControl()
        Componentes()
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

    Private Sub PrepararControl()
        productosGrid.Dock = DockStyle.Fill

        ' Repositorio
        Dim repo As New Repositorio_Compra()

        Dim listaProductos As List(Of VDetalleCompras) = repo.GetDetalle(idCompra)
        Dim tabla As DataTable = ConvertirListaADataTable(listaProductos)

        ' Configurar columnas y cargar
        Dim columnasVisibles = {"Descripcion", "Cantidad", "ModoCargo", "CostoUnitario", "Subtotal"}
        Dim anchos = New Dictionary(Of String, Integer) From {
        {"Descripcion", 400},
        {"Cantidad", 100},
        {"ModoCargo", 150},
        {"CostoUnitario", 150},
        {"Subtotal", 150}
    }
        Dim nombresColumnas = New Dictionary(Of String, String) From {
        {"Descripcion", "Descripción"},
        {"Cantidad", "Cantidad"},
        {"ModoCargo", "Ex/G"},
        {"CostoUnitario", "Precio"},
        {"Subtotal", "Total"}
    }

        productosGrid.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombresColumnas)
        productosGrid.MetodoCargaDatos = Function() tabla
        productosGrid.CargarDatos(tabla)

        Me.pnlContenedor.Controls.Add(productosGrid)

    End Sub


End Class
