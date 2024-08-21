using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.CheckPrint;
using ExceedERP.DataAccess.Context;
using System.IO;
using ExceedERP.Core.Domain.HRM.Payroll.MissingPayrollBackPays;

namespace ExceedERP.Web.Areas.HRM.Controllers.Payroll
{
    public class MissingPayrollBackPaymentDistributionsController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            ViewData["branch"] = db.Branch.Select(x => new { x.BranchId, x.Name }).ToList();
            ViewData["bussinessunit"] = db.BusinessUnits.Select(x => new { x.BusinessUnitId, x.Name }).ToList();
            ViewData["glPeriods"] = db.GLPeriods.Select(x => new { x.GLPeriodId, x.Name }).ToList();
            ViewData["employees"] = db.Person_Employee.Select(x => new {
                x.EmployeeId,
                FullName = x.EmployeeCode + "-" + x.FirstNameEnglish + " " + x.MiddleNameEnglish + " " + x.LastNameEnglish
            }).ToList();
            return View();
        }

        public ActionResult MissingPayrollBackPaymentDistributions_Read([DataSourceRequest]DataSourceRequest request,int PayBackId)
        {
            
            IQueryable<MissingPayrollBackPaymentDistribution> missingPayrollBackPaymentDistributions = db.MissingPayrollBackPaymentDistributions.Where(x=>x.MissingPayrollBackPayId==PayBackId);
            DataSourceResult result = missingPayrollBackPaymentDistributions.ToDataSourceResult(request, missingPayrollBack => new MissingPayrollBackPaymentDistribution
            {
                MissingPayrollBackPaymentDistributionId = missingPayrollBack.MissingPayrollBackPaymentDistributionId,
                MissingPayrollBackPayId = missingPayrollBack.MissingPayrollBackPayId,
                AccountCode = missingPayrollBack.AccountCode,
                AccountDesc = missingPayrollBack.AccountDesc,
                Debit = missingPayrollBack.Debit,
                Credit = missingPayrollBack.Credit,
                DateCreated = missingPayrollBack.DateCreated,
                LastModified = missingPayrollBack.LastModified,
                CreatedBy = missingPayrollBack.CreatedBy,
                ModifiedBy = missingPayrollBack.ModifiedBy
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDistributions_Create([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDistribution missingPayrollBack,int PayBackId)
        {
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDistribution
                {
                    MissingPayrollBackPaymentDistributionId = missingPayrollBack.MissingPayrollBackPaymentDistributionId,
                    MissingPayrollBackPayId = PayBackId,
                    AccountCode = missingPayrollBack.AccountCode,
                    AccountDesc = missingPayrollBack.AccountDesc,
                    Debit = missingPayrollBack.Debit,
                    Credit = missingPayrollBack.Credit,
                    DateCreated = missingPayrollBack.DateCreated,
                    LastModified = missingPayrollBack.LastModified,
                    CreatedBy = missingPayrollBack.CreatedBy,
                    ModifiedBy = missingPayrollBack.ModifiedBy
                };

                db.MissingPayrollBackPaymentDistributions.Add(entity);
                db.SaveChanges();
                missingPayrollBack.MissingPayrollBackPayId = entity.MissingPayrollBackPayId;
            }

            return Json(new[] { missingPayrollBack }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDistributions_Update([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDistribution missingPayrollBack)
        {
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDistribution
                {
                    MissingPayrollBackPaymentDistributionId = missingPayrollBack.MissingPayrollBackPaymentDistributionId,
                    MissingPayrollBackPayId = missingPayrollBack.MissingPayrollBackPayId,
                    AccountCode = missingPayrollBack.AccountCode,
                    AccountDesc = missingPayrollBack.AccountDesc,
                    Debit = missingPayrollBack.Debit,
                    Credit = missingPayrollBack.Credit,
                    DateCreated = missingPayrollBack.DateCreated,
                    LastModified = missingPayrollBack.LastModified,
                    CreatedBy = missingPayrollBack.CreatedBy,
                    ModifiedBy = missingPayrollBack.ModifiedBy
                };

                db.MissingPayrollBackPaymentDistributions.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBack }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDistributions_Destroy([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDistribution missingPayrollBack)
        {
            //if (HasRelatedCheckBook(missingPayrollBack))
            //{
            //    ModelState.AddModelError("", "This bank has linked check book. you cannot delete it.");
            //}
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDistribution
                {
                    MissingPayrollBackPaymentDistributionId = missingPayrollBack.MissingPayrollBackPaymentDistributionId,
                    MissingPayrollBackPayId = missingPayrollBack.MissingPayrollBackPayId,
                    AccountCode = missingPayrollBack.AccountCode,
                    AccountDesc = missingPayrollBack.AccountDesc,
                    Debit = missingPayrollBack.Debit,
                    Credit = missingPayrollBack.Credit,
                    DateCreated = missingPayrollBack.DateCreated,
                    LastModified = missingPayrollBack.LastModified,
                    CreatedBy = missingPayrollBack.CreatedBy,
                    ModifiedBy = missingPayrollBack.ModifiedBy
                };

                db.MissingPayrollBackPaymentDistributions.Attach(entity);
                db.MissingPayrollBackPaymentDistributions.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBack }.ToDataSourceResult(request, ModelState));
        }
        //private bool HasRelatedCheckBook(MissingPayrollBackPay missingPayrollBackPay)
        //{
        //   return db.MissingPayrollBackPays.Any(b => b.CPBankId == bank.CPBankId);
        //}
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


        public void Logo_Upload(int id, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                if (files != null && files.Count() > 0)
                {
                    foreach (var file in files)
                    {
                        string path = HttpContext.Server.MapPath("~/Content/Images/CheckPrint/Logo/Banks/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        var newFileName = "logo-" + id + Path.GetExtension(file.FileName);
                        var filePath = path + newFileName;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        file.SaveAs(filePath);

                        var record = db.CPBanks.Find(id);
                        if (record != null)
                        {
                            record.LogoFileName = newFileName;

                            db.CPBanks.Attach(record);
                            db.Entry(record).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
