Imports System.Data.SqlClient

Public Class Repositorio_Maestro
    Inherits Repositorio

    Protected parameter As List(Of SqlParameter)

    'lista para agregar, modificar y eliminar datos
    Protected Function ExecuteNomQuery(transacSql As String) As Integer
        Using coneccion = GetConnection()
            coneccion.Open()
            Using command = New SqlCommand()
                command.Connection = coneccion
                command.CommandText = transacSql
                command.CommandType = CommandType.Text
                For Each item As SqlParameter In parameter
                    command.Parameters.Add(item)
                Next
                Dim resultado = command.ExecuteNonQuery()
                parameter.Clear()
                Return resultado
            End Using
        End Using
    End Function

    'Lista para solo consultar datos
    Protected Function ExcecuteReader(transacSql As String) As DataTable
        Using coneccion = GetConnection()
            coneccion.Open()
            Using command = New SqlCommand()
                command.Connection = coneccion
                command.CommandText = transacSql
                command.CommandType = CommandType.Text
                Dim reader = command.ExecuteReader()
                Using table = New DataTable()
                    table.Load(reader)
                    reader.Dispose()
                    Return table
                End Using
            End Using
        End Using
    End Function

    Protected Function ExcecuteReaderUsePass(transacSql As String, user As String, pass As String) As DataTable
        Using coneccion = GetConnection()
            coneccion.Open()
            Using command = New SqlCommand()
                command.Connection = coneccion
                command.CommandText = transacSql
                For Each item As SqlParameter In parameter
                    command.Parameters.Add(item)
                Next
                'command.Parameters.AddWithValue("@Usuario", user)
                'command.Parameters.AddWithValue("@Pass", pass)
                command.CommandType = CommandType.Text
                Dim reader = command.ExecuteReader()
                Using table = New DataTable()
                    table.Load(reader)
                    reader.Dispose()
                    Return table
                End Using
            End Using
        End Using
    End Function

End Class

