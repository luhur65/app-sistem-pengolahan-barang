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
            MsgBox(ex.ToString)
            Barang.Close()
        End Try
    End Sub

    Sub ShowMessage(ByVal operation As Integer, ByVal message As String)
        If operation > 0 Then
            MsgBox(message)
        Else
            MsgBox("Perintah gagal dilakukan")
        End If
    End Sub


    ' BarangHandler
    Function GenerateNewKodeBarang()
        Dim random As System.Random = New Random()
        Dim randomKode As Integer = random.Next(0, 9999)
        Dim newKode As Integer = 0
        Select Case randomKode.ToString.Length
            Case 1
                newKode = "2000" & randomKode
            Case 2
                newKode = "200" & randomKode
            Case 3
                newKode = "20" & randomKode
            Case 4
                newKode = "2" & randomKode
        End Select

        Return newKode
    End Function

    Sub ValidasiData(ByVal data() As String, ByVal aksi As String)
        Koneksi()

        If Val(data(0)) = 0 Or data(1) = "" Or Val(data(2)) = 0 Or Val(data(3)) = 0 Or data(4) = "" Then
            MsgBox("Harap periksa kembali data barang anda")
        Else
            ' cek params aksi
            If aksi = "tambah" Then
                TambahBarang(data)
            ElseIf aksi = "ubah" Then
                UbahDataBarang(data)
            Else
                MsgBox("Aksi tidak diketahui")
            End If
        End If
    End Sub

    Sub TambahBarang(ByVal data() As String)
        Koneksi()

        perintah = "INSERT INTO `barang`(`kode`, `nama`, `harga`, `stok`, `satuan`) VALUES ('" & data(0) & "','" & data(1) & "','" & data(2) & "','" & data(3) & "','" & data(4) & "')"
        cmd = New MySqlCommand(perintah, conn)
        ShowMessage(cmd.ExecuteNonQuery(), "Barang baru ditambahkan")
    End Sub

    Sub UbahDataBarang(ByVal data As String())
        Koneksi()

        perintah = "UPDATE `barang` SET `kode`='" & data(0) & "',`nama`='" & data(1) & "',`harga`='" & data(2) & "',`stok`='" & data(3) & "',`satuan`='" & data(4) & "' WHERE kode='" & data(0) & "'"
        cmd = New MySqlCommand(perintah, conn)
        ShowMessage(cmd.ExecuteNonQuery(), "Barang telah diubah!!")
    End Sub

    Sub HapusDataBarang(ByVal kode As String)
        Koneksi()

        perintah = "DELETE FROM `barang` WHERE kode='" & kode & "'"
        cmd = New MySqlCommand(perintah, conn)
        ShowMessage(cmd.ExecuteNonQuery(), "Barang telah dihapus")
    End Sub

    ' PelangganHandler
    Function GenerateNewIDPelanggan(ByVal lastID As String)
        Dim newID As String = ""
        Select Case Len(lastID)
            Case 0
                newID = "00001"
            Case 1
                newID = "0000" & lastID + 1
            Case 2
                newID = "000" & lastID + 1
            Case 3
                newID = "00" & lastID + 1
            Case 4
                newID = "0" & lastID + 1
            Case 5
                newID = lastID + 1
        End Select
        Return newID
    End Function

    Sub ValidasiPelanggan(ByVal data() As String, ByVal aksi As String)
        Koneksi()

        If data(0) = "" Or data(1) = "" Or data(2) = "" Or data(3) = "" Or data(4) = "" Then
            MsgBox("Data masih ada yang kosong, Harap isi ulang kembali!!")
        Else
            ' cek params aksi
            If aksi = "tambah" Then
                TambahPelangganBaru(data)
            ElseIf aksi = "ubah" Then
                UbahPelanggan(data)
            Else
                MsgBox("Aksi tidak diketahui")
            End If
        End If
    End Sub

    Sub TambahPelangganBaru(ByVal data() As String)
        Koneksi()

        perintah = "INSERT INTO `pelanggan`(`idUser`, `namaUser`, `alamat`, `email`, `noHP`) VALUES ('" & data(0) & "','" & data(1) & "','" & data(2) & "','" & data(3) & "','" & data(4) & "')"
        cmd = New MySqlCommand(perintah, conn)
        ShowMessage(cmd.ExecuteNonQuery(), "Pelanggan baru telah ditambahkan")
    End Sub

    Sub UbahPelanggan(ByVal data() As String)
        Koneksi()

        perintah = "UPDATE `pelanggan` SET `namaUser`='" & data(1) & "',`alamat`='" & data(2) & "',`email`='" & data(3) & "',`noHP`='" & data(4) & "' WHERE idUser='" & data(0) & "'"
        cmd = New MySqlCommand(perintah, conn)
        ShowMessage(cmd.ExecuteNonQuery(), "Pelanggan telah diubah!!")
    End Sub

    Sub HapusPelanggan(ByVal id As String)
        Koneksi()

        perintah = "DELETE FROM `pelanggan` WHERE idUser='" & id & "'"
        cmd = New MySqlCommand(perintah, conn)
        ShowMessage(cmd.ExecuteNonQuery(), "Pelanggan telah dihapus")
    End Sub

End Module