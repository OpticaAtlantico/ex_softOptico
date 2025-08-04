Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frmConsultaEmpleados

    Public Property EmpleadoSeleccionado As TEmpleados = Nothing
    Public Event SolicitarAperturaFormulario(formulario As Form)

    Public Sub New()
        InitializeComponent()

        With Me.dgvDatosEmpleados.lblTitulo
            .Titulo = "Consulta de Empleados"
            .Subtitulo = "Lista de empleados registrados"
            .ForeColor = Color.FromArgb(57, 103, 208)
            .ColorTexto = Color.FromArgb(57, 103, 208)
            .Icono = IconChar.Users
        End With

        CargarDatosEmpleados()
    End Sub

    Private Sub frmConsultaEmpleados_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler dgvDatosEmpleados.EditarRegistro, AddressOf EditarEmpleado
        AddHandler dgvDatosEmpleados.EliminarRegistro, AddressOf EliminarEmpleadoUnico
        AddHandler dgvDatosEmpleados.AgregarRegistro, AddressOf AgregarEmpleado

        dgvDatosEmpleados.MetodoCargaDatos = AddressOf ObtenerEmpleados
        dgvDatosEmpleados.RefrescarTodo()
    End Sub

    Private Function ObtenerEmpleados() As DataTable
        Dim lista = New Repositorio_Empleados().ObtenerTodos()
        Return ConvertirListaADataTable(lista.ToList)
    End Function

    Private Sub CargarDatosEmpleados()
        ' === Reiniciar propiedades internas ===
        dgvDatosEmpleados.DataOriginal = Nothing
        dgvDatosEmpleados.DataCompleta = Nothing

        ' === Limpiar el DataGridView ===
        dgvDatosEmpleados.Grid.Rows.Clear()
        dgvDatosEmpleados.Grid.Columns.Clear()

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

        dgvDatosEmpleados.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombres)
        AgregarColumnasBotonesSiFaltan()
        AgregarToolTipsBotones()
        dgvDatosEmpleados.CargarDatos(tabla)
        dgvDatosEmpleados.Grid.Refresh()
    End Sub

    Private Sub AgregarToolTipsBotones()
        Dim dgv = dgvDatosEmpleados.GrvOrbital
        dgv.Columns("Agregar").ToolTipText = "Agregar relacionado"
        dgv.Columns("Editar").ToolTipText = "Editar este registro"
        dgv.Columns("Eliminar").ToolTipText = "Eliminar este registro"
    End Sub

    Private Sub AgregarColumnasBotonesSiFaltan()
        Dim dgv = dgvDatosEmpleados.GrvOrbital

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
        MessageBox.Show("Agregar nuevo empleado")
    End Sub

    Private Sub EditarEmpleado(id As Integer)
        Try
            Dim repositorio As New Repositorio_Empleados()
            Dim empleadoEncontrado As TEmpleados = repositorio.ObtenerPorID(id)

            If empleadoEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmNuevoEmpleado()
                formularioHijo.DatosEmpleados = empleadoEncontrado
                formularioHijo.NombreBoton = "Actualizar..."
                RaiseEvent SolicitarAperturaFormulario(formularioHijo)
            Else
                MessageBox.Show("No se encontró el empleado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al intentar cargar el empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EliminarEmpleadoUnico(id As Integer)
        Try
            Dim confirmar = MessageBox.Show("¿Deseas eliminar este empleado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirmar = DialogResult.No Then Exit Sub

            Dim repositorio As New Repositorio_Empleados()
            Dim empleado As TEmpleados = repositorio.ObtenerPorID(id)

            If empleado Is Nothing Then
                MessageBox.Show("No se encontró el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If EliminarEmpleado(empleado.EmpleadoID, empleado.Foto) Then
                CargarDatosEmpleados()
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar eliminar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class