using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class KhachHang
{
    [Key]
    public Guid MaKH { get; set; }
    public string HoTen { get; set; }
    public string TenDangNhap { get; set; }
    public string MatKhau { get; set; }
    public string Email { get; set; }
    public string DiaChi { get; set; }
    public DateTime NgaySinh { get; set; }
    public string GioiTinh { get; set; }
    public string SoDienThoai { get; set; }

    public ICollection<TourCaNhan> TourCaNhans { get; set; } = new List<TourCaNhan>();
    public ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();
}
