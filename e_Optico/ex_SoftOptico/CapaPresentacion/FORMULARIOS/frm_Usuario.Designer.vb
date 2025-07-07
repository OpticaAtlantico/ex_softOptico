<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Usuario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        men_Titulo = New MenuStrip()
        txt_Titulo = New ToolStripTextBox()
        pan_contenedor = New Panel()
        men_Titulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' men_Titulo
        ' 
        men_Titulo.AutoSize = False
        men_Titulo.BackColor = Color.FromArgb(CByte(46), CByte(59), CByte(104))
        men_Titulo.Items.AddRange(New ToolStripItem() {txt_Titulo})
        men_Titulo.Location = New Point(0, 0)
        men_Titulo.Name = "men_Titulo"
        men_Titulo.RightToLeft = RightToLeft.Yes
        men_Titulo.Size = New Size(1370, 54)
        men_Titulo.TabIndex = 1
        men_Titulo.Text = "MenuStrip2"
        ' 
        ' txt_Titulo
        ' 
        txt_Titulo.Alignment = ToolStripItemAlignment.Right
        txt_Titulo.AutoSize = False
        txt_Titulo.BackColor = Color.FromArgb(CByte(46), CByte(59), CByte(104))
        txt_Titulo.BorderStyle = BorderStyle.None
        txt_Titulo.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        txt_Titulo.ForeColor = Color.White
        txt_Titulo.Name = "txt_Titulo"
        txt_Titulo.ReadOnly = True
        txt_Titulo.Size = New Size(200, 25)
        txt_Titulo.Text = "SISTEMA DE VENTAS"
        ' 
        ' pan_contenedor
        ' 
        pan_contenedor.Dock = DockStyle.Fill
        pan_contenedor.Location = New Point(0, 54)
        pan_contenedor.Name = "pan_contenedor"
        pan_contenedor.Size = New Size(1370, 695)
        pan_contenedor.TabIndex = 2
        ' 
        ' frm_Inicio
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1370, 749)
        Controls.Add(pan_contenedor)
        Controls.Add(men_Titulo)
        Name = "frm_Inicio"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sistema Administrativo"
        TopMost = True
        men_Titulo.ResumeLayout(False)
        men_Titulo.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents men_Titulo As MenuStrip
    Friend WithEvents txt_Titulo As ToolStripTextBox

    Private Sub frm_Inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents pan_contenedor As Panel
End Class
