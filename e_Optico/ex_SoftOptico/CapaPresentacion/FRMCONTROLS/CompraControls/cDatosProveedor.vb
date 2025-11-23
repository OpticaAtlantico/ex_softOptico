Imports CapaEntidad
Imports System.Reflection

Public Class cDatosProveedor
    Public Property TabPanelRef As TabPanelUI

    Private cargandoCombo As Boolean = False
    Private llenarCombo As New LlenarComboBox
    Public Sub New()
        Me.InitializeComponent()
        Me.Dock = DockStyle.Fill
        Me.AutoSize = False
        Me.Margin = New Padding(0)
        Me.Padding = New Padding(0)
        Me.BackColor = Color.White

        AddHandler btnSiguiente.Click, Sub()
                                           AvanzarEntrePestañas()
                                       End Sub

        CustomerizeComponent()

    End Sub

    Private Sub CustomerizeComponent()
        ' Aquí puedes agregar cualquier personalización adicional de los controles
        ' Por ejemplo, establecer estilos, colores, fuentes, etc.

        'Llenar los combobox
        llenarCombo.Cargar(cmbProveedor, llenarCombo.SQL_PROVEEDOR, "NombreEmpresa", "ProveedorID")
        cmbProveedor.FinalizarCarga()

        llenarCombo.Cargar(cmbFormaPago, llenarCombo.SQL_TIPOPAGO, "Nombre", "TipoPagoID")
        cmbFormaPago.FinalizarCarga()

        llenarCombo.Cargar(cmbSucursal, llenarCombo.SQL_SUCURSALES, "NombreUbicacion", "UbicacionID")
        cmbSucursal.FinalizarCarga()

    End Sub

    Private Sub AvanzarEntrePestañas()
        ' Usa la clase reutilizable FormValidator para validar todo el container.
        Dim vr = FormValidator.ValidateContainer(Me)

        If Not vr.IsValid Then
            ' Intentar enfocar el control interno si aplica y avisar al usuario.
            Try
                Dim foco = FormValidator.FindFocusableChild(If(vr.FirstInvalid, Me))
                If foco IsNot Nothing Then
                    foco.Focus()
                ElseIf vr.FirstInvalid IsNot Nothing Then
                    vr.FirstInvalid.Focus()
                End If
            Catch
            End Try

            Try
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                     vr.Message,
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            Catch
                MessageBox.Show(vr.Message, MensajesUI.TituloInfo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            Exit Sub
        End If

        If TabPanelRef IsNot Nothing Then
            TabPanelRef.AvanzarPestaña()
        End If
    End Sub

    ' Validación delegada al FormValidator reutilizable
    Private Function ValidarControles() As Boolean
        Dim vr = FormValidator.ValidateContainer(Me)
        If Not vr.IsValid Then
            Try
                Dim foco = FormValidator.FindFocusableChild(If(vr.FirstInvalid, Me))
                If foco IsNot Nothing Then
                    foco.Focus()
                ElseIf vr.FirstInvalid IsNot Nothing Then
                    vr.FirstInvalid.Focus()
                End If
            Catch
            End Try

            Try
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                     vr.Message,
                                     MessageBoxUI.TipoMensaje.Advertencia,
                                     MessageBoxUI.TipoBotones.Aceptar)
            Catch
                MessageBox.Show(vr.Message, MensajesUI.TituloInfo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            Return False
        End If

        Return True
    End Function

    ' DTO con los campos que necesita frmRegistrarCompras
    Public Class ProveedorInfo
        Public Property ProveedorID As Integer?
        Public Property Nombre As String
        Public Property NumeroControl As String
        Public Property NumeroFactura As String
        Public Property FechaEmision As Date?
        Public Property Rif As String
        Public Property Telefono As String
        Public Property TipoPagoID As Integer?
        Public Property SucursalID As Integer?
        Public Property Domicilio As String
        Public Property Observacion As String
    End Class

    ' Recopila valores del usercontrol y devuelve un ProveedorInfo
    Public Function GetProveedorInfo() As ProveedorInfo
        Dim info As New ProveedorInfo()
        Try
            ' Proveedor seleccionado
            If Me.cmbProveedor IsNot Nothing Then
                Try
                    If Me.cmbProveedor.ValorSeleccionado IsNot Nothing Then
                        Dim v = Me.cmbProveedor.ValorSeleccionado
                        Dim id As Integer = 0
                        If Integer.TryParse(v.ToString(), id) Then info.ProveedorID = id
                    End If
                Catch
                End Try
                Try
                    ' Propiedad de texto (si exista)
                    info.Nombre = If(Me.cmbProveedor.Texto, String.Empty)
                Catch
                End Try
            End If

            ' Números y texto
            If Me.txtnControl IsNot Nothing Then info.NumeroControl = Me.txtnControl.TextString
            If Me.txtnFactura IsNot Nothing Then info.NumeroFactura = Me.txtnFactura.TextString
            If Me.txtRif IsNot Nothing Then info.Rif = Me.txtRif.TextString
            If Me.TextOnlyTextBoxLabelui4 IsNot Nothing Then info.Telefono = Me.TextOnlyTextBoxLabelui4.TextString
            If Me.txtDomicilio IsNot Nothing Then info.Domicilio = Me.txtDomicilio.TextString
            If Me.txtObservacion IsNot Nothing Then info.Observacion = Me.txtObservacion.TextString

            ' Fecha de emisión (DatePickerProUI: FechaSeleccionada / ValorFecha)
            If Me.txtFechaEmision IsNot Nothing Then
                Try
                    info.FechaEmision = Me.txtFechaEmision.FechaSeleccionada
                Catch
                    Try
                        info.FechaEmision = Me.txtFechaEmision.ValorFecha
                    Catch
                    End Try
                End Try
            End If

            ' Sucursal y forma/tipo de pago (ComboBoxLayoutUI: ValorSeleccionado)
            If Me.cmbSucursal IsNot Nothing Then
                Try
                    If Me.cmbSucursal.ValorSeleccionado IsNot Nothing Then
                        Dim v = Me.cmbSucursal.ValorSeleccionado
                        Dim id As Integer = 0
                        If Integer.TryParse(v.ToString(), id) Then info.SucursalID = id
                    End If
                Catch
                End Try
            End If

            If Me.cmbFormaPago IsNot Nothing Then
                Try
                    If Me.cmbFormaPago.ValorSeleccionado IsNot Nothing Then
                        Dim v = Me.cmbFormaPago.ValorSeleccionado
                        Dim id As Integer = 0
                        If Integer.TryParse(v.ToString(), id) Then info.TipoPagoID = id
                    End If
                Catch
                End Try
            End If

        Catch ex As Exception
            ' Si algo falla, devolvemos lo que haya recopilado
        End Try

        Return info
    End Function

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        ' Handler vacío por si necesitas lógica específica
    End Sub

End Class
