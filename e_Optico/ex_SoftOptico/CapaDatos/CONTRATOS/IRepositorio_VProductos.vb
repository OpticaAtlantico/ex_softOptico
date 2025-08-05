Imports CapaEntidad

Public Interface IRepositorio_VProductos
    Inherits IRepositorio_Generico(Of TVProductos)
    ' Para buscar un registro por usuario y contraseña
    Function ObtenerTodos() As IEnumerable(Of TVLogin)
End Interface
