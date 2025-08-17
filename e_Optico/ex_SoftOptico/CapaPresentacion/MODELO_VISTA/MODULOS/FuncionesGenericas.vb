Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp

Module FuncionesGenericas

    'ELIMINAR UN EMPLEADO Y SU FOTO
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
                Dim toast As New ToastUI("Empleado eliminado correctamente.", TipoToastUI.Success)
                toast.Mostrar()
                Return True
            Else
                Dim toast As New ToastUI("No se pudo eliminar el empleado.", TipoToastUI.Warning)
                toast.Mostrar()
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar empleado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'Guarda una imagen de empleado en la carpeta "FotosEmpleados" dentro del directorio de la aplicación.
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

    'CONVERTIR UNA LISTA A UN DATATABLE
    Public Function ConvertirListaADataTable(Of T)(lista As List(Of T)) As DataTable
        Dim tabla As New DataTable(GetType(T).Name)
        Dim propiedades As PropertyInfo() = GetType(T).GetProperties()

        For Each prop In propiedades
            Dim tipo As Type = If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType)
            tabla.Columns.Add(prop.Name, tipo)
        Next

        For Each item In lista
            Dim fila = tabla.NewRow()
            For Each prop In propiedades
                fila(prop.Name) = If(prop.GetValue(item, Nothing), DBNull.Value)
            Next
            tabla.Rows.Add(fila)
        Next

        Return tabla
    End Function

    'CONVERTIR UN IconChar A UN Bitmap
    Public Function IconCharToBitmap(icono As IconChar, color As Color, tamaño As Integer) As Bitmap
        Using iconBox As New IconPictureBox()
            iconBox.IconChar = icono
            iconBox.IconColor = color
            iconBox.IconSize = tamaño
            iconBox.Size = New Size(tamaño, tamaño)
            iconBox.BackColor = Color.Transparent

            Dim bmp As New Bitmap(tamaño, tamaño, PixelFormat.Format32bppArgb)
            iconBox.DrawToBitmap(bmp, New Rectangle(0, 0, tamaño, tamaño))
            Return bmp
        End Using
    End Function

End Module
