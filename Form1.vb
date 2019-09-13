Imports AutoCAD

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database4DataSet.beam1' table. You can move, or remove it, as needed.
        Me.KeyPreview = True
        fc = My.Settings.fc
        fy = My.Settings.fy
        fyp = My.Settings.fyp
        ll = My.Settings.ll
        dl = My.Settings.dl
        username = My.Settings.username
        ToolStripTextBox1.Text = My.Settings.projectname
        ToolStripTextBox2.Text = username
        RichTextBox3.Text = "Welcome Eng." & username
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox1.Text = My.Settings.fc
            TextBox2.Text = My.Settings.fy
            TextBox3.Text = My.Settings.fyp
        Else
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If
    End Sub

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ke, max, fc, fy, nu As Double
        If TextBox1.Text = "" Then
            MsgBox("ادخل قيمة fc", vbExclamation, "خطأ")
        ElseIf TextBox2.Text = "" Then
            MsgBox("ادخل قيمة fy", vbExclamation, "خطأ")
        ElseIf TextBox3.Text = "" Then
            MsgBox("ادخل قيمة fyp", vbExclamation, "خطأ")
        ElseIf roofs.Text = "" Then
            MsgBox("ادخل عدد الطوابق", vbExclamation, "خطأ")
        ElseIf ComboBox4.SelectedItem = "" Then
            MsgBox("اختر نوع العامود", vbExclamation, "خطأ")
        ElseIf ComboBox2.SelectedItem = "" Then
            MsgBox("اختر نوع الحساب", vbExclamation, "خطأ")
        ElseIf nuu.Text = "" Then
            MsgBox("أدخل الحمولة", vbExclamation, "خطأ")
        Else
            'حساب قيمة ke
            If ComboBox4.SelectedItem = "وسطي" Then
                If ComboBox1.SelectedItem = "الطابق الأخير" Then
                    ke = 1.3
                ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                    ke = 1.1
                ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                    ke = 1
                End If
            End If
            '======================================
            If ComboBox4.SelectedItem = "طرفي" Then
                If ComboBox1.SelectedItem = "الطابق الأخير" Then
                    ke = 1.6
                ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                    ke = 1.4
                ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                    ke = 1.15
                End If
            End If
            '======================================
            If ComboBox4.SelectedItem = "ركني" Then
                If ComboBox1.SelectedItem = "الطابق الأخير" Then
                    ke = 2
                ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                    ke = 1.7
                ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                    ke = 1.3
                End If
            End If
            '======================================
            'البلاطة الظفرية
            If CheckBox1.Checked Then
                If ComboBox4.SelectedItem = "وسطي" Then
                    If ComboBox1.SelectedItem = "الطابق الأخير" Then
                        ke = 1.3
                    ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                        ke = 1.1
                    ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                        ke = 1
                    End If
                End If
                '=====================================
                If ComboBox4.SelectedItem = "طرفي" Then
                    If ComboBox1.SelectedItem = "الطابق الأخير" Then
                        ke = 1.5
                    ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                        ke = 1.3
                    ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                        ke = 1.1
                    End If
                End If
                '=====================================
                If ComboBox4.SelectedItem = "ركني" Then
                    If ComboBox1.SelectedItem = "الطابق الأخير" Then
                        ke = 1.6
                    ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                        ke = 1.4
                    ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                        ke = 1.2
                    End If
                End If
            End If
            '======================================
            'تعريف المعطيات
1:          fc = TextBox1.Text
            fy = TextBox2.Text
            fyp = TextBox3.Text
            nu = 1.1 * nuu.Text * roofs.Text
            'حساب تسليح
            If ComboBox2.SelectedItem = "حساب تسليح" Then
                If TextBox4.Text = "" Then
                    MsgBox("أبعاد العامود ناقصة", vbExclamation, "خطأ")
                ElseIf TextBox5.Text = "" Then
                    MsgBox("أبعاد العامود ناقصة", vbExclamation, "خطأ")
                Else
                    Dim s, ac As Double
                    ac = (TextBox4.Text) * (TextBox5.Text)
                    s = ((nu * 10 ^ 3) - ((0.8 * 0.65) / ke) * (0.85 * fc * ac)) / (((0.8 * 0.65) / ke) * fy)
                    My.Settings.ass = s
                    If s > 0.025 * ac * 100 Then
                        MsgBox("المقطع بحاجة لتسليح حلزوني", vbExclamation, "تسليح حلزوني")
                        Button14.Visible = True
                    Else
                        Button14.Visible = False
                        TextBox6.Text = Math.Round(s, 2)
                        TextBox8.Text = ac
                        Dim n, fi As Double
                        n = (Math.Ceiling(TextBox4.Text / 30) + Math.Ceiling(TextBox5.Text / 30)) * 2
                        fi = Math.Sqrt((s * 4) / (n * Math.PI))
                        If fi <= 12 Then
                            fi = 12
                        ElseIf fi <= 14 Then
                            fi = 14
                        ElseIf fi <= 16 Then
                            fi = 16
                        ElseIf fi <= 18 Then
                            fi = 18
                        ElseIf fi <= 20 Then
                            fi = 20
                        ElseIf fi <= 22 Then
                            fi = 22
                        ElseIf fi <= 25 Then
                            fi = 25
                        ElseIf fi <= 28 Then
                            fi = 28
                        ElseIf fi <= 30 Then
                            fi = 30
                        ElseIf fi <= 32 Then
                            fi = 32
                        ElseIf fi <= 40 Then
                            fi = 40
                        End If
                        If fi > 40 Then
                            n = Math.Ceiling((s * 4) / (Math.PI * 25 ^ 2))
                            fi = 25
                        End If
                        TextBox11.Text = n & "T" & fi
                        TextBox10.Text = TextBox4.Text & "*" & TextBox5.Text
                        'حساب تسليح الاساور
                        Dim l, si As Double
                        l = (1 / 3) * fi
                        si = 6
                        If l > si Then
                            si = l
                        End If

                        If si <= 6 Then
                            si = 6
                        ElseIf si <= 8 Then
                            si = 8
                        ElseIf si <= 10 Then
                            si = 10
                        ElseIf si <= 12 Then
                            si = 12
                        ElseIf si > 12 Then
                            MessageBox.Show("لا يجب أن يكون قطر الأساور أكبر من 12")
                            si = Math.Round(si)
                        End If

                        Dim ri, v, x, z As Double
                        v = 15 * fi
                        x = TextBox4.Text
                        z = 300
                        If v <= z Then
                            ri = v
                        ElseIf z <= v Then
                            ri = z
                        ElseIf v <= x Then
                            ri = v
                        ElseIf z <= x Then
                            ri = z
                        ElseIf x <= z Then
                            ri = x
                        ElseIf x <= v Then
                            ri = x
                        End If
                        If ri > 0 And ri < 50 Then
                            ri = 50
                        ElseIf ri >= 50 And ri < 100 Then
                            ri = 50
                        ElseIf ri >= 100 And ri < 150 Then
                            ri = 100
                        ElseIf ri >= 150 And ri < 200 Then
                            ri = 150
                        ElseIf ri >= 200 And ri < 250 Then
                            ri = 200
                        ElseIf ri >= 250 And ri < 300 Then
                            ri = 250
                        ElseIf ri >= 300 Then
                            ri = 300
                        End If
                        TextBox13.Text = "Ф" & si & "/" & Math.Round(ri / 10) & "cm"
                        'Table
                        If Form4.RadioButton1.Checked = True Then
                            Dim rowNum As Integer = Form4.DataGridView1.Rows.Add
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox108.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(1).Value = nuu.Text * roofs.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(2).Value = ComboBox4.SelectedItem
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(3).Value = roofs.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(4).Value = TextBox8.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(5).Value = TextBox10.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(6).Value = TextBox6.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(7).Value = TextBox11.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(8).Value = TextBox13.Text
                            ToolStrip3.Visible = True
                        ElseIf Form4.RadioButton2.Checked = True Then
                            Dim rowNum As Integer = Form4.DataGridView1.Rows.Add
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox108.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(1).Value = TextBox10.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(2).Value = TextBox11.Text
                            Form4.DataGridView1.Rows.Item(rowNum).Cells(3).Value = TextBox13.Text
                            ToolStrip3.Visible = True
                        End If
                    End If
                End If
            End If
            '=====================================
            'حساب مقطع
            If ComboBox2.SelectedItem = "حساب مقطع" Then
                If ComboBox3.SelectedItem = "" Then
                    MsgBox("اختر نسبة التسليح", vbExclamation, "خطأ")

                    'نسبة تسليح دنيا
                ElseIf ComboBox3.SelectedItem = "دنيا" Then
                    max = ((nu * 10 ^ 3) / ((0.8 * 0.65 / ke) * (0.85 * fc + fy * 0.01)))
                    Dim a, b As Double
                    a = 0.01 * max
                    b = 0.006 * 90000
                    If a > b Then
                        TextBox6.Text = Math.Round(a, 2)
                    ElseIf b > a Then
                        TextBox6.Text = Math.Round(b, 2)
                    End If
                    If max > 90000 Then
                        TextBox8.Text = Math.Round(max, 2)
                    Else
                        TextBox8.Text = 90000
                    End If
                    Dim n, fi, bb, ll As Double
                    bb = TextBox109.Text
                    ll = TextBox8.Text / TextBox109.Text
                    n = Math.Ceiling(((bb - 6) / 300) * 2 + ((ll - 6) / 300) * 2)
                    fi = Math.Sqrt((TextBox6.Text * 4) / (n * Math.PI))
                    If fi <= 12 Then
                        fi = 12
                    ElseIf fi <= 14 Then
                        fi = 14
                    ElseIf fi <= 16 Then
                        fi = 16
                    ElseIf fi <= 18 Then
                        fi = 18
                    ElseIf fi <= 20 Then
                        fi = 20
                    ElseIf fi <= 22 Then
                        fi = 22
                    ElseIf fi <= 25 Then
                        fi = 25
                    ElseIf fi <= 28 Then
                        fi = 28
                    ElseIf fi <= 30 Then
                        fi = 30
                    ElseIf fi <= 32 Then
                        fi = 32
                    ElseIf fi <= 40 Then
                        fi = 40
                    End If
                    If fi > 40 Then
                        n = Math.Ceiling((TextBox6.Text * 4) / (Math.PI * 25 ^ 2))
                        fi = 25
                    End If
                    TextBox11.Text = n & "T" & fi
                    TextBox10.Text = Math.Round(bb / 10, 0) & "*" & Math.Round(ll / 10, 0)
                    'حساب تسليح الاساور
                    Dim l, si As Double
                    l = (1 / 3) * fi
                    si = 6
                    If l > si Then
                        si = l
                    End If

                    If si <= 6 Then
                        si = 6
                    ElseIf si <= 8 Then
                        si = 8
                    ElseIf si <= 10 Then
                        si = 10
                    ElseIf si <= 12 Then
                        si = 12
                    ElseIf si > 12 Then
                        MessageBox.Show("لا يجب أن يكون قطر الأساور أكبر من 12")
                        si = Math.Round(si)
                    End If

                    Dim ri, v, x, z As Double
                    v = 15 * fi
                    x = Math.Sqrt(TextBox8.Text)
                    z = 300
                    If v <= z Then
                        ri = v
                    ElseIf z <= v Then
                        ri = z
                    ElseIf v <= x Then
                        ri = v
                    ElseIf z <= x Then
                        ri = z
                    ElseIf x <= z Then
                        ri = x
                    ElseIf x <= v Then
                        ri = x
                    End If
                    If ri > 0 And ri < 50 Then
                        ri = 50
                    ElseIf ri >= 50 And ri < 100 Then
                        ri = 50
                    ElseIf ri >= 100 And ri < 150 Then
                        ri = 100
                    ElseIf ri >= 150 And ri < 200 Then
                        ri = 150
                    ElseIf ri >= 200 And ri < 250 Then
                        ri = 200
                    ElseIf ri >= 250 And ri < 300 Then
                        ri = 250
                    ElseIf ri >= 300 Then
                        ri = 300
                    End If
                    TextBox13.Text = "Ф" & si & "/" & Math.Round(ri / 10) & "cm"
                    'Table
                    If Form4.RadioButton1.Checked = True Then
                        Dim rowNum As Integer = Form4.DataGridView1.Rows.Add
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox108.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(1).Value = nuu.Text * roofs.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(2).Value = ComboBox4.SelectedItem
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(3).Value = roofs.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(4).Value = TextBox8.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(5).Value = TextBox10.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(6).Value = TextBox6.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(7).Value = TextBox11.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(8).Value = TextBox13.Text
                        ToolStrip3.Visible = True
                    ElseIf Form4.RadioButton2.Checked = True Then
                        Dim rowNum As Integer = Form4.DataGridView1.Rows.Add
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox108.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(1).Value = TextBox10.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(2).Value = TextBox11.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(3).Value = TextBox13.Text
                        ToolStrip3.Visible = True
                    End If
                    '===========================================
                    'نسبة تسليح عليا
                ElseIf ComboBox3.SelectedItem = "عليا" Then
                    max = ((nu * 10 ^ 3) / ((0.8 * 0.65 / ke) * (0.85 * fc + fy * 0.025)))
                    Dim a, b As Double
                    a = 0.025 * max
                    b = 0.006 * 90000
                    If a > b Then
                        TextBox6.Text = Math.Round(a, 2)
                    ElseIf b > a Then
                        TextBox6.Text = Math.Round(b, 2)
                    End If
                    If max > 90000 Then
                        TextBox8.Text = Math.Round(max, 2)
                    Else
                        TextBox8.Text = 90000
                    End If
                    Dim n, fi As Double
                    n = Math.Ceiling(Math.Sqrt(TextBox8.Text) / 300) * 4
                    fi = Math.Sqrt((TextBox6.Text * 4) / (n * Math.PI))
                    If fi <= 12 Then
                        fi = 12
                    ElseIf fi <= 14 Then
                        fi = 14
                    ElseIf fi <= 16 Then
                        fi = 16
                    ElseIf fi <= 18 Then
                        fi = 18
                    ElseIf fi <= 20 Then
                        fi = 20
                    ElseIf fi <= 22 Then
                        fi = 22
                    ElseIf fi <= 25 Then
                        fi = 25
                    ElseIf fi <= 28 Then
                        fi = 28
                    ElseIf fi <= 30 Then
                        fi = 30
                    ElseIf fi <= 32 Then
                        fi = 32
                    ElseIf fi <= 40 Then
                        fi = 40
                    End If
                    If fi > 40 Then
                        n = Math.Ceiling((TextBox6.Text * 4) / (Math.PI * 25 ^ 2))
                        fi = 25
                    End If
                    TextBox11.Text = n & "T" & fi
                    TextBox10.Text = Math.Round(Math.Sqrt(TextBox8.Text) / 10, 0) & "*" & Math.Round(Math.Sqrt(TextBox8.Text) / 10, 0)
                    'حساب تسليح الاساور
                    Dim l, si As Double
                    l = (1 / 3) * fi
                    si = 6
                    If l > si Then
                        si = l
                    End If

                    If si <= 6 Then
                        si = 6
                    ElseIf si <= 8 Then
                        si = 8
                    ElseIf si <= 10 Then
                        si = 10
                    ElseIf si <= 12 Then
                        si = 12
                    ElseIf si > 12 Then
                        MessageBox.Show("لا يجب أن يكون قطر الأساور أكبر من 12")
                        si = Math.Round(si)
                    End If

                    Dim ri, v, x, z As Double
                    v = 15 * fi
                    x = Math.Sqrt(TextBox8.Text)
                    z = 300
                    If v <= z Then
                        ri = v
                    ElseIf z <= v Then
                        ri = z
                    ElseIf v <= x Then
                        ri = v
                    ElseIf z <= x Then
                        ri = z
                    ElseIf x <= z Then
                        ri = x
                    ElseIf x <= v Then
                        ri = x
                    End If
                    If ri > 0 And ri < 50 Then
                        ri = 50
                    ElseIf ri >= 50 And ri < 100 Then
                        ri = 50
                    ElseIf ri >= 100 And ri < 150 Then
                        ri = 100
                    ElseIf ri >= 150 And ri < 200 Then
                        ri = 150
                    ElseIf ri >= 200 And ri < 250 Then
                        ri = 200
                    ElseIf ri >= 250 And ri < 300 Then
                        ri = 250
                    ElseIf ri >= 300 Then
                        ri = 300
                    End If
                    TextBox13.Text = "Ф" & si & "/" & Math.Round(ri / 10) & "cm"
                    'Table
                    If Form4.RadioButton1.Checked = True Then
                        Dim rowNum As Integer = Form4.DataGridView1.Rows.Add
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox108.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(1).Value = nuu.Text * roofs.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(2).Value = ComboBox4.SelectedItem
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(3).Value = roofs.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(4).Value = TextBox8.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(5).Value = TextBox10.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(6).Value = TextBox6.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(7).Value = TextBox11.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(8).Value = TextBox13.Text
                        ToolStrip3.Visible = True
                    ElseIf Form4.RadioButton2.Checked = True Then
                        Dim rowNum As Integer = Form4.DataGridView1.Rows.Add
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox108.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(1).Value = TextBox10.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(2).Value = TextBox11.Text
                        Form4.DataGridView1.Rows.Item(rowNum).Cells(3).Value = TextBox13.Text
                        ToolStrip3.Visible = True
                    End If
                End If
            End If
           
        End If
    End Sub
    Private Sub Button14_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim ke, ass, fc, fy, nu As Double
        If TextBox1.Text = "" Then
            MsgBox("ادخل قيمة fc", vbExclamation, "خطأ")
        ElseIf TextBox2.Text = "" Then
            MsgBox("ادخل قيمة fy", vbExclamation, "خطأ")
        ElseIf TextBox3.Text = "" Then
            MsgBox("ادخل قيمة fyp", vbExclamation, "خطأ")
        ElseIf roofs.Text = "" Then
            MsgBox("ادخل عدد الطوابق", vbExclamation, "خطأ")
        ElseIf ComboBox4.SelectedItem = "" Then
            MsgBox("اختر نوع العامود", vbExclamation, "خطأ")
        ElseIf ComboBox2.SelectedItem = "" Then
            MsgBox("اختر نوع الحساب", vbExclamation, "خطأ")
        ElseIf nuu.Text = "" Then
            MsgBox("أدخل الحمولة", vbExclamation, "خطأ")
        Else
            'حساب قيمة ke
            If ComboBox4.SelectedItem = "وسطي" Then
                If ComboBox1.SelectedItem = "الطابق الأخير" Then
                    ke = 1.3
                ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                    ke = 1.1
                ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                    ke = 1
                End If
            End If
            '======================================
            If ComboBox4.SelectedItem = "طرفي" Then
                If ComboBox1.SelectedItem = "الطابق الأخير" Then
                    ke = 1.6
                ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                    ke = 1.4
                ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                    ke = 1.15
                End If
            End If
            '======================================
            If ComboBox4.SelectedItem = "ركني" Then
                If ComboBox1.SelectedItem = "الطابق الأخير" Then
                    ke = 2
                ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                    ke = 1.7
                ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                    ke = 1.3
                End If
            End If
            '======================================
            'البلاطة الظفرية
            If CheckBox1.Checked Then
                If ComboBox4.SelectedItem = "وسطي" Then
                    If ComboBox1.SelectedItem = "الطابق الأخير" Then
                        ke = 1.3
                    ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                        ke = 1.1
                    ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                        ke = 1
                    End If
                End If
                '=====================================
                If ComboBox4.SelectedItem = "طرفي" Then
                    If ComboBox1.SelectedItem = "الطابق الأخير" Then
                        ke = 1.5
                    ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                        ke = 1.3
                    ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                        ke = 1.1
                    End If
                End If
                '=====================================
                If ComboBox4.SelectedItem = "ركني" Then
                    If ComboBox1.SelectedItem = "الطابق الأخير" Then
                        ke = 1.6
                    ElseIf ComboBox1.SelectedItem = "الطابق تحت الأخير" Then
                        ke = 1.4
                    ElseIf ComboBox1.SelectedItem = "باقي الطوابق" Then
                        ke = 1.2
                    End If
                End If
            End If
            '======================================
            'تعريف المعطيات
1:          fc = TextBox1.Text
            fy = TextBox2.Text
            fyp = TextBox3.Text
            nu = nuu.Text * roofs.Text
            Dim d, dk, ak, asp, ss, dh, aas, around As Double
            d = InputBox("أدخل قطر العامود", "قطر العامود", "500")
            ss = InputBox("أدخل خطوة الحلزون", "خطوة الحلزون", "40")
            dh = InputBox("أدخل قطر قضيب الحلزون", "قطر العامود", "8")
            aas = (Math.PI * (dh ^ 2)) / 4
            dk = d - 50
            around = (Math.PI * (d ^ 2)) / 4
            ak = (Math.PI * (dk ^ 2)) / 4
            asp = (Math.PI * dk * aas) / ss
            Dim aspmax, aspmin As Double
            aspmin = 0.45 * ((around / ak) - 1) * (fc / fyp) * ak
            aspmax = 0.34 * ((1.412 * (around / ak) - 1) * (fc / fyp) + 0.484 * (My.Settings.ass / ak) * (fy / fyp)) * ak
            If asp < aspmin Then
                MsgBox("يجب تكبير قطر العامود أو تصغير خطوة الحلزون", vbExclamation, "خطأ")
            ElseIf asp > aspmax Then
                MsgBox("يجب تكبير قطر العامود أو زيادة التسليح الطولي أو تطويق القطاع معدنياً أو استعمال قطاعات داخل المقطع", vbExclamation, "خطأ")
            Else
                ass = ((nu * 10 ^ 3) - ((0.8 * 0.65) / ke) * (0.85 * fc * ak) - ((0.8 * 0.65) / ke) * (2.5 * fyp * asp)) / (((0.8 * 0.65) / ke) * fy)
                TextBox6.Text = Math.Round(ass, 2)
                TextBox8.Text = Math.Round((Math.PI * (d ^ 2)) / 4, 2)
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles roofs.TextChanged, TextBox109.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedItem = "حساب تسليح" Then
            TextBox109.Visible = False
            Label229.Visible = False
            Label230.Visible = False
            TextBox4.Clear()
            TextBox4.Show()
            Label14.Show()
            Label15.Show()
            TextBox5.Show()
            TextBox5.Clear()
            TextBox6.Clear()
            TextBox8.Clear()
            ComboBox3.Hide()
            TextBox4.Enabled = True
            TextBox5.Enabled = True
        ElseIf ComboBox2.SelectedItem = "حساب مقطع" Then
            TextBox109.Visible = True
            Label229.Visible = True
            Label230.Visible = True
            TextBox4.Clear()
            TextBox4.Hide()
            Label14.Hide()
            TextBox8.Clear()
            Label15.Hide()
            TextBox5.Hide()
            TextBox5.Clear()
            TextBox6.Clear()
            ComboBox3.Show()
            TextBox4.Enabled = False
            TextBox5.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            If TextBox6.Text = "" Then
                MsgBox("لم يتم حساب شيء", vbExclamation, "لايوجد تسليح")
                CheckBox3.Checked = False
            Else
                TextBox7.Text = TextBox6.Text
            End If
        ElseIf CheckBox3.Checked = False Then
            TextBox7.Text = ""
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ass, nn, dd As Double
            If TextBox7.Text = "" Then
                MsgBox("أدخل مساحة التسليح", vbExclamation, "خطأ")
            ElseIf TextBox9.Text = "" And TextBox12.Text = "" Then
                MsgBox("أدخل القطر أو العدد", vbExclamation, "خطأ")
            Else
            If TextBox12.Enabled = False Then
                If TextBox9.Text < 4 Then
                    MsgBox("أقل عدد هو 4 للقضبان", vbExclamation, "خطأ")
                Else
                    ass = TextBox7.Text
                    nn = TextBox9.Text
                    dd = Math.Sqrt((ass * 4) / (nn * Math.PI))
                    If dd <= 12 Then
                        dd = 12
                    ElseIf dd <= 14 Then
                        dd = 14
                    ElseIf dd <= 16 Then
                        dd = 16
                    ElseIf dd <= 18 Then
                        dd = 18
                    ElseIf dd <= 20 Then
                        dd = 20
                    ElseIf dd <= 22 Then
                        dd = 22
                    ElseIf dd <= 25 Then
                        dd = 25
                    ElseIf dd <= 28 Then
                        dd = 28
                    ElseIf dd <= 30 Then
                        dd = 30
                    ElseIf dd <= 32 Then
                        dd = 32
                    ElseIf dd <= 40 Then
                        dd = 40
                    ElseIf dd > 40 Then
                        MsgBox("يجب زيادة عدد القضبان", vbExclamation, "قطر القضيب كبير جداً")
                    End If
                End If
                TextBox12.Text = dd
                TextBox9.Enabled = True
            ElseIf TextBox9.Enabled = False Then
                If TextBox12.Text < 12 Then
                    MsgBox("أقل قطر للقضبان هو 12 mm", vbExclamation, "خطأ")
                    ass = TextBox7.Text
                    dd = TextBox12.Text
                    nn = Math.Ceiling((ass * 4) / (Math.PI * dd ^ 2))
                    TextBox9.Text = nn
                    TextBox12.Enabled = True
                End If
            End If
            End If
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
        TextBox12.Enabled = False
        If TextBox9.Text = "" Then
            On Error Resume Next
            TextBox12.Enabled = True
        Else

            TextBox12.Enabled = False
            If TextBox9.Text = "" Then
                TextBox12.Enabled = True
                TextBox12.Text = ""
            End If
        End If
    End Sub

    Private Sub TextBox12_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox12.TextChanged
        TextBox9.Enabled = False
        If TextBox12.Text = "" Then
            On Error Resume Next
            TextBox9.Enabled = True
            TextBox9.Text = ""
        End If
    End Sub

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox14.Text = "" Then
            MsgBox("ادخل عدد العينات", vbExclamation, "Error")

        ElseIf ComboBox5.SelectedItem = "" Then
            MsgBox("اختر كمية الاسمنت", vbExclamation, "Error")

        ElseIf ComboBox7.SelectedItem = "" Then
            MsgBox("اختر الشكل", vbExclamation, "Error")

        ElseIf ComboBox6.SelectedItem = "" Then
            MsgBox("اختر عمر العينة", vbExclamation, "Error")
        Else
            Dim n, i As Integer, sum, fi, segma As Single
            n = TextBox14.Text

1:          Dim a(n) As Single
            For i = 1 To n
                a(i) = InputBox("f(" & i & ")=")
                sum = sum + a(i)
                fi = sum / n
            Next
            For i = 1 To n
                segma = segma + (a(i) - fi) ^ 2
            Next
            Dim s As Double
            s = Math.Sqrt(segma / (n - 1))


            a(1) = fi - 2.33 * s
            a(2) = fi + 2.33 * s

            For i = 1 To n
                If a(i) < a(1) Then
                    s = Math.Sqrt((segma - (a(i) - fi) ^ 2) / (n - 2))
                Else
                    s = s
                End If
                If a(i) > a(2) Then
                    s = Math.Sqrt((segma - (a(i) - fi) ^ 2) / (n - 2))
                Else
                    s = s
                    TextBox4.Text = Math.Round(s, 2)
                End If
            Next
            Dim m, j As Integer, min As Single
            m = 2
            min = a(1)
            For i = 1 To n
                If a(i) < min Then
                    a(i) = min
                End If
            Next

            Dim l(m) As Single
            For j = 1 To 2
                l(1) = fi - 1.1 * s
                l(2) = min / 0.8
            Next
            Dim fc As Double, jim As Single
            jim = l(1)
            For j = 1 To 2
                If l(2) < jim Then
                    jim = l(2)
                Else
                    jim = l(1)
                End If
                fc = jim

                If ComboBox7.SelectedItem = "100 * 100 * 100" Then
                    fc = 0.78 * jim
                End If
                If ComboBox7.SelectedItem = "150 * 150 * 150" Then
                    fc = 0.8 * jim
                End If
                If ComboBox7.SelectedItem = "200*200*200" Then
                    fc = 0.83 * jim
                End If
                If ComboBox7.SelectedItem = "300 * 300 * 300" Then
                    fc = 0.9 * jim
                End If
                If ComboBox7.SelectedItem = "300 * 150 * 150" Then
                    fc = 1 * jim
                End If
                If ComboBox7.SelectedItem = "450 * 150 * 150" Then
                    fc = 1.05 * jim
                End If
                If ComboBox7.SelectedItem = "600 * 200 * 200" Then
                    fc = 1.05 * jim
                End If
                If ComboBox7.SelectedItem = "300 * 150" Then
                    fc = 1 * jim
                End If
                If ComboBox7.SelectedItem = "200 * 100" Then
                    fc = 0.97 * jim
                End If
                If ComboBox7.SelectedItem = "500 * 250" Then
                    fc = 1.05 * jim
                End If
            Next
            If ComboBox6.SelectedItem = "3 days" Then
                fc = 2.5 * fc
            End If
            If ComboBox6.SelectedItem = "7 days" Then
                fc = 1.5 * fc
            End If
            If ComboBox6.SelectedItem = "28 days" Then
                fc = 1 * fc
            End If
            If ComboBox6.SelectedItem = "60 days" Then
                fc = 0.95 * fc
            End If
            If ComboBox6.SelectedItem = "90 days" Then
                fc = 0.9 * fc
            End If
            If ComboBox6.SelectedItem = "360 or more" Then
                fc = 0.8 * fc
            End If
            TextBox15.Text = Math.Round(Math.Round(fc, 1) / 10, 1)
            If ComboBox5.SelectedItem = "100" Then
                If TextBox15.Text < 5 Then
                    Label32.Text = "***"
                    Label33.Text = "not O.k"
                Else
                    Label32.Text = "***"
                    Label33.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "150" Then
                If TextBox15.Text < 8 Then
                    Label32.Text = " ***"
                    Label33.Text = "not O.k"
                Else
                    Label32.Text = "***"
                    Label33.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "200" Then
                If TextBox15.Text < 10 Then
                    Label32.Text = " ***"
                    Label33.Text = "not O.k"
                Else
                    Label32.Text = "***"
                    Label33.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "250" Then
                If TextBox15.Text < 12 Then
                    Label32.Text = " ***"
                    Label33.Text = "not O.k"
                Else
                    Label32.Text = "***"
                    Label33.Text = "O.k"
                End If

            End If
            If ComboBox5.SelectedItem = "300" Then
                If TextBox15.Text < 15 Then
                    Label33.Text = "not O.k"
                Else
                    Label33.Text = "O.k"
                End If
                If TextBox15.Text < 18 Then
                    Label32.Text = "not O.K"
                Else
                    Label32.Text = "O.K"


                End If
            End If
            If ComboBox5.SelectedItem = "350" Then
                If TextBox15.Text < 18 Then
                    Label33.Text = "not O.k"
                Else
                    Label33.Text = "O.K"
                End If
                If TextBox15.Text < 20 Then
                    Label32.Text = "not O.K"
                Else
                    Label32.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "400 c20" Then
                If TextBox15.Text < 20 Then
                    Label32.Text = "not O.K"
                    Label33.Text = "not O.k"
                Else

                    Label32.Text = "***"
                    Label33.Text = "O.k"
                End If
            End If

            If ComboBox5.SelectedItem = "400 c25" Then
                If TextBox15.Text < 25 Then
                    Label32.Text = "not O.K"
                    Label33.Text = "***"
                Else
                    Label32.Text = "O.K"
                    Label33.Text = "O.K"
                End If
            End If

            If ComboBox5.SelectedItem = "400 c30" Then
                If TextBox15.Text < 30 Then
                    Label32.Text = "not O.K"
                    Label33.Text = "***"
                Else
                    Label32.Text = "O.K"
                    Label33.Text = "O.K"

                End If
            End If
            If ComboBox5.SelectedItem = "450 c25" Then
                If TextBox15.Text < 25 Then
                    Label32.Text = "not O.K"
                    Label33.Text = "not O.k"
                Else
                    Label32.Text = "***"
                    Label33.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "450 c35" Then
                If TextBox15.Text < 35 Then
                    Label32.Text = " not O.K"
                    Label33.Text = "***"
                Else
                    Label32.Text = "O.K"
                    Label33.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "450 c40" Then
                If TextBox15.Text < 40 Then
                    Label32.Text = " not O.K"
                    Label33.Text = "***"
                Else
                    Label32.Text = "O.K"
                    Label33.Text = "O.k"

                End If
            End If
            If ComboBox5.SelectedItem = "450 c45" Then
                If TextBox15.Text < 45 Then
                    Label32.Text = " not O.K"
                    Label33.Text = "***"
                Else
                    Label32.Text = "O.K"
                    Label33.Text = "O.k"
                End If
            End If

            Label38.Text = Math.Round(0.44 * Math.Sqrt(TextBox15.Text), 2) & " Mpa"
            Label39.Text = Math.Round(5700 * Math.Sqrt(TextBox15.Text), 2) & " Mpa"
            Dim eco As Double
            eco = 5700 * Math.Sqrt(TextBox15.Text)
            Label40.Text = Math.Round(eco / (2 * (1 + 0.2)), 2) & " Mpa"
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            If TextBox15.Text = "" Then
                MsgBox("لم يتم حساب شيئ", vbExclamation, "خطأ")
                CheckBox4.Checked = False
            Else
                My.Settings.fc = TextBox15.Text
            End If
        End If
    End Sub
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox16.Text = "" Then
            MsgBox("أدخل حمل الكسر", vbExclamation, "خطأ")
        ElseIf ComboBox10.SelectedItem = "" Then
            MsgBox("اختر الشكل", vbExclamation, "خطأ")
        ElseIf ComboBox9.SelectedItem = "" Then
            MsgBox("اختر عمر العينة", vbExclamation, "خطأ")
        Else
            Dim l, d, a, age, cy As Double
            If ComboBox9.SelectedItem = "3 days" Then
                age = 2
            ElseIf ComboBox9.SelectedItem = "7 days" Then
                age = 1.4
            ElseIf ComboBox9.SelectedItem = "28 days" Then
                age = 1
            ElseIf ComboBox9.SelectedItem = "60 days" Then
                age = 0.95
            ElseIf ComboBox9.SelectedItem = "90 days" Then
                age = 0.9
            ElseIf ComboBox9.SelectedItem = "360 or more" Then
                age = 0.8
            End If
            If ComboBox10.SelectedItem = "100*100*100" Then
                l = 0
                d = 0
                a = 100
                cy = 0.78
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * Math.Pow(a, 2)) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (Math.Pow(a, 2)) * age * cy, 2)
            ElseIf ComboBox10.SelectedItem = "150*150*150" Then
                l = 0
                d = 0
                a = 150
                cy = 0.8
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * Math.Pow(a, 2)) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (Math.Pow(a, 2)) * age * cy, 2)
            ElseIf ComboBox10.SelectedItem = "200*200*200" Then
                l = 0
                d = 0
                a = 200
                cy = 0.83
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * Math.Pow(a, 2)) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (Math.Pow(a, 2)) * age * cy, 2)
            ElseIf ComboBox10.SelectedItem = "300*300*300" Then
                l = 0
                d = 0
                a = 300
                cy = 0.9
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * Math.Pow(a, 2)) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (Math.Pow(a, 2)) * age * cy, 2)
            ElseIf ComboBox10.SelectedItem = "300*150" Then
                l = 300
                d = 150
                a = 0
                cy = 1
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * d * l) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (d * l) * age * cy, 2)
            ElseIf ComboBox10.SelectedItem = "200*100" Then
                l = 200
                d = 100
                a = 0
                cy = 0.97
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * d * l) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (d * l) * age * cy, 2)
            ElseIf ComboBox10.SelectedItem = "500*200" Then
                l = 500
                d = 250
                a = 0
                cy = 1.05
                TextBox19.Text = Math.Round((2 * TextBox16.Text * 10 ^ 3) / (Math.PI * d * l) * age * cy, 2)
                TextBox20.Text = Math.Round((0.55 * TextBox16.Text * 10 ^ 3) / (d * l) * age * cy, 2)
            End If
            '==========================




        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox17.Text = "" Then
            MsgBox("أدخل الحمل المطبق", vbExclamation, "خطأ")
        ElseIf ComboBox12.SelectedItem = "" Then
            MsgBox("اختر الشكل", vbExclamation, "خطأ")
        ElseIf ComboBox8.SelectedItem = "" Then
            MsgBox("اختر عمر العينة", vbExclamation, "خطأ")
        Else
            Dim l, m, p, b, fcb, age As Double
            If ComboBox8.SelectedItem = "3 days" Then
                age = 2
            ElseIf ComboBox8.SelectedItem = "7 days" Then
                age = 1.4
            ElseIf ComboBox8.SelectedItem = "28 days" Then
                age = 1
            ElseIf ComboBox8.SelectedItem = "60 days" Then
                age = 0.95
            ElseIf ComboBox8.SelectedItem = "90 days" Then
                age = 0.9
            ElseIf ComboBox8.SelectedItem = "360 or more" Then
                age = 0.8
            End If
            p = TextBox17.Text
            If ComboBox12.SelectedItem = "550*100*100" Then
                l = 0.1
                b = 100
                m = p * l
                fcb = (6 * m * 10 ^ 6) / (Math.Pow(b, 3)) * age
                TextBox21.Text = Math.Round(fcb, 2)
                TextBox18.Text = Math.Round((3.6 * m * 10 ^ 6) / (Math.Pow(b, 3)), 2) * age
            ElseIf ComboBox12.SelectedItem = "700*150*150" Then
                l = 0.2
                b = 150
                m = p * l
                fcb = (6 * m * 10 ^ 6) / (Math.Pow(b, 3)) * age
                TextBox21.Text = Math.Round(fcb, 2)
                TextBox18.Text = Math.Round((3.6 * m * 10 ^ 6) / (Math.Pow(b, 3)), 2) * age
            End If
        End If
    End Sub


    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '   Acadapp = CreateObject("AutoCAD.Application")
    '    If Err.Number <> 0 Then
    '        Acadapp = CreateObject("AutoCAD.Application")
    '        Acadapp.Documents.Add()
    '        Acadapp.Visible = True
    '        Acadapp.WindowState = AutoCAD.AcWindowState.acMax
    '        Err.Clear()
    '    End If
    '    '=====رسم الطول السفلي=====
    '    Dim l1 As AcadLine
    '    Dim starp1(0 To 2) As Double
    '    Dim endp1(0 To 2) As Double
    '    starp1(0) = 0 : starp1(1) = 0 : starp1(2) = 0
    '    endp1(0) = TextBox22.Text : endp1(1) = 0 : endp1(2) = 0
    '    l1 = Acadapp.ActiveDocument.ModelSpace.AddLine(starp1, endp1)
    '    '=====رسم العرض الايسر=====
    '    Dim b1 As AcadLine
    '    Dim starp2(0 To 2) As Double
    '    Dim endp2(0 To 2) As Double
    '    starp2(0) = 0 : starp2(1) = 0 : starp2(2) = 0
    '    endp2(0) = 0 : endp2(1) = TextBox23.Text : endp2(2) = 0
    '    b1 = Acadapp.ActiveDocument.ModelSpace.AddLine(starp2, endp2)
    '    '=====رسم الطول العلوي=====
    '    Dim l2 As AcadLine
    '    Dim starp3(0 To 2) As Double
    '    Dim endp3(0 To 2) As Double
    '    starp3(0) = 0 : starp3(1) = TextBox23.Text : starp3(2) = 0
    '    endp3(0) = TextBox22.Text : endp3(1) = TextBox23.Text : endp3(2) = 0
    '    l2 = Acadapp.ActiveDocument.ModelSpace.AddLine(starp3, endp3)
    '    '=====رسم العرض الايمن=====
    '    Dim b2 As AcadLine
    '    Dim starp4(0 To 2) As Double
    '    Dim endp4(0 To 2) As Double
    '    starp4(0) = TextBox22.Text : starp4(1) = TextBox23.Text : starp4(2) = 0
    '    endp4(0) = TextBox22.Text : endp4(1) = 0 : endp4(2) = 0
    '    b2 = Acadapp.ActiveDocument.ModelSpace.AddLine(starp4, endp4)
    '    Acadapp.ZoomExtents()
    '    '===============رسم قضبان التسليح================
    '    Dim snl, snb As Double
    '    snl = Math.Round((TextBox22.Text / TextBox25.Text), 0)
    '    snb = Math.Round((TextBox23.Text / TextBox26.Text), 0)
    '    Dim i As Integer
    '    Dim x(snl), cir(snl) As Single
    '    For i = 0 To snl
    '        '======احداثيات x سفلي========
    '        x(i) = TextBox24.Text + (TextBox27.Text / 2) + i * (TextBox25.Text + TextBox27.Text / 2)
    '        Dim cc As AcadCircle, circle(snl) As Single, Y As Integer
    '        Dim cp(snl, 0 To 2) As Double
    '        For Y = 0 To snl
    '            cp(Y, 0) = x(i) : cp(Y, 1) = TextBox24.Text + (TextBox27.Text / 2) : cp(Y, 2) = 0
    '            cc = Acadapp.ActiveDocument.ModelSpace.AddCircle(cp, TextBox27.Text * 10)
    '        Next
    '    Next

    'End Sub
    Private Sub TextBox30_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox37.TextChanged, TextBox36.TextChanged, Textbox31.TextChanged, TextBox30.TextChanged
        If TabControl7.SelectedTab Is TabPage19 Then
            If TextBox30.Text = "" Or Textbox31.Text = "" Then
                Err.Clear()
            Else
                Dim b, h As Double
                b = Textbox31.Text : h = TextBox30.Text
                TextBox28.Text = Math.Round(h * b, 2)
                TextBox29.Text = Math.Round((b * h ^ 3) / 12, 2)
                TextBox34.Text = Math.Round(TextBox35.Text * (b / 1000) * (h / 1000), 2) * 1.4
            End If
        ElseIf TabControl7.SelectedTab Is TabPage20 Then
            If TextBox30.Text = "" Or Textbox31.Text = "" Or TextBox36.Text = "" Or TextBox37.Text = "" Then
                Err.Clear()
            Else
                Dim bw, ts, bf, h As Double
                bw = Textbox31.Text : h = TextBox30.Text : ts = TextBox37.Text : bf = TextBox36.Text
                TextBox28.Text = Math.Round((ts * bf) + ((h - ts) * bw), 2)
                TextBox29.Text = Math.Round(((bf * ts ^ 3) / 12) + (bw * ((h - ts) ^ 3) / 12), 2)
                TextBox34.Text = Math.Round(TextBox35.Text * ((bw / 1000) * ((h - ts) / 1000)) + TextBox35.Text * ((bf / 1000) * (ts / 1000)), 2) * 1.4
            End If
        End If
    End Sub


    Private Sub GroupBox15_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl7.SelectedIndexChanged
        If TabControl7.SelectedTab Is TabPage19 Then
            Label70.Text = "B="
            Label91.Visible = False
            TextBox36.Visible = False
            Label90.Visible = False
            Label92.Visible = False
            TextBox37.Visible = False
            Label93.Visible = False
            My.Settings.shape = "rec"
            If TextBox30.Text = "" Or Textbox31.Text = "" Then
                Err.Clear()
            Else
                Dim b, h As Double
                b = Textbox31.Text : h = TextBox30.Text
                TextBox28.Text = Math.Round(h * b, 2)
                TextBox29.Text = Math.Round((b * h ^ 3) / 12, 2)
                TextBox34.Text = Math.Round(TextBox35.Text * (b / 1000) * (h / 1000), 2)
            End If
        ElseIf TabControl7.SelectedTab Is TabPage20 Then
            Label70.Text = "Bw="
            Label91.Visible = True
            TextBox36.Visible = True
            Label90.Visible = True
            Label92.Visible = True
            TextBox37.Visible = True
            Label93.Visible = True
            My.Settings.shape = "t"
            If TextBox30.Text = "" Or Textbox31.Text = "" Or TextBox36.Text = "" Or TextBox37.Text = "" Then
                Err.Clear()
            Else
                Dim bw, ts, bf, h As Double
                bw = Textbox31.Text : h = TextBox30.Text : ts = TextBox37.Text : bf = TextBox36.Text
                TextBox28.Text = Math.Round((ts * bf) + ((h - ts) * bw), 2)
                TextBox29.Text = Math.Round(((bf * ts ^ 3) / 12) + (bw * ((h - ts) ^ 3) / 12), 2)
                TextBox34.Text = Math.Round(TextBox35.Text * ((bw / 1000) * ((h - ts) / 1000)) + TextBox35.Text * ((bf / 1000) * (ts / 1000)), 2)
            End If
        End If
    End Sub

    Private Sub TextBox35_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox35.TextChanged
        If TabControl7.SelectedTab Is TabPage19 Then
            If TextBox35.Text = "" Then
                Err.Clear()
            Else
                Dim b, h As Double
                b = Textbox31.Text : h = TextBox30.Text
                TextBox34.Text = Math.Round(TextBox35.Text * (b / 1000) * (h / 1000), 2)
            End If
        ElseIf TabControl7.SelectedTab Is TabPage20 Then
            If TextBox35.Text = "" Then
                Err.Clear()
            Else
                Dim bw, ts, bf, h As Double
                bw = Textbox31.Text : h = TextBox30.Text : ts = TextBox37.Text : bf = TextBox36.Text
                TextBox34.Text = Math.Round(TextBox35.Text * ((bw / 1000) * ((h - ts) / 1000)) + TextBox35.Text * ((bf / 1000) * (ts / 1000)), 2)
            End If
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            TextBox30.Enabled = False
            Textbox31.Enabled = False
            TextBox32.Enabled = False
            TextBox33.Enabled = False
            TextBox35.Enabled = False
            TextBox36.Enabled = False
            TextBox37.Enabled = False
        Else
            TextBox30.Enabled = True
            Textbox31.Enabled = True
            TextBox32.Enabled = True
            TextBox33.Enabled = True
            TextBox35.Enabled = True
            TextBox36.Enabled = True
            TextBox37.Enabled = True
        End If
    End Sub

    Public Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If TextBox40.Text = "" Then
            MsgBox("ادخل f'c", vbExclamation, "خطاً")
        ElseIf TextBox39.Text = "" Then
            MsgBox("ادخل fy", vbExclamation, "خطاً")
        ElseIf TextBox38.Text = "" Then
            MsgBox("ادخل fyp", vbExclamation, "خطاً")
        ElseIf TextBox41.Text = "" Then
            MsgBox("أدخل الحمولة", vbExclamation, "خطاً")
        ElseIf TextBox42.Text = "" Then
            MsgBox("أدخل طول المجاز", vbExclamation, "خطاً")
        ElseIf TextBox51.Text = "" Then
            MsgBox("أدخل عدد القضبان", vbExclamation, "خطاً")
        Else
            Dim p, m, d, h, a, ymax, asmax, asmin, mumax As Double
            h = TextBox30.Text : a = TextBox32.Text
            d = h - a
            TextBox50.Text = d
            '====حساب ymax====
            ymax = ((0.5 * 535) / (630 + TextBox39.Text)) * d
            TextBox45.Text = Math.Round(ymax, 2)

            '=====حساب p=====
            If RadioButton1.Checked = True Then
                p = TextBox41.Text * My.Settings.dl
            ElseIf RadioButton2.Checked = True Then
                Dim sw As Double
                sw = TextBox34.Text * My.Settings.dl
                p = TextBox41.Text * My.Settings.dl + sw
            End If
            TextBox43.Text = p

            '=====حساب m=====
            '====المسند الطرفي=====
            If RadioButton4.Checked = True Then
                m = (p * ((TextBox42.Text) ^ 2)) / 24
            End If
            '====المسند الوسطي====
            If RadioButton3.Checked = True Then
                If RadioButton7.Checked = True Then
                    m = (p * ((TextBox42.Text) ^ 2)) / 9
                ElseIf RadioButton6.Checked = True Then
                    If CheckBox7.Checked = True Then
                        m = (p * ((TextBox42.Text) ^ 2)) / 10
                    Else
                        m = (p * ((TextBox42.Text) ^ 2)) / 12
                    End If
                ElseIf RadioButton8.Checked = True Then
                    MsgBox("لا يوجد مسند وسطي في المجاز الواحد", vbExclamation, "خطأ")
                End If
            End If

            '====وسط المجاز====
            If RadioButton5.Checked = True Then
                If RadioButton8.Checked = True Then
                    m = (p * ((TextBox42.Text) ^ 2)) / 8
                ElseIf RadioButton7.Checked = True Then
                    m = (p * ((TextBox42.Text) ^ 2)) / 11
                ElseIf RadioButton6.Checked = True Then
                    If CheckBox7.Checked = True Then
                        m = (p * ((TextBox42.Text) ^ 2)) / 14
                    Else
                        m = (p * ((TextBox42.Text) ^ 2)) / 10
                    End If
                End If
            End If
            TextBox44.Text = Math.Round(m, 2)

            '====حساب asmin , asmax====
            asmin = (0.9 * Textbox31.Text * d) / TextBox39.Text
            asmax = 0.5 * ((455 / (630 + TextBox39.Text)) * (TextBox40.Text / TextBox39.Text) * Textbox31.Text * d)
            TextBox48.Text = Math.Round(asmax, 2)
            TextBox49.Text = Math.Round(asmin, 2)

            '====حساب mumax====
            mumax = 0.9 * (asmax * TextBox39.Text * (d - ymax / 2))
            If m > mumax Then
                MsgBox("يجب تكبير المقطع", vbExclamation, "تسليح ثنائي")
            Else

                '=====حساب y====
                Dim delta, y, fc, bb As Double
                fc = TextBox40.Text : bb = Textbox31.Text
                If My.Settings.shape = "rec" Then
10:                 delta = (d ^ 2) - 2 * ((m * (10 ^ 6)) / (0.765 * fc * bb))
                    y = ((d - Math.Sqrt(delta)) / 1)
                    If y >= ymax Then
                        y = ymax
                    ElseIf y < ymax Then
                        y = y
                    End If
                ElseIf My.Settings.shape = "t" Then
                    Dim mur, mur1, mur2, bf, tf As Double
                    bf = TextBox36.Text : tf = TextBox37.Text
                    mur = 0.9 * bf * tf * 0.85 * TextBox40.Text * (d - (tf / 2))
                    If m <= mur Then
                        GoTo 10
                    ElseIf m > mur Then
                        mur1 = 0.9 * (bf - Textbox31.Text) * tf * 0.85 * TextBox40.Text * (d - (tf / 2))
                        mur2 = m - mur1
                        delta = (d ^ 2) - 2 * ((mur2 * (10 ^ 6)) / (0.765 * fc * bb))
                        y = ((d - Math.Sqrt(delta)) / 1)
                    End If
                End If
                TextBox46.Text = Math.Round(y, 2)
                '=====حساب as====
                Dim ass As Double
                If My.Settings.shape = "rec" Then
                    ass = (m * 10 ^ 6) / (0.9 * TextBox39.Text * (d - (y / 2)))
                    If ass < asmin Then
                        ass = asmin
                    ElseIf ass > asmin And ass < asmax Then
                        ass = ass
                    ElseIf ass > asmax Then
                        MsgBox("التسليح غير اقتصادي قم بتكبير المقطع", vbExclamation, "تسليح كبير")
                    End If
                ElseIf My.Settings.shape = "t" Then
                    Dim as1, as2 As Double
                    as1 = (0.85 * TextBox40.Text * (TextBox36.Text - Textbox31.Text) * TextBox37.Text) / TextBox39.Text
                    as2 = (0.85 * TextBox40.Text * Textbox31.Text * y) / TextBox39.Text
                    ass = as1 + as2
                End If
                TextBox47.Text = Math.Round(ass, 2)
            End If
            '=====عملي====
            Dim n, di As Double
            n = TextBox51.Text
            di = Math.Sqrt((TextBox47.Text * 4) / (n * Math.PI))
            If di <= 12 Then
                di = 12
            ElseIf di <= 14 Then
                di = 14
            ElseIf di <= 16 Then
                di = 16
            ElseIf di <= 18 Then
                di = 18
            ElseIf di <= 20 Then
                di = 20
            ElseIf di <= 22 Then
                di = 22
            ElseIf di <= 25 Then
                di = 25
            ElseIf di <= 28 Then
                di = 28
            ElseIf di <= 30 Then
                di = 30
            ElseIf di <= 32 Then
                di = 32
            ElseIf di <= 40 Then
                di = 40
            ElseIf di > 40 Then
                MsgBox("يجب زيادة عدد القضبان", vbExclamation, "قطر القضيب كبير جداً")
            End If
            RichTextBox4.Text = n & "T" & di
            RichTextBox4.Visible = True
            If Form5.RadioButton1.Checked = True Then
                Dim rowNum As Integer = Form5.DataGridView1.Rows.Add
                Form5.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox110.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(1).Value = TextBox34.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(2).Value = TextBox29.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(3).Value = TextBox28.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(4).Value = TextBox41.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(5).Value = TextBox44.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(6).Value = TextBox47.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(7).Value = RichTextBox4.Text
                ToolStrip4.Visible = True
            ElseIf Form5.RadioButton2.Checked = True Then
                Dim rowNum As Integer = Form5.DataGridView1.Rows.Add
                Form5.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox110.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(1).Value = TextBox44.Text
                Form5.DataGridView1.Rows.Item(rowNum).Cells(2).Value = RichTextBox4.Text
                ToolStrip4.Visible = True
            End If

        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton3.Checked = True Or RadioButton5.Checked = True Then
            If RadioButton6.Checked = True Then
                CheckBox7.Visible = True
            Else
                CheckBox7.Visible = False
            End If
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            TextBox40.Text = My.Settings.fc
            TextBox39.Text = My.Settings.fy
            TextBox38.Text = My.Settings.fyp
        Else
            TextBox40.Text = ""
            TextBox39.Text = ""
            TextBox38.Text = ""
        End If
    End Sub

    Public Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If TextBox55.Text = "" Then
            MsgBox("ادخل f'c", vbExclamation, "خطاً")
        ElseIf TextBox54.Text = "" Then
            MsgBox("ادخل fy", vbExclamation, "خطاً")
        ElseIf TextBox53.Text = "" Then
            MsgBox("ادخل fyp", vbExclamation, "خطاً")
        ElseIf TextBox52.Text = "" Then
            MsgBox("أدخل القوى المطبقة", vbExclamation, "خطاً")
        ElseIf TextBox57.Text = "" Then
            MsgBox("أدخل عدد أفرع الأساور", vbExclamation, "خطاً")
        ElseIf ComboBox11.SelectedItem = "" Then
            MsgBox("اختر القطر", vbExclamation, "خطاً")
        ElseIf ComboBox13.SelectedItem = "" Then
            MsgBox("اختر قيمة قيمة Ʈou", vbExclamation, "خطاً")
        Else
            Dim qu, tu, tumax, tcu, tou, d, h, a, bw, n, fyr, ss As Double
            qu = (TextBox52.Text * 10 ^ 3) * My.Settings.dl
            h = TextBox30.Text : a = TextBox32.Text : bw = Textbox31.Text
            d = h - a
            fyr = TextBox53.Text
            '=======حساب tu======
            tu = qu / (0.85 * d * bw)
            TextBox56.Text = Math.Round(tu, 2)

            '=======حساب tumax=====
            If RadioButton10.Checked = True Then
                tumax = 0.65 * Math.Sqrt(TextBox55.Text)
            ElseIf RadioButton9.Checked = True Then
                tumax = 0.8 * Math.Sqrt(TextBox55.Text)
            End If
            TextBox58.Text = Math.Round(tumax, 2)

            '======التحقق من المقطع======
            If tu > tumax Then
                MsgBox("المقطع غير محقق لا بد من تغيير أبعاد المقطع بزيادة أبعاد المقطع أو تحسين مواصفات البيتون", vbExclamation, "المقطع غير محقق")
            Else

                '=====حساب tcu======
                tcu = 0.23 * Math.Sqrt(TextBox55.Text)
                TextBox59.Text = Math.Round(tcu, 2)

                '======حساب مساحة القضيب=======
                Dim ast As Double
                If ComboBox11.SelectedItem = "6" Then
                    ast = 9 * Math.PI
                ElseIf ComboBox11.SelectedItem = "8" Then
                    ast = 16 * Math.PI
                ElseIf ComboBox11.SelectedItem = "10" Then
                    ast = 25 * Math.PI
                ElseIf ComboBox11.SelectedItem = "12" Then
                    ast = 36 * Math.PI
                End If
                TextBox60.Text = Math.Round(ast, 2)

                '========حساب التباعد=======
                If tu <= tcu Then
                    n = TextBox57.Text
                    ss = (n * ast) / ((0.35 / fyr) * bw)
                ElseIf tu > tcu Then
                    '=====حساب Ʈou======
                    If ComboBox13.SelectedItem = "0" Then
                        tou = 0
                    ElseIf ComboBox3.SelectedItem = "0.35Ʈcu" Then
                        tou = 0.35 * tcu
                    ElseIf ComboBox13.SelectedItem = "0.7Ʈcu" Then
                        tou = 0.7 * tcu
                    End If
                    n = TextBox57.Text
                    ss = (n * ast) / (((tu - tou) / TextBox54.Text) * bw)
                End If
                If ss > d Or ss > 300 Then
                    MsgBox("النباعد غير محقق يجب أو يكون أصغر من المسافة العظمة والتي تساوي القيمة الدنيا من (d,300مم)", vbExclamation, "التباعد غير محقق")
                End If
                TextBox61.Text = Math.Round(ss, 2)
            End If
            '======التسليح العملي=====
            If d <= 300 Then
                If ss >= d Then
                    ss = d
                Else
                    ss = ss
                End If
            ElseIf d > 300 Then
                If ss >= 300 Then
                    ss = 300
                Else
                    ss = ss
                End If
            End If
            Dim di, nn As Double
            nn = TextBox57.Text / 2
            If ComboBox11.SelectedItem = "6" Then
                di = 6
            ElseIf ComboBox11.SelectedItem = "8" Then
                di = 8
            ElseIf ComboBox11.SelectedItem = "10" Then
                di = 10
            ElseIf ComboBox11.SelectedItem = "12" Then
                di = 12
            End If
            RichTextBox5.Text = nn & "Φ" & di & "/" & Math.Round(ss / 10, 0) & "cm'"
            Dim rowNum As Integer = Form6.DataGridView1.Rows.Add
            Form6.DataGridView1.Rows.Item(rowNum).Cells(0).Value = TextBox111.Text
            Form6.DataGridView1.Rows.Item(rowNum).Cells(1).Value = TextBox34.Text
            Form6.DataGridView1.Rows.Item(rowNum).Cells(2).Value = TextBox29.Text
            Form6.DataGridView1.Rows.Item(rowNum).Cells(3).Value = TextBox28.Text
            Form6.DataGridView1.Rows.Item(rowNum).Cells(4).Value = TextBox52.Text
            Form6.DataGridView1.Rows.Item(rowNum).Cells(5).Value = TextBox60.Text
            Form6.DataGridView1.Rows.Item(rowNum).Cells(6).Value = RichTextBox5.Text
            ToolStrip5.Visible = True
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            TextBox55.Text = My.Settings.fc
            TextBox54.Text = My.Settings.fy
            TextBox53.Text = My.Settings.fyp
        Else
            TextBox55.Text = ""
            TextBox54.Text = ""
            TextBox53.Text = ""
        End If
    End Sub

    Private Sub TextBox62_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox63.TextChanged, TextBox69.TextChanged, TextBox86.TextChanged
        If TextBox63.Text = "" Or TextBox69.Text = "" Or TextBox86.Text = "" Then
            Err.Clear()
        Else
            Dim h, t, c As Double
            h = TextBox63.Text * 1000 : t = TextBox69.Text * 1000 : c = TextBox86.Text
            TextBox68.Text = Math.Round(h * t, 2)
            TextBox67.Text = ((Math.Round(((t * (h ^ 3)) / 12), 2)) / (10 ^ 9)) & "*10⁹"
            TextBox66.Text = Math.Round(c * (t / 1000) * (h / 1000), 2)
        End If
    End Sub

    Public Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If TextBox75.Text = "" Then
            MsgBox("ادخل f'c", vbExclamation, "خطاً")
        ElseIf TextBox74.Text = "" Then
            MsgBox("ادخل fy", vbExclamation, "خطاً")
        ElseIf TextBox73.Text = "" Then
            MsgBox("ادخل fyp", vbExclamation, "خطاً")
        ElseIf TextBox70.Text = "" Then
            MsgBox("أدخل الحمولة", vbExclamation, "خطاً")
        ElseIf TextBox85.Text = "" Then
            MsgBox("أدخل التباعد بين قضبان التسليح الرئيسي", vbExclamation, "خطاً")
        ElseIf TextBox81.Text = "" Then
            MsgBox("أدخل التباعد بين قضبان تسليح القص", vbExclamation, "خطاً")
        ElseIf TextBox80.Text = "" Then
            MsgBox("أدخل عدد قضبان التسليح الرئيسي", vbExclamation, "خطاً")
        ElseIf TextBox87.Text = "" Then
            MsgBox("أدخل عدد قضبان التسليح الانشائي", vbExclamation, "خطاً")
        ElseIf TextBox88.Text = "" Then
            MsgBox("أدخل عدد قضبان تسليح القص", vbExclamation, "خطاً")
        Else
            Dim l, b1, b2, h, d, w, shart, t As Double
            b1 = TextBox64.Text * 100 : b2 = TextBox65.Text * 100 : h = TextBox63.Text * 100 : t = TextBox69.Text * 100
            l = Math.Min(1.05 * TextBox62.Text * 100, (TextBox62.Text * 100 + (b1 / 2) + (b2 / 2)))
            If h > l Then
                h = l
            Else
                h = TextBox63.Text * 100
            End If
            d = 0.9 * h
            '=====عميق على=====
            shart = (l / h)
            TextBox72.Text = shart
            If shart >= 2 And shart < 5 Then
                TextBox71.Text = "الجائز عميق على العزم"
            ElseIf shart < 2 Then
                TextBox71.Text = "الجائز عميق على القص والعزم"
            End If

            '=====حساب الحمولة=====
            Dim p, sw As Double
            sw = TextBox66.Text : p = TextBox70.Text
            w = sw + p
            TextBox72.Text = Math.Round(w, 2)
            '=====التحقق من السماكة====
            Dim shart2, tmin As Double
            shart2 = w / (0.3 * TextBox75.Text * h * 10)
            If shart2 < (1 / 52) Then
                tmin = Math.Round(0.5 * l * ((0.01 * shart2) ^ (1 / 3)), 2)
            ElseIf shart2 >= (1 / 52) Then
                tmin = Math.Round(1.5 * l * shart2, 2)
            End If
            If t >= tmin Then
                TextBox76.Text = "tmin=" & tmin & "cm" & " (محققة)"
            ElseIf t < tmin Then
                TextBox76.Text = "tmin=" & tmin & "cm" & " (غير محققة)"
                MsgBox("يجب تكبير سماكة الجائز", vbExclamation, "السماكة غير محققة")
            End If

            '=====حساب تسليح الانعطاف الرئيسي=====
            Dim m, ass, asmin As Double
            asmin = (0.9 * t * d * 100) / TextBox74.Text
            TextBox78.Text = Math.Round(asmin, 2)
            m = ((w * ((l / 100) ^ 2)) / 8) * 10 ^ 6
            TextBox77.Text = Math.Round(m / (10 ^ 6), 2)
            ass = 0.9 * (m / (0.55 * TextBox74.Text * h * 10)) * (1 + (2 / 3) * (h / l))

            If ass < asmin Then
                ass = Math.Max((2 / 3) * asmin, 1.33 * ass)
            ElseIf ass >= asmin Then
                ass = ass
            End If
            TextBox79.Text = Math.Round(ass, 2)
            '====عملي=====
            Dim n, di As Double
            n = TextBox80.Text
            di = Math.Sqrt((TextBox79.Text * 4) / (n * Math.PI))

            If di <= 12 Then
                di = 12
            ElseIf di <= 14 Then
                di = 14
            ElseIf di <= 16 Then
                di = 16
            ElseIf di <= 18 Then
                di = 18
            ElseIf di <= 20 Then
                di = 20
            ElseIf di <= 22 Then
                di = 22
            ElseIf di <= 25 Then
                di = 25
            ElseIf di <= 28 Then
                di = 28
            ElseIf di <= 30 Then
                di = 30
            ElseIf di <= 32 Then
                di = 32
            ElseIf di <= 40 Then
                di = 40
            ElseIf di > 40 Then
                MsgBox("يجب زيادة عدد القضبان", vbExclamation, "قطر القضيب كبير جداً")
            End If
            RichTextBox1.Text = n & "T" & di
            '=====التسليح الانشائي======
            Dim ass2 As Double
            ass2 = 0.002 * TextBox85.Text * t * 10
            TextBox84.Text = Math.Round(ass2, 2)
            '====عملي=====
            Dim n2, di2 As Double
            n2 = TextBox87.Text
            di2 = Math.Sqrt((TextBox84.Text * 4) / (n2 * Math.PI))
            If di2 <= 8 Then
                di2 = 8
            ElseIf di2 <= 10 Then
                di2 = 10
            ElseIf di <= 12 Then
                di2 = 12
            ElseIf di2 <= 14 Then
                di2 = 14
            ElseIf di2 <= 16 Then
                di2 = 16
            ElseIf di2 <= 18 Then
                di2 = 18
            ElseIf di2 <= 20 Then
                di2 = 20
            ElseIf di2 <= 22 Then
                di2 = 22
            ElseIf di2 <= 25 Then
                di2 = 25
            ElseIf di2 <= 28 Then
                di2 = 28
            ElseIf di2 <= 30 Then
                di2 = 30
            ElseIf di2 <= 32 Then
                di2 = 32
            ElseIf di2 <= 40 Then
                di2 = 40
            ElseIf di2 > 40 Then
                MsgBox("يجب زيادة عدد القضبان", vbExclamation, "قطر القضيب كبير جداً")
            End If
            RichTextBox6.Text = n2 & "T" & di2 & "/" & (TextBox85.Text / 10) & " cm"
            '====تسليح القص=====
            Dim q0, segma, ssee, lx As Double
            lx = (TextBox62.Text * 100) + ((TextBox64.Text / 2) + (TextBox65.Text / 2)) * 100
            q0 = (w * (lx / 100)) / 2
            segma = q0 / (0.85 * t * 10 * h * 10)
            ssee = 0.37 * Math.Sqrt(TextBox75.Text)

            If segma > ssee Then
                MsgBox("مقاومة القص كبيرة جداً يجب زيادة أبعاد المقطع", vbExclamation, "أبعاد المقطع صغيرة")
            ElseIf segma <= ssee Then
                Dim t0, tt, tmax, tc, big, big2, asq As Double
                t0 = (q0 * 10 ^ 3) / (0.85 * t * d * 100)
                TextBox83.Text = Math.Round(t0, 2)
                big = (lx / 2) - (TextBox64.Text * 100 / 2) - (0.15 * TextBox62.Text * 100)
                big2 = lx / 2
                tt = (t0 * big) / big2
                TextBox89.Text = Math.Round(tt, 2)
                tmax = 0.36 * Math.Sqrt(TextBox75.Text)
                TextBox90.Text = Math.Round(tmax, 2)
                tc = 0.088 * Math.Sqrt(TextBox75.Text)
                TextBox91.Text = Math.Round(tc, 2)

                '=====التسليح الانشائي====
                If tt <= tc Then
11:                 asq = 0.0012 * t * 10 * TextBox81.Text
                    '=====التسليح الحسابي=====
                ElseIf tt > tc Then
                    Dim al, qq2, sq, ln, qq1, ss, qq3 As Double
                    ln = TextBox62.Text
                    sq = TextBox81.Text
                    ss = TextBox85.Text
                    al = n2 * ((Math.PI * (di2) ^ 2) / 4)
                    qq1 = (al / sq) * ((11 - (ln / (d / 100))) / 12) * 0.55 * ln * 100
                    qq2 = (tt - tc) * TextBox69.Text * 1000
                    qq3 = (1 / ss) * ((1 + (ln / (d / 100))) / 12) * 0.55 * ln * 100

                    asq = (qq2 - qq1) / qq3

                End If
                TextBox82.Text = Math.Round(asq, 2)
                '=====
                '======العملي======
                Dim n3, di3 As Double
                n3 = TextBox88.Text
                di3 = Math.Sqrt((TextBox82.Text * 4) / (n3 * Math.PI))
                If di3 <= 8 Then
                    di3 = 8
                ElseIf di3 <= 10 Then
                    di3 = 10
                ElseIf di <= 12 Then
                    di3 = 12
                ElseIf di3 <= 14 Then
                    di3 = 14
                ElseIf di3 <= 16 Then
                    di3 = 16
                ElseIf di3 <= 18 Then
                    di3 = 18
                ElseIf di3 <= 20 Then
                    di3 = 20
                ElseIf di3 <= 22 Then
                    di3 = 22
                ElseIf di3 <= 25 Then
                    di3 = 25
                ElseIf di3 <= 28 Then
                    di3 = 28
                ElseIf di3 <= 30 Then
                    di3 = 30
                ElseIf di3 <= 32 Then
                    di3 = 32
                ElseIf di3 <= 40 Then
                    di3 = 40
                ElseIf di3 > 40 Then
                    MsgBox("يجب زيادة عدد القضبان", vbExclamation, "قطر القضيب كبير جداً")
                End If
                RichTextBox2.Text = n3 & "T" & di3 & "/" & TextBox81.Text / 10 & " cm"
            End If
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = True Then
            TextBox75.Text = My.Settings.fc
            TextBox74.Text = My.Settings.fy
            TextBox73.Text = My.Settings.fyp
        Else
            TextBox75.Text = ""
            TextBox74.Text = ""
            TextBox73.Text = ""
        End If
    End Sub

    Public Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If TextBox96.Text = "" Then
            MsgBox("ادخل f'c", vbExclamation, "خطاً")
        ElseIf TextBox95.Text = "" Then
            MsgBox("ادخل fy", vbExclamation, "خطاً")
        ElseIf TextBox94.Text = "" Then
            MsgBox("ادخل fyp", vbExclamation, "خطاً")
        ElseIf TextBox92.Text = "" Then
            MsgBox("أدخل قوة القص المطبقة", vbExclamation, "خطاً")
        ElseIf TextBox93.Text = "" Then
            MsgBox("أدخل عزم الفتل المصعد", vbExclamation, "خطاً")
        ElseIf TextBox97.Text = "" Then
            MsgBox("أدخل عدد أفرع أساور القص", vbExclamation, "خطاً")
        ElseIf TextBox98.Text = "" Then
            MsgBox("أدخل قطر اسوارة القص", vbExclamation, "خطاً")
        Else
            '======1======
            Dim qu, mtu As Double
            qu = TextBox92.Text : mtu = TextBox93.Text
            '======2======
            Dim b, d, h, bf, ts, tu, ttu As Double
            b = Textbox31.Text : d = TextBox30.Text - TextBox32.Text : h = TextBox30.Text : bf = TextBox36.Text : ts = TextBox37.Text
            'حسابtu
            tu = (qu * (10 ^ 3)) / (0.85 * b * d)
            TextBox99.Text = Math.Round(tu, 2)
            'حساب ttu
            If TabControl7.SelectedTab Is TabPage19 Then
                ttu = (3 * mtu * (10 ^ 6)) / ((b ^ 2) * h)
            ElseIf TabControl7.SelectedTab Is TabPage20 Then
                ttu = (3 * mtu * (10 ^ 6)) / (((b ^ 2) * h) + ((bf ^ 2) * ts))
            End If
            TextBox100.Text = Math.Round(ttu, 2)
            '=====3======
            Dim fc, fyp, ttumin, tumax, ttumax As Double
            fc = TextBox96.Text : fyp = TextBox94.Text
            ttumin = 0.13 * Math.Sqrt(fc)
            TextBox101.Text = Math.Round(ttumin, 2)
            tumax = 0.65 * Math.Sqrt(fc)
            TextBox102.Text = Math.Round(tumax, 2)
            ttumax = (0.8 * Math.Sqrt(fc)) / (Math.Sqrt(1 + ((1.2 * tu) / ttu) ^ 2))
            TextBox103.Text = Math.Round(ttumax, 2)
            '=====4======
            If ttu <= ttumin Then
                MsgBox("يمكن إهمال تأثير الفتل ودراسة المقطع على القص الصافي", vbExclamation, "يمكن إهمال الفتل")
            ElseIf tu > tumax Or ttu > ttumax Then
                MsgBox("يجب تكبير أبعاد المقطع", vbExclamation, "الأبعاد صغيرة")
            Else
                'حساب القص مع أخذ الفتل بعين الاعتبار
                Dim tcu As Double
                tcu = (0.16 * Math.Sqrt(fc)) / (Math.Sqrt(1 + ((ttu / (1.2 * tu)) ^ 2)))
                TextBox104.Text = Math.Round(tcu, 2)
                Dim n, di, ast, sq, astt As Double
                n = TextBox97.Text : di = TextBox98.Text : astt = ((Math.PI * (di ^ 2)) / 4) : ast = n * astt
                If tu <= tcu Then
                    sq = (ast / ((0.35 / fyp) * b) / 10)
                ElseIf tu > tcu Then
                    Dim num As Double
                    num = tu - tcu
                    sq = (ast / ((num / fyp) * b) / 10)
                End If
                TextBox106.Text = Math.Ceiling(sq)
                'حساب الفتل مع أخذ القص بعين الاعتبار
                Dim ttcu, st As Double
                ttcu = (0.16 * Math.Sqrt(fc)) / (Math.Sqrt(1 + ((1.2 * tu) / ttu) ^ 2))
                TextBox105.Text = Math.Round(ttcu, 2)
                If ttu <= ttcu Then
                    st = ((2 * astt) / ((0.35 / fyp) * b) / 10)
                ElseIf ttu > ttcu Then
                    Dim num2, num3, y1, x1, alpha As Double
                    num2 = ttu - ttcu : y1 = h * 5 : x1 = b * 5
                    alpha = 0.66 + 0.33 * (y1 / x1)
                    If alpha > 1.5 Then
                        alpha = 1.5
                    Else
                        alpha = alpha
                    End If
                    num3 = 3 * alpha * x1 * y1 * fyp
                    st = ((2 * astt) / ((num2 / num3) * (b ^ 2) * h) / 10)
                End If
                TextBox107.Text = Math.Ceiling(st)
                '======5======
                'التسليح الطولي
                Dim asstt, al As Double

            End If
        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked = True Then
            TextBox96.Text = My.Settings.fc
            TextBox95.Text = My.Settings.fy
            TextBox94.Text = My.Settings.fyp
        Else
            TextBox96.Text = ""
            TextBox95.Text = ""
            TextBox94.Text = ""
        End If
    End Sub

    Private Sub إعداداتToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        form2.Show()
    End Sub

    Private Sub تشغيلالآلةالحاسبيةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("c:\windows\system32\calc.exe")
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Shell("c:\windows\system32\calc.exe")
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        form2.Show()
    End Sub

    Private Sub ToolStripTextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.TextChanged, ToolStripTextBox2.TextChanged
        My.Settings.projectname = ToolStripTextBox1.Text
        My.Settings.username = ToolStripTextBox2.Text
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Me.Close()
        form2.Close()

    End Sub

    Private Sub حفظToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles حفظToolStripMenuItem.Click
        SaveFileDialog1.Filter = "EngineerCalculator|*.saad"
        SaveFileDialog1.FileName = "مشروع جديد"
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub فتحToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles فتحToolStripMenuItem.Click
        OpenFileDialog1.Filter = "EngineerCalculator|*.saad"
        OpenFileDialog1.FileName = "مشروع جديد"
        OpenFileDialog1.ShowDialog()
    End Sub

    Public Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        If TabPage5.Focus = True Then
            Button2_Click(Button2, e)
        ElseIf TabPage4.Focus = True Then
            Button1_Click(Button1, e)
        ElseIf TabPage9.Focus = True Then
            Button8_Click(Button8, e)
        ElseIf TabPage10.Focus = True Then
            Button9_Click(Button9, e)
        ElseIf TabPage11.Focus = True Then
            Button11_Click(Button11, e)
        ElseIf TabPage16.Focus = True Then
            Button10_Click(Button10, e)
        End If
    End Sub

    Private Sub طباعةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles طباعةToolStripMenuItem.Click
        PrintDialog1.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Form3.Show()
    End Sub

    Private Sub حسابToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles حسابToolStripMenuItem.Click
        ToolStripButton4.PerformClick()
    End Sub

    Private Sub تشغيلالألةالحاسبةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تشغيلالألةالحاسبةToolStripMenuItem.Click
        ToolStripButton5.PerformClick()
    End Sub

    Private Sub جدولالتسليحToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles جدولالتسليحToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        Form3.Show()
    End Sub

    Private Sub جدولالأعمدةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles جدولالأعمدةToolStripMenuItem.Click
        Form4.Show()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Shell("c:\windows\system32\calc.exe")
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Form3.Show()
    End Sub

    Private Sub ToolStripButton21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton21.Click
        Form4.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form5.Show()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Form5.Show()
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        Form6.Show()
    End Sub

    Private Sub إعداداتToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles إعداداتToolStripMenuItem.Click
        form2.Show()
    End Sub


    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            TextBox118.Text = My.Settings.fc
            TextBox117.Text = My.Settings.fy
            TextBox116.Text = My.Settings.fyp
        Else
            TextBox118.Text = ""
            TextBox117.Text = ""
            TextBox116.Text = ""
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim p, l, b, qall, tpc, fc, fy, bpc, brc, lpc, lrc, sum, fyp, cover As Double
        p = TextBox112.Text
        l = TextBox113.Text
        b = TextBox114.Text
        qall = TextBox115.Text
        tpc = TextBox119.Text
        fc = TextBox118.Text
        fy = TextBox117.Text
        fyp = TextBox116.Text
        cover = TextBox120.Text

        'تحديد القيمة b-a
        If b = l Then
            sum = 0
        ElseIf b > l Then
            sum = b - l
        ElseIf l > b Then
            sum = l - b
        End If

        'حساب أقل مساحة مطلوبة للقاعدة
        Dim apc As Double
        apc = p / qall

        'حساب طول ضلع القاعدة
        If b = l Then
            If tpc >= 20 Then
                bpc = Math.Sqrt(apc) 'القاعدة العادية
                lpc = bpc
                brc = bpc - 2 * tpc 'القاعدة المسلحة
                lrc = brc
            ElseIf tpc < 20 Then
                brc = Math.Sqrt(apc)
                lrc = brc
                bpc = brc + 2 * tpc
                lpc = bpc
            End If
        ElseIf b > l Or l > b Then
            Dim delta As Double
            If tpc >= 20 Then
                delta = sum ^ 2 + 4 * apc
                bpc = (-sum + Math.Sqrt(delta)) / 2
                lpc = apc / bpc
                brc = bpc - 2 * tpc
                lrc = lpc - 2 * tpc
            ElseIf tpc < 20 Then
                delta = sum ^ 2 + 4 * apc
                brc = (-sum + Math.Sqrt(delta)) / 2
                lrc = apc / brc
                bpc = brc + 2 * tpc
                lpc = lrc + 2 * tpc
            End If
        End If

        'مقاومة العزم (ارتفاع الاساس)س
        Dim fact, zi, zii, z, miact, miiact, di, dii, trc, tirc, tiirc As Double
        fact = p / (brc * lrc)

        'الاتجاه I
        zi = (lrc - b) / 2
        miact = (fact * zi * brc) * (zi / 2)
        di = 5 * Math.Sqrt(miact * (10 ^ 6) / (fc * brc * 1000))
        tirc = di + cover

        'الاتجاه II
        zii = (brc - apc) / 2
        miiact = (fact * zii * lrc) * (zii / 2)
        dii = 5 * Math.Sqrt(miiact * (10 ^ 6) / (fc * lrc * 1000))
        tiirc = dii + cover

        ' تحديد الارتفاع
        trc = Math.Max(tirc, tiirc)
        z = Math.Max(zi, zii)

    End Sub

    

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim rc As Integer = DataGridView1.RowCount - 1
        Dim l As Single(,) = New Single(rc + 10, 0) {}
        Dim p As Single(,) = New Single(rc + 10, 0) {}
        Dim m As Single(,) = New Single(rc + 10, 0) {}
        Dim q As Single(,) = New Single(rc + rc, 0) {}
        Dim re As Single(,) = New Single(rc + 10, 0) {}
        Dim i, j, h, r As Integer
        TextBox122.Text = 50
        For i = 0 To rc + 10
            'الأطوال والحمولة
            l(i, 0) = DataGridView1.Rows(i).Cells(0).Value.ToString()
            p(i, 0) = DataGridView2.Rows(i).Cells(0).Value.ToString()

            'مخطط العزم
            For j = 0 To rc + 10
                If rc - 1 = 0 Then
                    m(0, 0) = p(0, 0) * (l(0, 0) ^ 2) / 24
                    m(1, 0) = p(0, 0) * (l(0, 0) ^ 2) / 8
                    m(2, 0) = p(0, 0) * (l(0, 0) ^ 2) / 24
                ElseIf rc - 1 = 1 Then
                    m(0, 0) = p(0, 0) * (l(0, 0) ^ 2) / 24
                    m(1, 0) = p(0, 0) * (l(0, 0) ^ 2) / 11
                    m(2, 0) = ((p(0, 0) + p(1, 0)) / 2) * (((l(1, 0) + l(0, 0)) / 2) ^ 2) / 9
                    m(3, 0) = p(1, 0) * (l(1, 0) ^ 2) / 11
                    m(4, 0) = p(1, 0) * (l(1, 0) ^ 2) / 24
                Else
                    m(0, 0) = p(0, 0) * (l(0, 0) ^ 2) / 24
                    m(1, 0) = p(0, 0) * (l(0, 0) ^ 2) / 10
                    m(2, 0) = ((p(0, 0) + p(1, 0)) / 2) * (((l(0, 0) + l(1, 0)) / 2) ^ 2) / 10
                    If 3 + 2 * j > rc + 10 Then
                        On Error Resume Next
                    Else
                        m(3 + 2 * j, 0) = p(2 + j, 0) * (l(2 + j, 0) ^ 2) / 12
                    End If
                    If 2 + 2 * j > rc + 10 Then
                        On Error Resume Next
                    Else
                        m(2 + 2 * j, 0) = ((p(2 + j, 0) + p(3 + j, 0)) / 2) * (((l(2 + j, 0) + l(3 + j, 0)) / 2) ^ 2) / 14
                    End If
                    m(rc + 2, 0) = ((p(rc - 1, 0) + p(rc - 2, 0)) / 2) * (((l(rc - 1, 0) + l(rc - 2, 0)) / 2) ^ 2) / 10
                    m(rc + 3, 0) = p(rc - 1, 0) * (l(rc - 1, 0) ^ 2) / 10
                    m(rc + 4, 0) = p(rc - 1, 0) * (l(rc - 1, 0) ^ 2) / 24
                End If
                'نهاية مخطط العزم

                'مخطط القص
                For h = 0 To rc + rc
                    If rc - 1 = 0 Then
                        q(0, 0) = 0.9 * p(0, 0) * l(0, 0) / 2
                        q(1, 0) = 0
                        q(2, 0) = 0.9 * p(0, 0) * l(0, 0) / 2
                    ElseIf rc - 1 = 1 Then
                        q(0, 0) = 0.9 * p(0, 0) * l(0, 0) / 2
                        q(1, 0) = 0
                        q(2, 0) = 1.2 * ((p(0, 0) + p(1, 0)) / 2) * ((l(1, 0) + l(0, 0)) / 2) / 2
                        q(3, 0) = 1.2 * ((p(0, 0) + p(1, 0)) / 2) * ((l(1, 0) + l(0, 0)) / 2) / 2
                        q(4, 0) = 0
                        q(5, 0) = 0.9 * p(1, 0) * l(1, 0) / 2
                    Else
                        q(0, 0) = p(0, 0) * l(0, 0) / 2
                        q(1, 0) = 0
                        q(2, 0) = 1.15 * ((p(0, 0) + p(1, 0)) / 2) * ((l(0, 0) + l(1, 0)) / 2) / 2
                        q(3, 0) = ((p(0, 0) + p(1, 0)) / 2) * ((l(0, 0) + l(1, 0)) / 2) / 2
                        If 4 + 3 * j > rc + 10 Then
                            On Error Resume Next
                        Else
                            q(4 + 3 * j, 0) = 0
                        End If
                        If 4 + 2 * j > rc + 10 Then
                            On Error Resume Next
                        Else
                            q(4 + 2 * j, 0) = ((p(2 + j, 0) + p(3 + j, 0)) / 2) * ((l(2 + j, 0) + l(3 + j, 0)) / 2) / 2
                        End If
                        q(rc + rc - 3, 0) = ((p(rc - 1, 0) + p(rc - 2, 0)) / 2) * ((l(rc - 1, 0) + l(rc - 2, 0)) / 2) / 2
                        q(rc + rc - 2, 0) = p(rc - 1, 0) * l(rc - 1, 0) / 2
                        q(rc + rc - 1, 0) = 1.15 * p(rc - 1, 0) * l(rc - 1, 0) / 2
                        q(rc + rc, 0) = p(rc - 1, 0) * l(rc - 1, 0) / 2
                    End If
                    'نهاية مخطط القص

                    'ردود الافعال
                    For r = 0 To rc + 10
                        If rc - 1 = 0 Then
                            re(0, 0) = 0.45 * p(0, 0) * l(0, 0)
                            re(1, 0) = 0.45 * p(0, 0) * l(0, 0)
                        ElseIf rc - 1 = 1 Then
                            re(0, 0) = 0.45 * p(0, 0) * l(0, 0)
                            re(1, 0) = 1.15 * ((p(0, 0) + p(1, 0)) / 2) * ((l(1, 0) + l(0, 0)) / 2)
                            re(2, 0) = 0.45 * p(1, 0) * l(1, 0)
                        Else
                            re(0, 0) = p(0, 0) * l(0, 0) / 2
                            re(1, 0) = 1.1 * ((p(0, 0) + p(1, 0)) / 2) * ((l(1, 0) + l(0, 0)) / 2)
                            If 1 + j > rc + 10 Then
                                On Error Resume Next
                            Else
                                re(1 + j, 0) = ((p(j, 0) + p(1 + j, 0)) / 2) * ((l(j, 0) + l(1 + j, 0)) / 2)
                            End If
                            re(rc - 1, 0) = ((p(rc - 2, 0) + p(rc - 3, 0)) / 2) * ((l(rc - 2, 0) + l(rc - 3, 0)) / 2)
                            re(rc, 0) = 1.1 * ((p(rc - 1, 0) + p(rc - 2, 0)) / 2) * ((l(rc - 1, 0) + l(rc - 2, 0)) / 2)
                            re(rc + 1, 0) = p(rc - 1, 0) * l(rc - 1, 0) / 2
                        End If
                    Next
                Next
            Next
        Next
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            MsgBox("هل أنت متأكد من حذف السطر؟", vbOKCancel, "حذف سطر")
            DataGridView2.Rows.Remove(DataGridView2.SelectedRows(0))
        Else
            MessageBox.Show("اختر سطر لحذفه")
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            MsgBox("هل أنت متأكد من حذف السطر؟", vbOKCancel, "حذف سطر")
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("اختر سطر لحذفه")
        End If
    End Sub

End Class