Imports CapaEntidad

Public Interface IRepositorio_Empleados
    Function GetByCedula(cedula As String) As IEnumerable(Of VEmpleados)
    Function GetById(empleadoID As Integer) As VEmpleados
    Function GetAlls() As IEnumerable(Of VEmpleados)
End Interface
