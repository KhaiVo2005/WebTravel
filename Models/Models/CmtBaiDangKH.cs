namespace WebTravel.Models.Models
{
    public class CmtBaiDangKH
    {
        public BaiDang BaiDang { get; set; }
        public KhachHang NguoiDang { get; set; }
        public List<CmtBaiDang> BinhLuans { get; set; }

        // Danh sách người bình luận theo MaKH
        public Dictionary<Guid, KhachHang> DanhSachNguoiBinhLuan { get; set; } = new();
    }
}
