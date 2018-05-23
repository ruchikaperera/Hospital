﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.Doctors_Profile.Models;
using Hospital.Modules.LabManagement.Controllers;

namespace Hospital.Modules.LabManagement.Controllers
{
    public class LabDepartmentController : Controller
    {
        private readonly HospitalContext _context;


        public IActionResult HomePage()
        {

         
            
            ViewBag.a = 10;
            ViewBag.b = 80;
            ViewBag.c = 90;
            return View("LabHomePage");



        }

        public LabDepartmentController(HospitalContext context)
        {
            _context = context;
        }

        // GET: LabDepartment
        public async Task<IActionResult> Index()
        {
            var req = from s in _context.LabReportRequest
                      orderby s.ReportId descending
                      select s;
            //  await  Update_Report_Count();
            return View(await req.ToListAsync());
        }

        // GET: LabDepartment/Details/5
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

        // GET: LabDepartment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabDepartment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,nicNo,patientName,DoctorName,LabStatus,LabType,DoctorStatus,date,labNo,SpecialistName,description")] LabReportRequest labReportRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(labReportRequest);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(labReportRequest);
        //}

        // GET: LabDepartment/Edit/5
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

        // POST: LabDepartment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportId, nicNo,patientName,DoctorName,LabStatus,LabType,DoctorStatus,LabReport,date,labNo,SpecialistName,description")] LabReportRequest labReportRequest)
        {
            // make the report ready
            labReportRequest.LabStatus = "Ready";


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
                    await Recived_Report_Count_Update();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!LabReportRequestExists(labReportRequest.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(labReportRequest);
        }

        // GET: LabDepartment/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var labReportRequest = await _context.LabReportRequest
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (labReportRequest == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(labReportRequest);
        //}

        // POST: LabDepartment/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var labReportRequest = await _context.LabReportRequest.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.LabReportRequest.Remove(labReportRequest);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LabReportRequestExists(int id)
        //{
        //    return _context.LabReportRequest.Any(e => e.Id == id);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<int> Update_Report_Count()
        {
            ReportCount reportCount = new ReportCount();
            
           // var Model = await _context.ReportCount.SingleOrDefaultAsync(m => m.Id == id);

            // get the row count of ReportCount table


            // increment by one 
            reportCount.Count = 0; 


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
                        // return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return reportCount.Count;
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<int> Recived_Report_Count_Update()
        {
            int id = 1;
            var Model = await _context.ReportCount.SingleOrDefaultAsync(m => m.Id == id);

            // get the row count of ReportCount table
            var no = Model.Count;

            // increment by one 
            Model.Count = no + 1;


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportCountExists(Model.Id))
                    {
                        // return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return Model.Count;
        }

        private bool ReportCountExists(int id)
        {
            return _context.ReportCount.Any(e => e.Id == id);
        }
    }
}
