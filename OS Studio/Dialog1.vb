Imports System.Windows.Forms

Public Class Dialog1

    Dim page As Integer = 0

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If page > 0 Then
            page = page - 1
        End If
        ref()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If page < 2 Then
            page = page + 1
            OK_Button.Enabled = True
        Else
            CreateProject()
        End If
        ref()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub ref()
        If page = 0 Then
            Panel1.Visible = True
            Panel2.Visible = False
            Panel3.Visible = False
            OK_Button.Enabled = False
            Button1.Text = "Next"
        ElseIf page = 1 Then
            Panel2.Visible = True
            Panel1.Visible = False
            Panel3.Visible = False
            OK_Button.Enabled = True
            Button1.Text = "Next"
        ElseIf page = 2 Then
            Panel1.Visible = False
            Panel2.Visible = False
            Panel3.Visible = True
            OK_Button.Enabled = True
            Button1.Text = "Done"
        End If
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        page = 0
        TextBox4.Text = "C:\Users\" & Environment.UserName & "\Documents\OS Studio\Projects"
        ref()
    End Sub

    Sub CreateProject()
        Dim cd = ""
        My.Computer.FileSystem.CreateDirectory(TextBox4.Text & TextBox1.Text & TextBox3.Text)
        cd = TextBox4.Text & TextBox1.Text & TextBox3.Text & "\"
        Dim prjInfo As New Xml.XmlDocument
        addXmlElement(prjInfo, "project_name", TextBox1.Text)
        addXmlElement(prjInfo, "creator", TextBox2.Text)
        addXmlElement(prjInfo, "version", TextBox3.Text)
        prjInfo.Save(cd & TextBox1.Text & ".osp")
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Sub addXmlElement(ByRef xmlDoc As Xml.XmlDocument, ByVal elementName As String, ByVal elementData As String)
        Dim element As Xml.XmlElement = xmlDoc.CreateElement(elementName)
        element.InnerText = elementData
        xmlDoc.AppendChild(element)
    End Sub

    Function checkFields() As Boolean
        If page = 0 Then
            If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 And TextBox3.Text.Length > 0 Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        ElseIf page = 1 Then
            If TextBox5.Text.Length > 0 And TextBox6.Text.Length > 0 Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        ElseIf page = 2 Then
            If TextBox4.Text.Length > 0 Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        Else
            Button1.Enabled = False
        End If
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        checkFields()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        checkFields()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        checkFields()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        checkFields()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        checkFields()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        checkFields()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim r As DialogResult = FolderBrowserDialog1.ShowDialog
        If r = Windows.Forms.DialogResult.OK Then
            TextBox4.Text = FolderBrowserDialog1.SelectedPath & "\"
        End If
    End Sub

End Class
