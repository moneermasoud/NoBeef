Imports System.Data.OleDb
Module config

    Public stop_bf As String = 0
    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\list.accdb")
    Public ds As New DataTable
    Public da As New OleDbDataAdapter

End Module
