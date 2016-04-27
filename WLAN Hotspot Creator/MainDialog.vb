Imports WLANHotspotCreator.TrayStartUp
Imports Microsoft.Win32
Imports System.Management
Imports IcsManagerLibrary
Imports System.ComponentModel

Public Class MainDialog

    Public SysPath As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
    Public CommandSeperator As String = "&&"

    Private Sub StartUpRegistryCheck()

        Dim SSID_Val_Status As Boolean
        SSID_Val_Status = True
        Dim Key_Val_Status As Boolean
        Key_Val_Status = True
        '----------------------------------------------------------------------------------------------
        Dim WLANHotspotSSIDRegKey As RegistryKey
        WLANHotspotSSIDRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WLANHotspot", True)

        Dim SSID As String
        Try
            SSID = WLANHotspotSSIDRegKey.GetValue("SSID")
            If SSID.LongCount.ToString > 0 And SSID.LongCount.ToString <= 32 Then
                ssidTextBox.Text = SSID
            Else
                MsgBox("Registry value for: SSID must be between 1 to 32 character.", MsgBoxStyle.Critical, "Registry Value Error")
                ssidTextBox.Text = "MyHotspot"
                Try
                    WLANHotspotSSIDRegKey.SetValue("SSID", "MyHotspot")
                    WLANHotspotSSIDRegKey.Close()
                    StatusLbl.Text = "Status: Default SSID is written!"
                Catch
                    MsgBox("Unable to write default registry value for: SSID", MsgBoxStyle.Critical, "Registry Access Error")
                End Try
            End If
        Catch
            MsgBox("Unable to read registry value for: SSID", MsgBoxStyle.Critical, "Registry Access Error")
            ssidTextBox.Text = "MyHotspot"
            Try
                WLANHotspotSSIDRegKey.SetValue("SSID", "MyHotspot")
                WLANHotspotSSIDRegKey.Close()
                StatusLbl.Text = "Status: Default SSID is written!"
            Catch
                SSID_Val_Status = False
                MsgBox("Unable to write default registry value for: SSID", MsgBoxStyle.Critical, "Registry Access Error")
            End Try
        End Try
        '----------------------------------------------------------------------------------------------
        Dim WLANHotspotKeyRegKey As RegistryKey
        WLANHotspotKeyRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WLANHotspot", True)

        Dim Key As String
        Try
            Key = WLANHotspotKeyRegKey.GetValue("Key")
            If Key.LongCount.ToString >= 8 And Key.LongCount.ToString <= 64 Then
                passwordTextBox.Text = Key
            Else
                MsgBox("Registry value for: Key must be between 8 to 64 character.", MsgBoxStyle.Critical, "Registry Value Error")
                passwordTextBox.Text = "12345678"
                Try
                    WLANHotspotKeyRegKey.SetValue("Key", "12345678")
                    WLANHotspotKeyRegKey.Close()
                    StatusLbl.Text = "Status: Default Key is written!"
                Catch
                    MsgBox("Unable to write default registry value for: Key", MsgBoxStyle.Critical, "Registry Access Error")
                End Try
            End If
        Catch
            MsgBox("Unable to read registry value for: Key", MsgBoxStyle.Critical, "Registry Access Error")
            passwordTextBox.Text = "12345678"
            Try
                WLANHotspotKeyRegKey.SetValue("Key", "12345678")
                WLANHotspotKeyRegKey.Close()
                StatusLbl.Text = "Status: Default Key is written!"
            Catch
                Key_Val_Status = False
                MsgBox("Unable to write default registry value for: Key", MsgBoxStyle.Critical, "Registry Access Error")
            End Try
        End Try

        If SSID_Val_Status = False Or Key_Val_Status = False Then
            Dim WLANHotspotRepairRegistry As RegistryKey
            Try
                WLANHotspotRepairRegistry = Registry.LocalMachine.CreateSubKey("SOFTWARE\WLANHotspot")
                WLANHotspotRepairRegistry.SetValue("SSID", "MyHotspot", RegistryValueKind.String)
                WLANHotspotRepairRegistry.SetValue("Key", "12345678", RegistryValueKind.String)
                WLANHotspotRepairRegistry.Close()
                StatusLbl.Text = "Status: Application registry error repaired!"
            Catch
                MsgBox("Unable to repair application default registry!", MsgBoxStyle.Critical, "Registry Access Error")
            End Try
        End If


    End Sub

    Private Sub GetIcsAdapters()

        connectionComboBox.Items.Clear()

        Dim connectionScope As New ManagementScope()
        Dim connectionQuery As New SelectQuery("Win32_NetworkAdapter", "NetConnectionStatus=2")
        Dim searcher As New ManagementObjectSearcher(connectionScope, connectionQuery)

        Try
            For Each item As ManagementObject In searcher.[Get]()
                Dim connectionId As String = item("NetConnectionID").ToString()

                connectionComboBox.Items.Add(connectionId)

            Next
        Catch
        End Try

        If connectionComboBox.Items.Count = 0 Then
            connectionComboBox.Items.Add("No connection Avilable!")
        End If

        connectionComboBox.SelectedIndex = 0

    End Sub

    Private Sub IcsRefreshThread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles IcsRefreshThread.DoWork

        refreshConnectionButton.Enabled = False
        GetIcsAdapters()
        refreshConnectionButton.Enabled = True

    End Sub

    Private Sub MainDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CheckForIllegalCrossThreadCalls = False

        If Not System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\netsh.exe") Then
            MsgBox("netsh.exe Not found!", MsgBoxStyle.Critical, "Error!")
            Me.Close()
        Else
            AppTray.Visible = True
            StartUpRegistryCheck()
            IcsRefreshThread.RunWorkerAsync()
        End If

    End Sub

    Private Sub ShowPasswordChkBox_Click(sender As Object, e As EventArgs) Handles ShowPasswordChkBox.Click

        If ShowPasswordChkBox.CheckState = CheckState.Checked Then
            passwordTextBox.PasswordChar = Nothing
        ElseIf ShowPasswordChkBox.CheckState = CheckState.Unchecked Then
            passwordTextBox.PasswordChar = "●"
        End If

    End Sub

    Public Sub EnableUserInterface()

        ssidTextBox.Enabled = True
        passwordTextBox.Enabled = True
        ShowPasswordChkBox.Enabled = True
        connectionComboBox.Enabled = True
        refreshConnectionButton.Enabled = True

    End Sub

    Public Sub DisableUserInterface()

        ssidTextBox.Enabled = False
        passwordTextBox.Enabled = False
        ShowPasswordChkBox.Enabled = False
        connectionComboBox.Enabled = False
        refreshConnectionButton.Enabled = False

    End Sub

    Public Sub TrayStartingStatus()
        AppTray.Icon = My.Resources.connection_icon_blue
        AppTray.BalloonTipIcon = ToolTipIcon.Info
        AppTray.BalloonTipTitle = "WiFi Hotspot Status"
        AppTray.BalloonTipText = "Creating Hotspot..."
        AppTray.ShowBalloonTip(500)
    End Sub

    Public Sub TrayStartedStatus()

        AppTray.Icon = My.Resources.connection_icon_green
        AppTray.BalloonTipIcon = ToolTipIcon.Info
        AppTray.BalloonTipTitle = "WiFi Hotspot Status"
        AppTray.BalloonTipText = "Hotspot Started..."
        AppTray.ShowBalloonTip(500)

    End Sub

    Public Sub TrayStoppingStatus()

        AppTray.Icon = My.Resources.connection_icon_yellow
        AppTray.BalloonTipIcon = ToolTipIcon.Info
        AppTray.BalloonTipTitle = "WiFi Hotspot Status"
        AppTray.BalloonTipText = "Stopping Hotspot..."
        AppTray.ShowBalloonTip(500)

    End Sub

    Public Sub TrayStoppedStatus()

        AppTray.Icon = My.Resources.connection_icon_red
        AppTray.BalloonTipIcon = ToolTipIcon.Info
        AppTray.BalloonTipTitle = "WiFi Hotspot Status"
        AppTray.BalloonTipText = "Hotspot Stopped..."
        AppTray.ShowBalloonTip(500)

    End Sub

    Public Sub TrayErrorStatus()

        AppTray.Icon = My.Resources.connection_icon_red
        AppTray.BalloonTipIcon = ToolTipIcon.Info
        AppTray.BalloonTipTitle = "WiFi Hotspot Status"
        AppTray.BalloonTipText = "Hotspot couldn't be started..."
        AppTray.ShowBalloonTip(500)

    End Sub

    Private Sub ConnectIcs()

        If connectionComboBox.SelectedItem.ToString = "No connection Avilable!" Then
            StatusLbl.Text = "Status: Hotspot started without ICS!"
            startButton.Text = "&Stop"
            startButton.Enabled = True
        Else
            StatusLbl.Text = "Status: Trying to create ICS with " & connectionComboBox.SelectedItem.ToString & "."
            Try
                IcsManager.ShareConnection(IcsManager.GetConnectionByName(connectionComboBox.SelectedItem.ToString), IcsManager.GetConnectionByName("Wi-Fi Hotspot"))
                StatusLbl.Text = "Status: Shared with " & connectionComboBox.SelectedItem.ToString & "."
                startButton.Text = "&Stop"
                startButton.Enabled = True
            Catch
                StatusLbl.Text = "Status: Network shell busy, retrying ICS with " & connectionComboBox.SelectedItem.ToString & "."
                'startButton.Text = "&Stop"
                'startButton.Enabled = True
                ConnectIcs()
            End Try

        End If

    End Sub

    Private Sub IcsConnectThread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles IcsConnectThread.DoWork

        ConnectIcs()

    End Sub

    Private Sub ConnectFunction()

        startButton.Enabled = False

        Dim ConnectionCriteria As Boolean
        ConnectionCriteria = False

        If ssidTextBox.Text.LongCount.ToString > 0 And passwordTextBox.Text.LongCount.ToString > 7 Then
            ConnectionCriteria = True
        Else
            ConnectionCriteria = False
        End If

        If ConnectionCriteria = True Then

            StatusLbl.Text = "Status: Trying to create hotspot!"
            DisableUserInterface()
            TrayStartingStatus()

            Dim SSID As String
            SSID = """" & ssidTextBox.Text & """"

            Dim PSWD As String
            PSWD = """" & passwordTextBox.Text & """"

            'Dim SysPath As String
            'SysPath = Environment.GetFolderPath(Environment.SpecialFolder.System)

            'Dim CommandSeperator As String
            'CommandSeperator = "&&"

            If System.IO.File.Exists(SysPath & "\netsh.exe") Then
                Dim ConnectionProcess = New Process
                ConnectionProcess.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\cmd.exe"
                ConnectionProcess.StartInfo.Arguments = "/k echo off" & CommandSeperator & SysPath & "\netsh.exe wlan set hostednetwork mode=allow ssid=" & SSID & " key=" & PSWD & CommandSeperator & SysPath & "\netsh.exe  wlan start hostednetwork"
                ConnectionProcess.StartInfo.UseShellExecute = False
                ConnectionProcess.StartInfo.CreateNoWindow = True
                ConnectionProcess.StartInfo.RedirectStandardOutput = True
                ConnectionProcess.StartInfo.RedirectStandardError = True
                ConnectionProcess.Start()
                ConnectionProcess.WaitForExit(4000)
                If Not ConnectionProcess.HasExited Then
                    ConnectionProcess.Kill()
                    Dim SuccessOutPut As IO.StreamReader = ConnectionProcess.StandardOutput()
                    Dim ErrorOutPut As IO.StreamReader = ConnectionProcess.StandardError()
                    Dim ProcessSuccess As String
                    Dim ProcessError As String
                    ProcessSuccess = SuccessOutPut.ReadToEnd
                    ProcessError = ErrorOutPut.ReadToEnd
                    If ProcessError = "" Then
                        If ProcessSuccess.Contains("The hosted network couldn't be started") Then
                            StatusLbl.Text = "Status: Hotspot couldn't be started!"
                            EnableUserInterface()
                            startButton.Enabled = True
                            TrayErrorStatus()
                        ElseIf ProcessSuccess.Contains("The hosted network started") Then
                            StatusLbl.Text = "Status: Hotspot started!"
                            IcsConnectThread.RunWorkerAsync()
                            'startButton.Text = "&Stop"
                            'startButton.Enabled = True
                            TrayStartedStatus()
                        End If
                    Else
                        EnableUserInterface()
                        MsgBox(ProcessError, MsgBoxStyle.Critical, "Error")
                    End If
                    SuccessOutPut.Close()
                    ErrorOutPut.Close()
                    ConnectionProcess.Close()
                End If

            Else
                MsgBox("netsh.exe Not found!", MsgBoxStyle.Critical, "Error!")
            End If

        Else
            StatusLbl.Text = "Status: Check given SSID and Password!"
            startButton.Enabled = True
        End If

    End Sub

    Private Sub DisconnectFunction()

        startButton.Enabled = False

        StatusLbl.Text = "Status: Trying to stop hotspot!"
        TrayStoppingStatus()

        IcsManager.ShareConnection(Nothing, Nothing)

        'Dim SysPath As String
        'SysPath = Environment.GetFolderPath(Environment.SpecialFolder.System)

        'Dim CommandSeperator As String
        'CommandSeperator = "&&"

        If System.IO.File.Exists(SysPath & "\netsh.exe") Then
            Dim ConnectionProcess = New Process
            ConnectionProcess.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) & "\cmd.exe"
            ConnectionProcess.StartInfo.Arguments = "/k echo off" & CommandSeperator & SysPath & "\netsh.exe  wlan stop hostednetwork"
            ConnectionProcess.StartInfo.UseShellExecute = False
            ConnectionProcess.StartInfo.CreateNoWindow = True
            ConnectionProcess.StartInfo.RedirectStandardOutput = True
            ConnectionProcess.StartInfo.RedirectStandardError = True
            ConnectionProcess.Start()
            ConnectionProcess.WaitForExit(4000)
            If Not ConnectionProcess.HasExited Then
                ConnectionProcess.Kill()
                Dim SuccessOutPut As IO.StreamReader = ConnectionProcess.StandardOutput()
                Dim ErrorOutPut As IO.StreamReader = ConnectionProcess.StandardError()
                Dim ProcessSuccess As String
                Dim ProcessError As String
                ProcessSuccess = SuccessOutPut.ReadToEnd
                ProcessError = ErrorOutPut.ReadToEnd
                If ProcessError = "" Then
                    If ProcessSuccess.Contains("The hosted network stopped") Then
                        StatusLbl.Text = "Status: Hotspot stopped!"
                        EnableUserInterface()
                        startButton.Text = "&Start"
                        startButton.Enabled = True
                        TrayStoppedStatus()
                    End If
                Else
                    EnableUserInterface()
                    MsgBox(ProcessError, MsgBoxStyle.Critical, "Error")
                End If
                SuccessOutPut.Close()
                ErrorOutPut.Close()
                ConnectionProcess.Close()
            End If

        Else
            MsgBox("netsh.exe Not found!", MsgBoxStyle.Critical, "Error!")
        End If

    End Sub

    Private Sub WriteCurrentConfigToRegistry()

        Dim WLANHotspotWriteRegKey As RegistryKey
        Try
            WLANHotspotWriteRegKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\WLANHotspot", True)
            If Not ssidTextBox.Text = WLANHotspotWriteRegKey.GetValue("SSID") Then
                WLANHotspotWriteRegKey.SetValue("SSID", ssidTextBox.Text)
            End If
            '------------------------------------------------------------------------------------------------
            If Not passwordTextBox.Text = WLANHotspotWriteRegKey.GetValue("Key") Then
                WLANHotspotWriteRegKey.SetValue("Key", passwordTextBox.Text)
            End If
        Catch
            StartUpRegistryCheck()
        End Try

    End Sub

    Private Sub CurrentRegistryWriteThread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CurrentRegistryWriteThread.DoWork

        WriteCurrentConfigToRegistry()

    End Sub

    Private Sub ConsoleThread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles ConsoleThread.DoWork

        If startButton.Text = "&Start" Then
            ConnectFunction()
            CurrentRegistryWriteThread.RunWorkerAsync()
        ElseIf startButton.Text = "&Stop" Then
            DisconnectFunction()
        End If

    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click

        ConsoleThread.RunWorkerAsync()

    End Sub

    Private Sub refreshConnectionButton_Click(sender As Object, e As EventArgs) Handles refreshConnectionButton.Click

        IcsRefreshThread.RunWorkerAsync()

    End Sub

    Private Sub MainDialog_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked

        AboutDialog.ShowDialog()

    End Sub

    Private Sub MainDialog_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.Closing

        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Visible = False
        End If

    End Sub

    'Public c1 As TrayStartUp
    Private Sub MainDialog_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        'c1.TrayAppStartedStatus()

    End Sub

    Private Sub MainDialog_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If

    End Sub

    Private Sub MainDialog_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged

        If Me.Visible = False Then
            AppTray.Visible = False
        ElseIf Me.Visible = True Then
            AppTray.Visible = True
        End If

    End Sub

    Private Sub MainDialog_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Me.Width = 485
        Me.Height = 210
    End Sub

End Class
