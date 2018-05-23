using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Hospital.Modules.DrugDetails.Models;
using System.Net.Mail;
using System.Data;

namespace Hospital.Modules.DrugDetails.Controllers
{


    public class DrugsController : Controller
    {


        private readonly HospitalContext _context;

        public DrugsController(HospitalContext context)
        {
            _context = context;

         //   Getqty();
        }


        // GET: Drugs
        public async Task<IActionResult> Index(string search)
        {

            return View(await _context.Drug.ToListAsync());
        }

        //------------------------------------------------------


        public async Task<IActionResult> Search(string searchString)
        {
            var d = from m in _context.Drug
                    select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                d = d.Where(s => s.Name.Contains(searchString));
            }

            return View(await d.ToListAsync());
        }

        public async Task<IActionResult> DrugSelling()
        {
            //double cost = 0;
            //var drug = from m in _context.Drug
            //         select m;
            //var drug = _context.Drug.Select(d=> new { d.Name,d.Qty,d.Price});

            return View(await _context.Drug.ToListAsync());

        }

        public IActionResult Calculate(string id, string amt)
        {
            int amount = Int32.Parse(amt);
            double cal;
            double cost = 0;
            var pri = from p in _context.Drug
                      where p.ID == 10
                      select p.Price;

            foreach (double price in pri)
            {
                cost = price;
            }

            cal = amount;
            string calculate = cal.ToString();


            //ViewBag.cal = cal;
            return RedirectToAction("DrugSelling", "Drugs");

        }


        public async Task<IActionResult> SellingSearch(string search)
        {
            var d = from m in _context.Drug
                    select m;

            if (!String.IsNullOrEmpty(search))
            {
                d = d.Where(s => s.Name.Contains(search));
            }
            return View(await d.ToListAsync());
        }




        public void Getqty()
        {

            var drugs = from d in _context.Drug
                        where d.Qty == 0
                        select d.Name;

            var state = from d in _context.Drug
                        where d.Qty == 0
                        select d.State;


            if (drugs != null)
            {

                foreach (string s in state)
                {
                    if (s != "Not Available")
                    {
                        (from m in _context.Drug
                         where m.Qty == 0
                         select m).ToList().ForEach(n => n.State = "Not Available");



                        foreach (string name in drugs)
                        {
                            string to = "charukajayakody@gmail.com"; //To address    
                            string from = "charukay5@gmail.com"; //From address    
                            MailMessage message = new MailMessage(from, to);
                            string mailbody = name + " is out of stock";


                            message.Subject = "Some Drugs are out of stock ";
                            message.Body = mailbody;
                            //var filename = @"c:\test.pdf";
                            //message.Attachments.Add(new Attachment(filename));
                            message.BodyEncoding = System.Text.Encoding.UTF8;
                            message.IsBodyHtml = true;
                            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                            System.Net.NetworkCredential basicCredential1 = new
                            System.Net.NetworkCredential("charukay5@gmail.com", "tomcat123456");
                            client.EnableSsl = true;
                            client.UseDefaultCredentials = false;
                            client.Credentials = basicCredential1;

                            try
                            {

                                client.Send(message);

                            }

                            catch (Exception ex)
                            {
                                throw ex;
                            }

                        }

                    }

                }
                _context.SaveChanges();
            }

        }


        // GET: Drugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await _context.Drug
                .SingleOrDefaultAsync(m => m.ID == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // GET: Drugs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Drug_ID,Name,Description,Qty,Price,State")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drug);
        }

        // GET: Drugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await _context.Drug.SingleOrDefaultAsync(m => m.ID == id);
            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Drug_ID,Name,Description,Qty,Price,State")] Drug drug)
        {
            if (id != drug.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugExists(drug.ID))
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
            return View(drug);
        }

        // GET: Drugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drug = await _context.Drug
                .SingleOrDefaultAsync(m => m.ID == id);
            if (drug == null)
            {
                return NotFound();
            }

            return View(drug);
        }

        // POST: Drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drug = await _context.Drug.SingleOrDefaultAsync(m => m.ID == id);
            _context.Drug.Remove(drug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugExists(int id)
        {
            return _context.Drug.Any(e => e.ID == id);
        }
    }
}
