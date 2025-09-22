Imports System.IO
Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Class ServiceEmpleado
    Private ReadOnly _repo As Repositorio_Empleados

    Public Sub New()
        _repo = New Repositorio_Empleados()
    End Sub

#Region "Guardar"
    Public Function Guardar(empleado As TEmpleados) As Boolean
        ValidarEmpleado(empleado, esNuevo:=True)

        Try
            Return _repo.Add(empleado)
        Catch ex As SqlException
            Dim mensaje As String = SqlExceptionUI.ObtenerMensajeSql(ex)
            Throw New Exception(mensaje)
        End Try
    End Function
#End Region

#Region "Actualizar"
    Public Function Actualizar(empleado As TEmpleados) As Boolean
        If empleado.EmpleadoID <= 0 Then
            Throw New Exception("El ID de empleado es inválido.")
        End If

        ValidarEmpleado(empleado, esNuevo:=False)
        Return _repo.Edit(empleado)
    End Function
#End Region

#Region "Eliminar"
    '=== Eliminar empleado y su foto ===
    Public Function Eliminar(empleadoId As Integer, rutaFoto As String) As Boolean
        Try
            ' 1. Eliminar de la base de datos
            Dim eliminado As Boolean = _repo.Remove(empleadoId)

            If eliminado Then
                ' 2. Eliminar la imagen asociada si existe
                If Not String.IsNullOrWhiteSpace(rutaFoto) Then
                    Dim rutaAbsoluta As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaFoto)

                    If File.Exists(rutaAbsoluta) Then
                        Try
                            File.Delete(rutaAbsoluta)
                        Catch ex As IOException
                            ' Lógica de negocio -> devolvemos False, UI decidirá el mensaje
                            Return False
                        End Try
                    End If
                End If
            End If

            Return eliminado

        Catch ex As Exception
            ' Aquí no mostramos MessageBox, dejamos que la UI lo maneje
            Throw New Exception("Error al eliminar empleado", ex)
        End Try
    End Function
#End Region

#Region "Consultas"
    Public Function ObtenerPorId(id As Integer) As VEmpleados
        If id <= 0 Then Throw New Exception("El ID es inválido.")
        Return _repo.GetById(id)
    End Function

    Public Function Listar() As List(Of TEmpleados)
        Return _repo.GetAll()
    End Function
#End Region

#Region "Validaciones"
    Private Sub ValidarEmpleado(emp As TEmpleados, esNuevo As Boolean)
        If emp Is Nothing Then Throw New ArgumentNullException(NameOf(emp))

        If String.IsNullOrWhiteSpace(emp.Cedula) Then Throw New Exception("La cédula es obligatoria.")
        If String.IsNullOrWhiteSpace(emp.Nombre) Then Throw New Exception("El nombre es obligatorio.")
        If String.IsNullOrWhiteSpace(emp.Apellido) Then Throw New Exception("El apellido es obligatorio.")
        If String.IsNullOrWhiteSpace(emp.Correo) OrElse Not emp.Correo.Contains("@") Then Throw New Exception("Correo electrónico inválido.")
        If Not Integer.TryParse(emp.Edad, Nothing) OrElse Convert.ToInt32(emp.Edad) <= 0 Then Throw New Exception("La edad debe ser un número válido mayor que cero.")
        If emp.FechaNacimiento = Date.MinValue Then Throw New Exception("Debe seleccionar una fecha de nacimiento.")
        If emp.Cargo <= 0 Then Throw New Exception("Seleccione un cargo válido.")
        If emp.Zona < 0 Then Throw New Exception("Seleccione una zona válida.")
        If emp.EstadoCivil < 0 Then Throw New Exception("Seleccione un estado civil válido.")
        If emp.Sexo < 0 Then Throw New Exception("Seleccione un sexo válido.")
        If emp.Nacionalidad < 0 Then Throw New Exception("Seleccione una nacionalidad válida.")

        If String.IsNullOrWhiteSpace(emp.Telefono) Then Throw New Exception("El teléfono es obligatorio.")

        ' Validación de foto opcional
        'If String.IsNullOrWhiteSpace(emp.Foto) Then Throw New Exception("Debe cargar una foto.")

    End Sub
#End Region

End Class
