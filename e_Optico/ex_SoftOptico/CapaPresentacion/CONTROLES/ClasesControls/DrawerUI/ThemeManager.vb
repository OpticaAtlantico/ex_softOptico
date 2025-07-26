Imports System.Drawing

Public Class ThemeManager
    Private Shared _current As ThemeManager

    Public Shared ReadOnly Property Current As ThemeManager
        Get
            If _current Is Nothing Then _current = New ThemeManager()
            Return _current
        End Get
    End Property

    Public Property IconColor As Color = Color.White
    Public Property ItemBackColor As Color = Color.FromArgb(45, 45, 48)
    Public Property MouseOverBackColor As Color = Color.FromArgb(62, 62, 66)
    Public Property MouseDownBackColor As Color = Color.FromArgb(0, 122, 204)
End Class

