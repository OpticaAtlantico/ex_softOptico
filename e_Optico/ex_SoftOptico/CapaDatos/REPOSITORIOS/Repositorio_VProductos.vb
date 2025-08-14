
Imports Microsoft.Data.SqlClient
Imports CapaEntidad
Imports Microsoft.Data
Imports CapaDatos
Public Class Repositorio_VProductos
    Inherits Repositorio_Maestro
    Implements IRepositorio_VProductos

    Private SeleccionarProductos As String
    Private SeleccionarProductosById As String

    Public Sub New()
        SeleccionarProductos = "SELECT * FROM VProductos"
        SeleccionarProductosById = "SELECT Nombre FROM VProductos WHERE Codigo = @ProductoID"
    End Sub

    Public Function GetAll() As IEnumerable(Of TVProductos) Implements IRepositorio_Generico(Of TVProductos).GetAll
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarProductos)
        Dim lista = New List(Of TVProductos)
        For Each row As DataRow In resultadoTable.Rows
            Dim producto As New TVProductos With {
                .Codigo = If(row("Codigo") IsNot DBNull.Value, row("Codigo").ToString(), String.Empty),
                .Nombre = If(row("Nombre") IsNot DBNull.Value, row("Nombre").ToString(), String.Empty),
                .Precio = If(row("Precio") IsNot DBNull.Value, Convert.ToDecimal(row("Precio")), 0D),
                .Categoria = If(row("Categoria") IsNot DBNull.Value, row("Categoria").ToString(), String.Empty),
                .SubCategoria = If(row("SubCategoria") IsNot DBNull.Value, row("SubCategoria").ToString(), String.Empty),
                .Stock = If(row("Stock") IsNot DBNull.Value, Convert.ToInt32(row("Stock")), 0),
                .CategoriaID = If(row("CategoriaID") IsNot DBNull.Value, Convert.ToInt32(row("CategoriaID")), 0)
            }
            lista.Add(producto)
        Next
        Return lista
    End Function

    Public Function Add(entity As TVProductos) As Integer Implements IRepositorio_Generico(Of TVProductos).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As TVProductos) As Integer Implements IRepositorio_Generico(Of TVProductos).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TVProductos).Remove
        Throw New NotImplementedException()
    End Function

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TVProductos) Implements IRepositorio_Generico(Of TVProductos).GetAllUserPass
        Throw New NotImplementedException()
    End Function

    Public Function ObtenerProductoById(id As Integer) As String Implements IRepositorio_VProductos.ObtenerProductoById
        Dim nombreProducto As String = String.Empty

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()
            Using tran As SqlTransaction = conn.BeginTransaction()
                Try
                    Using cmdComp As New SqlCommand(SeleccionarProductosById, conn, tran)
                        cmdComp.Parameters.AddWithValue("@ProductoID", id)
                        Dim result = cmdComp.ExecuteScalar()
                        If result IsNot Nothing Then
                            nombreProducto = result.ToString()
                        End If
                    End Using

                    tran.Commit()
                    Return nombreProducto
                Catch ex As Exception
                    tran.Rollback()
                    Throw
                End Try
            End Using
        End Using

    End Function

    Private Function IRepositorio_VProductos_ObtenerTodos() As IEnumerable(Of TVLogin) Implements IRepositorio_VProductos.ObtenerTodos
        Return GetAll()
    End Function

    Public Function ObtenerNombreProducto(productoID As Integer) As String
        Dim repo As New Repositorio_VProductos
        Return repo.ObtenerProductoById(productoID)
    End Function

End Class
