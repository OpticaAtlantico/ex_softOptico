Imports System.Runtime.InteropServices.JavaScript.JSType
Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Class Repositorio_Proveedor
    Inherits Repositorio_Maestro
    Implements IRepositorio_Proveedor, IRepositorio_Generico(Of TProveedor)

    Private SeleccionarTodos As String
    Private SeleccionarPorID As String
    Private Insertar As String
    Private Actualizar As String
    Private Eliminar As String


#Region "CONSTRUCTOR"
    Sub New()
        SeleccionarTodos = "SELECT * FROM VProveedor"
        ' Assuming VEmpleados is a view that contains all necessary fields for TEmpleados.
        SeleccionarPorID = "SELECT * FROM VProveedor WHERE ProveedorID = @ProveedorID"
        ' Assuming VEmpleados is a view that contains all necessary fields for TEmpleados.
        Insertar = "INSERT INTO TProveedor (NombreEmpresa, RazonSocial, Contacto, Telefono, Rif, Correo, Direccion) 
                    VALUES (@NombreEmpresa, @RazonSocial, @Contacto, @Telefono, @Rif, @Correo, @Direccion)"
        ' Note: The Foto field is assumed to be a string path or URL; adjust as necessary for your application.
        Actualizar = "UPDATE TProveedor SET NombreEmpresa = @NombreEmpresa, RazonSocial = @RazonSocial, Contacto = @Contacto,
                      Telefono = @Telefono, Rif = @Rif, Correo = @Correo, Direccion = @Direccion"

        'eliminar empleado
        ' Assuming TEmpleados is the table where employee data is stored.
        Eliminar = "DELETE FROM TProveedores WHERE ProveedorID = @ProveedorID"
    End Sub

#End Region

#Region "METODOS DE LA INTERFAZ IRepositorio_Proveedor"
    Public Function ObtenerProveedor() As IEnumerable(Of TProveedor) Implements IRepositorio_Proveedor.ObtenerProveedor
        Return Me.GetAll()
    End Function

    Public Function BuscarProveedorPorNombre(nombre As String) As IEnumerable(Of TProveedor) Implements IRepositorio_Proveedor.BuscarProveedorPorNombre
        Dim query As String = "SELECT * FROM VProveedor WHERE NombreEmpresa LIKE @Nombre"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", "%" & nombre & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TProveedor)
        For Each row As DataRow In resultadoTable.Rows
            Dim proveedor As New TProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
            lista.Add(proveedor)
        Next
        Return lista
    End Function

    Public Function BuscarProveedorPorRIF(rif As String) As IEnumerable(Of TProveedor) Implements IRepositorio_Proveedor.BuscarProveedorPorRIF
        Dim query As String = "SELECT * FROM VProveedor WHERE Rif LIKE @Rif"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Rif", "%" & rif & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TProveedor)
        For Each row As DataRow In resultadoTable.Rows
            Dim proveedor As New TProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .rif = row("RIF").ToString(),
                .correo = row("correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
            lista.Add(proveedor)
        Next
        Return lista
    End Function

    Public Function BuscarProveedorPorID(id As Integer) As TProveedor Implements IRepositorio_Proveedor.BuscarProveedorPorID
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@ProveedorID", id)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorID)
        If resultadoTable.Rows.Count > 0 Then
            Dim row As DataRow = resultadoTable.Rows(0)
            Return New TProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
        End If
        Return Nothing
    End Function

    Public Function AgregarProveedor(proveedor As TProveedor) As Integer Implements IRepositorio_Proveedor.AgregarProveedor
        Return IRepositorio_Generico_Insertar(proveedor)
    End Function

    Public Function ActualizarProveedor(proveedor As TProveedor) As Integer Implements IRepositorio_Proveedor.ActualizarProveedor
        Return IRepositorio_Generico_Actualizar(proveedor)
    End Function

    Public Function EliminarProveedor(id As Integer) As Integer Implements IRepositorio_Proveedor.EliminarProveedor
        Return Remove(id)
    End Function

#End Region

#Region "MÉTODOS PRIVADOS"

    Public Function GetAll() As IEnumerable(Of TProveedor) Implements IRepositorio_Generico(Of TProveedor).GetAll
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarTodos)
        Dim lista = New List(Of TProveedor)
        For Each row As DataRow In resultadoTable.Rows
            Dim proveedor As New TProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
            lista.Add(proveedor)
        Next
        Return lista
    End Function

    Private Function IRepositorio_Generico_Insertar(entity As TProveedor) As Integer Implements IRepositorio_Generico(Of TProveedor).Add
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@NombreEmpresa", entity.nombreEmpresa),
            New SqlParameter("@RazonSocial", entity.razonSocial),
            New SqlParameter("@Contacto", entity.contacto),
            New SqlParameter("@Telefono", entity.telefono),
            New SqlParameter("@Rif", entity.rif),
            New SqlParameter("@Correo", entity.correo),
            New SqlParameter("@Direccion", entity.direccion)
        }
        Return ExecuteNonQuery(Insertar)
    End Function

    Private Function IRepositorio_Generico_Actualizar(entity As TProveedor) As Integer Implements IRepositorio_Generico(Of TProveedor).Edit
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@NombreEmpresa", entity.nombreEmpresa),
            New SqlParameter("@RazonSocial", entity.razonSocial),
            New SqlParameter("@Contacto", entity.contacto),
            New SqlParameter("@Telefono", entity.telefono),
            New SqlParameter("@Rif", entity.rif),
            New SqlParameter("@Correo", entity.correo),
            New SqlParameter("@Direccion", entity.direccion)
        }
        Return ExecuteNonQuery(Actualizar)
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TProveedor).Remove
        parameter = New List(Of SqlParameter) From {
                    New SqlParameter("@ProveedorID", id)
                }
        Return ExecuteNonQuery(Eliminar)
    End Function

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TProveedor) Implements IRepositorio_Generico(Of TProveedor).GetAllUserPass
        Throw New NotImplementedException()
    End Function



#End Region


End Class
