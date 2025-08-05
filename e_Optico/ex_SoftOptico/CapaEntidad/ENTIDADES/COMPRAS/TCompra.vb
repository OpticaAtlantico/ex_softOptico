Public Class TCompra
    Public Property CompraID As Integer
    Public Property FechaCompra As Date
    Public Property NumeroControl As String
    Public Property NumeroFactura As String
    Public Property TipoPagoID As Integer
    Public Property AlicuotaID As Integer
    Public Property ProveedorID As Integer
    Public Property EmpleadoID As Integer
    Public Property UbicacionDestinoID As Integer
    Public Property TotalCompra As Decimal
    Public Property Observacion As String
    Public Property Estado As String = "Completada"
    Public Property Detalle As List(Of TDetalleCompra)
End Class
