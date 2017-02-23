using _11_CustomHTMLHelperMethod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _11_CustomHTMLHelperMethod.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            List<Message> messages = new List<Message>();
            messages.Add(new Message() { Level = 3, Text = "Ut fusce varius" });
            messages.Add(new Message() { Level = 1, Text = "nisl ac ipsum gravida " });
            messages.Add(new Message() { Level = 2, Text = "vel pretium tellus tincidunt" });
            messages.Add(new Message() { Level = 4, Text = "integer eu augue augue" });

            return View(messages);
        }
    }
}