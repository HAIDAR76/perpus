Imports System.Data.SqlClient
Imports System.IO

Module Module1
    Public CONN As SqlConnection
    Public DA As SqlDataAdapter
    Public DS As New DataSet
    Public CMD As SqlCommand
    Public DR As SqlDataReader
    Public STR As String

    Sub koneksi()
        STR = "data source=UKOMYPKK2\SQLEXPRESS;initial catalog=perpustakaan;integrated security=true"
        CONN = New SqlConnection(STR)
        If CONN.State = ConnectionState.Closed Then
            CONN.Open()
        End If
    End Sub


End Module
