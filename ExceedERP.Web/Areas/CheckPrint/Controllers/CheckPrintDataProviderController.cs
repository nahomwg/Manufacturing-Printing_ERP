using ExceedERP.Core.Domain.CheckPrint;
using ExceedERP.DataAccess.Context;
using System.Linq;
using System.Web.Mvc;

namespace ExceedERP.Web.Areas.CheckPrint.Controllers
{
    public class CheckPrintDataProviderController : Controller
    {
        ExceedDbContext db = new ExceedDbContext();
        public JsonResult GetAllBanks()
        {
            var data = db.CPBanks;
            return Json(data.Select(s => new { s.CPBankId, s.Name }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBankAccounts(int bankId, string filterString)
        {
            var data = db.CPBankAccounts.Where(b => b.CPBankId == bankId).ToList();
            if (!string.IsNullOrEmpty(filterString))
            {
                data = data.Where(d => d.AccountNumber.Contains(filterString)).ToList();
            }
            return Json(data.Select(s => new { s.CPBankAccountId, s.AccountNumber }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCheckNumbers(int bookId)
        {
            var data = db.CPCheckBookCheckNumbers.Where(b => b.CPCheckBookId == bookId && (b.Status == CheckNumberStatus.New || b.Status == CheckNumberStatus.CheckCreated));
            return Json(data.Select(s => new { s.CPCheckBookCheckNumberId, s.CheckNumber }), JsonRequestBehavior.AllowGet);
        }
    }
}