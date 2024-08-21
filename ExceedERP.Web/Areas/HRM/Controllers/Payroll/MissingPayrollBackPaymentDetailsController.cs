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
    public class MissingPayrollBackPaymentDetailsController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();
        public ActionResult MissingPayrollBackPaymentDetails_Read([DataSourceRequest]DataSourceRequest request, int missLineId)
        {
            
            IQueryable<MissingPayrollBackPaymentDetail> missingPayrollBackPaymentDetails = db.MissingPayrollBackPaymentDetails.Where(x => x.MissingPayrollBackPaymentLineId == missLineId);
            DataSourceResult result = missingPayrollBackPaymentDetails.ToDataSourceResult(request, missingPayrollBackPaymentDetail => new MissingPayrollBackPaymentDetail
            {
                MissingPayrollBackPaymentDetailId = missingPayrollBackPaymentDetail.MissingPayrollBackPaymentDetailId,
                MissingPayrollBackPaymentLineId = missingPayrollBackPaymentDetail.MissingPayrollBackPaymentLineId,
                GLPeriodId = missingPayrollBackPaymentDetail.GLPeriodId,
                Description = missingPayrollBackPaymentDetail.Description,
                Type = missingPayrollBackPaymentDetail.Type,
                Amount = missingPayrollBackPaymentDetail.Amount,
                DateCreated = missingPayrollBackPaymentDetail.DateCreated,
                CreatedBy = missingPayrollBackPaymentDetail.CreatedBy,
                LastModified = missingPayrollBackPaymentDetail.LastModified,
                ModifiedBy = missingPayrollBackPaymentDetail.ModifiedBy,
                
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDetails_Create([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDetail missingPayrollBackPaymentDetails, int missLineId)
        {
            //missingPayrollBackPayment.missingPayrollBackPaymentDetailsId = lineId;
            if (ModelState.IsValid)
            {

                var entity = new MissingPayrollBackPaymentDetail
                {
                    MissingPayrollBackPaymentDetailId = missingPayrollBackPaymentDetails.MissingPayrollBackPaymentDetailId,
                    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentDetails.MissingPayrollBackPaymentLineId,
                    GLPeriodId = missingPayrollBackPaymentDetails.GLPeriodId,
                    Description = missingPayrollBackPaymentDetails.Description,
                    Type = missingPayrollBackPaymentDetails.Type,
                    Amount = missingPayrollBackPaymentDetails.Amount,
                    DateCreated = missingPayrollBackPaymentDetails.DateCreated,
                    CreatedBy = missingPayrollBackPaymentDetails.CreatedBy,
                    LastModified = missingPayrollBackPaymentDetails.LastModified,
                    ModifiedBy = missingPayrollBackPaymentDetails.ModifiedBy,
                };

                db.MissingPayrollBackPaymentDetails.Add(entity);
                db.SaveChanges();
                missingPayrollBackPaymentDetails.MissingPayrollBackPaymentDetailId = entity.MissingPayrollBackPaymentDetailId;
            }

            return Json(new[] { missingPayrollBackPaymentDetails }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MissingPayrollBackPaymentDetails_Update([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDetail missingPayrollBackPaymentDetails)
        {
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDetail
                {
                    MissingPayrollBackPaymentDetailId = missingPayrollBackPaymentDetails.MissingPayrollBackPaymentDetailId,
                    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentDetails.MissingPayrollBackPaymentLineId,
                    GLPeriodId = missingPayrollBackPaymentDetails.GLPeriodId,
                    Description = missingPayrollBackPaymentDetails.Description,
                    Type = missingPayrollBackPaymentDetails.Type,
                    Amount = missingPayrollBackPaymentDetails.Amount,
                    DateCreated = missingPayrollBackPaymentDetails.DateCreated,
                    CreatedBy = missingPayrollBackPaymentDetails.CreatedBy,
                    LastModified = missingPayrollBackPaymentDetails.LastModified,
                    ModifiedBy = missingPayrollBackPaymentDetails.ModifiedBy,
                };

                db.MissingPayrollBackPaymentDetails.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBackPaymentDetails }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult missingPayrollBackPaymentDetailss_Destroy([DataSourceRequest]DataSourceRequest request, MissingPayrollBackPaymentDetail missingPayrollBackPaymentDetails)
        {
            //if (HasRelatedCheckBook(missingPayrollBack))
            //{
            //    ModelState.AddModelError("", "This bank has linked check book. you cannot delete it.");
            //}
            if (ModelState.IsValid)
            {
                var entity = new MissingPayrollBackPaymentDetail
                {
                    MissingPayrollBackPaymentDetailId = missingPayrollBackPaymentDetails.MissingPayrollBackPaymentDetailId,
                    MissingPayrollBackPaymentLineId = missingPayrollBackPaymentDetails.MissingPayrollBackPaymentLineId,
                    GLPeriodId = missingPayrollBackPaymentDetails.GLPeriodId,
                    Description = missingPayrollBackPaymentDetails.Description,
                    Type = missingPayrollBackPaymentDetails.Type,
                    Amount = missingPayrollBackPaymentDetails.Amount,
                    DateCreated = missingPayrollBackPaymentDetails.DateCreated,
                    CreatedBy = missingPayrollBackPaymentDetails.CreatedBy,
                    LastModified = missingPayrollBackPaymentDetails.LastModified,
                    ModifiedBy = missingPayrollBackPaymentDetails.ModifiedBy,
                };

                db.MissingPayrollBackPaymentDetails.Attach(entity);
                db.MissingPayrollBackPaymentDetails.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { missingPayrollBackPaymentDetails }.ToDataSourceResult(request, ModelState));
        }
    }
}