using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NhanVien
{
    [Key]
    public Guid MaNV { get; set; }
    public string HoTen { get; set; }
    public string TenDangNhap { get; set; }
    public string MatKhau { get; set; }
    public string Email { get; set; }
    public string SoDienThoai { get; set; }
    public string DiaChi { get; set; }

    public ICollection<LoaiDichVu> LoaiDichVus { get; set; } = new List<LoaiDichVu>();
}
