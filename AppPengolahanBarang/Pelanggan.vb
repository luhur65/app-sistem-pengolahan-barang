Imports MySql.Data.MySqlClient

Public Class Pelanggan

    Sub BuatListView()
        With LV.Columns
            .Add("No.", 40, HorizontalAlignment.Center)
            .Add("ID Pelanggan", 100, HorizontalAlignment.Center)
            .Add("Nama Pelanggan", 150, HorizontalAlignment.Left)
            .Add("Alamat", 250, HorizontalAlignment.Left)
            .Add("Email", 250, HorizontalAlignment.Left)
            .Add("No. Handphone", 250, HorizontalAlignment.Left)
        End With
        LV.GridLines = True
        LV.View = View.Details
        LV.FullRowSelect = True
    End Sub

    Sub IsiListview(ByVal rd As Object)
        Dim i As Integer = 1
        While rd.Read
            Dim baris As New ListViewItem
            baris.Text = i
            With baris.SubItems
                .Add(rd.Item("idUser"))
                .Add(Microsoft.VisualBasic.StrConv(rd.Item("namauser"), VbStrConv.ProperCase))
                .Add(rd.Item("alamat"))
                .Add(rd.Item("email"))
                .Add(rd.Item("noHP"))
            End With
            LV.Items.Add(baris)
            i += 1
        End While
        rd.Close()
    End Sub

    Sub Bersih()
        AturKondisiForm(False, False)
        HapusIsianForm()
        IdPelanggan.Focus()
        AturKondisiTombolAksi(True, False, False, False, False, True)
        TampilkanSemuaPelanggan()
    End Sub

    Sub HapusIsianForm()
        IdPelanggan.Clear()
        namaPelanggan.Clear()
        alamatPelanggan.Clear()
        emailPelanggan.Clear()
        hpPelanggan.Clear()
    End Sub

    Sub AturKondisiForm(ByVal a As Boolean, ByVal b As Boolean)
        IdPelanggan.Enabled = a
        namaPelanggan.Enabled = b
        alamatPelanggan.Enabled = b
        emailPelanggan.Enabled = b
        hpPelanggan.Enabled = b
    End Sub

    Sub AturKondisiTombolAksi(ByVal a As Boolean, ByVal b As Boolean, ByVal c As Boolean, _
                              ByVal d As Boolean, ByVal e As Boolean, ByVal f As Boolean)
        btnTambah.Enabled = a
        btnSave.Enabled = b
        btnEdit.Enabled = c
        btnHapus.Enabled = d
        btnCancel.Enabled = e
        btnQuit.Enabled = f
    End Sub

    Sub TampilkanSemuaPelanggan()
        Koneksi.Koneksi()

        perintah = "SELECT * FROM `pelanggan` ORDER BY `idUser` ASC"
        cmd = New MySqlCommand(perintah, conn)
        rd = cmd.ExecuteReader
        LV.Clear()

        ' cek apakah ada data nya ( isi )
        If rd.HasRows() = True Then
            ' panggil function BuatListview -nya
            BuatListView()
            ' buat isi listview -nya
            IsiListview(rd)
        End If

        TotalPelanggan.Text = "Jumlah Pelanggan : " & LV.Items.Count()
    End Sub

    Private Sub Pelanggan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilkanSemuaPelanggan()
        AturKondisiForm(False, False)
        AturKondisiTombolAksi(True, False, False, False, False, True)
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        AturKondisiForm(True, False)
        IdPelanggan.Focus()
        AturKondisiTombolAksi(False, False, False, False, True, False)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Data() As String = {IdPelanggan.Text, namaPelanggan.Text, alamatPelanggan.Text, emailPelanggan.Text, hpPelanggan.Text}
        If Data(0) = "" Or Data(1) = "" Or Data(2) = "" Or Data(3) = "" Or Data(4) = "" Then
            MsgBox("Data masih ada yang kosong, Harap isi ulang kembali!!")
        Else
            TambahPelangganBaru(Data)
            Bersih()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Bersih()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim Data() As String = {IdPelanggan.Text, namaPelanggan.Text, alamatPelanggan.Text, emailPelanggan.Text, hpPelanggan.Text}
        If Data(0) = "" Or Data(1) = "" Or Data(2) = "" Or Data(3) = "" Or Data(4) = "" Then
            MsgBox("Data masih ada yang kosong, Harap isi ulang kembali!!")
        Else
            UbahPelanggan(Data)
            Bersih()
        End If
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Dim feedback As Integer
        feedback = MsgBox("Yakin ingin dihapus ??", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Konfirmasi")
        If feedback = MsgBoxResult.Yes Then
            HapusPelanggan(IdPelanggan.Text)
            TampilkanSemuaPelanggan()
            btnCancel_Click(sender, e)
        End If
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub IdPelanggan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IdPelanggan.KeyPress
        Koneksi.Koneksi()

        ' tombol enter ditekan
        If Asc(e.KeyChar) = 13 Then

            If IdPelanggan.Text <> "" Then
                cmd = New MySqlCommand("SELECT * FROM `pelanggan` WHERE idUser LIKE '%" & IdPelanggan.Text & "%'", conn)
                rd = cmd.ExecuteReader

                If rd.HasRows Then
                    rd.Read()
                    ' kode barang ada
                    AturKondisiForm(False, True)
                    AturKondisiTombolAksi(False, False, True, True, True, False)

                    IdPelanggan.Text = rd.Item("idUser")
                    namaPelanggan.Text = rd.Item("namaUser")
                    alamatPelanggan.Text = rd.Item("alamat")
                    emailPelanggan.Text = rd.Item("email")
                    hpPelanggan.Text = rd.Item("noHP")
                    rd.Close()
                Else
                    AturKondisiForm(False, True)
                    namaPelanggan.Focus()
                    AturKondisiTombolAksi(False, True, False, False, True, False)
                End If

            Else
                MsgBox("Id Pelanggan Kosong")
            End If

        End If
    End Sub

End Class