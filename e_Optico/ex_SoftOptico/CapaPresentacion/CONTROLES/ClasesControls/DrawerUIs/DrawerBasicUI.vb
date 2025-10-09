Imports FontAwesome.Sharp

Public Class DrawerbasicUI
    Inherits UserControl

    Private panelContenido As Panel
    Private headerLabel As Label
    Private activeOption As IconButton = Nothing

    Public Event OpcionSeleccionada(form As Form)

    Public Sub New()
        Me.Width = 240
        Me.BackColor = Color.FromArgb(248, 249, 250) ' Gris Bootstrap elegante
        Me.Visible = False
        InitializeComponents()
    End Sub

    Private Sub InitializeComponents()
        headerLabel = New Label() With {
            .Text = "Menú",
            .Dock = DockStyle.Top,
            .Height = 45,
            .Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold),
            .ForeColor = Color.FromArgb(52, 58, 64),
            .TextAlign = ContentAlignment.MiddleLeft,
            .Padding = New Padding(15, 0, 0, 0)
        }

        panelContenido = New Panel() With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .Padding = New Padding(8)
        }

        Me.Controls.Add(panelContenido)
        Me.Controls.Add(headerLabel)
    End Sub

    Public Sub CargarOpcionesAcordeon(opcionesPorCategoria As Dictionary(Of String, List(Of (String, Form))))
        panelContenido.Controls.Clear()
        Dim yPos As Integer = 5

        For Each categoria In opcionesPorCategoria
            ' --- CABECERA DE CATEGORÍA ---
            Dim btnCategoria As New IconButton() With {
                .Text = categoria.Key,
                .Dock = DockStyle.Top,
                .Height = 45,
                .FlatStyle = FlatStyle.Flat,
                .ForeColor = Color.FromArgb(33, 37, 41),
                .Font = New Font("Segoe UI Semibold", 10),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Padding = New Padding(18, 0, 0, 0),
                .IconChar = IconChar.ChevronRight,
                .IconColor = Color.Gray,
                .IconSize = 16,
                .TextImageRelation = TextImageRelation.ImageBeforeText,
                .BackColor = Color.White,
                .Cursor = Cursors.Hand
            }
            btnCategoria.FlatAppearance.BorderSize = 0

            Dim pnlSubMenu As New Panel() With {
                .Dock = DockStyle.Top,
                .AutoSize = True,
                .Visible = False,
                .BackColor = Color.FromArgb(248, 249, 250)
            }

            ' --- BOTONES DE SUBMENÚ ---
            For Each op In categoria.Value
                Dim btnOpcion As New IconButton() With {
                    .Text = op.Item1,
                    .Dock = DockStyle.Top,
                    .Height = 38,
                    .FlatStyle = FlatStyle.Flat,
                    .ForeColor = Color.FromArgb(73, 80, 87),
                    .Font = New Font("Segoe UI", 9),
                    .TextAlign = ContentAlignment.MiddleLeft,
                    .Padding = New Padding(38, 0, 0, 0),
                    .IconChar = IconChar.Circle,
                    .IconColor = Color.Silver,
                    .IconSize = 8,
                    .TextImageRelation = TextImageRelation.ImageBeforeText,
                    .BackColor = Color.Transparent,
                    .Cursor = Cursors.Hand
                }
                btnOpcion.FlatAppearance.BorderSize = 0

                ' Hover visual
                AddHandler btnOpcion.MouseEnter, Sub() btnOpcion.BackColor = Color.FromArgb(233, 236, 239)
                AddHandler btnOpcion.MouseLeave, Sub()
                                                     If btnOpcion IsNot activeOption Then
                                                         btnOpcion.BackColor = Color.Transparent
                                                     End If
                                                 End Sub

                ' Selección de opción
                AddHandler btnOpcion.Click, Sub()
                                                If activeOption IsNot Nothing Then
                                                    activeOption.BackColor = Color.Transparent
                                                    activeOption.ForeColor = Color.FromArgb(73, 80, 87)
                                                End If

                                                activeOption = btnOpcion
                                                btnOpcion.BackColor = Color.FromArgb(222, 226, 230)
                                                btnOpcion.ForeColor = Color.Black

                                                RaiseEvent OpcionSeleccionada(op.Item2)
                                                Me.Visible = False
                                            End Sub

                pnlSubMenu.Controls.Add(btnOpcion)
            Next

            ' --- CLICK EN CATEGORÍA (ACORDEÓN) ---
            AddHandler btnCategoria.Click, Sub()
                                               For Each ctrl In panelContenido.Controls
                                                   If TypeOf ctrl Is Panel Then
                                                       Dim p = DirectCast(ctrl, Panel)
                                                       p.Visible = False
                                                   End If
                                               Next
                                               pnlSubMenu.Visible = Not pnlSubMenu.Visible
                                               btnCategoria.IconChar = If(pnlSubMenu.Visible, IconChar.ChevronDown, IconChar.ChevronRight)
                                           End Sub

            ' Agregar al panel principal
            panelContenido.Controls.Add(pnlSubMenu)
            panelContenido.Controls.Add(btnCategoria)

            yPos += btnCategoria.Height + pnlSubMenu.Height + 5
        Next
    End Sub
End Class
