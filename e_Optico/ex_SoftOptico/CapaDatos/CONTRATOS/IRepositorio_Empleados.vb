Imports CapaEntidad

Public Interface IRepositorio_Empleados
    Function SearchEmpleadosByAge(edad As Integer) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByGender(sexo As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByMaritalStatus(estadoCivil As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByAddress(direccion As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByBirthDate(fechaNacimiento As Date) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByEmail(correo As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByPhone(telefono As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByLastName(apellido As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByCedula(cedula As String) As IEnumerable(Of TEmpleados)
    Function SearchEmpleadosByName(nombre As String) As IEnumerable(Of TEmpleados)
    Function GetInactiveEmpleados() As IEnumerable(Of TEmpleados)
    Function GetActiveEmpleados() As IEnumerable(Of TEmpleados)
    Function GetAllEmpleados() As IEnumerable(Of TEmpleados)
    Function AddEmpleado(empleado As TEmpleados) As Integer
    Function UpdateEmpleado(empleado As TEmpleados) As Integer
    Function DeleteEmpleado(empleadoID As Integer) As Integer
    Function GetEmpleadosByCargo(cargoID As Integer) As IEnumerable(Of TEmpleados)
    Function GetById(empleadoID As Integer) As TEmpleados
End Interface
