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
    public class ShootingsController : Controller
    {
        private readonly SrsContext _context;

        public ShootingsController(SrsContext context)
        {
            _context = context;
        }

        // GET: Shootings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shootings.ToListAsync());
        }

        // GET: Shootings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shooting = await _context.Shootings
                .SingleOrDefaultAsync(m => m.ShootingId == id);
            if (shooting == null)
            {
                return NotFound();
            }

            return View(shooting);
        }

        // GET: Shootings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shootings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShootingId,NumberOfShoots,CreationDateTime,IsFinished")] Shooting shooting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shooting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shooting);
        }

        // GET: Shootings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shooting = await _context.Shootings.SingleOrDefaultAsync(m => m.ShootingId == id);
            if (shooting == null)
            {
                return NotFound();
            }
            return View(shooting);
        }

        // POST: Shootings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShootingId,NumberOfShoots,CreationDateTime,IsFinished")] Shooting shooting)
        {
            if (id != shooting.ShootingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shooting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShootingExists(shooting.ShootingId))
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
            return View(shooting);
        }

        // GET: Shootings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shooting = await _context.Shootings
                .SingleOrDefaultAsync(m => m.ShootingId == id);
            if (shooting == null)
            {
                return NotFound();
            }

            return View(shooting);
        }

        // POST: Shootings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shooting = await _context.Shootings.SingleOrDefaultAsync(m => m.ShootingId == id);
            _context.Shootings.Remove(shooting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShootingExists(int id)
        {
            return _context.Shootings.Any(e => e.ShootingId == id);
        }
    }
}
