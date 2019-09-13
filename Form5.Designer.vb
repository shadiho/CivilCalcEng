<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.تصديرالجدولإلىMSExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.طباعةالجدولToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.حذفالصفالمحددToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.تفريغالجدولToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column6, Me.Column5, Me.Column3, Me.Column4, Me.Column7, Me.Column8})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.Size = New System.Drawing.Size(843, 243)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.Gray
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Maroon
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column1.HeaderText = "اسم المقطع"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.Silver
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column2.HeaderText = "الوزن الذاتي"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.Silver
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle19
        Me.Column6.HeaderText = "عزم العطالة"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.Silver
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column5.HeaderText = "مساحة المقطع"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Silver
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle21
        Me.Column3.HeaderText = "الحمولة"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.Silver
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle22
        Me.Column4.HeaderText = "العزم المطبق"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.Silver
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle23
        Me.Column7.HeaderText = "مساحة التسليح"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.Silver
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle24
        Me.Column8.HeaderText = "التسليح العملي"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripSplitButton1, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 246)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(843, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(158, 17)
        Me.ToolStripStatusLabel1.Text = "فقط يمكنك تعديل اسم المقطع"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel2.Text = "|||"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.تصديرالجدولإلىMSExcelToolStripMenuItem, Me.طباعةالجدولToolStripMenuItem, Me.حذفالصفالمحددToolStripMenuItem, Me.تفريغالجدولToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(90, 20)
        Me.ToolStripSplitButton1.Text = "حدد الإجراء"
        '
        'تصديرالجدولإلىMSExcelToolStripMenuItem
        '
        Me.تصديرالجدولإلىMSExcelToolStripMenuItem.Image = CType(resources.GetObject("تصديرالجدولإلىMSExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.تصديرالجدولإلىMSExcelToolStripMenuItem.Name = "تصديرالجدولإلىMSExcelToolStripMenuItem"
        Me.تصديرالجدولإلىMSExcelToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.تصديرالجدولإلىMSExcelToolStripMenuItem.Text = "تصدير الجدول إلى MS Excel"
        '
        'طباعةالجدولToolStripMenuItem
        '
        Me.طباعةالجدولToolStripMenuItem.Image = CType(resources.GetObject("طباعةالجدولToolStripMenuItem.Image"), System.Drawing.Image)
        Me.طباعةالجدولToolStripMenuItem.Name = "طباعةالجدولToolStripMenuItem"
        Me.طباعةالجدولToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.طباعةالجدولToolStripMenuItem.Text = "طباعة الجدول"
        '
        'حذفالصفالمحددToolStripMenuItem
        '
        Me.حذفالصفالمحددToolStripMenuItem.Image = CType(resources.GetObject("حذفالصفالمحددToolStripMenuItem.Image"), System.Drawing.Image)
        Me.حذفالصفالمحددToolStripMenuItem.Name = "حذفالصفالمحددToolStripMenuItem"
        Me.حذفالصفالمحددToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.حذفالصفالمحددToolStripMenuItem.Text = "حذف الصف المحدد"
        '
        'تفريغالجدولToolStripMenuItem
        '
        Me.تفريغالجدولToolStripMenuItem.Image = CType(resources.GetObject("تفريغالجدولToolStripMenuItem.Image"), System.Drawing.Image)
        Me.تفريغالجدولToolStripMenuItem.Name = "تفريغالجدولToolStripMenuItem"
        Me.تفريغالجدولToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.تفريغالجدولToolStripMenuItem.Text = "تفريغ الجدول"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel3.Text = "|||"
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(163, 249)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(134, 17)
        Me.RadioButton2.TabIndex = 9
        Me.RadioButton2.Text = "تنفيذي(لا يمكن التراجع)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(325, 249)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton1.TabIndex = 8
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "حسابي"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 268)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "جدول مقاطع الانعطاف"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents تصديرالجدولإلىMSExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents طباعةالجدولToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents حذفالصفالمحددToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents تفريغالجدولToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
