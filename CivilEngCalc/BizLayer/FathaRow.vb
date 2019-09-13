Public Class FathaRow
    Inherits DataGridViewRow

    Private _fatha As Fatha
    Public Property fatha() As Fatha
        Get
            Return _fatha
        End Get
        Set(ByVal value As Fatha)
            _fatha = value
        End Set
    End Property


    Private _isDummy As Boolean = False
    Public Property isDummy() As Boolean
        Get
            Return _isDummy
        End Get
        Set(ByVal value As Boolean)
            _isDummy = value
        End Set
    End Property

    Public Sub convertToReal()
        _isDummy = False
    End Sub

    Public Sub New(fatha As Fatha)
        MyBase.New
        _fatha = fatha
    End Sub
End Class
