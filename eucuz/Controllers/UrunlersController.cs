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
    public class UrunlersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrunlersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Urunlers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.urunlers.Include(u => u.kategoriler);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Urunlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.urunlers == null)
            {
                return NotFound();
            }

            var urunler = await _context.urunlers
                .Include(u => u.kategoriler)
                .FirstOrDefaultAsync(m => m.urun_Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // GET: Urunlers/Create
        public IActionResult Create()
        {
            List<kategoriler>listem=new List<kategoriler>();
            listem = _context.kategorilers.ToList();
            listem.Insert(0, new kategoriler { kategori_Id=0,kategori_Ad="Seçim Yapınız"});
            ViewBag.katelist=listem;
            return View();
        }

        // POST: Urunlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("urun_Id,urun_Adi,urun_Kodu,urun_fiyat,resim,aciklama,indirim,kategori_Id,birim,olcut")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(urunler);
        }

        // GET: Urunlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.urunlers == null)
            {
                return NotFound();
            }
            List<kategoriler> listem = new List<kategoriler>();
            listem = _context.kategorilers.ToList();
            listem.Insert(0, new kategoriler{ kategori_Id = 0, kategori_Ad = "Seçim Yapınız" });
            ViewBag.katelist = listem;
            var urunler = await _context.urunlers.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }
          
            return View(urunler);
        }

        // POST: Urunlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("urun_Id,urun_Adi,urun_Kodu,urun_fiyat,resim,aciklama,indirim,kategori_Id,birim,olcut")] Urunler urunler)
        {
            if (id != urunler.urun_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunlerExists(urunler.urun_Id))
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
           
            return View(urunler);
        }

        // GET: Urunlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.urunlers == null)
            {
                return NotFound();
            }

            var urunler = await _context.urunlers
                .Include(u => u.kategoriler)
                .FirstOrDefaultAsync(m => m.urun_Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // POST: Urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.urunlers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.urunlers'  is null.");
            }
            var urunler = await _context.urunlers.FindAsync(id);
            if (urunler != null)
            {
                _context.urunlers.Remove(urunler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunlerExists(int id)
        {
          return (_context.urunlers?.Any(e => e.urun_Id == id)).GetValueOrDefault();
        }
    }
}
