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
    public class LogInDetailsController : Controller
    {
        private readonly HospitalContext _context;

        public LogInDetailsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: LogInDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.LogInDetails.ToListAsync());
        }

        // GET: LogInDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logInDetails = await _context.LogInDetails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (logInDetails == null)
            {
                return NotFound();
            }

            return View(logInDetails);
        }

        // GET: LogInDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogInDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password,Position")] LogInDetails logInDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logInDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logInDetails);
        }

        // GET: LogInDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logInDetails = await _context.LogInDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (logInDetails == null)
            {
                return NotFound();
            }
            return View(logInDetails);
        }

        // POST: LogInDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,Position")] LogInDetails logInDetails)
        {
            if (id != logInDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logInDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogInDetailsExists(logInDetails.Id))
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
            return View(logInDetails);
        }

        // GET: LogInDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logInDetails = await _context.LogInDetails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (logInDetails == null)
            {
                return NotFound();
            }

            return View(logInDetails);
        }

        // POST: LogInDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logInDetails = await _context.LogInDetails.SingleOrDefaultAsync(m => m.Id == id);
            _context.LogInDetails.Remove(logInDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogInDetailsExists(int id)
        {
            return _context.LogInDetails.Any(e => e.Id == id);
        }
    }
}
