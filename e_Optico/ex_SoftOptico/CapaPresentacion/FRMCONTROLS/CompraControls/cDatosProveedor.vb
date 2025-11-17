Imports CapaEntidad

Public Class cDatosProveedor
    Public Property TabPanelRef As TabPanelUI

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

    End Sub

    Private Sub AvanzarEntrePestañas()
        If TabPanelRef IsNot Nothing Then
            TabPanelRef.AvanzarPestaña()
        End If
    End Sub

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
                    ' Propiedad de texto (si existe)
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
