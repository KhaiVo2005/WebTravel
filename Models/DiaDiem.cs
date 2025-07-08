using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DiaDiem
{
    [Key]
    public Guid MaDD { get; set; }

    public string TenDiaDiem { get; set; }
    public string MoTa { get; set; }
    public string Anh { get; set; }

    [ForeignKey("ThanhPho")]
    public Guid MaTP { get; set; }
    public ThanhPho ThanhPho { get; set; }

    public ICollection<DanhGiaDiaDiem> DanhGiaDiaDiems { get; set; } = new List<DanhGiaDiaDiem>();
    public ICollection<LoaiDichVu> LoaiDichVus { get; set; } = new List<LoaiDichVu>();
    public ICollection<DiaDiemTour> DiaDiemTours { get; set; } = new List<DiaDiemTour>();
}
