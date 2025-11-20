Imports CapaEntidad
Imports System.Reflection
Imports System.Linq

Public Class cDatosProductos
    Public Property TabPanelRef As TabPanelUI

    Public Sub New()
        Me.InitializeComponent()
        Me.Dock = DockStyle.Fill
        Me.AutoSize = False
        Me.Margin = New Padding(0)
        Me.Padding = New Padding(0)
        Me.BackColor = Color.White

        AddHandler btnAnterior.Click, Sub()
                                          AvanzarEntrePestañas()
                                      End Sub

    End Sub

    Private Sub AvanzarEntrePestañas()
        If TabPanelRef IsNot Nothing Then
            TabPanelRef.RetrocederPestaña()
        End If
    End Sub

    ''' <summary>
    ''' Devuelve el listado de detalle como List(Of TDetalleCompra).
    ''' Prioriza un control fuertemente tipado dentro de Panel1 (DataGridComprasUI / DataGridViewProveedorUI).
    ''' Mantiene fallback reflexivo para compatibilidad con implementaciones antiguas.
    ''' </summary>
    Public Function GetDetalle() As List(Of TDetalleCompra)
        Dim lista As New List(Of TDetalleCompra)()

        Try
            ' 1) Intento control fuertemente tipado en Panel1
            Dim gridControl = Panel1.Controls.OfType(Of Control)().FirstOrDefault(Function(c) c.GetType().Name = "DataGridComprasUI" OrElse c.GetType().Name = "DataGridViewProveedorUI")
            If gridControl IsNot Nothing Then
                Dim mi = gridControl.GetType().GetMethod("GetDetalleList", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If mi IsNot Nothing Then
                    Dim result = mi.Invoke(gridControl, Nothing)
                    If result IsNot Nothing Then
                        If TypeOf result Is List(Of TDetalleCompra) Then
                            Return DirectCast(result, List(Of TDetalleCompra))
                        End If
                        If TypeOf result Is List(Of ProductoSeleccionado) Then
                            Dim listaProd = DirectCast(result, List(Of ProductoSeleccionado))
                            For Each p In listaProd
                                Dim det As New TDetalleCompra With {
                                    .ProductoID = p.ProductoID,
                                    .Cantidad = CInt(p.Cantidad),
                                    .PrecioUnitario = p.Precio,
                                    .Descuento = p.Descuento,
                                    .Subtotal = p.Total,
                                    .ModoCargo = If(p.ExG, String.Empty)
                                }
                                lista.Add(det)
                            Next
                            Return lista
                        End If
                    End If
                End If
            End If

            ' 2) Fallback reflexivo recursivo en todo el control (compatibilidad)
            Dim target = FindControlWithMethod(Me, "GetDetalleList")
            If target IsNot Nothing Then
                Dim miFallback = target.GetType().GetMethod("GetDetalleList", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If miFallback IsNot Nothing Then
                    Dim result = miFallback.Invoke(target, Nothing)
                    If result IsNot Nothing Then
                        If TypeOf result Is List(Of TDetalleCompra) Then
                            Return DirectCast(result, List(Of TDetalleCompra))
                        End If
                        If TypeOf result Is List(Of ProductoSeleccionado) Then
                            Dim listaProd = DirectCast(result, List(Of ProductoSeleccionado))
                            For Each p In listaProd
                                Dim det As New TDetalleCompra With {
                                    .ProductoID = p.ProductoID,
                                    .Cantidad = CInt(p.Cantidad),
                                    .PrecioUnitario = p.Precio,
                                    .Descuento = p.Descuento,
                                    .Subtotal = p.Total,
                                    .ModoCargo = If(p.ExG, String.Empty)
                                }
                                lista.Add(det)
                            Next
                            Return lista
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ' No romper la UI. Aquí podrías loguear el error si tienes un logger.
        End Try

        Return lista
    End Function

    ' Wrapper para compatibilidad con llamadas existentes
    Public Function GetDetalleList() As List(Of TDetalleCompra)
        Return GetDetalle()
    End Function

    Private Function FindControlWithMethod(parent As Control, methodName As String) As Control
        For Each c As Control In parent.Controls
            Try
                If c.GetType().GetMethod(methodName, BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic) IsNot Nothing Then
                    Return c
                End If
            Catch
            End Try
            If c.HasChildren Then
                Dim f = FindControlWithMethod(c, methodName)
                If f IsNot Nothing Then Return f
            End If
        Next
        Return Nothing
    End Function

End Class