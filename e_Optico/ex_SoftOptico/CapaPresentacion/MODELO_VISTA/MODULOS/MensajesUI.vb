' 📌 Módulo central de mensajes para el sistema Orbital
Public Module MensajesUI

    ' ✅ Éxitos
    Public Const RegistroExitoso As String = "El registro se ha completado correctamente."
    Public Const ActualizacionExitosa As String = "La información se ha actualizado correctamente."
    Public Const EliminacionExitosa As String = "El registro se ha eliminado correctamente."

    ' ⚠️ Advertencias
    Public Const DatosIncompletos As String = "Debe completar todos los campos obligatorios antes de continuar."
    Public Const ConfirmarAccion As String = "¿Está seguro de que desea continuar con la operación?"

    ' ❌ Errores
    Public Const OperacionFallida As String = "No fue posible procesar la operación. Verifique los datos e intente nuevamente."
    Public Const RegistroDuplicado As String = "Ya existe un registro con la misma información. Verifique los datos e intente nuevamente."
    Public Const ErrorInesperado As String = "Ocurrió un error inesperado. Detalle: {0}"
    Public Const ErrorCargarFotos As String = "Error al cargar la foto. Detalle: {0}"

    ' ℹ️ Información
    Public Const ProcesoEnCurso As String = "La operación se está procesando, por favor espere."
    Public Const SinResultados As String = "No se encontraron registros con los criterios especificados."
    Public Const GridSinDatos As String = "No hay información que limpiar en la tabla de datos"
    Public Const CompletarDatos As String = "Debe agregar al menos un producto para continuar"


    ' 📌 Títulos estándar
    Public Const TituloExito As String = "Operación exitosa"
    Public Const TituloAdvertencia As String = "Advertencia"
    Public Const TituloError As String = "Error en la operación"
    Public Const TituloInfo As String = "Información"

End Module

'If exito Then
'Dim mensaje As New ToastUI(
'        If(esNuevo, MensajesUI.RegistroExitoso, MensajesUI.ActualizacionExitosa),
'        TipoToastUI.Success)
'mensaje.Mostrar()
'Else
'MessageBoxUI.Mostrar(MensajesUI.TituloError,
'                         MensajesUI.OperacionFallida,
'                         TipoMensaje.Errors, Botones.Aceptar)
'End If

'MessageBoxUI.Mostrar(MensajesUI.TituloError,
'                     MensajesUI.RegistroDuplicado,
'                     TipoMensaje.Errors, Botones.Aceptar)

'MessageBoxUI.Mostrar(MensajesUI.TituloError,
'                     String.Format(MensajesUI.ErrorInesperado, ex.Message),
'                     TipoMensaje.Errors, Botones.Aceptar)

