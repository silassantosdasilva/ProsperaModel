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
    public class DevedorModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public DevedorModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: DevedorModels
        public async Task<IActionResult> Index()
        {
              return _context.DevedorModel != null ? 
                          View(await _context.DevedorModel.ToListAsync()) :
                          Problem("Entity set 'ProsperaModelContext.DevedorModel'  is null.");
        }

        // GET: DevedorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DevedorModel == null)
            {
                return NotFound();
            }

            var devedorModel = await _context.DevedorModel
                .FirstOrDefaultAsync(m => m.IdDevedor == id);
            if (devedorModel == null)
            {
                return NotFound();
            }

            return View(devedorModel);
        }

        // GET: DevedorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DevedorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDevedor,NomDevedor,EmailDevedor,TeleDevedor,Tele2Devedor,EndereDevedor,CidadeDevedor,BairroDevedor,UFDevedor,CEPDevedor,ObservaDevedor,DatCadasDevedor,StatusDevedor,SaldoDevedor")] DevedorModel devedorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devedorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(devedorModel);
        }

        // GET: DevedorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DevedorModel == null)
            {
                return NotFound();
            }

            var devedorModel = await _context.DevedorModel.FindAsync(id);
            if (devedorModel == null)
            {
                return NotFound();
            }
            return View(devedorModel);
        }

        // POST: DevedorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDevedor,NomDevedor,EmailDevedor,TeleDevedor,Tele2Devedor,EndereDevedor,CidadeDevedor,BairroDevedor,UFDevedor,CEPDevedor,ObservaDevedor,DatCadasDevedor,StatusDevedor,SaldoDevedor")] DevedorModel devedorModel)
        {
            if (id != devedorModel.IdDevedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devedorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevedorModelExists(devedorModel.IdDevedor))
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
            return View(devedorModel);
        }

        // GET: DevedorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DevedorModel == null)
            {
                return NotFound();
            }

            var devedorModel = await _context.DevedorModel
                .FirstOrDefaultAsync(m => m.IdDevedor == id);
            if (devedorModel == null)
            {
                return NotFound();
            }

            return View(devedorModel);
        }

        // POST: DevedorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DevedorModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.DevedorModel'  is null.");
            }
            var devedorModel = await _context.DevedorModel.FindAsync(id);
            if (devedorModel != null)
            {
                _context.DevedorModel.Remove(devedorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevedorModelExists(int id)
        {
          return (_context.DevedorModel?.Any(e => e.IdDevedor == id)).GetValueOrDefault();
        }
    }
}
