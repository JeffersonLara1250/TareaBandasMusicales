using BandasMusicales.Data;
using BandasMusicales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandasMusicales.Controllers
{
    public class BandasController : Controller 
    {
        private readonly ApplicationDbContext db;

        public BandasController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Bandas.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await db.Bandas.FirstOrDefaultAsync(d => d.BandaId == id);

            if (band == null)
            {
                return NotFound();
            }

            return View(band);

        }

        //Crear por medio de vista

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Banda banda)
        {
            if (ModelState.IsValid)
            {
                db.Add(banda);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banda);

        }

        //Departamentos//Edit/1
        public async Task<IActionResult> Edit(int? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var Band = await db.Bandas.FindAsync(id);

            if (Band == null)
            {
                return NotFound();
            }

            return View(Band);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Banda banda)
        {
            if (id != banda.BandaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(banda);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));

            }

            return View(banda);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await db.Bandas.FirstOrDefaultAsync(d => d.BandaId == id);

            if (band == null)
            {
                return NotFound();
            }

            return View(band);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var band = await db.Bandas.FindAsync(id);
            db.Bandas.Remove(band);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
