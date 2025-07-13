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
    public class NhanViensController : Controller
    {
        private readonly TravelDbContext _context;

        public NhanViensController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: CSKH/NhanViens
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhanViens.ToListAsync());
        }

        // GET: CSKH/NhanViens/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // GET: CSKH/NhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CSKH/NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,HoTen,TenDangNhap,MatKhau,Email,SoDienThoai,DiaChi")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.MaNV = Guid.NewGuid();
                _context.Add(nhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVien);
        }

        // GET: CSKH/NhanViens/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }
            return View(nhanVien);
        }

        // POST: CSKH/NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaNV,HoTen,TenDangNhap,MatKhau,Email,SoDienThoai,DiaChi")] NhanVien nhanVien)
        {
            if (id != nhanVien.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienExists(nhanVien.MaNV))
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
            return View(nhanVien);
        }

        // GET: CSKH/NhanViens/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVien = await _context.NhanViens
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return View(nhanVien);
        }

        // POST: CSKH/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var nhanVien = await _context.NhanViens.FindAsync(id);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienExists(Guid id)
        {
            return _context.NhanViens.Any(e => e.MaNV == id);
        }
    }
}
