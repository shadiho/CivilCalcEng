Imports System.Drawing.Printing

Public Class JayzCtrl
#Region "Properties"
    Private _jayz As Jayz
    Public Property jayz() As Jayz
        Get
            Return _jayz
        End Get
        Set(ByVal value As Jayz)
            _jayz = value
        End Set
    End Property

    Private _drawingPanel As DrawingPanel
    Public Property drawingPanel() As DrawingPanel
        Get
            Return _drawingPanel
        End Get
        Set(ByVal value As DrawingPanel)
            _drawingPanel = value
        End Set
    End Property

    Private _addingNewFatha As Boolean
    Public Property addingNewFatha() As Boolean
        Get
            Return _addingNewFatha
        End Get
        Set(ByVal value As Boolean)
            _addingNewFatha = value
        End Set
    End Property
#End Region



#Region "Functions Jayz Properties"
    Public Sub fillJayzType()
        ddlJayType.Items.Add("جائز")
        ddlJayType.Items.Add("عصب")
    End Sub

    Public Sub selectJayzType()
        If _jayz.type = Jayz.jayzTypes.asab Then
            ddlJayType.SelectedIndex = 1
        Else
            ddlJayType.SelectedIndex = 0

        End If
    End Sub

    Public Sub updateJayzName()
        If Not _jayz.project.validateNewJayzName(_jayz, txtJayzName.Text) Then
            MsgBox("الاسم مستخدم لجائز آخر", MsgBoxStyle.Critical, "خطأ")
            txtJayzName.Text = CType(_jayz.project.form.ddlProjJayz.SelectedItem, Jayz).jayzName.Trim
            Return
        End If
        _jayz.jayzName = txtJayzName.Text.Trim
        _jayz.project.form.refreshJayzDll()
    End Sub


    Public Sub New(jayz As Jayz)

        ' This call is required by the designer.
        InitializeComponent()
        _drawingPanel = New DrawingPanel(jayz)

        drwPanel.Controls.Add(_drawingPanel)

        _jayz = jayz
        fillJayzType()
        fillMasnadTypes(ddlStartMasnadType)
        fillMasnadTypes(ddlEndMasnadType)
        If _jayz.masnadList.Count = 0 Then
            Dim m As New Masnad
            setMasnadType(m, ddlStartMasnadType)
            _jayz.masnadList.Add(m)
        End If

        ' Add any initialization after the InitializeComponent() call.
        Me.Dock = DockStyle.Fill

        Me.AutoSize = False
        If _jayz IsNot Nothing Then
            txtJayzName.Text = _jayz.jayzName
            txtJayzComment.Text = _jayz.comments
            nudCount.Value = _jayz.jayzCount
            selectJayzType()
            loadKeta3at()
            loadFathat()
            loadMasand()
        End If

    End Sub

    Private Sub txtJayzName_LostFocus(sender As Object, e As EventArgs) Handles txtJayzName.LostFocus
        updateJayzName()
    End Sub

    Private Sub txtJayzName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtJayzName.KeyUp
        If e.KeyCode = Keys.Enter Then
            updateJayzName()
        End If
    End Sub

    Private Sub ddlJayType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlJayType.SelectedIndexChanged
        If ddlJayType.SelectedIndex = 0 Then
            _jayz.type = Jayz.jayzTypes.jayz
        Else
            _jayz.type = Jayz.jayzTypes.asab
        End If
    End Sub

    Private Sub nudCount_ValueChanged(sender As Object, e As EventArgs) Handles nudCount.ValueChanged
        _jayz.jayzCount = nudCount.Value
    End Sub

    Private Sub txtJayzComment_LostFocus(sender As Object, e As EventArgs) Handles txtJayzComment.LostFocus
        _jayz.comments = txtJayzComment.Text
    End Sub
#End Region

#Region "Functions Masand"
    Public Sub fillMasnadTypes(ddl As ComboBox)
        ddl.Items.Add("مسند أحادي")
        ddl.Items.Add("وثاقة")
        ddl.Items.Add("ظفر")
        ddl.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Public Sub setMasnadType(masnad As Masnad, ddl As ComboBox)
        Select Case ddl.SelectedIndex
            Case 0
                masnad.type = Masnad.MasnadTypes.ohadi
            Case 1
                masnad.type = Masnad.MasnadTypes.wtha2a
            Case 2
                masnad.type = Masnad.MasnadTypes.dofr
        End Select
    End Sub

    Public Sub setSelectItemInMasnadTypeDll(masnad As Masnad, ddl As ComboBox)
        Select Case masnad.type
            Case Masnad.MasnadTypes.ohadi
                ddl.SelectedIndex = 0
            Case Masnad.MasnadTypes.wtha2a
                ddl.SelectedIndex = 1
            Case Masnad.MasnadTypes.dofr
                ddl.SelectedIndex = 2
        End Select
    End Sub

    Public Sub addMasnad(index As Integer)
        Dim masnad As New Masnad
        If (index = _jayz.masnadList.Count) Then
            setMasnadType(masnad, ddlEndMasnadType)
        End If
        grdMasand.Rows.Insert(index, masnad.masnadRow)
        masnad.masnadRow.Cells(1).Selected = True
        _jayz.addMasnadAt(index, masnad)

        For i As Integer = 1 To _jayz.masnadList.Count - 2
            _jayz.masnadList(i).type = Masnad.MasnadTypes.ohadi
        Next
    End Sub

    ''' <summary>
    ''' update the indexes of fathat to be shown in the grid
    ''' </summary>
    Public Sub updateMasandIndex()
        Dim i As Integer = 1
        For Each m As Masnad In _jayz.masnadList
            m.setIndex(i)
            i += 1
        Next
    End Sub

    ''' <summary>
    ''' function to be called when we start pdating a cell
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdMasnad_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grdMasand.CellBeginEdit
        enableDisableFormCtrls(False)
    End Sub

    ''' <summary>
    ''' end editing a cell
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdMasand_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdMasand.CellEndEdit
        Try
            Dim currVal As Object = grdMasand.SelectedCells(0).Value
            Dim selectedRow As MasnadRow = grdMasand.Rows(grdMasand.SelectedCells(0).RowIndex)
            If grdMasand.SelectedCells(0).ColumnIndex = 1 Then
                selectedRow.masnad.width = currVal
            Else
                selectedRow.masnad.masnadName = currVal
            End If
            _drawingPanel.draw()
            enableDisableFormCtrls(True)
        Catch ex As Exception
        End Try

    End Sub

    ''' <summary>
    ''' to add the decimal filter to the text box of length 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdMasnad_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grdMasand.EditingControlShowing
        If grdMasand.SelectedCells(0).ColumnIndex = 1 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf decimalNumFilter
        End If
    End Sub

    ''' <summary>
    ''' load all fathat and create their rows
    ''' </summary>
    Public Sub loadMasand()
        Dim indx As Integer = 0
        For Each m As Masnad In _jayz.masnadList
            If indx = 0 Then
                setSelectItemInMasnadTypeDll(m, ddlStartMasnadType)
            End If
            If indx = _jayz.masnadList.Count - 1 Then
                setSelectItemInMasnadTypeDll(m, ddlEndMasnadType)
            End If
            m.createMasnadRow()
            grdMasand.Rows.Add(m.masnadRow)
            indx += 1

        Next
        updateMasandIndex()
    End Sub

#End Region

#Region "Functions Jayz Fathat"

    Public Sub createDummyFatha()
        Dim fatha As New Fatha(_jayz)
        fatha.createFathaRow(_jayz)
        CType(fatha.fathaRow, FathaRow).isDummy = True
        grdFathat.Rows.Add(fatha.fathaRow)
        CType(fatha.fathaRow, FathaRow).Cells(0).Value = grdFathat.Rows.Count
    End Sub

    ''' <summary>
    ''' load all fathat and create their rows
    ''' </summary>
    Public Sub loadFathat()
        For Each f As Fatha In _jayz.fathaList
            f.createFathaRow(_jayz)
            grdFathat.Rows.Add(f.fathaRow)
        Next
        createDummyFatha()
        updateFathatIndx()
    End Sub

    ''' <summary>
    ''' create new fatha and add its row to the grid
    ''' </summary>
    ''' <param name="indx"></param>
    Public Sub addFatha(indx As Integer)
        Dim newFatha As New Fatha(_jayz)
        grdFathat.Rows.Insert(indx, newFatha.fathaRow)
        '_jayz.addFathaAt(indx, newFatha)
        newFatha.fathaRow.Cells(1).Selected = True
        updateFathatIndx()
        grdFathat.BeginEdit(False)
    End Sub



    ''' <summary>
    ''' update the indexes of fathat to be shown in the grid
    ''' </summary>
    Public Sub updateFathatIndx()
        Dim i As Integer = 1
        For Each f As FathaRow In grdFathat.Rows
            f.Cells(0).Value = i
            i += 1
        Next
    End Sub

    ''' <summary>
    ''' add fatha button handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAddFatha_Click(sender As Object, e As EventArgs) Handles btnAddFatha.Click
        _addingNewFatha = True
        If grdFathat.Rows.Count > 0 AndAlso grdFathat.CurrentCell.RowIndex > 0 Then
            addFatha(grdFathat.CurrentCell.RowIndex)
        Else
            addFatha(0)
        End If
    End Sub


    ''' <summary>
    ''' enable and disable all cotrols of form and jayz control while doing specific operations
    ''' </summary>
    ''' <param name="enable"></param>
    Public Sub enableDisableFormCtrls(enable As Boolean)
        btnAddFatha.Enabled = enable
        btnDeleteFatha.Enabled = enable
        _jayz.project.form.MenuStrip.Enabled = enable
        _jayz.project.form.ToolStrip.Enabled = enable
    End Sub


    ''' <summary>
    ''' function to be called when we start pdating a cell
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdFathat_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles grdFathat.CellBeginEdit
        enableDisableFormCtrls(False)
    End Sub

    ''' <summary>
    ''' remove the rows with empty or zero value
    ''' </summary>
    Private Sub removeNewRow()

        For Each r As FathaRow In grdFathat.Rows
            If r.Cells(1).Value Is Nothing OrElse r.Cells(1).Value = 0 Then
                grdFathat.Rows.Remove(r)
                '_jayz.removeFatha(r.fatha)
            End If
        Next
        createDummyFatha()
    End Sub

    ''' <summary>
    ''' end editing a cell
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdFathat_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdFathat.CellEndEdit
        Try
            If (grdFathat.SelectedCells(0).ColumnIndex = 1) Then
                Dim cellVal As Object = CType(grdFathat.Rows(e.RowIndex), FathaRow).Cells(1).Value
                If cellVal Is Nothing OrElse cellVal = 0 Then

                    If Not grdFathat.Rows(e.RowIndex).Cells(1).IsInEditMode Then
                        If Not CType(grdFathat.Rows(e.RowIndex), FathaRow).isDummy Then
                            Me.BeginInvoke(New MethodInvoker(AddressOf removeNewRow))
                        End If
                    End If
                Else
                    Dim fathaRow As FathaRow = CType(grdFathat.Rows(e.RowIndex), FathaRow)
                    fathaRow.fatha.length = fathaRow.Cells(1).Value
                    Dim addingDummyFatha As Boolean = fathaRow.isDummy

                    If fathaRow.isDummy Then
                        fathaRow.convertToReal()
                        createDummyFatha()
                        grdFathat.Rows(grdFathat.Rows.Count - 1).Cells(1).Selected = True
                        _addingNewFatha = True
                    End If
                    If _addingNewFatha Then
                        _jayz.addFathaAt(e.RowIndex, fathaRow.fatha)
                        If Not addingDummyFatha Then
                            addMasnad(e.RowIndex + 1)
                        Else
                            addMasnad(e.RowIndex + 1)
                        End If

                    End If

                    updateMasandIndex()
                    _drawingPanel.draw()
                End If
            End If

            enableDisableFormCtrls(True)
        Catch ex As Exception
            grdFathat.Rows(e.RowIndex).Selected = True
            grdFathat.BeginEdit(False)
        Finally
            _addingNewFatha = False
        End Try

    End Sub

    ''' <summary>
    ''' filter text box to accept decimal numbers
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub decimalNumFilter(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "." Or e.KeyChar = vbBack) Then e.Handled = True

    End Sub

    ''' <summary>
    ''' to add the decimal filter to the text box of length 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdFathat_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grdFathat.EditingControlShowing
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf decimalNumFilter
    End Sub

    Private Sub btnDeleteFatha_Click(sender As Object, e As EventArgs) Handles btnDeleteFatha.Click
        If CType(grdFathat.Rows(grdFathat.SelectedCells(0).RowIndex), FathaRow).isDummy Then
            Return
        End If
        If grdFathat.SelectedCells.Count > 0 Then
            If MsgBox("هل أنت متأكد من أنك تريد حذف الفتحة", MsgBoxStyle.OkCancel, "تحذير") = MsgBoxResult.Ok Then
                Dim currIndx As Integer = grdFathat.SelectedCells(0).RowIndex
                grdFathat.Rows.RemoveAt(currIndx)
                _jayz.removeFathaAt(currIndx)
                updateFathatIndx()

                grdMasand.Rows.RemoveAt(currIndx + 1)
                _jayz.removeMasnadAt(currIndx + 1)
                updateMasandIndex()
                If grdFathat.RowCount > 1 Then
                    If CType(grdFathat.Rows(currIndx), FathaRow).isDummy Then
                        grdFathat.Rows(currIndx - 1).Cells(1).Selected = True
                    Else
                        grdFathat.Rows(currIndx).Cells(1).Selected = True
                    End If
                Else
                    grdFathat.Rows(currIndx).Cells(1).Selected = True
                End If
                _drawingPanel.draw()
            End If
        End If
    End Sub

    Public Sub print(e As PrintPageEventArgs)
        drawingPanel.printPanel(e)
    End Sub

    Private Sub ddlEndMasnadType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEndMasnadType.SelectedIndexChanged
        If _jayz IsNot Nothing AndAlso _jayz.masnadList.Count > 1 Then
            setMasnadType(_jayz.masnadList(_jayz.masnadList.Count - 1), ddlEndMasnadType)
            _drawingPanel.draw()
        End If
    End Sub

    Private Sub ddlStartMasnadType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStartMasnadType.SelectedIndexChanged
        If _jayz IsNot Nothing Then
            setMasnadType(_jayz.masnadList(0), ddlStartMasnadType)
            _drawingPanel.draw()
        End If
    End Sub

#End Region

#Region "Keta3at Functions"
    Private Sub btnAddKta3_Click(sender As Object, e As EventArgs) Handles btnAddKta3.Click
        Dim kForm As New FrmKeta3
        kForm.loadData()
        Dim res As DialogResult = kForm.ShowDialog()
        If res = DialogResult.OK Then
            _jayz.keta3List.Add(kForm.selectedKeta3)
            kForm.selectedKeta3.createKeta3Row(_jayz.keta3List.Count)
            kForm.recKeta3.keta3Row = kForm.selectedKeta3.keta3Row
            kForm.tehKeta3.keta3Row = kForm.selectedKeta3.keta3Row
            grdKita3at.Rows.Add(kForm.selectedKeta3.keta3Row)
        End If

    End Sub
    Private Sub loadKeta3at()
        Dim indx As Integer = 1
        For Each k As Keta3 In _jayz.keta3List
            Dim kform As New FrmKeta3
            kform.setSelectedKeta3(k)
            kform.loadData()
            kform.selectedKeta3.createKeta3Row(indx)
            grdKita3at.Rows.Add(kform.selectedKeta3.keta3Row)
            indx += 1
        Next
    End Sub

    Private Sub grdKita3at_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdKita3at.CellDoubleClick
        Dim r As Keta3Row = grdKita3at.Rows(e.RowIndex)
        If r.keta3Form.ShowDialog() = DialogResult.OK Then
            r.keta3Form.selectedKeta3.keta3Row = r
            r.keta3Form.selectedKeta3.refreshRowData(r.keta3Form)
            _jayz.keta3List(e.RowIndex) = r.keta3Form.selectedKeta3
        End If

    End Sub
#End Region
End Class
