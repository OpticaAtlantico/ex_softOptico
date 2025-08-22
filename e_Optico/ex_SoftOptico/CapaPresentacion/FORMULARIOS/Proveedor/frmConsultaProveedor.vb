Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Public Class frmConsultaProveedor
    Public Property ProveedorSeleccionado As VProveedor = Nothing
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
        Dim listaProveedor As List(Of VProveedor) = repo.GetAlls()
        Dim tabla As DataTable = ConvertirListaADataTable(listaProveedor)

        Dim columnasVisibles = {"_proveedorID", "_nombreEmpresa", "_razonSocial", "_contacto", "_telefono", "_siglas", "_rif", "_correo", "_direccion"}

        Dim anchos = New Dictionary(Of String, Integer) From {
            {"_proveedorID", 80}, {"_nombreEmpresa", 160}, {"_razonSocial", 160},
            {"_contacto", 120}, {"_telefono", 120}, {"_siglas", 50}, {"_rif", 100},
            {"_correo", 130}, {"_direccion", 450}
        }

        Dim nombres = New Dictionary(Of String, String) From {
            {"_proveedorID", "ID"}, {"_nombreEmpresa", "Empresa"}, {"_razonSocial", "Razon Social"},
            {"_contacto", "Contacto"}, {"_telefono", "# Teléfono"}, {"_siglas", "Siglas"}, {"_rif", "Rif"},
            {"_correo", "Correo Electrónico"}, {"_direccion", "Domicilio Fiscal"}
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
            Dim proveedorEncontrado As VProveedor = repositorio.GetById(id)

            If proveedorEncontrado IsNot Nothing Then
                Dim formularioHijo As New frmProveedor()
                formularioHijo.DatosProveedor = proveedorEncontrado
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
                                 TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

    Private Sub EliminarProveedorUnico(id As Integer)
        Try
            Dim confirmar = MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                                MensajesUI.ConfirmarAccion,
                                                 TipoMensaje.Advertencia, Botones.SiNo)

            If confirmar = DialogResult.No Then Exit Sub

            Dim repositorio As New Repositorio_Proveedor()
            Dim proveedor As VProveedor = repositorio.GetById(id)

            If proveedor Is Nothing Then
                MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                     MensajesUI.SinResultados,
                                     TipoMensaje.Errors, Botones.Aceptar)
                Exit Sub
            End If

            Dim eliminar = repositorio.Remove(id)

            If eliminar Then
                MessageBoxUI.Mostrar(MensajesUI.TituloExito,
                                     MensajesUI.EliminacionExitosa,
                                     TipoMensaje.Exito, Botones.Aceptar)
                CargarDatosProveedores()
            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                     MensajesUI.OperacionFallida,
                                     TipoMensaje.Errors, Botones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

#Region "FUNCIONES PRIVADAS"

    Private Function ObtenerProveedor() As DataTable
        Dim lista = New Repositorio_Proveedor().GetAlls()
        Return ConvertirListaADataTable(lista.ToList)
    End Function

#End Region

End Class