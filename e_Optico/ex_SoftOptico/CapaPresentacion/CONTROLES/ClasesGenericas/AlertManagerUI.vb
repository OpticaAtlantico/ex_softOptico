Imports System.Windows.Forms
Imports System.Drawing
Public Module AlertManagerUI

    Private alertStack As New List(Of AlertPanelUI)

    Public Sub MostrarAlerta(form As Form, tipo As AlertType, mensaje As String)
        Dim alerta As New AlertPanelUI()
        alerta.TipoAlerta = tipo
        alerta.MensajeAlerta = mensaje
        alerta.Size = New Size(400, 45)

        ' Posicionar en esquina superior derecha
        Dim x = form.ClientSize.Width - alerta.Width - 20
        Dim yBase = 20 + (alertStack.Count * (alerta.Height + 10))

        alerta.Location = New Point(x, yBase)
        form.Controls.Add(alerta)
        alertStack.Add(alerta)

        alerta.Mostrar()

        AddHandler alerta.Disposed, Sub()
                                        alertStack.Remove(alerta)
                                        ReposicionarAlertas(form)
                                    End Sub
    End Sub

    Private Sub ReposicionarAlertas(form As Form)
        For i = 0 To alertStack.Count - 1
            Dim a = alertStack(i)
            Dim x = form.ClientSize.Width - a.Width - 20
            Dim y = 20 + (i * (a.Height + 10))
            a.Location = New Point(x, y)
        Next
    End Sub



End Module
