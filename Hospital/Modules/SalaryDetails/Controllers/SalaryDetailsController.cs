using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.SalaryDetails.Model;

namespace Hospital.Modules.SalaryDetails.Controllers
{
    public class SalaryDetailsController : Controller
    {
        private readonly HospitalContext _context;

        public SalaryDetailsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: SalaryDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalaryDetails.ToListAsync());
        }

        public async Task<IActionResult> SalaryDetelilsForEmp()
        {
            return View(await _context.SalaryDetails.ToListAsync());
        }

        // GET: SalaryDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryDetail = await _context.SalaryDetails
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            return View(salaryDetail);
        }

        // GET: SalaryDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalaryDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NIC,ID,WorkingHrs,Rating")] SalaryDetail salaryDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryDetail);
        }

        // GET: SalaryDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryDetail = await _context.SalaryDetails.SingleOrDefaultAsync(m => m.ID == id);
            if (salaryDetail == null)
            {
                return NotFound();
            }
            return View(salaryDetail);
        }

        // POST: SalaryDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NIC,ID,WorkingHrs,Rating")] SalaryDetail salaryDetail)
        {
            if (id != salaryDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryDetailExists(salaryDetail.ID))
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
            return View(salaryDetail);
        }

        // GET: SalaryDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryDetail = await _context.SalaryDetails
                .SingleOrDefaultAsync(m => m.ID == id);
            if (salaryDetail == null)
            {
                return NotFound();
            }

            return View(salaryDetail);
        }

        // POST: SalaryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryDetail = await _context.SalaryDetails.SingleOrDefaultAsync(m => m.ID == id);
            _context.SalaryDetails.Remove(salaryDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryDetailExists(int id)
        {
            return _context.SalaryDetails.Any(e => e.ID == id);
        }
    }
}
