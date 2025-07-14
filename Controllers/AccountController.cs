using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using WebTravel.Data;

public class AccountController : Controller
{
    private readonly TravelDbContext _context;

    public AccountController(TravelDbContext context)
    {
        _context = context;
    }

    // 👉 Trang login (GET)
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var kh = _context.KhachHangs.FirstOrDefault(k => k.TenDangNhap == username && k.MatKhau == password);
        if (kh != null)
        {
            HttpContext.Session.SetString("Username", kh.TenDangNhap);
            HttpContext.Session.SetString("Role", "KhachHang");
            HttpContext.Session.SetString("FullName", kh.HoTen);
            return RedirectToAction("TrangChu", "Home");
        }

        ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(KhachHang model)
    {
        // Kiểm tra tên đăng nhập
        var existing = _context.KhachHangs.FirstOrDefault(k => k.TenDangNhap == model.TenDangNhap);
        if (existing != null)
        {
            ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại.");
            return View(model);
        }

        var kh = new KhachHang
        {
            MaKH = Guid.NewGuid(),
            HoTen = model.HoTen,
            TenDangNhap = model.TenDangNhap,
            MatKhau = model.MatKhau, 
            Email = model.Email,
            DiaChi = model.DiaChi,
            NgaySinh = model.NgaySinh,
            GioiTinh = model.GioiTinh,
            SoDienThoai = model.SoDienThoai,
            AnhDaiDien = "default.jpg" 
        };

        _context.KhachHangs.Add(kh);
        _context.SaveChanges();

        HttpContext.Session.SetString("Username", kh.TenDangNhap);
        HttpContext.Session.SetString("FullName", kh.HoTen);
        HttpContext.Session.SetString("Role", "KhachHang");

        return RedirectToAction("TrangChu", "Home");
    }
}
