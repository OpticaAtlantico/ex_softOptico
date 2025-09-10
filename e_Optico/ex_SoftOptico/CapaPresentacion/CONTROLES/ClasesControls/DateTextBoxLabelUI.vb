Imports FontAwesome.Sharp

Public Class DateTextBoxLabelUI
    Inherits BaseTextBoxLabelUI

    Private dtpFecha As New DateTimePicker()

    Public Sub New()
        MyBase.New()

        ' Título / icono
        Me.TextoLabel = "Fecha:"
        iconoDerecha.IconChar = IconChar.CalendarAlt

        ' --- BUSCAR EL PANEL BASE DE FORMA SEGURA ---
        Dim basePanel As Panel = Nothing
        Try
            ' Preferible: usar pnlFondo si está disponible como Protected/Protected Friend
            basePanel = Me.pnlFondo
        Catch
            ' Fallback: buscar primer Panel en los controles
            basePanel = Me.Controls.OfType(Of Panel)().FirstOrDefault()
        End Try

        If basePanel Is Nothing Then
            ' No pudimos localizar el panel base: salir con mensaje en debug y evitar crash
            Debug.WriteLine("DateLabelUI: no se encontró el panel base (pnlFondo).")
            Return
        End If

        ' --- REMOVER EL TEXTBOX DE LA BASE (si existe) de forma segura ---
        Dim baseTextBox As TextBox = basePanel.Controls.OfType(Of TextBox)().FirstOrDefault()
        If baseTextBox IsNot Nothing Then
            ' Si tu base tiene un lblPlaceholder (Label sobrepuesto), ocultarlo:
            Dim placeholderLabel = basePanel.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Name = "lblPlaceholder" OrElse l.Tag = "placeholder")
            If placeholderLabel IsNot Nothing Then placeholderLabel.Visible = False

            basePanel.Controls.Remove(baseTextBox)
        End If

        ' --- CONFIGURAR DateTimePicker ---
        dtpFecha.Format = DateTimePickerFormat.Short
        dtpFecha.Dock = DockStyle.Top
        dtpFecha.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        dtpFecha.CalendarMonthBackground = basePanel.BackColor
        dtpFecha.ShowUpDown = False

        ' Opcional: conectar eventos de foco para refrescar el borde del panel
        AddHandler dtpFecha.GotFocus, Sub() pnlFondo.Invalidate()
        AddHandler dtpFecha.LostFocus, Sub() pnlFondo.Invalidate()
        AddHandler dtpFecha.ValueChanged, Sub() lblError.Visible = False

        ' --- AÑADIR al panel base ---
        basePanel.Controls.Add(dtpFecha)
        dtpFecha.BringToFront()

        ' Ajustes visuales: si tu base usa un lblPlaceholder o propiedad Placeholder, desactívala
        Try
            Me.Placeholder = String.Empty
        Catch
            ' ignorar si no existe la propiedad
        End Try
    End Sub

    ' Exponer el valor de la fecha
    Public Property Value As Date
        Get
            Return If(dtpFecha IsNot Nothing, dtpFecha.Value, Date.Now)
        End Get
        Set(value As Date)
            If dtpFecha IsNot Nothing Then dtpFecha.Value = value
        End Set
    End Property
End Class
