<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VirtualAdapterSelectionDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VirtualAdapterSelectionDialog))
        Me.IcsVirtualAdapterIdComboBox = New System.Windows.Forms.ComboBox()
        Me.selectButton = New System.Windows.Forms.Button()
        Me.SelectConnectionLabel = New System.Windows.Forms.Label()
        Me.VisualStyler = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        CType(Me.VisualStyler, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IcsVirtualAdapterIdComboBox
        '
        Me.IcsVirtualAdapterIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IcsVirtualAdapterIdComboBox.FormattingEnabled = True
        Me.IcsVirtualAdapterIdComboBox.Location = New System.Drawing.Point(20, 44)
        Me.IcsVirtualAdapterIdComboBox.Name = "IcsVirtualAdapterIdComboBox"
        Me.IcsVirtualAdapterIdComboBox.Size = New System.Drawing.Size(270, 21)
        Me.IcsVirtualAdapterIdComboBox.Sorted = True
        Me.IcsVirtualAdapterIdComboBox.TabIndex = 8
        '
        'selectButton
        '
        Me.selectButton.Location = New System.Drawing.Point(217, 71)
        Me.selectButton.Name = "selectButton"
        Me.selectButton.Size = New System.Drawing.Size(73, 23)
        Me.selectButton.TabIndex = 9
        Me.selectButton.Text = "&Select"
        Me.selectButton.UseVisualStyleBackColor = True
        '
        'SelectConnectionLabel
        '
        Me.SelectConnectionLabel.AutoSize = True
        Me.SelectConnectionLabel.Location = New System.Drawing.Point(17, 15)
        Me.SelectConnectionLabel.Name = "SelectConnectionLabel"
        Me.SelectConnectionLabel.Size = New System.Drawing.Size(225, 26)
        Me.SelectConnectionLabel.TabIndex = 7
        Me.SelectConnectionLabel.Text = "Multiple virtual network adapters are detected!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select any one from the list: "
        '
        'VisualStyler
        '
        Me.VisualStyler.HostForm = Me
        Me.VisualStyler.License = CType(resources.GetObject("VisualStyler.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Medium
        Me.VisualStyler.LoadVisualStyle(Nothing, "XP Royale (Black).vssf")
        '
        'VirtualAdapterSelectionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 106)
        Me.ControlBox = False
        Me.Controls.Add(Me.IcsVirtualAdapterIdComboBox)
        Me.Controls.Add(Me.selectButton)
        Me.Controls.Add(Me.SelectConnectionLabel)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(325, 145)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(325, 145)
        Me.Name = "VirtualAdapterSelectionDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "                  Multiple Virtual Adapter(s)"
        CType(Me.VisualStyler, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents IcsVirtualAdapterIdComboBox As ComboBox
    Public WithEvents selectButton As Button
    Private WithEvents SelectConnectionLabel As Label
    Friend WithEvents VisualStyler As SkinSoft.VisualStyler.VisualStyler
End Class
