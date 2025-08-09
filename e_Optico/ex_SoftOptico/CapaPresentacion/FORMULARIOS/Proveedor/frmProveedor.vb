Imports CapaDatos
Imports CapaEntidad

Public Class frmProveedor

    Private fadeTimer As New Timer()
    Private fadeStep As Double = 0.1
    Private rutaImagenSeleccionada As String = ""
    Public Property DatosProveedor As TProveedor = Nothing
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

#Region "EVENTOS DE FORMULARIO"

    Private Sub frmProveedor_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Initialize form components or load data if necessary

        Me.Visible = True
        fadeTimer.Start()

        If DatosProveedor IsNot Nothing Then
            CargarDatos(DatosProveedor)
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

        With lblEncabezado
            .Titulo = "Proveedor"
            .Subtitulo = "Datos del proveedor"
            .ForeColor = Color.FromArgb(57, 103, 208)
            .Icono = FontAwesome.Sharp.IconChar.Users
            .BackColor = Color.White

        End With

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

    Private Sub bntAccion_Click(sender As Object, e As EventArgs) Handles btnAccion.Click
        Select Case btnAccion.Texto
            Case "Actualizar..."
                ' Aquí puedes implementar la lógica para actualizar el empleado
                If DatosProveedor IsNot Nothing Then
                    ProcesarProveedor(esNuevo:=False)
                Else
                    MessageBoxUI.Mostrar("Sin actualizar...",
                                         "No hay datos del proveedor que actualizar... ",
                                         TipoMensaje.Errors, Botones.Aceptar)
                End If
            Case "Eliminar..."
                ' Aquí puedes implementar la lógica para eliminar el empleado
                Dim ProveedorId As Integer = DatosProveedor.proveedorID
                Dim confirmacion = MessageBoxUI.Mostrar("Eliminar datos...",
                                                        "¿Está usted seguro de eliminar el empleado seleccionado?",
                                                        TipoMensaje.Advertencia,
                                                        Botones.AceptarCancelar
                                                        )
                If confirmacion = DialogResult.Yes Then
                    'EliminarProveedor(empleadoId)
                    Me.Close() ' Cierra el formulario después de eliminar
                    frm_Principal.btnSalirFrmHijo.Visible = False ' Deshabilita botones de la ventana principal  
                End If

            Case "Guardar..."
                ' Aquí puedes implementar la lógica para guardar un nuevo empleado
                If DatosProveedor Is Nothing Then
                    ProcesarProveedor(esNuevo:=True)
                Else
                    MessageBoxUI.Mostrar("Guardar datos...",
                                         "Ya hay datos de empleados almacenado...",
                                         TipoMensaje.Errors,
                                         Botones.Aceptar
                                       )
                End If
            Case Else
                MessageBoxUI.Mostrar("Sin datos...",
                                     "La acción que intenta ejecutar no es reconocida",
                                     TipoMensaje.Errors,
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

        txtNombreEmpresa.Focus()

        container.ResumeLayout()
        container.PerformLayout()
    End Sub

    ' Recibe un objeto TEmpleados y rellena los controles del formulario.
    Public Sub CargarDatos(ByVal proveedor As TProveedor)
        ' Primero, verificamos que el objeto no sea nulo para evitar errores.
        If proveedor IsNot Nothing Then
            ' Asignamos los datos del objeto a los controles
            With Me
                txtNombreEmpresa.TextoUsuario = proveedor.nombreEmpresa
                txtRazonSocial.TextoUsuario = proveedor.razonSocial
                txtCorreo.TextoUsuario = proveedor.correo
                txtRif.TextoUsuario = proveedor.rif
                txtTelefono.TextoUsuario = proveedor.telefono
                txtContacto.TextoUsuario = proveedor.contacto
                txtDireccion.TextoUsuario = proveedor.direccion
            End With
        End If
    End Sub

#End Region

#Region "SQL"

    Private Function ObtenerDatosProveedor(Optional ByVal incluirID As Boolean = False) As ResultadoProveedor
        Dim resultado As New ResultadoProveedor()
        Try
            Dim id As Integer = If(incluirID, DatosProveedor.ProveedorID, 0)
            Dim nombre = txtNombreEmpresa.TextValue.Trim()
            Dim razonSocial = txtRazonSocial.TextValue.Trim()
            Dim correo = txtCorreo.TextValue.Trim()
            Dim rif = txtRif.TextValue.Trim()
            Dim telefono = txtTelefono.TextValue.Trim()
            Dim contacto = txtContacto.TextValue.Trim()
            Dim direccion = txtDireccion.TextValue.Trim()

            If {id, nombre, razonSocial, correo, rif, telefono, contacto, direccion}.Any(Function(s) String.IsNullOrWhiteSpace(s)) Then
                MessageBoxUI.Mostrar("Cargando...",
                                     "Por favor, complete todos los campos obligatorios.",
                                      TipoMensaje.Errors, Botones.Aceptar)

                resultado.EsValido = False
                Return resultado
            End If

            resultado.Proveedor = New TProveedor With {
            .nombreEmpresa = nombre,
            .razonSocial = razonSocial,
            .correo = correo,
            .rif = rif,
            .telefono = telefono,
            .contacto = contacto,
            .direccion = direccion
        }

            resultado.EsValido = True
        Catch ex As Exception

            MessageBoxUI.Mostrar("Cargando...",
                                 "Error al obtener los datos" & ex.Message,
                                 TipoMensaje.Errors, Botones.Aceptar)

            resultado.EsValido = False
        End Try

        Return resultado
    End Function

    Private Sub ProcesarProveedor(esNuevo As Boolean)
        Dim datos = ObtenerDatosProveedor(incluirID:=Not esNuevo)

        If Not datos.EsValido Then Exit Sub

        Dim repositorio As New Repositorio_Proveedor()
        Dim exito As Boolean = False

        Try
            If esNuevo Then
                exito = repositorio.AgregarProveedor(datos.Proveedor)
            Else
                exito = repositorio.ActualizarProveedor(datos.Proveedor)
            End If

            If exito Then
                Dim mensaje As New ToastUI(If(esNuevo, "Empleado guardado correctamente.", "Empleado actualizado correctamente."), TipoToastUI.Success)
                mensaje.Mostrar()

                Me.Close()
                frm_Principal.btnSalirFrmHijo.Visible = False ' Deshabilita botones de la ventana principal

            Else
                MessageBoxUI.Mostrar("Procesando...",
                                    "Ocurrió un error al procesar la operación.",
                                    TipoMensaje.Errors, Botones.Aceptar)
            End If
        Catch ex As Exception
            MessageBoxUI.Mostrar("Error...",
                                 "Ha ocurrido un error al procesar los datos del empleado..." & ex.Message,
                                 TipoMensaje.Errors, Botones.Aceptar)
        End Try
    End Sub

#End Region

End Class