Public Class CheckBoxLabelUI
    Inherits UserControl

    Private _Texto As String = "Etiqueta"
    Private _CheckedColor As Color = Color.MediumSlateBlue
    Private _UncheckedColor As Color = Color.WhiteSmoke
    Private _BorderColor As Color = Color.Gray

    Public Event CheckedChanged(sender As Object, e As EventArgs)
    Private WithEvents chk As New CheckBoxUI
    Private WithEvents lblTexto As New Label

#Region "PROPIEDADES"
    Public Property Texto As String
        Get
            Return _Texto
        End Get
        Set(value As String)
            _Texto = value
            lblTexto.Text = value
        End Set
    End Property

    Public Property CheckedColor As Color
        Get
            Return _CheckedColor
        End Get
        Set(value As Color)
            _CheckedColor = value
            chk.CheckedColor = value
        End Set
    End Property

    Public Property UncheckedColor As Color
        Get
            Return _UncheckedColor
        End Get
        Set(value As Color)
            _UncheckedColor = value
            chk.UncheckedColor = value
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
            chk.BorderColor = value
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return chk.Checked
        End Get
        Set(value As Boolean)
            chk.Checked = value
        End Set
    End Property
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or
                    ControlStyles.UserPaint Or
                    ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()
        Me.Size = New Size(200, 28)
        Me.BackColor = Color.Transparent

        chk.Location = New Point(0, 2)
        chk.Size = New Size(24, 24)

        lblTexto.Location = New Point(chk.Right + 8, 4)
        lblTexto.AutoSize = True
        lblTexto.Text = _Texto
        lblTexto.Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
        lblTexto.ForeColor = AppColors._cTexto
        lblTexto.Cursor = Cursors.Hand

        Me.Controls.Add(chk)
        Me.Controls.Add(lblTexto)
    End Sub
#End Region

#Region "EVENTOS"
    Private Sub lblTexto_Click(sender As Object, e As EventArgs) Handles lblTexto.Click
        chk.Checked = Not chk.Checked
    End Sub

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chk.CheckedChanged
        RaiseEvent CheckedChanged(Me, EventArgs.Empty)
    End Sub
#End Region

End Class
