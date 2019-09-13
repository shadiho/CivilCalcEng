Public Class MasnadRow
    Inherits DataGridViewRow
    Private _masnad As Masnad
    Public Property masnad() As Masnad
        Get
            Return _masnad
        End Get
        Set(ByVal value As Masnad)
            _masnad = value
        End Set
    End Property

    Public Sub New(masnad As Masnad)
        MyBase.New
        _masnad = masnad
    End Sub

End Class
