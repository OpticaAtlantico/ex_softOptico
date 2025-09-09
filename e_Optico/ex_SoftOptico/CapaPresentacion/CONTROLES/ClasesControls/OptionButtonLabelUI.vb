Public Class OptionButtonLabelUI
    Inherits UserControl

    ' ➤ Atributos
    Private _Texto As String = "Opción"
    Private _Checked As Boolean = False
    Private _CheckedColor As Color = AppColors._cOptionButton
    Private _BorderColor As Color = AppColors._cBasePrimary

    Private animationTimer As Timer
    Private animationProgress As Single = 0F
    Private lblTexto As Label

    Public Event CheckedChanged(sender As Object, e As EventArgs)

#Region "PROPIEDADES"
    ' ➤ Propiedades públicas
    Public Property Texto As String
        Get
            Return _Texto
        End Get
        Set(value As String)
            _Texto = value
            If lblTexto IsNot Nothing Then lblTexto.Text = value
            Invalidate()
        End Set
    End Property

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            If _Checked <> value Then
                _Checked = value
                RaiseEvent CheckedChanged(Me, EventArgs.Empty)
                animationProgress = 0F
                animationTimer.Start()
                Invalidate()
                If value Then DesactivarOtros()
            End If
        End Set
    End Property

    Public Property CheckedColor As Color
        Get
            Return _CheckedColor
        End Get
        Set(value As Color)
            _CheckedColor = value : Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value : Invalidate()
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

        animationTimer = New Timer With {.Interval = 15}
        AddHandler animationTimer.Tick, AddressOf AvanzarAnimacion

        lblTexto = New Label With {
            .Text = _Texto,
            .Location = New Point(28, 4),
            .AutoSize = True,
            .Font = New Font(AppFonts.Century, AppFonts.SizeMedium),
            .Cursor = Cursors.Hand
        }
        AddHandler lblTexto.Click, Sub() Me.Checked = True
        Me.Controls.Add(lblTexto)
    End Sub
#End Region

#Region "DIBUJO"
    ' ➤ Dibujo animado del botón
    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        Dim outerRect = New Rectangle(4, 4, 18, 18)
        Using pen As New Pen(BorderColor, 1.6F)
            g.DrawEllipse(pen, outerRect)
        End Using

        If Checked Then
            Dim maxSize = 10
            Dim currentSize = CInt(maxSize * animationProgress)
            Dim offset = (outerRect.Width - currentSize) \ 2
            Dim innerRect = New Rectangle(outerRect.X + offset, outerRect.Y + offset, currentSize, currentSize)

            Using b As New SolidBrush(CheckedColor)
                g.FillEllipse(b, innerRect)
            End Using
        End If
    End Sub
#End Region

#Region "PROCEDIMIENTO"
    ' ➤ Animación progresiva
    Private Sub AvanzarAnimacion(sender As Object, e As EventArgs)
        animationProgress += 0.1F
        If animationProgress >= 1.0F Then
            animationProgress = 1.0F
            animationTimer.Stop()
        End If
        Me.Invalidate()
    End Sub

    ' ➤ Desactivación automática de otros OptionButtonUI en el mismo contenedor
    Private Sub DesactivarOtros()
        If Me.Parent IsNot Nothing Then
            For Each ctrl In Me.Parent.Controls
                If TypeOf ctrl Is OptionButtonLabelUI AndAlso ctrl IsNot Me Then
                    DirectCast(ctrl, OptionButtonLabelUI).Checked = False
                End If
            Next
        End If
    End Sub

    ' ➤ Eventos de interacción
    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Me.Checked = True
    End Sub
#End Region

End Class


'Uso en e formulario

'Dim opt1 As New OptionButtonUI With {.Texto = "Opción A", .Location = New Point(30, 40)}
'Dim opt2 As New OptionButtonUI With {.Texto = "Opción B", .Location = New Point(30, 80)}
'Dim opt3 As New OptionButtonUI With {.Texto = "Opción C", .Location = New Point(30, 120)}

'AddHandler opt1.CheckedChanged, Sub() MsgBox("Elegiste: A")
'AddHandler opt2.CheckedChanged, Sub() MsgBox("Elegiste: B")
'AddHandler opt3.CheckedChanged, Sub() MsgBox("Elegiste: C")

'Me.Controls.AddRange({opt1, opt2, opt3})