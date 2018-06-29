using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrsWebsite.Models;

namespace SrsWebsite.Controllers
{
    public class ShootingTypesController : Controller
    {
        private readonly SrsContext _context;

        public ShootingTypesController(SrsContext context)
        {
            _context = context;
        }

        // GET: ShootingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShootingTypes.ToListAsync());
        }

        // GET: ShootingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shootingType = await _context.ShootingTypes
                .SingleOrDefaultAsync(m => m.ShootingTypeId == id);
            if (shootingType == null)
            {
                return NotFound();
            }

            return View(shootingType);
        }

        // GET: ShootingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShootingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShootingTypeId,Name,Price")] ShootingType shootingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shootingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shootingType);
        }

        // GET: ShootingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shootingType = await _context.ShootingTypes.SingleOrDefaultAsync(m => m.ShootingTypeId == id);
            if (shootingType == null)
            {
                return NotFound();
            }
            return View(shootingType);
        }

        // POST: ShootingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShootingTypeId,Name,Price")] ShootingType shootingType)
        {
            if (id != shootingType.ShootingTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shootingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShootingTypeExists(shootingType.ShootingTypeId))
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
            return View(shootingType);
        }

        // GET: ShootingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shootingType = await _context.ShootingTypes
                .SingleOrDefaultAsync(m => m.ShootingTypeId == id);
            if (shootingType == null)
            {
                return NotFound();
            }

            return View(shootingType);
        }

        // POST: ShootingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shootingType = await _context.ShootingTypes.SingleOrDefaultAsync(m => m.ShootingTypeId == id);
            _context.ShootingTypes.Remove(shootingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShootingTypeExists(int id)
        {
            return _context.ShootingTypes.Any(e => e.ShootingTypeId == id);
        }
    }
}
