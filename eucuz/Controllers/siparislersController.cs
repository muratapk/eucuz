using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eucuz.Data;
using eucuz.Models;

namespace eucuz.Controllers
{
    public class siparislersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public siparislersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: siparislers
        public async Task<IActionResult> Index()
        {
              return _context.siparislers != null ? 
                          View(await _context.siparislers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.siparislers'  is null.");
        }

        // GET: siparislers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.siparislers == null)
            {
                return NotFound();
            }

            var siparisler = await _context.siparislers
                .FirstOrDefaultAsync(m => m.siparis_Id == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // GET: siparislers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: siparislers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("siparis_Id,urun_Id,adet")] siparisler siparisler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparisler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siparisler);
        }

        // GET: siparislers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.siparislers == null)
            {
                return NotFound();
            }

            var siparisler = await _context.siparislers.FindAsync(id);
            if (siparisler == null)
            {
                return NotFound();
            }
            return View(siparisler);
        }

        // POST: siparislers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("siparis_Id,urun_Id,adet")] siparisler siparisler)
        {
            if (id != siparisler.siparis_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparisler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!siparislerExists(siparisler.siparis_Id))
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
            return View(siparisler);
        }

        // GET: siparislers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.siparislers == null)
            {
                return NotFound();
            }

            var siparisler = await _context.siparislers
                .FirstOrDefaultAsync(m => m.siparis_Id == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // POST: siparislers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.siparislers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.siparislers'  is null.");
            }
            var siparisler = await _context.siparislers.FindAsync(id);
            if (siparisler != null)
            {
                _context.siparislers.Remove(siparisler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool siparislerExists(int id)
        {
          return (_context.siparislers?.Any(e => e.siparis_Id == id)).GetValueOrDefault();
        }
    }
}
