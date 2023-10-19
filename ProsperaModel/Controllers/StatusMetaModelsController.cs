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
    public class StatusMetaModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public StatusMetaModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: StatusMetaModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.StatusMetaModel.Include(s => s.MetaModel);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: StatusMetaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusMetaModel == null)
            {
                return NotFound();
            }

            var statusMetaModel = await _context.StatusMetaModel
                .Include(s => s.MetaModel)
                .FirstOrDefaultAsync(m => m.IdStatusMeta == id);
            if (statusMetaModel == null)
            {
                return NotFound();
            }

            return View(statusMetaModel);
        }

        // GET: StatusMetaModels/Create
        public IActionResult Create()
        {
            ViewData["MetaModelId"] = new SelectList(_context.MetaModel, "IdMeta", "IdMeta");
            return View();
        }

        // POST: StatusMetaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatusMeta,DescStatusMeta,MetaModelId")] StatusMetaModel statusMetaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusMetaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MetaModelId"] = new SelectList(_context.MetaModel, "IdMeta", "IdMeta", statusMetaModel.MetaModelId);
            return View(statusMetaModel);
        }

        // GET: StatusMetaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusMetaModel == null)
            {
                return NotFound();
            }

            var statusMetaModel = await _context.StatusMetaModel.FindAsync(id);
            if (statusMetaModel == null)
            {
                return NotFound();
            }
            ViewData["MetaModelId"] = new SelectList(_context.MetaModel, "IdMeta", "IdMeta", statusMetaModel.MetaModelId);
            return View(statusMetaModel);
        }

        // POST: StatusMetaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatusMeta,DescStatusMeta,MetaModelId")] StatusMetaModel statusMetaModel)
        {
            if (id != statusMetaModel.IdStatusMeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusMetaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusMetaModelExists(statusMetaModel.IdStatusMeta))
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
            ViewData["MetaModelId"] = new SelectList(_context.MetaModel, "IdMeta", "IdMeta", statusMetaModel.MetaModelId);
            return View(statusMetaModel);
        }

        // GET: StatusMetaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusMetaModel == null)
            {
                return NotFound();
            }

            var statusMetaModel = await _context.StatusMetaModel
                .Include(s => s.MetaModel)
                .FirstOrDefaultAsync(m => m.IdStatusMeta == id);
            if (statusMetaModel == null)
            {
                return NotFound();
            }

            return View(statusMetaModel);
        }

        // POST: StatusMetaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusMetaModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.StatusMetaModel'  is null.");
            }
            var statusMetaModel = await _context.StatusMetaModel.FindAsync(id);
            if (statusMetaModel != null)
            {
                _context.StatusMetaModel.Remove(statusMetaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusMetaModelExists(int id)
        {
          return (_context.StatusMetaModel?.Any(e => e.IdStatusMeta == id)).GetValueOrDefault();
        }
    }
}
