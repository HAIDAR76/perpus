Imports System.Data.SqlClient

Public Class MenuUtamaAnggota

    Private Sub MenuUtamaAnggota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = TimeOfDay
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        PinjamanAnggota.Show()
    End Sub

    Private Sub ButtonAkun_Click(sender As Object, e As EventArgs) Handles ButtonAkun.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class