Imports FontAwesome.Sharp
Imports System.Drawing
Public Class GrupoSQL

    Public Property NombreGrupo As String
    Public Property Icono As FontAwesome.Sharp.IconChar
    Public Property EstiloColor As Color
    Public Property Acciones As List(Of String)

    ' Constructor opcional
    Public Sub New(nombre As String)
        Me.NombreGrupo = nombre
        Me.Icono = IconChar.Database
        Me.EstiloColor = Color.Silver
        Me.Acciones = New List(Of String)
    End Sub
End Class
