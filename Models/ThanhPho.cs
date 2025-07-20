using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ThanhPho
{
    [Key]
    public Guid MaTP { get; set; }
    public required string TenThanhPho { get; set; }

    public ICollection<DiaDiem> DiaDiems { get; set; } = new List<DiaDiem>();
}
