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
    public class ContaBancariaModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public ContaBancariaModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: ContaBancariaModels
        public async Task<IActionResult> Index()
        {
              return _context.ContaBancariaModel != null ? 
                          View(await _context.ContaBancariaModel.ToListAsync()) :
                          Problem("Entity set 'ProsperaModelContext.ContaBancariaModel'  is null.");
        }

        // GET: ContaBancariaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContaBancariaModel == null)
            {
                return NotFound();
            }

            var contaBancariaModel = await _context.ContaBancariaModel
                .FirstOrDefaultAsync(m => m.IdContBancaria == id);
            if (contaBancariaModel == null)
            {
                return NotFound();
            }

            return View(contaBancariaModel);
        }

        // GET: ContaBancariaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaBancariaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContBancaria,NomeTitulaContBan,NumContBan,AgenciaContBan,SaldoContBan,TipoContBan,ObsContBan")] ContaBancariaModel contaBancariaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaBancariaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaBancariaModel);
        }

        // GET: ContaBancariaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContaBancariaModel == null)
            {
                return NotFound();
            }

            var contaBancariaModel = await _context.ContaBancariaModel.FindAsync(id);
            if (contaBancariaModel == null)
            {
                return NotFound();
            }
            return View(contaBancariaModel);
        }

        // POST: ContaBancariaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContBancaria,NomeTitulaContBan,NumContBan,AgenciaContBan,SaldoContBan,TipoContBan,ObsContBan")] ContaBancariaModel contaBancariaModel)
        {
            if (id != contaBancariaModel.IdContBancaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaBancariaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaBancariaModelExists(contaBancariaModel.IdContBancaria))
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
            return View(contaBancariaModel);
        }

        // GET: ContaBancariaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContaBancariaModel == null)
            {
                return NotFound();
            }

            var contaBancariaModel = await _context.ContaBancariaModel
                .FirstOrDefaultAsync(m => m.IdContBancaria == id);
            if (contaBancariaModel == null)
            {
                return NotFound();
            }

            return View(contaBancariaModel);
        }

        // POST: ContaBancariaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContaBancariaModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.ContaBancariaModel'  is null.");
            }
            var contaBancariaModel = await _context.ContaBancariaModel.FindAsync(id);
            if (contaBancariaModel != null)
            {
                _context.ContaBancariaModel.Remove(contaBancariaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaBancariaModelExists(int id)
        {
          return (_context.ContaBancariaModel?.Any(e => e.IdContBancaria == id)).GetValueOrDefault();
        }
    }
}
