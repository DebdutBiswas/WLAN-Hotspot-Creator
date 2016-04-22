Imports Microsoft.Win32
Imports System.Windows.Forms.Control
'-----------------------------------------------------
'DefaultCode:
'Namespace My
'Partial Friend Class MyApplication
'End Class
'End Namespace
'-----------------------------------------------------

Namespace My

    Class MyApplication

#If _MyType = "WindowsForms" Then

        Dim CurrentSSID As String
        Dim CurrentKey As String
        Private WithEvents StartUpThread As New System.ComponentModel.BackgroundWorker

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
                    CurrentSSID = SSID
                Else
                    MsgBox("Registry value for: SSID must be between 1 to 32 character.", MsgBoxStyle.Critical, "Registry Value Error")
                    Try
                        WLANHotspotSSIDRegKey.SetValue("SSID", "MyHotspot")
                        WLANHotspotSSIDRegKey.Close()
                        MsgBox("Default SSID is written!", MsgBoxStyle.Information, "Registry Repaired")
                    Catch
                        MsgBox("Unable to write default registry value for: SSID", MsgBoxStyle.Critical, "Registry Access Error")
                    End Try
                End If
            Catch
                MsgBox("Unable to read registry value for: SSID", MsgBoxStyle.Critical, "Registry Access Error")
                Try
                    WLANHotspotSSIDRegKey.SetValue("SSID", "MyHotspot")
                    WLANHotspotSSIDRegKey.Close()
                    MsgBox("Default SSID is written!", MsgBoxStyle.Information, "Registry Repaired")
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
                    CurrentKey = Key
                Else
                    MsgBox("Registry value for: Key must be between 8 to 64 character.", MsgBoxStyle.Critical, "Registry Value Error")
                    Try
                        WLANHotspotKeyRegKey.SetValue("Key", "12345678")
                        WLANHotspotKeyRegKey.Close()
                        MsgBox("Default Key is written!", MsgBoxStyle.Information, "Registry Repaired")
                    Catch
                        MsgBox("Unable to write default registry value for: Key", MsgBoxStyle.Critical, "Registry Access Error")
                    End Try
                End If
            Catch
                MsgBox("Unable to read registry value for: Key", MsgBoxStyle.Critical, "Registry Access Error")
                Try
                    WLANHotspotKeyRegKey.SetValue("Key", "12345678")
                    WLANHotspotKeyRegKey.Close()
                    MsgBox("Default Key is written!", MsgBoxStyle.Information, "Registry Repaired")
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
                    MsgBox("Application registry error repaired!", MsgBoxStyle.Information, "Registry Repaired")
                Catch
                    MsgBox("Unable to repair application default registry!", MsgBoxStyle.Critical, "Registry Access Error")
                End Try
            End If

        End Sub

        Private Sub ConnectFunction()

            MainDialog.startButton.Enabled = False

            Dim ConnectionCriteria As Boolean
            ConnectionCriteria = False

            If CurrentSSID.LongCount.ToString > 0 And CurrentKey.LongCount.ToString > 7 Then
                ConnectionCriteria = True
            Else
                ConnectionCriteria = False
            End If

            If ConnectionCriteria = True Then

                MainDialog.StatusLbl.Text = "Status: Trying to create hotspot!"
                MainDialog.DisableUserInterface()
                MainDialog.TrayStartingStatus()

                Dim SSID As String
                SSID = """" & CurrentSSID & """"

                Dim PSWD As String
                PSWD = """" & CurrentKey & """"

                Dim SysPath As String
                SysPath = Environment.GetFolderPath(Environment.SpecialFolder.System)

                Dim CommandSeperator As String
                CommandSeperator = "&&"

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
                                MainDialog.StatusLbl.Text = "Status: Hotspot couldn't be started!"
                                MainDialog.EnableUserInterface()
                                MainDialog.startButton.Enabled = True
                                MainDialog.TrayErrorStatus()
                            ElseIf ProcessSuccess.Contains("The hosted network started") Then
                                MainDialog.StatusLbl.Text = "Status: Hotspot started!"
                                MainDialog.startButton.Text = "&Stop"
                                MainDialog.startButton.Enabled = True
                                MainDialog.TrayStartedStatus()
                            End If
                        Else
                            MainDialog.EnableUserInterface()
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
                MainDialog.StatusLbl.Text = "Status: Check given SSID and Password!"
                MainDialog.startButton.Enabled = True
            End If

        End Sub

        Private Sub StartUpThread_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles StartUpThread.DoWork

            StartUpRegistryCheck()
            ConnectFunction()

        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            CheckForIllegalCrossThreadCalls = False

            If Environment.GetCommandLineArgs.Count <> 1 Then

                Dim CommandLineArgument = Environment.GetCommandLineArgs(1)

                Select Case CommandLineArgument

                    Case "/start"
                        If Not System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\netsh.exe") Then
                            MsgBox("netsh.exe Not found!", MsgBoxStyle.Critical, "Error!")
                            End
                        Else
                            StartUpRegistryCheck()
                            ConnectFunction()
                            'StartUpThread.RunWorkerAsync()
                        End If

                    Case "/help"
                        Process.Start("https://facebook.com/dev.software.development")
                        End

                    Case Else
                        MessageBox.Show("Invalid Command Line Argument :" + CommandLineArgument, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End

                End Select

            End If

        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            MessageBox.Show("Fatal Error", "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Process.Start("taskkill.exe", "/f /im WLAN Hotspot Creator.exe")

        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown

        End Sub

        'OnInitialize is used for advanced customization of the My Application Model (MyApplication).
        'Startup code for your specific application should be placed in a Startup event handler.
        <Global.System.Diagnostics.DebuggerStepThrough()>
        Protected Overrides Function OnInitialize(ByVal commandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            Return MyBase.OnInitialize(commandLineArgs)

        End Function
#End If

    End Class

End Namespace
