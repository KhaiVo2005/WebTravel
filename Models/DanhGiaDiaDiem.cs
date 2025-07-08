using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DanhGiaDiaDiem
{
    [Key]
    public Guid MaDG { get; set; }

    public string Comment { get; set; }
    public int SoSao { get; set; }
    public string AnhVideo { get; set; }
    public Guid MaKH { get; set; } 

    [ForeignKey("DiaDiem")]
    public Guid MaDD { get; set; }
    public DiaDiem DiaDiem { get; set; }
}
