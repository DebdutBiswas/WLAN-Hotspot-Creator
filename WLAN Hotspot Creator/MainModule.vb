
Module MainModule

    Public WithEvents IcsVirtualAdapterIdArray As New ComboBox
    Public WithEvents IcsVirtualAdapterId As String
    Public Sub Main()

        Application.Run(New TrayStartUp)

    End Sub

End Module
