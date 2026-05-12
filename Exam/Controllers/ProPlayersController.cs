using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exam.Models;
using FragTracker.Data;

namespace Exam.Controllers
{
    public class ProPlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProPlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProPlayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProPlayers.ToListAsync());
        }

        // GET: ProPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proPlayer = await _context.ProPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proPlayer == null)
            {
                return NotFound();
            }

            return View(proPlayer);
        }

        // GET: ProPlayers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProPlayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nickname,Team,Game,Rating")] ProPlayer proPlayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proPlayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proPlayer);
        }

        // GET: ProPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proPlayer = await _context.ProPlayers.FindAsync(id);
            if (proPlayer == null)
            {
                return NotFound();
            }
            return View(proPlayer);
        }

        // POST: ProPlayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nickname,Team,Game,Rating")] ProPlayer proPlayer)
        {
            if (id != proPlayer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProPlayerExists(proPlayer.Id))
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
            return View(proPlayer);
        }

        // GET: ProPlayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proPlayer = await _context.ProPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proPlayer == null)
            {
                return NotFound();
            }

            return View(proPlayer);
        }

        // POST: ProPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proPlayer = await _context.ProPlayers.FindAsync(id);
            if (proPlayer != null)
            {
                _context.ProPlayers.Remove(proPlayer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProPlayerExists(int id)
        {
            return _context.ProPlayers.Any(e => e.Id == id);
        }
    }
}
