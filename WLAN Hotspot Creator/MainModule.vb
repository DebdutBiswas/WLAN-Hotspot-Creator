Imports System.Windows.Forms.Control
Imports Microsoft.Win32
Imports WLANHotspotCreator.MainDialog

Module MainModule

    Public Sub Main()
        Application.Run(New TrayStartUp)
    End Sub

End Module

Public Class TrayStartUp
    Inherits ApplicationContext

    Private WithEvents AppTray As New NotifyIcon
    Private WithEvents TrayMenuStrip As ContextMenuStrip
    Private WithEvents StartTrayMenuItm As New ToolStripMenuItem("&Start Hotspot")
    Private WithEvents StopTrayMenuItm As New ToolStripMenuItem("St&op Hotspot")
    Private WithEvents OpenAppTrayMenuItm As New ToolStripMenuItem("&Open Application")
    Private WithEvents ExitTrayMenuItm As New ToolStripMenuItem("&Exit")

    Public Sub AppTrayInitialize()
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

        TrayMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {StartTrayMenuItm, StopTrayMenuItm, OpenAppTrayMenuItm, ExitTrayMenuItm})
        TrayMenuStrip.ShowImageMargin = False
        TrayMenuStrip.Size = New System.Drawing.Size(143, 114)

        AppTrayInitialize()

        TrayAppStartedStatus()
    End Sub

End Class
