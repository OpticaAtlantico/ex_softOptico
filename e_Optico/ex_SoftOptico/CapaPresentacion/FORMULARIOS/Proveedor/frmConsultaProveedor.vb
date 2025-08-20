Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frmConsultaProveedor
    Public Property ProveedorSeleccionado As TEmpleados = Nothing
    ' Evento para pedir al formulario padre abrir un formulario hijo nuevo
    Public Event AbrirFormularioHijo As Action(Of Form)

    Private layoutOrbital As DataGridViewUI

#Region "CONSTRUCTOR"
    Public Sub New()
        InitializeComponent()
        FormStylerUI.Apply(Me)
        With Me.dgvDatosProveedor.lblTitulo
            .Titulo = "Consulta de Proveedor"
            .Subtitulo = "Lista de Proveedores registrados..."
            .ForeColor = Color.FromArgb(57, 103, 208)
            .ColorTexto = Color.FromArgb(57, 103, 208)
            .Icono = IconChar.Users
        End With

        CargarDatosProveedores()
    End Sub

#End Region

#Region "EVENTOS DEL FORMULARIO"

    Private Sub frmConsultaProveedor_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler dgvDatosProveedor.EditarRegistro, AddressOf EditarProveedor
        AddHandler dgvDatosProveedor.EliminarRegistro, AddressOf EliminarProveedorUnico
        AddHandler dgvDatosProveedor.AgregarRegistro, AddressOf AgregarProveedor
        AddHandler AbrirFormularioHijo, AddressOf frm_Principal.SolicitarAbrirFormularioHijo

        dgvDatosProveedor.MetodoCargaDatos = AddressOf ObtenerProveedor
        dgvDatosProveedor.RefrescarTodo()

        AddHandler dgvDatosProveedor.BExportarGrid.Click, Sub()
                                                              ExcelExportManagerUI.ExportarDesdeGridEstilizado(dgvDatosProveedor.GrvOrbital, "Proveedor")
                                                          End Sub

        AddHandler dgvDatosProveedor.BExportarTabla.Click, Sub()
                                                               MsgBox("Exportar tabla no implementado")
                                                           End Sub
        FadeManagerUI.StartFade(Me, 0.05)
    End Sub

#End Region

#Region "PROCEDIMIENTOS"

    Private Sub CargarDatosProveedores()
        ' === Reiniciar propiedades internas ===
        dgvDatosProveedor.DataOriginal = Nothing
        dgvDatosProveedor.DataCompleta = Nothing

        ' === Limpiar el DataGridView ===
        dgvDatosProveedor.Grid.Rows.Clear()
        dgvDatosProveedor.Grid.Columns.Clear()

        Dim repo As New Repositorio_Proveedor()
        Dim listaProveedor As List(Of TProveedor) = repo.ObtenerProveedor()
        Dim tabla As DataTable = ConvertirListaADataTable(listaProveedor)

        Dim columnasVisibles = {"ProveedorID", "nombreEmpresa", "razonSocial", "contacto", "telefono", "siglas", "rif", "correo", "direccion"}

        Dim anchos = New Dictionary(Of String, Integer) From {
            {"ProveedorID", 80}, {"nombreEmpresa", 160}, {"razonSocial", 160},
            {"contacto", 120}, {"telefono", 120}, {"siglas", 50}, {"rif", 100}, {"correo", 130}, {"direccion", 450}
        }

        Dim nombres = New Dictionary(Of String, String) From {
            {"ProveedorID", "ID"}, {"nombreEmpresa", "Empresa"}, {"razonSocial", "Razon Social"},
            {"contacto", "Contacto"}, {"telefono", "# Teléfono"}, {"siglas", "Siglas"}, {"rif", "Rif"}, {"correo", "Correo Electrónico"},
            {"direccion", "Domicilio Fiscal"}
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

    Private Sub AgregarProveedor()
        Dim frm As New frmProveedor
        Me.Close()
        RaiseEvent AbrirFormularioHijo(frm)
    End Sub

    Private Sub EditarProveedor(id As Integer)
        Try
            Dim repositorio As New Repositorio_Proveedor()
            Dim proveedorEncontrado As TProveedor = repositorio.BuscarProveedorPorID(id)

            If proveedorEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmProveedor()
                formularioHijo.DatosProveedor = proveedorEncontrado
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

    Private Sub EliminarProveedorUnico(id As Integer)
        Try
            Dim confirmar = MessageBoxUI.Mostrar("Remover datos...", "¿Deseas eliminar el proveedor seleccionado?", TipoMensaje.Advertencia, Botones.SiNo)

            If confirmar = DialogResult.No Then Exit Sub

            Dim repositorio As New Repositorio_Proveedor()
            Dim proveedor As TProveedor = repositorio.BuscarProveedorPorID(id)

            If proveedor Is Nothing Then
                MessageBoxUI.Mostrar("Buscando...", "No se encontró el proveedor.", TipoMensaje.Errors, Botones.Aceptar)
                Exit Sub
            End If

            Dim eliminar = repositorio.EliminarProveedor(id)

            If eliminar Then
                MessageBoxUI.Mostrar("Éxito", "Proveedor eliminado correctamente.", TipoMensaje.Exito, Botones.Aceptar)
                CargarDatosProveedores()
            Else
                MessageBoxUI.Mostrar("Error al eliminar", "No se pudo eliminar el proveedor.", TipoMensaje.Errors, Botones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar("Error... ", "Error al eliminar proveedor" & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

#Region "FUNCIONES PRIVADAS"

    Private Function ObtenerProveedor() As DataTable
        Dim lista = New Repositorio_Proveedor().ObtenerProveedor()
        Return ConvertirListaADataTable(lista.ToList)
    End Function

#End Region




End Class