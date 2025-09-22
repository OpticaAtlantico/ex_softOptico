Imports Microsoft.Data.SqlClient
Public Class Repositorio_Maestro
    Inherits Repositorio_Conexion

    Protected parameter As List(Of SqlParameter)

    'lista para agregar, modificar y eliminar datos
    Protected Function ExecuteNonQuery(transacSql As String) As Integer
        If String.IsNullOrWhiteSpace(transacSql) Then
            Throw New ArgumentException("El comando SQL no puede estar vacío.", NameOf(transacSql))
        End If

        Try
            Using conexion = ObtenerConexion()
                conexion.Open()

                Using comando As New SqlCommand(transacSql, conexion)
                    comando.CommandType = CommandType.Text

                    ' Validación defensiva de parámetros
                    If parameter IsNot Nothing AndAlso parameter.Count > 0 Then
                        For Each param As SqlParameter In parameter
                            comando.Parameters.Add(param)
                        Next
                    End If

                    Dim resultado As Integer = comando.ExecuteNonQuery()
                    parameter?.Clear()

                    Return resultado
                End Using
            End Using

        Catch ex As SqlException
            Throw
        Catch ex As Exception
            Throw
        End Try
    End Function

    Protected Function ExecuteReader(transacSql As String) As DataTable
        If String.IsNullOrWhiteSpace(transacSql) Then
            Throw New ArgumentException("La consulta SQL no puede estar vacía.", NameOf(transacSql))
        End If

        Try
            Using conexion = ObtenerConexion()
                conexion.Open()

                Using comando As New SqlCommand(transacSql, conexion)
                    comando.CommandType = CommandType.Text

                    ' Limpieza defensiva
                    comando.Parameters.Clear()

                    ' Carga de parámetros, evitando duplicados
                    If parameter IsNot Nothing AndAlso parameter.Count > 0 Then
                        For Each item As SqlParameter In parameter
                            If Not comando.Parameters.Contains(item.ParameterName) Then
                                comando.Parameters.Add(item)
                            End If
                        Next
                    End If

                    Using reader = comando.ExecuteReader()
                        Dim tablaResultado As New DataTable()
                        tablaResultado.Load(reader)
                        Return tablaResultado
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            Throw New Exception(SqlExceptionUI.ObtenerMensajeSql(ex))
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
