Imports CapaDatos
Imports CapaEntidad
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports OfficeOpenXml.Drawing.Slicer.Style

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

        'Bloquea el panel de grid hasta que se agregue un producto
        pnlDataGrid.Enabled = False

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

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click

        Try
            Dim ncontrol As String = txtNumeroControl.TextoUsuario.Trim()
            Dim nfactura As String = txtNumeroFactura.TextoUsuario.Trim()
            Dim fecha As Date = txtFechaEmision.TextValue
            Dim proveedor As String = cmbProveedor.TextoSeleccionado.Trim()
            Dim domicilio As String = txtDomicilio.TextoUsuario.Trim()
            Dim rif As String = txtRifCI.TextoUsuario.Trim()
            Dim telefono As String = txtTelefonos.TextoUsuario.Trim()
            Dim tipoPago As String = cmbTipoPago.TextoSeleccionado.Trim()

            If {ncontrol, nfactura, fecha, proveedor, domicilio, rif, telefono, tipoPago
                        }.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar("Cargando...",
                                         "Por favor, complete todos los campos obligatorios.",
                                          TipoMensaje.Errors, Botones.Aceptar)

            Else

                'Desbloquear el panel de grid
                pnlDataGrid.Enabled = True

            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error...", "Error al procesar los datos: " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
        End Try




    End Sub
End Class




















