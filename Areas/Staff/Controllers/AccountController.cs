using Microsoft.AspNetCore.Mvc;
using WebTravel.Attribute;
using WebTravel.Data;

namespace WebTravel.Areas.Staff.Controllers
{
    [CheckStaff]
    [Area("Staff")]
    public class AccountController : Controller
    {
        private readonly TravelDbContext _context;

        public AccountController(TravelDbContext context)
        {
            _context = context;
        }

        // 👉 GET: /Staff/Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // 👉 POST: /Staff/Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var nv = _context.NhanViens
                .FirstOrDefault(n => n.TenDangNhap == username && n.MatKhau == password);

            if (nv != null)
            {
                HttpContext.Session.SetString("Username", nv.TenDangNhap);
                HttpContext.Session.SetString("FullName", nv.HoTen);
                HttpContext.Session.SetString("Role", "NhanVien");

                return RedirectToAction("Index", "Home"); // hoặc Trang chính nhân viên
            }

            ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu.";
            return View();
        }

        // 👉 Đăng xuất
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // 👉 GET: /Staff/Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // 👉 POST: /Staff/Account/Register
        [HttpPost]
        public IActionResult Register(NhanVien model)
        {
            // Kiểm tra trùng tên đăng nhập
            var existing = _context.NhanViens
                .FirstOrDefault(n => n.TenDangNhap == model.TenDangNhap);

            if (existing != null)
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại.";
                return View(model);
            }

            model.MaNV = Guid.NewGuid();
            _context.NhanViens.Add(model);
            _context.SaveChanges();

            // Auto login nếu bạn muốn
            HttpContext.Session.SetString("Username", model.TenDangNhap);
            HttpContext.Session.SetString("FullName", model.HoTen);
            HttpContext.Session.SetString("Role", "NhanVien");

            return RedirectToAction("Index", "Home");
        }

    }
}
