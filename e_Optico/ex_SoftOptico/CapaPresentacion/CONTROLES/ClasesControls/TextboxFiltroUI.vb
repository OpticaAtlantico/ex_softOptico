Imports System.ComponentModel
Imports FontAwesome.Sharp

Public Class TextboxFiltroUI
    Inherits UserControl

    Private _iconBox As IconPictureBox
    Private _textInput As TextBox
    Public Event TextChanged As EventHandler

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

    Public Sub New()
        Me.Height = 32
        Me.Width = 240
        Me.BackColor = Color.White
        Me.Padding = New Padding(6)
        Me.DoubleBuffered = True

        _iconBox = New IconPictureBox() With {
            .IconChar = IconChar.Search,
            .IconColor = Color.Gray,
            .Size = New Size(20, 20),
            .Dock = DockStyle.Left,
            .Padding = New Padding(2),
            .BackColor = Color.Transparent
        }

        _textInput = New TextBox() With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 10),
            .Dock = DockStyle.Fill,
            .PlaceholderText = "Buscar...",
            .BackColor = Color.White
        }

        Dim innerPanel As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .Padding = New Padding(4)
        }

        innerPanel.Controls.AddRange({_textInput, _iconBox})
        Me.Controls.Add(innerPanel)

        AddHandler _textInput.GotFocus, Sub() Me.BackColor = Color.FromArgb(230, 244, 255)
        AddHandler _textInput.LostFocus, Sub() Me.BackColor = Color.White

        AddHandler _textInput.TextChanged, Sub(sender, e)
                                               RaiseEvent TextChanged(Me, e)
                                           End Sub

    End Sub


End Class