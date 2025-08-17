Imports System.Windows.Forms.Control.DoubleBuffered
Public Class FormStylerUI

    ''' <summary>
    ''' Aplica configuración visual estándar: Opacity, DoubleBuffering y estilos de pintura.
    ''' </summary>
    ''' <param name="form">Formulario objetivo</param>
    Public Shared Sub Apply(form As Form)
        If form Is Nothing Then Exit Sub

        form.Opacity = 0
        form.Visible = False

        ' Acceder a DoubleBuffered por reflexión
        Dim prop = form.GetType().GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        If prop IsNot Nothing Then
            prop.SetValue(form, True, Nothing)
        End If

        ' Acceder a SetStyle y UpdateStyles por reflexión
        Dim miSetStyle = form.GetType().GetMethod("SetStyle", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
        Dim miUpdateStyles = form.GetType().GetMethod("UpdateStyles", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)

        miSetStyle?.Invoke(form, {ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer, True})
        miUpdateStyles?.Invoke(form, Nothing)
    End Sub


End Class
