<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowCompanies
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShowCompanies))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FinacleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateCompanyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModifyCompanyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunQueryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeFinanacialYearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 599)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1362, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1362, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FinacleToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1362, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FinacleToolStripMenuItem
        '
        Me.FinacleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateCompanyToolStripMenuItem, Me.ModifyCompanyToolStripMenuItem, Me.RunQueryToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ChangeFinanacialYearToolStripMenuItem})
        Me.FinacleToolStripMenuItem.Name = "FinacleToolStripMenuItem"
        Me.FinacleToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.FinacleToolStripMenuItem.Text = "&Company"
        '
        'CreateCompanyToolStripMenuItem
        '
        Me.CreateCompanyToolStripMenuItem.Name = "CreateCompanyToolStripMenuItem"
        Me.CreateCompanyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.CreateCompanyToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.CreateCompanyToolStripMenuItem.Text = "Create Company"
        '
        'ModifyCompanyToolStripMenuItem
        '
        Me.ModifyCompanyToolStripMenuItem.Name = "ModifyCompanyToolStripMenuItem"
        Me.ModifyCompanyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ModifyCompanyToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ModifyCompanyToolStripMenuItem.Text = "Modify Company"
        '
        'RunQueryToolStripMenuItem
        '
        Me.RunQueryToolStripMenuItem.Name = "RunQueryToolStripMenuItem"
        Me.RunQueryToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.RunQueryToolStripMenuItem.Text = "Run Query"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ChangeFinanacialYearToolStripMenuItem
        '
        Me.ChangeFinanacialYearToolStripMenuItem.Name = "ChangeFinanacialYearToolStripMenuItem"
        Me.ChangeFinanacialYearToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.ChangeFinanacialYearToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.ChangeFinanacialYearToolStripMenuItem.Text = "Change Financial Year"
        '
        'ShowCompanies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1362, 621)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "ShowCompanies"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atithi #181101"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FinacleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateCompanyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifyCompanyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunQueryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeFinanacialYearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
