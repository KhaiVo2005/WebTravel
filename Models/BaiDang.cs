using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BaiDang
{
    [Key]
    public Guid MaBaiDang { get; set; }

    public string? NoiDung { get; set; }
    public string? AnhVideo { get; set; }
    public int? LuotLike { get; set; }

    [ForeignKey("KhachHang")]
    public Guid? MaKH { get; set; }

    public KhachHang? KhachHang { get; set; }

    public ICollection<CmtBaiDang> CmtBaiDangs { get; set; } = new List<CmtBaiDang>();
}
