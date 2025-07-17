Imports System.Windows.Forms
Imports CapaPresentacion.ThemeManagerWUI
Public Class frm_Visual

    Inherits Form

    Private lblEstadoTema As New LabelWUI()
    Private btnModoClaro As New ButtonWUI()
    Private btnModoOscuro As New ButtonWUI()
    Private btnGuardarTema As New ButtonWUI()
    Private tabControles As New TabControl()

    Private Sub frm_Visual_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    'Public Sub New()
    '    Me.Text = "Centro de Tema WilmerUI"
    '    Me.Size = New Size(800, 500)
    '    Me.StartPosition = FormStartPosition.CenterScreen
    '    Me.Font = New Font("Segoe UI", 9)
    '    Me.FormBorderStyle = FormBorderStyle.FixedSingle
    '    Me.MaximizeBox = False

    '    InicializarControles()
    '    CargarTabs()
    '    AplicarTemaVisual()

    '    AddHandler ThemeManagerWUI.TemaCambiado, Sub()
    '                                                 AplicarTemaVisual()
    '                                             End Sub
    'End Sub

    'Private Sub InicializarControles()
    '    ' Botones de tema
    '    btnModoClaro.BotonTexto = ChrW(&HF185) & " Claro"
    '    btnModoClaro.Size = New Size(100, 35)
    '    btnModoClaro.Location = New Point(30, 20)
    '    AddHandler btnModoClaro.BotonClick, Sub()
    '                                            ThemeManagerWUI.CambiarTema(TemaVisual.Claro)
    '                                        End Sub
    '    Me.Controls.Add(btnModoClaro)

    '    btnModoOscuro.BotonTexto = ChrW(&HF186) & " Oscuro"
    '    btnModoOscuro.Size = New Size(100, 35)
    '    btnModoOscuro.Location = New Point(150, 20)
    '    AddHandler btnModoOscuro.BotonClick, Sub()
    '                                             ThemeManagerWUI.CambiarTema(TemaVisual.Oscuro)
    '                                         End Sub
    '    Me.Controls.Add(btnModoOscuro)

    '    btnGuardarTema.BotonTexto = ChrW(&HF0C7) & " Guardar Tema"
    '    btnGuardarTema.Size = New Size(130, 35)
    '    btnGuardarTema.Location = New Point(270, 20)
    '    AddHandler btnGuardarTema.BotonClick, Sub()
    '                                              GestorPreferencias.GuardarTemaActual()
    '                                              MessageBox.Show("Preferencia guardada correctamente ✅", "WilmerUI", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                                          End Sub
    '    Me.Controls.Add(btnGuardarTema)

    '    ' Estado visual
    '    lblEstadoTema.Texto = "Tema actual: " & ThemeManagerWUI.TemaActual.ToString()
    '    lblEstadoTema.FondoColor = Color.Transparent
    '    lblEstadoTema.TextoColor = ThemeManagerWUI.ColorTextoBase
    '    lblEstadoTema.BorderRadius = 6
    '    lblEstadoTema.Location = New Point(30, 420)
    '    Me.Controls.Add(lblEstadoTema)

    '    ' TabControl
    '    tabControles.Size = New Size(740, 340)
    '    tabControles.Location = New Point(30, 70)
    '    Me.Controls.Add(tabControles)
    'End Sub

    'Private Sub CargarTabs()
    '    ' Tab Entrada
    '    Dim tabEntrada As New TabPage("Entrada")
    '    Dim txtBox1 As New TextBoxWUI() With {.Location = New Point(20, 30), .Size = New Size(200, 30), .TituloSuperior = "Nombre"}
    '    Dim txtIcono As New TextBoxIconWUI() With {.Location = New Point(240, 30), .Size = New Size(200, 30)}
    '    Dim txtFecha As New MaskedTextBoxFechaWUI() With {.Location = New Point(460, 30), .Size = New Size(200, 30)}
    '    tabEntrada.Controls.AddRange({txtBox1, txtIcono, txtFecha})
    '    tabControles.TabPages.Add(tabEntrada)

    '    ' Tab Selección
    '    Dim tabSeleccion As New TabPage("Selección")
    '    Dim combo1 As New ComboBoxWUI() With {.Location = New Point(20, 30), .Size = New Size(200, 30)}
    '    combo1.Items.AddRange({"Opción A", "Opción B", "Opción C"})
    '    combo1.SelectedIndex = 0
    '    Dim optBtn As New OptionButtonWUI() With {.Location = New Point(240, 30), .Size = New Size(150, 30)}
    '    Dim cmdBtn As New CommandButtonWUI() With {.Location = New Point(410, 30), .Size = New Size(150, 35), .BotonTexto = "Ejecutar"}
    '    Dim btnRipple As New ButtonWUI() With {.Location = New Point(580, 30), .Size = New Size(150, 35), .BotonTexto = "Aceptar"}
    '    tabSeleccion.Controls.AddRange({combo1, optBtn, cmdBtn, btnRipple})
    '    tabControles.TabPages.Add(tabSeleccion)

    '    ' Tab Visualización
    '    Dim tabVisual As New TabPage("Visuales")
    '    Dim lbl1 As New LabelWUI() With {.Location = New Point(20, 30), .Texto = "Etiqueta UI Demo", .BorderRadius = 10}
    '    tabVisual.Controls.Add(lbl1)
    '    tabControles.TabPages.Add(tabVisual)

    '    ' Tab Utilitarios
    '    Dim tabUtilitarios As New TabPage("Utilitarios")
    '    Dim lblUtils As New LabelWUI() With {.Location = New Point(20, 30), .Texto = "Aquí irán los controles utilitarios WilmerUI"}
    '    tabUtilitarios.Controls.Add(lblUtils)
    '    tabControles.TabPages.Add(tabUtilitarios)
    'End Sub

    'Private Sub AplicarTemaVisual()
    '    Me.BackColor = ThemeManagerWUI.ColorFondoBase
    '    tabControles.BackColor = ThemeManagerWUI.ColorFondoBase
    '    lblEstadoTema.Texto = "Tema actual: " & ThemeManagerWUI.TemaActual.ToString()
    '    lblEstadoTema.TextoColor = ThemeManagerWUI.ColorTextoBase

    '    ThemeManagerWUI.ActualizarControles(Me)
    'End Sub



    'MODO DE USO 

    ' Guardar preferencia
    'My.Settings.TemaWUI = "Oscuro"
    'My.Settings.Save()

    '' Recuperar al iniciar
    'Dim tema = My.Settings.TemaWUI
    'If tema = "Oscuro" Then
    '    ThemeManagerWUI.CambiarTema(TemaVisual.Oscuro)
    'Else
    '    ThemeManagerWUI.CambiarTema(TemaVisual.Claro)
    'End If


End Class