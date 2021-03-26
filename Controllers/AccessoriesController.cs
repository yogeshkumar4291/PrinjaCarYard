using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrinjaCarYard.Data;
using PrinjaCarYard.Models;

namespace PrinjaCarYard.Controllers
{[Authorize]
    public class AccessoriesController : Controller
    {
        private readonly CarDbContext _context;

        public AccessoriesController(CarDbContext context)
        {
            _context = context;
        }

        // GET: Accessories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accessorie.ToListAsync());
        }

        // GET: Accessories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessorie = await _context.Accessorie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accessorie == null)
            {
                return NotFound();
            }

            return View(accessorie);
        }

        // GET: Accessories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,price")] Accessorie accessorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accessorie);
        }

        // GET: Accessories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessorie = await _context.Accessorie.FindAsync(id);
            if (accessorie == null)
            {
                return NotFound();
            }
            return View(accessorie);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,price")] Accessorie accessorie)
        {
            if (id != accessorie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessorieExists(accessorie.ID))
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
            return View(accessorie);
        }

        // GET: Accessories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessorie = await _context.Accessorie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accessorie == null)
            {
                return NotFound();
            }

            return View(accessorie);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessorie = await _context.Accessorie.FindAsync(id);
            _context.Accessorie.Remove(accessorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessorieExists(int id)
        {
            return _context.Accessorie.Any(e => e.ID == id);
        }
    }
}
