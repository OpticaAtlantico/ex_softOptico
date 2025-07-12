Imports System.Drawing
Imports System.Windows.Forms

Public Class DatePickerWUI
    Inherits UserControl

    Private _maskedFecha As New MaskedTextBoxFechaWUI()
    Private _btnCalendario As New Label()
    Private _popupCalendario As New MonthCalendar()
    Private _panelSombra As New Panel()

    Public Sub New()
        Me.Size = New Size(297, 35)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        ' Campo de fecha
        _maskedFecha.Location = New Point(0, 0)
        Me.Controls.Add(_maskedFecha)

        ' Botón con ícono calendario
        _btnCalendario.Text = ChrW(&HF073) ' fa-calendar
        _btnCalendario.Font = New Font("Font Awesome 6 Free Solid", 10)
        _btnCalendario.Size = New Size(35, 35)
        _btnCalendario.TextAlign = ContentAlignment.MiddleCenter
        _btnCalendario.ForeColor = Color.Gray
        _btnCalendario.BackColor = Color.Transparent
        _btnCalendario.Location = New Point(Me.Width - 35, 0)
        Me.Controls.Add(_btnCalendario)

        ' Panel flotante
        _panelSombra.Size = New Size(250, 180)
        _panelSombra.BackColor = Color.White
        _panelSombra.BorderStyle = BorderStyle.FixedSingle
        _panelSombra.Visible = False
        _panelSombra.Location = New Point(0, Me.Height + 2)
        _panelSombra.Controls.Add(_popupCalendario)
        _popupCalendario.Dock = DockStyle.Fill
        _popupCalendario.MaxSelectionCount = 1

        Me.Controls.Add(_panelSombra)
        Me.BringToFront()

        AddHandler _btnCalendario.Click, Sub() _panelSombra.Visible = Not _panelSombra.Visible
        AddHandler _popupCalendario.DateSelected, Sub(s, e)
                                                      _maskedFecha.FechaTexto = e.Start.ToString("dd/MM/yyyy")
                                                      _panelSombra.Visible = False
                                                  End Sub
    End Sub

    ' 🎛 Propiedad pública

    Public Property FechaSeleccionada As Date
        Get
            Return If(Date.TryParse(_maskedFecha.FechaTexto, Nothing), Convert.ToDateTime(_maskedFecha.FechaTexto), Date.Today)
        End Get
        Set(value As Date)
            _maskedFecha.FechaTexto = value.ToString("dd/MM/yyyy")
        End Set
    End Property

    Public ReadOnly Property MaskedRef As MaskedTextBox
        Get
            Return _maskedFecha.MaskedRef
        End Get
    End Property
End Class
