using Microsoft.EntityFrameworkCore;
using NhaTroApp.Models;
using NhaTroApp.Services;
using Serilog;

namespace NhaTroApp;

public partial class FormKhachThue : Form
{
    private int _selectedMaKhach = -1;
    private List<ProvinceItem> _provinces = new();
    private bool _isLoadingAddress = false;

    public FormKhachThue()
    {
        InitializeComponent();
    }

    private async void FormKhachThue_Load(object sender, EventArgs e)
    {
        LamMoiForm();
        LoadRooms();
        await LoadProvincesAsync();
        LoadData();
    }

    private void LoadRooms()
    {
        try
        {
            using var context = new QLNhaTroContext();
            var allRooms = context.PhongTros.AsNoTracking().OrderBy(p => p.TenPhong).ToList();

            // Cho ComboBox thêm / sửa: Khi thêm mới chỉ hiện phòng đang trống hoặc phòng hiện tại của khách
            cboPhong.DataSource = allRooms;
            cboPhong.DisplayMember = "TenPhong";
            cboPhong.ValueMember = "MaPhong";

            // ComboBox lọc
            var filterRooms = new List<PhongTro>
            {
                new PhongTro { MaPhong = 0, TenPhong = "Tất cả phòng" }
            };
            filterRooms.AddRange(allRooms);
            cboLocPhong.DataSource = filterRooms;
            cboLocPhong.DisplayMember = "TenPhong";
            cboLocPhong.ValueMember = "MaPhong";
            cboLocPhong.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh sách phòng trọ.");
        }
    }

    private async Task LoadProvincesAsync()
    {
        _isLoadingAddress = true;
        cboTinh.Enabled = false;
        cboTinh.Text = "Đang tải tỉnh/thành...";

        try
        {
            _provinces = await AddressService.GetProvincesAsync();

            cboTinh.DataSource = new List<ProvinceItem>(_provinces);
            cboTinh.DisplayMember = "Name";
            cboTinh.ValueMember = "Code";

            // Cbo lọc tỉnh
            var filterProvinces = new List<ProvinceItem>
            {
                new ProvinceItem { Code = 0, Name = "Tất cả tỉnh" }
            };
            filterProvinces.AddRange(_provinces);
            cboLocTinh.DataSource = filterProvinces;
            cboLocTinh.DisplayMember = "Name";
            cboLocTinh.ValueMember = "Code";
            cboLocTinh.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "Không thể tải danh sách tỉnh/thành qua API.");
            MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng. Bạn vẫn có thể nhập tay thông tin.", 
                "Cảnh báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            cboTinh.Enabled = true;
            _isLoadingAddress = false;
            if (cboTinh.Items.Count > 0 && cboTinh.SelectedIndex >= 0)
            {
                await LoadWardsForCurrentProvince();
            }
        }
    }

    private async void cboTinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isLoadingAddress) return;
        await LoadWardsForCurrentProvince();
    }

    private async Task LoadWardsForCurrentProvince()
    {
        if (cboTinh.SelectedValue == null || !int.TryParse(cboTinh.SelectedValue.ToString(), out int code) || code <= 0)
        {
            cboPhuongXa.DataSource = null;
            return;
        }

        try
        {
            cboPhuongXa.Enabled = false;
            cboPhuongXa.Text = "Đang tải phường/xã...";
            var wards = await AddressService.GetWardsAsync(code);

            cboPhuongXa.DataSource = wards;
            cboPhuongXa.DisplayMember = "Name";
            cboPhuongXa.ValueMember = "Code";
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "Lỗi khi nạp danh sách phường/xã cho tỉnh code {Code}", code);
            cboPhuongXa.DataSource = null;
        }
        finally
        {
            cboPhuongXa.Enabled = true;
        }
    }

    private void LoadData()
    {
        try
        {
            using var context = new QLNhaTroContext();
            var query = context.KhachThues.Include(k => k.MaPhongNavigation).AsNoTracking().AsQueryable();

            // Tìm theo tên hoặc SĐT
            string search = txtTimTenSDT.Text.Trim();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(k => k.HoTen.Contains(search) || k.SoDienThoai.Contains(search));
            }

            // Lọc theo phòng
            if (cboLocPhong.SelectedValue != null && int.TryParse(cboLocPhong.SelectedValue.ToString(), out int pId) && pId > 0)
            {
                query = query.Where(k => k.MaPhong == pId);
            }

            // Lọc theo tỉnh
            if (cboLocTinh.SelectedValue != null && int.TryParse(cboLocTinh.SelectedValue.ToString(), out int tId) && tId > 0)
            {
                query = query.Where(k => k.MaTinh == tId);
            }

            var list = query.OrderByDescending(k => k.MaKhach).ToList();

            dgvKhachThue.DataSource = list.Select(k => new
            {
                k.MaKhach,
                k.HoTen,
                k.GioiTinh,
                NgaySinh = k.NgaySinh.ToString("dd/MM/yyyy"),
                k.SoDienThoai,
                TenPhong = k.MaPhongNavigation != null ? k.MaPhongNavigation.TenPhong : "",
                GiaThue = k.MaPhongNavigation != null ? k.MaPhongNavigation.GiaThue.ToString("#,##0") + " đ" : "",
                QueQuan = $"{(string.IsNullOrEmpty(k.TenPhuongXa) ? "" : k.TenPhuongXa + " - ")}{(k.TenTinh ?? "")}",
                DaDangKyTamTru = k.DaDangKyTamTru,
                k.MaPhong,
                k.MaTinh,
                k.TenTinh,
                k.MaPhuongXa,
                k.TenPhuongXa,
                RawNgaySinh = k.NgaySinh
            }).ToList();

            // Định dạng tiêu đề cột
            if (dgvKhachThue.Columns["MaKhach"] != null) dgvKhachThue.Columns["MaKhach"].HeaderText = "Mã";
            if (dgvKhachThue.Columns["HoTen"] != null) dgvKhachThue.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvKhachThue.Columns["GioiTinh"] != null) dgvKhachThue.Columns["GioiTinh"].HeaderText = "Phái";
            if (dgvKhachThue.Columns["NgaySinh"] != null) dgvKhachThue.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            if (dgvKhachThue.Columns["SoDienThoai"] != null) dgvKhachThue.Columns["SoDienThoai"].HeaderText = "SĐT";
            if (dgvKhachThue.Columns["TenPhong"] != null) dgvKhachThue.Columns["TenPhong"].HeaderText = "Phòng";
            if (dgvKhachThue.Columns["GiaThue"] != null)
            {
                dgvKhachThue.Columns["GiaThue"].HeaderText = "Giá thuê";
                dgvKhachThue.Columns["GiaThue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvKhachThue.Columns["QueQuan"] != null) dgvKhachThue.Columns["QueQuan"].HeaderText = "Quê quán";
            if (dgvKhachThue.Columns["DaDangKyTamTru"] != null) dgvKhachThue.Columns["DaDangKyTamTru"].HeaderText = "Tạm trú";

            // Ẩn các cột phụ
            string[] hiddenCols = { "MaPhong", "MaTinh", "TenTinh", "MaPhuongXa", "TenPhuongXa", "RawNgaySinh" };
            foreach (var col in hiddenCols)
            {
                if (dgvKhachThue.Columns[col] != null) dgvKhachThue.Columns[col].Visible = false;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi tải danh sách khách thuê.");
            MessageBox.Show("Đã xảy ra lỗi khi tải danh sách khách thuê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvKhachThue.Rows[e.RowIndex].DataBoundItem != null)
        {
            dynamic item = dgvKhachThue.Rows[e.RowIndex].DataBoundItem;
            _selectedMaKhach = item.MaKhach;
            txtHoTen.Text = item.HoTen;
            if (item.GioiTinh == "Nữ") radNu.Checked = true;
            else radNam.Checked = true;

            DateOnly ns = item.RawNgaySinh;
            dtpNgaySinh.Value = ns.ToDateTime(TimeOnly.MinValue);
            txtSoDienThoai.Text = item.SoDienThoai;
            cboPhong.SelectedValue = item.MaPhong;

            if (item.MaTinh != null)
            {
                cboTinh.SelectedValue = item.MaTinh;
            }
            txtPhuongXaManual.Text = item.TenPhuongXa ?? string.Empty;
            chkTamTru.Checked = item.DaDangKyTamTru;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show("Vui lòng nhập họ tên khách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtHoTen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
        {
            MessageBox.Show("Vui lòng nhập số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSoDienThoai.Focus();
            return false;
        }

        if (cboPhong.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cboPhong.Focus();
            return false;
        }

        return true;
    }

    private void UpdateRoomStatus(QLNhaTroContext context, int roomId)
    {
        int count = context.KhachThues.Count(k => k.MaPhong == roomId);
        var room = context.PhongTros.Find(roomId);
        if (room != null)
        {
            room.TinhTrang = count > 0 ? "Đang thuê" : "Trống";
        }
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            using var context = new QLNhaTroContext();

            int roomId = (int)cboPhong.SelectedValue!;

            // Lấy thông tin tỉnh/thành
            int? maTinh = null;
            string? tenTinh = null;
            if (cboTinh.SelectedItem is ProvinceItem pItem)
            {
                maTinh = pItem.Code;
                tenTinh = pItem.Name;
            }

            // Lấy thông tin phường/xã
            int? maPhuongXa = null;
            string? tenPhuongXa = null;
            if (cboPhuongXa.SelectedItem is WardItem wItem)
            {
                maPhuongXa = wItem.Code;
                tenPhuongXa = wItem.Name;
            }

            // Ưu tiên nhập tay nếu có gõ tay
            if (!string.IsNullOrWhiteSpace(txtPhuongXaManual.Text))
            {
                tenPhuongXa = txtPhuongXaManual.Text.Trim();
            }

            var khach = new KhachThue
            {
                HoTen = txtHoTen.Text.Trim(),
                GioiTinh = radNam.Checked ? "Nam" : "Nữ",
                NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                MaPhong = roomId,
                MaTinh = maTinh,
                TenTinh = tenTinh,
                MaPhuongXa = maPhuongXa,
                TenPhuongXa = tenPhuongXa,
                DaDangKyTamTru = chkTamTru.Checked
            };

            context.KhachThues.Add(khach);

            // Cập nhật trạng thái phòng sang "Đang thuê"
            var phong = context.PhongTros.Find(roomId);
            if (phong != null) phong.TinhTrang = "Đang thuê";

            context.SaveChanges();

            Log.Information("Thêm khách thuê thành công: MaKhach={MaKhach}, HoTen={HoTen}, Phong={Phong}", khach.MaKhach, khach.HoTen, roomId);
            MessageBox.Show("Thêm khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
            LoadRooms();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm khách thuê.");
            MessageBox.Show("Lỗi khi lưu dữ liệu vào CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaKhach <= 0)
        {
            MessageBox.Show("Vui lòng chọn khách cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput()) return;

        try
        {
            using var context = new QLNhaTroContext();
            var khach = context.KhachThues.Find(_selectedMaKhach);
            if (khach == null)
            {
                MessageBox.Show("Khách thuê không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoiForm();
                LoadData();
                return;
            }

            int oldRoomId = khach.MaPhong;
            int newRoomId = (int)cboPhong.SelectedValue!;

            khach.HoTen = txtHoTen.Text.Trim();
            khach.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
            khach.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value.Date);
            khach.SoDienThoai = txtSoDienThoai.Text.Trim();
            khach.MaPhong = newRoomId;

            if (cboTinh.SelectedItem is ProvinceItem pItem)
            {
                khach.MaTinh = pItem.Code;
                khach.TenTinh = pItem.Name;
            }

            if (cboPhuongXa.SelectedItem is WardItem wItem)
            {
                khach.MaPhuongXa = wItem.Code;
                khach.TenPhuongXa = wItem.Name;
            }

            if (!string.IsNullOrWhiteSpace(txtPhuongXaManual.Text))
            {
                khach.TenPhuongXa = txtPhuongXaManual.Text.Trim();
            }

            khach.DaDangKyTamTru = chkTamTru.Checked;

            context.SaveChanges();

            // Cập nhật tình trạng của phòng cũ và mới
            UpdateRoomStatus(context, oldRoomId);
            UpdateRoomStatus(context, newRoomId);
            context.SaveChanges();

            Log.Information("Cập nhật khách thuê MaKhach={MaKhach} thành công.", khach.MaKhach);
            MessageBox.Show("Cập nhật thông tin khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
            LoadRooms();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi cập nhật khách thuê MaKhach={MaKhach}", _selectedMaKhach);
            MessageBox.Show("Lỗi khi cập nhật dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaKhach <= 0)
        {
            MessageBox.Show("Vui lòng chọn khách cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var res = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách '{txtHoTen.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (res == DialogResult.Yes)
        {
            try
            {
                using var context = new QLNhaTroContext();
                var khach = context.KhachThues.Find(_selectedMaKhach);
                if (khach != null)
                {
                    int roomId = khach.MaPhong;
                    context.KhachThues.Remove(khach);
                    context.SaveChanges();

                    // Kiểm tra nếu phòng không còn ai thì chuyển về "Trống"
                    UpdateRoomStatus(context, roomId);
                    context.SaveChanges();

                    Log.Information("Xóa khách thuê MaKhach={MaKhach} thành công.", _selectedMaKhach);
                    MessageBox.Show("Đã xóa khách thuê thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LamMoiForm();
                LoadRooms();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khách thuê MaKhach={MaKhach}", _selectedMaKhach);
                MessageBox.Show("Lỗi khi xóa dữ liệu trong CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        LamMoiForm();
    }

    private void LamMoiForm()
    {
        _selectedMaKhach = -1;
        txtHoTen.Clear();
        radNam.Checked = true;
        dtpNgaySinh.Value = new DateTime(2000, 1, 1);
        txtSoDienThoai.Clear();
        txtPhuongXaManual.Clear();
        chkTamTru.Checked = false;

        btnThem.Enabled = true;
        btnSua.Enabled = false;
        btnXoa.Enabled = false;

        dgvKhachThue.ClearSelection();
    }

    private void FilterChanged(object? sender, EventArgs e)
    {
        LoadData();
    }

    private void btnBoLoc_Click(object sender, EventArgs e)
    {
        txtTimTenSDT.Clear();
        cboLocPhong.SelectedIndex = 0;
        cboLocTinh.SelectedIndex = 0;
        LoadData();
    }

    private void btnGayLoiThu_Click(object sender, EventArgs e)
    {
        // Cố tình ném Exception để kiểm tra cơ chế bắt lỗi toàn cục
        throw new InvalidOperationException("Đây là lỗi thử nghiệm để kiểm tra cơ chế bắt lỗi toàn cục (Global Exception Handler)!");
    }
}
