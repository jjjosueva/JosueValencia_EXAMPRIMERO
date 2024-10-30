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
    public class CelularesController : Controller
    {
        private readonly JosueValencia_EXAMPRIMEROContext _context;

        public CelularesController(JosueValencia_EXAMPRIMEROContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Celulares.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulares = await _context.Celulares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celulares == null)
            {
                return NotFound();
            }

            return View(celulares);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Celulares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Anio,Precio")] Celulares celulares)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celulares);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(celulares);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulares = await _context.Celulares.FindAsync(id);
            if (celulares == null)
            {
                return NotFound();
            }
            return View(celulares);
        }

        // POST: Celulares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Anio,Precio")] Celulares celulares)
        {
            if (id != celulares.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celulares);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularesExists(celulares.Id))
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
            return View(celulares);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulares = await _context.Celulares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celulares == null)
            {
                return NotFound();
            }

            return View(celulares);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celulares = await _context.Celulares.FindAsync(id);
            if (celulares != null)
            {
                _context.Celulares.Remove(celulares);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularesExists(int id)
        {
            return _context.Celulares.Any(e => e.Id == id);
        }
    }
}
