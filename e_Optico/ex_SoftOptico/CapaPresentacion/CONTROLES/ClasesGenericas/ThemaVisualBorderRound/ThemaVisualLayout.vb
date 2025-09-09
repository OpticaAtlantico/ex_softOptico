Public Class ThemaVisualLayout
    Public Property ColorNormal As Color
    Public Property ColorError As Color
    Public Property ColorValidado As Color
    Public Property ColorHover As Color
    Public Property ColorFocus As Color

    Public Function ObtenerColorBorde(estado As EstiloLayout.EstadoVisual) As Color
        Select Case estado
            Case EstiloLayout.EstadoVisual.Errors
                Return ColorError
            Case EstiloLayout.EstadoVisual.Validado
                Return ColorValidado
            Case EstiloLayout.EstadoVisual.Hover
                Return ColorHover
            Case EstiloLayout.EstadoVisual.Focus
                Return ColorFocus
            Case Else
                Return ColorNormal
        End Select
    End Function
End Class
