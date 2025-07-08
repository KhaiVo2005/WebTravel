using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CmtBaiDang
{
    [Key]
    public Guid MaDanhGia { get; set; }

    public string NoiDung { get; set; }
    public string AnhVideo { get; set; }

    [ForeignKey("BaiDang")]
    public Guid MaBaiDang { get; set; }
    public BaiDang BaiDang { get; set; }
    public Guid MaKH { get; set; }
}
