Imports System.ComponentModel
Imports FontAwesome.Sharp

Public Class MessageBoxUI
    Inherits UserControl

    Public Enum MessageBoxTipo
        Info
        Success
        Warning
        ErrorMsg
        Question
    End Enum

    Public Enum MessageBoxBotones
        Aceptar
        AceptarCancelar
        SiNo
    End Enum

    Public Event Resultado(respuesta As DialogResult)

    Private _tipo As MessageBoxTipo = MessageBoxTipo.Info
    Private _titulo As String = "Mensaje"
    Private _mensaje As String = "Esto es un mensaje."
    Private _botones As MessageBoxBotones = MessageBoxBotones.Aceptar

    ' Propiedades configurables
    <Category("WilmerUI")>
    Public Property Tipo As MessageBoxTipo
        Get
            Return _tipo
        End Get
        Set(value As MessageBoxTipo)
            _tipo = value
            ConfigurarIcono()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property Titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
            lblTitulo.Text = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
            lblMensaje.Text = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property Botones As MessageBoxBotones
        Get
            Return _botones
        End Get
        Set(value As MessageBoxBotones)
            _botones = value
            ConfigurarBotones()
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        Me.BackColor = Color.FromArgb(180, 0, 0, 0) ' fondo semitransparente negro
        ConfigurarControles()
    End Sub

    Private Sub ConfigurarControles()
        pnlBase.BackColor = Color.White
        pnlBase.Region = New Region(New Drawing2D.GraphicsPath())
        pnlBase.Region.MakeEmpty()

        lblTitulo.Font = New Font("Segoe UI Semibold", 14)
        lblMensaje.Font = New Font("Segoe UI", 11)
        lblTitulo.ForeColor = Color.Black
        lblMensaje.ForeColor = Color.DimGray

        ConfigurarIcono()
        ConfigurarBotones()
    End Sub

    Private Sub ConfigurarIcono()
        Select Case _tipo
            Case MessageBoxTipo.Info
                Icon.IconChar = IconChar.InfoCircle
                Icon.IconColor = Color.RoyalBlue
            Case MessageBoxTipo.Success
                Icon.IconChar = IconChar.CheckCircle
                Icon.IconColor = Color.SeaGreen
            Case MessageBoxTipo.Warning
                Icon.IconChar = IconChar.ExclamationTriangle
                Icon.IconColor = Color.Goldenrod
            Case MessageBoxTipo.ErrorMsg
                Icon.IconChar = IconChar.TimesCircle
                Icon.IconColor = Color.Firebrick
            Case MessageBoxTipo.Question
                Icon.IconChar = IconChar.QuestionCircle
                Icon.IconColor = Color.SteelBlue
        End Select
    End Sub

    Private Sub ConfigurarBotones()
        pnlBotones.Controls.Clear()
        Select Case _botones
            Case MessageBoxBotones.Aceptar
                pnlBotones.Controls.Add(CrearBoton("Aceptar", DialogResult.OK))
            Case MessageBoxBotones.AceptarCancelar
                pnlBotones.Controls.Add(CrearBoton("Aceptar", DialogResult.OK))
                pnlBotones.Controls.Add(CrearBoton("Cancelar", DialogResult.Cancel))
            Case MessageBoxBotones.SiNo
                pnlBotones.Controls.Add(CrearBoton("Sí", DialogResult.Yes))
                pnlBotones.Controls.Add(CrearBoton("No", DialogResult.No))
        End Select
    End Sub

    Private Function CrearBoton(texto As String, resultado As DialogResult) As Button
        Dim btn As New Button With {
            .Text = texto,
            .DialogResult = resultado,
            .Height = 35,
            .Width = 90,
            .FlatStyle = FlatStyle.Flat,
            .Font = New Font("Segoe UI", 10),
            .BackColor = Color.FromArgb(45, 132, 245),
            .ForeColor = Color.White,
            .Margin = New Padding(10)
        }
        AddHandler btn.Click, Sub() RaiseEvent resultado(resultado)
        Return btn
    End Function
End Class

