﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.Doctors_Profile.Models;

namespace Hospital.Modules.Doctors_Profile.Controllers
{
    [Produces("application/json")]
    [Route("api/LabReportRequests")]
    public class LabReportRequestsController : Controller
    {
        private readonly HospitalContext _context;

        public LabReportRequestsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: api/LabReportRequests
        [HttpGet]
        public IEnumerable<LabReportRequest> GetLabReportRequest()
        {
            return _context.LabReportRequest;
        }

        // GET: api/LabReportRequests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabReportRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var labReportRequest = await _context.LabReportRequest.SingleOrDefaultAsync(m => m.Id == id);

            if (labReportRequest == null)
            {
                return NotFound();
            }

            return Ok(labReportRequest);
        }

        // PUT: api/LabReportRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabReportRequest([FromRoute] int id, [FromBody] LabReportRequest labReportRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != labReportRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(labReportRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabReportRequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LabReportRequests
        [HttpPost]
        public async Task<IActionResult> PostLabReportRequest([FromBody] LabReportRequest labReportRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LabReportRequest.Add(labReportRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabReportRequest", new { id = labReportRequest.Id }, labReportRequest);
        }

        // DELETE: api/LabReportRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabReportRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var labReportRequest = await _context.LabReportRequest.SingleOrDefaultAsync(m => m.Id == id);
            if (labReportRequest == null)
            {
                return NotFound();
            }

            _context.LabReportRequest.Remove(labReportRequest);
            await _context.SaveChangesAsync();

            return Ok(labReportRequest);
        }

        private bool LabReportRequestExists(int id)
        {
            return _context.LabReportRequest.Any(e => e.Id == id);
        }
    }
}