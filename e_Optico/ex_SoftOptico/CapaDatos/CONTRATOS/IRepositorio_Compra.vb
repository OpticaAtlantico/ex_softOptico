Imports CapaEntidad

Public Interface IRepositorio_Compra
    Function GetAll() As IEnumerable(Of VCompras)
    Function GetDetalle(compraID As Integer) As IEnumerable(Of VDetalleCompras)
    Function Add(compra As TCompra) As Integer
    Function Update(compra As TCompra) As Boolean
    Function Delete(compraID As Integer) As Boolean
    Function GetById(compraID As Integer) As VCompras
End Interface
