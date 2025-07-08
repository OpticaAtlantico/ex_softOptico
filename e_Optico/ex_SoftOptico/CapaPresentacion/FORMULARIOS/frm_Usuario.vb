Imports MaterialSkin3
Imports MaterialSkin3.Controls

Public Class frm_Usuario
    Inherits MaterialForm

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)

        ' Botón Material
        Dim btn As New MaterialButton()
        btn.Text = "Aceptar"
        btn.Location = New Point(50, 100)
        Me.Controls.Add(btn)

        ' Caja de texto Material
        Dim txt As New MaterialTextBox2()
        txt.Hint = "Ingrese su nombre"
        txt.Location = New Point(50, 50)
        txt.Size = New Size(250, 48)
        Me.Controls.Add(txt)
    End Sub
End Class