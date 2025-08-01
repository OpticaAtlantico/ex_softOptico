Imports System.IO

Module FuncionesGenericas
    Public Function GuardarImagenEnCarpeta(rutaOrigen As String, nombreImagen As String) As String
        Try
            If String.IsNullOrWhiteSpace(rutaOrigen) OrElse Not File.Exists(rutaOrigen) Then
                Throw New FileNotFoundException("La imagen no existe.")
            End If

            ' Crear carpeta Fotos si no existe
            Dim carpetaFotos As String = Path.Combine(Application.StartupPath, "Fotos")
            If Not Directory.Exists(carpetaFotos) Then
                Directory.CreateDirectory(carpetaFotos)
            End If

            ' Obtener extensión original del archivo
            Dim extension As String = Path.GetExtension(rutaOrigen)
            Dim nombreFinal As String = $"{nombreImagen}{extension}"
            Dim rutaDestinoCompleta As String = Path.Combine(carpetaFotos, nombreFinal)

            ' Copiar la imagen a la carpeta Fotos
            File.Copy(rutaOrigen, rutaDestinoCompleta, True)

            ' Devolver ruta relativa
            Return $"Fotos/{nombreFinal}"

        Catch ex As Exception
            MessageBox.Show("Error al guardar imagen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

End Module
