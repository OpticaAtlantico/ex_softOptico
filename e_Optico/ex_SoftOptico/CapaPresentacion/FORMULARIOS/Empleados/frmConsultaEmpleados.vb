Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frmConsultaEmpleados

    Public Property EmpleadoSeleccionado As TEmpleados = Nothing
    ' Evento para pedir al formulario padre abrir un formulario hijo nuevo
    Public Event AbrirFormularioHijo As Action(Of Form)

    Private layoutOrbital As DataGridViewUI

#Region "CONSTRUCTOR"
    Public Sub New()
        InitializeComponent()
        FormStylerUI.Apply(Me)

        With Me.dgvDatosProveedor.lblTitulo
            .Titulo = "Consulta de Empleados"
            .Subtitulo = "Lista de empleados registrados"
            .ForeColor = Color.FromArgb(57, 103, 208)
            .ColorTexto = Color.FromArgb(57, 103, 208)
            .Icono = IconChar.Users
        End With

        CargarDatosEmpleados()
    End Sub

#End Region

#Region "EVENTOS DEL FORMULARIO"

    Private Sub frmConsultaEmpleados_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler dgvDatosProveedor.EditarRegistro, AddressOf EditarEmpleado
        AddHandler dgvDatosProveedor.EliminarRegistro, AddressOf EliminarEmpleadoUnico
        AddHandler dgvDatosProveedor.AgregarRegistro, AddressOf AgregarEmpleado
        AddHandler AbrirFormularioHijo, AddressOf frm_Principal.SolicitarAbrirFormularioHijo

        dgvDatosProveedor.MetodoCargaDatos = AddressOf ObtenerEmpleados
        dgvDatosProveedor.RefrescarTodo()

        AddHandler dgvDatosProveedor.BExportarGrid.Click, Sub()
                                                              ExcelExportManagerUI.ExportarDesdeGridEstilizado(dgvDatosProveedor.GrvOrbital, "Empleado")
                                                          End Sub

        AddHandler dgvDatosProveedor.BExportarTabla.Click, Sub()
                                                               MsgBox("Exportar tabla no implementado")
                                                           End Sub
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub CargarDatosEmpleados()
        ' === Reiniciar propiedades internas ===
        dgvDatosProveedor.DataOriginal = Nothing
        dgvDatosProveedor.DataCompleta = Nothing

        ' === Limpiar el DataGridView ===
        dgvDatosProveedor.Grid.Rows.Clear()
        dgvDatosProveedor.Grid.Columns.Clear()

        Dim repo As New Repositorio_Empleados()
        Dim listaEmpleados As List(Of TEmpleados) = repo.ObtenerTodos()
        Dim tabla As DataTable = ConvertirListaADataTable(listaEmpleados)

        Dim columnasVisibles = {"EmpleadoID", "Cedula", "Nombre", "Apellido", "Edad", "Nacionalidad", "EstadoCivil", "Sexo", "FechaNacimiento", "Correo", "Cargo", "Telefono", "Zona", "Direccion", "Estado"}

        Dim anchos = New Dictionary(Of String, Integer) From {
            {"EmpleadoID", 80}, {"Cedula", 120}, {"Nombre", 160}, {"Apellido", 160},
            {"Edad", 80}, {"Nacionalidad", 120}, {"EstadoCivil", 120}, {"Sexo", 100},
            {"FechaNacimiento", 130}, {"Correo", 200}, {"Cargo", 140}, {"Telefono", 120},
            {"Zona", 100}, {"Direccion", 200}, {"Estado", 100}
        }

        Dim nombres = New Dictionary(Of String, String) From {
            {"EmpleadoID", "ID"}, {"Cedula", "Cédula"}, {"Nombre", "Nombres"}, {"Apellido", "Apellidos"},
            {"Edad", "Edad"}, {"Nacionalidad", "Nacionalidad"}, {"EstadoCivil", "Estado Civil"}, {"Sexo", "Sexo"},
            {"FechaNacimiento", "Fecha de Nacimiento"}, {"Correo", "Correo Electrónico"}, {"Cargo", "Cargo"},
            {"Telefono", "Teléfono"}, {"Zona", "Zona"}, {"Direccion", "Dirección de Residencia"}, {"Estado", "Estatus"}
        }

        dgvDatosProveedor.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombres)
        AgregarColumnasBotonesSiFaltan()
        AgregarToolTipsBotones()
        dgvDatosProveedor.CargarDatos(tabla)
        dgvDatosProveedor.Grid.Refresh()
    End Sub

    Private Sub AgregarToolTipsBotones()
        Dim dgv = dgvDatosProveedor.GrvOrbital
        dgv.Columns("Agregar").ToolTipText = "Agregar relacionado"
        dgv.Columns("Editar").ToolTipText = "Editar este registro"
        dgv.Columns("Eliminar").ToolTipText = "Eliminar este registro"
    End Sub

    Private Sub AgregarColumnasBotonesSiFaltan()
        Dim dgv = dgvDatosProveedor.GrvOrbital

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

    Private Sub AgregarEmpleado()
        Dim frm As New frmEmpleado
        Me.Close()
        RaiseEvent AbrirFormularioHijo(frm)
    End Sub

    Private Sub EditarEmpleado(id As Integer)
        Try
            Dim repositorio As New Repositorio_Empleados()
            Dim empleadoEncontrado As TEmpleados = repositorio.ObtenerPorID(id)

            If empleadoEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmEmpleado()
                formularioHijo.DatosEmpleados = empleadoEncontrado
                formularioHijo.NombreBoton = "Actualizar..."

                ' En vez de abrir el formulario directamente, disparar evento
                RaiseEvent AbrirFormularioHijo(formularioHijo)
            Else
                MessageBoxUI.Mostrar("Busqueda fallida...", "No se pudo localizar los datos del empleado seleccionado, por favor verifique que los datos sean correctos", TipoMensaje.Informacion, Botones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error de datos...", "Error al intentar cargar el empleado, " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

    Private Sub EliminarEmpleadoUnico(id As Integer)
        Try
            Dim confirmar = MessageBoxUI.Mostrar("Eliminar datos...", "¿Deseas eliminar el proveedor seleccionado ?", TipoMensaje.Errors, Botones.AceptarCancelar)
            If confirmar = DialogResult.No Then Exit Sub

            Dim repositorio As New Repositorio_Empleados()
            Dim empleado As TEmpleados = repositorio.ObtenerPorID(id)

            If empleado Is Nothing Then
                MessageBoxUI.Mostrar("Error de datos...", "Empleado no encontrado por favor verifique los datos", TipoMensaje.Errors, Botones.Aceptar)
                Exit Sub
            End If

            If EliminarEmpleado(empleado.EmpleadoID, empleado.Foto) Then
                CargarDatosEmpleados()
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar("Error al eliminar...", "No se pudo eliminar el empleado seleccionado, por favor verifique que los datos sean correctos", TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

#Region "FUNCIONES "
    Private Function ObtenerEmpleados() As DataTable
        Dim lista = New Repositorio_Empleados().ObtenerTodos()
        Return ConvertirListaADataTable(lista.ToList)
    End Function

#End Region

End Class