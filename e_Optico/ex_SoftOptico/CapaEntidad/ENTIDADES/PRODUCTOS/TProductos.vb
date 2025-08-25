Public Class TProductos
    Public Property ProductoID As Integer
    Public Property CodigoProducto As String
    Public Property Descripcion As String
    Public Property CategoriaID As Integer
    Public Property Material As Integer
    Public Property Color As Integer
    Public Property Foto As String
    Public Property Activo As Boolean = True
    Public Property RequiereInventario As Boolean = True ' Para servicios que no manejan stock

End Class
