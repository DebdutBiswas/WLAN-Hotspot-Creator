Imports System.Windows.Forms.Control

Module MainModule

    Public Sub Main()

        Application.Run(New TrayStartUp)

    End Sub

End Module

Public Class TrayStartUp
    Inherits ApplicationContext

    Public WithEvents AppTray As New NotifyIcon
    Private WithEvents TrayMenuStrip As New ContextMenuStrip
    Private WithEvents StartTrayMenuItm As New ToolStripMenuItem("&Start Hotspot")
    Private WithEvents StopTrayMenuItm As New ToolStripMenuItem("St&op Hotspot")
    Public WithEvents OpenAppTrayMenuItm As New ToolStripMenuItem("Open &Application")
    Private WithEvents ExitTrayMenuItm As New ToolStripMenuItem("&Exit")

    Public Sub TrayMenuStripInitialize()

        TrayMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {StartTrayMenuItm, StopTrayMenuItm, OpenAppTrayMenuItm, ExitTrayMenuItm})
        TrayMenuStrip.ShowImageMargin = False
        TrayMenuStrip.Size = New System.Drawing.Size(143, 114)

    End Sub

    Public Sub AppTrayInitialize()

        TrayMenuStripInitialize()
        AppTray.Text = "WLAN Hotspot Creator"
        AppTray.ContextMenuStrip = TrayMenuStrip
        AppTray.Visible = True

    End Sub

    Public Sub TrayAppStartedStatus()

        AppTray.Icon = My.Resources.connection_icon_white
        AppTray.BalloonTipIcon = ToolTipIcon.Info
        AppTray.BalloonTipTitle = "WiFi Hotspot Status"
        AppTray.BalloonTipText = "Application started..."
        AppTray.ShowBalloonTip(500)

    End Sub

    Public Sub New()

        CheckForIllegalCrossThreadCalls = False

        AppTrayInitialize()
        TrayAppStartedStatus()

    End Sub

    Private Sub OpenAppTrayMenuItm_Click(sender As Object, e As EventArgs) Handles OpenAppTrayMenuItm.Click

        Dim MainWindow As New MainDialog
        MainWindow.ShowDialog()

    End Sub

    Private Sub ExitTrayMenuItm_Click(sender As Object, e As EventArgs) Handles ExitTrayMenuItm.Click

        AppTray.Visible = False
        Me.Dispose()
        Application.Exit()

    End Sub

End Class
