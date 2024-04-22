using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaProgreso1.Data;
using PracticaProgreso1.Models;

namespace PracticaProgreso1.Controllers
{
    public class PRobalinoesController : Controller
    {
        private readonly PracticaProgreso1Context _context;

        public PRobalinoesController(PracticaProgreso1Context context)
        {
            _context = context;
        }

        // GET: PRobalinoes
        public async Task<IActionResult> Index()
        {
            var practicaProgreso1Context = _context.PRobalino.Include(p => p.Carrera);
            return View(await practicaProgreso1Context.ToListAsync());
        }

        // GET: PRobalinoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRobalino = await _context.PRobalino
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRobalino == null)
            {
                return NotFound();
            }

            return View(pRobalino);
        }

        // GET: PRobalinoes/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "Campus");
            return View();
        }

        // POST: PRobalinoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Edad,Salario,Nombre,EsActivo,FechaRegistro,CarreraId")] PRobalino pRobalino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pRobalino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "Campus", pRobalino.CarreraId);
            return View(pRobalino);
        }

        // GET: PRobalinoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRobalino = await _context.PRobalino.FindAsync(id);
            if (pRobalino == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "Campus", pRobalino.CarreraId);
            return View(pRobalino);
        }

        // POST: PRobalinoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Edad,Salario,Nombre,EsActivo,FechaRegistro,CarreraId")] PRobalino pRobalino)
        {
            if (id != pRobalino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pRobalino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PRobalinoExists(pRobalino.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "CarreraId", "Campus", pRobalino.CarreraId);
            return View(pRobalino);
        }

        // GET: PRobalinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRobalino = await _context.PRobalino
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRobalino == null)
            {
                return NotFound();
            }

            return View(pRobalino);
        }

        // POST: PRobalinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pRobalino = await _context.PRobalino.FindAsync(id);
            if (pRobalino != null)
            {
                _context.PRobalino.Remove(pRobalino);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PRobalinoExists(int id)
        {
            return _context.PRobalino.Any(e => e.Id == id);
        }
    }
}
