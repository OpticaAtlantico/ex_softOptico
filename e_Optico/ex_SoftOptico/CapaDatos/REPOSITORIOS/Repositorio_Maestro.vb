Imports Microsoft.Data.SqlClient

Public Class Repositorio_Maestro
    Inherits Repositorio

    Protected parameter As List(Of SqlParameter)

    'lista para agregar, modificar y eliminar datos
    Protected Function ExecuteNonQuery(transacSql As String) As Integer
        Using coneccion = ObtenerConexion() 'Solicitud de conexión a la base de datos en Repositorio
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
        Using coneccion = ObtenerConexion() 'Solicitud de conexión a la base de datos en Repositorio
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

    Protected Function ExcecuteReaderUserPass(transacSql As String, user As String, pass As String) As DataTable
        Using conexion = ObtenerConexion()
            conexion.Open()
            Using command = New SqlCommand()
                command.Connection = conexion
                command.CommandText = transacSql
                command.CommandType = CommandType.Text

                ' Limpia por seguridad
                command.Parameters.Clear()

                ' Agrega parámetros pasados
                For Each item As SqlParameter In parameter
                    If Not command.Parameters.Contains(item.ParameterName) Then
                        command.Parameters.Add(item)
                    End If
                Next

                ' Agrega los parámetros adicionales si no están
                If Not command.Parameters.Contains("@Usuario") Then
                    command.Parameters.AddWithValue("@Usuario", user)
                End If

                If Not command.Parameters.Contains("@Pass") Then
                    command.Parameters.AddWithValue("@Pass", pass)
                End If

                ' Ejecutar y cargar los resultados
                Using reader = command.ExecuteReader()
                    Dim table As New DataTable()
                    table.Load(reader)
                    Return table
                End Using
            End Using
        End Using
    End Function
End Class
