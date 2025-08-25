Imports CapaEntidad

Public Class Repositorio_Precios
    Inherits Repositorio_Maestro
    Implements IRepositorio_Precios, IRepositorio_Generico(Of VPrecios)

    Public Function GetAll() As IEnumerable(Of VPrecios) Implements IRepositorio_Precios.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(id As Integer) As VPrecios Implements IRepositorio_Precios.GetById
        Throw New NotImplementedException()
    End Function

    Public Function Add(entity As VPrecios) As Integer Implements IRepositorio_Generico(Of VPrecios).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As VPrecios) As Integer Implements IRepositorio_Generico(Of VPrecios).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of VPrecios).Remove
        Throw New NotImplementedException()
    End Function

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of VPrecios) Implements IRepositorio_Generico(Of VPrecios).GetAllUserPass
        Throw New NotImplementedException()
    End Function

    Private Function IRepositorio_Generico_GetAll() As IEnumerable(Of VPrecios) Implements IRepositorio_Generico(Of VPrecios).GetAll
        Return GetAll()
    End Function
End Class
