<Serializable>
Public Class Keta3Teh
    Inherits Keta3
#Region "Properties"



    Private _bw As Decimal = 300
    Public Property bw() As Decimal
        Get
            Return _bw
        End Get
        Set(ByVal value As Decimal)
            _bw = value
        End Set
    End Property

    Private _bf As Decimal = 500
    Public Property bf() As Decimal
        Get
            Return _bf
        End Get
        Set(ByVal value As Decimal)
            _bf = value
        End Set
    End Property

    Private _ts As Decimal = 150
    Public Property ts() As Decimal
        Get
            Return _ts
        End Get
        Set(ByVal value As Decimal)
            _ts = value
        End Set
    End Property


#End Region

#Region "Functions"
    Public Sub New(name As String)
        MyBase.New(name)
    End Sub

    Public Overrides Sub calc()
        area = Math.Round((ts * bf) + ((h - ts) * bw), 2)
        Me.azem3atala = Math.Round(((bf * ts ^ 3) / 12) + (bw * ((h - ts) ^ 3) / 12), 2)
        Me.waznThati = Math.Round(Me.waznHajmi * ((bw / 1000) * ((h - ts) / 1000)) + Me.waznHajmi * ((bf / 1000) * (ts / 1000)), 2) * 1.4
    End Sub
#End Region
End Class
