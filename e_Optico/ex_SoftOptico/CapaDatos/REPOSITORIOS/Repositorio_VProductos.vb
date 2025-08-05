
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
        'Return ExecuteReader(SeleccionarProductos).AsEnumerable().Select(Function(row) New TVProductos With {
        '    .ProductoID = Convert.ToInt32(row("ProductoID")),
        '    .Nombre = Convert.ToString(row("Nombre")),
        '    .Descripcion = Convert.ToString(row("Descripcion")),
        '    .Precio = Convert.ToDecimal(row("Precio")),
        '    .Stock = Convert.ToInt32(row("Stock")),
        '    .Categoria = Convert.ToString(row("Categoria"))
        '})
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
