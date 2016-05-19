Public Class VirtualAdapterSelectionDialog
    Private Sub VirtualAdapterSelectionDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        IcsVirtualAdapterIdComboBox.Items.Clear()

        For Each IcsVirtualAdapter As String In IcsVirtualAdapterIdArray.Items
            IcsVirtualAdapterIdComboBox.Items.Add(IcsVirtualAdapter)
        Next

        IcsVirtualAdapterIdComboBox.SelectedIndex = 0

    End Sub

    Private Sub selectButton_Click(sender As Object, e As EventArgs) Handles selectButton.Click

        IcsVirtualAdapterId = IcsVirtualAdapterIdComboBox.SelectedItem.ToString
        Me.Close()

    End Sub

End Class