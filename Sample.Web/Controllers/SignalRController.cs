using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;

namespace Sample.Web.Controllers
{
    public class SignalRController : Controller{
        public ActionResult Index(){
            return View();
        }
    }
}
