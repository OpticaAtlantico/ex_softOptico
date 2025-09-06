Public Class AppUserControlStyles
    Public Shared Sub ApplyStandardStyle(ctrl As Control)
        ctrl.Font = New Font(AppFonts.DefaultFamily, AppFonts.SizeMedium)
        ctrl.BackColor = AppColors.BackgroundPrimary
        ctrl.ForeColor = AppColors.TextPrimary
        ctrl.Padding = New Padding(AppLayout.Padding10)
    End Sub

    Public Shared Sub ApplyErrorStyle(ctrl As Control)
        ctrl.BackColor = AppColors.Errors
        ctrl.ForeColor = Color.White
    End Sub

End Class
