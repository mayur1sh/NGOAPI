using Microsoft.AspNetCore.Mvc;
using NGOAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
namespace NGOAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Admin : ControllerBase
    {
        [HttpPost("SendEmail")]
        public IActionResult SendEmail(ContactForm _ContactForm)
        {
            MailAddress to = new MailAddress(_ContactForm.Email);
            MailAddress from = new MailAddress("mostact@gmail.com");

            MailMessage email = new MailMessage(from, to);
            email.Subject = "Thank you for visiting Dreams Peace Foundation";
            email.Body = _ContactForm.Message;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("mostact@gmail.com", "umco ghbe litj cyiu");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            Result _Result = new Result();
            try
            {

                smtp.Send(email);
                _Result.Status = "1";
            }
            catch (SmtpException ex)
            {
                _Result.Status = "0";
                _Result.Data = ex;
            }
            return Content(JsonSerializer.Serialize<Result>(_Result).ToString(), "application/json");
        }
    }
}
