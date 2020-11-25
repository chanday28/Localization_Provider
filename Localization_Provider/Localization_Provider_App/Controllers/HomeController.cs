using Localization_Provider_App.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Localization_Provider_App.Controllers
{
    public class HomeController : Controller
    {
        //Default Constructor
        public HomeController()
        {
        }
        public ITranslation TransalatedValue { get; }

        public HomeController(ITranslation transalatedValue)
        {
            TransalatedValue = transalatedValue;
        }
        // GET: Home
        public ActionResult Localization_Provider()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetOKTranslation(TranslationModel value)
        {
            if (ModelState.IsValid)
            {
                TranslationModel translatedDetail =await TransalatedValue.GetTranslatedValue(value.TranslationType.ToString());
                ViewBag.Msg = translatedDetail.OKButtonText;
            }
           
            return View("Localization_Provider");
        }

        [HttpPost]
        public async Task<ActionResult> GetCancelTranslation(TranslationModel value)
        {
            if (ModelState.IsValid)
            {
                TranslationModel translatedDetail = await TransalatedValue.GetTranslatedValue(value.TranslationType.ToString());
                ViewBag.Msg = translatedDetail.CancelButtonText;
            }

            return View("Localization_Provider");
        }
    }
}