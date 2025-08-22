Imports CapaEntidad
Imports Microsoft.Data
Imports Microsoft.Data.SqlClient
Imports Microsoft.EntityFrameworkCore.Storage.ValueConversion
Imports System.Data

Public Class Repositorio_Compra
    Inherits Repositorio_Maestro
    Implements IRepositorio_Compra, IRepositorio_Generico(Of TCompra)

    Private Const SQL_INSERT_COMPRA As String = "
        INSERT INTO TCompras (OrdenCompra, FechaCompra, NumeroControl, NumeroFactura, TipoPagoID, AlicuotaID, ProveedorID, 
                EmpleadoID, UbicacionDestinoID, TotalCompra, Observacion)
        OUTPUT INSERTED.OrdenCompra
        VALUES (@OrdenCompra, @FechaCompra, @NumeroControl, @NumeroFactura, @TipoPagoID, @AlicuotaID, @ProveedorID, 
                @EmpleadoID, @UbicacionDestinoID, @TotalCompra, @Observacion);"

    Private Const SQL_INSERT_DETALLE As String = "
        INSERT INTO TDetalleCompra (OrdenCompra, ProductoID, Cantidad, CostoUnitario, SubTotal, ModoCargo)
        VALUES (@OrdenCompra, @ProductoID, @Cantidad, @CostoUnitario, @SubTotal, @ModoCargo);"

    Private Const SQL_UPDATE_COMPRA As String = "
        UPDATE TCompras SET OrdenCompra = @OrdenCompra, FechaCompra = @FechaCompra, NumeroFactura = @NumeroFactura, 
        TipoPagoID = @TipoPagoID, AlicuotaID = @AlicuotaID, ProveedorID = @ProveedorID, 
        EmpleadoID = @EmpleadoID, UbicacionDestinoID = @UbicacionDestinoID, TotalCompra = @TotalCompra, 
        Observacion = @Observacion WHERE OrdenCompra = @OrdenCompra;"

    Private Const SQL_UPDATE_DETALLE As String = "
        INSERT INTO TDetalleCompra (ProductoID, Cantidad, CostoUnitario, Subtotal, ModoCargo)
        VALUES (@ProductoID, @Cantidad, @CostoUnitario, @Subtotal, @ModoCargo)"


    Private Const SQL_DELETE_COMPRA As String = "DELETE FROM TCompras WHERE OrdenCompra = @OrdenCompra"
    Private Const SQL_DELETE_DETALLE_BY_COMPRA As String = "DELETE FROM TDetalleCompra WHERE OrdenCompra = @OrdenCompra"

    Private Const SQL_SELECT_ALL As String = "SELECT * FROM VCompras"
    Private Const SQL_SELECT_BY_ID As String = "SELECT * FROM VCompras WHERE OrdenCompra = @OrdenCompra"
    Private Const SQL_SELECT_DETALLES_BY_COMPRA As String = "SELECT * FROM VDetalleCompras WHERE OrdenCompra = @OrdenCompra"

    Private Const SQL_SELECT_MAX_ORDEN As String = "SELECT MAX(OrdenCompra) FROM VCompras"

    Public Function GetById(compraID As Integer) As VCompras Implements IRepositorio_Compra.GetById
        Dim compra As New VCompras()
        compra._detalle = New List(Of VDetalleCompras)()

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            ' Leer cabecera
            Using cmd As New SqlCommand(SQL_SELECT_BY_ID, conn)
                cmd.Parameters.AddWithValue("@OrdenCompra", compraID)
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        compra._ordenCompra = Convert.ToInt32(rdr("OrdenCompra"))
                        compra._fecha = Convert.ToDateTime(rdr("Fecha"))
                        compra._nControl = If(IsDBNull(rdr("NControl")), "", Convert.ToString(rdr("NControl")))
                        compra._nFactura = If(IsDBNull(rdr("NFactura")), "", Convert.ToString(rdr("NFactura")))
                        compra._tPago = rdr("TPago")
                        compra._iVA = rdr("IVA")
                        compra._proveedor = rdr("Proveedor")
                        compra._direccion = If(IsDBNull(rdr("Direccion")), "", Convert.ToString(rdr("Direccion")))
                        compra._telefono = If(IsDBNull(rdr("Telefono")), "", Convert.ToString(rdr("Telefono")))
                        compra._rif = If(IsDBNull(rdr("Rif")), "", Convert.ToString(rdr("Rif")))
                        compra._razonSocial = If(IsDBNull(rdr("RazonSocial")), "", Convert.ToString(rdr("RazonSocial")))
                        compra._subTotal = Convert.ToDecimal(rdr("SubTotal"))
                        compra._sucursal = rdr("Sucursal")
                        compra._observacion = If(IsDBNull(rdr("Observacion")), "", Convert.ToString(rdr("Observacion")))
                    Else
                        Return Nothing
                    End If
                End Using
            End Using

            ' Leer detalles
            Using cmdDet As New SqlCommand(SQL_SELECT_DETALLES_BY_COMPRA, conn)
                cmdDet.Parameters.AddWithValue("@OrdenCompra", compraID)
                Using rdr = cmdDet.ExecuteReader()
                    While rdr.Read()
                        compra._detalle.Add(New VDetalleCompras With {
                            ._ordenCompra = If(IsDBNull(rdr("OrdenCompra")), 0, Convert.ToInt32(rdr("OrdenCompra"))),
                            ._descripcion = If(IsDBNull(rdr("Descripcion")), "", Convert.ToString(rdr("Descripcion"))),
                            ._codigoProducto = Convert.ToString(rdr("CodigoProducto")),
                            ._cantidad = Convert.ToInt32(rdr("Cantidad")),
                            ._costoUnitario = Convert.ToDecimal(rdr("CostoUnitario")),
                            ._subtotal = Convert.ToDecimal(rdr("SubTotal")),
                            ._modoCargo = If(IsDBNull(rdr("ModoCargo")), "", Convert.ToString(rdr("ModoCargo")))
                        })
                    End While
                End Using
            End Using
        End Using

        Return compra
    End Function

    Public Function GetDetalle(idCompra As Integer) As IEnumerable(Of VDetalleCompras) Implements IRepositorio_Compra.GetDetalle
        Dim listaDetalles As New List(Of VDetalleCompras)

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Using cmd As New SqlCommand(SQL_SELECT_DETALLES_BY_COMPRA, conn)
                cmd.Parameters.AddWithValue("@OrdenCompra", idCompra)

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim detalle As New VDetalleCompras With {
                                ._ordenCompra = Convert.ToInt32(reader("OrdenCompra")),
                                ._descripcion = reader("Descripcion").ToString(),
                                ._cantidad = Convert.ToInt32(reader("Cantidad")),
                                ._modoCargo = If(IsDBNull(reader("ModoCargo")), "", reader("ModoCargo").ToString()),
                                ._costoUnitario = Convert.ToDecimal(reader("CostoUnitario")),
                                ._subtotal = Convert.ToDecimal(reader("Subtotal"))
                            }
                        listaDetalles.Add(detalle)
                    End While
                End Using
            End Using
        End Using
        Return listaDetalles
    End Function

    Public Function GetAll() As IEnumerable(Of VCompras) Implements IRepositorio_Compra.GetAll
        Dim listaCompras As New List(Of VCompras)

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            Using cmd As New SqlCommand(SQL_SELECT_ALL, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim compra As New VCompras With {
                            ._ordenCompra = Convert.ToInt32(reader("OrdenCompra")),
                            ._fecha = Convert.ToDateTime(reader("Fecha")),
                            ._nControl = If(IsDBNull(reader("NControl")), "", reader("NControl").ToString()),
                            ._nFactura = If(IsDBNull(reader("NFactura")), "", reader("NFactura").ToString()),
                            ._sucursal = reader("Sucursal").ToString(),
                            ._proveedor = reader("Proveedor").ToString(),
                            ._tPago = reader("TPago").ToString(),
                            ._subTotal = Convert.ToDecimal(reader("SubTotal"))
                        }
                        listaCompras.Add(compra)
                    End While
                End Using
            End Using
        End Using

        Return listaCompras
    End Function

    Public Function GetMax() As Integer Implements IRepositorio_Compra.GetMax
        Dim maxValue As Integer = 0
        Using conn As SqlConnection = ObtenerConexion()
            Using command As New SqlCommand(SQL_SELECT_MAX_ORDEN, conn)
                conn.Open()
                Dim result = command.ExecuteScalar()
                If Not IsDBNull(result) Then
                    maxValue = Convert.ToInt32(result) + 1
                Else
                    maxValue = 1
                End If
            End Using
        End Using
        Return maxValue
    End Function

    Public Function Edit(entity As TCompra) As Integer Implements IRepositorio_Generico(Of TCompra).Edit
        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                Using tran As SqlClient.SqlTransaction = conn.BeginTransaction()
                    Try
                        ' 1. Actualizar datos de la compra
                        Using cmdUpdate As New SqlClient.SqlCommand(SQL_UPDATE_COMPRA, conn, tran)
                            cmdUpdate.Parameters.AddWithValue("@CompraID", entity.CompraID)
                            cmdUpdate.Parameters.AddWithValue("@OrdenCompra", entity.OrdenCompra)
                            cmdUpdate.Parameters.AddWithValue("@FechaCompra", entity.FechaCompra)
                            cmdUpdate.Parameters.AddWithValue("@NumeroFactura", If(String.IsNullOrWhiteSpace(entity.NumeroFactura), DBNull.Value, entity.NumeroFactura))
                            cmdUpdate.Parameters.AddWithValue("@TipoPagoID", entity.TipoPagoID)
                            cmdUpdate.Parameters.AddWithValue("@AlicuotaID", entity.AlicuotaID)
                            cmdUpdate.Parameters.AddWithValue("@ProveedorID", entity.ProveedorID)
                            cmdUpdate.Parameters.AddWithValue("@EmpleadoID", entity.EmpleadoID)
                            cmdUpdate.Parameters.AddWithValue("@UbicacionDestinoID", entity.UbicacionDestinoID)
                            cmdUpdate.Parameters.AddWithValue("@TotalCompra", entity.TotalCompra)
                            cmdUpdate.Parameters.AddWithValue("@Observacion", If(String.IsNullOrWhiteSpace(entity.Observacion), DBNull.Value, entity.Observacion))
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' 2. Eliminar detalle viejo
                        Using cmdDelete As New SqlClient.SqlCommand(SQL_DELETE_DETALLE_BY_COMPRA, conn, tran)
                            cmdDelete.Parameters.AddWithValue("@OrdenCompra", entity.OrdenCompra)
                            cmdDelete.ExecuteNonQuery()
                        End Using

                        ' 3. Insertar detalle nuevo
                        For Each item In entity.Detalle
                            Using cmdInsert As New SqlClient.SqlCommand(SQL_INSERT_DETALLE, conn, tran)
                                cmdInsert.Parameters.AddWithValue("@OrdenCompra", entity.OrdenCompra)
                                cmdInsert.Parameters.AddWithValue("@ProductoID", item.ProductoID)
                                cmdInsert.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                                cmdInsert.Parameters.AddWithValue("@CostoUnitario", item.PrecioUnitario)
                                cmdInsert.Parameters.AddWithValue("@SubTotal", item.Subtotal)
                                cmdInsert.Parameters.AddWithValue("@ModoCargo", If(String.IsNullOrWhiteSpace(item.ModoCargo), DBNull.Value, item.ModoCargo))
                                cmdInsert.ExecuteNonQuery()
                            End Using
                        Next

                        ' 4. Confirmar
                        tran.Commit()
                        Return True
                    Catch ex As Exception
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Repositorio_Compras.Update -> " & ex.Message, ex)
            Return False
        End Try
    End Function

    Public Function Add(entity As TCompra) As Integer Implements IRepositorio_Generico(Of TCompra).Add
        If entity Is Nothing Then Throw New ArgumentNullException(NameOf(entity))

        ' Asegurarse lista de detalles
        If entity.Detalle Is Nothing Then entity.Detalle = New List(Of TDetalleCompra)()

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()
            Using tran As SqlTransaction = conn.BeginTransaction()
                Try
                    ' 1) Insertar cabecera y obtener CompraID
                    Using cmdCompra As New SqlCommand(SQL_INSERT_COMPRA, conn, tran)
                        cmdCompra.Parameters.AddWithValue("@OrdenCompra", entity.OrdenCompra)
                        cmdCompra.Parameters.AddWithValue("@FechaCompra", entity.FechaCompra)
                        cmdCompra.Parameters.AddWithValue("@NumeroControl", If(String.IsNullOrWhiteSpace(entity.NumeroControl), DBNull.Value, entity.NumeroControl))
                        cmdCompra.Parameters.AddWithValue("@NumeroFactura", If(String.IsNullOrWhiteSpace(entity.NumeroFactura), DBNull.Value, entity.NumeroFactura))
                        cmdCompra.Parameters.AddWithValue("@TipoPagoID", entity.TipoPagoID)
                        cmdCompra.Parameters.AddWithValue("@AlicuotaID", entity.AlicuotaID)
                        cmdCompra.Parameters.AddWithValue("@ProveedorID", entity.ProveedorID)
                        cmdCompra.Parameters.AddWithValue("@EmpleadoID", entity.EmpleadoID)
                        cmdCompra.Parameters.AddWithValue("@UbicacionDestinoID", entity.UbicacionDestinoID)
                        cmdCompra.Parameters.AddWithValue("@TotalCompra", entity.TotalCompra)
                        cmdCompra.Parameters.AddWithValue("@Observacion", If(String.IsNullOrWhiteSpace(entity.Observacion), DBNull.Value, entity.Observacion))

                        Dim newCompraID As Integer = Convert.ToInt32(cmdCompra.ExecuteScalar())
                        entity.OrdenCompra = newCompraID

                        ' 2) Insertar detalles (reutilizar comando es posible; mantengo claro y simple)
                        For Each det As TDetalleCompra In entity.Detalle
                            Using cmdDet As New SqlCommand(SQL_INSERT_DETALLE, conn, tran)
                                cmdDet.Parameters.AddWithValue("@OrdenCompra", newCompraID)
                                cmdDet.Parameters.AddWithValue("@ProductoID", det.ProductoID)
                                cmdDet.Parameters.AddWithValue("@Cantidad", det.Cantidad)
                                cmdDet.Parameters.AddWithValue("@CostoUnitario", det.PrecioUnitario)
                                cmdDet.Parameters.AddWithValue("@SubTotal", det.Subtotal)
                                cmdDet.Parameters.AddWithValue("@ModoCargo", If(String.IsNullOrWhiteSpace(det.ModoCargo), DBNull.Value, det.ModoCargo))
                                cmdDet.ExecuteNonQuery()
                            End Using
                        Next
                    End Using

                    tran.Commit()
                    Return entity.OrdenCompra

                Catch ex As sqlException
                    Try
                        tran.Rollback()
                    Catch
                    End Try
                    Return ex.Number
                End Try
            End Using
        End Using
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TCompra).Remove
        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                Using tran As SqlClient.SqlTransaction = conn.BeginTransaction()
                    Try
                        ' Primero eliminar los detalles
                        Using cmdDetalle As New SqlClient.SqlCommand(SQL_DELETE_DETALLE_BY_COMPRA, conn, tran)
                            cmdDetalle.Parameters.AddWithValue("@OrdenCompra", id)
                            cmdDetalle.ExecuteNonQuery()
                        End Using

                        ' Luego eliminar la compra
                        Using cmdCompra As New SqlClient.SqlCommand(SQL_DELETE_COMPRA, conn, tran)
                            cmdCompra.Parameters.AddWithValue("@OrdenCompra", id)
                            cmdCompra.ExecuteNonQuery()
                        End Using

                        ' Confirmar transacción
                        tran.Commit()
                        Return True
                    Catch ex As Exception
                        ' Revertir si hubo error
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception("Repositorio_Compras.Remove -> " & ex.Message, ex)
            Return False
        End Try
    End Function


    '--------------------------------------------------------------------

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TCompra) Implements IRepositorio_Generico(Of TCompra).GetAllUserPass
        Throw New NotImplementedException()
    End Function

    Private Function IRepositorio_Generico_GetAll() As IEnumerable(Of TCompra) Implements IRepositorio_Generico(Of TCompra).GetAll
        Throw New NotImplementedException()
    End Function

End Class


