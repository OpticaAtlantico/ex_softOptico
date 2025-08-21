Imports System.Runtime.InteropServices.JavaScript.JSType
Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Class Repositorio_Proveedor
    Inherits Repositorio_Maestro
    Implements IRepositorio_Proveedor, IRepositorio_Generico(Of TProveedor)

    Private SeleccionarTodos As String
    Private SeleccionarPorID As String
    Private SeleccionarPorRif As String
    Private SeleccionarPorNombre As String
    Private Insertar As String
    Private Actualizar As String
    Private Eliminar As String

#Region "CONSTRUCTOR"
    Sub New()
        SeleccionarTodos = "SELECT * FROM VProveedor"
        SeleccionarPorID = "SELECT * FROM VProveedor WHERE ProveedorID = @ProveedorID"
        SeleccionarPorRif = "SELECT * FROM VProveedor WHERE Rif = @Rif"
        SeleccionarPorNombre = "SELECT * FROM VProveedor WHERE NombreEmpresa LIKE @Nombre"
        Insertar = "INSERT INTO TProveedor (NombreEmpresa, RazonSocial, Contacto, Telefono, Siglas, Rif, Correo, Direccion) 
                    VALUES (@NombreEmpresa, @RazonSocial, @Contacto, @Telefono, @Siglas, @Rif, @Correo, @Direccion)"

        Actualizar = "UPDATE TProveedor SET NombreEmpresa = @NombreEmpresa, RazonSocial = @RazonSocial, Contacto = @Contacto,
                      Telefono = @Telefono, Siglas = @Siglas, Rif = @Rif, Correo = @Correo, Direccion = @Direccion
                      WHERE ProveedorID = @ProveedorID"

        Eliminar = "DELETE FROM TProveedor WHERE ProveedorID = @ProveedorID"
    End Sub

    Public Function GetAlls() As IEnumerable(Of VProveedor) Implements IRepositorio_Proveedor.GetAlls
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarTodos)
        Dim lista As New List(Of VProveedor)
        For Each row As DataRow In resultadoTable.Rows
            Dim proveedor As New VProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .siglas = [Enum].GetName(GetType(Siglas), Convert.ToInt32(row("Siglas"))),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
            lista.Add(proveedor)
        Next
        Return lista

    End Function

    Public Function GetAllByRif(rif As String) As IEnumerable(Of VProveedor) Implements IRepositorio_Proveedor.GetAllByRif
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Rif", "%" & rif & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorRif)
        Dim lista As New List(Of VProveedor)
        For Each row As DataRow In resultadoTable.Rows
            Dim proveedor As New VProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .siglas = [Enum].GetName(GetType(Siglas), Convert.ToInt32(row("Siglas"))),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
            lista.Add(proveedor)
        Next
        Return lista
    End Function

    Public Function GetAllByNombre(nombre As String) As IEnumerable(Of VProveedor) Implements IRepositorio_Proveedor.GetAllByNombre
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", "%" & nombre & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorNombre)
        Dim lista As New List(Of VProveedor)
        For Each row As DataRow In resultadoTable.Rows
            Dim proveedor As New VProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .siglas = [Enum].GetName(GetType(Siglas), Convert.ToInt32(row("Siglas"))),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
            lista.Add(proveedor)
        Next
        Return lista
    End Function

    Public Function GetById(id As Integer) As VProveedor Implements IRepositorio_Proveedor.GetById
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@ProveedorID", id)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorID)
        If resultadoTable.Rows.Count > 0 Then
            Dim row As DataRow = resultadoTable.Rows(0)
            Return New VProveedor With {
                .ProveedorID = Convert.ToInt32(row("ProveedorID")),
                .nombreEmpresa = row("NombreEmpresa").ToString(),
                .razonSocial = row("RazonSocial").ToString(),
                .contacto = row("Contacto").ToString(),
                .telefono = row("Telefono").ToString(),
                .siglas = [Enum].GetName(GetType(Siglas), Convert.ToInt32(row("Siglas"))),
                .rif = row("Rif").ToString(),
                .correo = row("Correo").ToString(),
                .direccion = row("Direccion").ToString()
            }
        End If
        Return Nothing
    End Function



    Public Function Add(entity As TProveedor) As Integer Implements IRepositorio_Generico(Of TProveedor).Add
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@NombreEmpresa", entity.nombreEmpresa),
            New SqlParameter("@RazonSocial", entity.razonSocial),
            New SqlParameter("@Contacto", entity.contacto),
            New SqlParameter("@Telefono", entity.telefono),
            New SqlParameter("@Siglas", entity.siglas),
            New SqlParameter("@Rif", entity.rif),
            New SqlParameter("@Correo", entity.correo),
            New SqlParameter("@Direccion", entity.direccion)
        }
        Return ExecuteNonQuery(Insertar)
    End Function

    Public Function Edit(entity As TProveedor) As Integer Implements IRepositorio_Generico(Of TProveedor).Edit
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@ProveedorID", entity.ProveedorID),
            New SqlParameter("@NombreEmpresa", entity.nombreEmpresa),
            New SqlParameter("@RazonSocial", entity.razonSocial),
            New SqlParameter("@Contacto", entity.contacto),
            New SqlParameter("@Telefono", entity.telefono),
            New SqlParameter("@Siglas", entity.siglas),
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

    '----------------------------------------------------------------

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TProveedor) Implements IRepositorio_Generico(Of TProveedor).GetAllUserPass
        Throw New NotImplementedException()
    End Function
    Public Function GetAll() As IEnumerable(Of TProveedor) Implements IRepositorio_Generico(Of TProveedor).GetAll
        Throw New NotImplementedException()
    End Function
#End Region

#Region "METODOS DE LA INTERFAZ IRepositorio_Proveedor"




#End Region


End Class
