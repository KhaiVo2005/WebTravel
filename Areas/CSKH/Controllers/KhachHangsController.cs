using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTravel.Data;

namespace WebTravel.Areas.CSKH.Controllers
{
    [Area("CSKH")]
    public class KhachHangsController : Controller
    {
        private readonly TravelDbContext _context;

        public KhachHangsController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: CSKH/KhachHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.KhachHangs.ToListAsync());
        }

        // GET: CSKH/KhachHangs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.MaKH == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: CSKH/KhachHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CSKH/KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKH,HoTen,TenDangNhap,MatKhau,Email,DiaChi,NgaySinh,GioiTinh,SoDienThoai,AnhDaiDien")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.MaKH = Guid.NewGuid();
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        // GET: CSKH/KhachHangs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: CSKH/KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaKH,HoTen,TenDangNhap,MatKhau,Email,DiaChi,NgaySinh,GioiTinh,SoDienThoai,AnhDaiDien")] KhachHang khachHang)
        {
            if (id != khachHang.MaKH)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.MaKH))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(khachHang);
        }

        // GET: CSKH/KhachHangs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .FirstOrDefaultAsync(m => m.MaKH == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: CSKH/KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHangs.Remove(khachHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(Guid id)
        {
            return _context.KhachHangs.Any(e => e.MaKH == id);
        }
    }
}
