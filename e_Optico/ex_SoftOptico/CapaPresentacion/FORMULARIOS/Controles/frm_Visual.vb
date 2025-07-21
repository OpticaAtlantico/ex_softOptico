Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Forms
Imports FontAwesome.Sharp
Public Class frm_Visual
    'Inherits Form
    Private tabPanel As TabPanelUI
    Private WithEvents gridUI As New DataGridViewUI()
    Private Sub frm_Visual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '

        Me.Controls.Add(gridUI)

        ' Cargar registros simulados
        Dim dt As New DataTable()
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Nombre")
        dt.Columns.Add("Correo")

        dt.Rows.Add(1, "Wilmer Duarte", "wilmer@empresa.com")
        dt.Rows.Add(2, "Sofía Ramos", "sofia@empresa.com")
        dt.Rows.Add(3, "Carlos López", "carlos@empresa.com")

        'Asi se cambia los datos de los controles de la UI
        gridUI.lblTitulo.Titulo = "Wilmer Flores"
        gridUI.lblTitulo.Subtitulo = "Gestión de usuarios"
        gridUI.lblTitulo.Icono = IconChar.User



        gridUI.CargarDatos(dt)




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



    End Sub

    ' Eventos públicos orbitando 🚀
    Private Sub gridUI_EditarRegistro(id As Integer) Handles gridUI.EditarRegistro
        MessageBox.Show($"Editar: {id}")
    End Sub

    Private Sub gridUI_EliminarRegistro(id As Integer) Handles gridUI.EliminarRegistro
        MessageBox.Show($"Eliminar: {id}")
    End Sub

    Private Sub gridUI_AgregarRegistro() Handles gridUI.AgregarRegistro
        MessageBox.Show("Agregar nuevo registro")
    End Sub



End Class

