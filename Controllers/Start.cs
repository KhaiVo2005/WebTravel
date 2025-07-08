using Microsoft.AspNetCore.Mvc;
using WebTravel.Data;

namespace WebTravel.Controllers
{
    public class Start : Controller
    {
        TravelDbContext _context;

        public Start(TravelDbContext context)
        {
            _context = context;
        }

        // GET: /Auth/Register
        public IActionResult Register() => View();

        // POST: /Auth/Register
        [HttpPost]
        public IActionResult Register(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra trùng username
                if (_context.KhachHangs.Any(k => k.TenDangNhap == kh.TenDangNhap))
                {
                    ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại");
                    return View(kh);
                }

                kh.MaKH = Guid.NewGuid();
                _context.KhachHangs.Add(kh);
                _context.SaveChanges();
                ViewBag.SuccessMessage = "Đăng ký thành công!";
                return View();
            }
            return View(kh);
        }

        // GET: /Auth/Login
        public IActionResult Login() => View();

        // POST: /Auth/Login
        [HttpPost]
        public IActionResult Login(string tenDangNhap, string matKhau)
        {
            var kh = _context.KhachHangs.FirstOrDefault(k =>
                k.TenDangNhap == tenDangNhap && k.MatKhau == matKhau);

            if (kh != null)
            {
                HttpContext.Session.SetString("UserId", kh.MaKH.ToString());
                HttpContext.Session.SetString("UserName", kh.HoTen);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ThongBao = "Sai tên đăng nhập hoặc mật khẩu";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
