Imports CapaEntidad
Imports System.Reflection

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
        ' Validar todos los controles dentro de este UserControl.
        ' Si alguno no es válido, no avanzamos y enfocamos el primer control inválido.
        If Not ValidarControles() Then
            Exit Sub
        End If

        If TabPanelRef IsNot Nothing Then
            TabPanelRef.AvanzarPestaña()
        End If
    End Sub

    ' Recorre recursivamente los controles intentando validar:
    ' 1) Si el control implementa IValidable -> llamar EsValido()
    ' 2) Si no, busca por reflexión un método EsValido() y lo invoca.
    ' 3) Además valida que los campos requeridos no estén vacíos ni solo muestren el placeholder.
    Private Function ValidarControles() As Boolean
        Dim firstInvalid As Control = Nothing
        Dim ok As Boolean = ValidarRecursivo(Me, firstInvalid)

        If Not ok Then
            If firstInvalid IsNot Nothing Then
                Try
                    ' Intentar enfocar el control inválido para que el usuario vea el error
                    firstInvalid.Focus()
                Catch
                End Try

                ' Mostrar mensaje informativo común (se usa el helper MessageBoxUI en todo el proyecto)
                Try
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                         MensajesUI.DatosIncompletos,
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)
                Catch
                    ' Fallback silente si MessageBoxUI no está disponible
                    MessageBox.Show(MensajesUI.DatosIncompletos, MensajesUI.TituloInfo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If
        End If

        Return ok
    End Function

    Private Function ValidarRecursivo(container As Control, ByRef firstInvalid As Control) As Boolean
        For Each ctrl As Control In container.Controls
            Dim valido As Boolean = True

            Try
                ' 1) Si implementa IValidable
                If TypeOf ctrl Is IValidable Then
                    valido = CType(ctrl, IValidable).EsValido()
                Else
                    ' 2) Intentar por reflexión: buscar método EsValido()
                    Dim mi As MethodInfo = ctrl.GetType().GetMethod("EsValido", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                    If mi IsNot Nothing Then
                        Dim res = mi.Invoke(ctrl, Nothing)
                        If TypeOf res Is Boolean Then
                            valido = CBool(res)
                        End If
                    End If
                End If
            Catch
                ' En caso de error al invocar la validación, consideramos que el control es válido
                valido = True
            End Try

            ' 3) Validación adicional: si el control declara "CampoRequerido" comprobar contenido / placeholder
            If valido Then
                Try
                    ' Default: no asumir que todos los controles son requeridos.
                    Dim campoRequerido As Boolean = False
                    Dim prCampo = ctrl.GetType().GetProperty("CampoRequerido", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                    If prCampo IsNot Nothing Then
                        Try
                            campoRequerido = CBool(prCampo.GetValue(ctrl))
                        Catch
                            campoRequerido = False
                        End Try
                    End If

                    If campoRequerido Then
                        ' Buscar posible valor textual en varias propiedades comunes
                        Dim textProps = New String() {"TextString", "TextoUsuario", "TextValue", "Texto", "Text"}
                        Dim textVal As String = Nothing

                        For Each pn In textProps
                            Dim p = ctrl.GetType().GetProperty(pn, BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                            If p IsNot Nothing Then
                                Dim v = p.GetValue(ctrl)
                                If v IsNot Nothing Then
                                    textVal = v.ToString()
                                    Exit For
                                End If
                            End If
                        Next

                        ' Si no tiene representación textual, intentar comprobar selección (ComboBox)
                        If String.IsNullOrWhiteSpace(textVal) Then
                            Dim propValor = ctrl.GetType().GetProperty("ValorSeleccionado", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                            If propValor IsNot Nothing Then
                                Dim vsel = propValor.GetValue(ctrl)
                                If vsel Is Nothing OrElse String.IsNullOrWhiteSpace(vsel.ToString()) Then
                                    valido = False
                                End If
                            Else
                                ' Fallback: si no hay texto ni selección, considerar inválido
                                If String.IsNullOrWhiteSpace(textVal) Then
                                    valido = False
                                End If
                            End If
                        Else
                            ' Si tiene texto, comparar con placeholder (si existe) para evitar avanzar cuando solo muestra placeholder
                            Dim phProp = ctrl.GetType().GetProperty("Placeholder", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                            If phProp IsNot Nothing Then
                                Dim ph = phProp.GetValue(ctrl)
                                If ph IsNot Nothing Then
                                    If String.Equals(textVal.Trim(), ph.ToString().Trim(), StringComparison.OrdinalIgnoreCase) Then
                                        valido = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch
                    ' Si falla esta comprobación, no bloqueamos por este motivo
                End Try
            End If

            If Not valido Then
                firstInvalid = ctrl
                Return False
            End If

            ' Recursividad en hijos
            If ctrl.HasChildren Then
                If Not ValidarRecursivo(ctrl, firstInvalid) Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

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


End Class
