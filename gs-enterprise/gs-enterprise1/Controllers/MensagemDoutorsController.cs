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
            var mysqlContext = _context.MensagemDoutores.Include(m => m.Doutor);
            return View(await mysqlContext.ToListAsync());
        }

        // GET: MensagemDoutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MensagemDoutores == null)
            {
                return NotFound();
            }

            var mensagemDoutor = await _context.MensagemDoutores
                .Include(m => m.Doutor)
                .FirstOrDefaultAsync(m => m.MensagemDoutorId == id);
            if (mensagemDoutor == null)
            {
                return NotFound();
            }

            return View(mensagemDoutor);
        }

        // GET: MensagemDoutors/Create
        public IActionResult Create()
        {
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm");
            return View();
        }

        // POST: MensagemDoutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensagemDoutorId,DoutorId,mensagem")] MensagemDoutor mensagemDoutor)
        {
        
                _context.Add(mensagemDoutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            TempData["SuccessMessage"] = "Mensagem do doutor cadastrada com sucesso";
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm", mensagemDoutor.DoutorId);
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
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm", mensagemDoutor.DoutorId);
            return View(mensagemDoutor);
        }

        // POST: MensagemDoutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensagemDoutorId,DoutorId,mensagem")] MensagemDoutor mensagemDoutor)
        {
            if (id != mensagemDoutor.MensagemDoutorId)
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
                    if (!MensagemDoutorExists(mensagemDoutor.MensagemDoutorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "Mensagem do doutor Editada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm", mensagemDoutor.DoutorId);
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
                .Include(m => m.Doutor)
                .FirstOrDefaultAsync(m => m.MensagemDoutorId == id);
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
            TempData["SuccessMessage"] = "Mensagem do doutor Apagada com sucesso";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemDoutorExists(int id)
        {
          return (_context.MensagemDoutores?.Any(e => e.MensagemDoutorId == id)).GetValueOrDefault();
        }
    }
}
