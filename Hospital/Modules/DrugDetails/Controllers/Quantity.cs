using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hospital.Modules.DrugDetails.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Modules.DrugDetails.Controllers
{
    public class Quantity : Controller
    {
        // GET: /<controller>/

        public void SendEmail(String s)
        {
            string to = "charukajayakody@gmail.com"; //To address    
            string from = "charukay5@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            var mailbody = s;
            message.Subject = "Some Drugs are out of stock";
            message.Body = mailbody.ToString();
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
                //return View();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
