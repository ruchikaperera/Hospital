using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.Wardddata.Models;

namespace Hospital.Modules.Wardddata.Controllers
{
    public class WarddatasController : Controller
    {
        private readonly HospitalContext _context;

        public WarddatasController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Warddatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Warddatas.ToListAsync());
        }

        //Search
        public async Task<IActionResult> Search(string searchString)
        {
            var d = from ward in _context.Warddatas
                    select ward;

            if (!String.IsNullOrEmpty(searchString))
            {
                d = d.Where(s => s.wardno.Contains(searchString));
            }

            return View(await d.ToListAsync());
        }


        // GET: Warddatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warddatas = await _context.Warddatas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (warddatas == null)
            {
                return NotFound();
            }

            return View(warddatas);
        }

        // GET: Warddatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Warddatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,wardno,date,description,status,NoOfBed")] Warddatas warddatas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warddatas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(warddatas);
        }

        // GET: Warddatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warddatas = await _context.Warddatas.SingleOrDefaultAsync(m => m.Id == id);
            if (warddatas == null)
            {
                return NotFound();
            }
            return View(warddatas);
        }

        // POST: Warddatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,wardno,date,description,status,NoOfBed")] Warddatas warddatas)
        {
            if (id != warddatas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warddatas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarddatasExists(warddatas.Id))
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
            return View(warddatas);
        }

        // GET: Warddatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warddatas = await _context.Warddatas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (warddatas == null)
            {
                return NotFound();
            }

            return View(warddatas);
        }

        // POST: Warddatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warddatas = await _context.Warddatas.SingleOrDefaultAsync(m => m.Id == id);
            _context.Warddatas.Remove(warddatas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarddatasExists(int id)
        {
            return _context.Warddatas.Any(e => e.Id == id);
        }
    }
}
