Public Class Menu

    Private Sub DataBarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataBarangToolStripMenuItem.Click
        Barang.MdiParent = Me
        Barang.Show()
    End Sub

    Private Sub DataPelangganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataPelangganToolStripMenuItem.Click
        Pelanggan.MdiParent = Me
        Pelanggan.Show()
    End Sub

End Class