using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.StaffManagement.Models;

namespace Hospital.Modules.StaffManagement.Controllers
{
    public class staffTasksController : Controller
    {
        private readonly HospitalContext _context;

        public staffTasksController(HospitalContext context)
        {
            _context = context;
        }

        // GET: staffTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.staffTasks.ToListAsync());
        }

        // GET: staffTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTasks = await _context.staffTasks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (staffTasks == null)
            {
                return NotFound();
            }

            return View(staffTasks);
        }

        // GET: staffTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: staffTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,taskHeading,taskDetails,taskOwner,taskHolder,Date")] staffTasks staffTasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffTasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffTasks);
        }

        // GET: staffTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTasks = await _context.staffTasks.SingleOrDefaultAsync(m => m.Id == id);
            if (staffTasks == null)
            {
                return NotFound();
            }
            return View(staffTasks);
        }

        // POST: staffTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,taskHeading,taskDetails,taskOwner,taskHolder,Date")] staffTasks staffTasks)
        {
            if (id != staffTasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffTasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!staffTasksExists(staffTasks.Id))
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
            return View(staffTasks);
        }

        // GET: staffTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTasks = await _context.staffTasks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (staffTasks == null)
            {
                return NotFound();
            }

            return View(staffTasks);
        }

        // POST: staffTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffTasks = await _context.staffTasks.SingleOrDefaultAsync(m => m.Id == id);
            _context.staffTasks.Remove(staffTasks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool staffTasksExists(int id)
        {
            return _context.staffTasks.Any(e => e.Id == id);
        }
    }
}
