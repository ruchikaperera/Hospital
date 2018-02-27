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
    public class RequestFacilitiesController : Controller
    {
        private readonly HospitalContext _context;

        public RequestFacilitiesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: RequestFacilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestFacility.ToListAsync());
        }

        // GET: RequestFacilities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestFacility = await _context.RequestFacility
                .SingleOrDefaultAsync(m => m.Id == id);
            if (requestFacility == null)
            {
                return NotFound();
            }

            return View(requestFacility);
        }

        // GET: RequestFacilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestFacilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorName,Department,Topic,Description,Date")] RequestFacility requestFacility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestFacility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestFacility);
        }

        // GET: RequestFacilities/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestFacility = await _context.RequestFacility.SingleOrDefaultAsync(m => m.Id == id);
            if (requestFacility == null)
            {
                return NotFound();
            }
            return View(requestFacility);
        }

        // POST: RequestFacilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DoctorName,Department,Topic,Description,Date")] RequestFacility requestFacility)
        {
            if (id != requestFacility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestFacility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestFacilityExists(requestFacility.Id))
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
            return View(requestFacility);
        }

        // GET: RequestFacilities/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestFacility = await _context.RequestFacility
                .SingleOrDefaultAsync(m => m.Id == id);
            if (requestFacility == null)
            {
                return NotFound();
            }

            return View(requestFacility);
        }

        // POST: RequestFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var requestFacility = await _context.RequestFacility.SingleOrDefaultAsync(m => m.Id == id);
            _context.RequestFacility.Remove(requestFacility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestFacilityExists(string id)
        {
            return _context.RequestFacility.Any(e => e.Id == id);
        }
    }
}
