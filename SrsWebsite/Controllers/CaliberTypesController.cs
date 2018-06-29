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
    public class CaliberTypesController : Controller
    {
        private readonly SrsContext _context;

        public CaliberTypesController(SrsContext context)
        {
            _context = context;
        }

        // GET: CaliberTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaliberTypes.ToListAsync());
        }

        // GET: CaliberTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caliberType = await _context.CaliberTypes
                .SingleOrDefaultAsync(m => m.CaliberTypeId == id);
            if (caliberType == null)
            {
                return NotFound();
            }

            return View(caliberType);
        }

        // GET: CaliberTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaliberTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaliberTypeId,CaliberName")] CaliberType caliberType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caliberType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caliberType);
        }

        // GET: CaliberTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caliberType = await _context.CaliberTypes.SingleOrDefaultAsync(m => m.CaliberTypeId == id);
            if (caliberType == null)
            {
                return NotFound();
            }
            return View(caliberType);
        }

        // POST: CaliberTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaliberTypeId,CaliberName")] CaliberType caliberType)
        {
            if (id != caliberType.CaliberTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caliberType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaliberTypeExists(caliberType.CaliberTypeId))
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
            return View(caliberType);
        }

        // GET: CaliberTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caliberType = await _context.CaliberTypes
                .SingleOrDefaultAsync(m => m.CaliberTypeId == id);
            if (caliberType == null)
            {
                return NotFound();
            }

            return View(caliberType);
        }

        // POST: CaliberTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caliberType = await _context.CaliberTypes.SingleOrDefaultAsync(m => m.CaliberTypeId == id);
            _context.CaliberTypes.Remove(caliberType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaliberTypeExists(int id)
        {
            return _context.CaliberTypes.Any(e => e.CaliberTypeId == id);
        }
    }
}
