Public Class TProductos
    Public Property ProductoID As Integer
    Public Property CodigoProducto As String
    Public Property Descripcion As String
    Public Property CategoriaID As Integer
    Public Property PrecioVenta As Decimal
    Public Property CostoPromedio As Decimal 'Costo promedio ponderado
    Public Property Activo As Boolean = True
    Public Property Stock As Integer
    Public Property RequiereInventario As Boolean = True ' Para servicios que no manejan stock

End Class
