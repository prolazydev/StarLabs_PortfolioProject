using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarLabs_PortfolioProject.Data;
using StarLabs_PortfolioProject.Models;

namespace StarLabs_PortfolioProject.Controllers
{
    public class ChordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chords
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chords.ToListAsync());
        }

        // GET: Chords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _context.Chords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chord == null)
            {
                return NotFound();
            }

            return View(chord);
        }

        // GET: Chords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,isItLearned")] Chord chord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chord);
        }

        // GET: Chords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _context.Chords.FindAsync(id);
            if (chord == null)
            {
                return NotFound();
            }
            return View(chord);
        }

        // POST: Chords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,isItLearned")] Chord chord)
        {
            if (id != chord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChordExists(chord.Id))
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
            return View(chord);
        }

        // GET: Chords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chord = await _context.Chords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chord == null)
            {
                return NotFound();
            }

            return View(chord);
        }

        // POST: Chords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chord = await _context.Chords.FindAsync(id);
            _context.Chords.Remove(chord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChordExists(int id)
        {
            return _context.Chords.Any(e => e.Id == id);
        }
    }
}
