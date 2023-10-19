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
    public class OrcamentoModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public OrcamentoModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: OrcamentoModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.OrcamentoModel.Include(o => o.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: OrcamentoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrcamentoModel == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.OrcamentoModel
                .Include(o => o.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdOrcamento == id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }

            return View(orcamentoModel);
        }

        // GET: OrcamentoModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioOrca"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: OrcamentoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrcamento,NomeOrca,DatEmissaoOrca,DataValidadeOrca,DescricaoOrca,ValorOrca,ObservacaoOrca,StatusOrca,NomeContatoOrca,TeleOrca,Tele2Orca,EmailOrca,EnderecoOrca,EstadoOrca,BairroOrca,UsuarioOrca")] OrcamentoModel orcamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioOrca"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", orcamentoModel.UsuarioOrca);
            return View(orcamentoModel);
        }

        // GET: OrcamentoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrcamentoModel == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.OrcamentoModel.FindAsync(id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioOrca"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", orcamentoModel.UsuarioOrca);
            return View(orcamentoModel);
        }

        // POST: OrcamentoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrcamento,NomeOrca,DatEmissaoOrca,DataValidadeOrca,DescricaoOrca,ValorOrca,ObservacaoOrca,StatusOrca,NomeContatoOrca,TeleOrca,Tele2Orca,EmailOrca,EnderecoOrca,EstadoOrca,BairroOrca,UsuarioOrca")] OrcamentoModel orcamentoModel)
        {
            if (id != orcamentoModel.IdOrcamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoModelExists(orcamentoModel.IdOrcamento))
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
            ViewData["UsuarioOrca"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", orcamentoModel.UsuarioOrca);
            return View(orcamentoModel);
        }

        // GET: OrcamentoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrcamentoModel == null)
            {
                return NotFound();
            }

            var orcamentoModel = await _context.OrcamentoModel
                .Include(o => o.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdOrcamento == id);
            if (orcamentoModel == null)
            {
                return NotFound();
            }

            return View(orcamentoModel);
        }

        // POST: OrcamentoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrcamentoModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.OrcamentoModel'  is null.");
            }
            var orcamentoModel = await _context.OrcamentoModel.FindAsync(id);
            if (orcamentoModel != null)
            {
                _context.OrcamentoModel.Remove(orcamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoModelExists(int id)
        {
          return (_context.OrcamentoModel?.Any(e => e.IdOrcamento == id)).GetValueOrDefault();
        }
    }
}
