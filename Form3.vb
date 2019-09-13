Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database3DataSet.ورقة1' table. You can move, or remove it, as needed.
        'Me.ورقة1TableAdapter.Fill(Me.Database3DataSet.ورقة1)




    End Sub
    Private Sub مساحةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles مساحةToolStripMenuItem.Click
        Dim n, d As Integer
        Dim ass As Double
        d = InputBox("أدخل القطر", "القطر", "6")
        n = InputBox("أدخل العدد", "العدد", "1")
        ass = n * (Math.PI * (d ^ 2)) / 4
        MsgBox(Math.Round(ass, 0) & " mm2", MsgBoxStyle.Exclamation, "مساحة التسليح")
    End Sub

    Private Sub قطرToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles قطرToolStripMenuItem.Click
        Dim n, d As Integer
        Dim ass As Double
        ass = InputBox("أدخل مساحة التسليح mm2", "مساحة التسليح", "0")
        n = InputBox("أدخل العدد", "العدد", "1")
        d = Math.Sqrt((ass * 4) / (n * Math.PI))
        If d <= 6 Then
            d = 6
        ElseIf d <= 8 Then
            d = 8
        ElseIf d <= 10 Then
            d = 10
        ElseIf d <= 12 Then
            d = 12
        ElseIf d <= 14 Then
            d = 14
        ElseIf d <= 16 Then
            d = 16
        ElseIf d <= 18 Then
            d = 18
        ElseIf d <= 20 Then
            d = 20
        ElseIf d <= 22 Then
            d = 22
        ElseIf d <= 25 Then
            d = 25
        ElseIf d <= 28 Then
            d = 28
        ElseIf d <= 30 Then
            d = 30
        ElseIf d <= 32 Then
            d = 32
        ElseIf d <= 40 Then
            d = 40
        ElseIf d > 40 Then
            MsgBox("يجب زيادة عدد القضبان", vbExclamation, "قطر القضيب كبير جداً")
        End If
        MsgBox(d & " mm", MsgBoxStyle.Information, "القطر")
    End Sub

    Private Sub عددToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles عددToolStripMenuItem.Click
        Dim n, d As Integer
        Dim ass As Double
        ass = InputBox("أدخل مساحة التسليح mm2", "مساحة التسليح", "0")
        d = InputBox("أدخل القطر", "القطر", "6")
        n = Math.Ceiling((ass * 4) / (Math.PI * d ^ 2))
        Dim unit As String
        If n = 1 Then
            unit = " قضيب"
        ElseIf n = 2 Then
            unit = " قضيبين"
        ElseIf n > 2 Then
            unit = " قضبان"
        End If
        MsgBox(n & unit, MsgBoxStyle.Information, "العدد")
    End Sub
End Class