Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Imaging


Public Class Buku
    Sub kosongkan()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    Sub databaru()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Focus()
    End Sub

    Sub tampilandata()
        DA = New SqlDataAdapter("select * from tblbuku", CONN)
        DS = New DataSet
        DA.Fill(DS)
        DGV.DataSource = DS.Tables(0)
        DGV.ReadOnly = True
    End Sub

    Private Sub Buku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call tampilandata()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        TextBox1.MaxLength = 5
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            CMD = New SqlCommand("select * from tblbuku where kd_buku='" & TextBox1.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                TextBox2.Text = DR.Item("nm_buku")
                TextBox3.Text = DR.Item("penerbit")
                TextBox2.Focus()
            Else
                Call databaru()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        TextBox2.MaxLength = 30
        If e.KeyChar = Chr(13) Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        TextBox3.MaxLength = 30
        If e.KeyChar = Chr(13) Then
            Button8.Focus()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call koneksi()
            CMD = New SqlCommand("select * from tblbuku where kd_buku='" & TextBox1.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                Call koneksi()
                Dim simpan As String = "insert into tblbuku values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                CMD = New SqlCommand(simpan, CONN)
                CMD.ExecuteNonQuery()
            Else
                Call koneksi()
                Dim edit As String = "update tblbuku set nm_buku='" & TextBox2.Text & "',penerbit='" & TextBox3.Text & "' where kd_buku='" & TextBox1.Text & "'"
                CMD = New SqlCommand(edit, CONN)
                CMD.ExecuteNonQuery()
            End If
            Call kosongkan()
            Call tampilandata()
        End If

        'Dim command1 As New SqlCommand("insert into tblbuku(gambar)values(@img)", CONN)
        'Dim picture As New MemoryStream
        'PictureBox3.Image.Save(picture, PictureBox1.Image.RawFormat)
        'command1.Parameters.Add("@gambar", SqlDbType.Image).Value = picture.ToArray

    End Sub

    'Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    'Dim gambarupload As New OpenFileDialog
    '   gambarupload.Filter = "choose image(*.jpg;*.png;*.gif)|*.jpg;*;*.png;*.gif"
    '
    '   If gambarupload.ShowDialog = Windows.Forms.DialogResult.OK Then
    '      PictureBox3.Image = Image.FromFile(gambarupload.FileName)
    ' End If
    'End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox1.Text = "" Then
            MsgBox("kode harus diisi")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("hapus data ini?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call koneksi()
                Dim hapus As String = "delete from tblbuku where kd_buku='" & TextBox1.Text & "'"
                CMD = New SqlCommand(hapus, CONN)
                CMD.ExecuteNonQuery()
                Call kosongkan()
                Call tampilandata()
            Else
                Call kosongkan()
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Call kosongkan()
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Call koneksi()
        CMD = New SqlCommand("select * from tblbuku where nm_buku like '%" & TextBox4.Text & "%'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            Call koneksi()
            DA = New SqlDataAdapter("select * from tblbuku where nm_buku like '%" & TextBox4.Text & "%'", CONN)
            DS = New DataSet
            DA.Fill(DS)
            DGV.DataSource = DS.Tables(0)
        Else
            MsgBox("data tidak ditemukan")
        End If
    End Sub

    Private Sub DGV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV.CellMouseClick
        On Error Resume Next
        TextBox1.Text = DGV.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DGV.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DGV.Rows(e.RowIndex).Cells(2).Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Pinjaman.Show()
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