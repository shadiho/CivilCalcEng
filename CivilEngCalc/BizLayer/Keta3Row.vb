Public Class Keta3Row
    Inherits DataGridViewRow

    Private _keta3Form As FrmKeta3
    Public Property keta3Form() As FrmKeta3
        Get
            Return _keta3Form
        End Get
        Set(ByVal value As FrmKeta3)
            _keta3Form = value
        End Set
    End Property

    Public Sub New(keta3Form As FrmKeta3)
        MyBase.New
        _keta3Form = keta3Form
    End Sub
End Class
