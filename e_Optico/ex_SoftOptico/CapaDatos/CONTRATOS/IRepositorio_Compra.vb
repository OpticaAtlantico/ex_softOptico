Imports CapaEntidad

Public Interface IRepositorio_Compra
    Function GetAll() As IEnumerable(Of VCompras)
    Function GetDetalle(compraID As Integer) As IEnumerable(Of VDetalleCompras)
    Function GetById(compraID As Integer) As VCompras
    Function GetMax() As Integer
End Interface
