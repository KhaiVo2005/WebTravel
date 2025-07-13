using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTravel.Data;

namespace WebTravel.Areas.CSKH.Controllers
{
    [Area("CSKH")]
    public class HomeController : Controller
    {
        private readonly TravelDbContext _context;

        public HomeController(TravelDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TongKhachHang = await _context.KhachHangs.CountAsync();
            ViewBag.TongNhanVien = await _context.NhanViens.CountAsync();
            ViewBag.TongDichVu = await _context.LoaiDichVus.CountAsync();
            ViewBag.TongDiaDiem = await _context.DiaDiems.CountAsync();
            ViewBag.TongBaiViet = await _context.BaiDangs.CountAsync();
            ViewBag.TongThanhPho = await _context.ThanhPhos.CountAsync();

            // Truyền dữ liệu cho biểu đồ
            var chartData = new List<object>
            {
                new { Ten = "Khách hàng", SoLuong = ViewBag.TongKhachHang },
                new { Ten = "Nhân viên", SoLuong = ViewBag.TongNhanVien },
                new { Ten = "Bài viết", SoLuong = ViewBag.TongBaiViet },
                new { Ten = "Dịch vụ", SoLuong = ViewBag.TongDichVu },
                new { Ten = "Địa điểm", SoLuong = ViewBag.TongDiaDiem },
                new { Ten = "Thành phố", SoLuong = ViewBag.TongThanhPho }
            };

            ViewBag.ChartTongQuat = chartData;

            return View();
        }

    }
}
