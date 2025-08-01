'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Drawing.Drawing2D
'Imports System.Windows.Forms
'Imports FontAwesome.Sharp

'Public Class InputBoxUI
'    Inherits Form

'    Private lblTitulo As New Label()
'    Private txtInput As New TextBox()
'    Private btnAceptar As New Button()
'    Private btnCancelar As New Button()
'    Private icono As New IconPictureBox()
'    Private panelFondo As New Panel()
'    Private lblError As New Label()
'    Private _borderRadius As Integer = 12
'    Private _shadowColor As Color = Color.FromArgb(60, 0, 0, 0)

'    Public Property ValorIngresado As String = ""

'    Public Sub New(Optional titulo As String = "Ingrese un valor",
'                   Optional placeholder As String = "",
'                   Optional iconoChar As IconChar = IconChar.Keyboard,
'                   Optional colorFondo As Color = Nothing,
'                   Optional bordeColor As Color = Nothing,
'                   Optional modoOscuro As Boolean = False)

'        Me.FormBorderStyle = FormBorderStyle.None
'        Me.StartPosition = FormStartPosition.CenterParent
'        Me.Size = New Size(360, 180)
'        Me.Opacity = 0
'        Me.DoubleBuffered = True
'        Me.ShowInTaskbar = False
'        Me.TopMost = True
'        Me.BackColor = Color.White
'        Me.KeyPreview = True

'        ' Panel principal
'        panelFondo.Dock = DockStyle.Fill
'        panelFondo.BackColor = If(colorFondo = Nothing, Color.White, colorFondo)
'        Me.Controls.Add(panelFondo)

'        ' Sombra
'        Dim sombra = New Panel() With {
'            .Dock = DockStyle.Fill,
'            .BackColor = _shadowColor,
'            .Margin = New Padding(10),
'            .Padding = New Padding(10)
'        }
'        sombra.BringToFront()
'        sombra.SendToBack()
'        Me.Controls.Add(sombra)

'        ' Ícono
'        icono.IconChar = iconoChar
'        icono.IconColor = Color.Teal
'        icono.Size = New Size(28, 28)
'        icono.Location = New Point(20, 22)
'        icono.BackColor = Color.Transparent
'        panelFondo.Controls.Add(icono)

'        ' Título
'        lblTitulo.Text = titulo
'        lblTitulo.Font = New Font("Segoe UI", 11, FontStyle.Bold)
'        lblTitulo.ForeColor = Color.DimGray
'        lblTitulo.Location = New Point(60, 24)
'        lblTitulo.Size = New Size(280, 20)
'        panelFondo.Controls.Add(lblTitulo)

'        ' TextBox
'        txtInput.Font = New Font("Segoe UI", 10)
'        txtInput.Size = New Size(280, 25)
'        txtInput.Location = New Point(30, 60)
'        txtInput.ForeColor = Color.Black
'        txtInput.BackColor = Color.White
'        txtInput.BorderStyle = BorderStyle.FixedSingle
'        txtInput.PlaceholderText = placeholder
'        panelFondo.Controls.Add(txtInput)

'        ' Error
'        lblError.Font = New Font("Segoe UI", 8)
'        lblError.ForeColor = Color.Firebrick
'        lblError.Location = New Point(30, 90)
'        lblError.Size = New Size(300, 18)
'        lblError.Visible = False
'        panelFondo.Controls.Add(lblError)

'        ' Botón Aceptar
'        btnAceptar.Text = "Aceptar"
'        btnAceptar.FlatStyle = FlatStyle.Flat
'        btnAceptar.Font = New Font("Segoe UI", 9)
'        btnAceptar.BackColor = Color.Teal
'        btnAceptar.ForeColor = Color.White
'        btnAceptar.Size = New Size(100, 30)
'        btnAceptar.Location = New Point(60, 120)
'        AddHandler btnAceptar.Click, AddressOf ValidarYEnviar
'        panelFondo.Controls.Add(btnAceptar)

'        ' Botón Cancelar
'        btnCancelar.Text = "Cancelar"
'        btnCancelar.FlatStyle = FlatStyle.Flat
'        btnCancelar.Font = New Font("Segoe UI", 9)
'        btnCancelar.BackColor = Color.Gray
'        btnCancelar.ForeColor = Color.White
'        btnCancelar.Size = New Size(100, 30)
'        btnCancelar.Location = New Point(180, 120)
'        AddHandler btnCancelar.Click, Sub()
'                                          Me.DialogResult = DialogResult.Cancel
'                                          Me.Close()
'                                      End Sub

'        panelFondo.Controls.Add(btnCancelar)

'        ' Fade-in
'        AddHandler Me.Shown, Sub()
'                                 Dim tmr As New Timer With {.Interval = 10}
'                                 AddHandler tmr.Tick,
'                                     Sub()
'                                         If Me.Opacity < 1 Then
'                                             Me.Opacity += 0.1
'                                         Else
'                                             tmr.Stop()
'                                         End If
'                                     End Sub
'                                 tmr.Start()
'                             End Sub

'        ' Enter = Aceptar
'        AddHandler txtInput.KeyPress, Sub(s, e)
'                                          If e.KeyChar = ChrW(Keys.Enter) Then
'                                              e.Handled = True
'                                              ValidarYEnviar()
'                                          End If
'                                      End Sub

'        ' Esc = Cancelar
'        AddHandler Me.KeyDown, Sub(s, e)
'                                   If e.KeyCode = Keys.Escape Then
'                                       Me.DialogResult = DialogResult.Cancel
'                                       Me.Close()
'                                   End If
'                               End Sub
'    End Sub

'    Private Sub ValidarYEnviar()
'        If String.IsNullOrWhiteSpace(txtInput.Text) Then
'            lblError.Text = "Este campo es obligatorio."
'            lblError.Visible = True
'            txtInput.Focus()
'        Else
'            ValorIngresado = txtInput.Text.Trim()
'            Me.DialogResult = DialogResult.OK
'            Me.Close()
'        End If
'    End Sub

'    Protected Overrides Sub OnPaint(e As PaintEventArgs)
'        MyBase.OnPaint(e)
'        Using path As GraphicsPath = RoundedRect(Me.ClientRectangle, _borderRadius)
'            Me.Region = New Region(path)
'        End Using
'    End Sub

'    Private Function RoundedRect(rect As Rectangle, radius As Integer) As GraphicsPath
'        Dim path As New GraphicsPath()
'        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
'        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
'        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
'        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
'        path.CloseFigure()
'        Return path
'    End Function
'End Class


''Dim inputForm As New InputBoxUI("Ingrese su nombre", "Ej: Wilmer", IconChar.User)
''Dim resultado = inputForm.ShowDialog()

''If resultado = DialogResult.OK Then
''Dim texto = inputForm.ValorIngresado
''MessageBox.Show("Ingresado: " & texto)
''Else
''MessageBox.Show("Cancelado")
''End If