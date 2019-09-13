<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.تصديرالجدولإلىMSExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.طباعةالجدولToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.حذفالصفالمحددToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.تفريغالجدولToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column9, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle47
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.DataGridView1.Size = New System.Drawing.Size(932, 308)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        DataGridViewCellStyle38.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.White
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle38
        Me.Column1.HeaderText = "اسم العامود"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 88
        '
        'Column2
        '
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.Silver
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle39
        Me.Column2.HeaderText = "القوة المطبقة"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.Silver
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle40
        Me.Column3.HeaderText = "نوع العامود"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        DataGridViewCellStyle41.BackColor = System.Drawing.Color.Silver
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle41
        Me.Column4.HeaderText = "عدد الطوابق"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle42.BackColor = System.Drawing.Color.Silver
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle42
        Me.Column5.HeaderText = "مساحة المقطع"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle43.BackColor = System.Drawing.Color.Silver
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle43
        Me.Column9.HeaderText = "أبعاد المقطع"
        Me.Column9.Name = "Column9"
        '
        'Column6
        '
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.Silver
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle44
        Me.Column6.HeaderText = "مساحة التسليح"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.Silver
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle45
        Me.Column7.HeaderText = "تسليح عملي"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        DataGridViewCellStyle46.BackColor = System.Drawing.Color.Silver
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle46
        Me.Column8.HeaderText = "تسليح الأساور"
        Me.Column8.Name = "Column8"
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripSplitButton1, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 311)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(932, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(447, 17)
        Me.ToolStripStatusLabel1.Text = "يمكن تعديل بعض البيانات مثل اسم العامود ونوعه وأبعاد المقطع والتسليح العملي والأس" & _
            "اور"
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
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(242, 314)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "حسابي"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(80, 314)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(134, 17)
        Me.RadioButton2.TabIndex = 7
        Me.RadioButton2.Text = "تنفيذي(لا يمكن التراجع)"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 333)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "جدول الأعمدة"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents تصديرالجدولإلىMSExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents طباعةالجدولToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents حذفالصفالمحددToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents تفريغالجدولToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
End Class
