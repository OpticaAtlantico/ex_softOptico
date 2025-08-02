Imports CapaDatos
Imports CapaEntidad
Imports CapaPresentacion.LlenarComboBox
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports FontAwesome.Sharp
Public Class frmNuevoEmpleado

    Private fadeTimer As New Timer()
    Private fadeStep As Double = 0.1
    Private rutaImagenSeleccionada As String = ""

    Public Property DatosEmpleados As TEmpleados = Nothing
    Public Property NombreBoton As String = String.Empty

#Region "CONSTRUCTOR"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()

        ' Oculta al inicio para cargar limpio
        Me.Opacity = 0
        Me.Visible = False

        ' Timer para fade-in
        AddHandler fadeTimer.Tick, AddressOf FadeIn
        fadeTimer.Interval = 30

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
        Me.ResumeLayout()

        Me.Visible = True
        fadeTimer.Start()

        If DatosEmpleados IsNot Nothing Then
            CargarDatos(DatosEmpleados)
        End If

        Select Case NombreBoton
            Case "Actualizar..."
                btnAccion.Texto = "Actualizar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPen
            Case "Eliminar..."
                btnAccion.Texto = "Eliminar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserSlash
            Case Else
                btnAccion.Texto = "Guardar..."
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserTimes
        End Select

    End Sub

    Private Sub btnGuardarFoto_Click(sender As Object, e As EventArgs) Handles btnGuardarFoto.Click
        Using openDialog As New OpenFileDialog()
            openDialog.Title = "Seleccionar imagen"
            openDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif"

            If openDialog.ShowDialog() = DialogResult.OK Then
                rutaImagenSeleccionada = openDialog.FileName

                ' Cargar la imagen en el IconPictureBox
                Try
                    Dim img As Image = Image.FromFile(rutaImagenSeleccionada)
                    imgFoto.IconChar = IconChar.None ' Oculta el ícono para que se vea la imagen
                    imgFoto.BackgroundImage = img
                    imgFoto.BackgroundImageLayout = ImageLayout.Zoom
                Catch ex As Exception
                    MessageBox.Show("Error al cargar imagen: " & ex.Message)
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

    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 1 Then
            Me.Opacity += fadeStep
        Else
            fadeTimer.Stop()
        End If
    End Sub

    Private Sub PrepararUI()

        'Llenar combos con EnumItems
        EnumItems.CargarComboDesacoplado(cmbEstadoCivil, GetType(EstadoCivil))
        EnumItems.CargarComboDesacoplado(cmbNacionalidad, GetType(Nacionalidad))
        EnumItems.CargarComboDesacoplado(cmbSexo, GetType(Sexo))
        EnumItems.CargarComboDesacoplado(cmbZona, GetType(Zona))

        'Como sacar el valor de un combo desacoplado
        'Private Sub cmbEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCivil.SelectedIndexChanged
        '    Dim seleccionado As EnumItems = GetSeleccionCombo(cmbEstadoCivil)
        '    If seleccionado IsNot Nothing Then
        '        Dim idSeleccionado As Integer = seleccionado.valor
        '        Dim nombreSeleccionado As String = seleccionado.nombre
        '        Debug.Print($"ID: {idSeleccionado}, Nombre: {nombreSeleccionado}")
        '    End If
        'End Sub


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
                    MessageBox.Show("No hay datos de empleado para actualizar.")
                End If
            Case "Eliminar..."
                ' Aquí puedes implementar la lógica para eliminar el empleado
                If DatosEmpleados IsNot Nothing Then
                    Dim repositorio As New Repositorio_Empleados()
                    Dim resultado As Boolean = repositorio.EliminarEmpleado(DatosEmpleados.Cedula)
                    If resultado Then
                        MessageBox.Show("Empleado eliminado correctamente.")
                        LimpiarControles(Me)
                        limpiarImagen()
                    Else
                        MessageBox.Show("Error al eliminar el empleado.")
                    End If
                Else
                    MessageBox.Show("No hay datos de empleado para eliminar.")
                End If
            Case "Guardar..."
                ' Aquí puedes implementar la lógica para guardar un nuevo empleado
                If DatosEmpleados Is Nothing Then
                    ProcesarEmpleado(esNuevo:=True)
                Else
                    MessageBox.Show("Ya hay datos de empleado cargados.")
                End If
            Case Else
                MessageBox.Show("Acción no reconocida.")
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
                .cmbNacionalidad.IndiceSeleccionado = empleado.Nacionalidad
                .cmbEstadoCivil.IndiceSeleccionado = empleado.EstadoCivil
                .cmbSexo.IndiceSeleccionado = empleado.Sexo
                .txtFechaNac.FechaSeleccionada = empleado.FechaNacimiento
                .cmbCargo.IndiceSeleccionado = empleado.Cargo - 1
                .txtCorreo.TextoUsuario = empleado.Correo
                .txtTelefono.TextoUsuario = empleado.Telefono
                .cmbZona.IndiceSeleccionado = empleado.Zona
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
                        MessageBox.Show("Error al cargar imagen: " & ex.Message)
                    End Try
                Else
                    .limpiarImagen() ' Limpia la imagen si no hay foto
                End If

            End With

        End If
    End Sub


#End Region

#Region "SQL"

    Private Sub GuardarUsuario()
        Dim cedula As String = txtCedula.TextValue.Trim()
        Dim nombre As String = txtNombre.TextValue.Trim()
        Dim apellido As String = txtApellido.TextValue.Trim()
        Dim edad As String = txtEdad.TextValue.Trim()
        Dim nacionalidad As Integer = Convert.ToInt32(cmbNacionalidad.OrbitalCombo.ValorClave) + 1
        Dim estadoCivil As Integer = Convert.ToInt32(cmbEstadoCivil.OrbitalCombo.ValorClave) + 1
        Dim telefono As String = txtTelefono.TextValue.Trim()
        Dim correo As String = txtCorreo.TextValue.Trim()
        Dim direccion As String = txtDireccion.TextValue.Trim()
        Dim fechaNacimiento? As DateTime = txtFechaNac.FechaSeleccionada
        Dim sexo As Integer = Convert.ToInt32(cmbSexo.OrbitalCombo.ValorClave) + 1
        Dim cargo As Integer = Convert.ToInt32(cmbCargo.OrbitalCombo.ValorClave) + 1
        Dim asesor As String = swAsesor.Checked.ToString()
        Dim optometrista As String = swOptometrista.Checked.ToString()
        Dim gerente As String = swGerente.Checked.ToString()
        Dim marketing As String = swMarketing.Checked.ToString()
        Dim estado As Integer = 1
        Dim zona As Integer = Convert.ToInt32(cmbZona.OrbitalCombo.ValorClave) + 1

        If String.IsNullOrEmpty(cedula) OrElse
           String.IsNullOrEmpty(nombre) OrElse
           String.IsNullOrEmpty(apellido) OrElse
           String.IsNullOrEmpty(edad) OrElse
           String.IsNullOrEmpty(nacionalidad) OrElse
           String.IsNullOrEmpty(estadoCivil) OrElse
           String.IsNullOrEmpty(sexo) OrElse
           String.IsNullOrEmpty(telefono) OrElse
           String.IsNullOrEmpty(correo) OrElse
           String.IsNullOrEmpty(direccion) OrElse
           String.IsNullOrEmpty(cargo) Then

            ' Mostrar mensaje de error si algún campo obligatorio está vacío

            Dim msg As New ToastUI()
            msg.MostrarToast("Por favor, complete todos los campos obligatorios.", TipoToastUI.Warning)

            Return

        End If

        'Crear la carpeta foto
        Dim Ruta As String
        If Not String.IsNullOrEmpty(rutaImagenSeleccionada) Then
            Dim rutaRelativa As String = GuardarImagenEnCarpeta(rutaImagenSeleccionada, $"empleado_{txtCedula.TextValue}")
            Ruta = rutaRelativa
        Else
            Ruta = Nothing
        End If

        Dim empleado As New TEmpleados With {
            .Cedula = cedula,
            .Nombre = nombre,
            .Apellido = apellido,
            .Edad = edad,
            .Nacionalidad = nacionalidad,
            .EstadoCivil = estadoCivil,
            .Sexo = sexo,
            .Telefono = telefono,
            .Correo = correo,
            .Direccion = direccion,
            .FechaNacimiento = fechaNacimiento,
            .Cargo = cargo,
            .Asesor = asesor,
            .Optometrista = optometrista,
            .Gerente = gerente,
            .Marketing = marketing,
            .Estado = estado,
            .Zona = zona,
            .Foto = Ruta
        }

        Dim repositorio As New Repositorio_Empleados()
        Dim Mensaje As New ToastUI()
        Try
            Dim resultado As Boolean = repositorio.InsertarEmpleado(empleado)

            If resultado Then
                Mensaje.MostrarToast("Empleado guardado correctamente.", TipoToastUI.Success)
                LimpiarControles(Me)
                limpiarImagen()
                ' Aquí puedes cerrar el formulario o limpiar los campos
            Else
                ' Mostrar mensaje de error si no se pudo guardar
                Mensaje.MostrarToast("Error al guardar el empleado. Inténtelo de nuevo.", TipoToastUI.Errores)
            End If
        Catch ex As Exception
            ' Manejar excepciones y mostrar mensaje de error
            Mensaje.MostrarToast("Error al guardar el empleado: " & ex.Message, TipoToastUI.Errores)
        End Try

    End Sub

    Private Sub ActualizarUsuario()
        Dim id As Integer = DatosEmpleados.EmpleadoID
        Dim cedula As String = txtCedula.TextValue.Trim()
        Dim nombre As String = txtNombre.TextValue.Trim()
        Dim apellido As String = txtApellido.TextValue.Trim()
        Dim edad As String = txtEdad.TextValue.Trim()
        Dim nacionalidad As Integer = Convert.ToInt32(cmbNacionalidad.OrbitalCombo.ValorClave) + 1
        Dim estadoCivil As Integer = Convert.ToInt32(cmbEstadoCivil.OrbitalCombo.ValorClave) + 1
        Dim telefono As String = txtTelefono.TextValue.Trim()
        Dim correo As String = txtCorreo.TextValue.Trim()
        Dim direccion As String = txtDireccion.TextValue.Trim()
        Dim fechaNacimiento? As DateTime = txtFechaNac.FechaSeleccionada
        Dim sexo As Integer = Convert.ToInt32(cmbSexo.OrbitalCombo.ValorClave) + 1
        Dim cargo As Integer = Convert.ToInt32(cmbCargo.OrbitalCombo.ValorClave) + 1
        Dim asesor As String = swAsesor.Checked.ToString()
        Dim optometrista As String = swOptometrista.Checked.ToString()
        Dim gerente As String = swGerente.Checked.ToString()
        Dim marketing As String = swMarketing.Checked.ToString()
        Dim estado As Integer = 1
        Dim zona As Integer = Convert.ToInt32(cmbZona.OrbitalCombo.ValorClave) + 1

        If String.IsNullOrEmpty(cedula) OrElse
           String.IsNullOrEmpty(nombre) OrElse
           String.IsNullOrEmpty(apellido) OrElse
           String.IsNullOrEmpty(edad) OrElse
           String.IsNullOrEmpty(nacionalidad) OrElse
           String.IsNullOrEmpty(estadoCivil) OrElse
           String.IsNullOrEmpty(sexo) OrElse
           String.IsNullOrEmpty(telefono) OrElse
           String.IsNullOrEmpty(correo) OrElse
           String.IsNullOrEmpty(direccion) OrElse
           String.IsNullOrEmpty(cargo) Then

            ' Mostrar mensaje de error si algún campo obligatorio está vacío

            Dim msg As New ToastUI()
            msg.MostrarToast("Por favor, complete todos los campos obligatorios.", TipoToastUI.Warning)

            Return

        End If

        'Crear la carpeta foto
        Dim Ruta As String
        If Not String.IsNullOrEmpty(rutaImagenSeleccionada) Then
            Dim rutaRelativa As String = GuardarImagenEnCarpeta(rutaImagenSeleccionada, $"empleado_{txtCedula.TextValue}")
            Ruta = rutaRelativa
        Else
            Ruta = Nothing
        End If

        Dim empleado As New TEmpleados With {
            .EmpleadoID = id,
            .Cedula = cedula,
            .Nombre = nombre,
            .Apellido = apellido,
            .Edad = edad,
            .Nacionalidad = nacionalidad,
            .EstadoCivil = estadoCivil,
            .Sexo = sexo,
            .Telefono = telefono,
            .Correo = correo,
            .Direccion = direccion,
            .FechaNacimiento = fechaNacimiento,
            .Cargo = cargo,
            .Asesor = asesor,
            .Optometrista = optometrista,
            .Gerente = gerente,
            .Marketing = marketing,
            .Estado = estado,
            .Zona = zona,
            .Foto = Ruta
        }

        Dim repositorio As New Repositorio_Empleados()
        Dim Mensaje As New ToastUI()
        Try
            Dim resultado As Boolean = repositorio.ActualizarEmpleado(empleado)

            If resultado Then
                Mensaje.MostrarToast("Empleado actualizado correctamente.", TipoToastUI.Success)
                LimpiarControles(Me)
                limpiarImagen()
                ' Aquí puedes cerrar el formulario o limpiar los campos
            Else
                ' Mostrar mensaje de error si no se pudo guardar
                Mensaje.MostrarToast("Error al actualizar los datos del empleado. Inténtelo de nuevo.", TipoToastUI.Errores)
            End If
        Catch ex As Exception
            ' Manejar excepciones y mostrar mensaje de error
            Mensaje.MostrarToast("Error al actualizar el empleado: " & ex.Message, TipoToastUI.Errores)
        End Try

    End Sub

    Private Function ObtenerDatosEmpleado(Optional ByVal incluirID As Boolean = False) As ResultadoEmpleado
        Dim resultado As New ResultadoEmpleado()
        Dim mensaje As New ToastUI()

        Try
            Dim id As Integer = If(incluirID, DatosEmpleados.EmpleadoID, 0)
            Dim cedula = txtCedula.TextValue.Trim()
            Dim nombre = txtNombre.TextValue.Trim()
            Dim apellido = txtApellido.TextValue.Trim()
            Dim edad = txtEdad.TextValue.Trim()
            Dim nacionalidad = Convert.ToInt32(cmbNacionalidad.OrbitalCombo.ValorClave) + 1
            Dim estadoCivil = Convert.ToInt32(cmbEstadoCivil.OrbitalCombo.ValorClave) + 1
            Dim telefono = txtTelefono.TextValue.Trim()
            Dim correo = txtCorreo.TextValue.Trim()
            Dim direccion = txtDireccion.TextValue.Trim()
            Dim fechaNacimiento? = txtFechaNac.FechaSeleccionada
            Dim sexo = Convert.ToInt32(cmbSexo.OrbitalCombo.ValorClave) + 1
            Dim cargo = Convert.ToInt32(cmbCargo.OrbitalCombo.ValorClave) + 1
            Dim zona = Convert.ToInt32(cmbZona.OrbitalCombo.ValorClave) + 1

            If {cedula, nombre, apellido, edad, nacionalidad, estadoCivil, sexo, telefono, correo, direccion, cargo}.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                mensaje.MostrarToast("Por favor, complete todos los campos obligatorios.", TipoToastUI.Warning)
                resultado.EsValido = False
                Return resultado
            End If

            ' Ruta de imagen
            Dim rutaRelativa As String = If(Not String.IsNullOrEmpty(rutaImagenSeleccionada),
                                        GuardarImagenEnCarpeta(rutaImagenSeleccionada, $"empleado_{cedula}"),
                                        Nothing)

            resultado.Empleado = New TEmpleados With {
            .EmpleadoID = id,
            .Cedula = cedula,
            .Nombre = nombre,
            .Apellido = apellido,
            .Edad = edad,
            .Nacionalidad = Convert.ToInt32(nacionalidad) + 1,
            .EstadoCivil = Convert.ToInt32(estadoCivil) + 1,
            .Sexo = Convert.ToInt32(sexo) + 1,
            .Telefono = telefono,
            .Correo = correo,
            .Direccion = direccion,
            .FechaNacimiento = fechaNacimiento,
            .Cargo = Convert.ToInt32(cargo) + 1,
            .Zona = Convert.ToInt32(zona) + 1,
            .Asesor = swAsesor.Checked.ToString(),
            .Optometrista = swOptometrista.Checked.ToString(),
            .Gerente = swGerente.Checked.ToString(),
            .Marketing = swMarketing.Checked.ToString(),
            .Estado = 1,
            .Foto = If(String.IsNullOrWhiteSpace(rutaRelativa), "", rutaRelativa)
        }

            resultado.EsValido = True
        Catch ex As Exception
            mensaje.MostrarToast("Error al obtener los datos: " & ex.Message, TipoToastUI.Errores)
            resultado.EsValido = False
        End Try

        Return resultado
    End Function

    Private Sub ProcesarEmpleado(esNuevo As Boolean)
        Dim datos = ObtenerDatosEmpleado(incluirID:=Not esNuevo)

        If Not datos.EsValido Then Exit Sub

        Dim repositorio As New Repositorio_Empleados()
        Dim mensaje As New ToastUI()
        Dim exito As Boolean = False

        Try
            If esNuevo Then
                exito = repositorio.InsertarEmpleado(datos.Empleado)
            Else
                exito = repositorio.ActualizarEmpleado(datos.Empleado)
            End If

            If exito Then
                mensaje.MostrarToast(If(esNuevo, "Empleado guardado correctamente.", "Empleado actualizado correctamente."), TipoToastUI.Success)
                LimpiarControles(Me)
                limpiarImagen()
            Else
                mensaje.MostrarToast("Ocurrió un error al procesar la operación.", TipoToastUI.Errores)
            End If
        Catch ex As Exception
            mensaje.MostrarToast("Error: " & ex.Message, TipoToastUI.Errores)
        End Try
    End Sub



#End Region


End Class