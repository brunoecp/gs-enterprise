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
    public class MensagemPacientesController : Controller
    {
        private readonly mysqlContext _context;

        public MensagemPacientesController(mysqlContext context)
        {
            _context = context;
        }

        // GET: MensagemPacientes
        public async Task<IActionResult> Index()
        {
              return _context.MensagemPacientes != null ? 
                          View(await _context.MensagemPacientes.ToListAsync()) :
                          Problem("Entity set 'mysqlContext.MensagemPacientes'  is null.");
        }

        // GET: MensagemPacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MensagemPacientes == null)
            {
                return NotFound();
            }

            var mensagemPaciente = await _context.MensagemPacientes
                .FirstOrDefaultAsync(m => m.PacienteId == id);
            if (mensagemPaciente == null)
            {
                return NotFound();
            }

            return View(mensagemPaciente);
        }

        // GET: MensagemPacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MensagemPacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacienteId,mensagem")] MensagemPaciente mensagemPaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagemPaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensagemPaciente);
        }

        // GET: MensagemPacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MensagemPacientes == null)
            {
                return NotFound();
            }

            var mensagemPaciente = await _context.MensagemPacientes.FindAsync(id);
            if (mensagemPaciente == null)
            {
                return NotFound();
            }
            return View(mensagemPaciente);
        }

        // POST: MensagemPacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacienteId,mensagem")] MensagemPaciente mensagemPaciente)
        {
            if (id != mensagemPaciente.PacienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagemPaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemPacienteExists(mensagemPaciente.PacienteId))
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
            return View(mensagemPaciente);
        }

        // GET: MensagemPacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MensagemPacientes == null)
            {
                return NotFound();
            }

            var mensagemPaciente = await _context.MensagemPacientes
                .FirstOrDefaultAsync(m => m.PacienteId == id);
            if (mensagemPaciente == null)
            {
                return NotFound();
            }

            return View(mensagemPaciente);
        }

        // POST: MensagemPacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MensagemPacientes == null)
            {
                return Problem("Entity set 'mysqlContext.MensagemPacientes'  is null.");
            }
            var mensagemPaciente = await _context.MensagemPacientes.FindAsync(id);
            if (mensagemPaciente != null)
            {
                _context.MensagemPacientes.Remove(mensagemPaciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemPacienteExists(int id)
        {
          return (_context.MensagemPacientes?.Any(e => e.PacienteId == id)).GetValueOrDefault();
        }
    }
}
