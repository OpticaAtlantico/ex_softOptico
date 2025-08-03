Imports System.IO
Imports CapaDatos

Module FuncionesGenericas

    Public Function EliminarEmpleado(empleadoId As Integer, rutaFoto As String) As Boolean
        Try
            ' === 1. Eliminar de la base de datos ===
            Dim repositorio As New Repositorio_Empleados()
            Dim eliminado As Boolean = repositorio.EliminarEmpleado(empleadoId)

            If eliminado Then
                ' === 2. Eliminar la imagen si existe ===
                If Not String.IsNullOrWhiteSpace(rutaFoto) Then
                    Dim rutaAbsoluta As String = Path.Combine(Application.StartupPath, rutaFoto)

                    If File.Exists(rutaAbsoluta) Then
                        Try
                            File.Delete(rutaAbsoluta)
                        Catch ex As IOException
                            MessageBox.Show("La imagen no se pudo eliminar. Está siendo utilizada por otro proceso.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End If
                End If

                ' Mostrar mensaje exitoso
                Dim toast As New ToastUI()
                toast.MostrarToast("Empleado eliminado correctamente.", TipoToastUI.Success)
                Return True
            Else
                Dim toast As New ToastUI()
                toast.MostrarToast("No se pudo eliminar el empleado.", TipoToastUI.Warning)
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Public Function GuardarImagenEmpleado(rutaOrigen As String, nombreArchivoSinExtension As String) As String
        If String.IsNullOrWhiteSpace(rutaOrigen) OrElse Not File.Exists(rutaOrigen) Then
            Return Nothing ' No hay imagen válida para guardar
        End If

        Try
            ' Ruta destino
            Dim carpetaDestino As String = Path.Combine(Application.StartupPath, "FotosEmpleados")
            If Not Directory.Exists(carpetaDestino) Then
                Directory.CreateDirectory(carpetaDestino)
            End If

            ' Obtener extensión y construir ruta final
            Dim extension As String = Path.GetExtension(rutaOrigen)
            Dim rutaFinal As String = Path.Combine(carpetaDestino, $"{nombreArchivoSinExtension}{extension}")

            ' Si ya existe, liberarla y eliminarla
            If File.Exists(rutaFinal) Then
                Try
                    Using img As Image = Image.FromFile(rutaFinal)
                        img.Dispose()
                    End Using
                    File.Delete(rutaFinal)
                Catch ex As Exception
                    MessageBox.Show("No se pudo reemplazar la imagen anterior: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                End Try
            End If

            ' Copiar la nueva imagen
            File.Copy(rutaOrigen, rutaFinal, overwrite:=True)
            Return rutaFinal

        Catch ex As Exception
            MessageBox.Show("Error al guardar imagen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

End Module
