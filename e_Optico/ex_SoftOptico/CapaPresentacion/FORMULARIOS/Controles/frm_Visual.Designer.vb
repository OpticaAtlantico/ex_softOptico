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
        Labelwui1 = New LabelWUI()
        CLabelui1 = New cLabelUI()
        SuspendLayout()
        ' 
        ' Labelwui1
        ' 
        Labelwui1.AutoajustarAncho = True
        Labelwui1.BackColor = Color.Transparent
        Labelwui1.BorderRadius = 8
        Labelwui1.ColorIcono = Color.White
        Labelwui1.EstiloFuente = FontStyle.Regular
        Labelwui1.FondoColor = Color.Gainsboro
        Labelwui1.Location = New Point(67, 12)
        Labelwui1.MostrarIconoUnicode = ""
        Labelwui1.Name = "Labelwui1"
        Labelwui1.Size = New Size(130, 33)
        Labelwui1.TabIndex = 0
        Labelwui1.TamañoFuente = 12
        Labelwui1.Texto = "Etiqueta"
        Labelwui1.TextoColor = Color.Black
        ' 
        ' CLabelui1
        ' 
        CLabelui1.BackColor = Color.Transparent
        CLabelui1.BorderRadius = 10
        CLabelui1.FondoColor = Color.LightGray
        CLabelui1.HoverColor = Color.DodgerBlue
        CLabelui1.Icono = FontAwesome.Sharp.IconChar.XmarkCircle
        CLabelui1.IconoColor = Color.Black
        CLabelui1.Location = New Point(61, 101)
        CLabelui1.Name = "CLabelui1"
        CLabelui1.Size = New Size(205, 42)
        CLabelui1.TabIndex = 1
        CLabelui1.Texto = "Etiqueta"
        CLabelui1.TextoColor = Color.Black
        ' 
        ' frm_Visual
        ' 
        BackColor = SystemColors.WindowFrame
        ClientSize = New Size(758, 438)
        Controls.Add(CLabelui1)
        Controls.Add(Labelwui1)
        Name = "frm_Visual"
        ResumeLayout(False)

    End Sub

    Friend WithEvents Labelwui1 As LabelWUI
    Friend WithEvents CLabelui1 As cLabelUI


End Class
