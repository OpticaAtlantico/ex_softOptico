Public Class ThemeColors

    'AGREGAMOS UNA LISTA DE COLORS DE TIPO STRING EN FORMATTO HTML (OPCIONAL)
    Public Property PrimaryColor As Color
    Public Property SecondaryColor As Color
    Public ColorList As List(Of String) = New List(Of String)() From {
        "#3F51B5",
        "#009688",
        "#FF5722",
        "#607D8B",
        "#FF9800",
        "#9C27B0",
        "#2196F3",
        "#EA676C",
        "#E41A4A",
        "#5978BB",
        "#018790",
        "#0E3441",
        "#00B0AD",
        "#721D47",
        "#EA4833",
        "#EF937E",
        "#F37521",
        "#A12059",
        "#126881",
        "#8BC240",
        "#364D5B",
        "#C7DC5B",
        "#0094BC",
        "#E4126B",
        "#43B76E",
        "#7BCFE9",
        "#B71C46"
    }

    Function ChangeColorBrightness(color As Color, correcctionFactor As Double) As Color

        Dim red As Double = color.R
        Dim green As Double = color.G
        Dim blue As Double = color.B

        'if correcction factor is less then 0, darken color
        If correcctionFactor < 0 Then

            correcctionFactor = 1 + correcctionFactor
            red *= correcctionFactor
            green *= correcctionFactor
            blue *= correcctionFactor

            'if correction facctor is greater than zero, lighten color.
        Else

            red = (255 - red) * correcctionFactor + red
            green = (255 - green) * correcctionFactor + green
            blue = (255 - blue) * correcctionFactor + blue

        End If
        Return Color.FromArgb(color.A, CByte(red), CByte(green), CByte(blue))

    End Function


End Class
