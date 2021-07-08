<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pelanggan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pelanggan))
        Me.LV = New System.Windows.Forms.ListView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.hpPelanggan = New System.Windows.Forms.TextBox
        Me.emailPelanggan = New System.Windows.Forms.TextBox
        Me.alamatPelanggan = New System.Windows.Forms.TextBox
        Me.namaPelanggan = New System.Windows.Forms.TextBox
        Me.IdPelanggan = New System.Windows.Forms.TextBox
        Me.btnTambah = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnQuit = New System.Windows.Forms.Button
        Me.btnHapus = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.TotalPelanggan = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LV
        '
        Me.LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV.Location = New System.Drawing.Point(13, 211)
        Me.LV.Margin = New System.Windows.Forms.Padding(4)
        Me.LV.Name = "LV"
        Me.LV.Size = New System.Drawing.Size(756, 297)
        Me.LV.TabIndex = 10
        Me.LV.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID Pelanggan"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama Pelanggan"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Alamat"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "No. Handphone"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(410, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Email"
        '
        'hpPelanggan
        '
        Me.hpPelanggan.Location = New System.Drawing.Point(138, 130)
        Me.hpPelanggan.Name = "hpPelanggan"
        Me.hpPelanggan.Size = New System.Drawing.Size(266, 25)
        Me.hpPelanggan.TabIndex = 3
        '
        'emailPelanggan
        '
        Me.emailPelanggan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.emailPelanggan.Location = New System.Drawing.Point(461, 130)
        Me.emailPelanggan.Name = "emailPelanggan"
        Me.emailPelanggan.Size = New System.Drawing.Size(308, 25)
        Me.emailPelanggan.TabIndex = 4
        '
        'alamatPelanggan
        '
        Me.alamatPelanggan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.alamatPelanggan.Location = New System.Drawing.Point(138, 68)
        Me.alamatPelanggan.Multiline = True
        Me.alamatPelanggan.Name = "alamatPelanggan"
        Me.alamatPelanggan.Size = New System.Drawing.Size(631, 56)
        Me.alamatPelanggan.TabIndex = 2
        '
        'namaPelanggan
        '
        Me.namaPelanggan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.namaPelanggan.Location = New System.Drawing.Point(138, 37)
        Me.namaPelanggan.Name = "namaPelanggan"
        Me.namaPelanggan.Size = New System.Drawing.Size(266, 25)
        Me.namaPelanggan.TabIndex = 1
        '
        'IdPelanggan
        '
        Me.IdPelanggan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IdPelanggan.Location = New System.Drawing.Point(138, 6)
        Me.IdPelanggan.MaxLength = 5
        Me.IdPelanggan.Name = "IdPelanggan"
        Me.IdPelanggan.Size = New System.Drawing.Size(266, 25)
        Me.IdPelanggan.TabIndex = 0
        '
        'btnTambah
        '
        Me.btnTambah.Image = CType(resources.GetObject("btnTambah.Image"), System.Drawing.Image)
        Me.btnTambah.Location = New System.Drawing.Point(12, 167)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(139, 37)
        Me.btnTambah.TabIndex = 5
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTambah.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.Location = New System.Drawing.Point(157, 167)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(97, 37)
        Me.btnEdit.TabIndex = 6
        Me.btnEdit.Text = "Ubah"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnQuit
        '
        Me.btnQuit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuit.Image = CType(resources.GetObject("btnQuit.Image"), System.Drawing.Image)
        Me.btnQuit.Location = New System.Drawing.Point(604, 167)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(166, 37)
        Me.btnQuit.TabIndex = 9
        Me.btnQuit.Text = "Keluar"
        Me.btnQuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Image = CType(resources.GetObject("btnHapus.Image"), System.Drawing.Image)
        Me.btnHapus.Location = New System.Drawing.Point(260, 167)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(97, 37)
        Me.btnHapus.TabIndex = 7
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(501, 167)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(97, 37)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Batal"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalPelanggan})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 513)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(782, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TotalPelanggan
        '
        Me.TotalPelanggan.Name = "TotalPelanggan"
        Me.TotalPelanggan.Size = New System.Drawing.Size(0, 17)
        '
        'Pelanggan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 535)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.alamatPelanggan)
        Me.Controls.Add(Me.emailPelanggan)
        Me.Controls.Add(Me.IdPelanggan)
        Me.Controls.Add(Me.namaPelanggan)
        Me.Controls.Add(Me.hpPelanggan)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LV)
        Me.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Pelanggan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Pelanggan"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LV As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents hpPelanggan As System.Windows.Forms.TextBox
    Friend WithEvents emailPelanggan As System.Windows.Forms.TextBox
    Friend WithEvents alamatPelanggan As System.Windows.Forms.TextBox
    Friend WithEvents namaPelanggan As System.Windows.Forms.TextBox
    Friend WithEvents IdPelanggan As System.Windows.Forms.TextBox
    Friend WithEvents btnTambah As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents btnHapus As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalPelanggan As System.Windows.Forms.ToolStripStatusLabel
End Class
