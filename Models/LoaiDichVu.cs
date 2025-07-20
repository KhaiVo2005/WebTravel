using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LoaiDichVu
{
    [Key]
    public Guid MaLoaiDV { get; set; }

    public required string TenDV { get; set; }
    public required decimal GiaDV { get; set; }
    public required string MoTa { get; set; }
    public required string Anh { get; set; }
    public required int TrangThai { get; set; }

    [ForeignKey("NhanVien")]
    public Guid MaNV { get; set; }
    public NhanVien? NhanVien { get; set; }
    [ForeignKey("DiaDiem")]
    public required Guid MaDD { get; set; }
    public DiaDiem? DiaDiem { get; set; }
}
