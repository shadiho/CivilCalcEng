Public Class FrmKeta3
    Private _recKeta3 As Keta3Rectangle
    Public Property recKeta3() As Keta3Rectangle
        Get
            Return _recKeta3
        End Get
        Set(ByVal value As Keta3Rectangle)
            _recKeta3 = value
        End Set
    End Property

    Private _tehKeta3 As Keta3Teh
    Public Property tehKeta3() As Keta3Teh
        Get
            Return _tehKeta3
        End Get
        Set(ByVal value As Keta3Teh)
            _tehKeta3 = value
        End Set
    End Property

    Private _selectedKeta3 As Keta3
    Public Property selectedKeta3() As Keta3
        Get
            Return _selectedKeta3
        End Get
        Set(ByVal value As Keta3)
            _selectedKeta3 = value
        End Set
    End Property

    Private _ignoreTxtChangeEvent As Boolean = False
    Public Property ignoteTxtChangeEvent() As Boolean
        Get
            Return _ignoreTxtChangeEvent
        End Get
        Set(ByVal value As Boolean)
            _ignoreTxtChangeEvent = value
        End Set
    End Property

    ''' <summary>
    ''' filter text box to accept decimal numbers
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub decimalNumFilter(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles HTxt.KeyPress, AtehTxt.KeyPress, ATxt.KeyPress, AFathaTehTxt.KeyPress, AFathaTxt.KeyPress, BTxt.KeyPress, BFTxt.KeyPress, TsTxt.KeyPress, BwTxt.KeyPress
        If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "." Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub calc() Handles AFathaTxt.TextChanged, ATxt.TextChanged, HTxt.TextChanged, BTxt.TextChanged, txtWaznHajmi.TextChanged, BFTxt.TextChanged, TsTxt.TextChanged, AFathaTehTxt.TextChanged, AFathaTxt.TextChanged, BwTxt.TextChanged

        If _ignoreTxtChangeEvent Then
            Return
        End If
        If AFathaTehTxt.Text = "" Or AtehTxt.Text = "" Or HTxt.Text = "" Or BTxt.Text = "" Or txtWaznHajmi.Text = "" Or BFTxt.Text = "" Or TsTxt.Text = "" Or AFathaTehTxt.Text = "" Or AFathaTxt.Text = "" Or BwTxt.Text = "" Then
            'MsgBox("لا يمكن أن تكون القيمة خالية", MsgBoxStyle.OkOnly, "خطأ")
            Return
        End If
        Dim recKeta3 As New Keta3Rectangle(txtName.Text)
        Dim tehKeta3 As New Keta3Teh(txtName.Text)
        recKeta3.a = ATxt.Text
        recKeta3.aFatha = AFathaTxt.Text
        recKeta3.h = HTxt.Text
        recKeta3.b = BTxt.Text
        recKeta3.waznHajmi = txtWaznHajmi.Text
        recKeta3.calc()

        tehKeta3.a = AtehTxt.Text
        tehKeta3.aFatha = AFathaTehTxt.Text
        tehKeta3.bf = BFTxt.Text
        tehKeta3.ts = TsTxt.Text
        tehKeta3.bw = BwTxt.Text
        tehKeta3.waznHajmi = txtWaznHajmi.Text
        tehKeta3.calc()

        If TypeOf (selectedKeta3) Is Keta3Rectangle Then
            txtWaznThati.Text = recKeta3.waznThati
            txtAzem.Text = recKeta3.azem3atala
            txtArea.Text = recKeta3.area
        Else
            txtWaznThati.Text = tehKeta3.waznThati
            txtAzem.Text = tehKeta3.azem3atala
            txtArea.Text = tehKeta3.area
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'loadData()
    End Sub

    Public Function getKeta3Shape() As String
        If TypeOf (selectedKeta3) Is Keta3Rectangle Then
            Return "مستطيل"
        Else
            Return "تيه"
        End If
    End Function

    Public Sub setSelectedKeta3(k As Keta3)
        If TypeOf (k) Is Keta3Rectangle Then
            _recKeta3 = k
        Else
            _tehKeta3 = k
        End If
        _selectedKeta3 = k
    End Sub

    Public Sub loadData()
        _ignoreTxtChangeEvent = True
        If _tehKeta3 Is Nothing Then
            _tehKeta3 = New Keta3Teh("قطاع جديد")
        End If
        If _recKeta3 Is Nothing Then
            _recKeta3 = New Keta3Rectangle("قطاع جديد")
        End If

        If _selectedKeta3 Is Nothing Then
            _selectedKeta3 = _recKeta3
        End If
        _recKeta3.calc()
        _tehKeta3.calc()
        ATxt.Text = _recKeta3.a
        AFathaTxt.Text = _recKeta3.aFatha
        HTxt.Text = _recKeta3.h
        BTxt.Text = _recKeta3.b

        AtehTxt.Text = _tehKeta3.a
        AFathaTehTxt.Text = _tehKeta3.aFatha
        BFTxt.Text = _tehKeta3.bf
        TsTxt.Text = _tehKeta3.ts
        BwTxt.Text = _tehKeta3.bw

        loadSelectedKeta3Data()
        _ignoreTxtChangeEvent = False
    End Sub



    Private Sub loadSelectedKeta3Data()
        txtName.Text = _selectedKeta3.name
        txtWaznHajmi.Text = _selectedKeta3.waznHajmi
        txtArea.Text = _selectedKeta3.area
        txtAzem.Text = _selectedKeta3.azem3atala
        txtWaznThati.Text = _selectedKeta3.waznThati
    End Sub

    Private Sub saveSelectedKeta3Data()


        txtArea.Text = _selectedKeta3.area
        txtAzem.Text = _selectedKeta3.azem3atala
        txtWaznThati.Text = _selectedKeta3.waznThati
    End Sub

    Private Sub tabKeta3at_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabKeta3at.SelectedIndexChanged
        If tabKeta3at.SelectedIndex = 0 Then
            _selectedKeta3 = recKeta3
        Else
            _selectedKeta3 = tehKeta3
        End If
        calc()
    End Sub

    Private Sub save()

        _recKeta3.a = ATxt.Text
        _recKeta3.aFatha = AFathaTxt.Text
        _recKeta3.h = HTxt.Text
        _recKeta3.b = BTxt.Text
        _recKeta3.waznHajmi = txtWaznHajmi.Text
        _recKeta3.name = txtName.Text

        _tehKeta3.a = AtehTxt.Text
        _tehKeta3.aFatha = AFathaTehTxt.Text
        _tehKeta3.bf = BFTxt.Text
        _tehKeta3.ts = TsTxt.Text
        _tehKeta3.bw = BwTxt.Text
        _tehKeta3.waznHajmi = txtWaznHajmi.Text
        _tehKeta3.name = txtName.Text

        _selectedKeta3.waznThati = txtWaznThati.Text
        _selectedKeta3.azem3atala = txtAzem.Text
        _selectedKeta3.area = txtArea.Text
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If TypeOf (_selectedKeta3) Is Keta3Teh And (AFathaTehTxt.Text = "" Or AtehTxt.Text = "" Or BFTxt.Text = "" Or TsTxt.Text = "" Or AFathaTehTxt.Text = "" Or BwTxt.Text = "") Then
            MsgBox("أحد قيم القطاع خالية", MsgBoxStyle.OkOnly, "خطأ")
            Return
        End If
        If TypeOf (_selectedKeta3) Is Keta3Rectangle And (HTxt.Text = "" Or BTxt.Text = "" Or txtWaznHajmi.Text = "" Or AFathaTxt.Text = "" Or ATxt.Text = "" Or txtWaznHajmi.Text = "") Then
            MsgBox("أحد قيم القطاع خالية", MsgBoxStyle.OkOnly, "خطأ")
            Return
        End If
        save()
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub
End Class