Imports CapaEntidad
Public Interface IRepositorio_Proveedor
    Function GetAlls() As IEnumerable(Of VProveedor)
    Function GetAllByRif(rif As String) As IEnumerable(Of VProveedor)
    Function GetAllByNombre(nombre As String) As IEnumerable(Of VProveedor)
    Function GetById(id As Integer) As VProveedor
End Interface
