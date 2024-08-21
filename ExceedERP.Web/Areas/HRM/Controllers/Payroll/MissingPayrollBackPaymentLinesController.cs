using ExceedERP.Core.Domain.HRM.Payroll.MissingPayrollBackPays;
using ExceedERP.DataAccess.Context;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceedERP.Web.Areas.HRM.Controllers.Payroll
{
    public class MissingPayrollBackPaymentLinesController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();
        public ActionResult MissingPayrollBackPaymentLines_Read([DataSourceRequest]DataSourceRequest request, int mPBId)
        {
            //IQueryable<MissingPayrollBackPaymentLine> missingPayrollBackPaymentLines = db.MissingPayrollBackPaymentLines.Where(x => x.MissingPayrollBackPaymentLineId == mPBId);

            //DataSourceResult result = missingPayrollBackPaymentLines.ToDataSourceResult(request, missingPayrollBackPaymentLine => new MissingPayrollBackPaymentLine
            //{
            //    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId,
            //    MissingPayrollBackPayId = missingPayrollBackPaymentLine.MissingPayrollBackPayId,
            //    EmployeeId = missingPayrollBackPaymentLine.EmployeeId,
            //    Reason = missingPayrollBackPaymentLine.Reason,
            //    DateCreated = missingPayrollBackPaymentLine.DateCreated,
            //    LastModified = missingPayrollBackPaymentLine.LastModified,
            //    CreatedBy = missingPayrollBackPaymentLine.CreatedBy,
            //    ModifiedBy = missingPayrollBackPaymentLine.ModifiedBy
            //});

            //return Json(request);
            IQueryable<MissingPayrollBackPaymentLine> missingPayrollBackPaymentLines = db.MissingPayrollBackPaymentLines.Where(x => x.MissingPayrollBackPaymentLineId == mPBId);
            DataSourceResult result = missingPayrollBackPaymentLines.ToDataSourceResult(request, missingPayrollBackPaymentLine => new MissingPayrollBackPaymentLine
            {
                MissingPayrollBackPaymentLineId = missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId,
                MissingPayrollBackPayId = missingPayrollBackPaymentLine.MissingPayrollBackPayId,
                EmployeeId = missingPayrollBackPaymentLine.EmployeeId,
                Reason = missingPayrollBackPaymentLine.Reason,
                DateCreated = missingPayrollBackPaymentLine.DateCreated,
                LastModified = missingPayrollBackPaymentLine.LastModified,
                CreatedBy = missingPayrollBackPaymentLine.CreatedBy,
                ModifiedBy = missingPayrollBackPaymentLine.ModifiedBy
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentLines_Create([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentLine missingPayrollBackPaymentLine, int mPBId)
        {
            var exist = db.MissingPayrollBackPaymentLines.Any(x => x.EmployeeId == missingPayrollBackPaymentLine.EmployeeId && x.MissingPayrollBackPayId == mPBId);
            if (exist)
            {
                ModelState.AddModelError("exist", "Employee is already Registered!");
            }
            //missingPayrollBackPayment.MissingPayrollBackPaymentLineId = lineId;
            if (ModelState.IsValid)
            {

                var entity = new MissingPayrollBackPaymentLine
                {
                    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId,
                    MissingPayrollBackPayId = mPBId,
                    EmployeeId = missingPayrollBackPaymentLine.EmployeeId,
                    Reason = missingPayrollBackPaymentLine.Reason,
                    DateCreated = missingPayrollBackPaymentLine.DateCreated,
                    LastModified = missingPayrollBackPaymentLine.LastModified,
                    CreatedBy = missingPayrollBackPaymentLine.CreatedBy,
                    ModifiedBy = missingPayrollBackPaymentLine.ModifiedBy
                };

                db.MissingPayrollBackPaymentLines.Add(entity);
                db.SaveChanges();
                missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId = entity.MissingPayrollBackPaymentLineId;
            }

            return Json(new[] { missingPayrollBackPaymentLine }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentLines_Update([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentLine missingPayrollBackPaymentLine)
        {
            var exist = db.MissingPayrollBackPaymentLines.Any(x => x.EmployeeId == missingPayrollBackPaymentLine.EmployeeId
                                                                 && x.MissingPayrollBackPayId == missingPayrollBackPaymentLine.MissingPayrollBackPayId
                                                                 &&x.MissingPayrollBackPaymentLineId !=missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId);
            if (exist)
            {
                ModelState.AddModelError("exist", "Employee is already Registered!");
            }
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentLine
                {
                    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId,
                    MissingPayrollBackPayId = missingPayrollBackPaymentLine.MissingPayrollBackPayId,
                    EmployeeId = missingPayrollBackPaymentLine.EmployeeId,
                    Reason = missingPayrollBackPaymentLine.Reason,
                    DateCreated = missingPayrollBackPaymentLine.DateCreated,
                    LastModified = missingPayrollBackPaymentLine.LastModified,
                    CreatedBy = missingPayrollBackPaymentLine.CreatedBy,
                    ModifiedBy = missingPayrollBackPaymentLine.ModifiedBy
                };

                db.MissingPayrollBackPaymentLines.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBackPaymentLine }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentLines_Destroy([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentLine missingPayrollBackPaymentLine)
        {
            //if (HasRelatedCheckBook(missingPayrollBack))
            //{
            //    ModelState.AddModelError("", "This bank has linked check book. you cannot delete it.");
            //}
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentLine
                {
                    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentLine.MissingPayrollBackPaymentLineId,
                    MissingPayrollBackPayId = missingPayrollBackPaymentLine.MissingPayrollBackPayId,
                    EmployeeId = missingPayrollBackPaymentLine.EmployeeId,
                    Reason = missingPayrollBackPaymentLine.Reason,
                    DateCreated = missingPayrollBackPaymentLine.DateCreated,
                    LastModified = missingPayrollBackPaymentLine.LastModified,
                    CreatedBy = missingPayrollBackPaymentLine.CreatedBy,
                    ModifiedBy = missingPayrollBackPaymentLine.ModifiedBy
                };

                db.MissingPayrollBackPaymentLines.Attach(entity);
                db.MissingPayrollBackPaymentLines.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBackPaymentLine }.ToDataSourceResult(request, ModelState));
        }
    }
}