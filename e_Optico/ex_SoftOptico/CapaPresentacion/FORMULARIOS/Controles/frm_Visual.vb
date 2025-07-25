Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Imports Microsoft.Data.SqlClient
Public Class frm_Visual
    Inherits Form

    Private tabPanel As TabPanelUI
    Private WithEvents gridUI As New DataGridViewUI()
    Private Sub frm_Visual_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gridUI.Dock = DockStyle.Fill
        Me.Controls.Add(gridUI)

        CargarDatosDePrueba()

        'Dim toast As New ToastUI()
        'toast.MostrarToast("Guardado exitosamente...", TipoToastUI.Success)

        'MostrarAlerta(Me, AlertType.Success, "¡Bienvenido a la aplicación!")

    End Sub

    Private Sub CargarDatosDesdeSql()
        Dim tabla As New DataTable()

        Using conexion As New SqlConnection("TuConexionSQL")
            conexion.Open()
            Dim cmd As New SqlCommand("SELECT ID, Nombre, Correo, FechaAlta, TotalPagado FROM Empleados", conexion)
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(tabla)
        End Using

        Dim visibles = {"ID", "Nombre", "Correo", "FechaAlta", "TotalPagado", "Mensaje"}
        Dim anchos = New Dictionary(Of String, Integer) From {
        {"ID", 60}, {"Nombre", 200}, {"Correo", 180},
        {"FechaAlta", 100}, {"TotalPagado", 100}
    }
        Dim visuales = New Dictionary(Of String, String) From {
        {"ID", "#"}, {"Nombre", "Nombre completo"},
        {"Correo", "Correo electrónico"}, {"FechaAlta", "Fecha de alta"},
        {"TotalPagado", "Total pagado Bs."}
    }



        gridUI.ConfigurarColumnasVisualesPorTipo(tabla, visibles, anchos, visuales)
        gridUI.CargarDatos(tabla) ' o RefrescarPaginacion(tabla)
    End Sub

    Private Sub CargarDatosDePrueba()
        ' 1. Crear tabla simulada
        Dim tabla As New DataTable()
        tabla.Columns.Add("ID", GetType(Integer))
        tabla.Columns.Add("Nombre", GetType(String))
        tabla.Columns.Add("Correo", GetType(String))
        tabla.Columns.Add("FechaAlta", GetType(DateTime))
        tabla.Columns.Add("TotalPagado", GetType(Decimal))
        tabla.Columns.Add("Mensaje", GetType(String))

        For i = 1 To 25
            tabla.Rows.Add(i, $"Empleado {i}", $"empleado{i}@empresa.com", Date.Today.AddDays(-i), i * 1500, "Hola")
        Next

        Dim colAgregar = New DataGridViewImageColumn() With {
                .Image = IconChar.Plus.ToBitmapPaint(Color.SeaGreen, 18),
                .HeaderText = "",
                .Width = 20,
                .MinimumWidth = 18,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                .Resizable = DataGridViewTriState.False
            }

        Dim colEditar = New DataGridViewImageColumn() With {
                .Image = IconChar.Pen.ToBitmapPaint(Color.SteelBlue, 18),
                .HeaderText = "",
                .Width = 20,
                .MinimumWidth = 18,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                .Resizable = DataGridViewTriState.False
            }

        Dim colEliminar = New DataGridViewImageColumn() With {
                .Image = IconChar.TrashAlt.ToBitmapPaint(Color.Firebrick, 18),
                .HeaderText = "",
                .Width = 20,
                .MinimumWidth = 18,
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                .Resizable = DataGridViewTriState.False
            }

        gridUI.GrvOrbital.Columns.AddRange({colAgregar, colEditar, colEliminar})

        ' 3. Definir columnas visuales
        Dim visibles = {"ID", "Nombre", "Correo", "FechaAlta", "TotalPagado", "Mensaje"}
        Dim anchos = New Dictionary(Of String, Integer) From {
        {"ID", 50}, {"Nombre", 300}, {"Correo", 250}, {"FechaAlta", 150}, {"TotalPagado", 120}, {"Mensaje", 150}
    }
        Dim visuales = New Dictionary(Of String, String) From {
        {"ID", "#"}, {"Nombre", "Nombre completo"},
        {"Correo", "Correo electrónico"},
        {"FechaAlta", "Fecha de alta"},
        {"TotalPagado", "Total pagado Bs."},
        {"Mensaje", "Mensaje pagado"}
    }

        ' 4. Configurar columnas visuales y cargar datos
        gridUI.ConfigurarColumnasVisualesPorTipo(tabla, visibles, anchos, visuales)
        gridUI.CargarDatos(tabla)
    End Sub








    '

    'Me.Controls.Add(gridUI)

    '' Cargar registros simulados
    'Dim dt As New DataTable()
    'dt.Columns.Add("ID", GetType(Integer))
    'dt.Columns.Add("Nombre")
    'dt.Columns.Add("Correo")

    'dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
    'dt.Rows.Add(2, "Sofía Ramos", "sofia@empresa.com")
    'dt.Rows.Add(3, "Julio López", "carlos@empresa.com")
    'dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
    'dt.Rows.Add(2, "Petra Ramos", "sofia@empresa.com")
    'dt.Rows.Add(3, "Cars López", "carlos@empresa.com")
    'dt.Rows.Add(1, "Pedro Duarte", "wilmer@empresa.com")
    'dt.Rows.Add(2, "Sofía Ramos", "sofia@empresa.com")
    'dt.Rows.Add(3, "Marcos López", "carlos@empresa.com")
    'dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
    'dt.Rows.Add(2, "Julia Ramos", "sofia@empresa.com")
    'dt.Rows.Add(3, "Manuel López", "carlos@empresa.com")
    '' Cargar al Grid principal
    'gridUI.CargarDatos(dt)

    '' Actualizar el encabezado visual
    'gridUI.lblTitulo.Titulo = "Wilmer Flores"
    'gridUI.lblTitulo.Subtitulo = "Gestión de usuarios"
    'gridUI.lblTitulo.Icono = IconChar.User


    'AddHandler gridUI.Filtros.TextChanged, Sub()
    '                                           Debug.Print("Filtro activado: " & gridUI.Filtros.TextoFiltrado)
    '                                       End Sub

    'tabPanel = New TabPanelUI() With {
    '    .Dock = DockStyle.Fill,
    '    .TabHeight = 44
    '}

    'Me.Controls.Add(tabPanel)

    'Dim contenido As New moduloProductos()
    'tabPanel.AddTab(New TabItemOrbitalAdv With {
    '        .Titulo = "Auditoría",
    '        .Icono = IconChar.A,
    '        .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Success,
    '        .Tooltip = "Registros y seguimiento del sistema",
    '        .Contenido = contenido,
    '        .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Pendiente
    '})

    'tabPanel.AddTab(New TabItemOrbitalAdv With {
    '        .Titulo = "Control",
    '        .Icono = IconChar.ClinicMedical,
    '        .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Info,
    '        .Tooltip = "Registros y seguimiento del sistema",
    '        .Contenido = contenido,
    '        .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Ninguno
    '})

    'tabPanel.AddTab(New TabItemOrbitalAdv With {
    '        .Titulo = "Productos",
    '        .Icono = IconChar.Procedures,
    '        .Estilo = TabItemOrbitalAdv.EstiloBootstrap.Dark,
    '        .Tooltip = "Registros y seguimiento del sistema",
    '        .Contenido = contenido,
    '        .EstadoValidacion = TabItemOrbitalAdv.EstadoOrbital.Correcto
    '})






    'Eventos públicos orbitando 🚀
    Private Sub gridUI_EditarRegistro(id As Integer) Handles gridUI.EditarRegistro
        MessageBox.Show($"Editar: {id}")
    End Sub

    Private Sub gridUI_EliminarRegistro(id As Integer) Handles gridUI.EliminarRegistro
        MessageBox.Show($"Eliminar: {id}")
    End Sub

    Private Sub gridUI_AgregarRegistro() Handles gridUI.AgregarRegistro
        MessageBox.Show("Agregar nuevo registro")
    End Sub

    Private Sub gridUI_ExportarExcelSolicitado() Handles gridUI.ExportarExcelSolicitado
        gridUI.ExportarConEstiloExcel("ReporteFinanciero")
    End Sub

End Class

