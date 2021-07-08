Imports MySql.Data.MySqlClient

Public Class Pelanggan

    Dim tombolBehaviour() As Boolean = {True, False, False, False, True}

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

    Sub IsiListview()
        Dim i As Integer = 1
        While rd.Read
            Dim baris As New ListViewItem
            baris.Text = i
            With baris.SubItems
                .Add(rd.Item("idUser"))
                .Add(rd.Item("namauser"))
                .Add(rd.Item("alamat"))
                .Add(rd.Item("email"))
                .Add(rd.Item("noHP"))
            End With
            LV.Items.Add(baris)
            i += 1
        End While
        rd.Close()
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

    Sub AturKondisiTombolAksi(ByVal aksi() As Boolean)
        btnTambah.Enabled = aksi(0)
        btnEdit.Enabled = aksi(1)
        btnHapus.Enabled = aksi(2)
        btnCancel.Enabled = aksi(3)
        btnQuit.Enabled = aksi(4)
        btnTambah.Text = "Tambah"
        btnEdit.Text = "Ubah"
        btnHapus.Text = "Hapus"
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
            IsiListview()
        End If

        TotalPelanggan.Text = "Jumlah Pelanggan : " & LV.Items.Count()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub Pelanggan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilkanSemuaPelanggan()
        AturKondisiForm(True, False)
        AturKondisiTombolAksi(tombolBehaviour)
        IdPelanggan.Focus()
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        Koneksi.Koneksi()

        If IdPelanggan.Text = "" Then
            IdPelanggan.Text = GenerateNewIDPelanggan(LV.Items.Count)
        End If

        perintah = "SELECT * FROM `pelanggan` WHERE idUser='" & IdPelanggan.Text & "'"
        cmd = New MySqlCommand(perintah, conn)
        rd = cmd.ExecuteReader

        If rd.HasRows() Then
            rd.Read()
            ' kode barang ada
            Dim tombolBehaviour() As Boolean = {False, True, True, True, False}
            AturKondisiForm(False, True)
            AturKondisiTombolAksi(tombolBehaviour)

            namaPelanggan.Text = rd.Item("namaUser")
            alamatPelanggan.Text = rd.Item("alamat")
            hpPelanggan.Text = rd.Item("noHP")
            emailPelanggan.Text = rd.Item("email")
        Else
            rd.Close()
            If btnTambah.Text.ToLower = "simpan" Then
                Dim Data() As String = {IdPelanggan.Text, namaPelanggan.Text, alamatPelanggan.Text, emailPelanggan.Text, hpPelanggan.Text}
                ValidasiPelanggan(Data, "tambah")
                btnCancel_Click(sender, e)
                TampilkanSemuaPelanggan()
            Else
                Dim tombolBehaviour() As Boolean = {True, False, False, True, False}
                AturKondisiTombolAksi(tombolBehaviour)
                AturKondisiForm(False, True)
                btnTambah.Text = "Simpan"
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        AturKondisiForm(True, False)
        HapusIsianForm()
        AturKondisiTombolAksi(tombolBehaviour)
        IdPelanggan.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim Data() As String = {IdPelanggan.Text, namaPelanggan.Text, alamatPelanggan.Text, emailPelanggan.Text, hpPelanggan.Text}
        ValidasiPelanggan(Data, "ubah")
        btnCancel_Click(sender, e)
        TampilkanSemuaPelanggan()
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

    Private Sub IdPelanggan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IdPelanggan.KeyPress
        Koneksi.Koneksi()

        ' tombol enter ditekan
        If Asc(e.KeyChar) = 13 Then
            If Len(IdPelanggan.Text) = 5 Then
                btnTambah_Click(sender, e)

            Else
                MsgBox("Digit kode barang kurang!! (min:5)")

            End If
        End If

        ' tombol spasi ditekan
        If Asc(e.KeyChar) = 32 Then
            cmd = New MySqlCommand("SELECT * FROM `pelanggan` WHERE idUser LIKE '%" & IdPelanggan.Text & "%'", conn)
            rd = cmd.ExecuteReader

            If rd.HasRows Then
                rd.Read()
                ' kode barang ada
                Dim tombolBehaviour() As Boolean = {False, True, True, True, False}
                AturKondisiForm(False, True)
                AturKondisiTombolAksi(tombolBehaviour)

                IdPelanggan.Text = rd.Item("idUser")
                namaPelanggan.Text = rd.Item("namaUser")
                alamatPelanggan.Text = rd.Item("alamat")
                emailPelanggan.Text = rd.Item("email")
                hpPelanggan.Text = rd.Item("noHP")
                rd.Close()
            End If

        End If
    End Sub
End Class