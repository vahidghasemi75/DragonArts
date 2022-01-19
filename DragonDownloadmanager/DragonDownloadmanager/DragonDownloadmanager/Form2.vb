Imports System.ComponentModel
Imports System.Net
Public Class Form2
    Dim US = Environment.UserName
    Private Sub Label1_(sender As Object, e As EventArgs) Handles Label1.Click
        Label1.Text = "Wllcome Dear" & " " & US & " " & "To Our Production"

    End Sub
End Class