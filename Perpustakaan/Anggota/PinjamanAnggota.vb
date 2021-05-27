Imports System.Data.SqlClient

Public Class PinjamanAnggota

    Sub tampilandata()
        DA = New SqlDataAdapter("select * from tblpeminjaman", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Private Sub ButtonAkun_Click(sender As Object, e As EventArgs) Handles ButtonAkun.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Call koneksi()
        CMD = New SqlCommand("select * from tblpeminjaman where nm_anggota like '%" & TextBox2.Text & "%'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call koneksi()
            DA = New SqlDataAdapter("select * from tblpeminjaman where nm_anggota like '%" & TextBox2.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("nama anggota tidak ditemukan")
        End If
    End Sub

    Private Sub PinjamanAnggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call tampilandata()
    End Sub
End Class