Imports System.ComponentModel
Imports FontAwesome.Sharp

Public Class AlertUI
    Inherits PanelUI

    Private lblMensaje As New Label()
    Private icono As New IconPictureBox()
    Private _fadeTimer As New Timer()
    Private _vidaTimer As New Timer()
    Private _opacidad As Integer = 255

    Public Enum AlertType
        Info
        Success
        Warning
        Danger
    End Enum

    Private _tipo As AlertType = AlertType.Info

    <Category("WilmerUI")>
    Public Property Tipo As AlertType
        Get
            Return _tipo
        End Get
        Set(value As AlertType)
            _tipo = value
            AplicarEstiloAlerta()
        End Set
    End Property

    <Category("WilmerUI")>
    Public Property Mensaje As String
        Get
            Return lblMensaje.Text
        End Get
        Set(value As String)
            lblMensaje.Text = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.Height = 50
        Me.BorderRadius = 8
        Me.BorderSize = 1

        ' 🔹 Ícono FontAwesome
        With icono
            .Size = New Size(32, 32)
            .Location = New Point(10, 10)
            .IconSize = 28
            .BackColor = Color.Transparent
        End With
        Me.Controls.Add(icono)

        ' 🔹 Texto
        With lblMensaje
            .Font = New Font(AppFonts.Century, AppFonts.SizeSmall)
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleLeft
            .Dock = DockStyle.Fill
            .Padding = New Padding(50, 0, 10, 0)
        End With
        Me.Controls.Add(lblMensaje)

        AplicarEstiloAlerta()

        _vidaTimer.Interval = 5000
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

    Private Sub AplicarEstiloAlerta()
        Select Case _tipo
            Case AlertType.Success
                Me.CardBackColor = Color.FromArgb(230, 245, 233)
                Me.BorderColor = Color.SeaGreen
                icono.IconChar = IconChar.CheckCircle
                icono.IconColor = Color.SeaGreen
                lblMensaje.ForeColor = Color.SeaGreen

            Case AlertType.Info
                Me.CardBackColor = Color.FromArgb(227, 242, 253)
                Me.BorderColor = Color.SteelBlue
                icono.IconChar = IconChar.InfoCircle
                icono.IconColor = Color.SteelBlue
                lblMensaje.ForeColor = Color.SteelBlue

            Case AlertType.Warning
                Me.CardBackColor = Color.FromArgb(255, 249, 196)
                Me.BorderColor = Color.Goldenrod
                icono.IconChar = IconChar.ExclamationTriangle
                icono.IconColor = Color.Goldenrod
                lblMensaje.ForeColor = Color.Goldenrod

            Case AlertType.Danger
                Me.CardBackColor = Color.FromArgb(255, 235, 238)
                Me.BorderColor = Color.Firebrick
                icono.IconChar = IconChar.TimesCircle
                icono.IconColor = Color.Firebrick
                lblMensaje.ForeColor = Color.Firebrick
        End Select
        Me.Invalidate()
    End Sub
    Public Sub Mostrar()
        Me.Visible = True
        _opacidad = 255
        _vidaTimer.Start()
        Me.Invalidate()
    End Sub

End Class
