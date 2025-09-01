Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Class Repositorio_Productos
    Inherits Repositorio_Maestro
    Implements IRepositorio_Productos, IRepositorio_Generico(Of VProductos)

    Private SeleccionarProductos As String
    Private SeleccionarProductosById As String
    Public Sub New()
        SeleccionarProductos = "SELECT * FROM VProductos"
        SeleccionarProductosById = "SELECT Nombre FROM VProductos WHERE Codigo = @ProductoID"
    End Sub

    Public Function GetAll() As IEnumerable(Of VProductos) Implements IRepositorio_Productos.GetAll
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarProductos)
        Dim lista = New List(Of VProductos)
        For Each row As DataRow In resultadoTable.Rows
            Dim producto As New VProductos With {
                ._codigo = If(row("Codigo") IsNot DBNull.Value, row("Codigo").ToString(), String.Empty),
                ._nombre = If(row("Nombre") IsNot DBNull.Value, row("Nombre").ToString(), String.Empty),
                ._precio_Venta = 0,
                ._categoria = If(row("Categoria") IsNot DBNull.Value, row("Categoria").ToString(), String.Empty),
                ._subCategoria = If(row("SubCategoria") IsNot DBNull.Value, row("SubCategoria").ToString(), String.Empty),
                ._stock = If(row("Stock") IsNot DBNull.Value, Convert.ToInt32(row("Stock")), 0),
                ._categoriaID = If(row("CategoriaID") IsNot DBNull.Value, Convert.ToInt32(row("CategoriaID")), 0)
            }
            lista.Add(producto)
        Next
        Return lista
    End Function

    Public Function GetById(id As Integer) As String Implements IRepositorio_Productos.GetById
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

    Public Function Add(entity As VProductos) As Integer Implements IRepositorio_Generico(Of VProductos).Add
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As VProductos) As Integer Implements IRepositorio_Generico(Of VProductos).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of VProductos).Remove
        Throw New NotImplementedException()
    End Function

    '--------------------------------------------------------------------

    Private Function IRepositorio_Generico_GetAll() As IEnumerable(Of VProductos) Implements IRepositorio_Generico(Of VProductos).GetAll
        Return GetAll()
    End Function
End Class
