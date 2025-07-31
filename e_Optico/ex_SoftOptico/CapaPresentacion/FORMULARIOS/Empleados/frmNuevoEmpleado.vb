Imports DocumentFormat.OpenXml.Office2010.Excel
Imports CapaDatos
Imports CapaEntidad
Public Class frmNuevoEmpleado
    Private fadeTimer As New Timer()
    Private fadeStep As Double = 0.1

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
    Private Sub frmNuevoEmpleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form components or load data if necessary
        Me.SuspendLayout()
        PrepararUI()
        Me.ResumeLayout()

        Me.Visible = True
        fadeTimer.Start()
    End Sub

    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 1 Then
            Me.Opacity += fadeStep
        Else
            fadeTimer.Stop()
        End If
    End Sub

    ' Aquí configuras tus controles, layout, etc.
    Private Sub PrepararUI()

        Me.cmbNacionalidad.OrbitalCombo.Items.AddRange(New Object() {
            New LlenarComboBox.ComboItem("Venezolano", 1),
            New LlenarComboBox.ComboItem("Extranjero", 2)
            })

        Me.cmbSexo.OrbitalCombo.Items.AddRange(New Object() {
            New LlenarComboBox.ComboItem("Masculino", 1),
            New LlenarComboBox.ComboItem("Femenino", 2)
            })

        Me.cmbEstadoCivil.OrbitalCombo.Items.AddRange(New Object() {
            New LlenarComboBox.ComboItem("Soltero", 1),
            New LlenarComboBox.ComboItem("Casado", 2),
            New LlenarComboBox.ComboItem("Divorciado", 3),
            New LlenarComboBox.ComboItem("Viudo", 4)
            })

        Me.cmbZona.OrbitalCombo.Items.AddRange(New Object() {
            New LlenarComboBox.ComboItem("Pto Ordaz", 1),
            New LlenarComboBox.ComboItem("Sanfelix", 2)
            })

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

    Private Sub GuardarUsuario()
        Dim cedula As String = txtCedula.TextValue.Trim()
        Dim nombre As String = txtNombre.TextValue.Trim()
        Dim apellido As String = txtApellido.TextValue.Trim()
        Dim edad As String = txtEdad.TextValue.Trim()
        Dim nacionalidad As Integer = Convert.ToInt32(cmbNacionalidad.OrbitalCombo.ValorClave)
        Dim estadoCivil As Integer = Convert.ToInt32(cmbEstadoCivil.OrbitalCombo.ValorClave)
        Dim telefono As String = txtTelefono.TextValue.Trim()
        Dim correo As String = txtCorreo.TextValue.Trim()
        Dim direccion As String = txtDireccion.TextValue.Trim()
        Dim fechaNacimiento As DateTime = txtFechaNac.TextValue
        Dim sexo As Integer = Convert.ToInt32(cmbSexo.OrbitalCombo.ValorClave)
        Dim cargo As Integer = Convert.ToInt32(cmbCargo.OrbitalCombo.ValorClave) + 1
        Dim asesor As String = swAsesor.Checked.ToString()
        Dim optometrista As String = swOptometrista.Checked.ToString()
        Dim gerente As String = swGerente.Checked.ToString()
        Dim marketing As String = swMarketing.Checked.ToString()
        Dim estado As Integer = 1
        Dim zona As String = Convert.ToString(cmbZona.OrbitalCombo.ValorClave)

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
           fechaNacimiento = DateTime.MinValue OrElse
           String.IsNullOrEmpty(cargo) Then

            ' Mostrar mensaje de error si algún campo obligatorio está vacío
            Dim toasts As New ToastUI()
            'toast.MostrarToast("Guardado exitosamente", TipoToastUI.Success)
            toasts.MostrarToast("Por favor, complete todos los campos obligatorios.", TipoToastUI.Warning)

            Return
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
            .Zona = zona
        }

        Dim repositorio As New Repositorio_Empleados()
        Dim toast As New ToastUI()
        Try
            Dim resultado As Boolean = repositorio.InsertarEmpleado(empleado)

            If resultado Then
                toast.MostrarToast("Empleado guardado correctamente.", TipoToastUI.Success)
                ' Aquí puedes cerrar el formulario o limpiar los campos
            Else
                ' Mostrar mensaje de error si no se pudo guardar
                toast.MostrarToast("Error al guardar el empleado. Inténtelo de nuevo.", TipoToastUI.Errores)
            End If
        Catch ex As Exception
            ' Manejar excepciones y mostrar mensaje de error
            toast.MostrarToast("Error al guardar el empleado: " & ex.Message, TipoToastUI.Errores)
        End Try

    End Sub

    Private Sub LimpiarFormulario()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is TextBoxLabelUI Then
                'CType(ctrl, TextBoxLabelUI).Textovalue = ""
            End If
        Next
        ' Limpiar checkboxes, combos, etc.
    End Sub


End Class