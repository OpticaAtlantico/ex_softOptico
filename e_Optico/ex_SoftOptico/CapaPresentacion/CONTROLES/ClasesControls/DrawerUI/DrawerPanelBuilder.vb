Public Class DrawerPanelBuilder
    Private ReadOnly panelSide As Control
    Private ReadOnly groupsView As New Dictionary(Of DrawerGroup, SidePanelButtonGroupControl)

    Public Sub New(panelSide As Control, configs As Dictionary(Of DrawerGroup, List(Of DrawerItem)))
        Me.panelSide = panelSide
        InitializeGroups(configs)
    End Sub

    Private Sub InitializeGroups(configs As Dictionary(Of DrawerGroup, List(Of DrawerItem)))
        For Each kvp In configs
            Dim grpConfig = kvp.Key
            Dim items = kvp.Value

            ' Crea el control de grupo y árbol de botones
            Dim view = New SidePanelButtonGroupControl() With {
                .Visible = False
            }
            view.SetItems(
                items.Select(
                    Function(di) New ButtonGroupItem With {
                    .Text = di.Text,
                    .Icon = di.Icon,
                    .ClickHandler = di.ClickHandler
                }
            ))

            ' Posición relativa al botón trigger
            panelSide.Controls.Add(view)
            view.Left = grpConfig.TriggerButton.Left + grpConfig.LeftOffset
            view.Top = grpConfig.TriggerButton.Bottom + grpConfig.TopOffset

            ' Guarda y ata evento
            groupsView.Add(grpConfig, view)
            AddHandler grpConfig.TriggerButton.Click, Sub() ToggleGroup(grpConfig)
        Next
    End Sub

    Private Sub ToggleGroup(activeGroup As DrawerGroup)
        For Each kvp In groupsView
            Dim isActive = kvp.Key Is activeGroup
            kvp.Value.Visible = If(isActive, Not kvp.Value.Visible, False)
        Next
    End Sub
End Class

