Imports System.IO
Imports CapaDatos
Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Class ServiceProveedor
    Private ReadOnly _repo As Repositorio_Proveedor

    Public Sub New()
        _repo = New Repositorio_Proveedor()
    End Sub

#Region "Guardar"
    Public Function Guardar(proveedor As TProveedor) As Boolean
        ValidarProveedor(proveedor, esNuevo:=True)

        Try
            Return _repo.Add(proveedor)
        Catch ex As SqlException
            Dim mensaje As String = SqlExceptionUI.ObtenerMensajeSql(ex)
            Throw New Exception(mensaje)
        End Try
    End Function
#End Region

#Region "Actualizar"
    Public Function Actualizar(proveedor As TProveedor) As Boolean
        If proveedor.ProveedorID <= 0 Then
            Throw New Exception("El ID de empleado es inválido.")
        End If

        ValidarProveedor(proveedor, esNuevo:=False)
        Return _repo.Edit(proveedor)
    End Function
#End Region

#Region "Eliminar"
    '=== Eliminar empleado y su foto ===
    Public Function Eliminar(proveedorId As Integer) As Boolean
        Try
            ' 1. Eliminar de la base de datos
            Dim eliminado As Boolean = _repo.Remove(proveedorId)

            Return eliminado

        Catch ex As Exception
            ' Aquí no mostramos MessageBox, dejamos que la UI lo maneje
            Throw New Exception("Error al eliminar proveedor", ex)
        End Try
    End Function
#End Region

#Region "Consultas"
    Public Function ObtenerPorId(id As Integer) As VProveedor
        If id <= 0 Then Throw New Exception("El ID es inválido.")
        Return _repo.GetById(id)
    End Function

    Public Function Listar() As List(Of TProveedor)
        Return _repo.GetAll()
    End Function
#End Region

#Region "Validaciones"
    Private Sub ValidarProveedor(proveedor As TProveedor, esNuevo As Boolean)
        If proveedor Is Nothing Then Throw New ArgumentNullException(NameOf(proveedor))

        If String.IsNullOrWhiteSpace(proveedor.nombreEmpresa) Then Throw New Exception("El nombre de la empresa es obligatoria.")
        If String.IsNullOrWhiteSpace(proveedor.razonSocial) Then Throw New Exception("La razón social es obligatorio.")
        If String.IsNullOrWhiteSpace(proveedor.sigla) Then Throw New Exception("La sigla es obligatorio.")
        If String.IsNullOrWhiteSpace(proveedor.rif) Then Throw New Exception("El rif es obligatorio.")
        If String.IsNullOrWhiteSpace(proveedor.correo) OrElse Not proveedor.correo.Contains("@") Then Throw New Exception("Correo electrónico inválido.")
        If String.IsNullOrWhiteSpace(proveedor.telefono) Then Throw New Exception("El teléfono es obligatorio.")
        If String.IsNullOrWhiteSpace(proveedor.contacto) Then Throw New Exception("El teléfono de contacto es obligatorio.")
        If String.IsNullOrWhiteSpace(proveedor.direccion) Then Throw New Exception("La dirección de domicilio es obligatorio.")

    End Sub
#End Region

End Class
