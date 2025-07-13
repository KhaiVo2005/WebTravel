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
    public class LoaiDichVusController : Controller
    {
        private readonly TravelDbContext _context;

        public LoaiDichVusController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: CSKH/LoaiDichVus
        public async Task<IActionResult> Index()
        {
            var travelDbContext = _context.LoaiDichVus.Include(l => l.DiaDiem).Include(l => l.NhanVien);
            return View(await travelDbContext.ToListAsync());
        }

        // GET: CSKH/LoaiDichVus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiDichVu = await _context.LoaiDichVus
                .Include(l => l.DiaDiem)
                .Include(l => l.NhanVien)
                .FirstOrDefaultAsync(m => m.MaLoaiDV == id);
            if (loaiDichVu == null)
            {
                return NotFound();
            }

            return View(loaiDichVu);
        }

        // GET: CSKH/LoaiDichVus/Create
        public IActionResult Create()
        {
            ViewData["MaDD"] = new SelectList(_context.DiaDiems, "MaDD", "MaDD");
            ViewData["MaNV"] = new SelectList(_context.NhanViens, "MaNV", "MaNV");
            return View();
        }

        // POST: CSKH/LoaiDichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoaiDV,TenDV,GiaDV,MoTa,Anh,MaNV,MaDD")] LoaiDichVu loaiDichVu)
        {
            if (ModelState.IsValid)
            {
                loaiDichVu.MaLoaiDV = Guid.NewGuid();
                _context.Add(loaiDichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDD"] = new SelectList(_context.DiaDiems, "MaDD", "MaDD", loaiDichVu.MaDD);
            ViewData["MaNV"] = new SelectList(_context.NhanViens, "MaNV", "MaNV", loaiDichVu.MaNV);
            return View(loaiDichVu);
        }

        // GET: CSKH/LoaiDichVus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiDichVu = await _context.LoaiDichVus.FindAsync(id);
            if (loaiDichVu == null)
            {
                return NotFound();
            }
            ViewData["MaDD"] = new SelectList(_context.DiaDiems, "MaDD", "MaDD", loaiDichVu.MaDD);
            ViewData["MaNV"] = new SelectList(_context.NhanViens, "MaNV", "MaNV", loaiDichVu.MaNV);
            return View(loaiDichVu);
        }

        // POST: CSKH/LoaiDichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaLoaiDV,TenDV,GiaDV,MoTa,Anh,MaNV,MaDD")] LoaiDichVu loaiDichVu)
        {
            if (id != loaiDichVu.MaLoaiDV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiDichVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiDichVuExists(loaiDichVu.MaLoaiDV))
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
            ViewData["MaDD"] = new SelectList(_context.DiaDiems, "MaDD", "MaDD", loaiDichVu.MaDD);
            ViewData["MaNV"] = new SelectList(_context.NhanViens, "MaNV", "MaNV", loaiDichVu.MaNV);
            return View(loaiDichVu);
        }

        // GET: CSKH/LoaiDichVus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiDichVu = await _context.LoaiDichVus
                .Include(l => l.DiaDiem)
                .Include(l => l.NhanVien)
                .FirstOrDefaultAsync(m => m.MaLoaiDV == id);
            if (loaiDichVu == null)
            {
                return NotFound();
            }

            return View(loaiDichVu);
        }

        // POST: CSKH/LoaiDichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var loaiDichVu = await _context.LoaiDichVus.FindAsync(id);
            if (loaiDichVu != null)
            {
                _context.LoaiDichVus.Remove(loaiDichVu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiDichVuExists(Guid id)
        {
            return _context.LoaiDichVus.Any(e => e.MaLoaiDV == id);
        }
    }
}
