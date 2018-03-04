using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.Doctors_Profile.Models;

namespace Hospital.Modules.Doctors_Profile.Controllers
{
    public class ReportCountsController : Controller
    {
        private readonly HospitalContext _context;

        public ReportCountsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: ReportCounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportCount.ToListAsync());
        }

        // GET: ReportCounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCount = await _context.ReportCount
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reportCount == null)
            {
                return NotFound();
            }

            return View(reportCount);
        }

        // GET: ReportCounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportCounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Count")] ReportCount reportCount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportCount);
                await _context.SaveChangesAsync();
               // return RedirectToAction(nameof(Index));
            }
            return View(reportCount);
        }

        // GET: ReportCounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportCount = await _context.ReportCount.SingleOrDefaultAsync(m => m.Id == id);
            if (reportCount == null)
            {
                return NotFound();
            }
            return View(reportCount);
        }

        // POST: ReportCounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Count")] ReportCount reportCount)
        {
            if (id != reportCount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportCount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportCountExists(reportCount.Id))
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
            return View(reportCount);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetReportCount(int id, [Bind("Id,Count")] ReportCount reportCount)
        {
            reportCount.Count = 0;
            if (id != reportCount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportCount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportCountExists(reportCount.Id))
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
            return View(reportCount);
        }

       

        // POST: ReportCounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportCount = await _context.ReportCount.SingleOrDefaultAsync(m => m.Id == id);
            _context.ReportCount.Remove(reportCount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportCountExists(int id)
        {
            return _context.ReportCount.Any(e => e.Id == id);
        }
    }
}
