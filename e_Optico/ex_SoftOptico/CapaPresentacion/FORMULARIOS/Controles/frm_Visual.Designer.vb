<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Visual
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        CommandButtonui1 = New CommandButtonUI()
        SuspendLayout()
        ' 
        ' CommandButtonui1
        ' 
        CommandButtonui1.AnimarHover = True
        CommandButtonui1.BackColor = SystemColors.MenuHighlight
        CommandButtonui1.ColorBase = Color.IndianRed
        CommandButtonui1.ColorHover = Color.PaleTurquoise
        CommandButtonui1.ColorTexto = Color.White
        CommandButtonui1.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CommandButtonui1.ForeColor = SystemColors.ActiveCaption
        CommandButtonui1.Icono = FontAwesome.Sharp.IconChar.VolumeUp
        CommandButtonui1.Location = New Point(348, 60)
        CommandButtonui1.Name = "CommandButtonui1"
        CommandButtonui1.RadioBorde = 16
        CommandButtonui1.Size = New Size(125, 48)
        CommandButtonui1.TabIndex = 0
        CommandButtonui1.Text = "CommandButtonui1"
        CommandButtonui1.Texto = "Aceptar"
        ' 
        ' frm_Visual
        ' 
        BackColor = SystemColors.MenuHighlight
        ClientSize = New Size(758, 438)
        Controls.Add(CommandButtonui1)
        Name = "frm_Visual"
        Text = "Coliflor"
        ResumeLayout(False)

    End Sub

    Friend WithEvents CommandButtonui1 As CommandButtonUI

End Class
