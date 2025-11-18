Imports CapaEntidad
Imports System.Reflection

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

    ' Busca recursivamente un control hijo que implemente el método GetDetalleList y lo invoca.
    ' Devuelve List(Of TDetalleCompra) mapeado desde ProductoSeleccionado (incluye ProductoID).
    Public Function GetDetalleList() As List(Of TDetalleCompra)
        Dim lista As New List(Of TDetalleCompra)()
        Try
            Dim target = FindControlWithMethod(Me, "GetDetalleList")
            If target IsNot Nothing Then
                Dim mi = target.GetType().GetMethod("GetDetalleList", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If mi IsNot Nothing Then
                    Dim result = mi.Invoke(target, Nothing)
                    If result IsNot Nothing Then
                        ' Si el control devuelve List(Of TDetalleCompra) - usar directamente
                        If TypeOf result Is List(Of TDetalleCompra) Then
                            Return DirectCast(result, List(Of TDetalleCompra))
                        End If
                        ' Si devuelve List(Of ProductoSeleccionado) -> mapear usando ProductoID
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
            ' Ignorar y devolver lista vacía
        End Try
        Return lista
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
