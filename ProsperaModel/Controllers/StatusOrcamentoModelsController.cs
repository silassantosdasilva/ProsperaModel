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
    public class StatusOrcamentoModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public StatusOrcamentoModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: StatusOrcamentoModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.StatusOrcamentoModel.Include(s => s.OrcamentoModel);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: StatusOrcamentoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusOrcamentoModel == null)
            {
                return NotFound();
            }

            var statusOrcamentoModel = await _context.StatusOrcamentoModel
                .Include(s => s.OrcamentoModel)
                .FirstOrDefaultAsync(m => m.IdStatusOrca == id);
            if (statusOrcamentoModel == null)
            {
                return NotFound();
            }

            return View(statusOrcamentoModel);
        }

        // GET: StatusOrcamentoModels/Create
        public IActionResult Create()
        {
            ViewData["OrcamentoModelId"] = new SelectList(_context.OrcamentoModel, "IdOrcamento", "IdOrcamento");
            return View();
        }

        // POST: StatusOrcamentoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatusOrca,DescStatusOrca,OrcamentoModelId")] StatusOrcamentoModel statusOrcamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusOrcamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrcamentoModelId"] = new SelectList(_context.OrcamentoModel, "IdOrcamento", "IdOrcamento", statusOrcamentoModel.OrcamentoModelId);
            return View(statusOrcamentoModel);
        }

        // GET: StatusOrcamentoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusOrcamentoModel == null)
            {
                return NotFound();
            }

            var statusOrcamentoModel = await _context.StatusOrcamentoModel.FindAsync(id);
            if (statusOrcamentoModel == null)
            {
                return NotFound();
            }
            ViewData["OrcamentoModelId"] = new SelectList(_context.OrcamentoModel, "IdOrcamento", "IdOrcamento", statusOrcamentoModel.OrcamentoModelId);
            return View(statusOrcamentoModel);
        }

        // POST: StatusOrcamentoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatusOrca,DescStatusOrca,OrcamentoModelId")] StatusOrcamentoModel statusOrcamentoModel)
        {
            if (id != statusOrcamentoModel.IdStatusOrca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusOrcamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusOrcamentoModelExists(statusOrcamentoModel.IdStatusOrca))
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
            ViewData["OrcamentoModelId"] = new SelectList(_context.OrcamentoModel, "IdOrcamento", "IdOrcamento", statusOrcamentoModel.OrcamentoModelId);
            return View(statusOrcamentoModel);
        }

        // GET: StatusOrcamentoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusOrcamentoModel == null)
            {
                return NotFound();
            }

            var statusOrcamentoModel = await _context.StatusOrcamentoModel
                .Include(s => s.OrcamentoModel)
                .FirstOrDefaultAsync(m => m.IdStatusOrca == id);
            if (statusOrcamentoModel == null)
            {
                return NotFound();
            }

            return View(statusOrcamentoModel);
        }

        // POST: StatusOrcamentoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusOrcamentoModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.StatusOrcamentoModel'  is null.");
            }
            var statusOrcamentoModel = await _context.StatusOrcamentoModel.FindAsync(id);
            if (statusOrcamentoModel != null)
            {
                _context.StatusOrcamentoModel.Remove(statusOrcamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusOrcamentoModelExists(int id)
        {
          return (_context.StatusOrcamentoModel?.Any(e => e.IdStatusOrca == id)).GetValueOrDefault();
        }
    }
}
