Imports System.Net.Mail

Public Class BugRep

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Bug report not sent", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Class