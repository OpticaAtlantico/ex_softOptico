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
    Public Function GetDetalleList() As List(Of ProductoSeleccionado)
        Dim lista As New List(Of ProductoSeleccionado)()
        Try
            Dim target = FindControlWithMethod(Me, "GetDetalleList")
            If target IsNot Nothing Then
                Dim mi = target.GetType().GetMethod("GetDetalleList", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If mi IsNot Nothing Then
                    Dim result = mi.Invoke(target, Nothing)
                    If result IsNot Nothing AndAlso TypeOf result Is List(Of ProductoSeleccionado) Then
                        Return DirectCast(result, List(Of ProductoSeleccionado))
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
