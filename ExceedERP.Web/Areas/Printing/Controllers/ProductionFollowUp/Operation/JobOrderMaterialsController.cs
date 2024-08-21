﻿using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.DataAccess.Context;
using ExceedERP.Web.Helpers;
using ExceedERP.Core.Domain.Printing.ProductionFollowUp;

namespace ExceedERP.Web.Areas.Printing.Controllers.ProductionFollowUp.Operation
{
   // [AuthorizeRoles(ProductionFollowUpRoles.ProductionFollowUpRJobOrderUser)]
    public class JobOrderMaterialsController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public double GetBeforeVat(double quantity, double unitPrice)
        {
            return quantity * unitPrice;
        }
        public double GetTotaPrice(int id, double quantity, double unitPrice)
        {
            double totalPrice = 0;

            var jobOrder = db.Jobs.FirstOrDefault(x => x.JobId == id);
            if (jobOrder != null)
            {
                var jobType = db.JobCategories.FirstOrDefault(x => x.JobCategoryId == jobOrder.JobTypeId);
                if (jobType != null)
                {
                    var tax = db.GLTaxRates.FirstOrDefault(x => x.GLTaxRateID == jobType.GLTaxRateID);
                    if (tax != null)
                    {
                        totalPrice = (quantity * unitPrice) + (quantity * unitPrice * Convert.ToDouble(tax.CalculatedRate));
                    }
                }
            }
            return totalPrice;
        }
        public ActionResult JobOrderMaterials_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            IQueryable<JobOrderMaterial> joborderpapertypes = db.JobOrderMaterials.Where(x => x.JobId == id);
            DataSourceResult result = joborderpapertypes.ToDataSourceResult(request, jobOrderMaterial => new
            {
                JobOrderMaterialId = jobOrderMaterial.JobOrderMaterialId,
                JobId = jobOrderMaterial.JobId,
                Name = jobOrderMaterial.Name,
                Type = jobOrderMaterial.Type,
                Gram = jobOrderMaterial.Gram,
                Size = jobOrderMaterial.Size,
                Quantity = jobOrderMaterial.Quantity,
                UnitPrice = jobOrderMaterial.UnitPrice,
                BeforeVat = GetBeforeVat(jobOrderMaterial.Quantity, jobOrderMaterial.UnitPrice),
                TotalPrice = GetTotaPrice(jobOrderMaterial.JobId, jobOrderMaterial.Quantity, jobOrderMaterial.UnitPrice),
                SIVNo = jobOrderMaterial.SIVNo,
                Remark = jobOrderMaterial.Remark
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobOrderMaterials_Create([DataSourceRequest]DataSourceRequest request, JobOrderMaterial jobOrderMaterial, int id)
        {
            jobOrderMaterial.TotalPrice = jobOrderMaterial.Quantity * jobOrderMaterial.UnitPrice;

            if (ModelState.IsValid)
            {
                var entity = new JobOrderMaterial
                {
                    JobId = id,
                    Name = jobOrderMaterial.Name,
                    Type = jobOrderMaterial.Type,
                    Gram = jobOrderMaterial.Gram,
                    Size = jobOrderMaterial.Size,
                    Quantity = jobOrderMaterial.Quantity,
                    UnitPrice = jobOrderMaterial.UnitPrice,
                    TotalPrice = jobOrderMaterial.TotalPrice,
                    SIVNo = jobOrderMaterial.SIVNo,
                    Remark = jobOrderMaterial.Remark
                };

                db.JobOrderMaterials.Add(entity);
                db.SaveChanges();
                jobOrderMaterial.JobOrderMaterialId = entity.JobOrderMaterialId;
            }

            return Json(new[] { jobOrderMaterial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobOrderMaterials_Update([DataSourceRequest]DataSourceRequest request, JobOrderMaterial jobOrderMaterial)
        {
            jobOrderMaterial.TotalPrice = jobOrderMaterial.Quantity * jobOrderMaterial.UnitPrice;

            if (ModelState.IsValid)
            {
                var entity = new JobOrderMaterial
                {
                    JobOrderMaterialId = jobOrderMaterial.JobOrderMaterialId,
                    JobId = jobOrderMaterial.JobId,
                    Name = jobOrderMaterial.Name,
                    Type = jobOrderMaterial.Type,
                    Gram = jobOrderMaterial.Gram,
                    Size = jobOrderMaterial.Size,
                    Quantity = jobOrderMaterial.Quantity,
                    UnitPrice = jobOrderMaterial.UnitPrice,
                    TotalPrice = jobOrderMaterial.TotalPrice,
                    SIVNo = jobOrderMaterial.SIVNo,
                    Remark = jobOrderMaterial.Remark
                };

                db.JobOrderMaterials.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { jobOrderMaterial }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult JobOrderMaterials_Destroy([DataSourceRequest]DataSourceRequest request, JobOrderMaterial jobOrderMaterial)
        {
            if (ModelState.IsValid)
            {
                var entity = new JobOrderMaterial
                {
                    JobOrderMaterialId = jobOrderMaterial.JobOrderMaterialId,
                    JobId = jobOrderMaterial.JobId,
                    Name = jobOrderMaterial.Name,
                    Type = jobOrderMaterial.Type,
                    Gram = jobOrderMaterial.Gram,
                    Size = jobOrderMaterial.Size,
                    Quantity = jobOrderMaterial.Quantity,
                    UnitPrice = jobOrderMaterial.UnitPrice,
                    TotalPrice = jobOrderMaterial.TotalPrice,
                    SIVNo = jobOrderMaterial.SIVNo,
                    Remark = jobOrderMaterial.Remark
                };

                db.JobOrderMaterials.Attach(entity);
                db.JobOrderMaterials.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { jobOrderMaterial }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
