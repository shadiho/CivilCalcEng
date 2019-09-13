Public Class Form6
    Private strFormat As StringFormat
    Private arrColumnLefts As New ArrayList()
    Private arrColumnWidths As New ArrayList()
    Private iCellHeight As Integer = 0
    Private iTotalWidth As Integer = 0
    Private iRow As Integer = 0
    Private bFirstPage As Boolean = False
    Private bNewPage As Boolean = False
    Private iHeaderHeight As Integer = 0
    Private Sub printDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        Try

            strFormat = New StringFormat()
            strFormat.Alignment = StringAlignment.Near
            strFormat.LineAlignment = StringAlignment.Center
            strFormat.Trimming = StringTrimming.EllipsisCharacter
            arrColumnLefts.Clear()
            arrColumnWidths.Clear()
            iCellHeight = 0
            iRow = 0
            bFirstPage = True
            bNewPage = True
            iTotalWidth = 0
            For Each dgvGridCol As DataGridViewColumn In DataGridView1.Columns
                iTotalWidth += dgvGridCol.Width
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub


    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try

            Dim iLeftMargin As Integer = e.MarginBounds.Left
            Dim iTopMargin As Integer = e.MarginBounds.Top
            Dim bMorePagesToPrint As Boolean = False
            Dim iTmpWidth As Integer = 0
            If bFirstPage Then
                For Each GridCol As DataGridViewColumn In DataGridView1.Columns
                    iTmpWidth = Math.Floor(GridCol.Width / iTotalWidth * iTotalWidth * e.MarginBounds.Width / iTotalWidth)
                    iHeaderHeight = e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height + 11
                    arrColumnLefts.Add(iLeftMargin)
                    arrColumnWidths.Add(iTmpWidth)
                    iLeftMargin += iTmpWidth
                Next
            End If
            While iRow <= DataGridView1.Rows.Count - 1
                Dim GridRow As DataGridViewRow = DataGridView1.Rows(iRow)
                iCellHeight = GridRow.Height + 5
                Dim iCount As Integer = 0
                If iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                    bNewPage = True
                    bFirstPage = False
                    bMorePagesToPrint = True
                    Exit While
                Else
                    If bNewPage Then
                        e.Graphics.DrawString("  جدول تسيلح مقاطع قص" & My.Settings.projectname & " ، الخاص بالمهندس: " & My.Settings.username, New Font(DataGridView1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary", New Font(DataGridView1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)
                        Dim strDate As String = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString()
                        e.Graphics.DrawString(strDate, New Font(DataGridView1.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(strDate, New Font(DataGridView1.Font, FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top - e.Graphics.MeasureString("Customer Summary", New Font(New Font(DataGridView1.Font, FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13)
                        iTopMargin = e.MarginBounds.Top
                        For Each GridCol As DataGridViewColumn In DataGridView1.Columns
                            e.Graphics.FillRectangle(New SolidBrush(Color.LightGray), New Rectangle(DirectCast(arrColumnLefts(iCount), Integer), iTopMargin, DirectCast(arrColumnWidths(iCount), Integer), iHeaderHeight))
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(DirectCast(arrColumnLefts(iCount), Integer), iTopMargin, DirectCast(arrColumnWidths(iCount), Integer), iHeaderHeight))
                            e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, New SolidBrush(GridCol.InheritedStyle.ForeColor), New RectangleF(DirectCast(arrColumnLefts(iCount), Integer), iTopMargin, DirectCast(arrColumnWidths(iCount), Integer), iHeaderHeight), strFormat)
                            System.Math.Max(System.Threading.Interlocked.Increment(iCount), iCount - 1)
                        Next
                        bNewPage = False
                        iTopMargin += iHeaderHeight
                    End If
                    iCount = 0
                    For Each Cel As DataGridViewCell In GridRow.Cells
                        If Not Cel.Value Is Nothing Then
                            e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font, New SolidBrush(Cel.InheritedStyle.ForeColor), New RectangleF(DirectCast(arrColumnLefts(iCount), Integer), DirectCast(iTopMargin, Integer), DirectCast(arrColumnWidths(iCount), Integer), DirectCast(iCellHeight, Integer)), strFormat)
                        End If
                        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(DirectCast(arrColumnLefts(iCount), Integer), iTopMargin, DirectCast(arrColumnWidths(iCount), Integer), iCellHeight))
                        System.Math.Max(System.Threading.Interlocked.Increment(iCount), iCount - 1)
                    Next
                End If
                System.Math.Max(System.Threading.Interlocked.Increment(iRow), iRow - 1)
                iTopMargin += iCellHeight
            End While
            If bMorePagesToPrint Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If
        Catch exc As Exception
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub طباعةالجدولToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles طباعةالجدولToolStripMenuItem.Click
        'Preview
        'Dim printDialog As New PrintDialog()
        ' printDialog.UseEXDialog = True
        ' If DialogResult.OK = printDialog.ShowDialog() Then
        PrintPreviewDialog1.Document = PrintDocument1
        PrintDocument1.DocumentName = "Test Page Print"
        'PrintDocument1.Print()
        Me.PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub تصديرالجدولإلىMSExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles تصديرالجدولإلىMSExcelToolStripMenuItem.Click
        Try
            Dim MsExcel = CreateObject("Excel.Application")


            MsExcel.Workbooks.Add()


            For i As Integer = 0 To DataGridView1.Columns.Count - 1

                MsExcel.Cells(i + 1).Value = DataGridView1.Columns(i).HeaderText


            Next


            For i As Integer = 0 To DataGridView1.Columns.Count - 1


                For j As Integer = 0 To DataGridView1.Rows.Count - 1

                    MsExcel.Columns.HorizontalAlignment = 3


                    MsExcel.Columns.Font.Name = "Arial"


                    MsExcel.Rows.Item(j + 1).Font.Bold = 0


                    MsExcel.Rows.Item(j + 1).Font.size = 12

                    MsExcel.Cells(j + 1).ColumnWidth = 16

                    MsExcel.Cells(j + 2, i + 1).Value = DataGridView1.Rows(j).Cells(i).Value


                Next


            Next


            MsExcel.Visible = True


        Catch ex As Exception


            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            'you may want to add a confirmation message, and if the user confirms delete
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("اختر سطر لحذفه")
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            'you may want to add a confirmation message, and if the user confirms delete
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Else
            MessageBox.Show("اختر سطر لحذفه")
        End If
    End Sub
End Class