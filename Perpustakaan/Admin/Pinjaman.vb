﻿Public Class Pinjaman

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Buku.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Pengembalian.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        DaftarAnggota.Show()
    End Sub

    Private Sub ButtonAkun_Click(sender As Object, e As EventArgs) Handles ButtonAkun.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class