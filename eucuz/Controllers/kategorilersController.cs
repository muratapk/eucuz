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
    public class kategorilersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public kategorilersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: kategorilers
        public async Task<IActionResult> Index()
        {
              return _context.kategorilers != null ? 
                          View(await _context.kategorilers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.kategorilers'  is null.");
        }

        // GET: kategorilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.kategorilers == null)
            {
                return NotFound();
            }

            var kategoriler = await _context.kategorilers
                .FirstOrDefaultAsync(m => m.kategori_Id == id);
            if (kategoriler == null)
            {
                return NotFound();
            }

            return View(kategoriler);
        }

        // GET: kategorilers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: kategorilers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kategori_Ad")] kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriler);
        }

        // GET: kategorilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.kategorilers == null)
            {
                return NotFound();
            }

            var kategoriler = await _context.kategorilers.FindAsync(id);
            if (kategoriler == null)
            {
                return NotFound();
            }
            return View(kategoriler);
        }

        // POST: kategorilers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("kategori_Id,kategori_Ad")] kategoriler kategoriler)
        {
            if (id != kategoriler.kategori_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!kategorilerExists(kategoriler.kategori_Id))
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
            return View(kategoriler);
        }

        // GET: kategorilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.kategorilers == null)
            {
                return NotFound();
            }

            var kategoriler = await _context.kategorilers
                .FirstOrDefaultAsync(m => m.kategori_Id == id);
            if (kategoriler == null)
            {
                return NotFound();
            }

            return View(kategoriler);
        }

        // POST: kategorilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.kategorilers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.kategorilers'  is null.");
            }
            var kategoriler = await _context.kategorilers.FindAsync(id);
            if (kategoriler != null)
            {
                _context.kategorilers.Remove(kategoriler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool kategorilerExists(int id)
        {
          return (_context.kategorilers?.Any(e => e.kategori_Id == id)).GetValueOrDefault();
        }
    }
}
