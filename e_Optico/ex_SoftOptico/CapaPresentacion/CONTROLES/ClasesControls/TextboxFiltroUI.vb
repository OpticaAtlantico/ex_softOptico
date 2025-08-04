Imports System.ComponentModel
Imports FontAwesome.Sharp

Public Class TextboxFiltroUI
    Inherits UserControl

    Private _iconBox As IconPictureBox
    Private _textInput As TextBox
    Public Event TextChanged As EventHandler

    Public Sub New()
        Me.Height = 30
        Me.Width = 240
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
        Me.Padding = New Padding(0)

        ' 🔍 Icono de búsqueda
        _iconBox = New IconPictureBox() With {
        .IconChar = IconChar.Search,
        .IconColor = Color.Gray,
        .Size = New Size(20, 20),
        .BackColor = Color.Transparent
    }

        ' Posicionamiento manual para centrar verticalmente
        _iconBox.Location = New Point(8, CInt((Me.Height - _iconBox.Size.Height) / 2))
        _iconBox.Anchor = AnchorStyles.Left Or AnchorStyles.Top

        ' 🧠 Cuadro de texto
        _textInput = New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Century Gothic", 10),
            .Width = 350,
            .AutoSize = False,
            .Dock = DockStyle.Left,
            .Margin = New Padding(0, 4, 0, 2),
            .Padding = New Padding(0, 4, 0, 2), ' ⬇ espacio vertical
            .PlaceholderText = "Buscar...",
            .BackColor = Color.White
        }

        ' 🧩 Panel interno que aloja ícono + texto
        Dim innerPanel As New Panel With {
        .Dock = DockStyle.Fill,
        .BackColor = Color.White,
        .Padding = New Padding(_iconBox.Width + 10, 6, 0, 4) ' ⬅ separa el texto del ícono
    }

        innerPanel.Controls.AddRange({_textInput, _iconBox})
        Me.Controls.Add(innerPanel)

        ' 🔄 Eventos visuales al enfocar
        AddHandler _textInput.GotFocus, Sub() Me.BackColor = Color.FromArgb(230, 244, 255)
        AddHandler _textInput.LostFocus, Sub() Me.BackColor = Color.White

        ' 🔁 Relay del evento TextChanged hacia el control principal
        AddHandler _textInput.TextChanged, Sub(sender, e)
                                               RaiseEvent TextChanged(Me, e)
                                           End Sub
    End Sub

    <Category("Orbital"), Description("Texto del filtro")>
    Public Property Texto As String
        Get
            Return _textInput.Text
        End Get
        Set(value As String)
            _textInput.Text = value
        End Set
    End Property

    <Category("Orbital"), Description("Texto de sugerencia")>
    Public Property PlaceholderText As String
        Get
            Return _textInput.PlaceholderText
        End Get
        Set(value As String)
            _textInput.PlaceholderText = value
        End Set
    End Property

    <Category("Orbital"), Description("Ícono FontAwesome")>
    Public Property Icono As IconChar
        Get
            Return _iconBox.IconChar
        End Get
        Set(value As IconChar)
            _iconBox.IconChar = value
        End Set
    End Property

    <Category("Orbital"), Description("Color del ícono")>
    Public Property IconColor As Color
        Get
            Return _iconBox.IconColor
        End Get
        Set(value As Color)
            _iconBox.IconColor = value
        End Set
    End Property

    Public ReadOnly Property TextoFiltrado As String
        Get
            Return _textInput.Text.Trim()
        End Get
    End Property

End Class
