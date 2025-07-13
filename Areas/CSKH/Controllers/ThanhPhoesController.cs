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
    public class ThanhPhoesController : Controller
    {
        private readonly TravelDbContext _context;

        public ThanhPhoesController(TravelDbContext context)
        {
            _context = context;
        }

        // GET: CSKH/ThanhPhoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThanhPhos.ToListAsync());
        }

        // GET: CSKH/ThanhPhoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhPho = await _context.ThanhPhos
                .FirstOrDefaultAsync(m => m.MaTP == id);
            if (thanhPho == null)
            {
                return NotFound();
            }

            return View(thanhPho);
        }

        // GET: CSKH/ThanhPhoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CSKH/ThanhPhoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTP,TenThanhPho")] ThanhPho thanhPho)
        {
            if (ModelState.IsValid)
            {
                thanhPho.MaTP = Guid.NewGuid();
                _context.Add(thanhPho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thanhPho);
        }

        // GET: CSKH/ThanhPhoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhPho = await _context.ThanhPhos.FindAsync(id);
            if (thanhPho == null)
            {
                return NotFound();
            }
            return View(thanhPho);
        }

        // POST: CSKH/ThanhPhoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("MaTP,TenThanhPho")] ThanhPho thanhPho)
        {
            if (id != thanhPho.MaTP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhPho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhPhoExists(thanhPho.MaTP))
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
            return View(thanhPho);
        }

        // GET: CSKH/ThanhPhoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thanhPho = await _context.ThanhPhos
                .FirstOrDefaultAsync(m => m.MaTP == id);
            if (thanhPho == null)
            {
                return NotFound();
            }

            return View(thanhPho);
        }

        // POST: CSKH/ThanhPhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var thanhPho = await _context.ThanhPhos.FindAsync(id);
            if (thanhPho != null)
            {
                _context.ThanhPhos.Remove(thanhPho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhPhoExists(Guid id)
        {
            return _context.ThanhPhos.Any(e => e.MaTP == id);
        }
    }
}
