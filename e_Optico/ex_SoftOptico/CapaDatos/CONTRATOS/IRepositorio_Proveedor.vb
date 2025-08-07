Imports CapaEntidad
Public Interface IRepositorio_Proveedor
    Function ObtenerProveedor() As IEnumerable(Of TProveedor)
    Function BuscarProveedorPorRIF(rif As String) As IEnumerable(Of TProveedor)
    Function BuscarProveedorPorID(id As Integer) As TProveedor
    Function AgregarProveedor(proveedor As TProveedor) As Integer
    Function ActualizarProveedor(proveedor As TProveedor) As Integer
    Function EliminarProveedor(id As Integer) As Integer
End Interface
