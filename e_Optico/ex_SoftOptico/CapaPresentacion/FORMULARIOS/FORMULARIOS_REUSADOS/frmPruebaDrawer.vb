Imports System.Drawing
Imports System.Windows.Forms
Imports FontAwesome.Sharp

' Form principal de ejemplo que integra DrawerControlUI
Public Class frmPruebaDrawer
    Inherits Form

    Private drawer As DrawerControlUI
    Private PanelContenedor As New Panel()
    Private btnToggle As IconButton
    Private formularioActivo As Form = Nothing

    Public Sub New()
        Me.Text = "Sistema Principal"
        Me.Size = New Size(1200, 700)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Panel contenedor (agregarlo ANTES o DESPUES del drawer: se agrega DESPUÉS para que Drawer quede a la izquierda)
        PanelContenedor.Dock = DockStyle.Fill
        PanelContenedor.BackColor = Color.WhiteSmoke
        Me.Controls.Add(PanelContenedor)

        ' Drawer lateral (agregar después -> quedará a la izquierda con Dock.Left)
        drawer = New DrawerControlUI()
        drawer.Dock = DockStyle.Left
        Me.Controls.Add(drawer)
        drawer.BringToFront()
        AddHandler drawer.OpcionSeleccionada, AddressOf Drawer_OpcionSeleccionada

        ' Botón toggle externo (arriba-izquierda). Colócalo donde prefieras en tu UI. Aquí lo anclamos.
        btnToggle = New IconButton() With {
            .IconChar = IconChar.Bars,
            .IconColor = Color.Black,
            .IconSize = 20,
            .Size = New Size(42, 42),
            .Location = New Point(drawer.Right - 42, 8),
            .FlatStyle = FlatStyle.Flat
        }
        btnToggle.FlatAppearance.BorderSize = 0
        AddHandler btnToggle.Click, Sub() drawer.ToggleDrawer()
        Me.Controls.Add(btnToggle)
        'btnToggle.BringToFront()

        ' Ejemplo: si quieres agregar opciones desde aquí (opcional), puedes:
        ' drawer.AgregarOpcion("MiModulo", IconChar.Gears, New List(Of String) From {"Sub1","Sub2"})
    End Sub

    ' Abre un formulario hijo dentro del PanelContenedor (solo uno a la vez)
    Private Sub AbrirFormularioHijo(childForm As Form)
        If formularioActivo IsNot Nothing Then
            formularioActivo.Close()
        End If

        formularioActivo = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        PanelContenedor.Controls.Clear()
        PanelContenedor.Controls.Add(childForm)
        childForm.BringToFront()
        childForm.Show()
    End Sub

    ' Manejo del evento del Drawer
    Private Sub Drawer_OpcionSeleccionada(opcion As String)
        ' Aquí mapear opciones a formularios reales, si no existen muestra message
        Select Case opcion
            Case "Gestión de Empleados"
                Try
                    AbrirFormularioHijo(New frmEmpleado())
                Catch ex As Exception
                    MessageBox.Show("Abrir: " & opcion)
                End Try
            Case "Horarios"
                MessageBox.Show("Abrir: " & opcion)
            Case "Nueva Compra"
                Try
                    AbrirFormularioHijo(New frmCompras())
                Catch ex As Exception
                    MessageBox.Show("Abrir: " & opcion)
                End Try
            Case Else
                MessageBox.Show("Seleccionaste: " & opcion)
        End Select
    End Sub

End Class


