Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frmConsultaEmpleados

    Public Property EmpleadoSeleccionado As VEmpleados = Nothing
    ' Evento para pedir al formulario padre abrir un formulario hijo nuevo
    Public Event AbrirFormularioHijo As Action(Of Form)

    Private layoutOrbital As DataGridViewUI

#Region "CONSTRUCTOR"
    Public Sub New()
        InitializeComponent()
        FormStylerUI.Apply(Me)

        With Me.dgvDatosEmpleado.lblTitulo
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
        AddHandler dgvDatosEmpleado.EditarRegistro, AddressOf EditarEmpleado
        AddHandler dgvDatosEmpleado.EliminarRegistro, AddressOf EliminarEmpleadoUnico
        AddHandler dgvDatosEmpleado.AgregarRegistro, AddressOf AgregarEmpleado
        AddHandler AbrirFormularioHijo, AddressOf frm_Principal.SolicitarAbrirFormularioHijo

        dgvDatosEmpleado.MetodoCargaDatos = AddressOf ObtenerEmpleados
        dgvDatosEmpleado.RefrescarTodo()

        AddHandler dgvDatosEmpleado.BExportarGrid.Click, Sub()
                                                             ExcelExportManagerUI.ExportarDesdeGridEstilizado(dgvDatosEmpleado.GrvOrbital, "Empleado")
                                                         End Sub

        AddHandler dgvDatosEmpleado.BExportarTabla.Click, Sub()
                                                              MsgBox("Exportar tabla no implementado")
                                                          End Sub
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub CargarDatosEmpleados()
        ' === Reiniciar propiedades internas ===
        dgvDatosEmpleado.DataOriginal = Nothing
        dgvDatosEmpleado.DataCompleta = Nothing

        ' === Limpiar el DataGridView ===
        dgvDatosEmpleado.Grid.Rows.Clear()
        dgvDatosEmpleado.Grid.Columns.Clear()

        Dim repo As New Repositorio_Empleados()
        Dim listaEmpleados As List(Of VEmpleados) = repo.GetAlls()
        Dim tabla As DataTable = ConvertirListaADataTable(listaEmpleados)

        Dim columnasVisibles = {"_empleadoID", "_cedula", "_nombre", "_apellido", "_edad", "_nacionalidad", "_estadoCivil", "_sexo",
                                "_fechaNacimiento", "_correo", "_cargo", "_telefono", "_zona", "_direccion", "_estado"}

        Dim anchos = New Dictionary(Of String, Integer) From {
            {"_empleadoID", 40}, {"_cedula", 120}, {"_nombre", 160}, {"_apellido", 160},
            {"_edad", 80}, {"_nacionalidad", 160}, {"_estadoCivil", 120}, {"_sexo", 100},
            {"_fechaNacimiento", 160}, {"_correo", 230}, {"_cargo", 170}, {"_telefono", 190},
            {"_zona", 160}, {"_direccion", 300}, {"_estado", 100}
        }

        Dim nombres = New Dictionary(Of String, String) From {
            {"_empleadoID", "ID"}, {"_cedula", "Cédula"}, {"_nombre", "Nombres"}, {"_apellido", "Apellidos"},
            {"_edad", "Edad"}, {"_nacionalidad", "Nacionalidad"}, {"_estadoCivil", "Estado Civil"}, {"_sexo", "Sexo"},
            {"_fechaNacimiento", "Fecha de Nacimiento"}, {"_correo", "Correo Electrónico"}, {"_cargo", "Cargo"},
            {"_telefono", "Teléfono"}, {"_zona", "Zona"}, {"_direccion", "Dirección de Residencia"}, {"_estado", "Estatus"}
        }

        dgvDatosEmpleado.ConfigurarColumnasVisualesPorTipo(tabla, columnasVisibles, anchos, nombres)
        AgregarColumnasBotonesSiFaltan()
        AgregarToolTipsBotones()
        dgvDatosEmpleado.CargarDatos(tabla)
        dgvDatosEmpleado.Grid.Refresh()
        dgvDatosEmpleado.OcultarColumnas({"_empleadoID", "_estado"})
    End Sub

    Private Sub AgregarToolTipsBotones()
        Dim dgv = dgvDatosEmpleado.GrvOrbital
        dgv.Columns("Agregar").ToolTipText = "Agregar relacionado"
        dgv.Columns("Editar").ToolTipText = "Editar este registro"
        dgv.Columns("Eliminar").ToolTipText = "Eliminar este registro"
    End Sub

    Private Sub AgregarColumnasBotonesSiFaltan()
        Dim dgv = dgvDatosEmpleado.GrvOrbital

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
            Dim empleadoEncontrado As VEmpleados = repositorio.GetById(id)

            If empleadoEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmEmpleado()
                formularioHijo.DatosEmpleados = empleadoEncontrado
                formularioHijo.NombreBoton = "Actualizar..."

                ' En vez de abrir el formulario directamente, disparar evento
                RaiseEvent AbrirFormularioHijo(formularioHijo)
            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                     MensajesUI.OperacionFallida,
                                     TipoMensaje.Informacion, Botones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 TipoMensaje.Advertencia, Botones.Aceptar)
        End Try
    End Sub

    Private Sub EliminarEmpleadoUnico(id As Integer)
        Try
            Dim confirmar = MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                                 MensajesUI.ConfirmarAccion,
                                                 TipoMensaje.Errors, Botones.AceptarCancelar)

            If confirmar = DialogResult.No Then Exit Sub

            Dim repositorio As New Repositorio_Empleados()
            Dim empleado As VEmpleados = repositorio.GetById(id)

            If empleado Is Nothing Then
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                     MensajesUI.OperacionFallida,
                                     TipoMensaje.Errors, Botones.Aceptar)
                Exit Sub
            End If

            If EliminarEmpleado(empleado._empleadoID, empleado._foto) Then
                CargarDatosEmpleados()
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

#Region "FUNCIONES "
    Private Function ObtenerEmpleados() As DataTable
        Dim lista = New Repositorio_Empleados().GetAlls()
        Return ConvertirListaADataTable(lista.ToList)
    End Function

#End Region

End Class