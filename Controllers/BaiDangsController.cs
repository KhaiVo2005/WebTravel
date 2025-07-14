using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTravel.Attribute;
using WebTravel.Data;
using WebTravel.Models.Models;

namespace WebTravel.Controllers
{
    [CheckLogin]
    public class BaiDangsController : Controller
    {
        private readonly TravelDbContext _context;

        public BaiDangsController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: BaiDangs
        public async Task<IActionResult> Index()
        {
            var travelDbContext = _context.BaiDangs.Include(b => b.KhachHang).Include(b => b.CmtBaiDangs);
            return View(await travelDbContext.ToListAsync());
        }

        // GET: BaiDangs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var baiDang = await _context.BaiDangs.FirstOrDefaultAsync(b => b.MaBaiDang == id);
            if (baiDang == null)
                return NotFound();

            var nguoiDang = await _context.KhachHangs.FirstOrDefaultAsync(k => k.MaKH == baiDang.MaKH);

            var binhLuans = await _context.CmtBaiDangs
                .Where(c => c.MaBaiDang == baiDang.MaBaiDang)
                .ToListAsync();

            var listMaKH = binhLuans.Select(c => c.MaKH).Distinct();

            var khachBinhLuan = await _context.KhachHangs
                .Where(k => listMaKH.Contains(k.MaKH))
                .ToDictionaryAsync(k => k.MaKH);

            var vm = new CmtBaiDangKH
            {
                BaiDang = baiDang,
                NguoiDang = nguoiDang,
                BinhLuans = binhLuans,
                DanhSachNguoiBinhLuan = khachBinhLuan
            };

            return View(vm);
        }


        // GET: BaiDangs/Create
        public IActionResult Create()
        {
            ViewData["MaKH"] = new SelectList(_context.KhachHangs, "MaKH", "MaKH");
            return View();
        }

        // POST: BaiDangs/Create
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

        // GET: BaiDangs/Edit/5
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

        // POST: BaiDangs/Edit/5
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

        // GET: BaiDangs/Delete/5
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

        // POST: BaiDangs/Delete/5
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
