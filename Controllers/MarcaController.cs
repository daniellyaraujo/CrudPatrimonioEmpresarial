﻿using CrudPatrimonioEmpresarial.Data;
using CrudPatrimonioEmpresarial.Models.Marca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPatrimonioEmpresarial.Controllers
{
    [Authorize]
    public class MarcaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarcaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marca
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marca.ToListAsync());
        }

        // GET: Marca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marca/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,MarcaId")] Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,MarcaId")] Marca marca)
        {
            if (id != marca.MarcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.MarcaId))
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
            return View(marca);
        }

        // GET: Marca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.MarcaId == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(e => e.MarcaId == id);
        }
    }
}