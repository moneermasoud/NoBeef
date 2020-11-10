Imports System.Net
Imports System.Net.Mail
Imports Microsoft.Win32
Imports System.IO
Imports System.Threading
Imports System.Data.OleDb
Public Class main
    '###################################################################################################
    '###################################################################################################
    'NoBeef v.1.2
    'Web Application Directory Brute force based attack against a web server and analyzing the response.
    'Coded BY Moneer Masoud
    '###################################################################################################
    '###################################################################################################

    Private Sub count_dictionary()
        Try
            con.Open()
            Dim sql_str As String = "SELECT count(*) FROM listwords"
            Dim sql_cmd As New OleDbCommand(sql_str, con)
            Dim sql_reader As OleDbDataReader
            sql_reader = sql_cmd.ExecuteReader
            sql_reader.Read()
            If sql_reader.HasRows Then
                Label5.Text = sql_reader(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        show_list()
        If CheckBox1.Checked = True Then

            Me.Size = New System.Drawing.Size(569, 445)
        Else

            Me.Size = New System.Drawing.Size(569, 621)

        End If

        count_dictionary()
        PictureBox1.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' check if url textbox not null
        If url.Text = vbNullString Then
            MsgBox("Please insert target => like this : site.com or www.site.com", MsgBoxStyle.Exclamation, "No B33f v.1.0")
            Exit Sub
        End If
        '#######################################################################################
        Try
            MsgBox("Please wait 5 minutes or 10 minutes , don't touch anything", MsgBoxStyle.Information, "No B33f v.1.0")
            PictureBox1.Visible = True
            For i = 0 To ListView1.Items.Count - 1
                Dim urlcheck As String = "http://" & url.Text & "/" & ListView1.Items(i).SubItems(1).Text


                If checkFileExists(urlcheck) = True Then

                    output.AppendText("http://" & url.Text & "/" & ListView1.Items(i).SubItems(1).Text & " ==> " & "Found" & vbNewLine)
                    PictureBox1.Refresh()
                End If

                'Thread.Sleep(100)
                PictureBox1.Refresh()
            Next
            MsgBox("Successfully Completed", MsgBoxStyle.Information, "No B33f v.1.0")
            PictureBox1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

            PictureBox1.Visible = False
        End Try
        '#######################################################################################

    End Sub

    Private Sub show_list()
        '#######################################################################################

        Try
            con.Open()
            Dim sqlq As String = "SELECT * FROM listwords"
            Dim sqlq_cmd As New OleDbCommand(sqlq, con)
            Dim reader_sql_ve As OleDbDataReader = sqlq_cmd.ExecuteReader
            'clear data listview 
            ListView1.Columns.Clear()
            ListView1.Items.Clear()


            ListView1.Columns.Add("#ID")
            ListView1.Columns.Add("Directory")


            ListView1.Columns(0).Width = 200
            ListView1.Columns(1).Width = 310

            While reader_sql_ve.Read

                Dim item As New ListViewItem(reader_sql_ve("id_list").ToString())
                item.SubItems.Add(reader_sql_ve("dirname").ToString())


                ListView1.Items.Add(item)

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        '#######################################################################################

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        about.Show()
    End Sub

    Private Function checkFileExists(ByVal url As String) As Boolean
        '#######################################################################################
        Try
            Dim request As HttpWebRequest = TryCast(WebRequest.Create(url), HttpWebRequest)
            request.Method = "HEAD"
            If CheckBox2.Checked = True Then
                request.AllowAutoRedirect = True
            Else
                request.AllowAutoRedirect = False
            End If

            Dim response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            response.Close()
            Return (response.StatusCode = HttpStatusCode.OK)

        Catch
            Return False
        End Try
        '#######################################################################################
    End Function



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            Me.Size = New System.Drawing.Size(569, 445)
        Else

            Me.Size = New System.Drawing.Size(569, 621)

        End If
    End Sub



End Class
