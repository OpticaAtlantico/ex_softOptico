Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class InputBoxUI
    Inherits Form

#Region "Propiedades públicas"
    Public Property Placeholder As String
    Public Property Titulo As String
    Public Property TipoDato As TipoValidacion = TipoValidacion.Texto
    Public Property Icono As IconChar = IconChar.Pen
    Public Property EsObligatorio As Boolean = True

    Public Property ValorIngresado As String = ""
    Public Property Resultado As Boolean = False
#End Region

#Region "Controles internos"
    Private lblTitulo As New Label()
    Private lblError As New Label()
    Private btnAceptar As New Button()
    Private btnCancelar As New Button()
    Private iconoDecorativo As New IconPictureBox()
    Private fondoPanel As New Panel()
    Private txtInputUI As Control
#End Region

#Region "Enumeraciones"
    Public Enum TipoValidacion
        Texto
        Numero
        Cedula
        Correo
    End Enum
#End Region

#Region "Constructor"
    Public Sub New()
        ' --- Configuración de formulario ---
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.AliceBlue
        Me.Opacity = 0.97R
        Me.Size = New Size(445, 225)
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Region = New Region(GetRoundedRectPath(Me.ClientRectangle, 18))

        CrearControlesBase()
    End Sub
#End Region

#Region "Inicializar UI Base"
    Private Sub CrearControlesBase()
        ' === Panel de fondo ===
        fondoPanel.Size = New Size(440, 220)
        fondoPanel.Location = New Point((Me.Width - fondoPanel.Width) \ 2, (Me.Height - fondoPanel.Height) \ 2)
        fondoPanel.BackColor = Color.White
        fondoPanel.Region = New Region(GetRoundedRectPath(fondoPanel.ClientRectangle, 18))
        fondoPanel.Padding = New Padding(15)
        Me.Controls.Add(fondoPanel)

        ' === Título ===
        lblTitulo.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
        lblTitulo.Location = New Point(20, 20)
        lblTitulo.AutoSize = True
        fondoPanel.Controls.Add(lblTitulo)

        ' === Icono decorativo ===
        iconoDecorativo.IconColor = Color.DodgerBlue
        iconoDecorativo.IconSize = 40
        iconoDecorativo.Location = New Point(fondoPanel.Width - 60, 15)
        iconoDecorativo.Size = New Size(40, 40)
        fondoPanel.Controls.Add(iconoDecorativo)

        ' === Label error ===
        lblError.ForeColor = Color.Red
        lblError.Location = New Point(35, 115)
        lblError.AutoSize = True
        lblError.Font = New Font("Segoe UI", 9, FontStyle.Italic)
        fondoPanel.Controls.Add(lblError)

        ' === Botón Aceptar ===
        btnAceptar.Text = "Aceptar"
        btnAceptar.BackColor = Color.DodgerBlue
        btnAceptar.ForeColor = Color.White
        btnAceptar.FlatStyle = FlatStyle.Flat
        btnAceptar.Location = New Point(40, 155)
        btnAceptar.Size = New Size(150, 40)
        btnAceptar.Font = New Font("Century Gothic", 11, FontStyle.Regular)
        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
        fondoPanel.Controls.Add(btnAceptar)

        ' === Botón Cancelar ===
        btnCancelar.Text = "Cancelar"
        btnCancelar.BackColor = Color.OrangeRed
        btnCancelar.ForeColor = Color.WhiteSmoke
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Location = New Point(240, 155)
        btnCancelar.Size = New Size(150, 40)
        btnCancelar.Font = New Font("Century Gothic", 11, FontStyle.Regular)
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
        fondoPanel.Controls.Add(btnCancelar)
    End Sub
#End Region

#Region "Creación dinámica del control según tipo"
    Private Sub CrearControlInput()
        ' Si ya existe un control previo, se elimina
        If txtInputUI IsNot Nothing Then
            fondoPanel.Controls.Remove(txtInputUI)
            txtInputUI.Dispose()
        End If

        ' --- Crear según el tipo seleccionado ---
        Select Case TipoDato
            Case TipoValidacion.Texto
                txtInputUI = New TextOnlyTextBoxLabelUI()
            Case TipoValidacion.Numero, TipoValidacion.Cedula
                txtInputUI = New NumericTextBoxLabelUI()
            Case TipoValidacion.Correo
                txtInputUI = New EmailTextBoxLabelUI()
        End Select

        ' --- Propiedades comunes ---
        txtInputUI.Name = "txtInputUI"
        txtInputUI.Size = New Size(380, 80)
        txtInputUI.Location = New Point(30, 70)

        ' --- Configurar placeholder ---
        If TypeOf txtInputUI Is TextOnlyTextBoxLabelUI Then
            DirectCast(txtInputUI, TextOnlyTextBoxLabelUI).Placeholder = Placeholder
            AddHandler DirectCast(txtInputUI, TextOnlyTextBoxLabelUI).TextChanged,
                AddressOf ValidarEntradaEnTiempoReal
        ElseIf TypeOf txtInputUI Is NumericTextBoxLabelUI Then
            DirectCast(txtInputUI, NumericTextBoxLabelUI).Placeholder = Placeholder
            AddHandler DirectCast(txtInputUI, NumericTextBoxLabelUI).TextChanged,
                AddressOf ValidarEntradaEnTiempoReal
        ElseIf TypeOf txtInputUI Is EmailTextBoxLabelUI Then
            DirectCast(txtInputUI, EmailTextBoxLabelUI).Placeholder = Placeholder
            AddHandler DirectCast(txtInputUI, EmailTextBoxLabelUI).TextChanged,
                AddressOf ValidarEntradaEnTiempoReal
        End If

        fondoPanel.Controls.Add(txtInputUI)
        fondoPanel.Controls.SetChildIndex(txtInputUI, 0) ' Lo envía al frente
    End Sub
#End Region

#Region "Validación en tiempo real"
    Private Sub ValidarEntradaEnTiempoReal(sender As Object, e As EventArgs)
        ValidarEntrada(mostrarMensaje:=True)
    End Sub
#End Region

#Region "Botones"
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        If ValidarEntrada(mostrarMensaje:=True) Then
            Resultado = True

            If TypeOf txtInputUI Is TextOnlyTextBoxLabelUI Then
                ValorIngresado = DirectCast(txtInputUI, TextOnlyTextBoxLabelUI).TextString.Trim()
            ElseIf TypeOf txtInputUI Is NumericTextBoxLabelUI Then
                ValorIngresado = DirectCast(txtInputUI, NumericTextBoxLabelUI).TextString.Trim()
            ElseIf TypeOf txtInputUI Is EmailTextBoxLabelUI Then
                ValorIngresado = DirectCast(txtInputUI, EmailTextBoxLabelUI).TextString.Trim()
            End If

            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Resultado = False
        Me.Close()
    End Sub
#End Region

#Region "Validación lógica central"
    Private Function ValidarEntrada(Optional mostrarMensaje As Boolean = False) As Boolean
        Dim texto As String = ""

        ' Obtener el texto según el tipo de control
        If TypeOf txtInputUI Is TextOnlyTextBoxLabelUI Then
            texto = DirectCast(txtInputUI, TextOnlyTextBoxLabelUI).TextString.Trim()
        ElseIf TypeOf txtInputUI Is NumericTextBoxLabelUI Then
            texto = DirectCast(txtInputUI, NumericTextBoxLabelUI).TextString.Trim()
        ElseIf TypeOf txtInputUI Is EmailTextBoxLabelUI Then
            texto = DirectCast(txtInputUI, EmailTextBoxLabelUI).TextString.Trim()
        End If

        ' --- Validación general ---
        If EsObligatorio AndAlso String.IsNullOrEmpty(texto) Then
            If mostrarMensaje Then lblError.Text = "Este campo es obligatorio."
            CambiarColorEstado(False)
            Return False
        End If

        ' --- Validación específica ---
        Select Case TipoDato
            Case TipoValidacion.Numero
                If Not Integer.TryParse(texto, Nothing) Then
                    If mostrarMensaje Then lblError.Text = "Solo se permiten números."
                    CambiarColorEstado(False)
                    Return False
                End If

            Case TipoValidacion.Cedula
                If texto.Length < 8 OrElse texto.Length > 10 Then
                    If mostrarMensaje Then lblError.Text = "Formato de cédula no válido."
                    CambiarColorEstado(False)
                    Return False
                End If

            Case TipoValidacion.Correo
                If Not texto.Contains("@") OrElse Not texto.Contains(".") Then
                    If mostrarMensaje Then lblError.Text = "Correo no válido."
                    CambiarColorEstado(False)
                    Return False
                End If
        End Select

        lblError.Text = ""
        CambiarColorEstado(True)
        Return True
    End Function
#End Region

#Region "Efecto visual de estado"
    Private Sub CambiarColorEstado(valido As Boolean)
        ' Efecto visual en el borde del control (tipo Bootstrap)
        If valido Then
            fondoPanel.BackColor = Color.White
        Else
            fondoPanel.BackColor = Color.FromArgb(255, 250, 250)
        End If
    End Sub
#End Region

#Region "Funciones auxiliares"
    Private Function GetRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()
        Return path
    End Function
#End Region

#Region "Método Mostrar"
    Public Shared Function Mostrar(titulo As String,
                                   placeholder As String,
                                   tipoDato As TipoValidacion,
                                   Optional icono As IconChar = IconChar.Pen,
                                   Optional obligatorio As Boolean = True) As (Aceptado As Boolean, Valor As String)

        Using frm As New InputBoxUI()
            frm.Titulo = titulo
            frm.Placeholder = placeholder
            frm.TipoDato = tipoDato
            frm.Icono = icono
            frm.EsObligatorio = obligatorio

            frm.lblTitulo.Text = titulo
            frm.iconoDecorativo.IconChar = icono
            frm.CrearControlInput()

            frm.ShowDialog()
            Return (frm.Resultado, frm.ValorIngresado)
        End Using
    End Function
#End Region

End Class



'Imports System.Drawing.Drawing2D
'Imports FontAwesome.Sharp

'Public Class InputBoxUI
'    Inherits Form

'#Region "Propiedades públicas"
'    Public Property Placeholder As String
'    Public Property Titulo As String
'    Public Property TipoDato As TipoValidacion = TipoValidacion.Texto
'    Public Property Icono As IconChar = IconChar.Pen
'    Public Property EsObligatorio As Boolean = True

'    Public Property ValorIngresado As String = ""
'    Public Property Resultado As Boolean = False
'#End Region

'#Region "Controles internos"
'    Private lblTitulo As New Label()
'    Private lblError As New Label()
'    Private btnAceptar As New Button()
'    Private btnCancelar As New Button()
'    Private iconoDecorativo As New IconPictureBox()
'    Private fondoPanel As New Panel()
'    Private txtInputUI As Object ' 🚀 Tu control ajustado
'    Private _txtInputUI As New TipoValidacion() ' 🚀 Tu control ajustado
'    Public Property InputControl As TipoValidacion
'        Get
'            Return _txtInputUI
'        End Get
'        Set(value As TipoValidacion)
'            Select Case value
'                Case TipoValidacion.Texto
'                    txtInputUI = New TextOnlyTextBoxLabelUI()
'                Case TipoValidacion.Numero
'                    txtInputUI = New NumericTextBoxLabelUI()
'                Case TipoValidacion.Cedula
'                    txtInputUI = New NumericTextBoxLabelUI()
'                Case TipoValidacion.Correo
'                    txtInputUI = New EmailTextBoxLabelUI()
'            End Select
'        End Set
'    End Property
'    'Private txtInputUI As New TextOnlyTextBoxLabelUI() ' 🚀 Tu control ajustado
'#End Region

'    Public Enum TipoValidacion
'        Texto
'        Numero
'        Cedula
'        Correo
'    End Enum

'#Region "Constructor"
'    Public Sub New()
'        Me.FormBorderStyle = FormBorderStyle.None
'        Me.StartPosition = FormStartPosition.CenterScreen
'        Me.BackColor = Color.AliceBlue
'        Me.Opacity = 0.95R
'        Me.Size = New Size(445, 225)
'        Me.ShowInTaskbar = False
'        Me.TopMost = True
'        Me.Region = New Region(GetRoundedRectPath(Me.ClientRectangle, 18))

'        CrearControles()
'    End Sub
'#End Region

'#Region "Inicializar UI"
'    Private Sub CrearControles()
'        ' === Panel de fondo ===
'        fondoPanel.Size = New Size(440, 220)
'        fondoPanel.Location = New Point((Me.Width - fondoPanel.Width) \ 2, (Me.Height - fondoPanel.Height) \ 2)
'        fondoPanel.BackColor = Color.White
'        fondoPanel.Region = New Region(GetRoundedRectPath(fondoPanel.ClientRectangle, 18))
'        Me.Controls.Add(fondoPanel)

'        ' === Título ===
'        lblTitulo.Text = "Título"
'        lblTitulo.Font = New Font("Century Gothic", 12, FontStyle.Regular)
'        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
'        lblTitulo.Location = New Point(20, 20)
'        lblTitulo.AutoSize = True
'        fondoPanel.Controls.Add(lblTitulo)

'        ' === Icono ===
'        iconoDecorativo.IconChar = Icono
'        iconoDecorativo.IconColor = Color.DodgerBlue
'        iconoDecorativo.IconSize = 40
'        iconoDecorativo.Location = New Point(fondoPanel.Width - 60, 15)
'        iconoDecorativo.Size = New Size(40, 40)
'        fondoPanel.Controls.Add(iconoDecorativo)

'        ' === TextOnlyTextBoxLabelUI ===
'        txtInputUI.Name = "txtInputUI"
'        txtInputUI.Size = New Size(380, 80)
'        txtInputUI.Location = New Point(30, 70)
'        txtInputUI.Placeholder = Placeholder
'        txtInputUI.TextString = ""
'        fondoPanel.Controls.Add(txtInputUI)

'        ' === Label error ===
'        lblError.Text = ""
'        lblError.ForeColor = Color.Red
'        lblError.Location = New Point(35, 115)
'        lblError.AutoSize = True
'        fondoPanel.Controls.Add(lblError)

'        ' === Botón Aceptar ===
'        btnAceptar.Text = "Aceptar"
'        btnAceptar.BackColor = Color.DodgerBlue
'        btnAceptar.ForeColor = Color.White
'        btnAceptar.FlatStyle = FlatStyle.Flat
'        btnAceptar.Location = New Point(40, 155)
'        btnAceptar.Size = New Size(150, 40)
'        btnAceptar.Font = New Font("Century Gothic", 11, FontStyle.Regular)
'        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
'        fondoPanel.Controls.Add(btnAceptar)

'        ' === Botón Cancelar ===
'        btnCancelar.Text = "Cancelar"
'        btnCancelar.BackColor = Color.OrangeRed
'        btnCancelar.ForeColor = Color.WhiteSmoke
'        btnCancelar.FlatStyle = FlatStyle.Flat
'        btnCancelar.Location = New Point(240, 155)
'        btnCancelar.Size = New Size(150, 40)
'        btnCancelar.Font = New Font("Century Gothic", 11, FontStyle.Regular)
'        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
'        fondoPanel.Controls.Add(btnCancelar)
'    End Sub
'#End Region

'#Region "Eventos botones"
'    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
'        If ValidarEntrada() Then
'            Resultado = True
'            ValorIngresado = txtInputUI.TextString.Trim()
'            Me.Close()
'        End If
'    End Sub

'    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
'        Resultado = False
'        Me.Close()
'    End Sub
'#End Region

'#Region "Validación"
'    Private Function ValidarEntrada() As Boolean
'        Dim texto = txtInputUI.TextString.Trim()

'        If EsObligatorio AndAlso String.IsNullOrEmpty(texto) Then
'            lblError.Text = "Este campo es obligatorio."
'            Return False
'        End If

'        Select Case TipoDato
'            Case TipoValidacion.Numero
'                If Not Integer.TryParse(texto, Nothing) Then
'                    txtInputUI.lblError.Text = "Solo se permiten números."
'                    Return False
'                End If
'            Case TipoValidacion.Cedula
'                If texto.Length <> 8 AndAlso texto.Length <> 10 Then
'                    lblError.Text = "Formato de cédula no válido."
'                    Return False
'                End If
'            Case TipoValidacion.Correo
'                If Not texto.Contains("@") OrElse Not texto.Contains(".") Then
'                    lblError.Text = "Correo no válido."
'                    Return False
'                End If
'        End Select

'        lblError.Text = ""
'        Return True
'    End Function
'#End Region

'#Region "Funciones auxiliares"
'    Private Function GetRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.StartFigure()
'        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function
'#End Region

'#Region "Método Mostrar"
'    Public Shared Function Mostrar(titulo As String,
'                                   placeholder As String,
'                                   tipoDato As TipoValidacion,
'                                   Optional icono As IconChar = IconChar.Pen,
'                                   Optional obligatorio As Boolean = True) As (Aceptado As Boolean, Valor As String)

'        Using frm As New InputBoxUI()
'            frm.Titulo = titulo
'            frm.Placeholder = placeholder
'            frm.TipoDato = tipoDato
'            frm.Icono = icono
'            frm.EsObligatorio = obligatorio

'            frm.lblTitulo.Text = titulo
'            frm.txtInputUI.TextoLabel = "#Cedula"
'            frm.txtInputUI.Placeholder = placeholder
'            frm.txtInputUI.iconoDerecha.IconChar = If(tipoDato = TipoValidacion.Numero, IconChar.Hashtag, IconChar.Pen)
'            frm.iconoDecorativo.IconChar = icono

'            frm.ShowDialog()

'            Return (frm.Resultado, frm.ValorIngresado)
'        End Using
'    End Function

'#End Region
'End Class

''Dim resultado = InputBoxUI.Mostrar(
''    titulo:="Ingrese su nombre",
''    placeholder:="Ejemplo: Wilmer",
''    tipoDato:=InputBoxUI.TipoValidacion.Texto,
''    icono:=FontAwesome.Sharp.IconChar.User,
''    obligatorio:=True
'')

''If resultado.Aceptado Then
''MessageBox.Show("Dato recibido: " & resultado.Valor)
''Else
''MessageBox.Show("El usuario canceló.")
''End If


