using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.Doctors_Profile.Models;
using Hospital.Modules.StaffManagement.Controllers;

namespace Hospital.Modules.Doctors_Profile.Controllers
{
    public class LabReportRequestsController : Controller
    {
        private readonly HospitalContext _context;

        public static int no;
        public LabReportRequestsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: LabReportRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabReportRequest.ToListAsync());

        }

        // GET: LabReportRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labReportRequest = await _context.LabReportRequest
                .SingleOrDefaultAsync(m => m.Id == id);
            if (labReportRequest == null)
            {
                return NotFound();
            }

            return View(labReportRequest);
        }

        // GET: LabReportRequests/Create
        public IActionResult Create()
        {
            string username = LogInDetailsController.UserName;
            ViewBag.message = username;
            return View();
        }

        // POST: LabReportRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nicNo,patientName,DoctorName,LabStatus,LabType,DoctorStatus,date,labNo,SpecialistName,description")] LabReportRequest labReportRequest)
        {

            if (ModelState.IsValid)
            {
                _context.Add(labReportRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labReportRequest);
        }

        // GET: LabReportRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labReportRequest = await _context.LabReportRequest.SingleOrDefaultAsync(m => m.Id == id);
            if (labReportRequest == null)
            {
                return NotFound();
            }
            return View(labReportRequest);
        }

        // POST: LabReportRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nicNo,patientName,DoctorName,LabStatus,LabType,DoctorStatus,date,labNo,SpecialistName,description")] LabReportRequest labReportRequest)
        {
            if (id != labReportRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labReportRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabReportRequestExists(labReportRequest.Id))
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
            return View(labReportRequest);
        }

        // GET: LabReportRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labReportRequest = await _context.LabReportRequest
                .SingleOrDefaultAsync(m => m.Id == id);
            if (labReportRequest == null)
            {
                return NotFound();
            }

            return View(labReportRequest);
        }

        // POST: LabReportRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labReportRequest = await _context.LabReportRequest.SingleOrDefaultAsync(m => m.Id == id);
            _context.LabReportRequest.Remove(labReportRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
       

        private bool LabReportRequestExists(int id)
        {
            return _context.LabReportRequest.Any(e => e.Id == id);
        }
    }
}
