using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JosueValencia_EXAMPRIMERO.Data;
using JosueValencia_EXAMPRIMERO.Models;

namespace JosueValencia_EXAMPRIMERO.Controllers
{
    public class JValenciasController : Controller
    {
        private readonly JosueValencia_EXAMPRIMEROContext _context;

        public JValenciasController(JosueValencia_EXAMPRIMEROContext context)
        {
            _context = context;
        }

        // GET: JValencias
        public async Task<IActionResult> Index()
        {
            var josueValencia_EXAMPRIMEROContext = _context.JValencia.Include(j => j.Celular);
            return View(await josueValencia_EXAMPRIMEROContext.ToListAsync());
        }

        // GET: JValencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jValencia = await _context.JValencia
                .Include(j => j.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jValencia == null)
            {
                return NotFound();
            }

            return View(jValencia);
        }

        // GET: JValencias/Create
        public IActionResult Create()
        {
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "Id", "Id");
            return View();
        }

        // POST: JValencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sueldo,Nombre,Correo,ClienteAntiguo,Pedido,IdCelular")] JValencia jValencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jValencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "Id", "Id", jValencia.IdCelular);
            return View(jValencia);
        }

        // GET: JValencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jValencia = await _context.JValencia.FindAsync(id);
            if (jValencia == null)
            {
                return NotFound();
            }
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "Id", "Id", jValencia.IdCelular);
            return View(jValencia);
        }

        // POST: JValencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sueldo,Nombre,Correo,ClienteAntiguo,Pedido,IdCelular")] JValencia jValencia)
        {
            if (id != jValencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jValencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JValenciaExists(jValencia.Id))
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
            ViewData["IdCelular"] = new SelectList(_context.Celulares, "Id", "Id", jValencia.IdCelular);
            return View(jValencia);
        }

        // GET: JValencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jValencia = await _context.JValencia
                .Include(j => j.Celular)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jValencia == null)
            {
                return NotFound();
            }

            return View(jValencia);
        }

        // POST: JValencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jValencia = await _context.JValencia.FindAsync(id);
            if (jValencia != null)
            {
                _context.JValencia.Remove(jValencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JValenciaExists(int id)
        {
            return _context.JValencia.Any(e => e.Id == id);
        }
    }
}
