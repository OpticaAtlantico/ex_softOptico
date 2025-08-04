Public Class TEmpleados
    Public Property EmpleadoID As Integer
    Public Property Cedula As String
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Edad As Integer
    Public Property Nacionalidad As Integer
    Public Property EstadoCivil As Integer
    Public Property Sexo As Integer
    Public Property FechaNacimiento As Date
    Public Property Direccion As String
    Public Property Cargo As String 'FK DE TABLA TCARGOS
    Public Property Correo As String
    Public Property Asesor As Boolean
    Public Property Gerente As Boolean
    Public Property Optometrista As Boolean
    Public Property Marketing As Boolean
    Public Property Cobranza As Boolean
    Public Property Estado As Integer
    Public Property Telefono As String
    Public Property Zona As Integer
    Public Property Foto As String

End Class
