Imports CapaEntidad

Public Interface IRepositorio_VProductos
    Inherits IRepositorio_Generico(Of VProductos)
    ' Para buscar un registro por usuario y contraseña
    Function ObtenerTodos() As IEnumerable(Of TVLogin)
    Function ObtenerProductoById(id As Integer) As String
End Interface
