﻿using System;
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
    public class ChatsController : Controller
    {
        private readonly mysqlContext _context;

        public ChatsController(mysqlContext context)
        {
            _context = context;
        }

        // GET: Chats
        public async Task<IActionResult> Index()
        {
            var mysqlContext = _context.Chats.Include(c => c.Doutor).Include(c => c.Paciente);
            return View(await mysqlContext.ToListAsync());
        }

        // GET: Chats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .Include(c => c.Doutor)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ChatId == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // GET: Chats/Create
        public IActionResult Create()
        {
            ViewData["MensagemDoutorId"] = new SelectList(_context.MensagemDoutores, "MensagemDoutorId", "MensagemDoutorId");
            ViewData["MensagemPacienteId"] = new SelectList(_context.MensagemPacientes, "MensagemPacienteId", "MensagemPacienteId");
            return View();
        }

        // POST: Chats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChatId,MensagemDoutorId,MensagemPacienteId")] Chat chat)
        {
           
                _context.Add(chat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            TempData["SuccessMessage"] = "Chat Criado com sucesso";
            ViewData["MensagemDoutorId"] = new SelectList(_context.MensagemDoutores, "MensagemDoutorId", "MensagemDoutorId", chat.MensagemDoutorId);
            ViewData["MensagemPacienteId"] = new SelectList(_context.MensagemPacientes, "MensagemPacienteId", "MensagemPacienteId", chat.MensagemPacienteId);
            return View(chat);
        }

        // GET: Chats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }
            ViewData["MensagemDoutorId"] = new SelectList(_context.MensagemDoutores, "MensagemDoutorId", "MensagemDoutorId", chat.MensagemDoutorId);
            ViewData["MensagemPacienteId"] = new SelectList(_context.MensagemPacientes, "MensagemPacienteId", "MensagemPacienteId", chat.MensagemPacienteId);
            return View(chat);
        }

        // POST: Chats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChatId,MensagemDoutorId,MensagemPacienteId")] Chat chat)
        {
            if (id != chat.ChatId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(chat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatExists(chat.ChatId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "Chat Editado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewData["MensagemDoutorId"] = new SelectList(_context.MensagemDoutores, "MensagemDoutorId", "MensagemDoutorId", chat.MensagemDoutorId);
            ViewData["MensagemPacienteId"] = new SelectList(_context.MensagemPacientes, "MensagemPacienteId", "MensagemPacienteId", chat.MensagemPacienteId);
            return View(chat);
        }

        // GET: Chats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chats == null)
            {
                return NotFound();
            }

            var chat = await _context.Chats
                .Include(c => c.Doutor)
                .Include(c => c.Paciente)
                .FirstOrDefaultAsync(m => m.ChatId == id);
            if (chat == null)
            {
                return NotFound();
            }

            return View(chat);
        }

        // POST: Chats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chats == null)
            {
                return Problem("Entity set 'mysqlContext.Chats'  is null.");
            }
            var chat = await _context.Chats.FindAsync(id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
            }
            TempData["SuccessMessage"] = "Chat Deletado com sucesso";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatExists(int id)
        {
          return (_context.Chats?.Any(e => e.ChatId == id)).GetValueOrDefault();
        }
    }
}
