Public Class SidePanelButtonGroupControl
    Inherits UserControl

    Private _layout As TableLayoutPanel

    Public Sub New()
        _layout = New TableLayoutPanel() With {
            .Dock = DockStyle.Top,
            .AutoSize = True,
            .ColumnCount = 1,
            .Padding = New Padding(0),
            .Margin = New Padding(0)
        }
        Controls.Add(_layout)
    End Sub

    Public Sub SetItems(items As IEnumerable(Of ButtonGroupItem))
        _layout.Controls.Clear()
        _layout.RowStyles.Clear()
        Dim row As Integer = 0

        For Each item As ButtonGroupItem In items
            Dim btn As New Button() With {
                .Text = item.Text,
                .TextImageRelation = TextImageRelation.ImageBeforeText,
                .Dock = DockStyle.Top,
                .Height = 30,
                .FlatStyle = FlatStyle.Flat
            }
            AddHandler btn.Click, item.ClickHandler

            _layout.RowStyles.Add(New RowStyle(SizeType.Absolute, btn.Height))
            _layout.Controls.Add(btn, 0, row)
            row += 1
        Next
    End Sub
End Class


