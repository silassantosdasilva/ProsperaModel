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
    public class MetaModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public MetaModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: MetaModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.MetaModel.Include(m => m.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: MetaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MetaModel == null)
            {
                return NotFound();
            }

            var metaModel = await _context.MetaModel
                .Include(m => m.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdMeta == id);
            if (metaModel == null)
            {
                return NotFound();
            }

            return View(metaModel);
        }

        // GET: MetaModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioMeta"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: MetaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMeta,NomeMeta,DescMeta,DatInicioMeta,DataTerminoMeta,ValorMeta,StatusMeta,ObservacaoMeta,CatMeta,UsuarioMeta")] MetaModel metaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioMeta"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", metaModel.UsuarioMeta);
            return View(metaModel);
        }

        // GET: MetaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MetaModel == null)
            {
                return NotFound();
            }

            var metaModel = await _context.MetaModel.FindAsync(id);
            if (metaModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioMeta"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", metaModel.UsuarioMeta);
            return View(metaModel);
        }

        // POST: MetaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMeta,NomeMeta,DescMeta,DatInicioMeta,DataTerminoMeta,ValorMeta,StatusMeta,ObservacaoMeta,CatMeta,UsuarioMeta")] MetaModel metaModel)
        {
            if (id != metaModel.IdMeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetaModelExists(metaModel.IdMeta))
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
            ViewData["UsuarioMeta"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", metaModel.UsuarioMeta);
            return View(metaModel);
        }

        // GET: MetaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MetaModel == null)
            {
                return NotFound();
            }

            var metaModel = await _context.MetaModel
                .Include(m => m.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdMeta == id);
            if (metaModel == null)
            {
                return NotFound();
            }

            return View(metaModel);
        }

        // POST: MetaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MetaModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.MetaModel'  is null.");
            }
            var metaModel = await _context.MetaModel.FindAsync(id);
            if (metaModel != null)
            {
                _context.MetaModel.Remove(metaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetaModelExists(int id)
        {
          return (_context.MetaModel?.Any(e => e.IdMeta == id)).GetValueOrDefault();
        }
    }
}
