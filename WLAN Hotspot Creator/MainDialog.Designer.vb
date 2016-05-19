<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDialog))
        Me.VisualStyler = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.AppTray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TrayMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartTrayMenuItm = New System.Windows.Forms.ToolStripMenuItem()
        Me.StopTrayMenuItm = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenAppTrayMenuItm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitTrayMenuItm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleThread = New System.ComponentModel.BackgroundWorker()
        Me.MainDialogToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.passwordTextBox = New System.Windows.Forms.TextBox()
        Me.ssidTextBox = New System.Windows.Forms.TextBox()
        Me.connectionComboBox = New System.Windows.Forms.ComboBox()
        Me.refreshConnectionButton = New System.Windows.Forms.Button()
        Me.startButton = New System.Windows.Forms.Button()
        Me.connectionLabel = New System.Windows.Forms.Label()
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.ssidLabel = New System.Windows.Forms.Label()
        Me.ShowPasswordChkBox = New System.Windows.Forms.CheckBox()
        Me.StatusLbl = New System.Windows.Forms.Label()
        Me.CurrentRegistryWriteThread = New System.ComponentModel.BackgroundWorker()
        Me.IcsRefreshThread = New System.ComponentModel.BackgroundWorker()
        Me.IcsConnectThread = New System.ComponentModel.BackgroundWorker()
        CType(Me.VisualStyler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TrayMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'VisualStyler
        '
        Me.VisualStyler.HostForm = Me
        Me.VisualStyler.License = CType(resources.GetObject("VisualStyler.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Medium
        Me.VisualStyler.LoadVisualStyle(Nothing, "XP Royale (Black).vssf")
        '
        'AppTray
        '
        Me.AppTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.AppTray.BalloonTipText = "WLAN Hotspot Creator"
        Me.AppTray.BalloonTipTitle = "WLAN Hotspot Creator"
        Me.AppTray.ContextMenuStrip = Me.TrayMenuStrip
        Me.AppTray.Icon = CType(resources.GetObject("AppTray.Icon"), System.Drawing.Icon)
        Me.AppTray.Text = "WLAN Hotspot Creator"
        '
        'TrayMenuStrip
        '
        Me.TrayMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartTrayMenuItm, Me.StopTrayMenuItm, Me.OpenAppTrayMenuItm, Me.ExitTrayMenuItm})
        Me.TrayMenuStrip.Name = "TrayMenuStrip"
        Me.TrayMenuStrip.ShowImageMargin = False
        Me.TrayMenuStrip.Size = New System.Drawing.Size(143, 92)
        '
        'StartTrayMenuItm
        '
        Me.StartTrayMenuItm.Name = "StartTrayMenuItm"
        Me.StartTrayMenuItm.Size = New System.Drawing.Size(142, 22)
        Me.StartTrayMenuItm.Text = "&Start Hotspot"
        '
        'StopTrayMenuItm
        '
        Me.StopTrayMenuItm.Name = "StopTrayMenuItm"
        Me.StopTrayMenuItm.Size = New System.Drawing.Size(142, 22)
        Me.StopTrayMenuItm.Text = "St&op Hotspot"
        '
        'OpenAppTrayMenuItm
        '
        Me.OpenAppTrayMenuItm.Name = "OpenAppTrayMenuItm"
        Me.OpenAppTrayMenuItm.Size = New System.Drawing.Size(142, 22)
        Me.OpenAppTrayMenuItm.Text = "Open &Application"
        '
        'ExitTrayMenuItm
        '
        Me.ExitTrayMenuItm.Name = "ExitTrayMenuItm"
        Me.ExitTrayMenuItm.Size = New System.Drawing.Size(142, 22)
        Me.ExitTrayMenuItm.Text = "&Exit"
        '
        'ConsoleThread
        '
        '
        'MainDialogToolTip
        '
        Me.MainDialogToolTip.BackColor = System.Drawing.Color.White
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(145, 49)
        Me.passwordTextBox.MaxLength = 64
        Me.passwordTextBox.Name = "passwordTextBox"
        Me.passwordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.passwordTextBox.Size = New System.Drawing.Size(197, 20)
        Me.passwordTextBox.TabIndex = 2
        Me.MainDialogToolTip.SetToolTip(Me.passwordTextBox, "Password must be with in 64 characters" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and a minimum length of 8 characters!")
        '
        'ssidTextBox
        '
        Me.ssidTextBox.Location = New System.Drawing.Point(145, 14)
        Me.ssidTextBox.MaxLength = 32
        Me.ssidTextBox.Name = "ssidTextBox"
        Me.ssidTextBox.Size = New System.Drawing.Size(305, 20)
        Me.ssidTextBox.TabIndex = 1
        Me.MainDialogToolTip.SetToolTip(Me.ssidTextBox, "SSID must be with in 32 characters" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and a minimum length of 1 characters!")
        '
        'connectionComboBox
        '
        Me.connectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.connectionComboBox.FormattingEnabled = True
        Me.connectionComboBox.Location = New System.Drawing.Point(145, 86)
        Me.connectionComboBox.Name = "connectionComboBox"
        Me.connectionComboBox.Size = New System.Drawing.Size(270, 21)
        Me.connectionComboBox.Sorted = True
        Me.connectionComboBox.TabIndex = 5
        Me.MainDialogToolTip.SetToolTip(Me.connectionComboBox, "Select a network to be shared from the list" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "if you want to create a lan and not " &
        "to share" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "any existing network's internet connection" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "select local lan from the " &
        "list")
        '
        'refreshConnectionButton
        '
        Me.refreshConnectionButton.BackgroundImage = CType(resources.GetObject("refreshConnectionButton.BackgroundImage"), System.Drawing.Image)
        Me.refreshConnectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.refreshConnectionButton.Location = New System.Drawing.Point(418, 85)
        Me.refreshConnectionButton.Margin = New System.Windows.Forms.Padding(0)
        Me.refreshConnectionButton.Name = "refreshConnectionButton"
        Me.refreshConnectionButton.Size = New System.Drawing.Size(32, 23)
        Me.refreshConnectionButton.TabIndex = 4
        Me.refreshConnectionButton.UseVisualStyleBackColor = True
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(377, 127)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(73, 23)
        Me.startButton.TabIndex = 6
        Me.startButton.Text = "&Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'connectionLabel
        '
        Me.connectionLabel.AutoSize = True
        Me.connectionLabel.Location = New System.Drawing.Point(21, 89)
        Me.connectionLabel.Name = "connectionLabel"
        Me.connectionLabel.Size = New System.Drawing.Size(104, 13)
        Me.connectionLabel.TabIndex = 0
        Me.connectionLabel.Text = "Shared Connection: "
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Location = New System.Drawing.Point(21, 52)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(59, 13)
        Me.passwordLabel.TabIndex = 0
        Me.passwordLabel.Text = "Password: "
        '
        'ssidLabel
        '
        Me.ssidLabel.AutoSize = True
        Me.ssidLabel.Location = New System.Drawing.Point(21, 17)
        Me.ssidLabel.Name = "ssidLabel"
        Me.ssidLabel.Size = New System.Drawing.Size(118, 13)
        Me.ssidLabel.TabIndex = 0
        Me.ssidLabel.Text = "Network Name (SSID): "
        '
        'ShowPasswordChkBox
        '
        Me.ShowPasswordChkBox.AutoSize = True
        Me.ShowPasswordChkBox.Location = New System.Drawing.Point(348, 52)
        Me.ShowPasswordChkBox.Name = "ShowPasswordChkBox"
        Me.ShowPasswordChkBox.Size = New System.Drawing.Size(102, 17)
        Me.ShowPasswordChkBox.TabIndex = 3
        Me.ShowPasswordChkBox.Text = "Show Password"
        Me.ShowPasswordChkBox.UseVisualStyleBackColor = True
        '
        'StatusLbl
        '
        Me.StatusLbl.AutoSize = True
        Me.StatusLbl.Location = New System.Drawing.Point(21, 132)
        Me.StatusLbl.Name = "StatusLbl"
        Me.StatusLbl.Size = New System.Drawing.Size(0, 13)
        Me.StatusLbl.TabIndex = 0
        '
        'CurrentRegistryWriteThread
        '
        '
        'IcsRefreshThread
        '
        '
        'IcsConnectThread
        '
        '
        'MainDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 171)
        Me.Controls.Add(Me.StatusLbl)
        Me.Controls.Add(Me.ShowPasswordChkBox)
        Me.Controls.Add(Me.refreshConnectionButton)
        Me.Controls.Add(Me.connectionComboBox)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.connectionLabel)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.ssidLabel)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.ssidTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(485, 210)
        Me.MinimumSize = New System.Drawing.Size(485, 210)
        Me.Name = "MainDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WLAN Hotspot Creator"
        CType(Me.VisualStyler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TrayMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents VisualStyler As SkinSoft.VisualStyler.VisualStyler
    Private WithEvents refreshConnectionButton As Button
    Private WithEvents connectionComboBox As ComboBox
    Private WithEvents connectionLabel As Label
    Private WithEvents passwordLabel As Label
    Private WithEvents ssidLabel As Label
    Private WithEvents MainDialogToolTip As ToolTip
    Private WithEvents AppTray As NotifyIcon
    Private WithEvents StartTrayMenuItm As ToolStripMenuItem
    Private WithEvents StopTrayMenuItm As ToolStripMenuItem
    Private WithEvents OpenAppTrayMenuItm As ToolStripMenuItem
    Private WithEvents ExitTrayMenuItm As ToolStripMenuItem
    Friend WithEvents StatusLbl As Label
    Friend WithEvents ShowPasswordChkBox As CheckBox
    Private WithEvents CurrentRegistryWriteThread As System.ComponentModel.BackgroundWorker
    Public WithEvents startButton As Button
    Public WithEvents passwordTextBox As TextBox
    Public WithEvents ssidTextBox As TextBox
    Private WithEvents TrayMenuStrip As ContextMenuStrip
    Private WithEvents IcsRefreshThread As System.ComponentModel.BackgroundWorker
    Private WithEvents IcsConnectThread As System.ComponentModel.BackgroundWorker
    Private WithEvents ConsoleThread As System.ComponentModel.BackgroundWorker
End Class
