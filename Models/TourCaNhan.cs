using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TourCaNhan
{
    [Key]
    public Guid MaTour { get; set; }
    public string TenTour { get; set; }

    [ForeignKey("KhachHang")]
    public Guid MaKH { get; set; }
    public KhachHang KhachHang { get; set; }

    public ICollection<DiaDiemTour> DiaDiemTours { get; set; } = new List<DiaDiemTour>();
}
