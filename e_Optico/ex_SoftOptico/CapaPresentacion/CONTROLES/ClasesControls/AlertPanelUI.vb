﻿Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Public Enum AlertType
    Success
    Warning
    Errores
    Info
End Enum

Public Class AlertPanelUI
    Inherits UserControl

    Private _tipo As AlertType = AlertType.Info
    Private _mensaje As String = "Mensaje de alerta"
    Private _iconoUnicode As String = ChrW(&HF06A) ' fa-info-circle
    Private _iconoColor As Color = Color.White
    Private _fondoColor As Color = Color.SkyBlue
    Private _textoColor As Color = Color.White
    Private _fontAwesome As New Font("Font Awesome 6 Free Solid", 10)
    Private _fadeTimer As New Timer()
    Private _vidaTimer As New Timer()
    Private _opacidad As Integer = 255
    Private _btnCerrar As New Label()

    Public Sub New()
        Me.Size = New Size(400, 45)
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True

        _btnCerrar.Text = "✖"
        _btnCerrar.Font = New Font("Century Gothic", 10, FontStyle.Bold)
        _btnCerrar.ForeColor = Color.White
        _btnCerrar.AutoSize = False
        _btnCerrar.TextAlign = ContentAlignment.MiddleCenter
        _btnCerrar.Size = New Size(20, 20)
        _btnCerrar.Location = New Point(Me.Width - 25, 12)
        _btnCerrar.Cursor = Cursors.Hand
        AddHandler _btnCerrar.Click, Sub() Me.Dispose()
        Me.Controls.Add(_btnCerrar)

        _vidaTimer.Interval = 3000
        AddHandler _vidaTimer.Tick, Sub()
                                        _vidaTimer.Stop()
                                        _fadeTimer.Start()
                                    End Sub

        _fadeTimer.Interval = 30
        AddHandler _fadeTimer.Tick, Sub()
                                        _opacidad -= 15
                                        If _opacidad <= 0 Then
                                            _fadeTimer.Stop()
                                            Me.Dispose()
                                        Else
                                            Me.Invalidate()
                                        End If
                                    End Sub

        Me.Visible = False
    End Sub

    Public Sub Mostrar()
        Me.Visible = True
        _opacidad = 255
        _vidaTimer.Start()
        Me.Invalidate()
    End Sub

    Public Property TipoAlerta As AlertType
        Get
            Return _tipo
        End Get
        Set(value As AlertType)
            _tipo = value
            Select Case value
                Case AlertType.Success
                    _fondoColor = Color.MediumSeaGreen
                    _iconoUnicode = ChrW(&HF00C) ' fa-check
                Case AlertType.Warning
                    _fondoColor = Color.Goldenrod
                    _iconoUnicode = ChrW(&HF071) ' fa-exclamation-triangle
                Case AlertType.Errores
                    _fondoColor = Color.IndianRed
                    _iconoUnicode = ChrW(&HF057) ' fa-times-circle
                Case AlertType.Info
                    _fondoColor = Color.SkyBlue
                    _iconoUnicode = ChrW(&HF06A) ' fa-info-circle
            End Select
            Me.Invalidate()
        End Set
    End Property

    Public Property MensajeAlerta As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
            Me.Invalidate()
        End Set
    End Property

    ' 🎨 Render personalizado

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Dim g = pe.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

        Dim fondoColorFade = Color.FromArgb(_opacidad, _fondoColor)
        Dim textoColorFade = Color.FromArgb(_opacidad, _textoColor)
        Dim iconColorFade = Color.FromArgb(_opacidad, _iconoColor)

        g.FillRectangle(New SolidBrush(fondoColorFade), rect)
        g.DrawRectangle(New Pen(Color.White, 1), rect)

        ' Ícono
        TextRenderer.DrawText(g, _iconoUnicode, _fontAwesome, New Point(10, 12), iconColorFade)

        ' Mensaje
        TextRenderer.DrawText(g, _mensaje, New Font("Century Gothic", 10), New Rectangle(40, 10, Me.Width - 60, 25), textoColorFade)
    End Sub
End Class
