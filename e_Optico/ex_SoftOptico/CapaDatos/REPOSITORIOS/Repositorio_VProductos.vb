
Imports Microsoft.Data.SqlClient
Imports CapaEntidad
Public Class Repositorio_VProductos
    Inherits Repositorio_Maestro
    Implements IRepositorio_VProductos

    Private SeleccionarProductos As String

    Public Sub New()
        SeleccionarProductos = "SELECT * FROM VProductos"
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

    Private Function IRepositorio_VProductos_ObtenerTodos() As IEnumerable(Of TVLogin) Implements IRepositorio_VProductos.ObtenerTodos
        Return GetAll()
    End Function
End Class
