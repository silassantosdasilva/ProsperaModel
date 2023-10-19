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
    public class StatusTransferenciaModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public StatusTransferenciaModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: StatusTransferenciaModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.StatusTransferenciaModel.Include(s => s.TransferenciaModel);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: StatusTransferenciaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusTransferenciaModel == null)
            {
                return NotFound();
            }

            var statusTransferenciaModel = await _context.StatusTransferenciaModel
                .Include(s => s.TransferenciaModel)
                .FirstOrDefaultAsync(m => m.IdStatusTransfe == id);
            if (statusTransferenciaModel == null)
            {
                return NotFound();
            }

            return View(statusTransferenciaModel);
        }

        // GET: StatusTransferenciaModels/Create
        public IActionResult Create()
        {
            ViewData["TransferenciaModelId"] = new SelectList(_context.Set<TransferenciaModel>(), "IdTransferencia", "IdTransferencia");
            return View();
        }

        // POST: StatusTransferenciaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatusTransfe,DescStatusTransfe,TransferenciaModelId")] StatusTransferenciaModel statusTransferenciaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusTransferenciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransferenciaModelId"] = new SelectList(_context.Set<TransferenciaModel>(), "IdTransferencia", "IdTransferencia", statusTransferenciaModel.TransferenciaModelId);
            return View(statusTransferenciaModel);
        }

        // GET: StatusTransferenciaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusTransferenciaModel == null)
            {
                return NotFound();
            }

            var statusTransferenciaModel = await _context.StatusTransferenciaModel.FindAsync(id);
            if (statusTransferenciaModel == null)
            {
                return NotFound();
            }
            ViewData["TransferenciaModelId"] = new SelectList(_context.Set<TransferenciaModel>(), "IdTransferencia", "IdTransferencia", statusTransferenciaModel.TransferenciaModelId);
            return View(statusTransferenciaModel);
        }

        // POST: StatusTransferenciaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatusTransfe,DescStatusTransfe,TransferenciaModelId")] StatusTransferenciaModel statusTransferenciaModel)
        {
            if (id != statusTransferenciaModel.IdStatusTransfe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusTransferenciaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusTransferenciaModelExists(statusTransferenciaModel.IdStatusTransfe))
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
            ViewData["TransferenciaModelId"] = new SelectList(_context.Set<TransferenciaModel>(), "IdTransferencia", "IdTransferencia", statusTransferenciaModel.TransferenciaModelId);
            return View(statusTransferenciaModel);
        }

        // GET: StatusTransferenciaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusTransferenciaModel == null)
            {
                return NotFound();
            }

            var statusTransferenciaModel = await _context.StatusTransferenciaModel
                .Include(s => s.TransferenciaModel)
                .FirstOrDefaultAsync(m => m.IdStatusTransfe == id);
            if (statusTransferenciaModel == null)
            {
                return NotFound();
            }

            return View(statusTransferenciaModel);
        }

        // POST: StatusTransferenciaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusTransferenciaModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.StatusTransferenciaModel'  is null.");
            }
            var statusTransferenciaModel = await _context.StatusTransferenciaModel.FindAsync(id);
            if (statusTransferenciaModel != null)
            {
                _context.StatusTransferenciaModel.Remove(statusTransferenciaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusTransferenciaModelExists(int id)
        {
          return (_context.StatusTransferenciaModel?.Any(e => e.IdStatusTransfe == id)).GetValueOrDefault();
        }
    }
}
