using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NhanVien
{
    [Key]
    public Guid MaNV { get; set; }
    public required string HoTen { get; set; }
    public required string TenDangNhap { get; set; }
    public required string MatKhau { get; set; }
    public required string Email { get; set; }
    public required string SoDienThoai { get; set; }
    public required string DiaChi { get; set; }

    public ICollection<LoaiDichVu> LoaiDichVus { get; set; } = new List<LoaiDichVu>();
}
