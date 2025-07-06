Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.EntityFrameworkCore.Diagnostics

Public Class UserDao
    Inherits ConexionSQL

    Public Function Login(usuario As String, pass As String) As Boolean
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "SELECT * FROM V_LOGIN WHERE Usuario=@Usuario and Clave=@Pass"
                command.Parameters.AddWithValue("@Usuario", usuario)
                command.Parameters.AddWithValue("@Pass", pass)
                command.CommandType = CommandType.Text
                Dim reader = command.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read()
                        ActiveUser.Cedula = reader.GetString(0)
                        ActiveUser.Nombre = reader.GetString(1)
                        ActiveUser.Posicion = reader.GetString(2)
                        ActiveUser.Usuario = reader.GetString(3)
                        ActiveUser.Clave = reader.GetString(4)
                        ActiveUser.Estado = reader.GetBoolean(5)
                    End While
                    Return True
                Else
                    Return False
                End If
            End Using
        End Using
    End Function

    Public Sub EditLogin(rol As Integer, empleado As Integer, usuario As String, clave As String, estado As Byte)
        Using connection = GetConnection()
            connection.Open()
            Using command = New SqlCommand()
                command.Connection = connection
                command.CommandText = "Update tab_LOGIN SET IdRol = @Rol, IdEmpleado = @Empleado, Usuario = @Usuario, Clave = @Clave, Estado = @Estado "
                command.Parameters.AddWithValue("@Rol", rol)
                command.Parameters.AddWithValue("@Empleado", empleado)
                command.Parameters.AddWithValue("@Usuario", usuario)
                command.Parameters.AddWithValue("@Clave", clave)
                command.Parameters.AddWithValue("@Estado", estado)
                command.CommandType = CommandType.Text
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
