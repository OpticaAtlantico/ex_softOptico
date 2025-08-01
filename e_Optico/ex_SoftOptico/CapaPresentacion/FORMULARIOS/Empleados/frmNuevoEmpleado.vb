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
        'limpiarImagen()

        '' Borra la ruta almacenada
        'rutaImagenSeleccionada = ""

        Dim inputForm As New InputBoxUI("Ingrese su nombre", "Ej: Wilmer", IconChar.User)
        Dim resultado = inputForm.ShowDialog()

        If resultado = DialogResult.OK Then
            Dim texto = inputForm.ValorIngresado
            MessageBox.Show("Ingresado: " & texto)
        Else
            MessageBox.Show("Cancelado")
        End If
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

    Private Sub bntGuardar_Click(sender As Object, e As EventArgs) Handles bntGuardar.Click
        GuardarUsuario()
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

#End Region


End Class