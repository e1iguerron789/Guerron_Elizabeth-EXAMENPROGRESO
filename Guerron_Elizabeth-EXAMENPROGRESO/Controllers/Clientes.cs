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
    public class Clientes : Controller
    {
        private readonly Guerron_Elizabeth_EXAMENPROGRESOContext _context;

        public Clientes(Guerron_Elizabeth_EXAMENPROGRESOContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var guerron_Elizabeth_EXAMENPROGRESOContext = _context.EGuerron.Include(e => e.Celular);
            return View(await guerron_Elizabeth_EXAMENPROGRESOContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGuerron = await _context.EGuerron
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eGuerron == null)
            {
                return NotFound();
            }

            return View(eGuerron);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Altura,Nombre,Correo,ClienteAntiguo,Pedido,IdCelular")] EGuerron eGuerron)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eGuerron);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", eGuerron.IdCelular);
            return View(eGuerron);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGuerron = await _context.EGuerron.FindAsync(id);
            if (eGuerron == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", eGuerron.IdCelular);
            return View(eGuerron);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Altura,Nombre,Correo,ClienteAntiguo,Pedido,IdCelular")] EGuerron eGuerron)
        {
            if (id != eGuerron.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eGuerron);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EGuerronExists(eGuerron.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Id", eGuerron.IdCelular);
            return View(eGuerron);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eGuerron = await _context.EGuerron
                .Include(e => e.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eGuerron == null)
            {
                return NotFound();
            }

            return View(eGuerron);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eGuerron = await _context.EGuerron.FindAsync(id);
            if (eGuerron != null)
            {
                _context.EGuerron.Remove(eGuerron);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EGuerronExists(int id)
        {
            return _context.EGuerron.Any(e => e.Id == id);
        }
    }
}
