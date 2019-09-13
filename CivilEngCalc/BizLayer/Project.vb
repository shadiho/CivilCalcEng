Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

<Serializable>
Public Class Project
#Region "Props"
    <NonSerialized>
    Private _form As mainForm
    Public Property form() As mainForm
        Get
            Return _form
        End Get
        Set(ByVal value As mainForm)
            _form = value
        End Set
    End Property

    Private _projName As String
    Public Property projName() As String
        Get
            Return _projName
        End Get
        Set(ByVal value As String)
            _projName = value
        End Set
    End Property

    Private _props As ProjectProps
    Public Property props() As ProjectProps
        Get
            Return _props
        End Get
        Set(ByVal value As ProjectProps)
            _props = value
        End Set
    End Property

    Private _jayzList As List(Of Jayz)
    Public Property jayzList() As List(Of Jayz)
        Get
            Return _jayzList
        End Get
        Set(ByVal value As List(Of Jayz))
            _jayzList = value
        End Set
    End Property

    Private _filePath As String = ""
    Public Property filePath() As String
        Get
            Return _filePath
        End Get
        Set(ByVal value As String)
            _filePath = value
        End Set
    End Property
#End Region

#Region "functions"
    Public Sub New(name As String, form As mainForm)
        Me.projName = name
        _form = form
        _props = New ProjectProps
        _jayzList = New List(Of Jayz)
        Dim defJayz As New Jayz("جائز 1", "", Me)
        _jayzList.Add(defJayz)

    End Sub
    Public Sub addJayz()
        Dim newName As String = "جائز " + (jayzList.Count + 1).ToString
        Dim newJayz = New Jayz(newName, "", Me)
        _jayzList.Add(newJayz)
    End Sub

    Public Function validateNewJayzName(jayz As Jayz, newJayzName As String) As Boolean
        For Each j As Jayz In _jayzList
            If j.Equals(jayz) Then
                Continue For
            End If
            If j.jayzName.Trim = newJayzName.Trim Then
                Return False
            End If
        Next
        Return True
    End Function
    Public Shared Function load(fileName As String) As Project
        Try
            Dim myFileStream As FileStream = New FileStream(fileName, FileMode.Open)
            Dim formatter As New BinaryFormatter()
            Dim proj As Project = formatter.Deserialize(myFileStream)
            Return proj
        Catch ex As Exception

        End Try
        Return Nothing
    End Function


    Public Function save(fileName As String) As Boolean
        Try
            If _filePath = "" Then
                _filePath = fileName
            End If
            Dim formatter As New BinaryFormatter()
            Dim stream As Stream = New FileStream(fileName,
                     FileMode.Create,
                     FileAccess.Write, FileShare.None)
            formatter.Serialize(stream, Me)
            stream.Close()
            _filePath = fileName
            Return True
        Catch ex As Exception

        End Try
        Return False
    End Function
#End Region

End Class
