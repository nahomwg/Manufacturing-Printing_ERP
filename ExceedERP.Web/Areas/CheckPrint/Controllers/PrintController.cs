using ExceedERP.DataAccess.Context;
using System.Linq;
using System.Web.Mvc;

namespace ExceedERP.Web.Areas.CheckPrint.Controllers
{
    public class PrintController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();
        // GET: CheckPrint/Print
        public ActionResult Index(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Redirect("/CheckPrint/Cheks/Index");
            }
            else
            {
                ViewBag.Code = code;
                var selectedCheck = db.Checks.FirstOrDefault(c => c.Code == code);
                if(selectedCheck != null)
                {

                    return View();
                }
            }
            return Redirect(nameof(Template));
        }
        public ActionResult Voucher(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Redirect("/CheckPrint/Cheks/Index");
            }
            else
            {
                ViewBag.Code = code;
                var selectedCheck = db.Checks.FirstOrDefault(c => c.Code == code);
                if (selectedCheck != null)
                {
                    return View();
                }
            }
            return Redirect(nameof(Template));
        }
        public ActionResult Template()
        {
            return View();
        }
    }
}