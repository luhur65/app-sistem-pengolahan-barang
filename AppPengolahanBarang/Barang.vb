Imports MySql.Data.MySqlClient

Public Class Barang

    Dim tombolBehaviour() As Boolean = {True, False, False, False, True}

    Sub BuatListView()
        With LV.Columns
            .Add("No.", 50, HorizontalAlignment.Center)
            .Add("Kode Barang", 150, HorizontalAlignment.Center)
            .Add("Nama Barang", 250, HorizontalAlignment.Left)
            .Add("Satuan", 100, HorizontalAlignment.Center)
            .Add("Harga (Rp)", 113, HorizontalAlignment.Right)
            .Add("Stok", 100, HorizontalAlignment.Right)
            '.Add("Diskon", 120, HorizontalAlignment.Left)
            '.Add("Bayar", 120, HorizontalAlignment.Left)
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
                .Add(rd.Item("kode"))
                .Add(rd.Item("nama"))
                .Add(rd.Item("satuan"))
                .Add(Format(Val(rd.Item("harga")), "#,#,#"))
                .Add(rd.Item("stok"))
                '.Add(rd.Item("diskon"))
                '.Add(rd.Item("total_bayar"))
            End With
            LV.Items.Add(baris)
            i += 1
        End While
        rd.Close()
    End Sub

    Sub TampilkanSemuaBarang()
        Koneksi.Koneksi()

        perintah = "SELECT * FROM `barang` ORDER BY `id` ASC"
        cmd = New MySqlCommand(perintah, conn)
        rd = cmd.ExecuteReader
        LV.Clear()

        ' cek apakah ada data nya ( isi )
        If rd.HasRows() = True Then
            ' panggil function BuatListview -nya
            BuatListView()
            ' buat isi listview -nya
            IsiListview()
        Else
            LV.Columns.Add("Tidak ada Data", 500)
        End If

        TotalBarang.Text = "Jumlah Barang : " & LV.Items.Count()
    End Sub

    Sub IsiComboBox()
        Koneksi.Koneksi()
        ' Dapatkan data combobox satuan
        perintah = "SELECT `satuan` FROM `barang` Group By 1"
        cmd = New MySqlCommand(perintah, conn)
        rd = cmd.ExecuteReader()

        While rd.Read
            satuanBarang.Items.Add(rd.Item("satuan"))
        End While
        rd.Close()
    End Sub

    Sub HapusIsianForm()
        kodeBarang.Clear()
        namaBarang.Clear()
        hargaBarang.Clear()
        satuanBarang.ResetText()
        stokBarang.Clear()
    End Sub

    Sub AturKondisiForm(ByVal a As Boolean, ByVal b As Boolean)
        kodeBarang.Enabled = a
        namaBarang.Enabled = b
        hargaBarang.Enabled = b
        satuanBarang.Enabled = b
        stokBarang.Enabled = b
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

    Private Sub Barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilkanSemuaBarang()
        IsiComboBox()
        AturKondisiForm(True, False)
        AturKondisiTombolAksi(tombolBehaviour)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        HapusIsianForm()
        AturKondisiForm(True, False)
        AturKondisiTombolAksi(tombolBehaviour)
        kodeBarang.Focus()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        Koneksi.Koneksi()

        ' jika kode barang kosong maka buatkan kode barang baru dari hasil generate
        If kodeBarang.Text = "" Then
            kodeBarang.Text = GenerateNewKodeBarang()
        End If

        If Len(Trim(kodeBarang.Text)) = 5 Then
            cmd = New MySqlCommand("SELECT * FROM `barang` WHERE kode='" & kodeBarang.Text & "'", conn)
            rd = cmd.ExecuteReader()

            ' pengecekan data kode barang
            If rd.HasRows() Then
                rd.Read()
                ' kode barang ada
                Dim tombolBehaviour() As Boolean = {False, True, True, True, False}
                AturKondisiForm(False, True)
                AturKondisiTombolAksi(tombolBehaviour)

                namaBarang.Text = rd.Item("nama")
                hargaBarang.Text = rd.Item("harga")
                satuanBarang.Text = rd.Item("satuan")
                stokBarang.Text = rd.Item("stok")
            Else
                rd.Close()
                ' kode barang tidak ada
                Dim tombolBehaviour1() As Boolean = {True, False, False, True, False}
                If btnTambah.Text.ToLower = "simpan" Then
                    Dim Data() As String = {Val(kodeBarang.Text), namaBarang.Text, Val(hargaBarang.Text), Val(stokBarang.Text), satuanBarang.Text}
                    ValidasiData(Data, "tambah")
                    btnCancel_Click(sender, e)
                    TampilkanSemuaBarang()
                Else
                    AturKondisiForm(False, True)
                    AturKondisiTombolAksi(tombolBehaviour1)
                    btnTambah.Text = "Simpan"
                End If
            End If

        ElseIf Len(Trim(kodeBarang.Text)) > 5 Then
            MsgBox("Kode barang tidak boleh lebih dari 5")
        ElseIf Len(Trim(kodeBarang.Text)) < 5 Then
            MsgBox("Kode barang tidak boleh kurang dari 5")
        End If

        
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim Data() As String = {Val(kodeBarang.Text), namaBarang.Text, Val(hargaBarang.Text), Val(stokBarang.Text), satuanBarang.Text}
        ValidasiData(Data, "ubah")
        btnCancel_Click(sender, e)
        TampilkanSemuaBarang()
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Dim feedback As Integer
        feedback = MsgBox("Yakin ingin dihapus ??", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Konfirmasi")
        If feedback = MsgBoxResult.Yes Then
            HapusDataBarang(kodeBarang.Text)
            TampilkanSemuaBarang()
            btnCancel_Click(sender, e)
        End If
    End Sub

    Private Sub kodeBarang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kodeBarang.KeyPress
        Koneksi.Koneksi()

        If Asc(e.KeyChar) = 13 Then
            If Len(Trim(kodeBarang.Text)) = 5 Then
                btnTambah_Click(sender, e)
            ElseIf Len(Trim(kodeBarang.Text)) < 5 Then
                cmd = New MySqlCommand("SELECT * FROM `barang` WHERE kode LIKE '%" & kodeBarang.Text & "%'", conn)
                rd = cmd.ExecuteReader

                If rd.HasRows Then
                    rd.Read()
                    ' kode barang ada
                    Dim tombolBehaviour() As Boolean = {False, True, True, True, False}
                    AturKondisiForm(False, True)
                    AturKondisiTombolAksi(tombolBehaviour)

                    kodeBarang.Text = rd.Item("kode")
                    namaBarang.Text = rd.Item("nama")
                    hargaBarang.Text = rd.Item("harga")
                    satuanBarang.Text = rd.Item("satuan")
                    stokBarang.Text = rd.Item("stok")
                    rd.Close()
                Else
                    MsgBox("Data barang tidak ditemukan")
                End If
            ElseIf Len(Trim(kodeBarang.Text)) > 5 Then
                MsgBox("Kode barang lebih dari 5")
            Else
                MsgBox("Kode barang kosong")
            End If
        End If

    End Sub

End Class
