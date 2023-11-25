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
    public class ChamadasController : Controller
    {
        private readonly mysqlContext _context;

        public ChamadasController(mysqlContext context)
        {
            _context = context;
        }

        // GET: Chamadas
        public async Task<IActionResult> Index()
        {
            var mysqlContext = _context.chamadas.Include(c => c.Doutor).Include(c => c.Paciente);
            return View(await mysqlContext.ToListAsync());
        }

        // GET: Chamadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chamadas == null)
            {
                return NotFound();
            }

            var chamada = await _context.chamadas
                .Include(c => c.Doutor)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ChamadaId == id);
            if (chamada == null)
            {
                return NotFound();
            }

            return View(chamada);
        }

        // GET: Chamadas/Create
        public IActionResult Create()
        {
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm");
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf");
            return View();
        }

        // POST: Chamadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChamadaId,duracao,DoutorId,PacienteId")] Chamada chamada)
        {
         
                _context.Add(chamada);
                await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "chamada cadastrada com sucesso";
                return RedirectToAction(nameof(Index));
            
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm", chamada.DoutorId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf", chamada.PacienteId);
            return View(chamada);
        }

        // GET: Chamadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chamadas == null)
            {
                return NotFound();
            }

            var chamada = await _context.chamadas.FindAsync(id);
            if (chamada == null)
            {
                return NotFound();
            }
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm", chamada.DoutorId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf", chamada.PacienteId);
            return View(chamada);
        }

        // POST: Chamadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChamadaId,duracao,DoutorId,PacienteId")] Chamada chamada)
        {
            if (id != chamada.ChamadaId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadaExists(chamada.ChamadaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "chamada editada com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoutorId"] = new SelectList(_context.doutores, "Id", "crm", chamada.DoutorId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf", chamada.PacienteId);
            return View(chamada);
        }

        // GET: Chamadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chamadas == null)
            {
                return NotFound();
            }

            var chamada = await _context.chamadas
                .Include(c => c.Doutor)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ChamadaId == id);
            if (chamada == null)
            {
                return NotFound();
            }

            return View(chamada);
        }

        // POST: Chamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chamadas == null)
            {
                return Problem("Entity set 'mysqlContext.chamadas'  is null.");
            }
            var chamada = await _context.chamadas.FindAsync(id);
            if (chamada != null)
            {
                _context.chamadas.Remove(chamada);
            }
            TempData["SuccessMessage"] = "chamada deletada com sucesso";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadaExists(int id)
        {
          return (_context.chamadas?.Any(e => e.ChamadaId == id)).GetValueOrDefault();
        }
    }
}
