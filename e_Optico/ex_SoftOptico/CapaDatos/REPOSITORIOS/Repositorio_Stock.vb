Imports CapaEntidad
Imports Microsoft.Data
Imports Microsoft.Data.SqlClient
Public Class Repositorio_Stock
    Inherits Repositorio_Maestro
    Implements IRepositorio_Stock, IRepositorio_Generico(Of VStock)

    Public Function GetAll() As IEnumerable(Of VCompras) Implements IRepositorio_Stock.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function GetById(compraID As Integer) As VCompras Implements IRepositorio_Stock.GetById
        Throw New NotImplementedException()
    End Function

    Public Function Add(entity As VStock) As Integer Implements IRepositorio_Generico(Of VStock).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As VStock) As Integer Implements IRepositorio_Generico(Of VStock).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of VStock).Remove
        Throw New NotImplementedException()
    End Function


    '-----------------------------------------------------

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of VStock) Implements IRepositorio_Generico(Of VStock).GetAllUserPass
        Throw New NotImplementedException()
    End Function

    Private Function IRepositorio_Generico_GetAll() As IEnumerable(Of VStock) Implements IRepositorio_Generico(Of VStock).GetAll
        Throw New NotImplementedException()
    End Function
End Class
