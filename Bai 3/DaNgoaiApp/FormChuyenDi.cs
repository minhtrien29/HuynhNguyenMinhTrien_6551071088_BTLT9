using System.Globalization;
using DaNgoaiApp.Models;
using DaNgoaiApp.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DaNgoaiApp;

public partial class FormChuyenDi : Form
{
    private int _selectedMaChuyen = -1;
    private readonly string[] _phuongTienVi = new[] { "Xe máy", "Ô tô", "Xe khách", "Tàu hỏa" };
    private readonly string[] _phuongTienEn = new[] { "Motorbike", "Car", "Coach/Bus", "Train" };
    private string _currentLang = "vi";

    public FormChuyenDi()
    {
        InitializeComponent();
    }

    private void FormChuyenDi_Load(object sender, EventArgs e)
    {
        dtpTuNgay.Value = DateTime.Today;
        dtpDenNgay.Value = DateTime.Today.AddDays(30);

        _currentLang = SettingsManager.Current.Language ?? "vi";
        if (_currentLang == "en")
        {
            radTiengAnh.Checked = true;
        }
        else
        {
            radTiengViet.Checked = true;
        }

        ApplyLanguage();
        LamMoiForm();
        LoadData();
    }

    private void LanguageChanged(object sender, EventArgs e)
    {
        string newLang = radTiengAnh.Checked ? "en" : "vi";
        if (newLang != _currentLang)
        {
            _currentLang = newLang;
            SettingsManager.SaveSettings(_currentLang);
            ApplyLanguage();
            LoadData();
        }
    }

    private void ApplyLanguage()
    {
        bool isVi = _currentLang == "vi";
        CultureInfo culture = isVi ? new CultureInfo("vi-VN") : new CultureInfo("en-US");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        // Tiêu đề form & GroupBoxes
        this.Text = isVi ? "Kế hoạch dã ngoại & Dự báo thời tiết" : "Picnic & Travel Planner & Weather Forecast";
        grpNgonNgu.Text = isVi ? "Ngôn ngữ / Language" : "Language / Ngôn ngữ";
        grpThongTin.Text = isVi ? "Thông tin chuyến đi" : "Trip Information";
        grpTimKiem.Text = isVi ? "Tìm kiếm & Lọc" : "Search & Filter";
        grpThoiTiet.Text = isVi ? "Dự báo thời tiết (Open-Meteo API)" : "Weather Forecast (Open-Meteo API)";

        // Controls thông tin
        lblTenChuyen.Text = isVi ? "Tên chuyến (*):" : "Trip Name (*):";
        lblDiaDiem.Text = isVi ? "Địa điểm (*):" : "Destination (*):";
        lblNgayDi.Text = isVi ? "Ngày đi:" : "Departure:";
        lblSoNguoi.Text = isVi ? "Số người:" : "People:";
        lblNganSach.Text = isVi ? "Ngân sách:" : "Budget:";
        lblPhuongTien.Text = isVi ? "Phương tiện:" : "Transport:";
        chkDaHoanThanh.Text = isVi ? "Đã hoàn thành" : "Completed";
        lblGhiChu.Text = isVi ? "Ghi chú:" : "Notes:";

        // Nút CRUD
        btnThem.Text = isVi ? "Thêm" : "Add";
        btnSua.Text = isVi ? "Sửa" : "Edit";
        btnXoa.Text = isVi ? "Xóa" : "Delete";
        btnLamMoi.Text = isVi ? "Làm mới" : "Reset";

        // Controls tìm kiếm
        lblTimTenDiaDiem.Text = isVi ? "Tên / Địa điểm:" : "Name / Place:";
        chkChuaHoanThanh.Text = isVi ? "Chỉ hiện chuyến chưa hoàn thành" : "Only uncompleted trips";
        lblTuNgay.Text = isVi ? "Từ ngày:" : "From:";
        lblDenNgay.Text = isVi ? "Đến ngày:" : "To:";
        btnBoLoc.Text = isVi ? "Bỏ lọc" : "Clear Filter";

        // Phương tiện trong combobox
        int selectedIndex = cboPhuongTien.SelectedIndex;
        cboPhuongTien.Items.Clear();
        cboPhuongTien.Items.AddRange(isVi ? _phuongTienVi : _phuongTienEn);
        if (selectedIndex >= 0 && selectedIndex < cboPhuongTien.Items.Count)
            cboPhuongTien.SelectedIndex = selectedIndex;
        else if (cboPhuongTien.Items.Count > 0)
            cboPhuongTien.SelectedIndex = 0;

        btnXemThoiTiet.Text = isVi ? "⛅ Xem thời tiết" : "⛅ View Weather";
    }

    private void LoadData()
    {
        try
        {
            using var context = new QLDaNgoaiContext();
            var query = context.ChuyenDis.AsNoTracking().AsQueryable();

            string keyword = txtTimTenDiaDiem.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.TenChuyen.Contains(keyword) || c.DiaDiem.Contains(keyword));
            }

            if (chkChuaHoanThanh.Checked)
            {
                query = query.Where(c => !c.DaHoanThanh);
            }

            DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
            query = query.Where(c => c.NgayDi >= tuNgay && c.NgayDi <= denNgay);

            var list = query.OrderBy(c => c.NgayDi).ToList();
            bool isVi = _currentLang == "vi";

            dgvChuyenDi.DataSource = list.Select(c => new
            {
                c.MaChuyen,
                c.TenChuyen,
                c.DiaDiem,
                NgayDi = c.NgayDi.ToString(isVi ? "dd/MM/yyyy" : "yyyy-MM-dd"),
                c.SoNguoi,
                NganSach = c.NganSach.ToString("#,##0") + (isVi ? " đ" : " VND"),
                c.PhuongTien,
                c.DaHoanThanh,
                c.GhiChu,
                RawNgayDi = c.NgayDi,
                RawNganSach = c.NganSach
            }).ToList();

            // Đổi HeaderText lưới theo ngôn ngữ
            if (dgvChuyenDi.Columns["MaChuyen"] != null) dgvChuyenDi.Columns["MaChuyen"].HeaderText = isVi ? "Mã" : "ID";
            if (dgvChuyenDi.Columns["TenChuyen"] != null) dgvChuyenDi.Columns["TenChuyen"].HeaderText = isVi ? "Tên chuyến" : "Trip Name";
            if (dgvChuyenDi.Columns["DiaDiem"] != null) dgvChuyenDi.Columns["DiaDiem"].HeaderText = isVi ? "Địa điểm" : "Destination";
            if (dgvChuyenDi.Columns["NgayDi"] != null) dgvChuyenDi.Columns["NgayDi"].HeaderText = isVi ? "Ngày đi" : "Departure Date";
            if (dgvChuyenDi.Columns["SoNguoi"] != null) dgvChuyenDi.Columns["SoNguoi"].HeaderText = isVi ? "Số người" : "People";
            if (dgvChuyenDi.Columns["NganSach"] != null)
            {
                dgvChuyenDi.Columns["NganSach"].HeaderText = isVi ? "Ngân sách" : "Budget";
                dgvChuyenDi.Columns["NganSach"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvChuyenDi.Columns["PhuongTien"] != null) dgvChuyenDi.Columns["PhuongTien"].HeaderText = isVi ? "Phương tiện" : "Transport";
            if (dgvChuyenDi.Columns["DaHoanThanh"] != null) dgvChuyenDi.Columns["DaHoanThanh"].HeaderText = isVi ? "Xong" : "Done";
            if (dgvChuyenDi.Columns["GhiChu"] != null) dgvChuyenDi.Columns["GhiChu"].HeaderText = isVi ? "Ghi chú" : "Notes";

            if (dgvChuyenDi.Columns["RawNgayDi"] != null) dgvChuyenDi.Columns["RawNgayDi"].Visible = false;
            if (dgvChuyenDi.Columns["RawNganSach"] != null) dgvChuyenDi.Columns["RawNganSach"].Visible = false;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp danh sách chuyến đi.");
            MessageBox.Show(_currentLang == "vi" ? "Lỗi tải dữ liệu CSDL." : "Database error loading trips.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvChuyenDi_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvChuyenDi.Rows[e.RowIndex].DataBoundItem != null)
        {
            dynamic item = dgvChuyenDi.Rows[e.RowIndex].DataBoundItem;
            _selectedMaChuyen = item.MaChuyen;
            txtTenChuyen.Text = item.TenChuyen;
            txtDiaDiem.Text = item.DiaDiem;

            DateOnly nd = item.RawNgayDi;
            dtpNgayDi.Value = nd.ToDateTime(TimeOnly.MinValue);
            numSoNguoi.Value = (int)item.SoNguoi;
            numNganSach.Value = (decimal)item.RawNganSach;

            string pt = item.PhuongTien;
            cboPhuongTien.SelectedItem = pt;
            chkDaHoanThanh.Checked = item.DaHoanThanh;
            txtGhiChu.Text = item.GhiChu ?? string.Empty;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            // Tự động xem thời tiết cho dòng được chọn
            btnXemThoiTiet_Click(sender, e);
        }
    }

    private bool ValidateInput()
    {
        bool isVi = _currentLang == "vi";
        if (string.IsNullOrWhiteSpace(txtTenChuyen.Text))
        {
            MessageBox.Show(isVi ? "Vui lòng nhập tên chuyến đi!" : "Please enter trip name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTenChuyen.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
        {
            MessageBox.Show(isVi ? "Vui lòng nhập địa điểm!" : "Please enter destination!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDiaDiem.Focus();
            return false;
        }

        if (btnThem.Enabled && dtpNgayDi.Value.Date < DateTime.Today)
        {
            MessageBox.Show(isVi ? "Ngày đi không được nhỏ hơn ngày hôm nay khi thêm mới!" : "Departure date cannot be in the past!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpNgayDi.Focus();
            return false;
        }

        if (numSoNguoi.Value < 1)
        {
            MessageBox.Show(isVi ? "Số người phải lớn hơn hoặc bằng 1!" : "Number of people must be at least 1!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numSoNguoi.Focus();
            return false;
        }

        if (numNganSach.Value < 0)
        {
            MessageBox.Show(isVi ? "Ngân sách không được âm!" : "Budget cannot be negative!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numNganSach.Focus();
            return false;
        }

        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            using var context = new QLDaNgoaiContext();
            var cd = new ChuyenDi
            {
                TenChuyen = txtTenChuyen.Text.Trim(),
                DiaDiem = txtDiaDiem.Text.Trim(),
                NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date),
                SoNguoi = (int)numSoNguoi.Value,
                NganSach = numNganSach.Value,
                PhuongTien = cboPhuongTien.SelectedItem?.ToString() ?? "Xe máy",
                DaHoanThanh = chkDaHoanThanh.Checked,
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
            };

            context.ChuyenDis.Add(cd);
            context.SaveChanges();

            Log.Information("Thêm chuyến đi MaChuyen={MaChuyen}, Ten={TenChuyen}", cd.MaChuyen, cd.TenChuyen);
            MessageBox.Show(_currentLang == "vi" ? "Thêm chuyến đi thành công!" : "Trip added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm chuyến đi.");
            MessageBox.Show(_currentLang == "vi" ? "Lỗi lưu CSDL." : "Error saving to database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaChuyen <= 0) return;
        if (!ValidateInput()) return;

        try
        {
            using var context = new QLDaNgoaiContext();
            var cd = context.ChuyenDis.Find(_selectedMaChuyen);
            if (cd == null) return;

            cd.TenChuyen = txtTenChuyen.Text.Trim();
            cd.DiaDiem = txtDiaDiem.Text.Trim();
            cd.NgayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
            cd.SoNguoi = (int)numSoNguoi.Value;
            cd.NganSach = numNganSach.Value;
            cd.PhuongTien = cboPhuongTien.SelectedItem?.ToString() ?? "Xe máy";
            cd.DaHoanThanh = chkDaHoanThanh.Checked;
            cd.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

            context.SaveChanges();

            Log.Information("Cập nhật chuyến đi MaChuyen={MaChuyen}", cd.MaChuyen);
            MessageBox.Show(_currentLang == "vi" ? "Cập nhật thành công!" : "Trip updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi cập nhật chuyến đi MaChuyen={MaChuyen}", _selectedMaChuyen);
            MessageBox.Show(_currentLang == "vi" ? "Lỗi cập nhật CSDL." : "Error updating database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaChuyen <= 0) return;

        bool isVi = _currentLang == "vi";
        var res = MessageBox.Show(isVi ? $"Bạn có muốn xóa chuyến '{txtTenChuyen.Text}'?" : $"Are you sure to delete '{txtTenChuyen.Text}'?",
            isVi ? "Xác nhận xóa" : "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (res == DialogResult.Yes)
        {
            try
            {
                using var context = new QLDaNgoaiContext();
                var cd = context.ChuyenDis.Find(_selectedMaChuyen);
                if (cd != null)
                {
                    context.ChuyenDis.Remove(cd);
                    context.SaveChanges();
                    Log.Information("Xóa chuyến đi MaChuyen={MaChuyen}", _selectedMaChuyen);
                }

                LamMoiForm();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa chuyến đi MaChuyen={MaChuyen}", _selectedMaChuyen);
            }
        }
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        LamMoiForm();
    }

    private void LamMoiForm()
    {
        _selectedMaChuyen = -1;
        txtTenChuyen.Clear();
        txtDiaDiem.Clear();
        dtpNgayDi.Value = DateTime.Today;
        numSoNguoi.Value = 1;
        numNganSach.Value = 1000000;
        if (cboPhuongTien.Items.Count > 0) cboPhuongTien.SelectedIndex = 0;
        chkDaHoanThanh.Checked = false;
        txtGhiChu.Clear();

        btnThem.Enabled = true;
        btnSua.Enabled = false;
        btnXoa.Enabled = false;

        lblIconMoTa.Text = _currentLang == "vi" ? "Chọn chuyến đi để tra cứu" : "Select a trip to check forecast";
        lblNhietDo.Text = _currentLang == "vi" ? "Nhiệt độ: --" : "Temperature: --";
        lblXacSuatMua.Text = _currentLang == "vi" ? "Xác suất mưa: --" : "Precipitation: --";
        pnlCanhBao.Visible = false;

        dgvChuyenDi.ClearSelection();
    }

    private void FilterChanged(object? sender, EventArgs e)
    {
        LoadData();
    }

    private void btnBoLoc_Click(object sender, EventArgs e)
    {
        txtTimTenDiaDiem.Clear();
        chkChuaHoanThanh.Checked = false;
        dtpTuNgay.Value = DateTime.Today;
        dtpDenNgay.Value = DateTime.Today.AddDays(30);
        LoadData();
    }

    private async void btnXemThoiTiet_Click(object sender, EventArgs e)
    {
        string diaDiem = txtDiaDiem.Text.Trim();
        if (string.IsNullOrEmpty(diaDiem))
        {
            return;
        }

        bool isVi = _currentLang == "vi";
        btnXemThoiTiet.Enabled = false;
        prgLoading.Visible = true;
        pnlCanhBao.Visible = false;
        lblIconMoTa.Text = isVi ? "Đang lấy dự báo thời tiết..." : "Fetching weather forecast...";

        try
        {
            DateOnly ngayDi = DateOnly.FromDateTime(dtpNgayDi.Value.Date);
            var result = await WeatherService.GetForecastAsync(diaDiem, ngayDi);

            if (!result.Success)
            {
                lblIconMoTa.Text = isVi ? "⚠️ Không có dữ liệu" : "⚠️ No forecast data";
                lblNhietDo.Text = result.Message;
                lblXacSuatMua.Text = string.Empty;
                return;
            }

            lblIconMoTa.Text = isVi ? result.WeatherDescVi : result.WeatherDescEn;
            lblNhietDo.Text = (isVi ? "Nhiệt độ: " : "Temperature: ") + $"{result.TempMin:0.#}°C - {result.TempMax:0.#}°C";
            lblXacSuatMua.Text = (isVi ? "Xác suất mưa: " : "Rain probability: ") + $"{result.RainProb}%";

            if (!string.IsNullOrEmpty(result.WarningVi))
            {
                pnlCanhBao.Visible = true;
                lblCanhBao.Text = isVi ? result.WarningVi : result.WarningEn;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi nút xem thời tiết.");
            lblIconMoTa.Text = isVi ? "⚠️ Lỗi khi lấy thời tiết" : "⚠️ Weather error";
        }
        finally
        {
            btnXemThoiTiet.Enabled = true;
            prgLoading.Visible = false;
        }
    }
}
