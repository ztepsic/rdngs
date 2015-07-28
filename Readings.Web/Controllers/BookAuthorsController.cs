using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Readings.Web.Controllers
{
    public class BookAuthorsController : Controller
    {
        // GET: BookAuthors
        public ActionResult Index()
        {
            return View();
        }
    }
}