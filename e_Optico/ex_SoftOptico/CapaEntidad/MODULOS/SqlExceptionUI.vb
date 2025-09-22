Imports Microsoft.Data.SqlClient

Public Module SqlExceptionUI

    ''' <summary>
    ''' Devuelve un mensaje amigable en base al número de error SQL.
    ''' </summary>
    ''' <param name="ex">SqlException capturada</param>
    ''' <returns>Mensaje traducido</returns>
    Public Function ObtenerMensajeSql(ex As SqlException) As String
        Select Case ex.Number
            Case 2627, 2601
                Return "El registro ya existe (clave o valor id duplicada)."
            Case 547
                Return "No se puede eliminar porque tiene registros relacionados."
            Case 515
                Return "Debe completar todos los campos obligatorios."
            Case 8114, 245
                Return "El formato de datos no es válido."
            Case 18456
                Return "Error de autenticación con la base de datos."
            Case 4060
                Return "La base de datos especificada no está disponible."
            Case 53
                Return "No se puede conectar al servidor SQL."
            Case 1205
                Return "Conflicto de concurrencia, intente de nuevo."
            Case 50000
                Return ex.Message ' Mensaje lanzado desde la BD con RAISERROR o THROW
            Case Else
                ' Mensaje genérico + detalle técnico
                Return $"Error SQL inesperado (#{ex.Number}): {ex.Message}"
        End Select
    End Function

End Module