Imports System.Windows.Forms.Control

Public Class TrayStartUp
    Inherits ApplicationContext

    Public WithEvents AppTray As New NotifyIcon
    Private WithEvents TrayMenuStrip As New ContextMenuStrip
    Private WithEvents StartTrayMenuItm As New ToolStripMenuItem("&Start Hotspot")
    Private WithEvents StopTrayMenuItm As New ToolStripMenuItem("St&op Hotspot")
    Private WithEvents OpenAppTrayMenuItm As New ToolStripMenuItem("Open &Application")
    Private WithEvents CloseAppTrayMenuItm As New ToolStripMenuItem("&Close Application")
    Private WithEvents ExitTrayMenuItm As New ToolStripMenuItem("&Exit")
    Dim MainWindow As New MainDialog

    Public Sub TrayMenuStripInitialize()

        TrayMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {StartTrayMenuItm, StopTrayMenuItm, OpenAppTrayMenuItm, CloseAppTrayMenuItm, ExitTrayMenuItm})
        TrayMenuStrip.ShowImageMargin = False
        TrayMenuStrip.Size = New System.Drawing.Size(143, 114)
        CloseAppTrayMenuItm.Visible = False

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

    Private Sub AppTray_Click(sender As Object, e As EventArgs) Handles AppTray.Click

        If MainWindow.Visible = True Then
            OpenAppTrayMenuItm.Visible = False
            CloseAppTrayMenuItm.Visible = True
        ElseIf MainWindow.Visible = False Then
            CloseAppTrayMenuItm.Visible = False
            OpenAppTrayMenuItm.Visible = True
        End If

    End Sub

    Private Sub OpenAppTrayMenuItm_Click(sender As Object, e As EventArgs) Handles OpenAppTrayMenuItm.Click

        If MainWindow.Visible = False Then
            OpenAppTrayMenuItm.Visible = False
            CloseAppTrayMenuItm.Visible = True
            MainWindow.ShowDialog()
        End If

    End Sub

    Private Sub CloseAppTrayMenuItm_Click(sender As Object, e As EventArgs) Handles CloseAppTrayMenuItm.Click

        If MainWindow.Visible = True Then
            CloseAppTrayMenuItm.Visible = False
            OpenAppTrayMenuItm.Visible = True
            MainWindow.Visible = False
        End If

    End Sub

    Private Sub ExitTrayMenuItm_Click(sender As Object, e As EventArgs) Handles ExitTrayMenuItm.Click

        'MsgBox("Do you want to exit application?", MsgBoxStyle.YesNo, "WLAN Hotspot Creator")
        'If Conf.DialogResult = DialogResult.OK Then
        AppTray.Visible = False
        Me.Dispose()
        Application.Exit()
        'If MsgBoxResult.No Then
        'End If
        'End If

    End Sub

End Class
