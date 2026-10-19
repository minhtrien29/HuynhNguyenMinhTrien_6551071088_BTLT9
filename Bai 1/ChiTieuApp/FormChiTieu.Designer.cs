namespace ChiTieuApp;

partial class FormChiTieu
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.dtpNgayChi = new System.Windows.Forms.DateTimePicker();
        this.txtNoiDung = new System.Windows.Forms.TextBox();
        this.cboLoaiChi = new System.Windows.Forms.ComboBox();
        this.numSoTien = new System.Windows.Forms.NumericUpDown();
        this.txtGhiChu = new System.Windows.Forms.TextBox();
        this.btnThem = new System.Windows.Forms.Button();
        this.btnSua = new System.Windows.Forms.Button();
        this.btnXoa = new System.Windows.Forms.Button();
        this.btnLamMoi = new System.Windows.Forms.Button();
        this.dgvChiTieu = new System.Windows.Forms.DataGridView();
        this.txtTimNoiDung = new System.Windows.Forms.TextBox();
        this.cboLocLoaiChi = new System.Windows.Forms.ComboBox();
        this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        this.lblTongChi = new System.Windows.Forms.Label();
        this.grpThongTin = new System.Windows.Forms.GroupBox();
        this.grpTimKiem = new System.Windows.Forms.GroupBox();
        this.lblNgayChi = new System.Windows.Forms.Label();
        this.lblNoiDung = new System.Windows.Forms.Label();
        this.lblLoaiChi = new System.Windows.Forms.Label();
        this.lblSoTien = new System.Windows.Forms.Label();
        this.lblGhiChu = new System.Windows.Forms.Label();
        this.lblTimNoiDung = new System.Windows.Forms.Label();
        this.lblLocLoaiChi = new System.Windows.Forms.Label();
        this.lblTuNgay = new System.Windows.Forms.Label();
        this.lblDenNgay = new System.Windows.Forms.Label();
        this.btnBoLoc = new System.Windows.Forms.Button();

        ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
        this.grpThongTin.SuspendLayout();
        this.grpTimKiem.SuspendLayout();
        this.SuspendLayout();

        // 
        // grpThongTin
        // 
        this.grpThongTin.Controls.Add(this.lblNgayChi);
        this.grpThongTin.Controls.Add(this.dtpNgayChi);
        this.grpThongTin.Controls.Add(this.lblNoiDung);
        this.grpThongTin.Controls.Add(this.txtNoiDung);
        this.grpThongTin.Controls.Add(this.lblLoaiChi);
        this.grpThongTin.Controls.Add(this.cboLoaiChi);
        this.grpThongTin.Controls.Add(this.lblSoTien);
        this.grpThongTin.Controls.Add(this.numSoTien);
        this.grpThongTin.Controls.Add(this.lblGhiChu);
        this.grpThongTin.Controls.Add(this.txtGhiChu);
        this.grpThongTin.Controls.Add(this.btnThem);
        this.grpThongTin.Controls.Add(this.btnSua);
        this.grpThongTin.Controls.Add(this.btnXoa);
        this.grpThongTin.Controls.Add(this.btnLamMoi);
        this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpThongTin.Location = new System.Drawing.Point(12, 12);
        this.grpThongTin.Name = "grpThongTin";
        this.grpThongTin.Size = new System.Drawing.Size(420, 480);
        this.grpThongTin.TabIndex = 0;
        this.grpThongTin.TabStop = false;
        this.grpThongTin.Text = "Thông tin chi tiêu";

        // lblNgayChi & dtpNgayChi
        this.lblNgayChi.Location = new System.Drawing.Point(15, 30);
        this.lblNgayChi.Text = "Ngày chi:";
        this.lblNgayChi.Size = new System.Drawing.Size(100, 25);
        this.dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpNgayChi.Location = new System.Drawing.Point(120, 27);
        this.dtpNgayChi.Size = new System.Drawing.Size(280, 25);

        // lblNoiDung & txtNoiDung
        this.lblNoiDung.Location = new System.Drawing.Point(15, 70);
        this.lblNoiDung.Text = "Nội dung (*):";
        this.lblNoiDung.Size = new System.Drawing.Size(100, 25);
        this.txtNoiDung.Location = new System.Drawing.Point(120, 67);
        this.txtNoiDung.Size = new System.Drawing.Size(280, 25);

        // lblLoaiChi & cboLoaiChi
        this.lblLoaiChi.Location = new System.Drawing.Point(15, 110);
        this.lblLoaiChi.Text = "Loại chi:";
        this.lblLoaiChi.Size = new System.Drawing.Size(100, 25);
        this.cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLoaiChi.Location = new System.Drawing.Point(120, 107);
        this.cboLoaiChi.Size = new System.Drawing.Size(280, 25);

        // lblSoTien & numSoTien
        this.lblSoTien.Location = new System.Drawing.Point(15, 150);
        this.lblSoTien.Text = "Số tiền (đ):";
        this.lblSoTien.Size = new System.Drawing.Size(100, 25);
        this.numSoTien.Location = new System.Drawing.Point(120, 147);
        this.numSoTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        this.numSoTien.Increment = 1000M;
        this.numSoTien.ThousandsSeparator = true;
        this.numSoTien.Size = new System.Drawing.Size(280, 25);

        // lblGhiChu & txtGhiChu
        this.lblGhiChu.Location = new System.Drawing.Point(15, 190);
        this.lblGhiChu.Text = "Ghi chú:";
        this.lblGhiChu.Size = new System.Drawing.Size(100, 25);
        this.txtGhiChu.Multiline = true;
        this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtGhiChu.Location = new System.Drawing.Point(120, 187);
        this.txtGhiChu.Size = new System.Drawing.Size(280, 80);

        // Buttons
        this.btnThem.Text = "Thêm";
        this.btnThem.Location = new System.Drawing.Point(15, 290);
        this.btnThem.Size = new System.Drawing.Size(90, 35);
        this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

        this.btnSua.Text = "Sửa";
        this.btnSua.Location = new System.Drawing.Point(115, 290);
        this.btnSua.Size = new System.Drawing.Size(90, 35);
        this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

        this.btnXoa.Text = "Xóa";
        this.btnXoa.Location = new System.Drawing.Point(215, 290);
        this.btnXoa.Size = new System.Drawing.Size(90, 35);
        this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

        this.btnLamMoi.Text = "Làm mới";
        this.btnLamMoi.Location = new System.Drawing.Point(315, 290);
        this.btnLamMoi.Size = new System.Drawing.Size(85, 35);
        this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

        // 
        // grpTimKiem
        // 
        this.grpTimKiem.Controls.Add(this.lblTimNoiDung);
        this.grpTimKiem.Controls.Add(this.txtTimNoiDung);
        this.grpTimKiem.Controls.Add(this.lblLocLoaiChi);
        this.grpTimKiem.Controls.Add(this.cboLocLoaiChi);
        this.grpTimKiem.Controls.Add(this.lblTuNgay);
        this.grpTimKiem.Controls.Add(this.dtpTuNgay);
        this.grpTimKiem.Controls.Add(this.lblDenNgay);
        this.grpTimKiem.Controls.Add(this.dtpDenNgay);
        this.grpTimKiem.Controls.Add(this.btnBoLoc);
        this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpTimKiem.Location = new System.Drawing.Point(445, 12);
        this.grpTimKiem.Name = "grpTimKiem";
        this.grpTimKiem.Size = new System.Drawing.Size(730, 100);
        this.grpTimKiem.TabIndex = 1;
        this.grpTimKiem.TabStop = false;
        this.grpTimKiem.Text = "Tìm kiếm & Lọc";

        this.lblTimNoiDung.Location = new System.Drawing.Point(15, 25);
        this.lblTimNoiDung.Text = "Tìm nội dung:";
        this.lblTimNoiDung.Size = new System.Drawing.Size(90, 20);
        this.txtTimNoiDung.Location = new System.Drawing.Point(110, 22);
        this.txtTimNoiDung.Size = new System.Drawing.Size(180, 24);
        this.txtTimNoiDung.TextChanged += new System.EventHandler(this.FilterChanged);

        this.lblLocLoaiChi.Location = new System.Drawing.Point(310, 25);
        this.lblLocLoaiChi.Text = "Loại chi:";
        this.lblLocLoaiChi.Size = new System.Drawing.Size(65, 20);
        this.cboLocLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocLoaiChi.Location = new System.Drawing.Point(380, 22);
        this.cboLocLoaiChi.Size = new System.Drawing.Size(150, 24);
        this.cboLocLoaiChi.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

        this.lblTuNgay.Location = new System.Drawing.Point(15, 60);
        this.lblTuNgay.Text = "Từ ngày:";
        this.lblTuNgay.Size = new System.Drawing.Size(65, 20);
        this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpTuNgay.Location = new System.Drawing.Point(110, 57);
        this.dtpTuNgay.Size = new System.Drawing.Size(130, 24);
        this.dtpTuNgay.ValueChanged += new System.EventHandler(this.FilterChanged);

        this.lblDenNgay.Location = new System.Drawing.Point(260, 60);
        this.lblDenNgay.Text = "Đến ngày:";
        this.lblDenNgay.Size = new System.Drawing.Size(70, 20);
        this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpDenNgay.Location = new System.Drawing.Point(340, 57);
        this.dtpDenNgay.Size = new System.Drawing.Size(130, 24);
        this.dtpDenNgay.ValueChanged += new System.EventHandler(this.FilterChanged);

        this.btnBoLoc.Text = "Bỏ lọc";
        this.btnBoLoc.Location = new System.Drawing.Point(550, 35);
        this.btnBoLoc.Size = new System.Drawing.Size(90, 35);
        this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);

        // 
        // dgvChiTieu
        // 
        this.dgvChiTieu.AllowUserToAddRows = false;
        this.dgvChiTieu.AllowUserToDeleteRows = false;
        this.dgvChiTieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvChiTieu.BackgroundColor = System.Drawing.Color.White;
        this.dgvChiTieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvChiTieu.Location = new System.Drawing.Point(445, 120);
        this.dgvChiTieu.MultiSelect = false;
        this.dgvChiTieu.Name = "dgvChiTieu";
        this.dgvChiTieu.ReadOnly = true;
        this.dgvChiTieu.RowHeadersVisible = false;
        this.dgvChiTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvChiTieu.Size = new System.Drawing.Size(730, 330);
        this.dgvChiTieu.TabIndex = 2;
        this.dgvChiTieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTieu_CellClick);

        // 
        // lblTongChi
        // 
        this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTongChi.ForeColor = System.Drawing.Color.DarkRed;
        this.lblTongChi.Location = new System.Drawing.Point(445, 460);
        this.lblTongChi.Name = "lblTongChi";
        this.lblTongChi.Size = new System.Drawing.Size(730, 30);
        this.lblTongChi.TabIndex = 3;
        this.lblTongChi.Text = "Tổng chi: 0 đ";
        this.lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        // 
        // FormChiTieu
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1190, 505);
        this.Controls.Add(this.lblTongChi);
        this.Controls.Add(this.dgvChiTieu);
        this.Controls.Add(this.grpTimKiem);
        this.Controls.Add(this.grpThongTin);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "FormChiTieu";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Sổ chi tiêu cá nhân - Phiên bản 1.0.0";
        this.Load += new System.EventHandler(this.FormChiTieu_Load);

        ((System.ComponentModel.ISupportInitialize)(this.numSoTien)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
        this.grpThongTin.ResumeLayout(false);
        this.grpThongTin.PerformLayout();
        this.grpTimKiem.ResumeLayout(false);
        this.grpTimKiem.PerformLayout();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.DateTimePicker dtpNgayChi;
    private System.Windows.Forms.TextBox txtNoiDung;
    private System.Windows.Forms.ComboBox cboLoaiChi;
    private System.Windows.Forms.NumericUpDown numSoTien;
    private System.Windows.Forms.TextBox txtGhiChu;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.DataGridView dgvChiTieu;
    private System.Windows.Forms.TextBox txtTimNoiDung;
    private System.Windows.Forms.ComboBox cboLocLoaiChi;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.Label lblTongChi;
    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblNgayChi;
    private System.Windows.Forms.Label lblNoiDung;
    private System.Windows.Forms.Label lblLoaiChi;
    private System.Windows.Forms.Label lblSoTien;
    private System.Windows.Forms.Label lblGhiChu;
    private System.Windows.Forms.Label lblTimNoiDung;
    private System.Windows.Forms.Label lblLocLoaiChi;
    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.Button btnBoLoc;
}
