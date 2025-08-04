Imports System.Runtime.InteropServices

Public Class FondoOverlay
        Inherits Form

        Public Sub New()
            Me.FormBorderStyle = FormBorderStyle.None
            Me.StartPosition = FormStartPosition.Manual
            Me.BackColor = Color.Black
            Me.Opacity = 0.5 ' Ajusta la transparencia aquí
            Me.ShowInTaskbar = False
            Me.TopMost = False
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

            ' Cubre toda la pantalla (ajusta si quieres que cubra solo el dueño)
            Me.WindowState = FormWindowState.Maximized
            Me.Location = New Point(0, 0)

            ' Opcional: Para que no aparezca en ALT+TAB
            Me.FormBorderStyle = FormBorderStyle.None
        End Sub

        ' No recibe foco para que no interrumpa
        Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
            Get
                Return True
            End Get
        End Property

        ' No aparece en ALT+TAB
        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                Const WS_EX_TOOLWINDOW As Integer = &H80
                cp.ExStyle = cp.ExStyle Or WS_EX_TOOLWINDOW
                Return cp
            End Get
        End Property

    End Class
