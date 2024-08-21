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
    public class MissingPayrollBackPaymentDetailPeriodsController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();
      
        public ActionResult MissingPayrollBackPaymentDetailPeriods_Read([DataSourceRequest]DataSourceRequest request, int lineId)
        {

            IQueryable<MissingPayrollBackPaymentDetailPeriod> missingPayrollBackPayments = db.MissingPayrollBackPaymentDetailPeriods.Where(x => x.MissingPayrollBackPaymentLineId == lineId);
            DataSourceResult result = missingPayrollBackPayments.ToDataSourceResult(request, missingPayrollBackPayment => new MissingPayrollBackPaymentDetailPeriod
            {
                MissingPayrollBackPaymentDetailPeriodId = missingPayrollBackPayment.MissingPayrollBackPaymentDetailPeriodId,
                MissingPayrollBackPaymentLineId = missingPayrollBackPayment.MissingPayrollBackPaymentLineId,
                GLPeriodId = missingPayrollBackPayment.GLPeriodId,
                Description = missingPayrollBackPayment.Description,
                DateCreated = missingPayrollBackPayment.DateCreated,
                LastModified = missingPayrollBackPayment.LastModified,
                CreatedBy = missingPayrollBackPayment.CreatedBy,
                ModifiedBy = missingPayrollBackPayment.ModifiedBy
            });

            return Json(result);

            //IQueryable<MissingPayrollBackPaymentDetailPeriod> missingPayrollBackPayments = db.MissingPayrollBackPaymentDetailPeriods.Where(x => x.MissingPayrollBackPaymentLineId == lineId);

            //DataSourceResult result = missingPayrollBackPayments.ToDataSourceResult(request, missingPayrollBackPayment => new MissingPayrollBackPaymentDetailPeriod
            //{
            //    MissingPayrollBackPaymentDetailPeriodId = missingPayrollBackPayment.MissingPayrollBackPaymentDetailPeriodId,
            //    MissingPayrollBackPaymentLineId = missingPayrollBackPayment.MissingPayrollBackPaymentLineId,
            //    GLPeriodId = missingPayrollBackPayment.GLPeriodId,
            //    Description = missingPayrollBackPayment.Description,
            //    DateCreated = missingPayrollBackPayment.DateCreated,
            //    LastModified = missingPayrollBackPayment.LastModified,
            //    CreatedBy = missingPayrollBackPayment.CreatedBy,
            //    ModifiedBy = missingPayrollBackPayment.ModifiedBy
            //});

            //return Json(request);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDetailPeriods_Create([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDetailPeriod missingPayrollBackPayment, int lineId)
        {
            //missingPayrollBackPayment.MissingPayrollBackPaymentLineId = lineId;
            if (ModelState.IsValid)
            {

                var entity = new MissingPayrollBackPaymentDetailPeriod
                {
                    MissingPayrollBackPaymentDetailPeriodId = missingPayrollBackPayment.MissingPayrollBackPaymentDetailPeriodId,
                    MissingPayrollBackPaymentLineId = lineId,
                    GLPeriodId = missingPayrollBackPayment.GLPeriodId,
                    Description = missingPayrollBackPayment.Description,
                    DateCreated = missingPayrollBackPayment.DateCreated,
                    LastModified = missingPayrollBackPayment.LastModified,
                    CreatedBy = missingPayrollBackPayment.CreatedBy,
                    ModifiedBy = missingPayrollBackPayment.ModifiedBy
                };

                db.MissingPayrollBackPaymentDetailPeriods.Add(entity);
                db.SaveChanges();
                missingPayrollBackPayment.MissingPayrollBackPaymentDetailPeriodId = entity.MissingPayrollBackPaymentDetailPeriodId;
            }

            return Json(new[] { missingPayrollBackPayment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDetailPeriods_Update([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDetailPeriod missingPayrollBackPayment)
        {
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDetailPeriod
                {
                    MissingPayrollBackPaymentDetailPeriodId = missingPayrollBackPayment.MissingPayrollBackPaymentDetailPeriodId,
                    MissingPayrollBackPaymentLineId = missingPayrollBackPayment.MissingPayrollBackPaymentLineId,
                    GLPeriodId = missingPayrollBackPayment.GLPeriodId,
                    Description = missingPayrollBackPayment.Description,
                    DateCreated = missingPayrollBackPayment.DateCreated,
                    LastModified = missingPayrollBackPayment.LastModified,
                    CreatedBy = missingPayrollBackPayment.CreatedBy,
                    ModifiedBy = missingPayrollBackPayment.ModifiedBy
                };

                db.MissingPayrollBackPaymentDetailPeriods.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBackPayment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDetailPeriods_Destroy([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDetailPeriod missingPayrollBackPayment)
        {
            //if (HasRelatedCheckBook(missingPayrollBack))
            //{
            //    ModelState.AddModelError("", "This bank has linked check book. you cannot delete it.");
            //}
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDetailPeriod
                {
                    MissingPayrollBackPaymentDetailPeriodId = missingPayrollBackPayment.MissingPayrollBackPaymentDetailPeriodId,
                    MissingPayrollBackPaymentLineId = missingPayrollBackPayment.MissingPayrollBackPaymentLineId,
                    GLPeriodId = missingPayrollBackPayment.GLPeriodId,
                    Description = missingPayrollBackPayment.Description,
                    DateCreated = missingPayrollBackPayment.DateCreated,
                    LastModified = missingPayrollBackPayment.LastModified,
                    CreatedBy = missingPayrollBackPayment.CreatedBy,
                    ModifiedBy = missingPayrollBackPayment.ModifiedBy
                };

                db.MissingPayrollBackPaymentDetailPeriods.Attach(entity);
                db.MissingPayrollBackPaymentDetailPeriods.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBackPayment }.ToDataSourceResult(request, ModelState));
        }
    }
}