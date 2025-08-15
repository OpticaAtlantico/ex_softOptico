Imports CapaEntidad
Imports CapaDatos

Public Class ComprasService
    Private ReadOnly _repo As IRepositorio_Compra

    Public Sub New()
        _repo = New Repositorio_Compra() ' o inyecta vía constructor para tests
    End Sub

    Public Function RegistrarCompra(compra As TCompra) As Integer
        ' Validaciones de negocio
        If compra Is Nothing Then Throw New ArgumentNullException(NameOf(compra))
        If compra.ProveedorID <= 0 Then Throw New Exception("Seleccione un proveedor.")
        If compra.Detalle Is Nothing OrElse compra.Detalle.Count = 0 Then Throw New Exception("Agregue al menos un producto.")
        If compra.TotalCompra <= 0 Then Throw New Exception("Total inválido.")

        ' Podrías validar stock, precios, límites, etc. aquí antes de guardar.

        ' Guardar (retorna el ID)
        Return _repo.Add(compra)
    End Function

    Public Function ActualizarCompra(compra As TCompra) As Integer
        ' Validaciones de negocio
        If compra Is Nothing Then Throw New ArgumentNullException(NameOf(compra))
        If compra.ProveedorID <= 0 Then Throw New Exception("Seleccione un proveedor.")
        If compra.Detalle Is Nothing OrElse compra.Detalle.Count = 0 Then Throw New Exception("Agregue al menos un producto.")
        If compra.TotalCompra <= 0 Then Throw New Exception("Total inválido.")

        ' Podrías validar stock, precios, límites, etc. aquí antes de guardar.

        ' Guardar (retorna el ID)
        Return _repo.Update(compra)
    End Function
End Class
