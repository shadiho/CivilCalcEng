Public Class form2

    Private Sub settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        username.Text = My.Settings.username
        TextBox1.Text = My.Settings.projectname
        fc.Text = My.Settings.fc
        fy.Text = My.Settings.fy
        fyp.Text = My.Settings.fyp
        dl.Text = My.Settings.dl
        ll.Text = My.Settings.ll
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fc.Click
        fc.SelectAll()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fy.Click
        fy.SelectAll()
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fyp.Click
        fyp.SelectAll()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ll.Text = "1.7"
            ll.Enabled = False
            dl.Text = "1.4"
            dl.Enabled = False
        End If
        If CheckBox1.Checked = False Then
            ll.Text = ""
            ll.Enabled = True
            dl.Text = ""
            dl.Enabled = True
        End If
    End Sub


    Private Sub ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ok.Click
        My.Settings.username = username.Text
        My.Settings.language = lang.SelectedItem
        My.Settings.fc = fc.Text
        My.Settings.fy = fy.Text
        My.Settings.fyp = fyp.Text
        My.Settings.ll = ll.Text
        My.Settings.dl = dl.Text
        My.Settings.projectname = TextBox1.Text
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Me.Close()
    End Sub
End Class
