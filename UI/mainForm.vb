Imports System.Drawing.Printing
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Forms

Public Class mainForm

#Region "Custom Functions"
    Public Sub refreshJayzDll()
        'Me.ddlProjJayz.BeginUpdate()
        Dim selectedIndex = ddlProjJayz.SelectedIndex
        Dim tmpList As New List(Of Jayz)
        For Each j As Jayz In ddlProjJayz.Items
            tmpList.Add(j)
        Next
        ddlProjJayz.Items.Clear()
        For Each j As Jayz In tmpList
            ddlProjJayz.Items.Add(j)
        Next

        Me.ddlProjJayz.SelectedIndex = selectedIndex
    End Sub

    Public Sub newProject()
        If _project Is Nothing Then
            _project = New Project("مشروع جديد", Me)
            ddlProjJayz.Items.Add(_project.jayzList.Item(0))
            ddlProjJayz.SelectedIndex = 0
            mainPanel.Controls.Add(_project.jayzList.Item(0).jayzUI)
            btnAddJayz.Visible = True

        End If
    End Sub

    Public Sub addJayz()
        _project.addJayz()
        ddlProjJayz.Items.Add(_project.jayzList.Last)
        mainPanel.Controls.Clear()
        mainPanel.Controls.Add(_project.jayzList.Last.jayzUI)
        ddlProjJayz.SelectedIndex = ddlProjJayz.Items.Count - 1

    End Sub

    Public Sub changeJayz()
        mainPanel.Controls.Clear()
        mainPanel.Controls.Add(CType(ddlProjJayz.SelectedItem, Jayz).jayzUI)
    End Sub
#End Region

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        newProject()
    End Sub

    Public Sub loadProject(fileName As String)
        _project = Project.load(fileName)
        If _project Is Nothing Then
            MsgBox("حدث خطأ أثناء فتح الملف ,قد يكون الملف غير صالح")
            Return
        End If
        _project.form = Me

        ddlProjJayz.Items.Clear()

        For Each j As Jayz In _project.jayzList
            j.jayzUI = New JayzCtrl(j)
            ddlProjJayz.Items.Add(j)
            ddlProjJayz.SelectedIndex = 0
        Next
        btnAddJayz.Visible = True
    End Sub


    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Civil Eng Calc (*.cec)|*.cec"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            loadProject(FileName)

            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Civil Eng Calc (*.cec)|*.cec"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer
    Private _project As Project
    Public Property project() As Project
        Get
            Return _project
        End Get
        Set(ByVal value As Project)
            _project = value
        End Set
    End Property


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnAddJayz.Click
        addJayz()
    End Sub


    Private Sub ddlProjJayz_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProjJayz.SelectedIndexChanged
        changeJayz()
    End Sub

    Public Sub saveProject(fileName As String)
        _project.save(fileName)
        MsgBox("تم الحفظ بنجاح", MsgBoxStyle.MsgBoxRight, "حفظ")
    End Sub

    Public Sub saveProject()
        If _project Is Nothing Then
            Return
        End If
        If _project.filePath = "" Then
            Dim SaveFileDialog As New SaveFileDialog
            SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            SaveFileDialog.Filter = "Civil Eng Calc (*.cec)|*.cec"
            SaveFileDialog.FileName = _project.projName
            If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                Dim FileName As String = SaveFileDialog.FileName
                saveProject(FileName)
            End If
        Else
            saveProject(_project.filePath)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        saveProject()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        saveProject()
    End Sub



    Private Sub mainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        mainPanel.Refresh()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        _project.jayzList.Item(0).jayzUI.print(e)
    End Sub


    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click

    End Sub

    Private Sub PrintPreviewToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintPreviewToolStripButton.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub
End Class
