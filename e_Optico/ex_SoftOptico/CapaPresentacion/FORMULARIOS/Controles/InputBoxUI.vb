Imports System.Drawing.Drawing2D
Imports FontAwesome.Sharp

Public Class InputBoxUI
    Inherits Form
    Public Property Placeholder As String
    Public Property Titulo As String
    Public Property TipoDato As TipoValidacion = TipoValidacion.Texto
    Public Property Icono As IconChar = IconChar.Pen
    Public Property EsObligatorio As Boolean = True

    Public Property ValorIngresado As String = ""
    Public Property Resultado As Boolean = False

    Private lblTitulo As New Label()
    Private txtInput As New TextBox()
    Private lblError As New Label()
    Private btnAceptar As New Button()
    Private btnCancelar As New Button()
    Private iconoDecorativo As New IconPictureBox()
    Private fondoPanel As New Panel()
    Private pnlTextBox As New Panel()

    Public Enum TipoValidacion
        Texto
        Numero
        Cedula
        Correo
    End Enum

    Public Sub New()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.BackColor = Color.AliceBlue
        Me.Opacity = 0.9R ' Nivel de transparencia
        Me.Size = New Size(445, 225)
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.Region = New Region(GetRoundedRectPath(Me.ClientRectangle, 18))

        CrearControles()
    End Sub

    Private Sub CrearControles()
        fondoPanel.Size = New Size(440, 220)
        fondoPanel.Location = New Point((Me.Width - fondoPanel.Width) \ 2, (Me.Height - fondoPanel.Height) \ 2)
        fondoPanel.BackColor = Color.White
        fondoPanel.Region = New Region(GetRoundedRectPath(fondoPanel.ClientRectangle, 18))
        fondoPanel.Anchor = AnchorStyles.None
        fondoPanel.BorderStyle = BorderStyle.None
        Me.Controls.Add(fondoPanel)

        lblTitulo.Text = "Título"
        lblTitulo.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        lblTitulo.ForeColor = Color.FromArgb(40, 40, 40)
        lblTitulo.Location = New Point(((Me.Width - fondoPanel.Width) \ 2) + 17, (Me.Top + 65))
        lblTitulo.AutoSize = True
        fondoPanel.Controls.Add(lblTitulo)

        iconoDecorativo.IconChar = icono
        iconoDecorativo.IconColor = Color.DodgerBlue
        iconoDecorativo.IconSize = 50
        iconoDecorativo.Location = New Point(15, 20)
        iconoDecorativo.Size = New Size(40, 40)
        fondoPanel.Controls.Add(iconoDecorativo)

        ' === Panel redondeado para textbox ===
        pnlTextBox.Size = New Size(400, 38)
        pnlTextBox.Location = New Point(20, 95)
        pnlTextBox.BackColor = Color.LightSkyBlue
        pnlTextBox.Region = New Region(GetRoundedRectPath(New Rectangle(0, 0, pnlTextBox.Width, pnlTextBox.Height), 15))
        pnlTextBox.BorderStyle = BorderStyle.None
        pnlTextBox.Padding = New Padding(0)
        pnlTextBox.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        fondoPanel.Controls.Add(pnlTextBox)

        ' === TextBox dentro del panel ===
        txtInput.Font = New Font("Century Gothic", 11)
        txtInput.ForeColor = Color.White
        txtInput.BackColor = Color.LightSkyBlue
        txtInput.BorderStyle = BorderStyle.None
        txtInput.Location = New Point(10, 9) ' Centramos manualmente el texto verticalmente
        txtInput.Size = New Size(380, 22)
        txtInput.Multiline = False
        txtInput.TextAlign = HorizontalAlignment.Left
        pnlTextBox.Controls.Add(txtInput)

        lblError.Text = ""
        lblError.ForeColor = Color.Red
        lblError.Location = New Point(20, 145)
        lblError.AutoSize = True
        fondoPanel.Controls.Add(lblError)

        btnAceptar.Text = "Aceptar"
        btnAceptar.BackColor = Color.DodgerBlue
        btnAceptar.ForeColor = Color.White
        btnAceptar.FlatStyle = FlatStyle.Flat
        btnAceptar.Location = New Point(40, 155)
        btnAceptar.Size = New Size(150, 40)
        btnAceptar.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        AddHandler btnAceptar.Click, AddressOf BtnAceptar_Click
        fondoPanel.Controls.Add(btnAceptar)

        btnCancelar.Text = "Cancelar"
        btnCancelar.BackColor = Color.OrangeRed
        btnCancelar.ForeColor = Color.WhiteSmoke
        btnCancelar.FlatStyle = FlatStyle.Flat
        btnCancelar.Location = New Point(240, 155)
        btnCancelar.Size = New Size(150, 40)
        btnCancelar.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        AddHandler btnCancelar.Click, AddressOf BtnCancelar_Click
        fondoPanel.Controls.Add(btnCancelar)
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs)
        If ValidarEntrada() Then
            Resultado = True
            ValorIngresado = txtInput.Text.Trim()
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs)
        Resultado = False
        Me.Close()
    End Sub

    Private Function ValidarEntrada() As Boolean
        Dim texto = txtInput.Text.Trim()

        If EsObligatorio AndAlso String.IsNullOrEmpty(texto) Then
            lblError.Text = "Este campo es obligatorio."
            Return False
        End If

        Select Case TipoDato
            Case TipoValidacion.Numero
                If Not Integer.TryParse(texto, Nothing) Then
                    lblError.Text = "Solo se permiten números."
                    Return False
                End If
            Case TipoValidacion.Cedula
                If texto.Length <> 8 AndAlso texto.Length <> 10 Then
                    lblError.Text = "Formato de cédula no válido."
                    Return False
                End If
            Case TipoValidacion.Correo
                If Not texto.Contains("@") OrElse Not texto.Contains(".") Then
                    lblError.Text = "Correo no válido."
                    Return False
                End If
        End Select

        lblError.Text = ""
        Return True
    End Function

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

    Public Shared Function Mostrar(titulo As String,
                                   placeholder As String,
                                   tipoDato As TipoValidacion,
                                   Optional icono As IconChar = IconChar.Pen,
                                   Optional obligatorio As Boolean = True) As (Aceptado As Boolean, Valor As String)


        Using frm As New InputBoxUI()
            frm.Titulo = titulo
            frm.Placeholder = placeholder
            frm.TipoDato = tipoDato
            frm.icono = icono
            frm.EsObligatorio = obligatorio

            frm.lblTitulo.Text = titulo
            frm.txtInput.PlaceholderText = placeholder
            frm.iconoDecorativo.IconChar = icono

            frm.ShowDialog()

            Return (frm.Resultado, frm.ValorIngresado)

        End Using
    End Function

End Class


' Example usage:
'Dim resultado = InputBoxUI.Mostrar(
'    titulo:="Ingrese su correo",
'    placeholder:="ejemplo@correo.com",
'    tipoDato:=InputBoxUI.TipoValidacion.Correo,
'    icono:=FontAwesome.Sharp.IconChar.At,
'    obligatorio:=True
')

'If resultado.Aceptado Then
'MessageBox.Show("Dato recibido: " & resultado.Valor)
'Else
'MessageBox.Show("El usuario canceló.")
'End If
