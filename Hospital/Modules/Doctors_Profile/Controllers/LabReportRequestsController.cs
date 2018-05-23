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
       public static bool filter ;

        private readonly HospitalContext _context;

        public static int no;
        public LabReportRequestsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: LabReportRequests
        public async Task <IActionResult> Index()
        {
            

            await Update_Report_Count();

            if(filter)
            {
                var req = await _context.LabReportRequest
                     .Where(m => m.LabStatus == "Pending").ToListAsync();

                filter = false;

                return View(req);

            }
            else
            {
                var req = from s in _context.LabReportRequest
                          orderby s.ReportId descending
                          select s;

                filter = true;
                return View(await req.ToListAsync());

            }




            // return View(await _context.LabReportRequest.ToListAsync());

        }

        public async Task<IActionResult> ABC()
        {
            var req = await _context.LabReportRequest
                    .Where(m => m.LabStatus == "Pending").ToListAsync();

            return View("Index", req);
        }

        //public async Task<IActionResult> PendingReports()
        //{
        //    IEnumerable<LabReportRequest> labReportRequest;

        //    var a = await _context.LabReportRequest
        //               .Where(m => m.LabStatus == "Pending").ToListAsync();

        //    // return View(await _context.LabReportRequest.ToListAsync());
        //    return View(await a.ToList());

        //}



        public async Task<IActionResult> LabReportSearch()
        {
            int id = 3;
            // var i = await _context.LabReportRequest.ToListAsync();

            var req = await _context.LabReportRequest
                      .Where(m => m.labNo == id).ToListAsync();

            return View(req);


        }

        public async Task<IActionResult> Search()
        {
            int id = 962950019;
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.a = 30;

            var labReportRequest = await _context.LabReportRequest
                .SingleOrDefaultAsync(m => m.nicNo == id);

            ViewBag.Nic = labReportRequest.nicNo;
            ViewBag.Name = labReportRequest.patientName;
            ViewBag.LabStatus = labReportRequest.LabStatus;
            ViewBag.DoctorName = labReportRequest.DoctorName;
            ViewBag.DoctorStatus = labReportRequest.DoctorStatus;
            ViewBag.date = labReportRequest.date;
            ViewBag.DoctorName = labReportRequest.description;
            ViewBag.labNo = labReportRequest.labNo;
            ViewBag.LabReport = labReportRequest.LabReport;
            ViewBag.SpeacialistName = labReportRequest.SpecialistName;
            ViewBag.description = labReportRequest.description;


            string a = labReportRequest.LabStatus;
            if (labReportRequest == null)
            {
                return NotFound();
            }

            return View("Search");
        }
        public async Task<IActionResult> Check(int? id)
        {
            id = 666;
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.a = 30;

            var labReportRequest = await _context.LabReportRequest
                .SingleOrDefaultAsync(m => m.nicNo == id);

            string a = labReportRequest.LabStatus;
            if (labReportRequest == null)
            {
                return NotFound();
            }

            var i=await _context.LabReportRequest.SingleOrDefaultAsync(m => m.nicNo == id);
           // return View(await _context.LabReportRequest.ToListAsync());
            return RedirectToAction("Index", i);
            return View(labReportRequest);
        }

        // GET: LabReportRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.a = 30;

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
            username = "Ruchika Perera";
           // username = Central.CentralController.userName;

            ViewBag.username = username;
            return View();
        }

        // POST: LabReportRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nicNo,patientName,DoctorName,LabStatus,LabType,DoctorStatus,LabReport,date,labNo,SpecialistName,description")] LabReportRequest labReportRequest)
        {
            labReportRequest.ReportId = 1000;

            int  lastReportID = _context.LabReportRequest.LastOrDefault().ReportId;
            labReportRequest.ReportId = lastReportID + 1;
            labReportRequest.LabStatus = "Pending";
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,nicNo,patientName,DoctorName,LabStatus,LabType,DoctorStatus,LabReport,date,labNo,SpecialistName,description")] LabReportRequest labReportRequest)
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
                .FirstOrDefaultAsync(m => m.Id == id);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<int> Update_Report_Count()
        {
            ReportCount reportCount = new ReportCount();
            int id = 1;

            var Model = await _context.ReportCount.SingleOrDefaultAsync(m => m.Id == id);

            // get the row count of ReportCount table


            // increment by one 
            Model.Count = 0;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportCount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }

            }
            return reportCount.Count;
        }





        private bool LabReportRequestExists(int id)
        {
            return _context.LabReportRequest.Any(e => e.Id == id);
        }

       
    }
}
