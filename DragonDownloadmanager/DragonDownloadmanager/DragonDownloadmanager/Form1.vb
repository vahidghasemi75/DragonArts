Imports System.ComponentModel
Imports System.Net
Public Class Form1
    Private WithEvents HTTPCLIENT As WebClient
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HTTPCLIENT = New WebClient
        Dim Download As String = TextBox1.Text
        Dim USER = Environment.UserName
        Dim SAVE As String = "C:\Users\" & USER & "\Downloads\" & TextBox2.Text ''file.exe
        Try
            HTTPCLIENT.DownloadFileAsync(New Uri(Download), SAVE)
            TextBox1.ReadOnly = True
            TextBox2.ReadOnly = True
            Button1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Information")
            TextBox1.Text = "Download Link"
            TextBox2.Text = "Example.exe"
        End Try

    End Sub

    Private Sub HTTPCLIENT_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles HTTPCLIENT.DownloadProgressChanged
        ProgressBar1.Maximum = e.TotalBytesToReceive
        ProgressBar1.Value = e.BytesReceived
        Me.Text = "Downloaded... " & e.ProgressPercentage & "%"

        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Value = 0
            TextBox1.Text = "Download Link"
            TextBox2.Text = "Example.exe"
            TextBox1.ReadOnly = False
            TextBox2.ReadOnly = False
            Button1.Enabled = True


        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            HTTPCLIENT.CancelAsync()
        Catch ex As Exception
            End
        End Try
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        TextBox2.Text = ""
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub File_Opening(sender As Object, e As CancelEventArgs)

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Visible = True
    End Sub
End Class
