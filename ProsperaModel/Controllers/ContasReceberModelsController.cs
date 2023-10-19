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
    public class ContasReceberModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public ContasReceberModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: ContasReceberModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.ContasReceberModel.Include(c => c.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: ContasReceberModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContasReceberModel == null)
            {
                return NotFound();
            }

            var contasReceberModel = await _context.ContasReceberModel
                .Include(c => c.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdContasReceber == id);
            if (contasReceberModel == null)
            {
                return NotFound();
            }

            return View(contasReceberModel);
        }

        // GET: ContasReceberModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioCR"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: ContasReceberModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContasReceber,CodCR,DatEmissaoCR,DatVencimentoCR,DevedorCR,DescricaoCR,ValorCR,StatusCR,MetodoPgtoCR,ObservacaoCR,ContaBanCR,AgenciaContBanCR,UsuarioCR")] ContasReceberModel contasReceberModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contasReceberModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioCR"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", contasReceberModel.UsuarioCR);
            return View(contasReceberModel);
        }

        // GET: ContasReceberModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContasReceberModel == null)
            {
                return NotFound();
            }

            var contasReceberModel = await _context.ContasReceberModel.FindAsync(id);
            if (contasReceberModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioCR"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", contasReceberModel.UsuarioCR);
            return View(contasReceberModel);
        }

        // POST: ContasReceberModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContasReceber,CodCR,DatEmissaoCR,DatVencimentoCR,DevedorCR,DescricaoCR,ValorCR,StatusCR,MetodoPgtoCR,ObservacaoCR,ContaBanCR,AgenciaContBanCR,UsuarioCR")] ContasReceberModel contasReceberModel)
        {
            if (id != contasReceberModel.IdContasReceber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contasReceberModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContasReceberModelExists(contasReceberModel.IdContasReceber))
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
            ViewData["UsuarioCR"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", contasReceberModel.UsuarioCR);
            return View(contasReceberModel);
        }

        // GET: ContasReceberModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContasReceberModel == null)
            {
                return NotFound();
            }

            var contasReceberModel = await _context.ContasReceberModel
                .Include(c => c.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdContasReceber == id);
            if (contasReceberModel == null)
            {
                return NotFound();
            }

            return View(contasReceberModel);
        }

        // POST: ContasReceberModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContasReceberModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.ContasReceberModel'  is null.");
            }
            var contasReceberModel = await _context.ContasReceberModel.FindAsync(id);
            if (contasReceberModel != null)
            {
                _context.ContasReceberModel.Remove(contasReceberModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContasReceberModelExists(int id)
        {
          return (_context.ContasReceberModel?.Any(e => e.IdContasReceber == id)).GetValueOrDefault();
        }
    }
}
