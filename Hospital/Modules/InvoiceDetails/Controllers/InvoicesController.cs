using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.InvoiceDetails.Models;
using Hospital.Modules.PatientManagement.Models;

namespace Hospital.Modules.InvoiceDetails.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly HospitalContext _context;

        public InvoicesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index(String search)
        {
            if (search != null)
            {
                return View(_context.Invoice.Where(i => i.PatienID == search).ToList());
            }
            return View(await _context.Invoice.ToListAsync());
        }

        public async Task<IActionResult> mainView()
        {
            return View();
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> item = _context.PatientDetails.Select(c => new SelectListItem
            {
                Text = c.Id.ToString(),
                Value = c.Id.ToString()
            }
             );
            ViewBag.PatienID = item;


            return View();
        }



        //public ActionResult cal()
        //{
        //    Invoice invoice = new Invoice();
        //    int id = 1;
        //    String name = "panadol";
        //    var price = _context.Drug.SingleOrDefault(i => i.Name.Equals(name));
        //    int medication = _context.Invoice.Count(x => x.medication == price.Name);

        //    double count = (price.Price * medication);

        //    IEnumerable<SelectListItem> item = _context.Invoice.Select(c => new SelectListItem
        //    {
        //        Text = c.Id.ToString(),
        //        Value = c.Id.ToString()
        //    }
        //    );
        //    ViewBag.PatienID = item;


        //    invoice.PatienID = id.ToString();
        //    invoice.Total_Amount = count;
        //    return View(invoice);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> cal(Invoice invoice)
        {

            if (ModelState.IsValid)
            {
                //var patientdetails = new PatientDetails()
                //{
                //    Id=Convert.ToInt32(invoice.PatienID),
                //    avalablity= "checked_out",
                //    checkedout=invoice.Date,
                //    NicNo="",
                //    Wardno="",
                //    Address="",
                //    telephone=0,
                //    patientName=""


                //};



                _context.Add(invoice);

                //_context.Patients.Update(patientdetails);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }






        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InvoiceID,PatienID,Total_Amount,Pay_type,Status,Date,Comments")] Invoice invoice)
        {

            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InvoiceID,PatienID,Total_Amount,VAT,Discount,Adj_Amount,Pay_type,Status,Date,Comments")] Invoice invoice)
        {
            if (id != invoice.InvoiceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.InvoiceID))
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
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .SingleOrDefaultAsync(m => m.InvoiceID == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.SingleOrDefaultAsync(m => m.InvoiceID == id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.InvoiceID == id);
        }
    }
}
