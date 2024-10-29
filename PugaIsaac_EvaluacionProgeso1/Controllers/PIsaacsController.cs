using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PugaIsaac_EvaluacionProgeso1.Data;
using PugaIsaac_EvaluacionProgeso1.Models;

namespace PugaIsaac_EvaluacionProgeso1.Controllers
{
    public class PIsaacsController : Controller
    {
        private readonly PugaIsaac_EvaluacionProgeso1Context _context;

        public PIsaacsController(PugaIsaac_EvaluacionProgeso1Context context)
        {
            _context = context;
        }

        // GET: PIsaacs
        public async Task<IActionResult> Index()
        {
            var pugaIsaac_EvaluacionProgeso1Context = _context.PIsaac.Include(p => p.Celular);
            return View(await pugaIsaac_EvaluacionProgeso1Context.ToListAsync());
        }

        // GET: PIsaacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pIsaac = await _context.PIsaac
                .Include(p => p.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pIsaac == null)
            {
                return NotFound();
            }

            return View(pIsaac);
        }

        // GET: PIsaacs/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Name");//id
            return View();
        }

        // POST: PIsaacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Soltero,FechaDeCompra,Sueldo,IdCelular")] PIsaac pIsaac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pIsaac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Name", pIsaac.IdCelular);
            return View(pIsaac);
        }

        // GET: PIsaacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pIsaac = await _context.PIsaac.FindAsync(id);
            if (pIsaac == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Name", pIsaac.IdCelular);
            return View(pIsaac);
        }

        // POST: PIsaacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Soltero,FechaDeCompra,Sueldo,IdCelular")] PIsaac pIsaac)
        {
            if (id != pIsaac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pIsaac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PIsaacExists(pIsaac.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Set<Celular>(), "Id", "Name", pIsaac.IdCelular);
            return View(pIsaac);
        }

        // GET: PIsaacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pIsaac = await _context.PIsaac
                .Include(p => p.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pIsaac == null)
            {
                return NotFound();
            }

            return View(pIsaac);
        }

        // POST: PIsaacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pIsaac = await _context.PIsaac.FindAsync(id);
            if (pIsaac != null)
            {
                _context.PIsaac.Remove(pIsaac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PIsaacExists(int id)
        {
            return _context.PIsaac.Any(e => e.Id == id);
        }
    }
}
