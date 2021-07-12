Imports MySql.Data.MySqlClient

Public Class Barang

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

    Sub IsiListview(ByVal rd As Object)
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
            IsiListview(rd)
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

    Sub Bersih()
        HapusIsianForm()
        AturKondisiForm(False, False)
        AturKondisiTombolAksi(True, False, False, False, True, False)
        kodeBarang.Focus()
        TampilkanSemuaBarang()
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

    Sub AturKondisiTombolAksi(ByVal a As Boolean, ByVal b As Boolean, ByVal c As Boolean, ByVal d As Boolean, ByVal e As Boolean, ByVal f As Boolean)
        btnTambah.Enabled = a
        btnEdit.Enabled = b
        btnHapus.Enabled = c
        btnCancel.Enabled = d
        btnQuit.Enabled = e
        btnSave.Enabled = f
    End Sub

    Private Sub Barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilkanSemuaBarang()
        AturKondisiForm(False, False)
        AturKondisiTombolAksi(True, False, False, False, True, False)
        IsiComboBox()
    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        AturKondisiForm(True, False)
        AturKondisiTombolAksi(False, False, False, True, False, False)
        kodeBarang.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Data() As String = {Val(kodeBarang.Text), namaBarang.Text, Val(hargaBarang.Text), Val(stokBarang.Text), UCase(satuanBarang.Text)}
        If Val(Data(0)) = 0 Or Data(1) = "" Or Val(Data(2)) = 0 Or Val(Data(3)) = 0 Or Data(4) = "" Then
            MsgBox("Data masih ada yang kosong / salah")
        Else
            TambahBarang(Data)
            Bersih()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim Data() As String = {Val(kodeBarang.Text), namaBarang.Text, Val(hargaBarang.Text), Val(stokBarang.Text), UCase(satuanBarang.Text)}
        If Val(Data(0)) = 0 Or Data(1) = "" Or Val(Data(2)) = 0 Or Val(Data(3)) = 0 Or Data(4) = "" Then
            MsgBox("Data masih ada yang kosong / salah")
        Else
            UbahDataBarang(Data)
            Bersih()
        End If
    End Sub

    Private Sub btnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHapus.Click
        Dim feedback As Integer
        feedback = MsgBox("Yakin ingin dihapus ??", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Konfirmasi")

        ' Cek feedback ? 
        ' ya -> hapus data barang
        ' no -> hapus data barang tidak jadi
        If feedback = MsgBoxResult.Yes Then
            HapusDataBarang(kodeBarang.Text)
            Bersih()
        End If
    End Sub

    Private Sub kodeBarang_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles kodeBarang.KeyPress
        Koneksi.Koneksi()

        ' tombol enter ditekan
        If Asc(e.KeyChar) = 13 Then
            cmd = New MySqlCommand("SELECT * FROM `barang` WHERE kode='" & kodeBarang.Text & "'", conn)
            rd = cmd.ExecuteReader()

            ' pengecekan data kode barang
            ' jika ada
            If rd.HasRows() Then
                rd.Read()
                ' kode barang ada
                AturKondisiForm(False, True)
                AturKondisiTombolAksi(False, True, True, True, False, False)

                namaBarang.Text = rd.Item("nama")
                hargaBarang.Text = rd.Item("harga")
                satuanBarang.Text = rd.Item("satuan")
                stokBarang.Text = rd.Item("stok")
                rd.Close()
            Else
                ' kode barang tidak ada
                AturKondisiForm(False, True)
                AturKondisiTombolAksi(False, False, False, True, False, True)

            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Bersih()
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Me.Close()
    End Sub

End Class