Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Imports Nancy.Json

Public Class Form1

    Public Sub getdata()
        Try
            Dim uriString As String = "http://localhost:8080/CodeIgniter_API-master/index.php/api/getdata"
            Dim uri As New Uri(uriString)
            Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
            request.Method = "GET"
            Dim response As HttpWebResponse = request.GetResponse()
            Dim read = New StreamReader(response.GetResponseStream())
            Dim raw As String = read.ReadToEnd()
            Dim no As Integer = 0
            Dim dict As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(raw)

            For Each item As Object In dict
                no = no + 1
                DataGridView1.Rows.Add(no, item("npm").ToString, item("name").ToString,
                                       item("major").ToString, item("studyprogram").ToString,
                                       item("class").ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Notifikasi")
        End Try
    End Sub

    Public Sub getdatawhere(npm)
        Try
            Dim uriString As String = "http://localhost:8080/CodeIgniter_API-master/index.php/api/getdatawhere/" + npm
            Dim uri As New Uri(uriString)
            Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
            request.Method = "GET"
            Dim response As HttpWebResponse = request.GetResponse()
            Dim read = New StreamReader(response.GetResponseStream())
            Dim raw As String = read.ReadToEnd()
            Dim no As Integer = 0
            Dim dict As Object = New JavaScriptSerializer().Deserialize(Of List(Of Object))(raw)
            For Each item As Object In dict
                no = no + 1
                DataGridView1.Rows.Add(no, item("npm").ToString, item("name").ToString,
                                       item("major").ToString, item("studyprogram").ToString,
                                       item("class").ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Notifikasi")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getdata()
    End Sub
End Class
