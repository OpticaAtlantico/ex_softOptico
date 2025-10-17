Imports CapaDatos
Imports CapaEntidad
Imports CapaNegocio
Imports FontAwesome.Sharp
Imports Microsoft.Data.SqlClient
Public Class frmEmpleado
    Inherits Form

    'Private fadeTimer As New Timer()
    'Private fadeStep As Double = 0.05

    Private rutaImagenSeleccionada As String = ""
    Private llenarCombo As New LlenarComboBox
    Public Property DatosEmpleados As VEmpleados = Nothing
    Public Property NombreBoton As String = String.Empty

    Public Event CerrarEmpleado As Action

#Region "CONSTRUCTOR"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        FormStylerUI.Apply(Me)
        PrepararUI()
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

        If DatosEmpleados IsNot Nothing Then
            CargarDatos(DatosEmpleados)
        End If

        btnAccion.Cursor = Cursors.Hand
        btnAccion.ColorTexto = Color.DarkSlateBlue
        Select Case NombreBoton
            Case "Actualizar"
                btnAccion.Texto = "Actualizar"
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPen
            Case "Eliminar"
                btnAccion.Texto = "Eliminar"
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserTimes
            Case Else
                btnAccion.Texto = "Guardar"
                btnAccion.Icono = FontAwesome.Sharp.IconChar.UserPlus
        End Select

        With Me.lblHeader
            .Titulo = btnAccion.Texto & " Empleado"
            .Subtitulo = "Aministrar los datos del empleado..."
            .Icono = btnAccion.Icono
            .ColorFondo = AppColors._cEncabezado
            .ColorTexto = AppColors._cBlancoOscuro
            .Dock = DockStyle.Fill
            .Anchor = AnchorStyles.Top And AnchorStyles.Left
        End With

        With Me.pnlFoto
            .BackColorContenedor = AppColors._cBack
            .BorderColor = AppColors._cLinea
            .ShadowColor = AppColors._cShadow
            .BorderRadius = 20
            .BorderSize = 1
            .CardBackColor = AppColors._cBlanco
            .Estilo = PanelUI.EstiloCard.None
        End With

        With Me.pnlDatos1
            .BackColorContenedor = AppColors._cBack
            .BorderColor = AppColors._cLinea
            .ShadowColor = AppColors._cShadow
            .BorderRadius = 20
            .BorderSize = 1
            .CardBackColor = AppColors._cBlanco
            .Estilo = PanelUI.EstiloCard.None
        End With

        With Me.pnlDatos2
            .BackColorContenedor = AppColors._cBack
            .BorderColor = AppColors._cLinea
            .ShadowColor = AppColors._cShadow
            .BorderRadius = 20
            .BorderSize = 1
            .CardBackColor = AppColors._cBlanco
            .Estilo = PanelUI.EstiloCard.None
        End With

        With Me.pnlDatos3
            .BackColorContenedor = AppColors._cBack
            .BorderColor = AppColors._cLinea
            .ShadowColor = AppColors._cShadow
            .BorderRadius = 20
            .BorderSize = 1
            .CardBackColor = AppColors._cBlanco
            .Estilo = PanelUI.EstiloCard.None
        End With

        With Me.pnlEncabezado
            .BackColor = AppColors._cFooter
            .Dock = DockStyle.Top
            .Height = 60
        End With

        With Me.pnlFooter
            .BackColor = AppColors._cFooter
            .Dock = DockStyle.Bottom
            .Height = 50
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
                                         MessageBoxUI.TipoMensaje.Errorr,
                                         MessageBoxUI.TipoBotones.Aceptar)
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
            Case "Actualizar"
                ' Aquí puedes implementar la lógica para actualizar el empleado
                If DatosEmpleados IsNot Nothing Then
                    ProcesarEmpleado(esNuevo:=False)
                Else
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                         MensajesUI.SinResultados,
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)
                End If

            Case "Eliminar"

                Try
                    Dim id As Integer = Convert.ToInt32(DatosEmpleados._empleadoID)
                    Dim rutaFoto As String = DatosEmpleados._foto ' asumiendo que guardas la ruta en un campo oculto o label

                    Dim service As New ServiceEmpleado()
                    Dim ok As Boolean = service.Eliminar(id, rutaFoto)

                    If ok Then
                        Dim toast As New ToastUI("Empleado eliminado correctamente.", TipoToastUI.Success)

                        RaiseEvent CerrarEmpleado()
                        Me.Close()
                        toast.Mostrar()
                    Else
                        MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                            (MensajesUI.ErrorInesperado),
                                            MessageBoxUI.TipoMensaje.Errorr,
                                            MessageBoxUI.TipoBotones.Aceptar)
                    End If

                Catch ex As Exception
                    MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                    MessageBoxUI.TipoMensaje.Errorr,
                                    MessageBoxUI.TipoBotones.Aceptar)
                End Try

            Case "Guardar"

                ' Aquí puedes implementar la lógica para guardar un nuevo empleado
                If DatosEmpleados Is Nothing Then
                    ProcesarEmpleado(esNuevo:=True)
                Else
                    ' Si ya hay datos de empleados, muestra un mensaje de advertencia
                    MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                         MensajesUI.RegistroDuplicado,
                                         MessageBoxUI.TipoMensaje.Advertencia,
                                         MessageBoxUI.TipoBotones.Aceptar)

                End If

            Case Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                     MensajesUI.OperacionFallida,
                                    MessageBoxUI.TipoMensaje.Informacion,
                                    MessageBoxUI.TipoBotones.Aceptar)

        End Select
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
                .txtCedula.TextString = empleado._cedula
                .txtNombre.TextString = empleado._nombre
                .txtApellido.TextString = empleado._apellido
                .txtEdad.TextString = empleado._edad
                .cmbNacionalidad.Texto = empleado._nacionalidad ' Asumiendo que el índice comienza en 0
                .cmbEstadoCivil.Texto = empleado._estadoCivil
                .cmbSexo.Texto = empleado._sexo
                .txtFechaNac.FechaSeleccionada = empleado._fechaNacimiento
                .cmbCargo.Texto = empleado._cargo
                .txtCorreo.TextString = empleado._correo
                .txtTelefono.TextString = empleado._telefono
                .cmbZona.Texto = empleado._zona
                .txtDireccion.TextString = empleado._direccion
                .chkAsesor.Checked = If(empleado._asesor = "True", True, False)
                .chkOptometrista.Checked = If(empleado._optometrista = "True", True, False)
                .chkGerente.Checked = If(empleado._gerente = "True", True, False)
                .chkMarketing.Checked = If(empleado._marketing = "True", True, False)
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
                                             MessageBoxUI.TipoMensaje.Errorr,
                                             MessageBoxUI.TipoBotones.Aceptar)

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
            Dim fechaNacimiento = txtFechaNac.FechaSeleccionada
            Dim sexo = Convert.ToInt32(cmbSexo.IndiceSeleccionado)
            Dim cargo = Convert.ToInt32(cmbCargo.IndiceSeleccionado) + 1 ' Asumiendo que el índice comienza en 0
            Dim zona = Convert.ToInt32(cmbZona.IndiceSeleccionado)


            If {cedula, nombre, apellido, edad, nacionalidad, estadoCivil, sexo, telefono, correo, direccion, cargo}.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar(MensajesUI.TituloInfo,
                                    MensajesUI.DatosIncompletos,
                                    MessageBoxUI.TipoMensaje.Advertencia,
                                    MessageBoxUI.TipoBotones.Aceptar)

                resultado.EsValido = False
                Return resultado
            End If

            ' Ruta de imagen
            Dim rutaRelativa As String = GuardarImagenEmpleado(rutaImagenSeleccionada, $"e_{cedula}")

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
                                                        .Asesor = chkAsesor.Checked.ToString(),
                                                        .Optometrista = chkOptometrista.Checked.ToString(),
                                                        .Gerente = chkGerente.Checked.ToString(),
                                                        .Marketing = chkMarketing.Checked.ToString(),
                                                        .Estado = 1,
                                                        .Foto = If(String.IsNullOrWhiteSpace(rutaRelativa), "", rutaRelativa)
                                                    }

            resultado.EsValido = True
        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 String.Format(MensajesUI.ErrorInesperado, ex.Message),
                                    MessageBoxUI.TipoMensaje.Errorr,
                                    MessageBoxUI.TipoBotones.Aceptar)

            resultado.EsValido = False
        End Try

        Return resultado
    End Function

    Private Sub ProcesarEmpleado(esNuevo As Boolean)
        Dim datos = ObtenerDatosEmpleado(incluirID:=Not esNuevo)

        If Not datos.EsValido Then Exit Sub

        Dim service As New ServiceEmpleado()

        Try
            Dim exito As Boolean
            If esNuevo Then
                exito = service.Guardar(datos.Empleado)
            Else
                exito = service.Actualizar(datos.Empleado)
            End If

            If exito Then
                Dim mensaje As New ToastUI(If(esNuevo, MensajesUI.RegistroExitoso,
                                                   MensajesUI.ActualizacionExitosa),
                                                   TipoToastUI.Success)
                RaiseEvent CerrarEmpleado()
                Me.Close()
                mensaje.Mostrar()
            Else
                MessageBoxUI.Mostrar(MensajesUI.TituloError,
                                 MensajesUI.OperacionFallida,
                                 MessageBoxUI.TipoMensaje.Errorr,
                                 MessageBoxUI.TipoBotones.Aceptar)
            End If

        Catch ex As Exception
            MessageBoxUI.Mostrar(MensajesUI.TituloError,
                             ex.Message,
                             MessageBoxUI.TipoMensaje.Errorr,
                             MessageBoxUI.TipoBotones.Aceptar)

        End Try
    End Sub

    Private Sub frmEmpleado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'RaiseEvent CerrarEmpleado(Me, EventArgs.Empty)
    End Sub

#End Region

End Class