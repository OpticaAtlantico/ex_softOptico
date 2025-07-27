Imports System.Windows.Forms
Imports System.Reflection

Public Class DrawerAnimatorOrbital

    Public Event DrawerOpened As EventHandler
    Public Event DrawerClosed As EventHandler

    Private ReadOnly panelTarget As Panel
    Private ReadOnly finalWidth As Integer
    Private ReadOnly durationMs As Integer
    Private ReadOnly stepsCount As Integer
    Private ReadOnly timer As Timer

    Private initWidth As Integer
    Private currentStep As Integer
    Private increment As Integer
    Private isOpening As Boolean

    Public Sub New(target As Panel, width As Integer, duration As Integer, steps As Integer)
        panelTarget = target
        finalWidth = width
        durationMs = duration
        stepsCount = steps

        timer = New Timer() With {
            .Interval = Math.Max(1, durationMs \ stepsCount)
        }
        AddHandler timer.Tick, AddressOf OnTick

        ' Evita flicker
        Dim prop = panelTarget.GetType() _
                       .GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        prop.SetValue(panelTarget, True, Nothing)
    End Sub

    Public Sub Toggle()
        If panelTarget.Width = 0 Then Show() Else Hide()
    End Sub

    Public Sub Show()
        isOpening = True
        initWidth = 0
        currentStep = 0
        increment = (finalWidth - initWidth) \ stepsCount
        panelTarget.Width = initWidth
        timer.Start()
    End Sub

    Public Sub Hide()
        isOpening = False
        initWidth = panelTarget.Width
        currentStep = 0
        increment = initWidth \ stepsCount
        timer.Start()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        currentStep += 1

        If isOpening Then
            panelTarget.Width = Math.Min(finalWidth, initWidth + increment * currentStep)
            If panelTarget.Width >= finalWidth Then
                timer.Stop()
                RaiseEvent DrawerOpened(Me, EventArgs.Empty)
            End If
        Else
            panelTarget.Width = Math.Max(0, initWidth - increment * currentStep)
            If panelTarget.Width <= 0 Then
                timer.Stop()
                RaiseEvent DrawerClosed(Me, EventArgs.Empty)
            End If
        End If
    End Sub

End Class














'Imports System.Windows.Forms
'Imports System.Reflection

'Public Class DrawerAnimatorOrbital

'    Public Event DrawerOpened As EventHandler
'    Public Event DrawerClosed As EventHandler

'    Private ReadOnly panelTarget As Panel
'    Private ReadOnly durationMs As Integer
'    Private ReadOnly stepsCount As Integer
'    Private ReadOnly timer As Timer

'    Private initWidth As Integer
'    Private finalWidth As Integer
'    Private currentStep As Integer
'    Private increment As Integer
'    Private isAnimating As Boolean

'    Public Sub New(target As Panel, width As Integer, duration As Integer, steps As Integer)
'        panelTarget = target
'        finalWidth = width
'        durationMs = duration
'        stepsCount = steps

'        timer = New Timer()
'        timer.Interval = Math.Max(1, durationMs \ stepsCount)
'        AddHandler timer.Tick, AddressOf Timer_Tick

'        ' Activa double buffering para menos flicker
'        Dim pi = panelTarget.GetType().
'                 GetProperty("DoubleBuffered", BindingFlags.NonPublic Or BindingFlags.Instance)
'        pi.SetValue(panelTarget, True, Nothing)
'    End Sub

'    Public Sub Toggle()
'        If isAnimating Then Return
'        If panelTarget.Width = 0 Then Show() Else Hide()
'    End Sub

'    Public Sub Show()
'        If isAnimating Then Return
'        initWidth = finalWidth
'        currentStep = 0
'        increment = CInt((finalWidth - initWidth) / stepsCount)
'        panelTarget.Width = initWidth
'        isAnimating = True
'        timer.Start()
'    End Sub

'    Public Sub Hide()
'        If isAnimating Then Return
'        initWidth = 0
'        currentStep = 0
'        increment = CInt(initWidth / stepsCount)
'        isAnimating = True
'        timer.Start()
'    End Sub

'    Private Sub Timer_Tick(sender As Object, e As EventArgs)
'        currentStep += 1

'        Dim newW As Integer
'        If initWidth > panelTarget.Width Then
'            ' Cerrando
'            newW = Math.Max(0, initWidth - increment * currentStep)
'        Else
'            ' Abriendo
'            newW = Math.Min(finalWidth, initWidth + increment * currentStep)
'        End If

'        panelTarget.Width = newW

'        If currentStep >= stepsCount Then
'            timer.Stop()
'            isAnimating = False
'            If panelTarget.Width = finalWidth Then
'                RaiseEvent DrawerOpened(Me, EventArgs.Empty)
'            Else
'                RaiseEvent DrawerClosed(Me, EventArgs.Empty)
'            End If
'        End If
'    End Sub
'End Class


















''Public Class DrawerAnimatorOrbital
''    Private ReadOnly drawerPanel As Panel
''    Private ReadOnly finalWidth As Integer
''    Private ReadOnly timer As Timer
''    Private Steps As Integer
''    Private opening As Boolean

''    Public Event Opened As EventHandler
''    Public Event Closed As EventHandler

''    Public Sub New(drawerPanel As Panel, finalWidth As Integer, Optional intervalMs As Integer = 1)
''        If drawerPanel Is Nothing Then Throw New ArgumentNullException(NameOf(drawerPanel))
''        Me.drawerPanel = drawerPanel
''        Me.finalWidth = finalWidth

''        ' Ajuste fino de animación
''        Me.Steps = Math.Max(1, finalWidth \ 1)
''        Me.timer = New Timer() With {.Interval = intervalMs}
''        AddHandler timer.Tick, AddressOf OnTick
''    End Sub

''    Public Sub Toggle()
''        If drawerPanel.Visible AndAlso drawerPanel.Width > 0 Then
''            Close()
''        Else
''            Open()
''        End If
''    End Sub

''    Public Sub Open()
''        opening = True
''        drawerPanel.Visible = True
''        drawerPanel.Width = 0
''        timer.Start()
''    End Sub

''    Public Sub Close()
''        opening = False
''        timer.Start()
''    End Sub

''    Private Sub OnTick(sender As Object, e As EventArgs)
''        Debug.WriteLine($"[Animator] Tick: Width={drawerPanel.Width}, opening={opening}")

''        If opening Then
''            drawerPanel.Width = Math.Min(finalWidth, drawerPanel.Width + Steps)
''            If drawerPanel.Width <= finalWidth Then
''                timer.Stop()
''                RaiseEvent Opened(Me, EventArgs.Empty)
''            End If
''        Else
''            drawerPanel.Width = Math.Max(0, drawerPanel.Width - Steps)
''            If drawerPanel.Width > 0 Then
''                timer.Stop()
''                drawerPanel.Visible = False
''                RaiseEvent Closed(Me, EventArgs.Empty)
''            End If
''        End If
''    End Sub
''End Class




'''Imports System
'''Imports System.Diagnostics
'''Imports System.Windows.Forms

'''''' <summary>
'''''' Controla la animación de apertura y cierre de un Panel tipo drawer.
'''''' </summary>
'''Public Class DrawerAnimatorOrbital

'''    Private ReadOnly drawerPanel As Panel
'''    Private ReadOnly finalWidth As Integer
'''    Private ReadOnly Steps As Integer
'''    Private ReadOnly timer As Timer
'''    Private opening As Boolean

'''    Public Event Opened As EventHandler
'''    Public Event Closed As EventHandler

'''    ''' <param name="drawerPanel">
'''    ''' Panel (DrawerPanelUI) insertado desde el diseñador.
'''    ''' </param>
'''    ''' <param name="finalWidth">
'''    ''' Ancho en pixeles cuando el drawer está completamente abierto.
'''    ''' </param>
'''    ''' <param name="animationIntervalMs">
'''    ''' Intervalo en milisegundos para el Timer de animación.
'''    ''' </param>
'''    Public Sub New(
'''            drawerPanel As Panel,
'''            finalWidth As Integer,
'''            Optional animationIntervalMs As Integer = 15)

'''        If drawerPanel Is Nothing Then
'''            Throw New ArgumentNullException(NameOf(drawerPanel))
'''        End If

'''        Me.drawerPanel = drawerPanel
'''        Me.finalWidth = finalWidth
'''        ' Dividimos el movimiento en 10 pasos iguales
'''        Me.Steps = Math.Max(1, finalWidth \ 10)

'''        Me.timer = New Timer() With {
'''            .Interval = animationIntervalMs
'''        }
'''        AddHandler timer.Tick, AddressOf OnTick
'''    End Sub

'''    ''' <summary>
'''    ''' Alterna entre abrir y cerrar el drawer con animación.
'''    ''' </summary>
'''    Public Sub Toggle()
'''        Debug.WriteLine("[DrawerAnimatorOrbital] Toggle")
'''        If drawerPanel.Visible AndAlso drawerPanel.Width > 0 Then
'''            Close()
'''        Else
'''            Open()
'''        End If
'''    End Sub

'''    ''' <summary>
'''    ''' Inicia la animación de apertura.
'''    ''' </summary>
'''    Public Sub Open()
'''        Debug.WriteLine("[DrawerAnimatorOrbital] Open")
'''        opening = True
'''        drawerPanel.Visible = True
'''        drawerPanel.Width = 200
'''        timer.Start()
'''    End Sub

'''    ''' <summary>
'''    ''' Inicia la animación de cierre.
'''    ''' </summary>
'''    Public Sub Close()
'''        Debug.WriteLine("[DrawerAnimatorOrbital] Close")
'''        opening = False
'''        timer.Start()
'''    End Sub

'''    ''' <summary>
'''    ''' Ajusta el ancho del panel en cada tick del Timer.
'''    ''' </summary>
'''    Private Sub OnTick(sender As Object, e As EventArgs)
'''        Dim currentWidth As Integer = drawerPanel.Width

'''        If opening Then 'AndAlso drawerPanel.Width >= finalWidth Then
'''            timer.Stop()
'''            RaiseEvent Opened(Me, EventArgs.Empty)
'''        ElseIf Not opening Then 'AndAlso drawerPanel.Width <= 0 Then
'''            timer.Stop()
'''            drawerPanel.Visible = False
'''            RaiseEvent Closed(Me, EventArgs.Empty)
'''        End If


'''    End Sub



'''End Class

