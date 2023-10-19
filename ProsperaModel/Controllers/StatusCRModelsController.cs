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
    public class StatusCRModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public StatusCRModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: StatusCRModels
        public async Task<IActionResult> Index()
        {
              return _context.StatusCRModel != null ? 
                          View(await _context.StatusCRModel.ToListAsync()) :
                          Problem("Entity set 'ProsperaModelContext.StatusCRModel'  is null.");
        }

        // GET: StatusCRModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusCRModel == null)
            {
                return NotFound();
            }

            var statusCRModel = await _context.StatusCRModel
                .FirstOrDefaultAsync(m => m.IdStatusCR == id);
            if (statusCRModel == null)
            {
                return NotFound();
            }

            return View(statusCRModel);
        }

        // GET: StatusCRModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusCRModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatusCR,DescStatusCR,CRModel")] StatusCRModel statusCRModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusCRModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusCRModel);
        }

        // GET: StatusCRModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusCRModel == null)
            {
                return NotFound();
            }

            var statusCRModel = await _context.StatusCRModel.FindAsync(id);
            if (statusCRModel == null)
            {
                return NotFound();
            }
            return View(statusCRModel);
        }

        // POST: StatusCRModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatusCR,DescStatusCR,CRModel")] StatusCRModel statusCRModel)
        {
            if (id != statusCRModel.IdStatusCR)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusCRModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusCRModelExists(statusCRModel.IdStatusCR))
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
            return View(statusCRModel);
        }

        // GET: StatusCRModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusCRModel == null)
            {
                return NotFound();
            }

            var statusCRModel = await _context.StatusCRModel
                .FirstOrDefaultAsync(m => m.IdStatusCR == id);
            if (statusCRModel == null)
            {
                return NotFound();
            }

            return View(statusCRModel);
        }

        // POST: StatusCRModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusCRModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.StatusCRModel'  is null.");
            }
            var statusCRModel = await _context.StatusCRModel.FindAsync(id);
            if (statusCRModel != null)
            {
                _context.StatusCRModel.Remove(statusCRModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusCRModelExists(int id)
        {
          return (_context.StatusCRModel?.Any(e => e.IdStatusCR == id)).GetValueOrDefault();
        }
    }
}
