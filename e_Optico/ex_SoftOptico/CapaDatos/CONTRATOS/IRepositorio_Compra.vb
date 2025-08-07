Imports CapaEntidad

Public Interface IRepositorio_Compra
    Function GetAllCompras() As IEnumerable(Of TCompra)
    Function AddCompra(compra As TCompra) As Integer
    Function UpdateCompra(compra As TCompra) As Integer
    Function DeleteCompra(compraID As Integer) As Integer
    Function GetById(compraID As Integer) As TCompra
End Interface
