﻿﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.Manufacturing.Production;
using ExceedERP.DataAccess.Context;
using ExceedERP.Core.Domain.Manufacturing.Setting;

namespace ExceedERP.Web.Areas.Manufacturing.Controllers
{
    public class FurnitureDailyProductionFollowUpController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult FurnitureDailyProductionFollowUps_Read([DataSourceRequest]DataSourceRequest request, int id, WorkShop workShop)
        {
            IQueryable<FurnitureDailyProductionFollowUp> furnituredailyproductionfollowups = db.FurnitureDailyProductionFollowUps.Where(x => x.FurnitureJobOrderProductionId == id && x.WorkShop == workShop);
            DataSourceResult result = furnituredailyproductionfollowups.ToDataSourceResult(request, furnitureDailyProductionFollowUp => new FurnitureDailyProductionFollowUp
            {
                FurnitureDailyProductionFollowUpId = furnitureDailyProductionFollowUp.FurnitureDailyProductionFollowUpId,
                WorkShop = furnitureDailyProductionFollowUp.WorkShop,
                ManifucturingTaskCategoryId = furnitureDailyProductionFollowUp.ManifucturingTaskCategoryId,
                EmployeeId = furnitureDailyProductionFollowUp.EmployeeId,
                DateExcuted = furnitureDailyProductionFollowUp.DateExcuted,
                
                DailyProductionPlan = furnitureDailyProductionFollowUp.DailyProductionPlan,
                DailyProductionActual = furnitureDailyProductionFollowUp.DailyProductionActual,
                FurnitureJobOrderProductionId = furnitureDailyProductionFollowUp.FurnitureJobOrderProductionId,
                DateCreated = furnitureDailyProductionFollowUp.DateCreated,
                LastModified = furnitureDailyProductionFollowUp.LastModified,
                CreatedBy = furnitureDailyProductionFollowUp.CreatedBy,
                ModifiedBy = furnitureDailyProductionFollowUp.ModifiedBy,
                
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FurnitureDailyProductionFollowUps_Create([DataSourceRequest]DataSourceRequest request, FurnitureDailyProductionFollowUp furnitureDailyProductionFollowUp)
        {
            if (ModelState.IsValid)
            {
                var entity = new FurnitureDailyProductionFollowUp
                {
                    WorkShop = furnitureDailyProductionFollowUp.WorkShop,
                    ManifucturingTaskCategoryId = furnitureDailyProductionFollowUp.ManifucturingTaskCategoryId,
                    EmployeeId = furnitureDailyProductionFollowUp.EmployeeId,
                    DateExcuted = furnitureDailyProductionFollowUp.DateExcuted,
                    
                    DailyProductionPlan = furnitureDailyProductionFollowUp.DailyProductionPlan,
                    DailyProductionActual = furnitureDailyProductionFollowUp.DailyProductionActual,
                    FurnitureJobOrderProductionId = furnitureDailyProductionFollowUp.FurnitureJobOrderProductionId,
                    DateCreated = furnitureDailyProductionFollowUp.DateCreated,
                    LastModified = furnitureDailyProductionFollowUp.LastModified,
                    CreatedBy = furnitureDailyProductionFollowUp.CreatedBy,
                    ModifiedBy = furnitureDailyProductionFollowUp.ModifiedBy
                };

                db.FurnitureDailyProductionFollowUps.Add(entity);
                db.SaveChanges();
                furnitureDailyProductionFollowUp.FurnitureDailyProductionFollowUpId = entity.FurnitureDailyProductionFollowUpId;
            }

            return Json(new[] { furnitureDailyProductionFollowUp }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FurnitureDailyProductionFollowUps_Update([DataSourceRequest]DataSourceRequest request, FurnitureDailyProductionFollowUp furnitureDailyProductionFollowUp)
        {
            if (ModelState.IsValid)
            {
                var entity = new FurnitureDailyProductionFollowUp
                {
                    FurnitureDailyProductionFollowUpId = furnitureDailyProductionFollowUp.FurnitureDailyProductionFollowUpId,
                    WorkShop = furnitureDailyProductionFollowUp.WorkShop,
                    ManifucturingTaskCategoryId = furnitureDailyProductionFollowUp.ManifucturingTaskCategoryId,
                    EmployeeId = furnitureDailyProductionFollowUp.EmployeeId,
                    DateExcuted = furnitureDailyProductionFollowUp.DateExcuted,
                    
                    DailyProductionPlan = furnitureDailyProductionFollowUp.DailyProductionPlan,
                    DailyProductionActual = furnitureDailyProductionFollowUp.DailyProductionActual,
                    FurnitureJobOrderProductionId = furnitureDailyProductionFollowUp.FurnitureJobOrderProductionId,
                    DateCreated = furnitureDailyProductionFollowUp.DateCreated,
                    LastModified = furnitureDailyProductionFollowUp.LastModified,
                    CreatedBy = furnitureDailyProductionFollowUp.CreatedBy,
                    ModifiedBy = furnitureDailyProductionFollowUp.ModifiedBy
                };

                db.FurnitureDailyProductionFollowUps.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { furnitureDailyProductionFollowUp }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FurnitureDailyProductionFollowUps_Destroy([DataSourceRequest]DataSourceRequest request, FurnitureDailyProductionFollowUp furnitureDailyProductionFollowUp)
        {
            if (ModelState.IsValid)
            {
                var entity = new FurnitureDailyProductionFollowUp
                {
                    FurnitureDailyProductionFollowUpId = furnitureDailyProductionFollowUp.FurnitureDailyProductionFollowUpId,
                    WorkShop = furnitureDailyProductionFollowUp.WorkShop,
                    ManifucturingTaskCategoryId = furnitureDailyProductionFollowUp.ManifucturingTaskCategoryId,
                    EmployeeId = furnitureDailyProductionFollowUp.EmployeeId,
                    DateExcuted = furnitureDailyProductionFollowUp.DateExcuted,
                    
                    DailyProductionPlan = furnitureDailyProductionFollowUp.DailyProductionPlan,
                    DailyProductionActual = furnitureDailyProductionFollowUp.DailyProductionActual,
                    FurnitureJobOrderProductionId = furnitureDailyProductionFollowUp.FurnitureJobOrderProductionId,
                    DateCreated = furnitureDailyProductionFollowUp.DateCreated,
                    LastModified = furnitureDailyProductionFollowUp.LastModified,
                    CreatedBy = furnitureDailyProductionFollowUp.CreatedBy,
                    ModifiedBy = furnitureDailyProductionFollowUp.ModifiedBy
                };

                db.FurnitureDailyProductionFollowUps.Attach(entity);
                db.FurnitureDailyProductionFollowUps.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { furnitureDailyProductionFollowUp }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}