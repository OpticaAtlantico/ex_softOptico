Imports CapaDatos
Imports CapaEntidad

Public Class frmCompras

    Private grvCompras As New DataGridComprasUI()
    Private cargandoCombo As Boolean = False

    Private Sub frmCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar configuración del DataGridComprasUI
        grvCompras.Dock = DockStyle.Fill
        grvCompras.IvaPorcentaje = 16D ' IVA por defecto si aplica
        grvCompras.Inicializar()

        ' Inicializar con lista vacía
        grvCompras.CargarDatos(New List(Of ProductoSeleccionado)())

        ' Suscribir evento de totales
        AddHandler grvCompras.TotalActualizado, AddressOf ActualizarEtiquetasTotales

        ' Limpiar el panel contenedor
        pnlDataGrid.Controls.Clear()

        ' Agregar al panel contenedor
        pnlDataGrid.Controls.Add(grvCompras)
        grvCompras.BringToFront()

        cmbProveedor.IniciarCarga()

        'llenar combos desde la base de datos
        Dim llenarCombo As New LlenarComboBox

        Dim sql As String = "SELECT ProveedorID, NombreEmpresa FROM TProveedor"
        llenarCombo.Cargar(cmbProveedor, sql, "NombreEmpresa", "ProveedorID")

        cmbProveedor.FinalizarCarga()

    End Sub

    Private Sub ActualizarEtiquetasTotales(totalExento As Decimal, baseImponible As Decimal, iva As Decimal, totalGeneral As Decimal)
        ' Aquí puedes actualizar labels o campos fuera del control
        lblExento.Text = totalExento.ToString("N2")
        lblBaseImponible.Text = baseImponible.ToString("N2")
        lblIva.Text = iva.ToString("N2")
        lblTotalGeneral.Text = totalGeneral.ToString("N2")
    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        Dim frmLista As New frmListarProductos
        frmLista.FormularioDestino = Me
        frmLista.ShowDialog()

    End Sub

    ' Método para agregar un producto desde otro formulario
    Public Sub AgregarProductoAlDetalle(producto As ProductoSeleccionado)
        grvCompras.AgregarProducto(
            producto.Codigo,
            producto.Nombre,
            producto.ExG,
            producto.Precio
        )
    End Sub

    Private Sub cmbProveedor_SelectedIndexChangedCustom(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChangedCustom

        Dim seleccionado As LlenarComboBox.ComboItem = cmbProveedor.ItemSeleccionado

        If seleccionado IsNot Nothing Then
            Dim idprovedor As Integer = Convert.ToInt32(seleccionado.Valor)
            Dim nombreProveedor As String = seleccionado.Texto

            Dim proveedor As New Repositorio_Proveedor
            Dim datos = proveedor.BuscarProveedorPorID(idprovedor)
            Try
                If datos IsNot Nothing Then
                    txtTelefonos.TextoUsuario = datos.telefono
                    txtRifCI.TextoUsuario = datos.rif
                    txtDomicilio.TextoUsuario = datos.direccion
                Else
                    ' Limpiar campos si no se encuentra el proveedor
                    txtTelefonos.TextoUsuario = String.Empty
                    txtRifCI.TextoUsuario = String.Empty
                    txtDomicilio.TextoUsuario = String.Empty
                End If
            Catch ex As Exception
                MessageBoxUI.Mostrar("Error...", "Error al buscar el proveedor: " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
            End Try

        End If

    End Sub
End Class




















