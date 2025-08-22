Public Class VCompras
    Public Property _compraID As Integer
    Public Property _ordenCompra As Integer
    Public Property _fecha As Date
    Public Property _nControl As String
    Public Property _nFactura As String
    Public Property _subTotal As Decimal
    Public Property _observacion As String
    Public Property _sucursal As String
    Public Property _proveedor As String
    Public Property _razonSocial As String
    Public Property _telefono As String
    Public Property _contacto As String
    Public Property _direccion As String
    Public Property _correo As String
    Public Property _rif As String
    Public Property _iVA As String
    Public Property _tPago As String
    Public Property _detalle As List(Of VDetalleCompras)
End Class


