Public Class SidePanelGroupBuilder
    Private ReadOnly _panelSide As Control
    Private ReadOnly _groups As New Dictionary(Of Button, SidePanelButtonGroupControl)()

    Public Sub New(panelSide As Control)
        _panelSide = panelSide
    End Sub

    Public Sub RegisterGroup(triggerButton As Button, items As IEnumerable(Of ButtonGroupItem))
        Dim group As New SidePanelButtonGroupControl()
        group.SetItems(items)

        group.Visible = False
        _panelSide.Controls.Add(group)
        group.Top = triggerButton.Bottom
        group.Left = triggerButton.Left + 20

        _groups(triggerButton) = group
        AddHandler triggerButton.Click, Sub() ToggleGroup(triggerButton)
    End Sub

    Private Sub ToggleGroup(trigger As Button)
        For Each kvp As KeyValuePair(Of Button, SidePanelButtonGroupControl) In _groups
            If kvp.Key Is trigger Then
                kvp.Value.Visible = Not kvp.Value.Visible
            Else
                kvp.Value.Visible = False
            End If
        Next
    End Sub
End Class

