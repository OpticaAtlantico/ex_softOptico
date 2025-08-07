Imports CapaEntidad
Imports Microsoft.Data.SqlClient

Public Class Repositorio_Compra
    Inherits Repositorio_Maestro
    Implements IRepositorio_Compra, IRepositorio_Generico(Of TCompra)

    Private SeleccionarTodos As String
    Private SeleccionarPorID As String
    Private Insertar As String
    Private Actualizar As String
    Private Eliminar As String
    Public Sub New()
        SeleccionarTodos = "SELECT * FROM VCompras"
        ' Assuming VEmpleados is a view that contains all necessary fields for TEmpleados.
        SeleccionarPorID = "SELECT * FROM VEmpleados WHERE EmpleadoID = @EmpleadoID"
        ' Assuming VEmpleados is a view that contains all necessary fields for TEmpleados.
        Insertar = "INSERT INTO TEmpleados (Cedula, Nombre, Apellido, Edad, Nacionalidad, EstadoCivil, 
                    Sexo, FechaNacimiento, Direccion, CargoEmpleadoID, Correo, Asesor, Gerente, Optometrista, Marketing, 
                    Cobranza, Estado, Telefono, Zona, Foto) VALUES (@Cedula, @Nombre, @Apellido, @Edad, @Nacionalidad, 
                    @EstadoCivil, @Sexo, @FechaNacimiento, @Direccion, @Cargo, @Correo, @Asesor, @Gerente, 
                    @Optometrista, @Marketing, @Cobranza, @Estado, @Telefono, @Zona, @Foto)"
        ' Note: The Foto field is assumed to be a string path or URL; adjust as necessary for your application.
        Actualizar = "UPDATE TEmpleados SET 
                    Cedula = @Cedula, Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad, Nacionalidad = @Nacionalidad, 
                    EstadoCivil = @EstadoCivil, Sexo = @Sexo, FechaNacimiento = @FechaNacimiento, Direccion = @Direccion, 
                    CargoEmpleadoID = @Cargo, Correo = @Correo, Asesor = @Asesor, Gerente = @Gerente, 
                    Optometrista = @Optometrista, Marketing = @Marketing, Cobranza = @Cobranza, Zona = @Zona, Foto = @Foto 
                    WHERE EmpleadoID = @EmpleadoID"
        'eliminar empleado
        ' Assuming TEmpleados is the table where employee data is stored.
        Eliminar = "DELETE FROM TEmpleados WHERE EmpleadoID = @EmpleadoID"
    End Sub

    Public Function Add(entity As TCompra) As Integer Implements IRepositorio_Generico(Of TCompra).Add
        Return AddCompra(entity)
    End Function

    Public Function GetAllCompras() As IEnumerable(Of TCompra) Implements IRepositorio_Compra.GetAllCompras
        Throw New NotImplementedException()
    End Function

    Public Function AddCompra(compra As TCompra) As Integer Implements IRepositorio_Compra.AddCompra
        Using conn As New SqlConnection("TU_CONEXION")
            conn.Open()
            Dim trans As SqlTransaction = conn.BeginTransaction()

            Try
                ' INSERTAR ENCABEZADO DE COMPRA
                Dim cmdCompra As New SqlCommand("
                    INSERT INTO TCompras 
                        (FechaCompra, NumeroControl, NumeroFactura, TipoPagoID, 
                        AlicuotaID, ProveedorID, EmpleadoID, UbicacionDestinoID, 
                        TotalCompra, Estado, Observacion)
                    OUTPUT INSERTED.CompraID
                    VALUES
                        (@FechaCompra, @NumeroControl, @NumeroFactura, @TipoPagoID, 
                        @AlicuotaID, @ProveedorID, @EmpleadoID, @UbicacionDestinoID, 
                        @TotalCompra, @Estado, @Observacion)", conn, trans)

                cmdCompra.Parameters.AddWithValue("@FechaCompra", compra.FechaCompra)
                cmdCompra.Parameters.AddWithValue("@NumeroControl", compra.NumeroControl)
                cmdCompra.Parameters.AddWithValue("@NumeroFactura", compra.NumeroFactura)
                cmdCompra.Parameters.AddWithValue("@TipoPagoID", compra.TipoPagoID)
                cmdCompra.Parameters.AddWithValue("@AlicuotaID", compra.AlicuotaID)
                cmdCompra.Parameters.AddWithValue("@ProveedorID", compra.ProveedorID)
                cmdCompra.Parameters.AddWithValue("@EmpleadoID", compra.EmpleadoID)
                cmdCompra.Parameters.AddWithValue("@UbicacionDestinoID", compra.UbicacionDestinoID)
                cmdCompra.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra)
                cmdCompra.Parameters.AddWithValue("@Observacion", If(compra.Observacion, DBNull.Value))

                Dim compraID As Integer = Convert.ToInt32(cmdCompra.ExecuteScalar())

                ' INSERTAR DETALLE
                For Each item In compra.Detalle
                    Dim cmdDetalle As New SqlCommand("
                        INSERT INTO TDetalleCompra 
                            (CompraID, ProductoID, Cantidad, CostoUnitario, Subtotal, ModoCargo)
                        VALUES
                            (@CompraID, @ProductoID, @Cantidad, @CostoUnitario, @Subtotal, @ModoCargo)", conn, trans)

                    cmdDetalle.Parameters.AddWithValue("@CompraID", compraID)
                    cmdDetalle.Parameters.AddWithValue("@ProductoID", item.ProductoID)
                    cmdDetalle.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                    cmdDetalle.Parameters.AddWithValue("@CostoUnitario", item.CostoUnitario)
                    cmdDetalle.Parameters.AddWithValue("@Subtotal", item.Subtotal)
                    cmdDetalle.Parameters.AddWithValue("@ModoCargo", item.ModoCargo)

                    cmdDetalle.ExecuteNonQuery()
                Next

                trans.Commit()
                Return True

            Catch ex As Exception
                trans.Rollback()
                'MessageBoxUI.Show("Error al guardar: " & ex.Message, TipoMensaje.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function UpdateCompra(compra As TCompra) As Integer Implements IRepositorio_Compra.UpdateCompra
        Throw New NotImplementedException()
    End Function

    Public Function DeleteCompra(compraID As Integer) As Integer Implements IRepositorio_Compra.DeleteCompra
        Throw New NotImplementedException()
    End Function

    Public Function GetById(compraID As Integer) As TCompra Implements IRepositorio_Compra.GetById
        Throw New NotImplementedException()
    End Function

    Public Function GetAll() As IEnumerable(Of TCompra) Implements IRepositorio_Generico(Of TCompra).GetAll
        Throw New NotImplementedException()
    End Function

    Public Function Edit(entity As TCompra) As Integer Implements IRepositorio_Generico(Of TCompra).Edit
        Throw New NotImplementedException()
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TCompra).Remove
        Throw New NotImplementedException()
    End Function

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TCompra) Implements IRepositorio_Generico(Of TCompra).GetAllUserPass
        Throw New NotImplementedException()
    End Function
End Class
