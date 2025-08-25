Imports CapaEntidad

Public Class Repositorio_HistoricoStock
    Inherits Repositorio_Maestro
    Implements IRepositorio_HistoricoStock, IRepositorio_Generico(Of VHistoricoStock)


    Public Function GetById(id As Integer) As VHistoricoStock Implements IRepositorio_HistoricoStock.GetById
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As IEnumerable(Of VHistoricoStock) Implements IRepositorio_Generico(Of VHistoricoStock).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function Add(entity As VHistoricoStock) As Integer Implements IRepositorio_Generico(Of VHistoricoStock).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As VHistoricoStock) As Integer Implements IRepositorio_Generico(Of VHistoricoStock).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of VHistoricoStock).Remove
        Throw New NotImplementedException()
    End Function


    '-----------------------------------------
    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of VHistoricoStock) Implements IRepositorio_Generico(Of VHistoricoStock).GetAllUserPass
        Throw New NotImplementedException()
    End Function

    Private Function IRepositorio_HistoricoStock_GetAll() As IEnumerable(Of VHistoricoStock) Implements IRepositorio_HistoricoStock.GetAll
        Return GetAll()
    End Function
End Class
