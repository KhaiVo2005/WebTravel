using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTravel.Data;

namespace WebTravel.Controllers
{
    public class DiaDiemsController : Controller
    {
        private readonly TravelDbContext _context;

        public DiaDiemsController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: DiaDiems
        public async Task<IActionResult> Index()
        {
            var travelDbContext = _context.DiaDiems.Include(d => d.ThanhPho);
            return View(await travelDbContext.ToListAsync());
        }

        // GET: DiaDiems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem = await _context.DiaDiems
                .Include(d => d.ThanhPho)
                .FirstOrDefaultAsync(m => m.MaDD == id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            return View(diaDiem);
        }

        // GET: DiaDiems/Create
        public IActionResult Create()
        {
            ViewData["MaTP"] = new SelectList(_context.ThanhPhos, "MaTP", "MaTP");
            return View();
        }

        // POST: DiaDiems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDD,TenDiaDiem,MoTa,Anh,MaTP")] DiaDiem diaDiem)
        {
            if (ModelState.IsValid)
            {
                diaDiem.MaDD = Guid.NewGuid();
                _context.Add(diaDiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaTP"] = new SelectList(_context.ThanhPhos, "MaTP", "MaTP", diaDiem.MaTP);
            return View(diaDiem);
        }

        // GET: DiaDiems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem = await _context.DiaDiems.FindAsync(id);
            if (diaDiem == null)
            {
                return NotFound();
            }
            ViewData["MaTP"] = new SelectList(_context.ThanhPhos, "MaTP", "MaTP", diaDiem.MaTP);
            return View(diaDiem);
        }

        // POST: DiaDiems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaDD,TenDiaDiem,MoTa,Anh,MaTP")] DiaDiem diaDiem)
        {
            if (id != diaDiem.MaDD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaDiem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaDiemExists(diaDiem.MaDD))
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
            ViewData["MaTP"] = new SelectList(_context.ThanhPhos, "MaTP", "MaTP", diaDiem.MaTP);
            return View(diaDiem);
        }

        // GET: DiaDiems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem = await _context.DiaDiems
                .Include(d => d.ThanhPho)
                .FirstOrDefaultAsync(m => m.MaDD == id);
            if (diaDiem == null)
            {
                return NotFound();
            }

            return View(diaDiem);
        }

        // POST: DiaDiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var diaDiem = await _context.DiaDiems.FindAsync(id);
            if (diaDiem != null)
            {
                _context.DiaDiems.Remove(diaDiem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaDiemExists(Guid id)
        {
            return _context.DiaDiems.Any(e => e.MaDD == id);
        }
    }
}
