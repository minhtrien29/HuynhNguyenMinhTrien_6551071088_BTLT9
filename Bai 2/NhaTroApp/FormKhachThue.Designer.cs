namespace NhaTroApp;

partial class FormKhachThue
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
        this.lblHoTen = new System.Windows.Forms.Label();
        this.txtHoTen = new System.Windows.Forms.TextBox();
        this.grpGioiTinh = new System.Windows.Forms.GroupBox();
        this.radNam = new System.Windows.Forms.RadioButton();
        this.radNu = new System.Windows.Forms.RadioButton();
        this.lblNgaySinh = new System.Windows.Forms.Label();
        this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
        this.lblSoDienThoai = new System.Windows.Forms.Label();
        this.txtSoDienThoai = new System.Windows.Forms.TextBox();
        this.lblPhong = new System.Windows.Forms.Label();
        this.cboPhong = new System.Windows.Forms.ComboBox();
        this.lblTinh = new System.Windows.Forms.Label();
        this.cboTinh = new System.Windows.Forms.ComboBox();
        this.lblPhuongXa = new System.Windows.Forms.Label();
        this.cboPhuongXa = new System.Windows.Forms.ComboBox();
        this.txtPhuongXaManual = new System.Windows.Forms.TextBox();
        this.chkTamTru = new System.Windows.Forms.CheckBox();
        this.btnThem = new System.Windows.Forms.Button();
        this.btnSua = new System.Windows.Forms.Button();
        this.btnXoa = new System.Windows.Forms.Button();
        this.btnLamMoi = new System.Windows.Forms.Button();
        this.btnGayLoiThu = new System.Windows.Forms.Button();

        this.grpTimKiem = new System.Windows.Forms.GroupBox();
        this.lblTimTenSDT = new System.Windows.Forms.Label();
        this.txtTimTenSDT = new System.Windows.Forms.TextBox();
        this.lblLocPhong = new System.Windows.Forms.Label();
        this.cboLocPhong = new System.Windows.Forms.ComboBox();
        this.lblLocTinh = new System.Windows.Forms.Label();
        this.cboLocTinh = new System.Windows.Forms.ComboBox();
        this.btnBoLoc = new System.Windows.Forms.Button();

        this.dgvKhachThue = new System.Windows.Forms.DataGridView();

        this.grpThongTin.SuspendLayout();
        this.grpGioiTinh.SuspendLayout();
        this.grpTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).BeginInit();
        this.SuspendLayout();

        // 
        // grpThongTin
        // 
        this.grpThongTin.Controls.Add(this.lblHoTen);
        this.grpThongTin.Controls.Add(this.txtHoTen);
        this.grpThongTin.Controls.Add(this.grpGioiTinh);
        this.grpThongTin.Controls.Add(this.lblNgaySinh);
        this.grpThongTin.Controls.Add(this.dtpNgaySinh);
        this.grpThongTin.Controls.Add(this.lblSoDienThoai);
        this.grpThongTin.Controls.Add(this.txtSoDienThoai);
        this.grpThongTin.Controls.Add(this.lblPhong);
        this.grpThongTin.Controls.Add(this.cboPhong);
        this.grpThongTin.Controls.Add(this.lblTinh);
        this.grpThongTin.Controls.Add(this.cboTinh);
        this.grpThongTin.Controls.Add(this.lblPhuongXa);
        this.grpThongTin.Controls.Add(this.cboPhuongXa);
        this.grpThongTin.Controls.Add(this.txtPhuongXaManual);
        this.grpThongTin.Controls.Add(this.chkTamTru);
        this.grpThongTin.Controls.Add(this.btnThem);
        this.grpThongTin.Controls.Add(this.btnSua);
        this.grpThongTin.Controls.Add(this.btnXoa);
        this.grpThongTin.Controls.Add(this.btnLamMoi);
        this.grpThongTin.Controls.Add(this.btnGayLoiThu);
        this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpThongTin.Location = new System.Drawing.Point(12, 12);
        this.grpThongTin.Name = "grpThongTin";
        this.grpThongTin.Size = new System.Drawing.Size(430, 520);
        this.grpThongTin.TabIndex = 0;
        this.grpThongTin.TabStop = false;
        this.grpThongTin.Text = "Thông tin khách thuê";

        // Họ tên
        this.lblHoTen.Location = new System.Drawing.Point(15, 25);
        this.lblHoTen.Text = "Họ tên (*):";
        this.lblHoTen.Size = new System.Drawing.Size(95, 23);
        this.txtHoTen.Location = new System.Drawing.Point(115, 22);
        this.txtHoTen.Size = new System.Drawing.Size(300, 24);

        // Giới tính
        this.grpGioiTinh.Controls.Add(this.radNam);
        this.grpGioiTinh.Controls.Add(this.radNu);
        this.grpGioiTinh.Location = new System.Drawing.Point(15, 55);
        this.grpGioiTinh.Size = new System.Drawing.Size(400, 48);
        this.grpGioiTinh.Text = "Giới tính";
        this.radNam.Location = new System.Drawing.Point(50, 18);
        this.radNam.Text = "Nam";
        this.radNam.Checked = true;
        this.radNam.Size = new System.Drawing.Size(80, 22);
        this.radNu.Location = new System.Drawing.Point(200, 18);
        this.radNu.Text = "Nữ";
        this.radNu.Size = new System.Drawing.Size(80, 22);

        // Ngày sinh
        this.lblNgaySinh.Location = new System.Drawing.Point(15, 115);
        this.lblNgaySinh.Text = "Ngày sinh:";
        this.lblNgaySinh.Size = new System.Drawing.Size(95, 23);
        this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpNgaySinh.Location = new System.Drawing.Point(115, 112);
        this.dtpNgaySinh.Size = new System.Drawing.Size(300, 24);

        // SĐT
        this.lblSoDienThoai.Location = new System.Drawing.Point(15, 155);
        this.lblSoDienThoai.Text = "Số ĐT (*):";
        this.lblSoDienThoai.Size = new System.Drawing.Size(95, 23);
        this.txtSoDienThoai.Location = new System.Drawing.Point(115, 152);
        this.txtSoDienThoai.Size = new System.Drawing.Size(300, 24);

        // Phòng
        this.lblPhong.Location = new System.Drawing.Point(15, 195);
        this.lblPhong.Text = "Phòng (*):";
        this.lblPhong.Size = new System.Drawing.Size(95, 23);
        this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboPhong.Location = new System.Drawing.Point(115, 192);
        this.cboPhong.Size = new System.Drawing.Size(300, 24);

        // Tỉnh / Thành
        this.lblTinh.Location = new System.Drawing.Point(15, 235);
        this.lblTinh.Text = "Tỉnh/Thành:";
        this.lblTinh.Size = new System.Drawing.Size(95, 23);
        this.cboTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboTinh.Location = new System.Drawing.Point(115, 232);
        this.cboTinh.Size = new System.Drawing.Size(300, 24);
        this.cboTinh.SelectedIndexChanged += new System.EventHandler(this.cboTinh_SelectedIndexChanged);

        // Phường / Xã
        this.lblPhuongXa.Location = new System.Drawing.Point(15, 275);
        this.lblPhuongXa.Text = "Phường/Xã:";
        this.lblPhuongXa.Size = new System.Drawing.Size(95, 23);
        this.cboPhuongXa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboPhuongXa.Location = new System.Drawing.Point(115, 272);
        this.cboPhuongXa.Size = new System.Drawing.Size(300, 24);

        // Nhập tay Phường/Xã (chịu lỗi khi mất mạng)
        this.txtPhuongXaManual.Location = new System.Drawing.Point(115, 305);
        this.txtPhuongXaManual.Size = new System.Drawing.Size(300, 24);
        this.txtPhuongXaManual.PlaceholderText = "Nhập tay xã/phường nếu mất mạng";

        // Tạm trú
        this.chkTamTru.Location = new System.Drawing.Point(115, 340);
        this.chkTamTru.Text = "Đã đăng ký tạm trú";
        this.chkTamTru.Size = new System.Drawing.Size(200, 24);

        // Buttons
        this.btnThem.Text = "Thêm";
        this.btnThem.Location = new System.Drawing.Point(15, 385);
        this.btnThem.Size = new System.Drawing.Size(90, 35);
        this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

        this.btnSua.Text = "Sửa";
        this.btnSua.Location = new System.Drawing.Point(115, 385);
        this.btnSua.Size = new System.Drawing.Size(90, 35);
        this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

        this.btnXoa.Text = "Xóa";
        this.btnXoa.Location = new System.Drawing.Point(215, 385);
        this.btnXoa.Size = new System.Drawing.Size(90, 35);
        this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

        this.btnLamMoi.Text = "Làm mới";
        this.btnLamMoi.Location = new System.Drawing.Point(315, 385);
        this.btnLamMoi.Size = new System.Drawing.Size(90, 35);
        this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

        // Nút thử gây lỗi toàn cục
        this.btnGayLoiThu.Text = "⚡ Gây lỗi thử (Test Exception)";
        this.btnGayLoiThu.BackColor = System.Drawing.Color.MistyRose;
        this.btnGayLoiThu.Location = new System.Drawing.Point(15, 435);
        this.btnGayLoiThu.Size = new System.Drawing.Size(390, 32);
        this.btnGayLoiThu.Click += new System.EventHandler(this.btnGayLoiThu_Click);

        // 
        // grpTimKiem
        // 
        this.grpTimKiem.Controls.Add(this.lblTimTenSDT);
        this.grpTimKiem.Controls.Add(this.txtTimTenSDT);
        this.grpTimKiem.Controls.Add(this.lblLocPhong);
        this.grpTimKiem.Controls.Add(this.cboLocPhong);
        this.grpTimKiem.Controls.Add(this.lblLocTinh);
        this.grpTimKiem.Controls.Add(this.cboLocTinh);
        this.grpTimKiem.Controls.Add(this.btnBoLoc);
        this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.grpTimKiem.Location = new System.Drawing.Point(455, 12);
        this.grpTimKiem.Name = "grpTimKiem";
        this.grpTimKiem.Size = new System.Drawing.Size(760, 90);
        this.grpTimKiem.TabIndex = 1;
        this.grpTimKiem.TabStop = false;
        this.grpTimKiem.Text = "Tìm kiếm & Lọc";

        this.lblTimTenSDT.Location = new System.Drawing.Point(15, 25);
        this.lblTimTenSDT.Text = "Họ tên / SĐT:";
        this.lblTimTenSDT.Size = new System.Drawing.Size(90, 20);
        this.txtTimTenSDT.Location = new System.Drawing.Point(110, 22);
        this.txtTimTenSDT.Size = new System.Drawing.Size(170, 24);
        this.txtTimTenSDT.TextChanged += new System.EventHandler(this.FilterChanged);

        this.lblLocPhong.Location = new System.Drawing.Point(300, 25);
        this.lblLocPhong.Text = "Phòng:";
        this.lblLocPhong.Size = new System.Drawing.Size(55, 20);
        this.cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocPhong.Location = new System.Drawing.Point(360, 22);
        this.cboLocPhong.Size = new System.Drawing.Size(140, 24);
        this.cboLocPhong.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

        this.lblLocTinh.Location = new System.Drawing.Point(15, 58);
        this.lblLocTinh.Text = "Tỉnh/Thành:";
        this.lblLocTinh.Size = new System.Drawing.Size(90, 20);
        this.cboLocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboLocTinh.Location = new System.Drawing.Point(110, 55);
        this.cboLocTinh.Size = new System.Drawing.Size(170, 24);
        this.cboLocTinh.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);

        this.btnBoLoc.Text = "Bỏ lọc";
        this.btnBoLoc.Location = new System.Drawing.Point(540, 25);
        this.btnBoLoc.Size = new System.Drawing.Size(100, 45);
        this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);

        // 
        // dgvKhachThue
        // 
        this.dgvKhachThue.AllowUserToAddRows = false;
        this.dgvKhachThue.AllowUserToDeleteRows = false;
        this.dgvKhachThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvKhachThue.BackgroundColor = System.Drawing.Color.White;
        this.dgvKhachThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvKhachThue.Location = new System.Drawing.Point(455, 110);
        this.dgvKhachThue.MultiSelect = false;
        this.dgvKhachThue.Name = "dgvKhachThue";
        this.dgvKhachThue.ReadOnly = true;
        this.dgvKhachThue.RowHeadersVisible = false;
        this.dgvKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvKhachThue.Size = new System.Drawing.Size(760, 420);
        this.dgvKhachThue.TabIndex = 2;
        this.dgvKhachThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachThue_CellClick);

        // 
        // FormKhachThue
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1230, 545);
        this.Controls.Add(this.dgvKhachThue);
        this.Controls.Add(this.grpTimKiem);
        this.Controls.Add(this.grpThongTin);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "FormKhachThue";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quản lý nhà trọ - Quê quán qua API Hành chính VN";
        this.Load += new System.EventHandler(this.FormKhachThue_Load);

        this.grpThongTin.ResumeLayout(false);
        this.grpThongTin.PerformLayout();
        this.grpGioiTinh.ResumeLayout(false);
        this.grpTimKiem.ResumeLayout(false);
        this.grpTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).EndInit();
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.GroupBox grpThongTin;
    private System.Windows.Forms.Label lblHoTen;
    private System.Windows.Forms.TextBox txtHoTen;
    private System.Windows.Forms.GroupBox grpGioiTinh;
    private System.Windows.Forms.RadioButton radNam;
    private System.Windows.Forms.RadioButton radNu;
    private System.Windows.Forms.Label lblNgaySinh;
    private System.Windows.Forms.DateTimePicker dtpNgaySinh;
    private System.Windows.Forms.Label lblSoDienThoai;
    private System.Windows.Forms.TextBox txtSoDienThoai;
    private System.Windows.Forms.Label lblPhong;
    private System.Windows.Forms.ComboBox cboPhong;
    private System.Windows.Forms.Label lblTinh;
    private System.Windows.Forms.ComboBox cboTinh;
    private System.Windows.Forms.Label lblPhuongXa;
    private System.Windows.Forms.ComboBox cboPhuongXa;
    private System.Windows.Forms.TextBox txtPhuongXaManual;
    private System.Windows.Forms.CheckBox chkTamTru;
    private System.Windows.Forms.Button btnThem;
    private System.Windows.Forms.Button btnSua;
    private System.Windows.Forms.Button btnXoa;
    private System.Windows.Forms.Button btnLamMoi;
    private System.Windows.Forms.Button btnGayLoiThu;

    private System.Windows.Forms.GroupBox grpTimKiem;
    private System.Windows.Forms.Label lblTimTenSDT;
    private System.Windows.Forms.TextBox txtTimTenSDT;
    private System.Windows.Forms.Label lblLocPhong;
    private System.Windows.Forms.ComboBox cboLocPhong;
    private System.Windows.Forms.Label lblLocTinh;
    private System.Windows.Forms.ComboBox cboLocTinh;
    private System.Windows.Forms.Button btnBoLoc;

    private System.Windows.Forms.DataGridView dgvKhachThue;
}
