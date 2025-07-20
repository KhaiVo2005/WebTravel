using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class KhachHang_LoaiDichVu
{
    [Key]
    public Guid MaThue { get; set; }

    public int SoLuong { get; set; }
    public DateTime TuNgay { get; set; }
    public DateTime DenNgay { get; set; }

    [ForeignKey("DiaDiemTour")]
    public Guid MaDiaDiemTour { get; set; }
    public DiaDiemTour? DiaDiemTour { get; set; }
    public Guid MaLoaiDV { get; set; }

    public ICollection<DanhGiaDichVu> DanhGiaDichVus { get; set; } = new List<DanhGiaDichVu>();

}
