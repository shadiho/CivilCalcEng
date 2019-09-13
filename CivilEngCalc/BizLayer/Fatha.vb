<Serializable>
Public Class Fatha
#Region "Properties"
    Private _length As Decimal
    Public Property length() As Decimal
        Get
            Return _length
        End Get
        Set(ByVal value As Decimal)
            _length = value
        End Set
    End Property

    Private _keta3 As Keta3
    Public Property keta3() As Keta3
        Get
            Return _keta3
        End Get
        Set(ByVal value As Keta3)
            _keta3 = value
        End Set
    End Property

    <NonSerialized>
    Private _fathaRow As DataGridViewRow
    Public Property fathaRow() As DataGridViewRow
        Get
            Return _fathaRow
        End Get
        Set(ByVal value As DataGridViewRow)
            _fathaRow = value
        End Set
    End Property

    Private _fathaIndex As Integer
    Public Property fathaIndex() As Integer
        Get
            Return _fathaIndex
        End Get
        Set(ByVal value As Integer)
            _fathaIndex = value
        End Set
    End Property

    Private _jayz As Jayz
    Public Property jayz() As Jayz
        Get
            Return _jayz
        End Get
        Set(ByVal value As Jayz)
            _jayz = value
        End Set
    End Property
#End Region

#Region "Functions"
    Public Sub New(jayz As Jayz)
        _jayz = jayz
        createFathaRow(jayz)
    End Sub

    Public Sub createFathaRow(jayz As Jayz)
        _fathaRow = New FathaRow(Me)

        Dim numCell As New DataGridViewTextBoxCell

        'numCell.Value = indx
        Dim lenCell As New DataGridViewTextBoxCell
        Dim keta3Cell As New DataGridViewComboBoxCell

        _fathaRow.Cells.Add(numCell)
        _fathaRow.Cells.Add(lenCell)
        _fathaRow.Cells.Add(keta3Cell)
        If _length > 0 Then
            lenCell.Value = _length
        End If
        For Each k As Keta3 In jayz.keta3List
            keta3Cell.Items.Add(k)
        Next

        numCell.ReadOnly = True

    End Sub

    Public Sub setIndex(indx As Integer)
        _fathaRow.Cells(0).Value = indx
    End Sub

    Public Sub load()
        _fathaRow.Cells(0).Value = _fathaIndex
        _fathaRow.Cells(1).Value = _length
        '_fathaRow.Cells(2).Value = _keta3.name
    End Sub
#End Region
End Class
