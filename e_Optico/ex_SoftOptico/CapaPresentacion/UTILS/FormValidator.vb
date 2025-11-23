Imports System.Reflection
Imports CapaEntidad

''' <summary>
''' Clase reutilizable para validar formularios y UserControls.
''' Uso: Dim result = FormValidator.ValidateContainer(Me)
''' </summary>
Public NotInheritable Class FormValidator

    Public Class ValidationResult
        Public Property IsValid As Boolean = True
        Public Property FirstInvalid As Control = Nothing
        Public Property Message As String = String.Empty
    End Class

    Private Sub New()
    End Sub

    Private Shared ReadOnly TextProperties As String() = New String() {"TextString", "TextoUsuario", "TextValue", "Texto", "Text"}

    ''' <summary>
    ''' Valida recursivamente todos los controles dentro de <paramref name="container"/>.
    ''' Solo comprueba contenido adicional si el control expone la propiedad Boolean "CampoRequerido" y ésta es True.
    ''' Retorna ValidationResult con el primer control inválido (si existe).
    ''' </summary>
    Public Shared Function ValidateContainer(container As Control) As ValidationResult
        Dim vr As New ValidationResult()
        Try
            Dim firstInvalid As Control = Nothing
            Dim ok = ValidateRecursively(container, firstInvalid)
            If Not ok Then
                vr.IsValid = False
                vr.FirstInvalid = firstInvalid
                vr.Message = MensajesUI.DatosIncompletos
            End If
        Catch ex As Exception
            ' En caso inesperado, consideramos válido para no bloquear el flujo por errores de reflexión
            vr.IsValid = True
        End Try
        Return vr
    End Function

    Private Shared Function ValidateRecursively(container As Control, ByRef firstInvalid As Control) As Boolean
        For Each ctrl As Control In container.Controls
            Dim valido As Boolean = True

            ' 1) Si implementa IValidable -> EsValido()
            Try
                If TypeOf ctrl Is IValidable Then
                    valido = CType(ctrl, IValidable).EsValido()
                Else
                    ' 2) Si tiene método EsValido por reflexión -> invocarlo
                    Dim mi As MethodInfo = ctrl.GetType().GetMethod("EsValido", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                    If mi IsNot Nothing Then
                        Dim res = mi.Invoke(ctrl, Nothing)
                        If TypeOf res Is Boolean Then valido = CBool(res)
                    End If
                End If
            Catch
                ' Si falla la invocación, no penalizamos (evitar bloquear por controles externos)
                valido = True
            End Try

            ' 3) Si control declara CampoRequerido = True -> comprobar contenido/selección/placeholder
            If valido Then
                Try
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
                        ' Obtener primer valor textual disponible
                        Dim textVal As String = Nothing
                        For Each pn In TextProperties
                            Dim p = ctrl.GetType().GetProperty(pn, BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                            If p IsNot Nothing Then
                                Dim v = p.GetValue(ctrl)
                                If v IsNot Nothing Then
                                    textVal = v.ToString()
                                    Exit For
                                End If
                            End If
                        Next

                        ' Si sigue vacío -> comprobar ValorSeleccionado (combos personalizados)
                        If String.IsNullOrWhiteSpace(textVal) Then
                            Dim propValor = ctrl.GetType().GetProperty("ValorSeleccionado", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                            If propValor IsNot Nothing Then
                                Dim vsel = propValor.GetValue(ctrl)
                                If vsel Is Nothing OrElse String.IsNullOrWhiteSpace(vsel.ToString()) Then valido = False
                            Else
                                ' No tiene valor ni texto: inválido
                                valido = False
                            End If
                        Else
                            ' Si tiene texto, comparar con Placeholder (si existe) para evitar aceptar placeholder como valor
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
                    ' Ignorar errores en comprobación extra
                End Try
            End If

            If Not valido Then
                firstInvalid = ctrl
                Return False
            End If

            ' Validar hijos recursivamente
            If ctrl.HasChildren Then
                If Not ValidateRecursively(ctrl, firstInvalid) Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    ''' <summary>
    ''' Intenta obtener un child enfocable útil dentro de <paramref name="parent"/>.
    ''' Util para enfocarse en el textbox o combo real dentro de un control compuesto.
    ''' </summary>
    Public Shared Function FindFocusableChild(parent As Control) As Control
        For Each c As Control In parent.Controls
            If c.Visible AndAlso c.Enabled Then
                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then Return c
                ' Propiedades comunes en controles compuestos
                Dim pTxt = c.GetType().GetProperty("txtCampo", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If pTxt IsNot Nothing Then
                    Dim val = pTxt.GetValue(c)
                    If TypeOf val Is Control Then Return DirectCast(val, Control)
                End If
                Dim pCmb = c.GetType().GetProperty("cmbCampo", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If pCmb IsNot Nothing Then
                    Dim val = pCmb.GetValue(c)
                    If TypeOf val Is Control Then Return DirectCast(val, Control)
                End If
                ' Recursividad
                Dim found = FindFocusableChild(c)
                If found IsNot Nothing Then Return found
            End If
        Next
        Return Nothing
    End Function

End Class