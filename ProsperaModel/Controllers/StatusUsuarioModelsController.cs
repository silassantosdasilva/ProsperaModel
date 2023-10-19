using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsperaModel.Data;

namespace ProsperaModel.Controllers
{
    public class StatusUsuarioModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public StatusUsuarioModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: StatusUsuarioModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.StatusUsuarioModel.Include(s => s.UsuarioModel);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: StatusUsuarioModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusUsuarioModel == null)
            {
                return NotFound();
            }

            var statusUsuarioModel = await _context.StatusUsuarioModel
                .Include(s => s.UsuarioModel)
                .FirstOrDefaultAsync(m => m.IdStatusUsuario == id);
            if (statusUsuarioModel == null)
            {
                return NotFound();
            }

            return View(statusUsuarioModel);
        }

        // GET: StatusUsuarioModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioModelId"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: StatusUsuarioModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatusUsuario,DescStatusUsuario,UsuarioModelId")] StatusUsuarioModel statusUsuarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusUsuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioModelId"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", statusUsuarioModel.UsuarioModelId);
            return View(statusUsuarioModel);
        }

        // GET: StatusUsuarioModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusUsuarioModel == null)
            {
                return NotFound();
            }

            var statusUsuarioModel = await _context.StatusUsuarioModel.FindAsync(id);
            if (statusUsuarioModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioModelId"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", statusUsuarioModel.UsuarioModelId);
            return View(statusUsuarioModel);
        }

        // POST: StatusUsuarioModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatusUsuario,DescStatusUsuario,UsuarioModelId")] StatusUsuarioModel statusUsuarioModel)
        {
            if (id != statusUsuarioModel.IdStatusUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusUsuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusUsuarioModelExists(statusUsuarioModel.IdStatusUsuario))
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
            ViewData["UsuarioModelId"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", statusUsuarioModel.UsuarioModelId);
            return View(statusUsuarioModel);
        }

        // GET: StatusUsuarioModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusUsuarioModel == null)
            {
                return NotFound();
            }

            var statusUsuarioModel = await _context.StatusUsuarioModel
                .Include(s => s.UsuarioModel)
                .FirstOrDefaultAsync(m => m.IdStatusUsuario == id);
            if (statusUsuarioModel == null)
            {
                return NotFound();
            }

            return View(statusUsuarioModel);
        }

        // POST: StatusUsuarioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusUsuarioModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.StatusUsuarioModel'  is null.");
            }
            var statusUsuarioModel = await _context.StatusUsuarioModel.FindAsync(id);
            if (statusUsuarioModel != null)
            {
                _context.StatusUsuarioModel.Remove(statusUsuarioModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusUsuarioModelExists(int id)
        {
          return (_context.StatusUsuarioModel?.Any(e => e.IdStatusUsuario == id)).GetValueOrDefault();
        }
    }
}
