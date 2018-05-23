using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.StaffData.Models;

namespace Hospital.Modules.StaffData
{
    public class StaffdatasController : Controller
    {
        private readonly HospitalContext _context;

        public StaffdatasController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Staffdatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staffdatas.ToListAsync());
        }

        //Search
        public async Task<IActionResult> Search(string searchString)
        {
            var d = from attendance in _context.Staffdatas
                    select attendance;

            if (!String.IsNullOrEmpty(searchString))
            {
                d = d.Where(s => s.Staffid.Contains(searchString));
                //d = d.Where(s => s.Name.Contains(searchString));
            }

            return View(await d.ToListAsync());
        }

        // GET: Staffdatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffdatas = await _context.Staffdatas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (staffdatas == null)
            {
                return NotFound();
            }

            return View(staffdatas);
        }

        // GET: Staffdatas/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Staffdatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Staffid,Name,Date,Attendance")] Staffdatas staffdatas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffdatas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffdatas);
        }

        // GET: Staffdatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffdatas = await _context.Staffdatas.SingleOrDefaultAsync(m => m.Id == id);
            if (staffdatas == null)
            {
                return NotFound();
            }
            return View(staffdatas);
        }

        // POST: Staffdatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Staffid,Name,Date,Attendance")] Staffdatas staffdatas)
        {
            if (id != staffdatas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffdatas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffdatasExists(staffdatas.Id))
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
            return View(staffdatas);
        }

        // GET: Staffdatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffdatas = await _context.Staffdatas
                .SingleOrDefaultAsync(m => m.Id == id);
            if (staffdatas == null)
            {
                return NotFound();
            }

            return View(staffdatas);
        }

        // POST: Staffdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffdatas = await _context.Staffdatas.SingleOrDefaultAsync(m => m.Id == id);
            _context.Staffdatas.Remove(staffdatas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffdatasExists(int id)
        {
            return _context.Staffdatas.Any(e => e.Id == id);
        }
    }
}
