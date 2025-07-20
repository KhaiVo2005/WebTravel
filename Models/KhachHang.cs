using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class KhachHang
{
    [Key]
    public Guid MaKH { get; set; }
    public required string HoTen { get; set; }
    public required string TenDangNhap { get; set; }
    public required string MatKhau { get; set; }
    public required string Email { get; set; }
    public required string DiaChi { get; set; }
    public DateTime NgaySinh { get; set; }
    public required string GioiTinh { get; set; }
    public required string SoDienThoai { get; set; }
    public string? AnhDaiDien { get; set; }

    public ICollection<TourCaNhan> TourCaNhans { get; set; } = new List<TourCaNhan>();
    public ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();
}
