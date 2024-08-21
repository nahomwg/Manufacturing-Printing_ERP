﻿﻿using System;
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
using ExceedERP.Core.Domain.Finance.GL.Dynamic;
using ExceedERP.Core.Domain.printing.JobCosting;

namespace ExceedERP.Web.Areas.Printing.Controllers.JobCosting

{
    //[AuthorizeRoles(JobCostingRoles.JobCostingIdleTime)]
    public class IdleTimeController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            var glsegmentId = db.GlSegmentSetups.FirstOrDefault(x => x.SegmentType == DynamicSegmentTypes.CostCenter)?.GLSegmentSetupId ?? 0;

            var costcenters = db.GlChartOfAccountSegments.Where(x => x.GLSegmentSetupId == glsegmentId).AsQueryable();
            ViewData["CostCenters"] = costcenters.ToList();

            ViewData["ControllableIdleTimeCategories"] = db.IdleTimeCategories.Where(q=>q.IsControllable ==true).ToList();
            ViewData["NonControllableIdleTimeCategories"] = db.IdleTimeCategories.Where(q=>q.IsControllable == false).ToList();
            ViewData["FiscalYears"] = db.GLFiscalYears.ToList();
            ViewData["Periods"] = db.GLPeriods.ToList();
            return View();
        }

        public ActionResult IdleTimes_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<IdleTime> idletimes = db.IdleTimes;
            DataSourceResult result = idletimes.ToDataSourceResult(request, idleTime => new {
                IdleTimeID = idleTime.IdleTimeID,
                GlFiscalYearId = idleTime.GlFiscalYearId,
                GLPeriodId = idleTime.GLPeriodId
            });

            return Json(result);
        }

        public ActionResult IdleTimes_Create([DataSourceRequest]DataSourceRequest request, IdleTime idleTime)
        {
            if (ModelState.IsValid)
            {
                var entity = (IdleTime)this.GetObject(idleTime);
                db.IdleTimes.Add(entity);
                db.SaveChanges();
                idleTime.IdleTimeID = entity.IdleTimeID;
            }

            return Json(new[] { idleTime }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IdleTimes_Update([DataSourceRequest]DataSourceRequest request, IdleTime idleTime)
        {
            if (ModelState.IsValid)
            {
                var entity = (IdleTime)this.GetObject(idleTime);

                db.IdleTimes.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { idleTime }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IdleTimes_Destroy([DataSourceRequest]DataSourceRequest request, IdleTime idleTime)
        {

            if (ModelState.IsValid)
            {
                var entity = (IdleTime)this.GetObject(idleTime);

                db.IdleTimes.Attach(entity);
                db.IdleTimes.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { idleTime }.ToDataSourceResult(request, ModelState));
        }

        private object GetObject(IdleTime idleTime)
        {
            var entity = new IdleTime
            {
                IdleTimeID = idleTime.IdleTimeID,
                GlFiscalYearId = idleTime.GlFiscalYearId,
                GLPeriodId = idleTime.GLPeriodId

            };
            return entity;
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}