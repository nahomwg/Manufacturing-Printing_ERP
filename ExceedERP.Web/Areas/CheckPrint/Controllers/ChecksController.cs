using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.CheckPrint;
using ExceedERP.DataAccess.Context;

namespace ExceedERP.Web.Areas.CheckPrint.Controllers
{
    public class ChecksController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            ViewData["Banks"] = db.CPBanks.Select(b => new { b.Name, b.CPBankId }).ToList();
            ViewData["BankAccounts"] = db.CPBankAccounts.Select(b => new { b.AccountNumber, b.CPBankAccountId }).ToList();

            return View();
        }

        public ActionResult Checks_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            IQueryable<Check> checks = db.Checks.Where(c => c.CPCheckBookId == id);
            DataSourceResult result = checks.ToDataSourceResult(request, check => new  Check{
                CheckId = check.CheckId,
                CPCheckBookId = check.CPCheckBookId,
                Date = check.Date,
                PayableTo = check.PayableTo,
                PayableFor = check.PayableFor,
                BBF = check.BBF,
                Deposits = check.Deposits,
                Total = check.Total,
                ThisCheck = check.ThisCheck,
                Balance = check.Balance,
                CheckNumber = check.CheckNumber,
                Payee = check.Payee,
                CheckAmount = check.CheckAmount,
                Code = check.Code,
                Status = check.Status,
                Purpose = check.Purpose,
                IsVoucherPrepared = check.PaymentVouchers.Any() ? true : false,

                DateCreated = check.DateCreated,
                LastModified = check.LastModified,
                CreatedBy = check.CreatedBy,
                ModifiedBy = check.ModifiedBy
            });

            return Json(result);
        }

        private bool IsDuplicateCheckNumber(Check check, int bookId)
        {
            return db.Checks.Any(c => c.CheckId != check.CheckId && c.CheckNumber == check.CheckNumber && c.CPCheckBookId == bookId);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Checks_Create([DataSourceRequest]DataSourceRequest request, Check check, int id)
        {
            if(IsDuplicateCheckNumber(check, id))
            {
                ModelState.AddModelError("", $"Check number {check.CheckNumber} is used already.");
            }
            if (ModelState.IsValid)
            {
                var entity = new Check
                {
                    CPCheckBookId = id,
                    Date = check.Date,
                    PayableTo = check.PayableTo,
                    PayableFor = check.PayableFor,
                    BBF = check.BBF,
                    Deposits = check.Deposits,
                    Total = check.Total,
                    ThisCheck = check.ThisCheck,
                    Balance = check.Balance,
                    CheckNumber = check.CheckNumber,
                    Payee = check.Payee,
                    CheckAmount = check.CheckAmount,
                    Code = Guid.NewGuid().ToString(),
                    Status = check.Status,
                    Purpose = check.Purpose,

                    DateCreated = check.DateCreated,
                    LastModified = check.LastModified,
                    CreatedBy = check.CreatedBy,
                    ModifiedBy = check.ModifiedBy
                };

                db.Checks.Add(entity);
                db.SaveChanges();
                check.CheckId = entity.CheckId;

                UpdateCheckNumber(entity, entity.CPCheckBookId);
            }

            return Json(new[] { check }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Checks_Update([DataSourceRequest]DataSourceRequest request, Check check)
        {
            if (IsDuplicateCheckNumber(check, check.CPCheckBookId))
            {
                ModelState.AddModelError("", $"Check number {check.CheckNumber} is used already.");
            }
            if (ModelState.IsValid)
            {
                var entity = new Check
                {
                    CheckId = check.CheckId,
                    CPCheckBookId = check.CPCheckBookId,
                    Date = check.Date,
                    PayableTo = check.PayableTo,
                    PayableFor = check.PayableFor,
                    BBF = check.BBF,
                    Deposits = check.Deposits,
                    Total = check.Total,
                    ThisCheck = check.ThisCheck,
                    Balance = check.Balance,
                    CheckNumber = check.CheckNumber,
                    Payee = check.Payee,
                    CheckAmount = check.CheckAmount,
                    Code = check.Code,
                    Status = check.Status,
                    Purpose = check.Purpose,

                    DateCreated = check.DateCreated,
                    LastModified = check.LastModified,
                    CreatedBy = check.CreatedBy,
                    ModifiedBy = check.ModifiedBy
                };

                db.Checks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { check }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Checks_Destroy([DataSourceRequest]DataSourceRequest request, Check check)
        {
            if (ModelState.IsValid)
            {
                var entity = new Check
                {
                    CheckId = check.CheckId,
                    CPCheckBookId = check.CPCheckBookId,
                    Date = check.Date,
                    PayableTo = check.PayableTo,
                    PayableFor = check.PayableFor,
                    BBF = check.BBF,
                    Deposits = check.Deposits,
                    Total = check.Total,
                    ThisCheck = check.ThisCheck,
                    Balance = check.Balance,
                    CheckNumber = check.CheckNumber,
                    Payee = check.Payee,
                    CheckAmount = check.CheckAmount,
                    Code = check.Code,
                    Status = check.Status,
                    Purpose = check.Purpose,

                    DateCreated = check.DateCreated,
                    LastModified = check.LastModified,
                    CreatedBy = check.CreatedBy,
                    ModifiedBy = check.ModifiedBy
                };

                db.Checks.Attach(entity);
                db.Checks.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { check }.ToDataSourceResult(request, ModelState));
        }

        private void UpdateCheckNumber(Check check, int bookId)
        {
            var checkNumberRecord =
                db.CPCheckBookCheckNumbers.FirstOrDefault(d => d.CheckNumber == check.CheckNumber && d.CPCheckBookId == bookId);
            if(checkNumberRecord != null)
            {
                checkNumberRecord.Status = CheckNumberStatus.CheckCreated;

                db.CPCheckBookCheckNumbers.Attach(checkNumberRecord);
                db.Entry(checkNumberRecord).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    
        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        public JsonResult SignACheck(int checkId)
        {
            var selectedCheck = db.Checks.Find(checkId);
            if(selectedCheck == null)
            {
                return Json(new { Message = "Doesn't exist", Status = "Error" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //if (!selectedCheck.IsSigned)
                //{
                //    selectedCheck.IsSigned = true;
                //    selectedCheck.SignedBy = User.Identity.Name;
                //    selectedCheck.SignedOn = DateTime.Now;

                //    db.Checks.Attach(selectedCheck);
                //    db.Entry(selectedCheck).State = EntityState.Modified;
                //    db.SaveChanges();
                //    return Json(new { Message = "Operation successful", Status = "Ok" }, JsonRequestBehavior.AllowGet);

                //}
                return Json(new { Message = "Operation successful", Status = "Ok" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PrintCheck(int checkId)
        {
            var selectedCheck = db.Checks.Find(checkId);
            if (selectedCheck == null)
            {
                return Json(new { Message = "Doesn't exist", Status = "Error" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var checkNumber = db.CPCheckBookCheckNumbers.FirstOrDefault(c => c.CheckNumber == selectedCheck.CheckNumber && c.CPCheckBookId == selectedCheck.CPCheckBookId);
                if (selectedCheck.Status ==CheckStatus.New && checkNumber != null)
                {
                    selectedCheck.Status = CheckStatus.Printed;

                    checkNumber.Status = CheckNumberStatus.CheckPrinted;

                    db.Checks.Attach(selectedCheck);
                    db.Entry(selectedCheck).State = EntityState.Modified;

                    db.CPCheckBookCheckNumbers.Attach(checkNumber);
                    db.Entry(checkNumber).State = EntityState.Modified;


                    db.SaveChanges();
                    return Json(new { Message = "Operation successful", Status = "Ok" }, JsonRequestBehavior.AllowGet);

                }
                return Json(new { Message = "Operation successful", Status = "Ok" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PreparePaymentVoucher(int checkId)
        {
            var selectedCheck = db.Checks.Find(checkId);
            if (selectedCheck == null)
            {
                return Json(new { Message = "Doesn't exist", Status = "Error" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (selectedCheck.Status == CheckStatus.Printed)
                {
                    var existingVoucher = db.CPPaymentVouchers.FirstOrDefault(v => v.CheckId == checkId);
                    if(existingVoucher == null)
                    {
                        var voucher = new CPPaymentVoucher
                        {
                            CheckId = selectedCheck.CheckId,

                            CreatedBy = User.Identity.Name,
                            DateCreated = DateTime.Now,
                        };

                        db.CPPaymentVouchers.Add(voucher);
                        db.SaveChanges();
                        var voucherNumber = voucher.CPPaymentVoucherId < 1000000 ? voucher.CPPaymentVoucherId.ToString("D6") : voucher.CPPaymentVoucherId.ToString("D12");
                        return Json(new { Message = "Operation successful. Voucher number is " + voucherNumber, Status = "Ok" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var voucherNumber = existingVoucher.CPPaymentVoucherId < 1000000 ? existingVoucher.CPPaymentVoucherId.ToString("D6") : existingVoucher.CPPaymentVoucherId.ToString("D12");

                        return Json(new { Message = "Payment Voucher exists already. Existing voucher number is " + existingVoucher.CPPaymentVoucherId, Status = "Ok" }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { Message = "Operation successful", Status = "Ok" }, JsonRequestBehavior.AllowGet);
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
