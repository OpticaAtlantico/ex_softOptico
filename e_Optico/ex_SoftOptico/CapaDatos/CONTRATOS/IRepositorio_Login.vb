Imports CapaEntidad

Public Interface IRepositorio_Login
    Inherits IRepositorio_Generico(Of TLogin)
    ' Para buscar un registro por usuario y contraseña
    Function GetAllUser() As IEnumerable(Of TLogin)

End Interface
