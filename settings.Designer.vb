<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(form2))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.username = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lang = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dl = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ll = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fyp = New System.Windows.Forms.TextBox()
        Me.fy = New System.Windows.Forms.TextBox()
        Me.fc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ok = New System.Windows.Forms.Button()
        Me.cancel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(296, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "اسم المهندس:"
        '
        'username
        '
        Me.username.Location = New System.Drawing.Point(151, 6)
        Me.username.Name = "username"
        Me.username.Size = New System.Drawing.Size(139, 20)
        Me.username.TabIndex = 1
        Me.username.Text = "Saad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(296, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "اللغة:"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(390, 273)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.lang)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.username)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(382, 247)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "أساسية"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lang
        '
        Me.lang.FormattingEnabled = True
        Me.lang.Items.AddRange(New Object() {"عربي", "English"})
        Me.lang.Location = New System.Drawing.Point(151, 140)
        Me.lang.Name = "lang"
        Me.lang.Size = New System.Drawing.Size(139, 21)
        Me.lang.TabIndex = 3
        Me.lang.Text = "اختر لغتك"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(382, 247)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "تصميمية"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.dl)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.ll)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 123)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 113)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "تصعيد الحمولات:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(84, 80)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(80, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "حسب الكود"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dl
        '
        Me.dl.Location = New System.Drawing.Point(107, 45)
        Me.dl.Name = "dl"
        Me.dl.Size = New System.Drawing.Size(57, 20)
        Me.dl.TabIndex = 7
        Me.dl.Text = "1.4"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(217, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(145, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "معامل تصعيد الحمولات الميتة:"
        '
        'll
        '
        Me.ll.Location = New System.Drawing.Point(107, 13)
        Me.ll.Name = "ll"
        Me.ll.Size = New System.Drawing.Size(57, 20)
        Me.ll.TabIndex = 5
        Me.ll.Text = "1.7"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(221, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "معامل تصعيد الحمولات الحية:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.fyp)
        Me.GroupBox1.Controls.Add(Me.fy)
        Me.GroupBox1.Controls.Add(Me.fc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(368, 109)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "المقاومات:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Mpa"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Mpa"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(52, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Mpa"
        '
        'fyp
        '
        Me.fyp.Location = New System.Drawing.Point(107, 83)
        Me.fyp.Name = "fyp"
        Me.fyp.Size = New System.Drawing.Size(57, 20)
        Me.fyp.TabIndex = 6
        Me.fyp.Text = "240"
        '
        'fy
        '
        Me.fy.Location = New System.Drawing.Point(107, 46)
        Me.fy.Name = "fy"
        Me.fy.Size = New System.Drawing.Size(57, 20)
        Me.fy.TabIndex = 5
        Me.fy.Text = "400"
        '
        'fc
        '
        Me.fc.Location = New System.Drawing.Point(107, 13)
        Me.fc.Name = "fc"
        Me.fc.Size = New System.Drawing.Size(57, 20)
        Me.fc.TabIndex = 4
        Me.fc.Text = "20"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(196, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "إجهاد الخضوع لفولاذ الأساور (Fyp):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(234, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "إجهاد الخضوع للفولاذ (Fy):"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(206, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "المقاومة المميزة للخرسانة (F'c):"
        '
        'ok
        '
        Me.ok.Location = New System.Drawing.Point(290, 280)
        Me.ok.Name = "ok"
        Me.ok.Size = New System.Drawing.Size(88, 30)
        Me.ok.TabIndex = 6
        Me.ok.Text = "موافق"
        Me.ok.UseVisualStyleBackColor = True
        '
        'cancel
        '
        Me.cancel.Location = New System.Drawing.Point(196, 280)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(88, 30)
        Me.cancel.TabIndex = 7
        Me.cancel.Text = "إلغاء الأمر"
        Me.cancel.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.CivilEngCalc.My.Resources.Resources.icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 142)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(296, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "اسم المشروع:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(151, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(139, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "مشروع جديد"
        '
        'form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 322)
        Me.Controls.Add(Me.cancel)
        Me.Controls.Add(Me.ok)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الاعدادات"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents username As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lang As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents fyp As System.Windows.Forms.TextBox
    Friend WithEvents fy As System.Windows.Forms.TextBox
    Friend WithEvents fc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dl As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ll As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ok As System.Windows.Forms.Button
    Friend WithEvents cancel As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
