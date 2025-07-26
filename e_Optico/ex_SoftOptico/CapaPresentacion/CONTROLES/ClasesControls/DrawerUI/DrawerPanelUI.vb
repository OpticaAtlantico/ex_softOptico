Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
Imports FontAwesome.Sharp

<Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", GetType(IDesigner))>
<DefaultEvent("Toggled")>
Public Class DrawerPanelUI
    Inherits Panel

    ' Timer para animación
    Private animationTimer As Timer
    Private animator As Timer
    Private isExpanding As Boolean
    ' Ancho final cuando está abierto
    Public Property DrawerWidth As Integer = 250

    ' Paso e intervalo
    Public Property AnimationStep As Integer = 20
    Public Property AnimationInterval As Integer = 15

    Private _isOpen As Boolean
    Public ReadOnly Property IsOpen As Boolean
        Get
            Return _isOpen
        End Get
    End Property

    Public Event Toggled As EventHandler

    Public Sub New()
        MyBase.New()

        ' Detectar modo diseño
        Dim inDesign = (LicenseManager.UsageMode = LicenseUsageMode.Designtime)

        ' En diseño: ancho fijo, visible
        If inDesign Then
            Me.Width = DrawerWidth
            Me.Visible = True
        Else
            Me.Width = 0
            Me.Visible = False
        End If

        Me.Dock = DockStyle.Right
        Me.AutoScroll = True
        Me.BackColor = SystemColors.ControlLight

        animationTimer = New Timer() With {.Interval = AnimationInterval}
        AddHandler animationTimer.Tick, AddressOf OnAnimationTick
    End Sub

    Public Sub Open()
        If _isOpen Or animationTimer.Enabled Then Return
        animationTimer.Start()
    End Sub

    Public Sub Close()
        If Not _isOpen Or animationTimer.Enabled Then Return
        animationTimer.Start()
    End Sub

    Private Sub OnAnimationTick(sender As Object, e As EventArgs)
        Dim target = If(_isOpen, 0, DrawerWidth)
        Dim delta = If(_isOpen, -AnimationStep, AnimationStep)
        Me.Width = Math.Min(Math.Max(Me.Width + delta, 0), DrawerWidth)

        If Me.Width = target Then
            animationTimer.Stop()
            _isOpen = (target > 0)
            RaiseEvent Toggled(Me, EventArgs.Empty)
            If Not _isOpen Then Me.Visible = False
        End If
    End Sub

    Public Sub RenderItems(items As List(Of DrawerItem))
        Me.Controls.Clear()
        Dim y As Integer = 10

        For Each itm In items
            ' Crea copia local para la lambda
            Dim currentItem = itm

            Dim btn As New IconButton() With {
            .IconChar = currentItem.Icon,
            .IconColor = ThemeManagerUI.ForeColor,
            .IconSize = 24,
            .Text = "  " & currentItem.Text,
            .TextAlign = ContentAlignment.MiddleLeft,
            .TextImageRelation = TextImageRelation.ImageBeforeText,
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .ForeColor = ThemeManagerUI.ForeColor,
            .BackColor = Color.Transparent,
            .FlatStyle = FlatStyle.Flat,
            .Width = Me.ClientSize.Width - 20,
            .Height = Forty(),
            .Location = New Point(10, y)
        }
            btn.FlatAppearance.BorderSize = 0

            AddHandler btn.Click, Sub(sender As Object, e As EventArgs)
                                      currentItem.Callback.Invoke()
                                      Me.CloseAnimated()
                                  End Sub

            Me.Controls.Add(btn)
            y += btn.Height + 5
        Next
    End Sub


    ' Abre con animación
    Public Sub OpenAnimated()
        If Me.Visible Then Return
        Me.Width = 0
        Me.Visible = True
        isExpanding = True
        animator.Start()
    End Sub

    ' Cierra con animación
    Public Sub CloseAnimated()
        If Not Me.Visible Then Return
        isExpanding = False
        animator.Start()
    End Sub

    '' Altura estándar para botones
    Private Function Forty() As Integer
        Return 40
    End Function


    'Inherits Panel

    '' Timer para animación
    'Private animationTimer As Timer

    '' Estados y valores de animación
    'Private _isOpen As Boolean = False
    'Private targetWidth As Integer
    'Private initialWidth As Integer

    'Private animator As Timer
    'Private isExpanding As Boolean

    'Public Property ExpandedWidth As Integer = 200

    '' Ancho final cuando está abierto
    'Public Property DrawerWidth As Integer = 250

    '' Intervalo y paso de animación
    'Public Property AnimationInterval As Integer = 15
    'Public Property AnimationStep As Integer = 20

    '' Indica si el drawer está abierto
    'Public Property IsOpen As Boolean
    '    Get
    '        Return _isOpen
    '    End Get
    '    Set(value As Boolean)
    '        If value Then
    '            Open()
    '        Else
    '            Close()
    '        End If
    '    End Set
    'End Property

    'Public Sub New()
    '    MyBase.New()

    '    ' Estado inicial cerrado
    '    Me.Width = 0
    '    Me.Dock = DockStyle.Right
    '    Me.AutoScroll = True
    '    Me.BackColor = SystemColors.ControlLight

    '    ' Configurar el timer
    '    animationTimer = New Timer()
    '    animationTimer.Interval = AnimationInterval
    '    AddHandler animationTimer.Tick, AddressOf OnAnimationTick
    'End Sub

    '' Lanza la animación de apertura
    'Public Sub Open()
    '    If _isOpen OrElse animationTimer.Enabled Then Return
    '    initialWidth = Me.Width
    '    targetWidth = DrawerWidth
    '    animationTimer.Start()
    'End Sub

    '' Lanza la animación de cierre
    'Public Sub Close()
    '    If Not _isOpen OrElse animationTimer.Enabled Then Return
    '    initialWidth = Me.Width
    '    targetWidth = 0
    '    animationTimer.Start()
    'End Sub

    '' Manejador de tick: ajusta ancho hasta alcanzar targetWidth
    'Private Sub OnAnimationTick(sender As Object, e As EventArgs)
    '    Dim newWidth As Integer = Me.Width

    '    If _isOpen Then
    '        ' Cerrando
    '        newWidth = Math.Max(Me.Width - AnimationStep, targetWidth)
    '    Else
    '        ' Abriendo
    '        newWidth = Math.Min(Me.Width + AnimationStep, targetWidth)
    '    End If

    '    Me.Width = newWidth

    '    ' Cuando llega al destino, detiene animación y cambia estado
    '    If newWidth = targetWidth Then
    '        animationTimer.Stop()
    '        _isOpen = (targetWidth > 0)
    '        RaiseEvent Toggled(Me, EventArgs.Empty)
    '    End If
    'End Sub

    'Public Sub RenderItems(items As List(Of DrawerItem))
    '    Me.Controls.Clear()
    '    Dim y As Integer = 10

    '    For Each itm In items
    '        Dim btn As New IconButton() With {
    '            .IconChar = itm.Icon,
    '            .IconColor = ThemeManagerUI.ForeColor,
    '            .IconSize = 24,
    '            .Text = "  " & itm.Label,
    '            .TextAlign = ContentAlignment.MiddleLeft,
    '            .TextImageRelation = TextImageRelation.ImageBeforeText,
    '            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
    '            .ForeColor = ThemeManagerUI.ForeColor,
    '            .BackColor = Color.Transparent,
    '            .FlatStyle = FlatStyle.Flat,
    '            .Width = Me.ClientSize.Width - 20,
    '            .Height = Forty(),
    '            .Location = New Drawing.Point(10, y)
    '        }
    '        btn.FlatAppearance.BorderSize = 0

    '        AddHandler btn.Click, Sub()
    '                                  itm.Callback.Invoke()
    '                                  CloseAnimated()
    '                              End Sub

    '        Me.Controls.Add(btn)
    '        y += btn.Height + 5
    '    Next
    'End Sub

    '' Abre con animación
    'Public Sub OpenAnimated()
    '    If Me.Visible Then Return
    '    Me.Width = 0
    '    Me.Visible = True
    '    isExpanding = True
    '    animator.Start()
    'End Sub

    '' Cierra con animación
    'Public Sub CloseAnimated()
    '    If Not Me.Visible Then Return
    '    isExpanding = False
    '    animator.Start()
    'End Sub

    'Private Sub OnAnimateTick(sender As Object, e As EventArgs)
    '    If isExpanding Then
    '        Me.Width += AnimationStep
    '        If Me.Width >= ExpandedWidth Then
    '            animator.Stop()
    '            Me.Width = ExpandedWidth
    '        End If
    '    Else
    '        Me.Width -= AnimationStep
    '        If Me.Width <= 0 Then
    '            animator.Stop()
    '            Me.Visible = False
    '            Me.Width = ExpandedWidth
    '        End If
    '    End If
    'End Sub

    '' Altura estándar para botones
    'Private Function Forty() As Integer
    '    Return 40
    'End Function

    '' Evento opcional para reaccionar al cambio de estado
    'Public Event Toggled As EventHandler
End Class









'Imports System.Drawing
'Imports System.Windows.Forms
'Imports DocumentFormat.OpenXml.Drawing
'Imports FontAwesome.Sharp

'' UserControl reusable que maneja renderizado y animación del drawer
'Public Class DrawerPanelUI
'    Inherits UserControl

'    Private animator As Timer
'    Private isExpanding As Boolean

'    Public Property ExpandedWidth As Integer = 200
'    Public Property AnimationStep As Integer = 20
'    Public Property AnimationInterval As Integer = 15

'    Public Sub New()
'        Me.Dock = DockStyle.Left
'        Me.Width = ExpandedWidth
'        Me.Visible = False
'        Me.BackColor = ThemeManagerUI.BackColor
'        Me.DoubleBuffered = True

'        animator = New Timer() With {.Interval = AnimationInterval}
'        AddHandler animator.Tick, AddressOf OnAnimateTick
'    End Sub

'    ' Dibuja los botones con iconos FontAwesome
'    Public Sub RenderItems(items As List(Of DrawerItem))
'        Me.Controls.Clear()
'        Dim y As Integer = 10

'        For Each itm In items
'            Dim btn As New IconButton() With {
'                .IconChar = itm.Icon,
'                .IconColor = ThemeManagerUI.ForeColor,
'                .IconSize = 24,
'                .Text = "  " & itm.Label,
'                .TextAlign = ContentAlignment.MiddleLeft,
'                .TextImageRelation = TextImageRelation.ImageBeforeText,
'                .Font = New Font("Segoe UI", 10, FontStyle.Regular),
'                .ForeColor = ThemeManagerUI.ForeColor,
'                .BackColor = Color.Transparent,
'                .FlatStyle = FlatStyle.Flat,
'                .Width = Me.ClientSize.Width - 20,
'                .Height = Forty(),
'                .Location = New Drawing.Point(10, y)
'            }
'            btn.FlatAppearance.BorderSize = 0

'            AddHandler btn.Click, Sub()
'                                      itm.Callback.Invoke()
'                                      CloseAnimated()
'                                  End Sub

'            Me.Controls.Add(btn)
'            y += btn.Height + 5
'        Next
'    End Sub

'    ' Abre con animación
'    Public Sub OpenAnimated()
'        If Me.Visible Then Return
'        Me.Width = 0
'        Me.Visible = True
'        isExpanding = True
'        animator.Start()
'    End Sub

'    ' Cierra con animación
'    Public Sub CloseAnimated()
'        If Not Me.Visible Then Return
'        isExpanding = False
'        animator.Start()
'    End Sub

'    Private Sub OnAnimateTick(sender As Object, e As EventArgs)
'        If isExpanding Then
'            Me.Width += AnimationStep
'            If Me.Width >= ExpandedWidth Then
'                animator.Stop()
'                Me.Width = ExpandedWidth
'            End If
'        Else
'            Me.Width -= AnimationStep
'            If Me.Width <= 0 Then
'                animator.Stop()
'                Me.Visible = False
'                Me.Width = ExpandedWidth
'            End If
'        End If
'    End Sub

'    ' Altura estándar para botones
'    Private Function Forty() As Integer
'        Return 40
'    End Function
'End Class
