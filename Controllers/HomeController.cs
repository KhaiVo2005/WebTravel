using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTravel.Data;
using WebTravel.Models.Models;

namespace WebTravel.Controllers
{
    public class HomeController : Controller
    {
        TravelDbContext _context;

        public HomeController(TravelDbContext context)
        {
            _context = context;
        }

        public IActionResult TrangChu()
        {
            var diaDiems = _context.DiaDiems.Take(5).ToList();
            var baiDangs = _context.BaiDangs.OrderByDescending(b => b.MaBaiDang).Take(5).ToList();
            var dichVus = _context.LoaiDichVus.OrderByDescending(d => d.GiaDV).Take(5).ToList();

            var vm = new HomeViewModel
            {
                DiaDiems = diaDiems,
                BaiDangs = baiDangs,
                DichVus = dichVus
            };

            return View(vm);
        }
    }
}
