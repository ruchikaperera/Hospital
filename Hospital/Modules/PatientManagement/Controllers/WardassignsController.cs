using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.PatientManagement.Models;

namespace Hospital.Modules.PatientManagement.Controllers
{
    public class WardassignsController : Controller
    {
        private readonly HospitalContext _context;

        public WardassignsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Wardassigns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wardassign.ToListAsync());
        }

        // GET: Wardassigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wardassign = await _context.Wardassign
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wardassign == null)
            {
                return NotFound();
            }

            return View(wardassign);
        }

        // GET: Wardassigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wardassigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,patientName,nicNo,date")] Wardassign wardassign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wardassign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wardassign);
        }

        // GET: Wardassigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wardassign = await _context.Wardassign.SingleOrDefaultAsync(m => m.Id == id);
            if (wardassign == null)
            {
                return NotFound();
            }
            return View(wardassign);
        }

        // POST: Wardassigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,patientName,nicNo,date")] Wardassign wardassign)
        {
            if (id != wardassign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wardassign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardassignExists(wardassign.Id))
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
            return View(wardassign);
        }

        // GET: Wardassigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wardassign = await _context.Wardassign
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wardassign == null)
            {
                return NotFound();
            }

            return View(wardassign);
        }

        // POST: Wardassigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wardassign = await _context.Wardassign.SingleOrDefaultAsync(m => m.Id == id);
            _context.Wardassign.Remove(wardassign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WardassignExists(int id)
        {
            return _context.Wardassign.Any(e => e.Id == id);
        }
    }
}
