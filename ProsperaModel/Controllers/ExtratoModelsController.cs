using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsperaModel.Data;
using ProsperaModel.Models;

namespace ProsperaModel.Controllers
{
    public class ExtratoModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public ExtratoModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: ExtratoModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.ExtratoModel.Include(e => e.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: ExtratoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExtratoModel == null)
            {
                return NotFound();
            }

            var extratoModel = await _context.ExtratoModel
                .Include(e => e.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdExtrato == id);
            if (extratoModel == null)
            {
                return NotFound();
            }

            return View(extratoModel);
        }

        // GET: ExtratoModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioExtrat"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: ExtratoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExtrato,NomeExtrat,TipoExtrat,ValorExtrat,NomBancoExtrat,CodContaExtrat,DestinatarioExtrat,DataExtrat,StatusExtrat,UsuarioExtrat,ObservacaoExtrat")] ExtratoModel extratoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(extratoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioExtrat"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", extratoModel.UsuarioExtrat);
            return View(extratoModel);
        }

        // GET: ExtratoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExtratoModel == null)
            {
                return NotFound();
            }

            var extratoModel = await _context.ExtratoModel.FindAsync(id);
            if (extratoModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioExtrat"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", extratoModel.UsuarioExtrat);
            return View(extratoModel);
        }

        // POST: ExtratoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExtrato,NomeExtrat,TipoExtrat,ValorExtrat,NomBancoExtrat,CodContaExtrat,DestinatarioExtrat,DataExtrat,StatusExtrat,UsuarioExtrat,ObservacaoExtrat")] ExtratoModel extratoModel)
        {
            if (id != extratoModel.IdExtrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(extratoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtratoModelExists(extratoModel.IdExtrato))
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
            ViewData["UsuarioExtrat"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", extratoModel.UsuarioExtrat);
            return View(extratoModel);
        }

        // GET: ExtratoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExtratoModel == null)
            {
                return NotFound();
            }

            var extratoModel = await _context.ExtratoModel
                .Include(e => e.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdExtrato == id);
            if (extratoModel == null)
            {
                return NotFound();
            }

            return View(extratoModel);
        }

        // POST: ExtratoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExtratoModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.ExtratoModel'  is null.");
            }
            var extratoModel = await _context.ExtratoModel.FindAsync(id);
            if (extratoModel != null)
            {
                _context.ExtratoModel.Remove(extratoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtratoModelExists(int id)
        {
          return (_context.ExtratoModel?.Any(e => e.IdExtrato == id)).GetValueOrDefault();
        }
    }
}
