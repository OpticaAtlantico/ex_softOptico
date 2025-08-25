Public Class ucProductos
    Inherits UserControl

    Public Sub New()
        Me.InitializeComponent()
        Me.Dock = DockStyle.Fill
        Me.AutoSize = False
        Me.Margin = New Padding(0)
        Me.Padding = New Padding(0)
        Me.BackColor = Color.WhiteSmoke
        ConstruirLayoutOrbital()
    End Sub

    Private Sub ConstruirLayoutOrbital()
        Dim layout As New TableLayoutPanel With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 4,
            .AutoSize = False,
            .Margin = New Padding(0),
            .Padding = New Padding(10),
            .BackColor = Color.Transparent
        }

        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 150)) ' Etiquetas
        layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))  ' Controles

        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 60))

        Me.Controls.Add(layout)

        Dim lblNombre As New Label With {.Text = "Nombre:", .TextAlign = ContentAlignment.MiddleRight, .Dock = DockStyle.Fill}
        Dim txtNombre As New TextBox With {.Dock = DockStyle.Fill}

        Dim lblPrecio As New Label With {.Text = "Precio:", .TextAlign = ContentAlignment.MiddleRight, .Dock = DockStyle.Fill}
        Dim txtPrecio As New TextBox With {.Dock = DockStyle.Fill}

        Dim lblStock As New Label With {.Text = "Stock:", .TextAlign = ContentAlignment.MiddleRight, .Dock = DockStyle.Fill}
        Dim txtStock As New TextBox With {.Dock = DockStyle.Fill}

        Dim btnSiguiente As New Button With {.Text = "Siguiente", .Dock = DockStyle.Right, .Width = 120}
        AddHandler btnSiguiente.Click, AddressOf btnSiguiente_Click

        layout.Controls.Add(lblNombre, 0, 0)
        layout.Controls.Add(txtNombre, 1, 0)
        layout.Controls.Add(lblPrecio, 0, 1)
        layout.Controls.Add(txtPrecio, 1, 1)
        layout.Controls.Add(lblStock, 0, 2)
        layout.Controls.Add(txtStock, 1, 2)
        layout.Controls.Add(btnSiguiente, 1, 3)
    End Sub

    Public Property TabPanelRef As TabPanelUI

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        If TabPanelRef IsNot Nothing Then
            TabPanelRef.AvanzarPestaña()
        End If
    End Sub


    'Public Function Validar() As Boolean
    '    ' Validación básica
    '    Return Not String.IsNullOrWhiteSpace(txtNombre.Text)
    'End Function
End Class
