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
    public class PatientDetailsController : Controller
    {
        private readonly HospitalContext _context;

        public PatientDetailsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: PatientDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientDetails.ToListAsync());
        }


        // GET: PatientDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientDetails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return View(patientDetails);
        }

        // GET: PatientDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,patientName,NicNo,Email,Wardno,Date_Cin,telephone,Address")] PatientDetails patientDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientDetails);
        }

        // GET: PatientDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (patientDetails == null)
            {
                return NotFound();
            }
            return View(patientDetails);
        }

        // POST: PatientDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,patientName,NicNo,Email,Wardno,Date_Cin,telephone,Address")] PatientDetails patientDetails)
        {
            if (id != patientDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDetailsExists(patientDetails.Id))
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
            return View(patientDetails);
        }

        // GET: PatientDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientDetails = await _context.PatientDetails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (patientDetails == null)
            {
                return NotFound();
            }

            return View(patientDetails);
        }

        // POST: PatientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientDetails = await _context.PatientDetails.SingleOrDefaultAsync(m => m.Id == id);
            _context.PatientDetails.Remove(patientDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDetailsExists(int id)
        {
            return _context.PatientDetails.Any(e => e.Id == id);
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
