Imports Microsoft.Data.SqlClient
Imports CapaEntidad

Public Class Repositorio_Empleados
    Inherits Repositorio_Maestro
    Implements IRepositorio_Empleados, IRepositorio_Generico(Of TEmpleados)

    Private SeleccionarTodos As String
    Private SeleccionarPorID As String
    Private Insertar As String
    Private Actualizar As String
    Private Eliminar As String
    Public Sub New()
        SeleccionarTodos = "SELECT * FROM VEmpleados"
        SeleccionarPorID = "SELECT * FROM VEmpleados WHERE EmpleadoID = @EmpleadoID"
        Insertar = "INSERT INTO TEmpleados (Cedula, Nombre, Apellido, Edad, Nacionalidad, EstadoCivil, 
                    Sexo, FechaNacimiento, Direccion, CargoEmpleadoID, Correo, Asesor, Gerente, Optometrista, Marketing, 
                    Cobranza, Estado, Telefono, Zona, Foto) VALUES (@Cedula, @Nombre, @Apellido, @Edad, @Nacionalidad, 
                    @EstadoCivil, @Sexo, @FechaNacimiento, @Direccion, @Cargo, @Correo, @Asesor, @Gerente, 
                    @Optometrista, @Marketing, @Cobranza, @Estado, @Telefono, @Zona, @Foto)"
        Actualizar = "UPDATE TEmpleados SET Cedula = @Cedula, Nombre = @Nombre, Apellido = @Apellido, Edad = @Edad, _
                    Nacionalidad = @Nacionalidad, EstadoCivil = @EstadoCivil, Sexo = @Sexo, FechaNacimiento = @FechaNacimiento, _
                    Direccion = @Direccion, Cargo = @Cargo, Correo = @Correo, Asesor = @Asesor, Gerente = @Gerente, _
                    Optometrista = @Optometrista, Marketing = @Marketing, Cobranza = @Cobranza WHERE EmpleadoID = @EmpleadoID"
        Eliminar = "DELETE FROM TEmpleados WHERE EmpleadoID = @EmpleadoID"
    End Sub

    Public Function ObtenerTodos() As IEnumerable(Of TEmpleados) Implements IRepositorio_Generico(Of TEmpleados).GetAll
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarTodos)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("CargoEmpleadoID")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono")),
                .Zona = Convert.ToString(row("Zona"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Private Function IRepositorio_Generico_Insertar(entity As TEmpleados) As Integer Implements IRepositorio_Generico(Of TEmpleados).Add
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
            New SqlParameter("@Foto", entity.Foto)
        }
        Return ExecuteNonQuery(Insertar)
    End Function

    Private Function IRepositorio_Generico_Actualizar(entity As TEmpleados) As Integer Implements IRepositorio_Generico(Of TEmpleados).Edit
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
            New SqlParameter("@Cobranza", entity.Cobranza)
        }
        Return ExecuteNonQuery(Actualizar)
    End Function

    Public Function Remove(id As Integer) As Integer Implements IRepositorio_Generico(Of TEmpleados).Remove
        parameter = New List(Of SqlParameter) From {
                    New SqlParameter("@EmpleadoID", id)
                }
        Return ExecuteNonQuery(Eliminar)
    End Function

    Public Function ObtenerPorID(empleadoID As Integer) As TEmpleados Implements IRepositorio_Empleados.GetById
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EmpleadoID", empleadoID)
        }
        Dim resultadoTable As DataTable = ExecuteReader(SeleccionarPorID)
        If resultadoTable.Rows.Count > 0 Then
            Dim row As DataRow = resultadoTable.Rows(0)
            Return New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
        End If
        Return Nothing
    End Function

    Public Function ObtenerTodosLosEmpleados() As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.GetAllEmpleados
        Return ObtenerTodos()
    End Function

    Public Function InsertarEmpleado(empleado As TEmpleados) As Integer Implements IRepositorio_Empleados.AddEmpleado
        Return IRepositorio_Generico_Insertar(empleado)
    End Function

    Public Function ActualizarEmpleado(empleado As TEmpleados) As Integer Implements IRepositorio_Empleados.UpdateEmpleado
        Return IRepositorio_Generico_Actualizar(empleado)
    End Function

    Public Function EliminarEmpleado(empleado As Integer) As Integer Implements IRepositorio_Empleados.DeleteEmpleado
        Return Remove(empleado)
    End Function

    Public Function ObtenerEmpleadosPorCargo(cargoID As Integer) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.GetEmpleadosByCargo
        Dim query As String = "SELECT * FROM VEmpleados WHERE Cargo = @CargoID"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@CargoID", cargoID)
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function ObtenerEmpleadosActivos() As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.GetActiveEmpleados
        Dim query As String = "SELECT * FROM VEmpleados WHERE Estado = 1"
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function ObtenerEmpleadosInactivos() As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.GetInactiveEmpleados
        Dim query As String = "SELECT * FROM VEmpleados WHERE Estado = 0"
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorNombre(nombre As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByName
        Dim query As String = "SELECT * FROM VEmpleados WHERE Nombre LIKE @Nombre"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", "%" & nombre & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorCedula(cedula As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByCedula
        Dim query As String = "SELECT * FROM VEmpleados WHERE Cedula LIKE @Cedula"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Cedula", "%" & cedula & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToInt32(row("Nacionalidad")),
                .EstadoCivil = Convert.ToInt32(row("EstadoCivil")),
                .Sexo = Convert.ToInt32(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("CargoEmpleadoID")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono")),
                .Zona = Convert.ToInt32(row("Zona")),
                .Foto = Convert.ToString(row("Foto"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorApellido(apellido As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByLastName
        Dim query As String = "SELECT * FROM VEmpleados WHERE Apellido LIKE @Apellido"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Apellido", "%" & apellido & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorTelefono(telefono As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByPhone
        Dim query As String = "SELECT * FROM VEmpleados WHERE Telefono LIKE @Telefono"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Telefono", "%" & telefono & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorCorreo(correo As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByEmail
        Dim query As String = "SELECT * FROM VEmpleados WHERE Correo LIKE @Correo"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Correo", "%" & correo & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorFechaNacimiento(fechaNacimiento As Date) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByBirthDate
        Dim query As String = "SELECT * FROM VEmpleados WHERE FechaNacimiento = @FechaNacimiento"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@FechaNacimiento", fechaNacimiento)
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorDireccion(direccion As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByAddress
        Dim query As String = "SELECT * FROM VEmpleados WHERE Direccion LIKE @Direccion"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Direccion", "%" & direccion & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorEstadoCivil(estadoCivil As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByMaritalStatus
        Dim query As String = "SELECT * FROM VEmpleados WHERE EstadoCivil LIKE @EstadoCivil"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@EstadoCivil", "%" & estadoCivil & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorSexo(sexo As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByGender
        Dim query As String = "SELECT * FROM VEmpleados WHERE Sexo LIKE @Sexo"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Sexo", "%" & sexo & "%")
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function BuscarEmpleadosPorEdad(edad As Integer) As IEnumerable(Of TEmpleados) Implements IRepositorio_Empleados.SearchEmpleadosByAge
        Dim query As String = "SELECT * FROM VEmpleados WHERE Edad = @Edad"
        parameter = New List(Of SqlParameter) From {
            New SqlParameter("@Edad", edad)
        }
        Dim resultadoTable As DataTable = ExecuteReader(query)
        Dim lista = New List(Of TEmpleados)
        For Each row As DataRow In resultadoTable.Rows
            Dim empleado As New TEmpleados With {
                .EmpleadoID = Convert.ToInt32(row("EmpleadoID")),
                .Cedula = Convert.ToString(row("Cedula")),
                .Nombre = Convert.ToString(row("Nombre")),
                .Apellido = Convert.ToString(row("Apellido")),
                .Edad = Convert.ToInt32(row("Edad")),
                .Nacionalidad = Convert.ToString(row("Nacionalidad")),
                .EstadoCivil = Convert.ToString(row("EstadoCivil")),
                .Sexo = Convert.ToString(row("Sexo")),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNacimiento")),
                .Direccion = Convert.ToString(row("Direccion")),
                .Cargo = Convert.ToInt32(row("Cargo")),
                .Correo = Convert.ToString(row("Correo")),
                .Asesor = Convert.ToByte(row("Asesor")),
                .Gerente = Convert.ToByte(row("Gerente")),
                .Optometrista = Convert.ToByte(row("Optometrista")),
                .Marketing = Convert.ToByte(row("Marketing")),
                .Cobranza = Convert.ToByte(row("Cobranza")),
                .Estado = Convert.ToByte(row("Estado")),
                .Telefono = Convert.ToString(row("Telefono"))
            }
            lista.Add(empleado)
        Next
        Return lista
    End Function

    Public Function GetAllUserPass(usuario As String, password As String) As IEnumerable(Of TEmpleados) Implements IRepositorio_Generico(Of TEmpleados).GetAllUserPass
        Throw New NotImplementedException()
    End Function


End Class
