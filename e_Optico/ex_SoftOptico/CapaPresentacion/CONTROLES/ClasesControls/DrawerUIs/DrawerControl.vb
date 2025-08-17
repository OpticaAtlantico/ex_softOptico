Imports FontAwesome.Sharp
Public Class DrawerControl
    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or
                    ControlStyles.UserPaint Or
                    ControlStyles.OptimizedDoubleBuffer, True)
        Me.UpdateStyles()

        Me.Dock = DockStyle.Fill
    End Sub

    Public Sub CargarOpciones(opciones As List(Of Tuple(Of String, IconChar, EventHandler)))
        pnlOpciones.Controls.Clear()

        For Each opcion In opciones
            Dim btn As New IconButton With {
                .Text = opcion.Item1,
                .IconChar = opcion.Item2,
                .IconColor = Color.Black,
                .TextImageRelation = TextImageRelation.ImageBeforeText,
                .TextAlign = ContentAlignment.MiddleLeft,
                .ImageAlign = ContentAlignment.MiddleLeft,
                .Padding = New Padding(10, 0, 0, 0),
                .Dock = DockStyle.Top,
                .Height = 40,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Century Gothic", 9, FontStyle.Regular),
                .BackColor = Color.White,
                .ForeColor = Color.Black,
                .IconSize = 26
            }
            btn.FlatAppearance.BorderSize = 0

            If opcion.Item3 IsNot Nothing Then
                AddHandler btn.Click, opcion.Item3
            End If

            pnlOpciones.Controls.Add(btn)
        Next
    End Sub
End Class
