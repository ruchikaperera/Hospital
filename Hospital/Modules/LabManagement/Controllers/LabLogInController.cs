using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.LabManagement.Models;

namespace Hospital.Modules.LabManagement.Controllers
{
    public class LabLogInController : Controller
    {
        private readonly HospitalContext _context;
        public static string username, Password;
        public  Boolean IsLoggedIn;

        public IActionResult IsLoggedin()
        {
            if(this.IsLoggedIn)
            {
                return View("LabHomePage");

            }
            else
            {
                return View("LabLogIn");

            }
        }

        public IActionResult HomePage()
        {
            return View("LabHomePage");
        }

        public LabLogInController(HospitalContext context)
        {
            _context = context;
        }

        // GET: LabLogIn
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabLogInModel.ToListAsync());
        }

        // GET: LabLogIn/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labLogInModel = await _context.LabLogInModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (labLogInModel == null)
            {
                return NotFound();
            }

            return View(labLogInModel);
        }

        // GET: LabLogIn/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabLogIn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,userName,password")] LabLogInModel labLogInModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labLogInModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labLogInModel);
        }

        // GET: LabLogIn/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labLogInModel = await _context.LabLogInModel.SingleOrDefaultAsync(m => m.Id == id);
            if (labLogInModel == null)
            {
                return NotFound();
            }
            return View(labLogInModel);
        }

        // POST: LabLogIn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,userName,password")] LabLogInModel labLogInModel)
        {
            if (id != labLogInModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labLogInModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabLogInModelExists(labLogInModel.Id))
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
            return View(labLogInModel);
        }

        // GET: LabLogIn/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labLogInModel = await _context.LabLogInModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (labLogInModel == null)
            {
                return NotFound();
            }

            return View(labLogInModel);
        }

        // POST: LabLogIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var labLogInModel = await _context.LabLogInModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.LabLogInModel.Remove(labLogInModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabLogInModelExists(string id)
        {
            return _context.LabLogInModel.Any(e => e.Id == id);
        }
    }
}
