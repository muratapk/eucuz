using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eucuz.Data;
using eucuz.Models;
using NuGet.Protocol;
using static NuGet.Packaging.PackagingConstants;
using Microsoft.CodeAnalysis.Operations;

namespace eucuz.Controllers
{
    public class UrunlersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UrunlersController(ApplicationDbContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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

            ViewBag.katelist = new SelectList(_context.kategorilers, "kategori_Id", "kategori_Ad");
            return View();  
        }

        // POST: Urunlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Urunler urunler, IFormFile resimyukle)
        {

            //if (urunler.resimyukle != null)
            //{
            //    string folder = "~/resimler";
            //    string isim = Guid.NewGuid().ToString() + urunler.resimyukle.FileName;
            //    folder += isim;
            //    string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            //    await urunler.resimyukle.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            //    urunler.resim = isim;
            //}

            string extension = Path.GetExtension(resimyukle.FileName);
            //burada dosyanı uzantısı aldık
            var randomName = Guid.NewGuid().ToString() + extension;
            var yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler", randomName);
            using (var stream = new FileStream(yol, FileMode.Create))
            {
                await resimyukle.CopyToAsync(stream);
            }
            urunler.resim= randomName;

           
               

                _context.Add(urunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        
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
