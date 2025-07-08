using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LoaiDichVu
{
    [Key]
    public Guid MaLoaiDV { get; set; }

    public string TenDV { get; set; }
    public decimal GiaDV { get; set; }
    public string MoTa { get; set; }
    public string Anh { get; set; }

    [ForeignKey("NhanVien")]
    public Guid MaNV { get; set; }
    public NhanVien NhanVien { get; set; }
    [ForeignKey("DiaDiem")]
    public Guid MaDD { get; set; }
    public DiaDiem DiaDiem { get; set; }
}
