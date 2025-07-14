Public Class TEmpleados
    Public Property EmpleadoID As Integer
    Public Property Cedula As String
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Edad As Integer
    Public Property Nacionalidad As String
    Public Property EstadoCivil As String
    Public Property Sexo As String
    Public Property FechaNacimiento As Date
    Public Property Direccion As String
    Public Property Cargo As Integer 'FK DE TABLA TCARGOS
    Public Property Correo As String
    Public Property Asesor As Byte ' 0 = No, 1 = Si
    Public Property Gerente As Byte ' 0 = No, 1 = Si
    Public Property Optometrista As Byte ' 0 = No, 1 = Si
    Public Property Marketing As Byte ' 0 = No, 1 = Si
    Public Property Cobranza As Byte ' 0 = No, 1 = Si
    Public Property Estado As Byte
    Public Property Telefono As String

End Class
