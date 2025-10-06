Imports System.Drawing
Imports System.Windows.Forms

Public Class DrawerUI
    Inherits Panel

    Public Event OpcionSeleccionada(opcion As String)

    Public Sub New()
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.AutoScroll = True
    End Sub

    Public Sub CargarOpciones(opciones As List(Of String))
        Me.Controls.Clear()

        Dim y As Integer = 10
        For Each opcion In opciones
            Dim btn As New Button With {
                .Text = opcion,
                .Font = New Font("Segoe UI", 10, FontStyle.Regular),
                .BackColor = Color.White,
                .ForeColor = Color.Black,
                .FlatStyle = FlatStyle.Flat,
                .Width = Me.Width - 20,
                .Height = 40,
                .Location = New Point(10, y),
                .Cursor = Cursors.Hand
            }
            btn.FlatAppearance.BorderSize = 0
            AddHandler btn.Click, Sub() RaiseEvent OpcionSeleccionada(opcion)
            Me.Controls.Add(btn)
            y += 45
        Next
    End Sub
End Class
