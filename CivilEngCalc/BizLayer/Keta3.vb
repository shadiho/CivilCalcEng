<Serializable>
Public MustInherit Class Keta3

#Region "Properties"
    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _h As Decimal = 600
    Public Property h() As Decimal
        Get
            Return _h
        End Get
        Set(ByVal value As Decimal)
            _h = value
        End Set
    End Property
    Private _a As Decimal = 50
    Public Property a() As Decimal
        Get
            Return _a
        End Get
        Set(ByVal value As Decimal)
            _a = value
        End Set
    End Property

    Private _aFatha As Decimal = 50
    Public Property aFatha() As Decimal
        Get
            Return _aFatha
        End Get
        Set(ByVal value As Decimal)
            _aFatha = value
        End Set
    End Property

    Private _waznHajmi As Decimal = 25
    Public Property waznHajmi() As Decimal
        Get
            Return _waznHajmi
        End Get
        Set(ByVal value As Decimal)
            _waznHajmi = value
        End Set
    End Property

    Private _area As Decimal
    Public Property area() As Decimal
        Get
            Return _area
        End Get
        Set(ByVal value As Decimal)
            _area = value
        End Set
    End Property

    Private _azem3atala As Decimal
    Public Property azem3atala() As Decimal
        Get
            Return _azem3atala
        End Get
        Set(ByVal value As Decimal)
            _azem3atala = value
        End Set
    End Property

    Private _waznThati As Decimal
    Public Property waznThati() As Decimal
        Get
            Return _waznThati
        End Get
        Set(ByVal value As Decimal)
            _waznThati = value
        End Set
    End Property

    <NonSerialized>
    Private _keta3Row As Keta3Row
    Public Property keta3Row() As Keta3Row
        Get
            Return _keta3Row
        End Get
        Set(ByVal value As Keta3Row)
            _keta3Row = value
        End Set
    End Property
#End Region

#Region "Functions"
    Public Sub New(name As String)
        _name = name
        Me.calc()
    End Sub

    Public MustOverride Sub calc()

    Public Sub createKeta3Row(indx As Integer)
        Dim kForm As New FrmKeta3
        kForm.selectedKeta3 = Me
        kForm.loadData()
        _keta3Row = New Keta3Row(kForm)

        Dim numCell As New DataGridViewTextBoxCell
        Dim shapeCell As New DataGridViewTextBoxCell
        Dim nameCell As New DataGridViewTextBoxCell
        Dim infoCell As New DataGridViewTextBoxCell

        _keta3Row.Cells.Add(numCell)
        _keta3Row.Cells.Add(shapeCell)
        _keta3Row.Cells.Add(nameCell)
        _keta3Row.Cells.Add(infoCell)


        numCell.ReadOnly = True
        numCell.Value = indx
        nameCell.ReadOnly = True
        nameCell.Value = _name
        shapeCell.ReadOnly = True
        shapeCell.Value = kForm.getKeta3Shape
        infoCell.ReadOnly = True
        infoCell.Value = kForm.selectedKeta3.getInfo
    End Sub

    Public Sub refreshRowData(frm As FrmKeta3)
        _keta3Row.Cells(1).Value = frm.getKeta3Shape
        _keta3Row.Cells(2).Value = _name
        _keta3Row.Cells(3).Value = frm.selectedKeta3.getInfo
    End Sub


    Public Function getInfo() As String
        Return "م=" + area.ToString + "مم2" + ",ع =" + azem3atala.ToString + "مم4" + ",و =" + waznThati.ToString + "طن/م"
    End Function

    Public Overrides Function ToString() As String
        Return _name
    End Function
#End Region
End Class
