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
    public class ContasPagarModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public ContasPagarModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: ContasPagarModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.ContasPagarModel.Include(c => c.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: ContasPagarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContasPagarModel == null)
            {
                return NotFound();
            }

            var contasPagarModel = await _context.ContasPagarModel
                .Include(c => c.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdContasPagar == id);
            if (contasPagarModel == null)
            {
                return NotFound();
            }

            return View(contasPagarModel);
        }

        // GET: ContasPagarModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioCP"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: ContasPagarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContasPagar,CodCP,DatEmissaoCP,DatVencimentoCP,DevedorCP,DescricaoCP,ValorCP,StatusCP,MetodoPgtoCP,ObservacaoCP,ContaBanCP,AgenciaContBanCP,UsuarioCP")] ContasPagarModel contasPagarModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contasPagarModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioCP"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", contasPagarModel.UsuarioCP);
            return View(contasPagarModel);
        }

        // GET: ContasPagarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContasPagarModel == null)
            {
                return NotFound();
            }

            var contasPagarModel = await _context.ContasPagarModel.FindAsync(id);
            if (contasPagarModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioCP"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", contasPagarModel.UsuarioCP);
            return View(contasPagarModel);
        }

        // POST: ContasPagarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContasPagar,CodCP,DatEmissaoCP,DatVencimentoCP,DevedorCP,DescricaoCP,ValorCP,StatusCP,MetodoPgtoCP,ObservacaoCP,ContaBanCP,AgenciaContBanCP,UsuarioCP")] ContasPagarModel contasPagarModel)
        {
            if (id != contasPagarModel.IdContasPagar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contasPagarModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContasPagarModelExists(contasPagarModel.IdContasPagar))
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
            ViewData["UsuarioCP"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", contasPagarModel.UsuarioCP);
            return View(contasPagarModel);
        }

        // GET: ContasPagarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContasPagarModel == null)
            {
                return NotFound();
            }

            var contasPagarModel = await _context.ContasPagarModel
                .Include(c => c.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdContasPagar == id);
            if (contasPagarModel == null)
            {
                return NotFound();
            }

            return View(contasPagarModel);
        }

        // POST: ContasPagarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContasPagarModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.ContasPagarModel'  is null.");
            }
            var contasPagarModel = await _context.ContasPagarModel.FindAsync(id);
            if (contasPagarModel != null)
            {
                _context.ContasPagarModel.Remove(contasPagarModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasPagarModelExists(int id)
        {
          return (_context.ContasPagarModel?.Any(e => e.IdContasPagar == id)).GetValueOrDefault();
        }
    }
}
