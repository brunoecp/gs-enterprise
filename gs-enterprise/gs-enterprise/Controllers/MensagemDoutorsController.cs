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
    public class MensagemDoutorsController : Controller
    {
        private readonly mysqlContext _context;

        public MensagemDoutorsController(mysqlContext context)
        {
            _context = context;
        }

        // GET: MensagemDoutors
        public async Task<IActionResult> Index()
        {
              return _context.MensagemDoutores != null ? 
                          View(await _context.MensagemDoutores.ToListAsync()) :
                          Problem("Entity set 'mysqlContext.MensagemDoutores'  is null.");
        }

        // GET: MensagemDoutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MensagemDoutores == null)
            {
                return NotFound();
            }

            var mensagemDoutor = await _context.MensagemDoutores
                .FirstOrDefaultAsync(m => m.DoutorId == id);
            if (mensagemDoutor == null)
            {
                return NotFound();
            }

            return View(mensagemDoutor);
        }

        // GET: MensagemDoutors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MensagemDoutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoutorId,mensagem")] MensagemDoutor mensagemDoutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagemDoutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensagemDoutor);
        }

        // GET: MensagemDoutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MensagemDoutores == null)
            {
                return NotFound();
            }

            var mensagemDoutor = await _context.MensagemDoutores.FindAsync(id);
            if (mensagemDoutor == null)
            {
                return NotFound();
            }
            return View(mensagemDoutor);
        }

        // POST: MensagemDoutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoutorId,mensagem")] MensagemDoutor mensagemDoutor)
        {
            if (id != mensagemDoutor.DoutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagemDoutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemDoutorExists(mensagemDoutor.DoutorId))
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
            return View(mensagemDoutor);
        }

        // GET: MensagemDoutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MensagemDoutores == null)
            {
                return NotFound();
            }

            var mensagemDoutor = await _context.MensagemDoutores
                .FirstOrDefaultAsync(m => m.DoutorId == id);
            if (mensagemDoutor == null)
            {
                return NotFound();
            }

            return View(mensagemDoutor);
        }

        // POST: MensagemDoutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MensagemDoutores == null)
            {
                return Problem("Entity set 'mysqlContext.MensagemDoutores'  is null.");
            }
            var mensagemDoutor = await _context.MensagemDoutores.FindAsync(id);
            if (mensagemDoutor != null)
            {
                _context.MensagemDoutores.Remove(mensagemDoutor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemDoutorExists(int id)
        {
          return (_context.MensagemDoutores?.Any(e => e.DoutorId == id)).GetValueOrDefault();
        }
    }
}
