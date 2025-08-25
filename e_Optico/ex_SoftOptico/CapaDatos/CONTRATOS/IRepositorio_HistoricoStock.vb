Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.Data.SqlClient
Public Interface IRepositorio_HistoricoStock
    Function GetAll() As IEnumerable(Of VHistoricoStock)
    Function GetById(id As Integer) As VHistoricoStock
End Interface
