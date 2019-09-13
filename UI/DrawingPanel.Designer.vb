<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DrawingPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.drwPanel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'drwPanel
        '
        Me.drwPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.drwPanel.Location = New System.Drawing.Point(0, 0)
        Me.drwPanel.Name = "drwPanel"
        Me.drwPanel.Size = New System.Drawing.Size(853, 489)
        Me.drwPanel.TabIndex = 0
        '
        'DrawingPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.drwPanel)
        Me.Name = "DrawingPanel"
        Me.Size = New System.Drawing.Size(853, 489)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents drwPanel As Panel
End Class
