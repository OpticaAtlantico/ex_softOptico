Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Interface IRepositorio_Stock
    Function GetAll() As IEnumerable(Of VCompras)
    Function GetById(compraID As Integer) As VCompras
End Interface
