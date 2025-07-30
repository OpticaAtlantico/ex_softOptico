Imports System.Windows.Forms

Public Class FormConCorteSuave
    Inherits Form

    Private fadeTimer As New Timer()
    Private fadeStep As Double = 0.1

    Public Sub New()
        ' Doble buffer para reducir flickering
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()

        ' Formato visual suave
        Me.Opacity = 0
        Me.Visible = False

        ' Configuración del timer para la transición suave
        AddHandler fadeTimer.Tick, AddressOf FadeIn
        fadeTimer.Interval = 30
    End Sub

    ' Usamos WS_EX_COMPOSITED para evitar parpadeos fuertes
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000 ' WS_EX_COMPOSITED
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ' Permite a clases hijas preparar su contenido antes de mostrar
        Me.SuspendLayout()
        PrepararUI()
        Me.ResumeLayout()

        Me.Visible = True
        fadeTimer.Start()
    End Sub

    ' Transición de aparición suave
    Private Sub FadeIn(sender As Object, e As EventArgs)
        If Me.Opacity < 1 Then
            Me.Opacity += fadeStep
        Else
            fadeTimer.Stop()
        End If
    End Sub

    ' Método opcional que puedes sobrescribir desde tus formularios
    Protected Overridable Sub PrepararUI()
        ' Ejemplo: se puede sobrescribir para inicializar controles antes de que el formulario aparezca
    End Sub
End Class

