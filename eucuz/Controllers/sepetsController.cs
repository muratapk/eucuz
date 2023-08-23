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
    public class sepetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public sepetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: sepets
        public async Task<IActionResult> Index()
        {
              return _context.sepet != null ? 
                          View(await _context.sepet.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.sepet'  is null.");
        }

        // GET: sepets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sepet == null)
            {
                return NotFound();
            }

            var sepet = await _context.sepet
                .FirstOrDefaultAsync(m => m.sepet_Id == id);
            if (sepet == null)
            {
                return NotFound();
            }

            return View(sepet);
        }

        // GET: sepets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sepets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sepet_Id,urun_Id,adet")] sepet sepet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sepet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sepet);
        }

        // GET: sepets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sepet == null)
            {
                return NotFound();
            }

            var sepet = await _context.sepet.FindAsync(id);
            if (sepet == null)
            {
                return NotFound();
            }
            return View(sepet);
        }

        // POST: sepets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sepet_Id,urun_Id,adet")] sepet sepet)
        {
            if (id != sepet.sepet_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sepet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!sepetExists(sepet.sepet_Id))
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
            return View(sepet);
        }

        // GET: sepets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sepet == null)
            {
                return NotFound();
            }

            var sepet = await _context.sepet
                .FirstOrDefaultAsync(m => m.sepet_Id == id);
            if (sepet == null)
            {
                return NotFound();
            }

            return View(sepet);
        }

        // POST: sepets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sepet == null)
            {
                return Problem("Entity set 'ApplicationDbContext.sepet'  is null.");
            }
            var sepet = await _context.sepet.FindAsync(id);
            if (sepet != null)
            {
                _context.sepet.Remove(sepet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool sepetExists(int id)
        {
          return (_context.sepet?.Any(e => e.sepet_Id == id)).GetValueOrDefault();
        }
    }
}
