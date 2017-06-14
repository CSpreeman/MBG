using MITM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MITM.Controllers
{
    public class BlogsController : Controller
    {
        public ActionResult Blog(int id = 0)
        {
            ItemModel<int> model = new ItemModel<int>();
            model.Id = id;
            return View(model);
        }
    }
}