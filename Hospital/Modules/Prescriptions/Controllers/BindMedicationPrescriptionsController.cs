using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.Prescriptions.Models;

namespace Hospital.Modules.Prescriptions.Controllers
{
    public class BindMedicationPrescriptionsController : Controller
    {
        private readonly HospitalContext _context;

        public BindMedicationPrescriptionsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: BindMedicationPrescriptions
        public async Task<IActionResult> Index(String search)
        {
            if (search != null)
            {
                return View(_context.BindMedicationPrescription.Where(i => i.PID == search).ToList());
            }
            return View(await _context.BindMedicationPrescription.ToListAsync());
        }

        //Call main View
        public async Task<IActionResult> mainView()
        {
            return View();
        }


        // GET: BindMedicationPrescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bindMedicationPrescription = await _context.BindMedicationPrescription
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bindMedicationPrescription == null)
            {
                return NotFound();
            }

            return View(bindMedicationPrescription);
        }

        // GET: BindMedicationPrescriptions/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> item = _context.PatientDetails.Select(c => new SelectListItem
            {
                Text = c.Id.ToString(),
                Value = c.Id.ToString()
            }
            );
            ViewBag.PID = item;


            return View();
        }

        // POST: BindMedicationPrescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PID,Treatment,Case_history,Note,medication,When_to_take")] BindMedicationPrescription bindMedicationPrescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bindMedicationPrescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bindMedicationPrescription);
        }

        // GET: BindMedicationPrescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bindMedicationPrescription = await _context.BindMedicationPrescription.SingleOrDefaultAsync(m => m.ID == id);
            if (bindMedicationPrescription == null)
            {
                return NotFound();
            }
            return View(bindMedicationPrescription);
        }

        // POST: BindMedicationPrescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PID,Treatment,Case_history,Note,medication,When_to_take")] BindMedicationPrescription bindMedicationPrescription)
        {
            if (id != bindMedicationPrescription.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bindMedicationPrescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BindMedicationPrescriptionExists(bindMedicationPrescription.ID))
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
            return View(bindMedicationPrescription);
        }

        // GET: BindMedicationPrescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bindMedicationPrescription = await _context.BindMedicationPrescription
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bindMedicationPrescription == null)
            {
                return NotFound();
            }

            return View(bindMedicationPrescription);
        }

        // POST: BindMedicationPrescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bindMedicationPrescription = await _context.BindMedicationPrescription.SingleOrDefaultAsync(m => m.ID == id);
            _context.BindMedicationPrescription.Remove(bindMedicationPrescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BindMedicationPrescriptionExists(int id)
        {
            return _context.BindMedicationPrescription.Any(e => e.ID == id);
        }
    }
}
