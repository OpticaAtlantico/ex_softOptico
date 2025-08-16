Imports CapaEntidad
Imports Microsoft.Data
Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class Repositorio_Compra
    Inherits Repositorio
    Implements IRepositorio_Compra

    Private Const SQL_INSERT_COMPRA As String = "
        INSERT INTO TCompras (FechaCompra, NumeroControl, NumeroFactura, TipoPagoID, AlicuotaID, ProveedorID, 
                EmpleadoID, UbicacionDestinoID, TotalCompra, Observacion)
        OUTPUT INSERTED.CompraID
        VALUES (@FechaCompra, @NumeroControl, @NumeroFactura, @TipoPagoID, @AlicuotaID, @ProveedorID, 
                @EmpleadoID, @UbicacionDestinoID, @TotalCompra, @Observacion);"

    Private Const SQL_INSERT_DETALLE As String = "
        INSERT INTO TDetalleCompra (CompraID, ProductoID, Cantidad, CostoUnitario, SubTotal, ModoCargo)
        VALUES (@CompraID, @ProductoID, @Cantidad, @CostoUnitario, @SubTotal, @ModoCargo);"

    Private Const SQL_UPDATE_COMPRA As String = "
        UPDATE TCompras SET FechaCompra = @FechaCompra, NumeroControl = @NumeroControl, NumeroFactura = @NumeroFactura, 
        TipoPagoID = @TipoPagoID, AlicuotaID = @AlicuotaID, ProveedorID = @ProveedorID, 
        EmpleadoID = @EmpleadoID, UbicacionDestinoID = @UbicacionDestinoID, TotalCompra = @TotalCompra, 
        Observacion = @Observacion WHERE CompraID = @CompraID;"

    Private Const SQL_UPDATE_DETALLE As String = "
        INSERT INTO TDetalleCompra (CompraID, ProductoID, Cantidad, CostoUnitario, Subtotal, ModoCargo)
        VALUES (@CompraID, @ProductoID, @Cantidad, @CostoUnitario, @Subtotal, @ModoCargo)"


    Private Const SQL_DELETE_COMPRA As String = "DELETE FROM TCompras WHERE CompraID = @CompraID"
    Private Const SQL_DELETE_DETALLE_BY_COMPRA As String = "DELETE FROM TDetalleCompra WHERE CompraID = @CompraID"

    Private Const SQL_SELECT_ALL As String = "SELECT * FROM VCompras"
    Private Const SQL_SELECT_BY_ID As String = "SELECT * FROM VCompras WHERE CompraID = @CompraID"
    Private Const SQL_SELECT_DETALLES_BY_COMPRA As String = "SELECT * FROM TDetalleCompra WHERE CompraID = @CompraID"

    Public Function Add(compra As TCompra) As Integer Implements IRepositorio_Compra.Add
        If compra Is Nothing Then Throw New ArgumentNullException(NameOf(compra))

        ' Asegurarse lista de detalles
        If compra.Detalle Is Nothing Then compra.Detalle = New List(Of TDetalleCompra)()

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()
            Using tran As SqlTransaction = conn.BeginTransaction()
                Try
                    ' 1) Insertar cabecera y obtener CompraID
                    Using cmdCompra As New SqlCommand(SQL_INSERT_COMPRA, conn, tran)
                        cmdCompra.Parameters.AddWithValue("@FechaCompra", compra.FechaCompra)
                        cmdCompra.Parameters.AddWithValue("@NumeroControl", If(String.IsNullOrWhiteSpace(compra.NumeroControl), DBNull.Value, compra.NumeroControl))
                        cmdCompra.Parameters.AddWithValue("@NumeroFactura", If(String.IsNullOrWhiteSpace(compra.NumeroFactura), DBNull.Value, compra.NumeroFactura))
                        cmdCompra.Parameters.AddWithValue("@TipoPagoID", compra.TipoPagoID)
                        cmdCompra.Parameters.AddWithValue("@AlicuotaID", compra.AlicuotaID)
                        cmdCompra.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID)
                        cmdCompra.Parameters.AddWithValue("@EmpleadoID", compra.EmpleadoID)
                        cmdCompra.Parameters.AddWithValue("@UbicacionDestinoID", compra.UbicacionDestinoID)
                        cmdCompra.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra)
                        cmdCompra.Parameters.AddWithValue("@Observacion", If(String.IsNullOrWhiteSpace(compra.Observacion), DBNull.Value, compra.Observacion))

                        Dim newCompraID As Integer = Convert.ToInt32(cmdCompra.ExecuteScalar())
                        compra.CompraID = newCompraID

                        ' 2) Insertar detalles (reutilizar comando es posible; mantengo claro y simple)
                        For Each det As TDetalleCompra In compra.Detalle
                            Using cmdDet As New SqlCommand(SQL_INSERT_DETALLE, conn, tran)
                                cmdDet.Parameters.AddWithValue("@CompraID", newCompraID)
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
                    Return compra.CompraID

                Catch ex As Exception
                    Try
                        tran.Rollback()
                    Catch
                    End Try
                    Throw New Exception("Repositorio_Compras.Add -> " & ex.Message, ex)
                End Try
            End Using
        End Using
    End Function

    Public Function GetById(compraID As Integer) As TCompra Implements IRepositorio_Compra.GetById
        Dim compra As New TCompra()
        compra.Detalle = New List(Of TDetalleCompra)()

        Using conn As SqlConnection = ObtenerConexion()
            conn.Open()

            ' Leer cabecera
            Using cmd As New SqlCommand(SQL_SELECT_BY_ID, conn)
                cmd.Parameters.AddWithValue("@CompraID", compraID)
                Using rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        compra.CompraID = Convert.ToInt32(rdr("CompraID"))
                        compra.FechaCompra = Convert.ToDateTime(rdr("FechaCompra"))
                        compra.NumeroControl = If(IsDBNull(rdr("NumeroControl")), "", Convert.ToString(rdr("NumeroControl")))
                        compra.NumeroFactura = If(IsDBNull(rdr("NumeroFactura")), "", Convert.ToString(rdr("NumeroFactura")))
                        compra.TipoPagoID = Convert.ToInt32(rdr("TipoPagoID"))
                        compra.AlicuotaID = Convert.ToInt32(rdr("AlicuotaID"))
                        compra.ProveedorID = Convert.ToInt32(rdr("ProveedorID"))
                        compra.EmpleadoID = Convert.ToInt32(rdr("EmpleadoID"))
                        compra.UbicacionDestinoID = Convert.ToInt32(rdr("UbicacionDestinoID"))
                        compra.TotalCompra = Convert.ToDecimal(rdr("TotalCompra"))
                        compra.Observacion = If(IsDBNull(rdr("Observacion")), "", Convert.ToString(rdr("Observacion")))
                    Else
                        Return Nothing
                    End If
                End Using
            End Using

            ' Leer detalles
            Using cmdDet As New SqlCommand(SQL_SELECT_DETALLES_BY_COMPRA, conn)
                cmdDet.Parameters.AddWithValue("@CompraID", compraID)
                Using rdr = cmdDet.ExecuteReader()
                    While rdr.Read()
                        compra.Detalle.Add(New TDetalleCompra With {
                            .DetalleID = If(IsDBNull(rdr("DetalleCompraID")), 0, Convert.ToInt32(rdr("DetalleCompraID"))),
                            .CompraID = If(IsDBNull(rdr("CompraID")), 0, Convert.ToInt32(rdr("CompraID"))),
                            .ProductoID = Convert.ToInt32(rdr("ProductoID")),
                            .Cantidad = Convert.ToDecimal(rdr("Cantidad")),
                            .PrecioUnitario = Convert.ToDecimal(rdr("CostoUnitario")),
                            .Subtotal = Convert.ToDecimal(rdr("SubTotal")),
                            .ModoCargo = If(IsDBNull(rdr("ModoCargo")), "", Convert.ToString(rdr("ModoCargo")))
                        })
                    End While
                End Using
            End Using
        End Using

        Return compra
    End Function

    Public Function Remove(compraID As Integer) As Boolean Implements IRepositorio_Compra.Delete
        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                Using tran As SqlClient.SqlTransaction = conn.BeginTransaction()
                    Try
                        ' Primero eliminar los detalles
                        Using cmdDetalle As New SqlClient.SqlCommand(SQL_DELETE_DETALLE_BY_COMPRA, conn, tran)
                            cmdDetalle.Parameters.AddWithValue("@CompraID", compraID)
                            cmdDetalle.ExecuteNonQuery()
                        End Using

                        ' Luego eliminar la compra
                        Using cmdCompra As New SqlClient.SqlCommand(SQL_DELETE_COMPRA, conn, tran)
                            cmdCompra.Parameters.AddWithValue("@CompraID", compraID)
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

    Public Function GetAll() As IEnumerable(Of TCompra) Implements IRepositorio_Compra.GetAll
        Throw New NotImplementedException()
    End Function

    Public Function Update(compra As TCompra) As Boolean Implements IRepositorio_Compra.Update
        Try
            Using conn As SqlConnection = ObtenerConexion()
                conn.Open()
                Using tran As SqlClient.SqlTransaction = conn.BeginTransaction()
                    Try
                        ' 1. Actualizar datos de la compra
                        Using cmdUpdate As New SqlClient.SqlCommand(SQL_UPDATE_COMPRA, conn, tran)
                            cmdUpdate.Parameters.AddWithValue("@CompraID", compra.CompraID)
                            cmdUpdate.Parameters.AddWithValue("@FechaCompra", compra.FechaCompra)
                            cmdUpdate.Parameters.AddWithValue("@NumeroControl", If(String.IsNullOrWhiteSpace(compra.NumeroControl), DBNull.Value, compra.NumeroControl))
                            cmdUpdate.Parameters.AddWithValue("@NumeroFactura", If(String.IsNullOrWhiteSpace(compra.NumeroFactura), DBNull.Value, compra.NumeroFactura))
                            cmdUpdate.Parameters.AddWithValue("@TipoPagoID", compra.TipoPagoID)
                            cmdUpdate.Parameters.AddWithValue("@AlicuotaID", compra.AlicuotaID)
                            cmdUpdate.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID)
                            cmdUpdate.Parameters.AddWithValue("@EmpleadoID", compra.EmpleadoID)
                            cmdUpdate.Parameters.AddWithValue("@UbicacionDestinoID", compra.UbicacionDestinoID)
                            cmdUpdate.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra)
                            cmdUpdate.Parameters.AddWithValue("@Observacion", If(String.IsNullOrWhiteSpace(compra.Observacion), DBNull.Value, compra.Observacion))
                            cmdUpdate.ExecuteNonQuery()
                        End Using

                        ' 2. Eliminar detalle viejo
                        Using cmdDelete As New SqlClient.SqlCommand(SQL_DELETE_DETALLE_BY_COMPRA, conn, tran)
                            cmdDelete.Parameters.AddWithValue("@CompraID", compra.CompraID)
                            cmdDelete.ExecuteNonQuery()
                        End Using

                        ' 3. Insertar detalle nuevo
                        For Each item In compra.Detalle
                            Using cmdInsert As New SqlClient.SqlCommand(SQL_INSERT_DETALLE, conn, tran)
                                cmdInsert.Parameters.AddWithValue("@CompraID", compra.CompraID)
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
End Class


