Imports MySql.Data.MySqlClient

Module Koneksi

    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader

    Const SERVER As String = "localhost"
    Const USERID As String = "root"
    Const PASSID As String = ""
    Const DB As String = "vb8"

    Public perintah As String

    Sub Koneksi()
        perintah = "Server=" & SERVER & _
                    ";uid=" & USERID & _
                    ";pwd=" & PASSID & _
                    ";database=" & DB & _
                    ""
        Try
            conn = New MySqlConnection(perintah)
            conn.Open()
        Catch ex As Exception
            MsgBox("Koneksi Belum Tersambung !!!")
            Menu.Close()
        End Try
    End Sub

    '
    ' MsgBoxHandler
    '
    Sub SuccessMsg(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Information, "Perintah Berhasil")
    End Sub

    Sub FailedMsg(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Critical, "Perintah Gagal")
    End Sub

    ' 
    ' BarangHandler
    '
    Sub TambahBarang(ByVal data() As String)
        Koneksi()

        perintah = "INSERT INTO `barang`(`kode`, `nama`, `harga`, `stok`, `satuan`) VALUES ('" & data(0) & "','" & data(1) & "','" & data(2) & "','" & data(3) & "','" & data(4) & "')"
        cmd = New MySqlCommand(perintah, conn)
        If cmd.ExecuteNonQuery > 0 Then
            SuccessMsg("Barang berhasil ditambahkan!!")
        Else
            FailedMsg("Barang gagal ditambahkan!!")
        End If
    End Sub

    Sub UbahDataBarang(ByVal data As String())
        Koneksi()

        perintah = "UPDATE `barang` SET `kode`='" & data(0) & "',`nama`='" & data(1) & "',`harga`='" & data(2) & "',`stok`='" & data(3) & "',`satuan`='" & data(4) & "' WHERE kode='" & data(0) & "'"
        cmd = New MySqlCommand(perintah, conn)
        ' cek apakah berhasil tersimpan
        If cmd.ExecuteNonQuery > 0 Then
            SuccessMsg("Barang berhasil diubah!!")
        Else
            FailedMsg("Barang gagal diubah!!")
        End If
    End Sub

    Sub HapusDataBarang(ByVal kode As String)
        Koneksi()

        perintah = "DELETE FROM `barang` WHERE kode='" & kode & "'"
        cmd = New MySqlCommand(perintah, conn)
        ' cek apakah berhasil tersimpan
        If cmd.ExecuteNonQuery > 0 Then
            SuccessMsg("Barang berhasil dihapus!!")
        Else
            FailedMsg("Barang gagal dihapus!!")
        End If
    End Sub

    '
    ' PelangganHandler
    '
    Sub TambahPelangganBaru(ByVal data() As String)
        Koneksi()

        perintah = "INSERT INTO `pelanggan`(`idUser`, `namaUser`, `alamat`, `email`, `noHP`) VALUES ('" & data(0) & "','" & data(1) & "','" & data(2) & "','" & data(3) & "','" & data(4) & "')"
        cmd = New MySqlCommand(perintah, conn)
        ' cek apakah berhasil tersimpan
        If cmd.ExecuteNonQuery > 0 Then
            SuccessMsg("Pelanggan baru berhasil ditambahkan!!")
        Else
            FailedMsg("Pelanggan gagal ditambahkan!!")
        End If
    End Sub

    Sub UbahPelanggan(ByVal data() As String)
        Koneksi()

        perintah = "UPDATE `pelanggan` SET `namaUser`='" & data(1) & "',`alamat`='" & data(2) & "',`email`='" & data(3) & "',`noHP`='" & data(4) & "' WHERE idUser='" & data(0) & "'"
        cmd = New MySqlCommand(perintah, conn)
        ' cek apakah berhasil tersimpan
        If cmd.ExecuteNonQuery > 0 Then
            SuccessMsg("Pelanggan berhasil diubah!!")
        Else
            FailedMsg("Pelanggan gagal diubah!!")
        End If
    End Sub

    Sub HapusPelanggan(ByVal id As String)
        Koneksi()

        perintah = "DELETE FROM `pelanggan` WHERE idUser='" & id & "'"
        cmd = New MySqlCommand(perintah, conn)
        ' cek apakah berhasil tersimpan
        If cmd.ExecuteNonQuery > 0 Then
            SuccessMsg("Pelanggan berhasil dihapus!!")
        Else
            FailedMsg("Pelanggan gagal dihapus!!")
        End If
    End Sub

End Module