using App.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class EventController : Controller
    {
        private BaseLogic baseLogic;

        public EventController()
        {
            baseLogic = new BaseLogic();
        }
        public ActionResult List()
        {
            return View(baseLogic.GetReferenceData(0).Result);
        }
        public ActionResult AddEdit()
        {
            return View();
        }
        public ActionResult Display()
        {
            return View();
        }
    }
}