using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Guerron_Elizabeth_EXAMENPROGRESO.Data;
using Guerron_Elizabeth_EXAMENPROGRESO.Models;

namespace Guerron_Elizabeth_EXAMENPROGRESO.Controllers
{
    public class CelularesController : Controller
    {
        private readonly Guerron_Elizabeth_EXAMENPROGRESOContext _context;

        public CelularesController(Guerron_Elizabeth_EXAMENPROGRESOContext context)
        {
            _context = context;
        }

        // GET: Celulares
        public async Task<IActionResult> Index()
        {
            return View(await _context.Celular.ToListAsync());
        }

        // GET: Celulares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // GET: Celulares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Celulares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Amo,Precio")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celular);
        }

        // GET: Celulares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }
            return View(celular);
        }

        // POST: Celulares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Amo,Precio")] Celular celular)
        {
            if (id != celular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularExists(celular.Id))
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
            return View(celular);
        }

        // GET: Celulares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // POST: Celulares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celular = await _context.Celular.FindAsync(id);
            if (celular != null)
            {
                _context.Celular.Remove(celular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularExists(int id)
        {
            return _context.Celular.Any(e => e.Id == id);
        }
    }
}
