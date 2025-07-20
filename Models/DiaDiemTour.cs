using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DiaDiemTour
{
    [Key]
    public Guid MaDiaDiemTour { get; set; }

    [ForeignKey("TourCaNhan")]
    public Guid MaTour { get; set; }
    public TourCaNhan? TourCaNhan { get; set; }
    [ForeignKey("DiaDiem")]
    public Guid MaDiaDiem { get; set; }
    public DiaDiem? DiaDiem { get; set; }

    public ICollection<KhachHang_LoaiDichVu> KhachHang_LoaiDichVus { get; set; } = new List<KhachHang_LoaiDichVu>();
}
