using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warframe_Inventory.Data;
using Warframe_Inventory.Entities;

namespace Warframe_Inventory.Controllers
{
    public class WarframesController : Controller
    {
        private readonly AppDbContext _context;

        public WarframesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Warframes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Warframes.ToListAsync());
        }

        // GET: Warframes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warframe = await _context.Warframes
                .FirstOrDefaultAsync(m => m.WarframeId == id);
            if (warframe == null)
            {
                return NotFound();
            }

            return View(warframe);
        }

        // GET: Warframes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Warframes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WarframeId,Name,Blueprints,Neuroptics,Chassis,Systems")] Warframe warframe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warframe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warframe);
        }

        // GET: Warframes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warframe = await _context.Warframes.FindAsync(id);
            if (warframe == null)
            {
                return NotFound();
            }
            return View(warframe);
        }

        // POST: Warframes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WarframeId,Name,Blueprints,Neuroptics,Chassis,Systems")] Warframe warframe)
        {
            if (id != warframe.WarframeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warframe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarframeExists(warframe.WarframeId))
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
            return View(warframe);
        }

        // GET: Warframes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warframe = await _context.Warframes
                .FirstOrDefaultAsync(m => m.WarframeId == id);
            if (warframe == null)
            {
                return NotFound();
            }

            return View(warframe);
        }

        // POST: Warframes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warframe = await _context.Warframes.FindAsync(id);
            if (warframe != null)
            {
                _context.Warframes.Remove(warframe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarframeExists(int id)
        {
            return _context.Warframes.Any(e => e.WarframeId == id);
        }
    }
}
