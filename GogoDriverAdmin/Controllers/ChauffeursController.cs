using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GogoDriver.Models;

namespace GogoDriver.Controllers
{
    public class ChauffeursController : Controller
    {
        private readonly GogoBdContext _context;

        public ChauffeursController(GogoBdContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs
        public async Task<IActionResult> Index()
        {
            var gogoBdContext = _context.Chauffeurs.Include(c => c.IdPersonneNavigation);
            return View(await gogoBdContext.ToListAsync());
        }

        // GET: Chauffeurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Chauffeurs == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs
                .Include(c => c.IdPersonneNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonne == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // GET: Chauffeurs/Create
        public IActionResult Create()
        {
            ViewData["IdPersonne"] = new SelectList(_context.Personnes, "IdPersonne", "IdPersonne");
            return View();
        }

        // POST: Chauffeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonne,IdChauffeur,NumPermi,NumCapacite,EtatChauffeur")] Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chauffeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonne"] = new SelectList(_context.Personnes, "IdPersonne", "IdPersonne", chauffeur.IdPersonne);
            return View(chauffeur);
        }

        // GET: Chauffeurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Chauffeurs == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs.FindAsync(id);
            if (chauffeur == null)
            {
                return NotFound();
            }
            ViewData["IdPersonne"] = new SelectList(_context.Personnes, "IdPersonne", "IdPersonne", chauffeur.IdPersonne);
            return View(chauffeur);
        }

        // POST: Chauffeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPersonne,IdChauffeur,NumPermi,NumCapacite,EtatChauffeur")] Chauffeur chauffeur)
        {
            if (id != chauffeur.IdPersonne)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChauffeurExists(chauffeur.IdPersonne))
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
            ViewData["IdPersonne"] = new SelectList(_context.Personnes, "IdPersonne", "IdPersonne", chauffeur.IdPersonne);
            return View(chauffeur);
        }

        // GET: Chauffeurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Chauffeurs == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs
                .Include(c => c.IdPersonneNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonne == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // POST: Chauffeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Chauffeurs == null)
            {
                return Problem("Entity set 'GogoBdContext.Chauffeurs'  is null.");
            }
            var chauffeur = await _context.Chauffeurs.FindAsync(id);
            if (chauffeur != null)
            {
                _context.Chauffeurs.Remove(chauffeur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChauffeurExists(string id)
        {
          return (_context.Chauffeurs?.Any(e => e.IdPersonne == id)).GetValueOrDefault();
        }
    }
}
