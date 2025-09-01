Imports Microsoft.Data.SqlClient
Imports CapaEntidad

Public Class Repositorio_Empleados
    Inherits Repositorio_Maestro
    Implements IRepositorio_Empleados, IRepositorio_Generico(Of TEmpleados)

    Private SeleccionarTodos As String
    Private SeleccionarPorID As String
    Private SeleccionarPorCedula As String
    Private Insertar As String
    Private Actualizar As String
    Private Eliminar As String
    Public Sub New()
        SeleccionarTodos = "SELECT * FROM VEmpleados"
        ' Assuming VEmpleados is a view that contains all necessary fields for TEmpleados.
        SeleccionarPorID = "SELECT * FROM VEmpleados WHERE EmpleadoID = @EmpleadoID"
        SeleccionarPorCedula = "SELECT * FROM VEmpleados WHERE Cedula = @Cedula"

        Insertar = "INSERT INTO TEmpleados (Cedula, Nombre, Apellido, Edad, Nacionalidad, EstadoCivil, 
                    Sexo, FechaNacimiento, Direccion, CargoEmpleadoID, Correo, Asesor, Gerente, Optometrista, Marketing, 
                    Cobranza, Estado, Telefono, Zona, Foto) VALUES (@Cedula, @Nombre, @Apellido, @Edad, @Nacionalidad, 
                    @EstadoCivil, @Sexo, @FechaNacimiento, @Direccion, @Cargo, @Correo, @Asesor, @Gerente, 
                    @Optometrista, @Marketing, @Cobranza, @Estado, @Telefono, @Zona, @Foto)"

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

    Public Function GetAlls() As IEnumerable(Of VEmpleados) Implements IRepositorio_Empleados.GetAlls
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarTodos)
        Dim lista = New List(Of VEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New VEmpleados With {
                ._empleadoID = Convert.ToInt32(row("EmpleadoID")),
                ._cedula = Convert.ToString(row("Cedula")),
                ._nombre = Convert.ToString(row("Nombre")),
                ._apellido = Convert.ToString(row("Apellido")),
                ._edad = Convert.ToInt32(row("Edad")),
                ._nacionalidad = [Enum].GetName(GetType(Nacionalidad), Convert.ToInt32(row("Nacionalidad"))),
                ._estadoCivil = [Enum].GetName(GetType(EstadoCivil), Convert.ToInt32(row("EstadoCivil"))),
                ._sexo = [Enum].GetName(GetType(Sexo), Convert.ToInt32(row("Sexo"))),
                ._fechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                ._direccion = Convert.ToString(row("Direccion")),
                ._cargo = Convert.ToString(row("Cargo")),
                ._correo = Convert.ToString(row("Correo")),
                ._asesor = Convert.ToBoolean(row("Asesor")),
                ._gerente = Convert.ToBoolean(row("Gerente")),
                ._optometrista = Convert.ToBoolean(row("Optometrista")),
                ._marketing = Convert.ToBoolean(row("Marketing")),
                ._cobranza = Convert.ToBoolean(row("Cobranza")),
                ._estado = Convert.ToByte(row("Estado")),
                ._telefono = Convert.ToString(row("Telefono")),
                ._zona = [Enum].GetName(GetType(Zona), Convert.ToInt32(row("Zona"))),
                ._foto = If(String.IsNullOrWhiteSpace(Convert.ToString(row("Foto"))), "Sin Foto", Convert.ToString(row("Foto")))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function GetByCedula(cedula As String) As IEnumerable(Of VEmpleados) Implements IRepositorio_Empleados.GetByCedula
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Cedula", cedula)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorCedula)
        Dim lista = New List(Of VEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New VEmpleados With {
                ._empleadoID = Convert.ToInt32(row("EmpleadoID")),
                ._cedula = Convert.ToString(row("Cedula")),
                ._nombre = Convert.ToString(row("Nombre")),
                ._apellido = Convert.ToString(row("Apellido")),
                ._edad = Convert.ToInt32(row("Edad")),
                ._nacionalidad = [Enum].GetName(GetType(Nacionalidad), Convert.ToInt32(row("Nacionalidad"))),
                ._estadoCivil = [Enum].GetName(GetType(EstadoCivil), Convert.ToInt32(row("EstadoCivil"))),
                ._sexo = [Enum].GetName(GetType(Sexo), Convert.ToInt32(row("Sexo"))),
                ._fechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                ._direccion = Convert.ToString(row("Direccion")),
                ._cargo = Convert.ToString(row("Cargo")),
                ._correo = Convert.ToString(row("Correo")),
                ._asesor = Convert.ToBoolean(row("Asesor")),
                ._gerente = Convert.ToBoolean(row("Gerente")),
                ._optometrista = Convert.ToBoolean(row("Optometrista")),
                ._marketing = Convert.ToBoolean(row("Marketing")),
                ._cobranza = Convert.ToBoolean(row("Cobranza")),
                ._estado = Convert.ToByte(row("Estado")),
                ._telefono = Convert.ToString(row("Telefono")),
                ._zona = [Enum].GetName(GetType(Zona), Convert.ToInt32(row("Zona"))),
                ._foto = If(String.IsNullOrWhiteSpace(Convert.ToString(row("Foto"))), "Sin Foto", Convert.ToString(row("Foto")))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function GetById(empleadoID As Integer) As VEmpleados Implements IRepositorio_Empleados.GetById
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EmpleadoID", empleadoID)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorID)
        If resultadoTable.Rows.Count > 0 Then
            Dim row As DataRow = resultadoTable.Rows(0)
            Return New VEmpleados With {
                ._empleadoID = Convert.ToInt32(row("EmpleadoID")),
                ._cedula = Convert.ToString(row("Cedula")),
                ._nombre = Convert.ToString(row("Nombre")),
                ._apellido = Convert.ToString(row("Apellido")),
                ._edad = Convert.ToInt32(row("Edad")),
                ._nacionalidad = [Enum].GetName(GetType(Nacionalidad), Convert.ToInt32(row("Nacionalidad"))),
                ._estadoCivil = [Enum].GetName(GetType(EstadoCivil), Convert.ToInt32(row("EstadoCivil"))),
                ._sexo = [Enum].GetName(GetType(Sexo), Convert.ToInt32(row("Sexo"))),
                ._fechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                ._direccion = Convert.ToString(row("Direccion")),
                ._cargo = Convert.ToString(row("Cargo")),
                ._correo = Convert.ToString(row("Correo")),
                ._asesor = Convert.ToBoolean(row("Asesor")),
                ._gerente = Convert.ToBoolean(row("Gerente")),
                ._optometrista = Convert.ToBoolean(row("Optometrista")),
                ._marketing = Convert.ToBoolean(row("Marketing")),
                ._cobranza = Convert.ToBoolean(row("Cobranza")),
                ._estado = Convert.ToByte(row("Estado")),
                ._telefono = Convert.ToString(row("Telefono")),
                ._zona = [Enum].GetName(GetType(Zona), Convert.ToInt32(row("Zona"))),
                ._foto = If(String.IsNullOrWhiteSpace(Convert.ToString(row("Foto"))), "Sin Foto", Convert.ToString(row("Foto")))
            }
        End If
        Return Nothing
    End Function

    Public Function Add(entity As TEmpleados) As Integer Implements IRepositorio_Generico(Of TEmpleados).Add
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Cedula", entity.Cedula),
            New SqlParameter("@Nombre", entity.Nombre),
            New SqlParameter("@Apellido", entity.Apellido),
            New SqlParameter("@Edad", entity.Edad),
            New SqlParameter("@Nacionalidad", entity.Nacionalidad),
            New SqlParameter("@EstadoCivil", entity.EstadoCivil),
            New SqlParameter("@Sexo", entity.Sexo),
            New SqlParameter("@FechaNacimiento", entity.FechaNacimiento),
            New SqlParameter("@Direccion", entity.Direccion),
            New SqlParameter("@Cargo", entity.Cargo),
            New SqlParameter("@Correo", entity.Correo),
            New SqlParameter("@Asesor", entity.Asesor),
            New SqlParameter("@Gerente", entity.Gerente),
            New SqlParameter("@Optometrista", entity.Optometrista),
            New SqlParameter("@Marketing", entity.Marketing),
            New SqlParameter("@Cobranza", entity.Cobranza),
            New SqlParameter("@Estado", entity.Estado),
            New SqlParameter("@Telefono", entity.Telefono),
            New SqlParameter("@Zona", entity.Zona),
            New SqlParameter("@Foto", If(String.IsNullOrWhiteSpace(entity.Foto), "Sin Foto", entity.Foto))
        }
        Return ExecuteNonQuery(Insertar)
    End Function

    Public Function Edit(entity As TEmpleados) As Integer Implements IRepositorio_Generico(Of TEmpleados).Edit
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EmpleadoID", entity.EmpleadoID),
            New SqlParameter("@Cedula", entity.Cedula),
            New SqlParameter("@Nombre", entity.Nombre),
            New SqlParameter("@Apellido", entity.Apellido),
            New SqlParameter("@Edad", entity.Edad),
            New SqlParameter("@Nacionalidad", entity.Nacionalidad),
            New SqlParameter("@EstadoCivil", entity.EstadoCivil),
            New SqlParameter("@Sexo", entity.Sexo),
            New SqlParameter("@FechaNacimiento", entity.FechaNacimiento),
            New SqlParameter("@Direccion", entity.Direccion),
            New SqlParameter("@Cargo", entity.Cargo),
            New SqlParameter("@Correo", entity.Correo),
            New SqlParameter("@Asesor", entity.Asesor),
            New SqlParameter("@Gerente", entity.Gerente),
            New SqlParameter("@Optometrista", entity.Optometrista),
            New SqlParameter("@Marketing", entity.Marketing),
            New SqlParameter("@Cobranza", entity.Cobranza),
            New SqlParameter("@Estado", entity.Estado),
            New SqlParameter("@Telefono", entity.Telefono),
            New SqlParameter("@Zona", entity.Zona),
            New SqlParameter("@Foto", If(String.IsNullOrWhiteSpace(entity.Foto), "Sin Foto", entity.Foto))
        }
        Return ExecuteNonQuery(Actualizar)
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TEmpleados).Remove
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EmpleadoID", id)
        }
        Return ExecuteNonQuery(Eliminar)
    End Function


    '----------------------------------------

    Public Function GetAll() As IEnumerable(Of TEmpleados) Implements IRepositorio_Generico(Of TEmpleados).GetAll
        Throw New NotImplementedException()
    End Function


End Class
