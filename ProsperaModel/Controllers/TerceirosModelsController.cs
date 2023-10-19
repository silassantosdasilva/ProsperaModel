using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsperaModel.Data;
using SeuProjeto.Models;

namespace ProsperaModel.Controllers
{
    public class TerceirosModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public TerceirosModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: TerceirosModels
        public async Task<IActionResult> Index()
        {
              return _context.TerceirosModel != null ? 
                          View(await _context.TerceirosModel.ToListAsync()) :
                          Problem("Entity set 'ProsperaModelContext.TerceirosModel'  is null.");
        }

        // GET: TerceirosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TerceirosModel == null)
            {
                return NotFound();
            }

            var terceirosModel = await _context.TerceirosModel
                .FirstOrDefaultAsync(m => m.IdTerceiros == id);
            if (terceirosModel == null)
            {
                return NotFound();
            }

            return View(terceirosModel);
        }

        // GET: TerceirosModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TerceirosModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTerceiros,NomeTerceiros,TelefoneTerceiros,Telefone2Terceiros,EmailTerceiros,EnderecoTerceiros,CidadeTerceiros,BairroTerceiros,UFTerceiros,CEPTerceiros,ObservacaoTerceiros,DataCadastroTerceiros,StatusTerceiros,SaldoTerceiros,IdContaBancariaModel")] TerceirosModel terceirosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terceirosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(terceirosModel);
        }

        // GET: TerceirosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TerceirosModel == null)
            {
                return NotFound();
            }

            var terceirosModel = await _context.TerceirosModel.FindAsync(id);
            if (terceirosModel == null)
            {
                return NotFound();
            }
            return View(terceirosModel);
        }

        // POST: TerceirosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTerceiros,NomeTerceiros,TelefoneTerceiros,Telefone2Terceiros,EmailTerceiros,EnderecoTerceiros,CidadeTerceiros,BairroTerceiros,UFTerceiros,CEPTerceiros,ObservacaoTerceiros,DataCadastroTerceiros,StatusTerceiros,SaldoTerceiros,IdContaBancariaModel")] TerceirosModel terceirosModel)
        {
            if (id != terceirosModel.IdTerceiros)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terceirosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceirosModelExists(terceirosModel.IdTerceiros))
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
            return View(terceirosModel);
        }

        // GET: TerceirosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TerceirosModel == null)
            {
                return NotFound();
            }

            var terceirosModel = await _context.TerceirosModel
                .FirstOrDefaultAsync(m => m.IdTerceiros == id);
            if (terceirosModel == null)
            {
                return NotFound();
            }

            return View(terceirosModel);
        }

        // POST: TerceirosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TerceirosModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.TerceirosModel'  is null.");
            }
            var terceirosModel = await _context.TerceirosModel.FindAsync(id);
            if (terceirosModel != null)
            {
                _context.TerceirosModel.Remove(terceirosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceirosModelExists(int id)
        {
          return (_context.TerceirosModel?.Any(e => e.IdTerceiros == id)).GetValueOrDefault();
        }
    }
}
