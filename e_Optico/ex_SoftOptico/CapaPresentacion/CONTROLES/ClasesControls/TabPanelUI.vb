Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class TabPanelUI
    Inherits UserControl

    Private WithEvents selectorTabs As New FlowLayoutPanel()
    Private panelContenido As New Panel()
    Private listaPaginas As New List(Of Control)
    Private colorActivo As Color = ThemeManagerUI.ColorPrimario
    Private colorInactivo As Color = ThemeManagerUI.ColorBorde
    Private colorTexto As Color = ThemeManagerUI.ColorTextoBase

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(600, 400)
        Me.BackColor = ThemeManagerUI.ColorFondoBase

        selectorTabs.Dock = DockStyle.Top
        selectorTabs.Height = 40
        selectorTabs.BackColor = Color.Transparent
        selectorTabs.FlowDirection = FlowDirection.LeftToRight
        selectorTabs.WrapContents = False
        Me.Controls.Add(selectorTabs)

        panelContenido.Dock = DockStyle.Fill
        panelContenido.BackColor = Color.Transparent
        Me.Controls.Add(panelContenido)
    End Sub

    Public Sub AgregarPestaña(titulo As String, contenido As Control)
        Dim btnTab As New Button()
        btnTab.Text = titulo
        btnTab.FlatStyle = FlatStyle.Flat
        btnTab.FlatAppearance.BorderSize = 0
        btnTab.Font = New Font("Century Gothic", 10, FontStyle.Bold)
        btnTab.ForeColor = colorTexto
        btnTab.BackColor = colorInactivo
        btnTab.Margin = New Padding(4, 6, 4, 0)
        btnTab.Height = 28
        btnTab.AutoSize = True

        AddHandler btnTab.Click, Sub(sender, e)
                                     MostrarContenido(contenido)
                                     ActualizarEstiloTabs(btnTab)
                                 End Sub

        selectorTabs.Controls.Add(btnTab)
        listaPaginas.Add(contenido)

        contenido.Dock = DockStyle.Fill
        contenido.Visible = False
        panelContenido.Controls.Add(contenido)

        If listaPaginas.Count = 1 Then
            MostrarContenido(contenido)
            ActualizarEstiloTabs(btnTab)
        End If
    End Sub

    Private Sub MostrarContenido(ctrlActivo As Control)
        For Each ctrl In listaPaginas
            ctrl.Visible = (ctrl Is ctrlActivo)
        Next
    End Sub

    Private Sub ActualizarEstiloTabs(tabActivo As Button)
        For Each ctrl As Control In selectorTabs.Controls
            If TypeOf ctrl Is Button Then
                Dim btn = CType(ctrl, Button)
                btn.BackColor = If(btn Is tabActivo, colorActivo, colorInactivo)
                btn.ForeColor = colorTexto
            End If
        Next
    End Sub

    Public Sub AplicarEstiloDesdeTema()
        Me.BackColor = ThemeManagerUI.ColorFondoBase
        colorActivo = ThemeManagerUI.ColorPrimario
        colorInactivo = ThemeManagerUI.ColorBorde
        colorTexto = ThemeManagerUI.ColorTextoBase
        Me.Invalidate()
    End Sub

    'Como lo usas

    'Dim tabPanel As New TabPanelUI()
    'tabPanel.Dock = DockStyle.Fill
    'Me.Controls.Add(tabPanel)

    'Dim pagina1 As New FloatingCardUI()
    'pagina1.Controls.Add(New LabelUI() With {.Text = "Datos personales"})

    'Dim pagina2 As New FloatingCardUI()
    'pagina2.Controls.Add(New LabelUI() With {.Text = "Preferencias"})

    'tabPanel.AgregarPestaña("Perfil", pagina1)
    'tabPanel.AgregarPestaña("Opciones", pagina2)


End Class
