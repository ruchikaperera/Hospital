using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.StaffManagement.Models;

namespace Hospital.Modules.StaffManagement.Controllers
{
    public class EditProfilesController : Controller
    {
        private readonly HospitalContext _context;

        public EditProfilesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: EditProfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.EditProfile.ToListAsync());
        }

        // GET: EditProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editProfile = await _context.EditProfile
                .SingleOrDefaultAsync(m => m.Id == id);
            if (editProfile == null)
            {
                return NotFound();
            }

            return View(editProfile);
        }

        // GET: EditProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EditProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password")] EditProfile editProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editProfile);
        }

        // GET: EditProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editProfile = await _context.EditProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (editProfile == null)
            {
                return NotFound();
            }
            return View(editProfile);
        }

        // POST: EditProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password")] EditProfile editProfile)
        {
            if (id != editProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditProfileExists(editProfile.Id))
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
            return View(editProfile);
        }

        // GET: EditProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editProfile = await _context.EditProfile
                .SingleOrDefaultAsync(m => m.Id == id);
            if (editProfile == null)
            {
                return NotFound();
            }

            return View(editProfile);
        }

        // POST: EditProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editProfile = await _context.EditProfile.SingleOrDefaultAsync(m => m.Id == id);
            _context.EditProfile.Remove(editProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditProfileExists(int id)
        {
            return _context.EditProfile.Any(e => e.Id == id);
        }
    }
}
