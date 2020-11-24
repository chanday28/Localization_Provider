using Localization_Provider_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Localization_Provider_App.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Localization_Provider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OK(LangaugeModel value)
        {
            if (ModelState.IsValid)
            {
                TableManager TableManagerObj = new TableManager();
                LangaugeModel langauageDetail = TableManagerObj.GetLangaugeDetail("localization", value.LanguageType.ToString());

                ViewBag.Msg = langauageDetail.OKButtonText;
               
            }
            return View("Localization_Provider");
        }
        [HttpPost]
        public ActionResult Cancel(LangaugeModel value)
        {
            if (ModelState.IsValid)
            {
                TableManager TableManagerObj = new TableManager();
                LangaugeModel langauageDetail = TableManagerObj.GetLangaugeDetail("localization", value.LanguageType.ToString());

                ViewBag.Msg = langauageDetail.CancelButtonText;

            }
            return View("Localization_Provider");
        }
    }
}