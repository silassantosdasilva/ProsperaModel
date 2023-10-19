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
    public class TransferenciaModelsController : Controller
    {
        private readonly ProsperaModelContext _context;

        public TransferenciaModelsController(ProsperaModelContext context)
        {
            _context = context;
        }

        // GET: TransferenciaModels
        public async Task<IActionResult> Index()
        {
            var prosperaModelContext = _context.TransferenciaModel.Include(t => t.IdUsuario);
            return View(await prosperaModelContext.ToListAsync());
        }

        // GET: TransferenciaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransferenciaModel == null)
            {
                return NotFound();
            }

            var transferenciaModel = await _context.TransferenciaModel
                .Include(t => t.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdTransferencia == id);
            if (transferenciaModel == null)
            {
                return NotFound();
            }

            return View(transferenciaModel);
        }

        // GET: TransferenciaModels/Create
        public IActionResult Create()
        {
            ViewData["UsuarioTransfe"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: TransferenciaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransferencia,DestinatarioTransfe,NumContBan,AgenciaContBan,NomeBanTransfe,ValorTransfe,DescricaoTransfe,DatAgendaTransfere,TipoTransfe,UsuarioTransfe")] TransferenciaModel transferenciaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transferenciaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioTransfe"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", transferenciaModel.UsuarioTransfe);
            return View(transferenciaModel);
        }

        // GET: TransferenciaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransferenciaModel == null)
            {
                return NotFound();
            }

            var transferenciaModel = await _context.TransferenciaModel.FindAsync(id);
            if (transferenciaModel == null)
            {
                return NotFound();
            }
            ViewData["UsuarioTransfe"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", transferenciaModel.UsuarioTransfe);
            return View(transferenciaModel);
        }

        // POST: TransferenciaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransferencia,DestinatarioTransfe,NumContBan,AgenciaContBan,NomeBanTransfe,ValorTransfe,DescricaoTransfe,DatAgendaTransfere,TipoTransfe,UsuarioTransfe")] TransferenciaModel transferenciaModel)
        {
            if (id != transferenciaModel.IdTransferencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transferenciaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransferenciaModelExists(transferenciaModel.IdTransferencia))
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
            ViewData["UsuarioTransfe"] = new SelectList(_context.UsuarioModel, "IdUsuario", "EmailUsuario", transferenciaModel.UsuarioTransfe);
            return View(transferenciaModel);
        }

        // GET: TransferenciaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransferenciaModel == null)
            {
                return NotFound();
            }

            var transferenciaModel = await _context.TransferenciaModel
                .Include(t => t.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdTransferencia == id);
            if (transferenciaModel == null)
            {
                return NotFound();
            }

            return View(transferenciaModel);
        }

        // POST: TransferenciaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransferenciaModel == null)
            {
                return Problem("Entity set 'ProsperaModelContext.TransferenciaModel'  is null.");
            }
            var transferenciaModel = await _context.TransferenciaModel.FindAsync(id);
            if (transferenciaModel != null)
            {
                _context.TransferenciaModel.Remove(transferenciaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransferenciaModelExists(int id)
        {
          return (_context.TransferenciaModel?.Any(e => e.IdTransferencia == id)).GetValueOrDefault();
        }
    }
}
