Imports System.Drawing
Imports System.Windows.Forms

Public Class TexboxConPlaceholder

    Public Class TextBoxConPlaceholder
        Inherits TextBox

        Private _placeholder As String = "Escribe aquí..."
        Private _placeholderColor As Color = Color.Gray

        Public Property Placeholder As String
            Get
                Return _placeholder
            End Get
            Set(value As String)
                _placeholder = value
                Me.Invalidate()
            End Set
        End Property

        Public Property PlaceholderColor As Color
            Get
                Return _placeholderColor
            End Get
            Set(value As Color)
                _placeholderColor = value
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)

            Const WM_PAINT As Integer = &HF

            If m.Msg = WM_PAINT Then
                If String.IsNullOrEmpty(Me.Text) AndAlso Not Me.Focused Then
                    Using g As Graphics = Me.CreateGraphics()
                        TextRenderer.DrawText(g, _placeholder, Me.Font, Me.ClientRectangle, _placeholderColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter)
                    End Using
                End If
            End If
        End Sub
    End Class
End Class
