namespace DaNgoaiApp;

partial class FormChuyenDi
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
        this.grpThongTin = new System.Windows.Forms.GroupBox();
        this.lblTenChuyen = new System.Windows.Forms.Label();
        this.txtTenChuyen = new System.Windows.Forms.TextBox();
        this.lblDiaDiem = new System.Windows.Forms.Label();
        this.txtDiaDiem = new System.Windows.Forms.TextBox();
        this.lblNgayDi = new System.Windows.Forms.Label();
        this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
        this.lblSoNguoi = new System.Windows.Forms.Label();
        this.numSoNguoi = new System.Windows.Forms.NumericUpDown();
        this.lblNganSach = new System.Windows.Forms.Label();
        this.numNganSach = new System.Windows.Forms.NumericUpDown();
        this.lblPhuongTien = new System.Windows.Forms.Label();
        this.cboPhuongTien = new System.Windows.Forms.ComboBox();
        this.chkDaHoanThanh = new System.Windows.Forms.CheckBox();
        this.lblGhiChu = new System.Windows.Forms.Label();
        this.txtGhiChu = new System.Windows.Forms.TextBox();
        this.btnThem = new System.Windows.Forms.Button();
        this.btnSua = new System.Windows.Forms.Button();
        this.btnXoa = new System.Windows.Forms.Button();
        this.btnLamMoi = new System.Windows.Forms.Button();

        this.grpTimKiem = new System.Windows.Forms.GroupBox();
        this.lblTimTenDiaDiem = new System.Windows.Forms.Label();
        this.txtTimTenDiaDiem = new System.Windows.Forms.TextBox();
        this.chkChuaHoanThanh = new System.Windows.Forms.CheckBox();
        this.lblTuNgay = new System.Windows.Forms.Label();
        this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        this.lblDenNgay = new System.Windows.Forms.Label();
        this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        this.btnBoLoc = new System.Windows.Forms.Button();

        this.grpNgonNgu = new System.Windows.Forms.GroupBox();
        this.radTiengViet = new System.Windows.Forms.RadioButton();
        this.radTiengAnh = new System.Windows.Forms.RadioButton();

        this.grpThoiTiet = new System.Windows.Forms.GroupBox();
        this.btnXemThoiTiet = new System.Windows.Forms.Button();
        this.prgLoading = new System.Windows.Forms.ProgressBar();
        this.lblIconMoTa = new System.Windows.Forms.Label();
        this.lblNhietDo = new System.Windows.Forms.Label();
        this.lblXacSuatMua = new System.Windows.Forms.Label();
        this.pnlCanhBao = new System.Windows.Forms.Panel();
        this.lblCanhBao = new System.Windows.Forms.Label();

        this.dgvChuyenDi = new System.Windows.Forms.DataGridView();

        this.grpThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numNganSach)).BeginInit();
        this.grpTimKiem.SuspendLayout();
        this.grpNgonNgu.SuspendLayout();
        this.grpThoiTiet.SuspendLayout();
        this.pnlCanhBao.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenDi)).BeginInit();
        this.SuspendLayout();

        // 
        // grpNgonNgu
        // 
        this.grpNgonNgu.Controls.Add(this.radTiengViet);
        this.grpNgonNgu.Controls.Add(this.radTiengAnh);
        this.grpNgonNgu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpNgonNgu.Location = new System.Drawing.Point(12, 10);
        this.grpNgonNgu.Name = "grpNgonNgu";
        this.grpNgonNgu.Size = new System.Drawing.Size(420, 50);
        this.grpNgonNgu.TabIndex = 0;
        this.grpNgonNgu.TabStop = false;
        this.grpNgonNgu.Text = "Ngôn ngữ / Language";

        this.radTiengViet.Location = new System.Drawing.Point(50, 20);
        this.radTiengViet.Text = "Tiếng Việt";
        this.radTiengViet.Size = new System.Drawing.Size(120, 20);
        this.radTiengViet.CheckedChanged += new System.EventHandler(this.LanguageChanged);

        this.radTiengAnh.Location = new System.Drawing.Point(220, 20);
        this.radTiengAnh.Text = "English";
        this.radTiengAnh.Size = new System.Drawing.Size(120, 20);
        this.radTiengAnh.CheckedChanged += new System.EventHandler(this.LanguageChanged);

        // 
        // grpThongTin
        // 
        this.grpThongTin.Controls.Add(this.lblTenChuyen);
        this.grpThongTin.Controls.Add(this.txtTenChuyen);
        this.grpThongTin.Controls.Add(this.lblDiaDiem);
        this.grpThongTin.Controls.Add(this.txtDiaDiem);
        this.grpThongTin.Controls.Add(this.lblNgayDi);
        this.grpThongTin.Controls.Add(this.dtpNgayDi);
        this.grpThongTin.Controls.Add(this.lblSoNguoi);
        this.grpThongTin.Controls.Add(this.numSoNguoi);
        this.grpThongTin.Controls.Add(this.lblNganSach);
        this.grpThongTin.Controls.Add(this.numNganSach);
        this.grpThongTin.Controls.Add(this.lblPhuongTien);
        this.grpThongTin.Controls.Add(this.cboPhuongTien);
        this.grpThongTin.Controls.Add(this.chkDaHoanThanh);
        this.grpThongTin.Controls.Add(this.lblGhiChu);
        this.grpThongTin.Controls.Add(this.txtGhiChu);
        this.grpThongTin.Controls.Add(this.btnThem);
        this.grpThongTin.Controls.Add(this.btnSua);
        this.grpThongTin.Controls.Add(this.btnXoa);
        this.grpThongTin.Controls.Add(this.btnLamMoi);
        this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpThongTin.Location = new System.Drawing.Point(12, 65);
        this.grpThongTin.Name = "grpThongTin";
        this.grpThongTin.Size = new System.Drawing.Size(420, 480);
        this.grpThongTin.TabIndex = 1;
        this.grpThongTin.TabStop = false;
        this.grpThongTin.Text = "Thông tin chuyến đi";

        // Tên chuyến
        this.lblTenChuyen.Location = new System.Drawing.Point(15, 25);
        this.lblTenChuyen.Text = "Tên chuyến:";
        this.lblTenChuyen.Size = new System.Drawing.Size(100, 22);
        this.txtTenChuyen.Location = new System.Drawing.Point(120, 22);
        this.txtTenChuyen.Size = new System.Drawing.Size(280, 24);

        // Địa điểm
        this.lblDiaDiem.Location = new System.Drawing.Point(15, 60);
        this.lblDiaDiem.Text = "Địa điểm:";
        this.lblDiaDiem.Size = new System.Drawing.Size(100, 22);
        this.txtDiaDiem.Location = new System.Drawing.Point(120, 57);
        this.txtDiaDiem.Size = new System.Drawing.Size(280, 24);

        // Ngày đi
        this.lblNgayDi.Location = new System.Drawing.Point(15, 95);
        this.lblNgayDi.Text = "Ngày đi:";
        this.lblNgayDi.Size = new System.Drawing.Size(100, 22);
        this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpNgayDi.Location = new System.Drawing.Point(120, 92);
        this.dtpNgayDi.Size = new System.Drawing.Size(280, 24);

        // Số người
        this.lblSoNguoi.Location = new System.Drawing.Point(15, 130);
        this.lblSoNguoi.Text = "Số người:";
        this.lblSoNguoi.Size = new System.Drawing.Size(100, 22);
        this.numSoNguoi.Location = new System.Drawing.Point(120, 127);
        this.numSoNguoi.Minimum = 1M;
        this.numSoNguoi.Value = 1M;
        this.numSoNguoi.Size = new System.Drawing.Size(280, 24);

        // Ngân sách
        this.lblNganSach.Location = new System.Drawing.Point(15, 165);
        this.lblNganSach.Text = "Ngân sách:";
        this.lblNganSach.Size = new System.Drawing.Size(100, 22);
        this.numNganSach.Location = new System.Drawing.Point(120, 162);
        this.numNganSach.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        this.numNganSach.ThousandsSeparator = true;
        this.numNganSach.Size = new System.Drawing.Size(280, 24);

        // Phương tiện
        this.lblPhuongTien.Location = new System.Drawing.Point(15, 200);
        this.lblPhuongTien.Text = "Phương tiện:";
        this.lblPhuongTien.Size = new System.Drawing.Size(100, 22);
        this.cboPhuongTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboPhuongTien.Location = new System.Drawing.Point(120, 197);
        this.cboPhuongTien.Size = new System.Drawing.Size(280, 24);

        // Đã hoàn thành
        this.chkDaHoanThanh.Location = new System.Drawing.Point(120, 230);
        this.chkDaHoanThanh.Text = "Đã hoàn thành";
        this.chkDaHoanThanh.Size = new System.Drawing.Size(200, 24);

        // Ghi chú
        this.lblGhiChu.Location = new System.Drawing.Point(15, 265);
        this.lblGhiChu.Text = "Ghi chú:";
        this.lblGhiChu.Size = new System.Drawing.Size(100, 22);
        this.txtGhiChu.Multiline = true;
        this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtGhiChu.Location = new System.Drawing.Point(120, 262);
        this.txtGhiChu.Size = new System.Drawing.Size(280, 60);

        // Buttons
        this.btnThem.Text = "Thêm";
        this.btnThem.Location = new System.Drawing.Point(15, 340);
        this.btnThem.Size = new System.Drawing.Size(85, 35);
        this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

        this.btnSua.Text = "Sửa";
        this.btnSua.Location = new System.Drawing.Point(115, 340);
        this.btnSua.Size = new System.Drawing.Size(85, 35);
        this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

        this.btnXoa.Text = "Xóa";
        this.btnXoa.Location = new System.Drawing.Point(215, 340);
        this.btnXoa.Size = new System.Drawing.Size(85, 35);
        this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

        this.btnLamMoi.Text = "Làm mới";
        this.btnLamMoi.Location = new System.Drawing.Point(315, 340);
        this.btnLamMoi.Size = new System.Drawing.Size(85, 35);
        this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

        // 
        // grpTimKiem
        // 
        this.grpTimKiem.Controls.Add(this.lblTimTenDiaDiem);
        this.grpTimKiem.Controls.Add(this.txtTimTenDiaDiem);
        this.grpTimKiem.Controls.Add(this.chkChuaHoanThanh);
        this.grpTimKiem.Controls.Add(this.lblTuNgay);
        this.grpTimKiem.Controls.Add(this.dtpTuNgay);
        this.grpTimKiem.Controls.Add(this.lblDenNgay);
        this.grpTimKiem.Controls.Add(this.dtpDenNgay);
        this.grpTimKiem.Controls.Add(this.btnBoLoc);
        this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpTimKiem.Location = new System.Drawing.Point(445, 10);
        this.grpTimKiem.Name = "grpTimKiem";
        this.grpTimKiem.Size = new System.Drawing.Size(760, 95);
        this.grpTimKiem.TabIndex = 2;
        this.grpTimKiem.TabStop = false;
        this.grpTimKiem.Text = "Tìm kiếm & Lọc";

        this.lblTimTenDiaDiem.Location = new System.Drawing.Point(15, 25);
        this.lblTimTenDiaDiem.Text = "Tên / Địa điểm:";
        this.lblTimTenDiaDiem.Size = new System.Drawing.Size(105, 20);
        this.txtTimTenDiaDiem.Location = new System.Drawing.Point(125, 22);
        this.txtTimTenDiaDiem.Size = new System.Drawing.Size(160, 24);
        this.txtTimTenDiaDiem.TextChanged += new System.EventHandler(this.FilterChanged);

        this.chkChuaHoanThanh.Location = new System.Drawing.Point(300, 22);
        this.chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";
        this.chkChuaHoanThanh.Size = new System.Drawing.Size(250, 24);
        this.chkChuaHoanThanh.CheckedChanged += new System.EventHandler(this.FilterChanged);

        this.lblTuNgay.Location = new System.Drawing.Point(15, 60);
        this.lblTuNgay.Text = "Từ ngày:";
        this.lblTuNgay.Size = new System.Drawing.Size(70, 20);
        this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpTuNgay.Location = new System.Drawing.Point(90, 57);
        this.dtpTuNgay.Size = new System.Drawing.Size(120, 24);
        this.dtpTuNgay.ValueChanged += new System.EventHandler(this.FilterChanged);

        this.lblDenNgay.Location = new System.Drawing.Point(230, 60);
        this.lblDenNgay.Text = "Đến ngày:";
        this.lblDenNgay.Size = new System.Drawing.Size(75, 20);
        this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpDenNgay.Location = new System.Drawing.Point(310, 57);
        this.dtpDenNgay.Size = new System.Drawing.Size(120, 24);
        this.dtpDenNgay.ValueChanged += new System.EventHandler(this.FilterChanged);

        this.btnBoLoc.Text = "Bỏ lọc";
        this.btnBoLoc.Location = new System.Drawing.Point(560, 30);
        this.btnBoLoc.Size = new System.Drawing.Size(90, 40);
        this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);

        // 
        // grpThoiTiet
        // 
        this.grpThoiTiet.Controls.Add(this.btnXemThoiTiet);
        this.grpThoiTiet.Controls.Add(this.prgLoading);
        this.grpThoiTiet.Controls.Add(this.lblIconMoTa);
        this.grpThoiTiet.Controls.Add(this.lblNhietDo);
        this.grpThoiTiet.Controls.Add(this.lblXacSuatMua);
        this.grpThoiTiet.Controls.Add(this.pnlCanhBao);
        this.grpThoiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpThoiTiet.Location = new System.Drawing.Point(445, 110);
        this.grpThoiTiet.Name = "grpThoiTiet";
        this.grpThoiTiet.Size = new System.Drawing.Size(760, 110);
        this.grpThoiTiet.TabIndex = 3;
        this.grpThoiTiet.TabStop = false;
        this.grpThoiTiet.Text = "Dự báo thời tiết (Open-Meteo API)";

        this.btnXemThoiTiet.Text = "⛅ Xem thời tiết";
        this.btnXemThoiTiet.Location = new System.Drawing.Point(15, 25);
        this.btnXemThoiTiet.Size = new System.Drawing.Size(140, 35);
        this.btnXemThoiTiet.Click += new System.EventHandler(this.btnXemThoiTiet_Click);

        this.prgLoading.Location = new System.Drawing.Point(15, 68);
        this.prgLoading.Size = new System.Drawing.Size(140, 15);
        this.prgLoading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        this.prgLoading.Visible = false;

        this.lblIconMoTa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblIconMoTa.Location = new System.Drawing.Point(170, 20);
        this.lblIconMoTa.Size = new System.Drawing.Size(250, 30);
        this.lblIconMoTa.Text = "Chọn chuyến đi để tra cứu";

        this.lblNhietDo.Location = new System.Drawing.Point(170, 52);
        this.lblNhietDo.Size = new System.Drawing.Size(180, 22);
        this.lblNhietDo.Text = "Nhiệt độ: --";

        this.lblXacSuatMua.Location = new System.Drawing.Point(170, 75);
        this.lblXacSuatMua.Size = new System.Drawing.Size(180, 22);
        this.lblXacSuatMua.Text = "Xác suất mưa: --";

        this.pnlCanhBao.Controls.Add(this.lblCanhBao);
        this.pnlCanhBao.Location = new System.Drawing.Point(430, 18);
        this.pnlCanhBao.Size = new System.Drawing.Size(320, 80);
        this.pnlCanhBao.Visible = false;
        this.pnlCanhBao.BackColor = System.Drawing.Color.SandyBrown;

        this.lblCanhBao.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblCanhBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblCanhBao.ForeColor = System.Drawing.Color.DarkRed;
        this.lblCanhBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // 
        // dgvChuyenDi
        // 
        this.dgvChuyenDi.AllowUserToAddRows = false;
        this.dgvChuyenDi.AllowUserToDeleteRows = false;
        this.dgvChuyenDi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvChuyenDi.BackgroundColor = System.Drawing.Color.White;
        this.dgvChuyenDi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvChuyenDi.Location = new System.Drawing.Point(445, 230);
        this.dgvChuyenDi.MultiSelect = false;
        this.dgvChuyenDi.Name = "dgvChuyenDi";
        this.dgvChuyenDi.ReadOnly = true;
        this.dgvChuyenDi.RowHeadersVisible = false;
        this.dgvChuyenDi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvChuyenDi.Size = new System.Drawing.Size(760, 315);
        this.dgvChuyenDi.TabIndex = 4;
        this.dgvChuyenDi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuyenDi_CellClick);

        // 
        // FormChuyenDi
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1220, 560);
        this.Controls.Add(this.dgvChuyenDi);
        this.Controls.Add(this.grpThoiTiet);
        this.Controls.Add(this.grpTimKiem);
        this.Controls.Add(this.grpThongTin);
        this.Controls.Add(this.grpNgonNgu);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "FormChuyenDi";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Kế hoạch dã ngoại & Dự báo thời tiết";
        this.Load += new System.EventHandler(this.FormChuyenDi_Load);

        this.grpNgonNgu.ResumeLayout(false);
        this.grpThongTin.ResumeLayout(false);
        this.grpThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numNganSach)).EndInit();
        this.grpTimKiem.ResumeLayout(false);
        this.grpTimKiem.PerformLayout();
        this.grpThoiTiet.ResumeLayout(false);
        this.pnlCanhBao.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenDi)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grpNgonNgu;
    private System.Windows.Forms.RadioButton radTiengViet;
    private System.Windows.Forms.RadioButton radTiengAnh;

    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.Label lblTenChuyen;
    private System.Windows.Forms.TextBox txtTenChuyen;
    private System.Windows.Forms.Label lblDiaDiem;
    private System.Windows.Forms.TextBox txtDiaDiem;
    private System.Windows.Forms.Label lblNgayDi;
    private System.Windows.Forms.DateTimePicker dtpNgayDi;
    private System.Windows.Forms.Label lblSoNguoi;
    private System.Windows.Forms.NumericUpDown numSoNguoi;
    private System.Windows.Forms.Label lblNganSach;
    private System.Windows.Forms.NumericUpDown numNganSach;
    private System.Windows.Forms.Label lblPhuongTien;
    private System.Windows.Forms.ComboBox cboPhuongTien;
    private System.Windows.Forms.CheckBox chkDaHoanThanh;
    private System.Windows.Forms.Label lblGhiChu;
    private System.Windows.Forms.TextBox txtGhiChu;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblTimTenDiaDiem;
    private System.Windows.Forms.TextBox txtTimTenDiaDiem;
    private System.Windows.Forms.CheckBox chkChuaHoanThanh;
    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private System.Windows.Forms.Button btnBoLoc;

    private System.Windows.Forms.GroupBox grpThoiTiet;
    private System.Windows.Forms.Button btnXemThoiTiet;
    private System.Windows.Forms.ProgressBar prgLoading;
    private System.Windows.Forms.Label lblIconMoTa;
    private System.Windows.Forms.Label lblNhietDo;
    private System.Windows.Forms.Label lblXacSuatMua;
    private System.Windows.Forms.Panel pnlCanhBao;
    private System.Windows.Forms.Label lblCanhBao;

    private System.Windows.Forms.DataGridView dgvChuyenDi;
}
