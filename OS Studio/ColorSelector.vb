Imports System.Globalization

Public Class ColorSelector

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim r As DialogResult = ColorDialog1.ShowDialog()
        If r = Windows.Forms.DialogResult.OK Then
            Panel1.BackColor = ColorDialog1.Color
            Panel1.BackColor = Panel1.BackColor
            TextBox1.Text = Panel1.BackColor.R
            TextBox2.Text = Panel1.BackColor.G
            TextBox3.Text = Panel1.BackColor.B
            TextBox4.Text = "0x" & hexString(Panel1.BackColor.B) & hexString(Panel1.BackColor.G) & hexString(Panel1.BackColor.R)
            TextBox5.Text = HexStringToBinary(TextBox4.Text.Substring(2))
        End If
    End Sub

    Function hexString(ByVal n As Byte) As String
        Dim r As String = Hex(n)
        If r.Length < 2 Then
            r = 0 & r
        End If
        Return r
    End Function

    Function HexStringToBinary(ByVal hexString As String) As String
        Dim num As Integer = Integer.Parse(hexString, NumberStyles.HexNumber)
        Return Convert.ToString(num, 2)
    End Function
End Class