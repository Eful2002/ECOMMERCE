﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Admin.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Admin/Error
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult ErrorKey()
        {
            return View();
        }
    }
}