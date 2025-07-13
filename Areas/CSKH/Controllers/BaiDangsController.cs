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
    public class BaiDangsController : Controller
    {
        private readonly TravelDbContext _context;

        public BaiDangsController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: CSKH/BaiDangs
        public async Task<IActionResult> Index()
        {
            var travelDbContext = _context.BaiDangs.Include(b => b.KhachHang);
            return View(await travelDbContext.ToListAsync());
        }

        // GET: CSKH/BaiDangs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiDang = await _context.BaiDangs
                .Include(b => b.KhachHang)
                .FirstOrDefaultAsync(m => m.MaBaiDang == id);
            if (baiDang == null)
            {
                return NotFound();
            }

            return View(baiDang);
        }

        // GET: CSKH/BaiDangs/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.KhachHangs, "MaKH", "MaKH");
            return View();
        }

        // POST: CSKH/BaiDangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBaiDang,NoiDung,AnhVideo,LuotLike,MaKH")] BaiDang baiDang)
        {
            if (ModelState.IsValid)
            {
                baiDang.MaBaiDang = Guid.NewGuid();
                _context.Add(baiDang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHangs, "MaKH", "MaKH", baiDang.MaKH);
            return View(baiDang);
        }

        // GET: CSKH/BaiDangs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiDang = await _context.BaiDangs.FindAsync(id);
            if (baiDang == null)
            {
                return NotFound();
            }
            ViewData["MaKH"] = new SelectList(_context.KhachHangs, "MaKH", "MaKH", baiDang.MaKH);
            return View(baiDang);
        }

        // POST: CSKH/BaiDangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaBaiDang,NoiDung,AnhVideo,LuotLike,MaKH")] BaiDang baiDang)
        {
            if (id != baiDang.MaBaiDang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baiDang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiDangExists(baiDang.MaBaiDang))
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
            ViewData["MaKH"] = new SelectList(_context.KhachHangs, "MaKH", "MaKH", baiDang.MaKH);
            return View(baiDang);
        }

        // GET: CSKH/BaiDangs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiDang = await _context.BaiDangs
                .Include(b => b.KhachHang)
                .FirstOrDefaultAsync(m => m.MaBaiDang == id);
            if (baiDang == null)
            {
                return NotFound();
            }

            return View(baiDang);
        }

        // POST: CSKH/BaiDangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var baiDang = await _context.BaiDangs.FindAsync(id);
            if (baiDang != null)
            {
                _context.BaiDangs.Remove(baiDang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaiDangExists(Guid id)
        {
            return _context.BaiDangs.Any(e => e.MaBaiDang == id);
        }
    }
}
