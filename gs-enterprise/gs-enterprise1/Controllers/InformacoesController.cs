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
    public class InformacoesController : Controller
    {
        private readonly mysqlContext _context;

        public InformacoesController(mysqlContext context)
        {
            _context = context;
        }

        // GET: Informacoes
        public async Task<IActionResult> Index()
        {
            var mysqlContext = _context.Informacoes.Include(i => i.Paciente);
            return View(await mysqlContext.ToListAsync());
        }

        // GET: Informacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Informacoes == null)
            {
                return NotFound();
            }

            var informacoes = await _context.Informacoes
                .Include(i => i.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informacoes == null)
            {
                return NotFound();
            }

            return View(informacoes);
        }

        // GET: Informacoes/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf");
            return View();
        }

        // POST: Informacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PacienteId,latitude,longitude,temp,umidade,batimento")] Informacoes informacoes)
        {
          
                _context.Add(informacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            TempData["SuccessMessage"] = "Informação criado com sucesso";
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf", informacoes.PacienteId);
            return View(informacoes);
        }

        // GET: Informacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Informacoes == null)
            {
                return NotFound();
            }

            var informacoes = await _context.Informacoes.FindAsync(id);
            if (informacoes == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf", informacoes.PacienteId);
            return View(informacoes);
        }

        // POST: Informacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PacienteId,latitude,longitude,temp,umidade,batimento")] Informacoes informacoes)
        {
            if (id != informacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(informacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InformacoesExists(informacoes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "Informação Editado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "PacienteId", "cpf", informacoes.PacienteId);
            return View(informacoes);
        }

        // GET: Informacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Informacoes == null)
            {
                return NotFound();
            }

            var informacoes = await _context.Informacoes
                .Include(i => i.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (informacoes == null)
            {
                return NotFound();
            }

            return View(informacoes);
        }

        // POST: Informacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Informacoes == null)
            {
                return Problem("Entity set 'mysqlContext.Informacoes'  is null.");
            }
            var informacoes = await _context.Informacoes.FindAsync(id);
            if (informacoes != null)
            {
                _context.Informacoes.Remove(informacoes);
            }
            TempData["SuccessMessage"] = "Informação Deletado com sucesso";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InformacoesExists(int id)
        {
          return (_context.Informacoes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
