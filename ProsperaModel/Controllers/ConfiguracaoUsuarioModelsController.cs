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
    public class ConfiguracaoUsuarioModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public ConfiguracaoUsuarioModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: ConfiguracaoUsuarioModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.ConfiguracaoUsuarioModel.Include(c => c.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: ConfiguracaoUsuarioModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ConfiguracaoUsuarioModel == null)
            {
                return NotFound();
            }

            var configuracaoUsuarioModel = await _context.ConfiguracaoUsuarioModel
                .Include(c => c.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdConfiguracaoUsuario == id);
            if (configuracaoUsuarioModel == null)
            {
                return NotFound();
            }

            return View(configuracaoUsuarioModel);
        }

        // GET: ConfiguracaoUsuarioModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioConfiguracaoUsuario"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: ConfiguracaoUsuarioModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfiguracaoUsuario,UsuarioConfiguracaoUsuario,NotificacoesAtivadas")] ConfiguracaoUsuarioModel configuracaoUsuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configuracaoUsuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioConfiguracaoUsuario"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", configuracaoUsuarioModel.UsuarioConfiguracaoUsuario);
            return View(configuracaoUsuarioModel);
        }

        // GET: ConfiguracaoUsuarioModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ConfiguracaoUsuarioModel == null)
            {
                return NotFound();
            }

            var configuracaoUsuarioModel = await _context.ConfiguracaoUsuarioModel.FindAsync(id);
            if (configuracaoUsuarioModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioConfiguracaoUsuario"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", configuracaoUsuarioModel.UsuarioConfiguracaoUsuario);
            return View(configuracaoUsuarioModel);
        }

        // POST: ConfiguracaoUsuarioModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfiguracaoUsuario,UsuarioConfiguracaoUsuario,NotificacoesAtivadas")] ConfiguracaoUsuarioModel configuracaoUsuarioModel)
        {
            if (id != configuracaoUsuarioModel.IdConfiguracaoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracaoUsuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracaoUsuarioModelExists(configuracaoUsuarioModel.IdConfiguracaoUsuario))
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
            ViewData["UsuarioConfiguracaoUsuario"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", configuracaoUsuarioModel.UsuarioConfiguracaoUsuario);
            return View(configuracaoUsuarioModel);
        }

        // GET: ConfiguracaoUsuarioModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ConfiguracaoUsuarioModel == null)
            {
                return NotFound();
            }

            var configuracaoUsuarioModel = await _context.ConfiguracaoUsuarioModel
                .Include(c => c.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdConfiguracaoUsuario == id);
            if (configuracaoUsuarioModel == null)
            {
                return NotFound();
            }

            return View(configuracaoUsuarioModel);
        }

        // POST: ConfiguracaoUsuarioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ConfiguracaoUsuarioModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.ConfiguracaoUsuarioModel'  is null.");
            }
            var configuracaoUsuarioModel = await _context.ConfiguracaoUsuarioModel.FindAsync(id);
            if (configuracaoUsuarioModel != null)
            {
                _context.ConfiguracaoUsuarioModel.Remove(configuracaoUsuarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiguracaoUsuarioModelExists(int id)
        {
          return (_context.ConfiguracaoUsuarioModel?.Any(e => e.IdConfiguracaoUsuario == id)).GetValueOrDefault();
        }
    }
}
