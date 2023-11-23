using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gs_enterprise.Data;
using gs_enterprise.Models;

namespace gs_enterprise.Controllers
{
    public class DoutorsController : Controller
    {
        private readonly mysqlContext _context;

        public DoutorsController(mysqlContext context)
        {
            _context = context;
        }

        // GET: Doutors
        public async Task<IActionResult> Index()
        {
              return _context.doutores != null ? 
                          View(await _context.doutores.ToListAsync()) :
                          Problem("Entity set 'mysqlContext.doutores'  is null.");
        }

        // GET: Doutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.doutores == null)
            {
                return NotFound();
            }

            var doutor = await _context.doutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doutor == null)
            {
                return NotFound();
            }

            return View(doutor);
        }

        // GET: Doutors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,email,nascimento,crm,senha")] Doutor doutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doutor);
        }

        // GET: Doutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.doutores == null)
            {
                return NotFound();
            }

            var doutor = await _context.doutores.FindAsync(id);
            if (doutor == null)
            {
                return NotFound();
            }
            return View(doutor);
        }

        // POST: Doutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,email,nascimento,crm,senha")] Doutor doutor)
        {
            if (id != doutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoutorExists(doutor.Id))
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
            return View(doutor);
        }

        // GET: Doutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.doutores == null)
            {
                return NotFound();
            }

            var doutor = await _context.doutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doutor == null)
            {
                return NotFound();
            }

            return View(doutor);
        }

        // POST: Doutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.doutores == null)
            {
                return Problem("Entity set 'mysqlContext.doutores'  is null.");
            }
            var doutor = await _context.doutores.FindAsync(id);
            if (doutor != null)
            {
                _context.doutores.Remove(doutor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoutorExists(int id)
        {
          return (_context.doutores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
