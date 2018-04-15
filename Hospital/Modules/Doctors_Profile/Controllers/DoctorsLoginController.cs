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
    public class DoctorsProfileController : Controller
    {
        private readonly HospitalContext _context;
       // public static int no;

        public DoctorsProfileController(HospitalContext context)
        {
            _context = context;
        }
        //public Task<int> SearchPatient(int? id)
        //{
        //    if (id == null)
        //    {
        //       // return NotFound();
        //    }

        //    var patientModel = _context.patient
        //       .SingleOrDefaultAsync(m => m.Id == id);
        //    if (patientModel == null)
        //    {
        //      //  return NotFound();
        //    }

        //    string username = "";
        //    username = "Ruchika Perera";
        //    ViewBag.username = username;
        //   // return View("zz");
        //   // return 2;
        //}


        // GET: DoctorsLogin
        public IActionResult Index()
        {
            int No = Get_PendingLabReportsCount();
            int Finished_Report_count = Get_Finished_LabReportsCount();
            ViewBag.no = No;
            ViewBag.finishedReportCount = Finished_Report_count;
            //return View(await _context.DoctorsLoginModel.ToListAsync());
            return View("zz");

        }

        // GET: DoctorsLogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsLoginModel = await _context.DoctorsLoginModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorsLoginModel == null)
            {
                return NotFound();
            }

            return View(doctorsLoginModel);
        }
        public async Task<LabReportRequest> SearchPatient(int? id)
        {
            LabReportRequest labReportRequest = new LabReportRequest();
          
            if (id == null)
            {
              //  return NotFound();
            }

            ViewBag.a = 30;

             labReportRequest = await _context.LabReportRequest
                .SingleOrDefaultAsync(m => m.nicNo == id);
            if (labReportRequest == null)
            {
               // return NotFound();
            }


            // return View(labReportRequest);
            return labReportRequest;
        }

        // GET: DoctorsLogin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoctorsLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,userName,password")] DoctorsLoginModel doctorsLoginModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctorsLoginModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctorsLoginModel);
        }

        // GET: DoctorsLogin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsLoginModel = await _context.DoctorsLoginModel.SingleOrDefaultAsync(m => m.Id == id);
            if (doctorsLoginModel == null)
            {
                return NotFound();
            }
            return View(doctorsLoginModel);
        }

        // POST: DoctorsLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,userName,password")] DoctorsLoginModel doctorsLoginModel)
        {
            if (id != doctorsLoginModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctorsLoginModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorsLoginModelExists(doctorsLoginModel.Id))
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
            return View(doctorsLoginModel);
        }

        // GET: DoctorsLogin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorsLoginModel = await _context.DoctorsLoginModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorsLoginModel == null)
            {
                return NotFound();
            }

            return View(doctorsLoginModel);
        }

        // POST: DoctorsLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctorsLoginModel = await _context.DoctorsLoginModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.DoctorsLoginModel.Remove(doctorsLoginModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorsLoginModelExists(int id)
        {
            return _context.DoctorsLoginModel.Any(e => e.Id == id);
        }

        public  int Get_PendingLabReportsCount()
        {
            string status = "Pending";
           var no =  _context.LabReportRequest.Count(s => s.LabStatus.Equals(status));
            return no;

        }

        public int Get_Finished_LabReportsCount()
        {
            var model = _context.ReportCount.SingleOrDefault(s => s.Id.Equals(1));
            return model.Count;

        }





        public int Reset_LabReportCount()
        {
            string status = "Pending";
            var no = _context.LabReportRequest.Count(s => s.LabStatus.Equals(status));
            return no;

        }
    }
}
