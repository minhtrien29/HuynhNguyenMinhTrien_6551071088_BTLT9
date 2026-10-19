using ChiTieuApp.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Data;

namespace ChiTieuApp;

public partial class FormChiTieu : Form
{
    private int _selectedMaCT = -1;
    private readonly string[] _loaiChiList = new[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" };

    public FormChiTieu()
    {
        InitializeComponent();
    }

    private void FormChiTieu_Load(object sender, EventArgs e)
    {
        cboLoaiChi.Items.AddRange(_loaiChiList);
        if (cboLoaiChi.Items.Count > 0) cboLoaiChi.SelectedIndex = 0;

        cboLocLoaiChi.Items.Add("Tất cả");
        cboLocLoaiChi.Items.AddRange(_loaiChiList);
        cboLocLoaiChi.SelectedIndex = 0;

        dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
        dtpDenNgay.Value = DateTime.Today;

        LamMoiForm();
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            using var context = new QLChiTieuContext();
            var query = context.ChiTieus.AsNoTracking().AsQueryable();

            // Lọc theo nội dung
            string keyword = txtTimNoiDung.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.NoiDung.Contains(keyword));
            }

            // Lọc theo loại chi
            string loaiChi = cboLocLoaiChi.SelectedItem?.ToString() ?? "Tất cả";
            if (loaiChi != "Tất cả")
            {
                query = query.Where(c => c.LoaiChi == loaiChi);
            }

            // Lọc theo ngày
            DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
            DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);
            query = query.Where(c => c.NgayChi >= tuNgay && c.NgayChi <= denNgay);

            var list = query.OrderByDescending(c => c.NgayChi).ThenByDescending(c => c.MaCt).ToList();

            dgvChiTieu.DataSource = list.Select(c => new
            {
                c.MaCt,
                NgayChi = c.NgayChi.ToString("dd/MM/yyyy"),
                c.NoiDung,
                c.LoaiChi,
                SoTien = c.SoTien.ToString("#,##0") + " đ",
                c.GhiChu,
                RawSoTien = c.SoTien,
                RawNgayChi = c.NgayChi
            }).ToList();

            // Định dạng tiêu đề cột
            if (dgvChiTieu.Columns["MaCt"] != null) dgvChiTieu.Columns["MaCt"].HeaderText = "Mã";
            if (dgvChiTieu.Columns["NgayChi"] != null) dgvChiTieu.Columns["NgayChi"].HeaderText = "Ngày chi";
            if (dgvChiTieu.Columns["NoiDung"] != null) dgvChiTieu.Columns["NoiDung"].HeaderText = "Nội dung";
            if (dgvChiTieu.Columns["LoaiChi"] != null) dgvChiTieu.Columns["LoaiChi"].HeaderText = "Loại chi";
            if (dgvChiTieu.Columns["SoTien"] != null)
            {
                dgvChiTieu.Columns["SoTien"].HeaderText = "Số tiền";
                dgvChiTieu.Columns["SoTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvChiTieu.Columns["GhiChu"] != null) dgvChiTieu.Columns["GhiChu"].HeaderText = "Ghi chú";
            if (dgvChiTieu.Columns["RawSoTien"] != null) dgvChiTieu.Columns["RawSoTien"].Visible = false;
            if (dgvChiTieu.Columns["RawNgayChi"] != null) dgvChiTieu.Columns["RawNgayChi"].Visible = false;

            // Tính tổng tiền
            decimal tongChi = list.Sum(c => c.SoTien);
            lblTongChi.Text = $"Tổng chi: {tongChi:#,##0} đ";
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi nạp dữ liệu chi tiêu từ CSDL.");
            MessageBox.Show("Không thể tải danh sách chi tiêu. Vui lòng kiểm tra kết nối CSDL trong appsettings.json.", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && dgvChiTieu.Rows[e.RowIndex].DataBoundItem != null)
        {
            dynamic item = dgvChiTieu.Rows[e.RowIndex].DataBoundItem;
            _selectedMaCT = item.MaCt;
            DateOnly ngay = item.RawNgayChi;
            dtpNgayChi.Value = ngay.ToDateTime(TimeOnly.MinValue);
            txtNoiDung.Text = item.NoiDung;
            cboLoaiChi.SelectedItem = item.LoaiChi;
            numSoTien.Value = (decimal)item.RawSoTien;
            txtGhiChu.Text = item.GhiChu ?? string.Empty;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
        {
            MessageBox.Show("Vui lòng nhập nội dung chi tiêu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNoiDung.Focus();
            return false;
        }

        if (numSoTien.Value <= 0)
        {
            MessageBox.Show("Số tiền chi phải lớn hơn 0 đ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numSoTien.Focus();
            return false;
        }

        if (dtpNgayChi.Value.Date > DateTime.Today)
        {
            MessageBox.Show("Ngày chi không được lớn hơn ngày hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpNgayChi.Focus();
            return false;
        }

        return true;
    }

    private void btnThem_Click(object sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            using var context = new QLChiTieuContext();
            var ct = new ChiTieu
            {
                NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date),
                NoiDung = txtNoiDung.Text.Trim(),
                LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                SoTien = numSoTien.Value,
                GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
            };

            context.ChiTieus.Add(ct);
            context.SaveChanges();

            Log.Information("Thêm khoản chi tiêu thành công. MaCT: {MaCT}, Số tiền: {SoTien}, Nội dung: {NoiDung}", ct.MaCt, ct.SoTien, ct.NoiDung);
            MessageBox.Show("Thêm khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi thêm khoản chi tiêu mới.");
            MessageBox.Show("Đã xảy ra lỗi khi thêm dữ liệu vào CSDL. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSua_Click(object sender, EventArgs e)
    {
        if (_selectedMaCT <= 0)
        {
            MessageBox.Show("Vui lòng chọn dòng chi tiêu cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateInput()) return;

        try
        {
            using var context = new QLChiTieuContext();
            var ct = context.ChiTieus.Find(_selectedMaCT);
            if (ct == null)
            {
                MessageBox.Show("Khoản chi tiêu không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LamMoiForm();
                LoadData();
                return;
            }

            ct.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value.Date);
            ct.NoiDung = txtNoiDung.Text.Trim();
            ct.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
            ct.SoTien = numSoTien.Value;
            ct.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

            context.SaveChanges();

            Log.Information("Cập nhật khoản chi tiêu thành công. MaCT: {MaCT}, Số tiền: {SoTien}", ct.MaCt, ct.SoTien);
            MessageBox.Show("Cập nhật khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoiForm();
            LoadData();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi cập nhật chi tiêu MaCT: {MaCT}", _selectedMaCT);
            MessageBox.Show("Đã xảy ra lỗi khi cập nhật CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnXoa_Click(object sender, EventArgs e)
    {
        if (_selectedMaCT <= 0)
        {
            MessageBox.Show("Vui lòng chọn dòng chi tiêu cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa khoản chi '{txtNoiDung.Text}' (Mã: {_selectedMaCT}) không?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (dialogResult == DialogResult.Yes)
        {
            try
            {
                using var context = new QLChiTieuContext();
                var ct = context.ChiTieus.Find(_selectedMaCT);
                if (ct != null)
                {
                    context.ChiTieus.Remove(ct);
                    context.SaveChanges();
                    Log.Information("Xóa khoản chi tiêu thành công. MaCT: {MaCT}", _selectedMaCT);
                    MessageBox.Show("Đã xóa khoản chi tiêu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LamMoiForm();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khoản chi tiêu MaCT: {MaCT}", _selectedMaCT);
                MessageBox.Show("Đã xảy ra lỗi khi xóa dữ liệu trong CSDL.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void btnLamMoi_Click(object sender, EventArgs e)
    {
        LamMoiForm();
    }

    private void LamMoiForm()
    {
        _selectedMaCT = -1;
        dtpNgayChi.Value = DateTime.Today;
        txtNoiDung.Clear();
        if (cboLoaiChi.Items.Count > 0) cboLoaiChi.SelectedIndex = 0;
        numSoTien.Value = 0;
        txtGhiChu.Clear();

        btnThem.Enabled = true;
        btnSua.Enabled = false;
        btnXoa.Enabled = false;

        dgvChiTieu.ClearSelection();
    }

    private void FilterChanged(object? sender, EventArgs e)
    {
        LoadData();
    }

    private void btnBoLoc_Click(object sender, EventArgs e)
    {
        txtTimNoiDung.Clear();
        cboLocLoaiChi.SelectedIndex = 0;
        dtpTuNgay.Value = DateTime.Today.AddMonths(-1);
        dtpDenNgay.Value = DateTime.Today;
        LoadData();
    }
}
