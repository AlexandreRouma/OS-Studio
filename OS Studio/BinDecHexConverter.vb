Imports System.Globalization

Public Class BinDecHexConverter

    Dim sm1 As Boolean = False
    Dim sm2 As Boolean = False
    Dim sm3 As Boolean = False

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If sm1 = False Then
            sm2 = True
            sm3 = True
            Try
                TextBox2.Text = Convert.ToInt32(TextBox1.Text, 2)
                TextBox3.Text = Hex(TextBox2.Text)
            Catch ex As Exception
                TextBox2.Text = ""
                TextBox3.Text = ""
            End Try
        Else
            sm1 = False
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If sm2 = False Then
            sm1 = True
            sm3 = True
            Try
                TextBox3.Text = Hex(TextBox2.Text)
                TextBox1.Text = HexStringToBinary(TextBox3.Text)
            Catch ex As Exception
                TextBox3.Text = ""
                TextBox1.Text = ""
            End Try
        Else
            sm2 = False
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If sm3 = False Then
            sm1 = True
            sm2 = True
            Try
                TextBox1.Text = HexStringToBinary(TextBox3.Text)
                TextBox2.Text = Val("&H" & TextBox3.Text)
            Catch ex As Exception
                TextBox1.Text = ""
                TextBox2.Text = ""
            End Try
        Else
            sm3 = False
        End If
    End Sub

    Function HexStringToBinary(ByVal hexString As String) As String
        Dim num As Integer = Integer.Parse(hexString, NumberStyles.HexNumber)
        Return Convert.ToString(num, 2)
    End Function

End Class