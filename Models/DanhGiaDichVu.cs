using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DanhGiaDichVu
{
    [Key]
    public Guid MaDanhGia { get; set; }

    public decimal? DanhGia { get; set; }
    public int? SoSao { get; set; }
    public string? AnhVideo { get; set; }

    [ForeignKey("KhachHang_LoaiDichVu")]
    public Guid MaThue { get; set; }
    public KhachHang_LoaiDichVu? KhachHang_LoaiDichVu { get; set; }
}
