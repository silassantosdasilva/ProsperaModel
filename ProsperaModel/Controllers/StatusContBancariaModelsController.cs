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
    public class StatusContBancariaModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public StatusContBancariaModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: StatusContBancariaModels
        public async Task<IActionResult> Index()
        {
              return _context.StatusContBancariaModel != null ? 
                          View(await _context.StatusContBancariaModel.ToListAsync()) :
                          Problem("Entity set 'ProsperaModelContext.StatusContBancariaModel'  is null.");
        }

        // GET: StatusContBancariaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusContBancariaModel == null)
            {
                return NotFound();
            }

            var statusContBancariaModel = await _context.StatusContBancariaModel
                .FirstOrDefaultAsync(m => m.IdStatusContBan == id);
            if (statusContBancariaModel == null)
            {
                return NotFound();
            }

            return View(statusContBancariaModel);
        }

        // GET: StatusContBancariaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusContBancariaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatusContBan,DescStatusContBan,ContBancariaModel")] StatusContBancariaModel statusContBancariaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusContBancariaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusContBancariaModel);
        }

        // GET: StatusContBancariaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusContBancariaModel == null)
            {
                return NotFound();
            }

            var statusContBancariaModel = await _context.StatusContBancariaModel.FindAsync(id);
            if (statusContBancariaModel == null)
            {
                return NotFound();
            }
            return View(statusContBancariaModel);
        }

        // POST: StatusContBancariaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatusContBan,DescStatusContBan,ContBancariaModel")] StatusContBancariaModel statusContBancariaModel)
        {
            if (id != statusContBancariaModel.IdStatusContBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusContBancariaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusContBancariaModelExists(statusContBancariaModel.IdStatusContBan))
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
            return View(statusContBancariaModel);
        }

        // GET: StatusContBancariaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusContBancariaModel == null)
            {
                return NotFound();
            }

            var statusContBancariaModel = await _context.StatusContBancariaModel
                .FirstOrDefaultAsync(m => m.IdStatusContBan == id);
            if (statusContBancariaModel == null)
            {
                return NotFound();
            }

            return View(statusContBancariaModel);
        }

        // POST: StatusContBancariaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusContBancariaModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.StatusContBancariaModel'  is null.");
            }
            var statusContBancariaModel = await _context.StatusContBancariaModel.FindAsync(id);
            if (statusContBancariaModel != null)
            {
                _context.StatusContBancariaModel.Remove(statusContBancariaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusContBancariaModelExists(int id)
        {
          return (_context.StatusContBancariaModel?.Any(e => e.IdStatusContBan == id)).GetValueOrDefault();
        }
    }
}
