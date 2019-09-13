
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Public Class DrawingPanel
#Region "Properties"



    Private _jayz As Jayz
    Public Property jayz() As Jayz
        Get
            Return _jayz
        End Get
        Set(ByVal value As Jayz)
            _jayz = value
        End Set
    End Property

    Private _pen As Pen
    Public Property pen() As Pen
        Get
            Return _pen
        End Get
        Set(ByVal value As Pen)
            _pen = value
        End Set
    End Property

    Private _penBold As Pen
    Public Property penBold() As Pen
        Get
            Return _penBold
        End Get
        Set(ByVal value As Pen)
            _penBold = value
        End Set
    End Property

    Private _brush As Brush
    Public Property brush() As Brush
        Get
            Return _brush
        End Get
        Set(ByVal value As Brush)
            _brush = value
        End Set
    End Property

    Private _font As Font
    Public Property font() As Font
        Get
            Return _font
        End Get
        Set(ByVal value As Font)
            _font = value
        End Set
    End Property

    Private _downPartStartPoint As Point
    Public Property downPartStartPoint() As Point
        Get
            Return _downPartStartPoint
        End Get
        Set(ByVal value As Point)
            _downPartStartPoint = value
        End Set
    End Property

    Private _downPartEndPoint As Point
    Public Property downPartEndPoint() As Point
        Get
            Return _downPartEndPoint
        End Get
        Set(ByVal value As Point)
            _downPartEndPoint = value
        End Set
    End Property

    Private _upperPartStartPoint As Point
    Public Property upperPartStartPoint() As Point
        Get
            Return _upperPartStartPoint
        End Get
        Set(ByVal value As Point)
            _upperPartStartPoint = value
        End Set
    End Property

    Private _upperPartEndPoint As Point
    Public Property uppertPartEndPoint() As Point
        Get
            Return _upperPartEndPoint
        End Get
        Set(ByVal value As Point)
            _upperPartEndPoint = value
        End Set
    End Property

#End Region
#Region "General Functions"
    Public Sub draw()

        drwPanel.Refresh()
    End Sub

    Public Sub New(jayz As Jayz)

        ' This call is required by the designer.
        InitializeComponent()
        _jayz = jayz
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.White
        _pen = New Pen(Color.Black)
        _penBold = New Pen(Color.Black, 3)
        _brush = New SolidBrush(Color.Black)
        _font = New Font("Arial", 8)
    End Sub

    Private Sub drwPanel_Paint(sender As Object, e As PaintEventArgs) Handles drwPanel.Paint
        If _jayz IsNot Nothing AndAlso _jayz.fathaList.Count > 0 Then
            drawDownPart(e.Graphics)
            drawUpperPart(e.Graphics)
        End If
    End Sub

    Public Sub printPanel(e As PrintPageEventArgs)
        drawDownPart(e.Graphics)
    End Sub
#End Region

#Region "drawDownPart"



    Private Sub drawFathaMark(graphics As Graphics, fathaPoint As Point)
        Dim p1 As New Point(fathaPoint.X, fathaPoint.Y - 5)
        Dim p2 As New Point(fathaPoint.X, fathaPoint.Y + 5)
        graphics.DrawLine(_pen, p1, p2)

        Dim p3 As New Point(fathaPoint.X - 5, fathaPoint.Y - 5)
        Dim p4 As New Point(fathaPoint.X + 5, fathaPoint.Y + 5)
        graphics.DrawLine(_pen, p3, p4)
    End Sub

    Private Sub drawFathaProps(graphics As Graphics, indx As Integer, fatha As Fatha, fathaStartPoint As Point, fathaEndPoint As Point)
        Dim fathaName As String = "الفتحة " + indx.ToString
        Dim fathaLength As String = fatha.length.ToString + " m"
        Dim strWidth As SizeF = graphics.MeasureString(fathaName, _font)
        Dim fathaLenthWith As SizeF = graphics.MeasureString(fathaLength, _font)
        Dim p As New Point(fathaStartPoint.X + (fathaEndPoint.X - fathaStartPoint.X) / 2 - (strWidth.Width / 2), fathaStartPoint.Y + 5)
        graphics.DrawString(fathaName, _font, _brush, p)
        Dim p1 As New Point(fathaStartPoint.X + (fathaEndPoint.X - fathaStartPoint.X) / 2 - (fathaLenthWith.Width / 2), fathaStartPoint.Y - 15)
        graphics.DrawString(fathaLength, _font, _brush, p1)
    End Sub

    Private Function getFathaEndPoint(fatha As Fatha, prevPoint As Point) As Point
        Dim fathatLineLength As Decimal = _downPartEndPoint.X - _downPartStartPoint.X
        Dim fathatLength As Decimal = _jayz.getJayzLength
        Dim fathaLengthPercent As Decimal = 100 * fatha.length / fathatLength
        Dim fathaPointX As Decimal = fathaLengthPercent * fathatLineLength / 100
        Dim p As New Point(prevPoint.X + fathaPointX, prevPoint.Y)
        Return p
    End Function

    Private Sub drawDownPart(graphics As Graphics)
        _downPartStartPoint = New Point(drwPanel.Location.X + 50, drwPanel.Location.Y + drwPanel.Height - 50)
        _downPartEndPoint = New Point(drwPanel.Location.X + drwPanel.Width - 50, drwPanel.Location.Y + drwPanel.Height - 50)
        graphics.DrawLine(Me.pen, _downPartStartPoint, _downPartEndPoint)
        drawFathaMark(graphics, _downPartStartPoint)
        ' drawFathaMark(e, _fathatEndPoint)
        Dim prevFathaPoint As Point = _downPartStartPoint
        Dim currFathaEndPoint As Point
        Dim indx As Integer = 1
        For Each f As Fatha In _jayz.fathaList
            currFathaEndPoint = getFathaEndPoint(f, prevFathaPoint)
            drawFathaMark(graphics, currFathaEndPoint)
            drawFathaProps(graphics, indx, f, prevFathaPoint, currFathaEndPoint)
            prevFathaPoint = currFathaEndPoint
            indx += 1
        Next

    End Sub
#End Region

#Region "Upper Part"
    Private Sub drawMasnad(graphics As Graphics, fathaPoint As Point, masnad As Masnad, indx As Integer)
        If masnad.type = Masnad.MasnadTypes.ohadi Then
            Dim p1 As New Point(fathaPoint.X, fathaPoint.Y)
            Dim alterY As Integer = 10
            Dim p2 As New Point(fathaPoint.X - 10, fathaPoint.Y + alterY)
            graphics.DrawLine(_pen, p1, p2)
            Dim p3 As New Point(fathaPoint.X + 10, fathaPoint.Y + alterY)
            graphics.DrawLine(_pen, p1, p3)
            Dim p4 As New Point(fathaPoint.X - 15, fathaPoint.Y + alterY)
            Dim p5 As New Point(fathaPoint.X + 15, fathaPoint.Y + alterY)
            graphics.DrawLine(_pen, p4, p5)
            Dim startP As Point = p4
            For i = 0 To 10
                Dim endP As New Point(startP.X - 3, startP.Y + 3)
                graphics.DrawLine(_pen, startP, endP)
                startP = New Point(startP.X + 3, startP.Y)
            Next
        End If
        If masnad.type = Masnad.MasnadTypes.wtha2a Then
            Dim p1 As New Point(fathaPoint.X, fathaPoint.Y - 13)
            Dim p2 As New Point(fathaPoint.X, fathaPoint.Y + 13)
            graphics.DrawLine(_pen, p1, p2)

            Dim startP As Point = p1
            Dim endP As Point
            For i = 0 To 8
                If indx = 0 Then
                    endP = New Point(startP.X - 3, startP.Y + 3)
                Else
                    endP = New Point(startP.X + 3, startP.Y + 3)
                End If

                graphics.DrawLine(_pen, startP, endP)
                startP = New Point(startP.X, startP.Y + 3)
            Next
        End If
        Dim masnadName As String
        If masnad.masnadName Is Nothing OrElse masnad.masnadName.Trim = "" Then
            masnadName = "-" + (indx + 1).ToString + "-"
        Else
            masnadName = "-" + masnad.masnadName + "-"
        End If
        Dim masnadNameWidth As SizeF = graphics.MeasureString(masnadName, _font)
        Dim mPoint As New Point(fathaPoint.X - (masnadNameWidth.Width / 2), fathaPoint.Y + 20)
        graphics.DrawString(masnadName, _font, _brush, mPoint)

        Dim masnadWidthInMeter As Decimal = masnad.width / 100
        Dim jayzWdithinDrawing As Decimal = uppertPartEndPoint.X - upperPartStartPoint.X
        Dim masnadWidthInDrawing As Decimal = jayzWdithinDrawing * masnadWidthInMeter / _jayz.length
        If indx > 0 Then
            Dim masnadLeftLineX As Decimal = fathaPoint.X - (masnadWidthInDrawing / 2)
            Dim masnadLeftLineP1 As Point = New Point(masnadLeftLineX, fathaPoint.Y - 5)
            Dim masnadLeftLinP2 As Point = New Point(masnadLeftLineX, fathaPoint.Y + 5)
            graphics.DrawLine(_pen, masnadLeftLineP1, masnadLeftLinP2)
        End If
        If indx < _jayz.masnadList.Count - 1 Then
            Dim masnadRightLineX As Decimal = fathaPoint.X + (masnadWidthInDrawing / 2)
            Dim masnadRightLinP1 As Point = New Point(masnadRightLineX, fathaPoint.Y - 5)
            Dim masnadRightLinP2 As Point = New Point(masnadRightLineX, fathaPoint.Y + 5)
            graphics.DrawLine(_pen, masnadRightLinP1, masnadRightLinP2)
        End If
    End Sub

    Private Sub drawUpperPart(graphics As Graphics)
        _upperPartStartPoint = New Point(downPartStartPoint.X, downPartStartPoint.Y - 100)
        _upperPartEndPoint = New Point(_downPartEndPoint.X, downPartEndPoint.Y - 100)
        graphics.DrawLine(_penBold, _upperPartStartPoint, _upperPartEndPoint)

        drawMasnad(graphics, _upperPartStartPoint, _jayz.masnadList(0), 0)

        Dim prevFathaPoint As Point = _upperPartStartPoint
        Dim currFathaEndPoint As Point
        Dim indx As Integer = 1
        For Each f As Fatha In _jayz.fathaList
            currFathaEndPoint = getFathaEndPoint(f, prevFathaPoint)
            drawMasnad(graphics, currFathaEndPoint, _jayz.masnadList(indx), indx)
            'drawFathaProps(graphics, indx, f, prevFathaPoint, currFathaEndPoint)
            prevFathaPoint = currFathaEndPoint
            indx += 1
        Next

    End Sub
#End Region

End Class
