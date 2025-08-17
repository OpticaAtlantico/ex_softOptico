Imports System.ComponentModel
Imports System.Drawing

Public Class ButtonLinkUI

    Private _hoverColor As Color = Color.DodgerBlue
    Private _normalColor As Color = Color.WhiteSmoke
    Private _activeColor As Color = Color.RoyalBlue
    Private _subrayarHover As Boolean = True

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        lblTexto.ForeColor = _normalColor
        lblTexto.Cursor = Cursors.Hand
        lblTexto.Font = New Font("Century Gothic", 10, FontStyle.Regular)
        lblTexto.AutoSize = True
        lblTexto.TextAlign = ContentAlignment.MiddleLeft
        lblTexto.Dock = DockStyle.Fill
        Me.BackColor = Color.Transparent
    End Sub

    ' === Propiedades Personalizadas ===

    <Category("WilmerUI")>
    Public Property HoverColor As Color
        Get
            Return _hoverColor
        End Get
        Set(value As Color)
            _hoverColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property NormalColor As Color
        Get
            Return _normalColor
        End Get
        Set(value As Color)
            _normalColor = value
            lblTexto.ForeColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property ActiveColor As Color
        Get
            Return _activeColor
        End Get
        Set(value As Color)
            _activeColor = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property SubrayarAlPasar As Boolean
        Get
            Return _subrayarHover
        End Get
        Set(value As Boolean)
            _subrayarHover = value
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property LinkText As String
        Get
            Return lblTexto.Text
        End Get
        Set(value As String)
            lblTexto.Text = value
        End Set
    End Property

    ' === Eventos Hover y Click ===

    Private Sub lblTexto_MouseEnter(sender As Object, e As EventArgs) Handles lblTexto.MouseEnter
        lblTexto.ForeColor = _hoverColor
        If _subrayarHover Then
            lblTexto.Font = New Font(lblTexto.Font, FontStyle.Underline)
        End If
    End Sub

    Private Sub lblTexto_MouseLeave(sender As Object, e As EventArgs) Handles lblTexto.MouseLeave
        lblTexto.ForeColor = _normalColor
        lblTexto.Font = New Font(lblTexto.Font, FontStyle.Regular)
    End Sub

    Private Sub lblTexto_MouseDown(sender As Object, e As MouseEventArgs) Handles lblTexto.MouseDown
        lblTexto.ForeColor = _activeColor
    End Sub

    Private Sub lblTexto_MouseUp(sender As Object, e As MouseEventArgs) Handles lblTexto.MouseUp
        lblTexto.ForeColor = _hoverColor
    End Sub

    ' Evento público para que puedas manejar el Click
    Public Event LinkClick As EventHandler
    Private Sub lblTexto_Click(sender As Object, e As EventArgs) Handles lblTexto.Click
        RaiseEvent LinkClick(Me, EventArgs.Empty)
    End Sub
End Class
