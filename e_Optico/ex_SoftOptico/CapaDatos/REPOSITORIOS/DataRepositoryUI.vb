Imports System.Data
Imports Microsoft.Data.SqlClient

Public Class DataRepositoryUI

    Private ReadOnly grupoSQL As String
    Private ReadOnly cadenaConexion As String

    Public Event OnError(msg As String)

    Public Sub New(grupo As String, conexion As String)
        grupoSQL = grupo
        cadenaConexion = conexion
    End Sub

    Public Function EjecutarSP(nombreSP As String, parametros As SqlParameter()) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As New SqlConnection(cadenaConexion)
                Using cmd As New SqlCommand(nombreSP, conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddRange(parametros)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            RaiseEvent OnError($"[{grupoSQL}] Error en SP: {ex.Message}")
        End Try

        Return dt
    End Function

End Class