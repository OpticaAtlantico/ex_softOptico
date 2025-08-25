Imports CapaEntidad

Public Interface IRepositorio_Precios
    Function GetAll() As IEnumerable(Of VPrecios)
    Function GetById(id As Integer) As VPrecios
End Interface
