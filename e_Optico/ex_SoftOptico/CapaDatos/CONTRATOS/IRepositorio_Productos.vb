Imports CapaEntidad

Public Interface IRepositorio_Productos
    Function GetAll() As IEnumerable(Of VProductos)
    Function GetById(id As Integer) As String
End Interface
