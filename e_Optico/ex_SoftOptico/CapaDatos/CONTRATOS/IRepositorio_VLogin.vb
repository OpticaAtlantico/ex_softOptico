Imports CapaEntidad

Public Interface IRepositorio_VLogin
    Inherits IRepositorio_Generico(Of VLogin)
    ' Para buscar un registro por usuario y contraseña
    Function GetUserPass(usuario As String, clave As String) As IEnumerable(Of VLogin)
End Interface

