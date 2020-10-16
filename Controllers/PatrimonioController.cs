using CrudPatrimonioEmpresarial.Data;
using CrudPatrimonioEmpresarial.Models.Patrimonio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPatrimonioEmpresarial.Controllers
{
    [Authorize]
    public class PatrimonioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatrimonioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patrimonio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patrimonio.ToListAsync());
        }

        // GET: Patrimonio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrimonio = await _context.Patrimonio
                .FirstOrDefaultAsync(m => m.MarcaId == id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            return View(patrimonio);
        }

        // GET: Patrimonio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,MarcaId,Descricao,NumeroTombo")] Patrimonio patrimonio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrimonio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrimonio);
        }

        // GET: Patrimonio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrimonio = await _context.Patrimonio.FindAsync(id);
            if (patrimonio == null)
            {
                return NotFound();
            }
            return View(patrimonio);
        }

        // POST: Patrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,MarcaId,Descricao,NumeroTombo")] Patrimonio patrimonio)
        {
            if (id != patrimonio.MarcaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrimonio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrimonioExists(patrimonio.MarcaId))
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
            return View(patrimonio);
        }

        // GET: Patrimonio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrimonio = await _context.Patrimonio
                .FirstOrDefaultAsync(m => m.MarcaId == id);
            if (patrimonio == null)
            {
                return NotFound();
            }

            return View(patrimonio);
        }

        // POST: Patrimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrimonio = await _context.Patrimonio.FindAsync(id);
            _context.Patrimonio.Remove(patrimonio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrimonioExists(int id)
        {
            return _context.Patrimonio.Any(e => e.MarcaId == id);
        }
    }
}