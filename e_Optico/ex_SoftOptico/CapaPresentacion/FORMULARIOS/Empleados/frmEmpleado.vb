Imports System.Drawing
Imports CapaDatos
Imports CapaEntidad
Imports FontAwesome.Sharp
Imports Microsoft.Data.SqlClient
Public Class frmEmpleado
    Inherits Form

    Private rutaImagenSeleccionada As String = ""
    Private llenarCombo As New LlenarComboBox
    Public Property DatosEmpleados As VEmpleados = Nothing
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
    Private Sub frmEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        FadeManagerUI.StartFade(Me, 0.05)

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
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         String.Format(MensajesUI.ErrorCargarFotos, ex.Message),
                                         TipoMensaje.Errors, Botones.Aceptar)
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
        CargarCombos.CargarComboDesacoplado(cmbEstadoCivil, GetType(EstadoCivil))
        CargarCombos.CargarComboDesacoplado(cmbNacionalidad, GetType(Nacionalidad))
        CargarCombos.CargarComboDesacoplado(cmbSexo, GetType(Sexo))
        CargarCombos.CargarComboDesacoplado(cmbZona, GetType(Zona))

        'LLENAR COMBO
        llenarCombo.Cargar(cmbCargo, llenarCombo.SQL_CARGOEMPLEADOS, "Descripcion", "CargoEmpleadoID")
    End Sub

    Private Sub bntAccion_Click(sender As Object, e As EventArgs) Handles btnAccion.Click
        Select Case btnAccion.Texto
            Case "Actualizar..."
                ' Aquí puedes implementar la lógica para actualizar el empleado
                If DatosEmpleados IsNot Nothing Then
                    ProcesarEmpleado(esNuevo:=False)
                Else
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         MensajesUI.SinResultados,
                                         TipoMensaje.Advertencia, Botones.Aceptar)
                End If
            Case "Eliminar..."
                ' Aquí puedes implementar la lógica para eliminar el empleado
                Dim empleadoId As Integer = DatosEmpleados._empleadoID
                Dim rutaFoto As String = DatosEmpleados._foto ' Ejemplo: "Fotos/empleado_1234.jpg"

                Dim confirmacion = MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                                         MensajesUI.ConfirmarAccion,
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
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                         MensajesUI.RegistroDuplicado,
                                         TipoMensaje.Advertencia,
                                         Botones.Aceptar
                                         )

                End If
            Case Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                     MensajesUI.OperacionFallida,
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
    Public Sub CargarDatos(ByVal empleado As VEmpleados)
        ' Primero, verificamos que el objeto no sea nulo para evitar errores.
        If empleado IsNot Nothing Then
            ' Asignamos los datos del objeto a los controles
            With Me
                .txtCedula.TextoUsuario = empleado._cedula
                .txtNombre.TextoUsuario = empleado._nombre
                .txtApellido.TextoUsuario = empleado._apellido
                .txtEdad.TextoUsuario = empleado._edad
                .cmbNacionalidad.OrbitalCombo.Text = empleado._nacionalidad ' Asumiendo que el índice comienza en 0
                .cmbEstadoCivil.OrbitalCombo.Text = empleado._estadoCivil
                .cmbSexo.OrbitalCombo.Text = empleado._sexo
                .txtFechaNac.FechaSeleccionada = empleado._fechaNacimiento
                .cmbCargo.OrbitalCombo.Text = empleado._cargo
                .txtCorreo.TextoUsuario = empleado._correo
                .txtTelefono.TextoUsuario = empleado._telefono
                .cmbZona.OrbitalCombo.Text = empleado._zona
                .txtDireccion.TextoUsuario = empleado._direccion
                .swAsesor.Checked = If(empleado._asesor = "True", True, False)
                .swOptometrista.Checked = If(empleado._optometrista = "True", True, False)
                .swGerente.Checked = If(empleado._gerente = "True", True, False)
                .swMarketing.Checked = If(empleado._marketing = "True", True, False)
                ' Si tienes un control para mostrar la foto, lo asignas aquí
                If Not String.IsNullOrEmpty(empleado._foto) Then
                    Try
                        Dim img As Image = Image.FromFile(empleado._foto)
                        .imgFoto.BackgroundImage = img
                        .imgFoto.BackgroundImageLayout = ImageLayout.Zoom
                        .imgFoto.IconChar = FontAwesome.Sharp.IconChar.None ' Oculta el ícono para que se vea la imagen
                    Catch ex As Exception

                        MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                             String.Format(MensajesUI.ErrorCargarFotos, ex.Message),
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
            Dim id As Integer = If(incluirID, DatosEmpleados._empleadoID, 0)
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
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                    MensajesUI.DatosIncompletos,
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
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
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
                exito = repositorio.Add(datos.Empleado)
            Else
                exito = repositorio.Edit(datos.Empleado)
            End If

            If exito Then
                Dim mensaje As New ToastUI(If(esNuevo, MensajesUI.RegistroExitoso,
                                                       MensajesUI.ActualizacionExitosa), TipoToastUI.Success)
                mensaje.Mostrar()

                LimpiarControles(Me)
                limpiarImagen()

            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                    MensajesUI.ErrorInesperado,
                                    TipoMensaje.Errors,
                                    Botones.Aceptar
                                    )
            End If
        Catch ex As Exception
            If TypeOf ex.InnerException Is SqlException Then
                Dim sqlEx = CType(ex.InnerException, SqlException)
                If sqlEx.Number = 2627 Then
                    MessageBoxUI.Mostrar(MensajesUI.TituloAdvertencia,
                                         MensajesUI.RegistroDuplicado,
                                         TipoMensaje.Errors, Botones.Aceptar)
                    Exit Sub
                End If
            End If

            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                 TipoMensaje.Errors,
                                 Botones.Aceptar
                                )
        End Try
    End Sub

#End Region


End Class