Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

Public Enum AlertType
    Success
    Warning
    Errores
    Info
End Enum

Public Class AlertPanelUI
    Inherits UserControl

    Private _tipo As AlertType = AlertType.Info
    Private _mensaje As String = "Mensaje de alerta"
    Private _iconChar As IconChar = IconChar.InfoCircle
    Private _iconColor As Color = AppColors._cBlanco
    Private _fondoColor As Color = AppColors._cBasePrimary
    Private _textoColor As Color = AppColors._cBlanco
    Private _fadeTimer As New Timer()
    Private _vidaTimer As New Timer()
    Private _opacidad As Integer = 255
    Private _btnCerrar As New Label()

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(800, 60)
        Me.BackColor = Color.Transparent

        _btnCerrar.Text = "✖"
        _btnCerrar.Font = New Font(AppFonts.Century, AppFonts.SizeMedium, AppFonts.Bold)
        _btnCerrar.ForeColor = AppColors._cBlanco
        _btnCerrar.AutoSize = False
        _btnCerrar.TextAlign = ContentAlignment.MiddleCenter
        _btnCerrar.Size = New Size(20, 20)
        _btnCerrar.Location = New Point(Me.Width - 25, 5)
        _btnCerrar.Cursor = Cursors.Hand
        AddHandler _btnCerrar.Click, Sub() Me.Dispose()
        Me.Controls.Add(_btnCerrar)

        _vidaTimer.Interval = 5000
        AddHandler _vidaTimer.Tick, Sub()
                                        _vidaTimer.Stop()
                                        _fadeTimer.Start()
                                    End Sub

        _fadeTimer.Interval = 30
        AddHandler _fadeTimer.Tick, Sub()
                                        _opacidad -= 15
                                        If _opacidad <= 0 Then
                                            _fadeTimer.Stop()
                                            Me.Dispose()
                                        Else
                                            Me.Invalidate()
                                        End If
                                    End Sub

        Me.Visible = False
    End Sub
#End Region

#Region "PROPIEDADES"
    Public Property TipoAlerta As AlertType
        Get
            Return _tipo
        End Get
        Set(value As AlertType)
            _tipo = value
            Select Case value
                Case AlertType.Success
                    _fondoColor = AppColors._cBaseSuccess
                    _iconChar = IconChar.CheckCircle
                Case AlertType.Warning
                    _fondoColor = AppColors._cBaseWarning
                    _iconChar = IconChar.ExclamationTriangle
                Case AlertType.Errores
                    _fondoColor = AppColors._cBaseDanger
                    _iconChar = IconChar.TimesCircle
                Case AlertType.Info
                    _fondoColor = AppColors._cBaseInfo
                    _iconChar = IconChar.InfoCircle
            End Select
            Me.Invalidate()
        End Set
    End Property

    Public Property MensajeAlerta As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "PROCEDIMIENTO"
    Public Sub Mostrar()
        Me.Visible = True
        _opacidad = 255
        _vidaTimer.Start()
        Me.Invalidate()
    End Sub
#End Region

#Region "DIBUJO"
    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim radio As Integer = 12

        Dim fondoColorFade = Color.FromArgb(_opacidad, _fondoColor)
        Dim textoColorFade = Color.FromArgb(_opacidad, _textoColor)
        Dim iconColorFade = Color.FromArgb(_opacidad, _iconColor)

        ' --- 🎨 Sombra inclinada ---
        'Using pathShadow As GraphicsPath = CrearPathRedondeado(New Rectangle(rect.X + 4, rect.Y + 4, rect.Width, rect.Height), radio)
        '    Using br As New SolidBrush(Color.FromArgb(80, Color.Black))
        '        g.FillPath(br, pathShadow)
        '    End Using
        'End Using

        ' --- 🎨 Fondo redondeado ---
        Using path As GraphicsPath = CrearPathRedondeado(rect, radio)
            Using br As New SolidBrush(fondoColorFade)
                g.FillPath(br, path)
            End Using
            g.DrawPath(New Pen(Color.White, 1), path)
        End Using

        ' --- 🔹 Ícono FontAwesome ---
        Dim icono As New IconPictureBox()
        icono.IconChar = _iconChar
        icono.IconColor = iconColorFade
        icono.IconSize = 35
        icono.BackColor = _fondoColor
        Using bmp As New Bitmap(icono.Width, icono.Height)
            icono.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
            g.DrawImage(bmp, New Point(12, (Me.Height \ 2) - (bmp.Height \ 2)))
        End Using

        ' --- 🔹 Texto ---
        TextRenderer.DrawText(g, _mensaje,
                              New Font(AppFonts.Century, AppFonts.SizeSmall),
                              New Rectangle(50, 5, Me.Width - 80, Me.Height - 10),
                              textoColorFade,
                              TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
    End Sub

    Private Function CrearPathRedondeado(rect As Rectangle, radio As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, radio, radio, 180, 90)
        path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90)
        path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90)
        path.CloseFigure()
        Return path
    End Function
#End Region

End Class

'AlertManagerUI.MostrarAlerta(Me, AlertType.Info, "hola ara todos")