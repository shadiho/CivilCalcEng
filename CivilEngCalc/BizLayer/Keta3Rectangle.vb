<Serializable>
Public Class Keta3Rectangle
    Inherits Keta3
#Region "Properties"


    Private _b As Decimal = 300
    Public Property b() As Decimal
        Get
            Return _b
        End Get
        Set(ByVal value As Decimal)
            _b = value
        End Set
    End Property

#End Region

#Region "Functions"
    Public Sub New(name As String)
        MyBase.New(name)
    End Sub

    Public Overrides Sub calc()
        area = Math.Round(h * b, 2)
        Me.azem3atala = Math.Round((b * h ^ 3) / 12, 2)
        Me.waznThati = Math.Round(Me.waznHajmi * (b / 1000) * (h / 1000), 2) * 1.4
    End Sub




#End Region
End Class
