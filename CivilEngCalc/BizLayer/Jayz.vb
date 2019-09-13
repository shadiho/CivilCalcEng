<Serializable>
Public Class Jayz
#Region "Properties"

    Public Enum jayzTypes
        jayz = 0
        asab = 1
    End Enum

    Private _project As Project
    Public Property project() As Project
        Get
            Return _project
        End Get
        Set(ByVal value As Project)
            _project = value
        End Set
    End Property

    Private _jayzName As String
    Public Property jayzName() As String
        Get
            Return _jayzName
        End Get
        Set(ByVal value As String)
            _jayzName = value
        End Set
    End Property

    Private _jayzCount As Integer
    Public Property jayzCount() As Integer
        Get
            Return _jayzCount
        End Get
        Set(ByVal value As Integer)
            _jayzCount = value
        End Set
    End Property


    Private _length As Decimal
    Public Property length() As Decimal
        Get
            Return _length
        End Get
        Set(ByVal value As Decimal)
            _length = value
        End Set
    End Property

    Private _type As jayzTypes
    Public Property type() As jayzTypes
        Get
            Return _type
        End Get
        Set(ByVal value As jayzTypes)
            _type = value
        End Set
    End Property

    Private _comments As String
    Public Property comments() As String
        Get
            Return _comments
        End Get
        Set(ByVal value As String)
            _comments = value
        End Set
    End Property


    Private _fathaList As List(Of Fatha)
    Public Property fathaList() As List(Of Fatha)
        Get
            Return _fathaList
        End Get
        Set(ByVal value As List(Of Fatha))
            _fathaList = value
        End Set
    End Property

    Private _masnadList As List(Of Masnad)
    Public Property masnadList() As List(Of Masnad)
        Get
            Return _masnadList
        End Get
        Set(ByVal value As List(Of Masnad))
            _masnadList = value
        End Set
    End Property

    Private _keta3List As List(Of Keta3)
    Public Property keta3List() As List(Of Keta3)
        Get
            Return _keta3List
        End Get
        Set(ByVal value As List(Of Keta3))
            _keta3List = value
        End Set
    End Property

    Private _affectForceList As List(Of AffectedForce)
    Public Property affectForceList() As List(Of AffectedForce)
        Get
            Return _affectForceList
        End Get
        Set(ByVal value As List(Of AffectedForce))
            _affectForceList = value
        End Set
    End Property

    <NonSerialized>
    Private _jayzUI As JayzCtrl
    Public Property jayzUI() As JayzCtrl
        Get
            Return _jayzUI
        End Get
        Set(ByVal value As JayzCtrl)
            _jayzUI = value
        End Set
    End Property
#End Region

#Region "Functions"
    Public Sub New(name As String, comments As String, project As Project)
        _jayzName = name
        _project = project
        _comments = comments
        _fathaList = New List(Of Fatha)
        _masnadList = New List(Of Masnad)
        _jayzCount = 1
        _keta3List = New List(Of Keta3)
        Dim defKeta3 = New Keta3Rectangle("قطاع جديد")
        defKeta3.calc()
        _keta3List.Add(defKeta3)
        _affectForceList = New List(Of AffectedForce)
        _type = jayzTypes.jayz
        _jayzUI = New JayzCtrl(Me)

    End Sub

    Public Overrides Function ToString() As String
        Return _jayzName
    End Function

    Public Sub addFatha(fatha As Fatha)
        _fathaList.Add(fatha)
        _length += fatha.length
    End Sub

    Public Sub addFathaAt(index As Integer, fatha As Fatha)
        _fathaList.Insert(index, fatha)
        _length += fatha.length
    End Sub

    Public Sub addMasnad(masnad As Masnad)
        _masnadList.Add(masnad)
    End Sub

    Public Sub addMasnadAt(index As Integer, masnad As Masnad)
        masnad.masnadRow.Cells(0).Value = index + 1
        _masnadList.Insert(index, masnad)
    End Sub

    Public Sub removeMasnadAt(index As Integer)
        _masnadList.RemoveAt(index)
    End Sub

    Public Sub removeFatha(fatha As Fatha)
        _fathaList.Remove(fatha)
        _length -= fatha.length
    End Sub

    Public Sub removeFathaAt(index As Integer)
        _length -= _fathaList.Item(index).length
        _fathaList.RemoveAt(index)

    End Sub


    Public Function getJayzLength() As Decimal
        Dim len As Decimal = 0
        For Each f As Fatha In fathaList
            len += f.length
        Next
        _length = len
        Return len
    End Function
#End Region
End Class
