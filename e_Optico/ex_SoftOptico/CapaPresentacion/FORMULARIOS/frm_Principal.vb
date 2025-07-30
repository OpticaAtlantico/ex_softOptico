Imports System.Runtime.InteropServices
Imports DocumentFormat.OpenXml.Presentation
Imports FontAwesome.Sharp
Imports Microsoft.Windows.Themes
Imports CapaEntidad
Imports ClosedXML.Excel

Public Class frm_Principal
    Private drawerAbierto As Boolean = False
    Private drawerControl As New DrawerControl()

    Private DrawerExpandido As Boolean = True
    Private DrawerObjetivoWidth As Integer = 152
    Private DrawerVelocidad As Integer = 30

    'Para procedimeintos de botones 
    Private currentButton As Button
    Private activeForms As Form ' Formulario activo
    Dim loginmodelo = listLogin

#Region "CONSTRUCTOR"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.

        InitializeComponent()
        Me.DoubleBuffered = True

        pnlDrawer.Controls.Add(drawerControl)
        pnlDrawer.Width = 160
        pnlDrawer.BackColor = Color.Azure
        pnlDrawer.Visible = False

        With Me
            btnSalirFrmHijo.Visible = False
            .Text = String.Empty
            .ControlBox = False
            .MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
        End With
        WindowState = FormWindowState.Maximized
    End Sub



#End Region

#Region "DRAG FORM"
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
    End Sub
#End Region

#Region "CONTROLES"
    Private Sub btnSalirFrmHijo_Click(sender As Object, e As EventArgs) Handles btnSalirFrmHijo.Click
        If (Not (activeForms) Is Nothing) Then
            activeForms.Close()
        End If
        Reset()
    End Sub
    Private Sub pnlEncabezado_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlEncabezado.MouseDown
        'Funcion para permitir mover el formulario por todas partes
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub AgregarBotonMenu(nombre As String, icono As IconChar, evento As EventHandler)
        Dim btn As New IconButton With {
            .Text = "",
            .IconChar = icono,
            .IconColor = Color.WhiteSmoke,
            .Dock = DockStyle.Top,
            .Height = 50,
            .FlatStyle = FlatStyle.Flat,
            .TextImageRelation = TextImageRelation.ImageAboveText,
            .IconSize = 45,
            .ForeColor = Color.WhiteSmoke
        }
        btn.FlatAppearance.BorderSize = 0
        AddHandler btn.Click, evento
        pnlMenu.Controls.Add(btn)

    End Sub

    Private Sub BotonMenuEmpleados()
        ' Crear las opciones de manera clara, evitando CType de lambdas
        Dim opciones As New List(Of Tuple(Of String, IconChar, EventHandler))

        Dim handlerReporte As New EventHandler(AddressOf SubReportes_Click)
        opciones.Add(Tuple.Create("Ver Reporte", IconChar.ListCheck, handlerReporte))

        Dim handlerConsultar As New EventHandler(AddressOf SubConsultar_Click)
        opciones.Add(Tuple.Create("Lista de Consulta", IconChar.ListNumeric, handlerConsultar))

        Dim handlerEliminar As New EventHandler(AddressOf SubEliminar_Click)
        opciones.Add(Tuple.Create("Eliminar Empleado", IconChar.TrashArrowUp, handlerEliminar))

        Dim handlerEditar As New EventHandler(AddressOf SubEditar_Click)
        opciones.Add(Tuple.Create("Actualizar Datos", IconChar.FolderOpen, handlerEditar))

        Dim handlerNuevo As New EventHandler(AddressOf SubNuevo_Click)
        opciones.Add(Tuple.Create("Nuevo Empleado", IconChar.Save, handlerNuevo))

        ' Cargar en Drawer
        drawerControl.CargarOpciones(opciones)
        pnlDrawer.Visible = True
        If pnlDrawer.Width <= 0 Then
            DrawerTimer.Start()
        End If
        drawerAbierto = True
    End Sub

#End Region

#Region "EVENTOS"

    Private Sub SubNuevo_Click(sender As Object, e As EventArgs)
        Dim abierto As Boolean = Application.OpenForms().OfType(Of frmNuevoEmpleado).Any()

        If Not abierto Then
            OpenChildForm(New frmNuevoEmpleado, sender)
            EfectoBotonInActivo()
        End If

    End Sub

    Private Sub SubEditar_Click(sender As Object, e As EventArgs)
        'MostrarContenido(New AbrirControl())
        DrawerTimer.Start()
    End Sub

    Private Sub SubEliminar_Click(sender As Object, e As EventArgs)
        'MostrarContenido(frm)
        DrawerTimer.Start()
    End Sub

    Private Sub SubConsultar_Click(sender As Object, e As EventArgs)
        'ostrarContenido(New CopiarControl())
        DrawerTimer.Start()
    End Sub

    Private Sub SubReportes_Click(sender As Object, e As EventArgs)
        'MostrarContenido(New PegarControl())
        DrawerTimer.Start()
    End Sub

#End Region

#Region "ACCIONES"

    Private Sub DrawerTimer_Tick(sender As Object, e As EventArgs) Handles DrawerTimer.Tick
        If Not DrawerExpandido Then
            ' Expandiendo
            If pnlDrawer.Width < DrawerObjetivoWidth Then
                pnlDrawer.Visible = True
                pnlDrawer.Width += DrawerVelocidad
            Else
                DrawerTimer.Stop()
                DrawerExpandido = True
            End If
        Else
            ' Contrayendo
            If pnlDrawer.Width > 0 Then
                pnlDrawer.Width -= DrawerVelocidad
            Else
                DrawerTimer.Stop()
                pnlDrawer.Visible = False
                DrawerExpandido = False
            End If
        End If
    End Sub

    Private Sub btnMostrarMenu_Click(sender As Object, e As EventArgs) Handles btnMostrarMenu.Click
        DrawerTimer.Start()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            listLogin.Clear() ' Limpiar la lista de usuarios
            Me.Close() ' Cerrar el formulario principal
            'Application.Exit()
        End If
    End Sub

    Private Sub btnMaximizar_Click(sender As Object, e As EventArgs) Handles btnMaximizar.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btnminimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub


#End Region

#Region "PROCEDIMIENTO"
    Private Sub EfectoBotonActivo(sender As Object)
        EfectoBotonInActivo()
        If sender IsNot Nothing Then
            sender.BackColor = Color.White
            sender.ForeColor = Color.Black
            sender.IconColor = Color.Black
        End If
    End Sub

    Private Sub EfectoBotonInActivo()
        For Each btn In pnlMenu.Controls
            If TypeOf btn Is IconButton Then
                If btn IsNot currentButton Then
                    If CType(btn, IconButton).IconColor <> Color.WhiteSmoke Then
                        CType(btn, IconButton).IconColor = Color.WhiteSmoke
                        CType(btn, IconButton).ForeColor = Color.WhiteSmoke
                        CType(btn, IconButton).BackColor = Color.FromArgb(51, 51, 76)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub ActivateButton()
        btnSalirFrmHijo.Visible = True
    End Sub
    Private Sub DisableButton()
        btnSalirFrmHijo.Visible = False
    End Sub
    Private Sub OpenChildForm(childForm As Form, btnSender As Object)
        If activeForms IsNot Nothing Then activeForms.Close()
        ActivateButton()
        activeForms = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Me.pnlContenedor.Controls.Add(childForm)
        Me.pnlContenedor.Tag = childForm
        childForm.BringToFront()
        DrawerExpandido = True
        DrawerTimer.Start()
        childForm.Show()

    End Sub
    Private Sub Reset()
        currentButton = New Button()
        DisableButton()
    End Sub

    Private Sub MostrarContenido(frm As Form)
        'pnlContenedor.Controls.Clear()
        'control.Dock = DockStyle.Fill
        'pnlContenedor.Controls.Add(control)
    End Sub


#End Region


    Private Sub btnInventario_Click(sender As Object, e As EventArgs) Handles btnInventario.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnCompra_Click(sender As Object, e As EventArgs) Handles btnCompra.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnEmpleado_Click(sender As Object, e As EventArgs) Handles btnEmpleado.Click
        BotonMenuEmpleados()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnComision_Click(sender As Object, e As EventArgs) Handles btnComision.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnNomina_Click(sender As Object, e As EventArgs) Handles btnNomina.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnAnalisis_Click(sender As Object, e As EventArgs) Handles btnAnalisis.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub

    Private Sub btnAjustes_Click(sender As Object, e As EventArgs) Handles btnAjustes.Click
        'BotonMenuInventario()
        EfectoBotonActivo(sender)
    End Sub
End Class