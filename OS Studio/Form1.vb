Imports System.Text
Imports System.IO

Public Class Form1

    Private Sub MenuItem5_Click(sender As Object, e As EventArgs) Handles MenuItem5.Click
        AboutBox1.Show()
    End Sub

    Private Sub MenuItem6_Click(sender As Object, e As EventArgs) Handles MenuItem6.Click
        Process.Start("http://wiki.osdev.org")
    End Sub

    Private Sub MenuItem7_Click(sender As Object, e As EventArgs) Handles MenuItem7.Click
        Process.Start("http://forum.osdev.org")
    End Sub

    Private Sub MenuItem15_Click(sender As Object, e As EventArgs) Handles MenuItem15.Click
        Me.Close()
    End Sub

    Private Sub MenuItem19_Click(sender As Object, e As EventArgs) Handles MenuItem19.Click
        ColorSelector.Show()
    End Sub

    Private Sub MenuItem20_Click(sender As Object, e As EventArgs) Handles MenuItem20.Click
        BinDecHexConverter.Show()
    End Sub

    Private Sub MenuItem12_Click(sender As Object, e As EventArgs) Handles MenuItem12.Click
        MsgBox("Sorry, Not yet implemented ^_^" & Chr(13) & "You can use Win32diskImager if you need to burn an image" & Chr(13) & Chr(13) & "have a nice day !")
    End Sub

    Private Sub MenuItem22_Click(sender As Object, e As EventArgs) Handles MenuItem22.Click
        BugRep.Show()
    End Sub

    Private Sub MenuItem18_Click(sender As Object, e As EventArgs) Handles MenuItem18.Click
        Dialog1.ShowDialog()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkIfFirstStart()
    End Sub

    Sub checkIfFirstStart()
        If My.Computer.FileSystem.DirectoryExists("C:\Users\" & Environment.UserName & "\Documents\OS Studio") = False Then
            Try
                My.Computer.FileSystem.CreateDirectory("C:\Users\" & Environment.UserName & "\Documents\OS Studio")
                Dim preference_xml As New Xml.XmlDocument
                Dim test As Xml.XmlElement = preference_xml.CreateElement("TEST")
                test.InnerText = "LOLOLOL"
                preference_xml.AppendChild(test)
                preference_xml.Save("C:\Users\" & Environment.UserName & "\Documents\OS Studio\preferences.xml")
            Catch ex As Exception

            End Try
        End If
        Dim xml As New Xml.XmlDocument
    End Sub

End Class
