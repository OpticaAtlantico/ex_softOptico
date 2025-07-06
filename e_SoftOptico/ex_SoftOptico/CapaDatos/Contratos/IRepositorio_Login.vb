Imports CapaEntidad

Public Interface IRepositorio_Login
    Inherits IRepositorio_Generico(Of tab_LOGIN)
    Function GetAllUsuarios() As IEnumerable(Of tab_LOGIN)
    'Function GetAllUserPass(user As String, pass As String) As Integer
End Interface
