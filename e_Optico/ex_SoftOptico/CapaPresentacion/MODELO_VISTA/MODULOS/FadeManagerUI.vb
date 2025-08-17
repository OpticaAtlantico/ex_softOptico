Public Enum FadeDirection
    FadeIn
    FadeOut
End Enum

Public Module FadeManagerUI
    Private fadeTimer As New Timer With {.Interval = 30}
    Private fadeTarget As Form
    Private fadeDirection As FadeDirection
    Private fadeStep As Double = 0.2
    Private isFading As Boolean = False

    Public Sub StartFade(form As Form, direction As FadeDirection, Optional speed As Double = 0.08)
        If form Is Nothing Then Exit Sub
        Dim t As New Timer With {.Interval = 15}
        AddHandler t.Tick,
            Sub()
                Select Case direction
                    Case FadeDirection.FadeIn
                        If form.Opacity < 1 Then
                            form.Opacity += speed
                        Else
                            form.Opacity = 1
                            t.Stop()
                            t.Dispose()
                        End If
                    Case FadeDirection.FadeOut
                        If form.Opacity > 0 Then
                            form.Opacity -= speed
                        Else
                            form.Opacity = 0
                            t.Stop()
                            t.Dispose()
                            form.Close()
                        End If
                End Select
            End Sub
        form.Opacity = If(direction = FadeDirection.FadeIn, 0, 1)
        t.Start()

    End Sub

    Public Sub ShowWithFade(form As Form, Optional speed As Double = 0.08)
        FormStylerUI.Apply(form)
        'form.Show()
        StartFade(form, FadeDirection.FadeIn, speed)
    End Sub
    Public Sub ApplyOut(form As Form, Optional durationMs As Integer = 300)
        If form Is Nothing OrElse form.IsDisposed Then Exit Sub

        Dim steps As Integer = 30
        Dim interval As Integer = durationMs \ steps
        Dim decrement As Double = 1.0 / steps

        Dim t As New Timer With {.Interval = interval}
        AddHandler t.Tick, Sub(sender, e)
                               If form.Opacity > decrement Then
                                   form.Opacity -= decrement
                               Else
                                   t.Stop()
                                   t.Dispose()
                                   form.Close()
                               End If
                           End Sub
        t.Start()
    End Sub

End Module