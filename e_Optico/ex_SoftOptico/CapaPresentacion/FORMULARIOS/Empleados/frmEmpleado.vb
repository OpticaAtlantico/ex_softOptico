Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Imports System.Drawing
Public Class frmEmpleado
    Inherits Form

    Private rutaImagenSeleccionada As String = ""

    Public Property DatosEmpleados As TEmpleados = Nothing
    Public Property NombreBoton As String = String.Empty

#Region "CONSTRUCTOR"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        FormStylerUI.Apply(Me)

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    ' Aplica WS_EX_COMPOSITED para suavizar repintado de todo el formulario
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

#End Region

#Region "EVENTOS DEL FORMULARIO"
    Private Sub frmNuevoEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form components or load data if necessary
        Me.SuspendLayout()
        PrepararUI()

        If DatosEmpleados IsNot Nothing Then
            CargarDatos(DatosEmpleados)
        End If

        btnAccion.Cursor = Cursors.Hand
        btnAccion.ColorTexto = Color.DarkSlateBlue
        Select Case NombreBoton
            Case "Actualizar..."
                btnAccion.Texto = "Actualizar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPen
            Case "Eliminar..."
                btnAccion.Texto = "Eliminar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserTimes
            Case Else
                btnAccion.Texto = "Guardar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPlus
        End Select

        With Me.Headerui1
            .Titulo = "Nuevo Empleado"
            .Subtitulo = "Ingrese los datos del nuevo empleado..."
            .Icono = IconChar.UserGear
            .ColorFondo = Color.FromArgb(0, 191, 192)
            .ColorTexto = Color.WhiteSmoke
        End With
        Me.ResumeLayout()
        FadeManagerUI.StartFade(Me, FadeDirection.FadeIn, 0.05)

    End Sub

    Private Sub btnGuardarFoto_Click(sender As Object, e As EventArgs) Handles btnGuardarFoto.Click
        Using openDialog As New OpenFileDialog()
            openDialog.Title = "Seleccionar imagen"
            openDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

            If openDialog.ShowDialog() = DialogResult.OK Then
                rutaImagenSeleccionada = openDialog.FileName

                ' Cargar la imagen en el IconPictureBox sin bloquear el archivo
                Try
                    Using imgTemp As Image = Image.FromFile(rutaImagenSeleccionada)
                        Dim imgClonada As Image = New Bitmap(imgTemp) ' Clonar para evitar lock
                        imgFoto.IconChar = IconChar.None
                        imgFoto.BackgroundImage = imgClonada
                        imgFoto.BackgroundImageLayout = ImageLayout.Zoom
                    End Using
                Catch ex As Exception
                    MessageBoxUI.Mostrar("Error...", "Error al cargar la imagen: " & ex.Message, TipoMensaje.Errors, Botones.Aceptar)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnEliminarFoto_Click(sender As Object, e As EventArgs) Handles btnEliminarFoto.Click
        ' Elimina la imagen mostrada
        limpiarImagen()

        '' Borra la ruta almacenada
        rutaImagenSeleccionada = ""

    End Sub

    Private Sub txtCedula_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedula.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtNombre_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtApellido_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellido.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtEdad_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEdad.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtFechaNac_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFechaNac.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtCorreo_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreo.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

    Private Sub txtTelefono_CampoKeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.CampoKeyPress
        AvanzarConEnter(e, CType(sender, Control), Me)
    End Sub

#End Region

#Region "PROCEDIMIENTOS"
    Private Sub PrepararUI()

        'Llenar combos con EnumItems
        EnumItems.CargarComboDesacoplado(cmbEstadoCivil, GetType(EstadoCivil))
        EnumItems.CargarComboDesacoplado(cmbNacionalidad, GetType(Nacionalidad))
        EnumItems.CargarComboDesacoplado(cmbSexo, GetType(Sexo))
        EnumItems.CargarComboDesacoplado(cmbZona, GetType(Zona))

        'llenar combos desde la base de datos
        Dim llenarCombo As New LlenarComboBox

        Dim sql As String = "SELECT CargoEmpleadoID, Descripcion FROM TCargoEmpleado"
        llenarCombo.Cargar(cmbCargo, sql, "Descripcion", "CargoEmpleadoID")

        'Para obtener el co seleccionado y el texto

        'Dim idSeleccionado As Integer = Convert.ToInt32(cmbNacionalidad.ValorClave)
        'Dim textoSeleccionado As String = cmbNacionalidad.ValorTexto

    End Sub

    Private Sub bntAccion_Click(sender As Object, e As EventArgs) Handles btnAccion.Click
        Select Case btnAccion.Texto
            Case "Actualizar..."
                ' Aquí puedes implementar la lógica para actualizar el empleado
                If DatosEmpleados IsNot Nothing Then
                    ProcesarEmpleado(esNuevo:=False)
                Else
                    MessageBoxUI.Mostrar("Sin actualizar...",
                                         "No hay datos del empleado que actualizar... ",
                                         TipoMensaje.Advertencia, Botones.Aceptar)
                End If
            Case "Eliminar..."
                ' Aquí puedes implementar la lógica para eliminar el empleado
                Dim empleadoId As Integer = DatosEmpleados.EmpleadoID
                Dim rutaFoto As String = DatosEmpleados.Foto ' Ejemplo: "Fotos/empleado_1234.jpg"

                Dim confirmacion = MessageBoxUI.Mostrar("Eliminando...",
                                                         "¿Está usted seguro de eliminar el empleado seleccionado?",
                                                         TipoMensaje.Informacion,
                                                         Botones.AceptarCancelar
                                                       )

                ' Verifica si el usuario confirmó la eliminación
                If confirmacion = DialogResult.Yes Then
                    EliminarEmpleado(empleadoId, rutaFoto)
                    Me.Close() ' Cierra el formulario después de eliminar
                    frm_Principal.btnSalirFrmHijo.Visible = False ' Deshabilita botones de la ventana principal  
                End If

            Case "Guardar..."
                ' Aquí puedes implementar la lógica para guardar un nuevo empleado
                If DatosEmpleados Is Nothing Then
                    ProcesarEmpleado(esNuevo:=True)
                Else
                    ' Si ya hay datos de empleados, muestra un mensaje de advertencia
                    MessageBoxUI.Mostrar("Guardar datos...",
                                         "Ya hay datos de empleados almacenados...",
                                         TipoMensaje.Advertencia,
                                         Botones.Aceptar
                                         )

                End If
            Case Else
                MessageBoxUI.Mostrar("Sin datos...",
                                     "La acción que intenta ejecutar no es reconocida",
                                    TipoMensaje.Informacion,
                                    Botones.Aceptar
                                    )
        End Select
    End Sub

    Private Sub LimpiarControles(container As Control)
        container.SuspendLayout()

        For Each ctrl As Control In container.Controls
            If TypeOf ctrl Is TextBoxLabelUI Then
                Dim c = CType(ctrl, TextBoxLabelUI)
                c.TextoUsuario = ""

            ElseIf TypeOf ctrl Is ComboBoxLabelUI Then
                Dim c = CType(ctrl, ComboBoxLabelUI)
                c.Limpiar()

            ElseIf TypeOf ctrl Is MaskedTextBoxLabelUI Then
                Dim c = CType(ctrl, MaskedTextBoxLabelUI)
                c.TextoUsuario = ""

            ElseIf TypeOf ctrl Is MultilineTextBoxLabelUI Then
                Dim c = CType(ctrl, MultilineTextBoxLabelUI)
                c.TextoUsuario = ""

            ElseIf TypeOf ctrl Is ToggleSwitchUI Then
                CType(ctrl, ToggleSwitchUI).Checked = False

            ElseIf ctrl.HasChildren Then
                ' Llamada recursiva para paneles o groupboxes
                LimpiarControles(ctrl)
            End If
        Next

        container.ResumeLayout()
        container.PerformLayout()
    End Sub

    Private Sub limpiarImagen()
        imgFoto.BackgroundImage = Nothing

        ' (Opcional) restaurar el ícono por defecto si quieres
        imgFoto.BorderStyle = BorderStyle.FixedSingle
        imgFoto.IconChar = FontAwesome.Sharp.IconChar.UserGear
        imgFoto.IconColor = SystemColors.AppWorkspace
        imgFoto.IconFont = FontAwesome.Sharp.IconFont.Auto
        imgFoto.IconSize = 196
    End Sub

    ' Recibe un objeto TEmpleados y rellena los controles del formulario.
    Public Sub CargarDatos(ByVal empleado As TEmpleados)
        ' Primero, verificamos que el objeto no sea nulo para evitar errores.
        If empleado IsNot Nothing Then
            ' Asignamos los datos del objeto a los controles
            With Me
                .txtCedula.TextoUsuario = empleado.Cedula
                .txtNombre.TextoUsuario = empleado.Nombre
                .txtApellido.TextoUsuario = empleado.Apellido
                .txtEdad.TextoUsuario = empleado.Edad
                .cmbNacionalidad.OrbitalCombo.SelectedIndex = Convert.ToInt32(empleado.Nacionalidad) ' Asumiendo que el índice comienza en 0
                .cmbEstadoCivil.OrbitalCombo.SelectedIndex = Convert.ToInt32(empleado.EstadoCivil)
                .cmbSexo.OrbitalCombo.SelectedIndex = Convert.ToInt32(empleado.Sexo)
                .txtFechaNac.FechaSeleccionada = empleado.FechaNacimiento
                .cmbCargo.OrbitalCombo.Text = empleado.Cargo
                .txtCorreo.TextoUsuario = empleado.Correo
                .txtTelefono.TextoUsuario = empleado.Telefono
                .cmbZona.OrbitalCombo.SelectedIndex = Convert.ToInt32(empleado.Zona)
                .txtDireccion.TextoUsuario = empleado.Direccion
                .swAsesor.Checked = If(empleado.Asesor = "True", True, False)
                .swOptometrista.Checked = If(empleado.Optometrista = "True", True, False)
                .swGerente.Checked = If(empleado.Gerente = "True", True, False)
                .swMarketing.Checked = If(empleado.Marketing = "True", True, False)
                ' Si tienes un control para mostrar la foto, lo asignas aquí
                If Not String.IsNullOrEmpty(empleado.Foto) Then
                    Try
                        Dim img As Image = Image.FromFile(empleado.Foto)
                        .imgFoto.BackgroundImage = img
                        .imgFoto.BackgroundImageLayout = ImageLayout.Zoom
                        .imgFoto.IconChar = FontAwesome.Sharp.IconChar.None ' Oculta el ícono para que se vea la imagen
                    Catch ex As Exception

                        MessageBoxUI.Mostrar("Cargando...",
                                             "Error al cargar la foto del empleado..." & ex.Message,
                                             TipoMensaje.Errors,
                                             Botones.Aceptar
                                            )
                    End Try
                Else
                    .limpiarImagen() ' Limpia la imagen si no hay foto
                End If

            End With

        End If
    End Sub

#End Region

#Region "SQL"

    Private Function ObtenerDatosEmpleado(Optional ByVal incluirID As Boolean = False) As ResultadoEmpleados
        Dim resultado As New ResultadoEmpleados()

        Try
            Dim id As Integer = If(incluirID, DatosEmpleados.EmpleadoID, 0)
            Dim cedula = txtCedula.TextValue.Trim()
            Dim nombre = txtNombre.TextValue.Trim()
            Dim apellido = txtApellido.TextValue.Trim()
            Dim edad = txtEdad.TextValue.Trim()
            Dim nacionalidad = Convert.ToInt32(cmbNacionalidad.IndiceSeleccionado)
            Dim estadoCivil = Convert.ToInt32(cmbEstadoCivil.IndiceSeleccionado)
            Dim telefono = txtTelefono.TextValue.Trim()
            Dim correo = txtCorreo.TextValue.Trim()
            Dim direccion = txtDireccion.TextValue.Trim()
            Dim fechaNacimiento? = txtFechaNac.FechaSeleccionada
            Dim sexo = Convert.ToInt32(cmbSexo.IndiceSeleccionado)
            Dim cargo = Convert.ToInt32(cmbCargo.IndiceSeleccionado) + 1 ' Asumiendo que el índice comienza en 0
            Dim zona = Convert.ToInt32(cmbZona.IndiceSeleccionado)

            If {cedula, nombre, apellido, edad, nacionalidad, estadoCivil, sexo, telefono, correo, direccion, cargo}.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar("Cargando...",
                                    "Por favor, complete todos los campos obligatorios.",
                                    TipoMensaje.Advertencia,
                                    Botones.Aceptar
                                    )

                resultado.EsValido = False
                Return resultado
            End If

            ' Ruta de imagen
            Dim rutaRelativa As String = GuardarImagenEmpleado(rutaImagenSeleccionada, $"empleado_{cedula}")

            resultado.Empleado = New TEmpleados With {
            .EmpleadoID = id,
            .Cedula = cedula,
            .Nombre = nombre,
            .Apellido = apellido,
            .Edad = edad,
            .Nacionalidad = Convert.ToInt32(nacionalidad),
            .EstadoCivil = Convert.ToInt32(estadoCivil),
            .Sexo = Convert.ToInt32(sexo),
            .Telefono = telefono,
            .Correo = correo,
            .Direccion = direccion,
            .FechaNacimiento = fechaNacimiento,
            .Cargo = Convert.ToInt32(cargo),
            .Zona = Convert.ToInt32(zona),
            .Asesor = swAsesor.Checked.ToString(),
            .Optometrista = swOptometrista.Checked.ToString(),
            .Gerente = swGerente.Checked.ToString(),
            .Marketing = swMarketing.Checked.ToString(),
            .Estado = 1,
            .Foto = If(String.IsNullOrWhiteSpace(rutaRelativa), "", rutaRelativa)
        }

            resultado.EsValido = True
        Catch ex As Exception
            MessageBoxUI.Mostrar("Cargando...",
                                 "Error al obtener los datos" & ex.Message,
                                    TipoMensaje.Errors,
                                    Botones.Aceptar
                                    )

            resultado.EsValido = False
        End Try

        Return resultado
    End Function

    Private Sub ProcesarEmpleado(esNuevo As Boolean)
        Dim datos = ObtenerDatosEmpleado(incluirID:=Not esNuevo)

        If Not datos.EsValido Then Exit Sub

        Dim repositorio As New Repositorio_Empleados()

        Dim exito As Boolean = False

        Try
            If esNuevo Then
                exito = repositorio.InsertarEmpleado(datos.Empleado)
            Else
                exito = repositorio.ActualizarEmpleado(datos.Empleado)
            End If

            If exito Then
                Dim mensaje As New ToastUI(If(esNuevo, "Empleado guardado correctamente.", "Empleado actualizado correctamente."), TipoToastUI.Success)
                mensaje.Mostrar()

                LimpiarControles(Me)
                limpiarImagen()

            Else
                MessageBoxUI.Mostrar("Procesando...",
                                    "Ocurrió un error al procesar la operación.",
                                    TipoMensaje.Errors,
                                    Botones.Aceptar
                                    )
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error...",
                                 "Ha ocurrido un error al procesar los datos del empleado..." & ex.Message,
                                 TipoMensaje.Errors,
                                 Botones.Aceptar
                                )

        End Try
    End Sub

#End Region


End Class