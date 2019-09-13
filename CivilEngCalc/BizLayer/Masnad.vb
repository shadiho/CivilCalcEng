<Serializable>
Public Class Masnad
#Region "Properties"
    Private _width As Decimal
    Public Property width() As Decimal
        Get
            Return _width
        End Get
        Set(ByVal value As Decimal)
            _width = value
        End Set
    End Property

    Private _masnadName As String
    Public Property masnadName() As String
        Get
            Return _masnadName
        End Get
        Set(ByVal value As String)
            _masnadName = value
        End Set
    End Property

    Public Enum MasnadTypes
        normal
        ohadi
        dofr
        wtha2a
    End Enum

    Private _type As MasnadTypes = MasnadTypes.normal
    Public Property type() As MasnadTypes
        Get
            Return _type
        End Get
        Set(ByVal value As MasnadTypes)
            _type = value
        End Set
    End Property

    <NonSerialized>
    Private _masnadRow As MasnadRow
    Public Property masnadRow() As MasnadRow
        Get
            Return _masnadRow
        End Get
        Set(ByVal value As MasnadRow)
            _masnadRow = value
        End Set
    End Property

#End Region

#Region "Functions"
    Public Sub New()
        _width = 40
        _type = MasnadTypes.ohadi
        _masnadName = ""
        createMasnadRow()
    End Sub

    Public Sub createMasnadRow()
        _masnadRow = New MasnadRow(Me)

        Dim numCell As New DataGridViewTextBoxCell
        Dim widthCell As New DataGridViewTextBoxCell
        Dim nameCell As New DataGridViewTextBoxCell

        _masnadRow.Cells.Add(numCell)
        _masnadRow.Cells.Add(widthCell)
        _masnadRow.Cells.Add(nameCell)
        If _width > 0 Then
            widthCell.Value = _width
        End If
        numCell.ReadOnly = True
        nameCell.Value = _masnadName
    End Sub

    Public Sub setIndex(index As Integer)
        _masnadRow.Cells(0).Value = index
    End Sub
#End Region

End Class
