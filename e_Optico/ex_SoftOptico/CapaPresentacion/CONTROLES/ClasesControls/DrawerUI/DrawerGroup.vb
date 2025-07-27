Public Class DrawerGroup
    Public Shared ReadOnly Compras As New DrawerGroup("Compras")
    Public Shared ReadOnly Ventas As New DrawerGroup("Ventas")
    Public Property TriggerButton As Button
    Public Property LeftOffset As Integer = 20
    Public Property TopOffset As Integer = 0

    Private Sub New(name As String)
        Me.Name = name
    End Sub
    Public ReadOnly Property Name As String
End Class
