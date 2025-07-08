namespace WebTravel.Models.Models
{
    public class HomeViewModel
    {
        public List<DiaDiem> DiaDiems { get; set; } = new List<DiaDiem>();
        public List<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();
        public List<LoaiDichVu> DichVus { get; set; } = new List<LoaiDichVu>();
    }
}
