﻿﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.Printing;
using ExceedERP.DataAccess.Context;

namespace ExceedERP.Web.Areas.Printing.Controllers
{
    public class PrintingOverAllCostController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrintingOverAllCosts_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            IQueryable<PrintingOverAllCost> printingoverallcosts = db.PrintingOverAllCosts.Where(x => x.PrintingCostEstimationId == id);
            DataSourceResult result = printingoverallcosts.ToDataSourceResult(request, printingOverAllCost => new PrintingOverAllCost
            {
                PrintingOverAllCostId = printingOverAllCost.PrintingOverAllCostId,
                MaterialCost = printingOverAllCost.MaterialCost,
                LaborCost = printingOverAllCost.LaborCost,
                TotalProductionCost = printingOverAllCost.TotalProductionCost,
                AdminstrativeCost = printingOverAllCost.AdminstrativeCost,
                ProfitMargin = printingOverAllCost.ProfitMargin,
                GraphicsCost = printingOverAllCost.GraphicsCost,
                UnitPrice = printingOverAllCost.UnitPrice,
                TotalBeforeVAT = printingOverAllCost.TotalBeforeVAT,
                VAT = printingOverAllCost.VAT,
                GrandTotal = printingOverAllCost.GrandTotal,
                PrintingCostEstimationId = printingOverAllCost.PrintingCostEstimationId
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrintingOverAllCosts_Create([DataSourceRequest]DataSourceRequest request, PrintingOverAllCost printingOverAllCost, int id)
        {
            if (ModelState.IsValid)
            {
                var entity = new PrintingOverAllCost
                {
                    MaterialCost = printingOverAllCost.MaterialCost,
                    LaborCost = printingOverAllCost.LaborCost,
                    TotalProductionCost = printingOverAllCost.TotalProductionCost,
                    AdminstrativeCost = printingOverAllCost.AdminstrativeCost,
                    ProfitMargin = printingOverAllCost.ProfitMargin,
                    GraphicsCost = printingOverAllCost.GraphicsCost,
                    UnitPrice = printingOverAllCost.UnitPrice,
                    TotalBeforeVAT = printingOverAllCost.TotalBeforeVAT,
                    VAT = printingOverAllCost.VAT,
                    GrandTotal = printingOverAllCost.GrandTotal,
                    PrintingCostEstimationId = id
                };

                db.PrintingOverAllCosts.Add(entity);
                db.SaveChanges();
                printingOverAllCost.PrintingOverAllCostId = entity.PrintingOverAllCostId;
            }

            return Json(new[] { printingOverAllCost }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrintingOverAllCosts_Update([DataSourceRequest]DataSourceRequest request, PrintingOverAllCost printingOverAllCost)
        {
            if (ModelState.IsValid)
            {
                var entity = new PrintingOverAllCost
                {
                    PrintingOverAllCostId = printingOverAllCost.PrintingOverAllCostId,
                    MaterialCost = printingOverAllCost.MaterialCost,
                    LaborCost = printingOverAllCost.LaborCost,
                    TotalProductionCost = printingOverAllCost.TotalProductionCost,
                    AdminstrativeCost = printingOverAllCost.AdminstrativeCost,
                    ProfitMargin = printingOverAllCost.ProfitMargin,
                    GraphicsCost = printingOverAllCost.GraphicsCost,
                    UnitPrice = printingOverAllCost.UnitPrice,
                    TotalBeforeVAT = printingOverAllCost.TotalBeforeVAT,
                    VAT = printingOverAllCost.VAT,
                    GrandTotal = printingOverAllCost.GrandTotal,
                    PrintingCostEstimationId = printingOverAllCost.PrintingCostEstimationId
                };

                db.PrintingOverAllCosts.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { printingOverAllCost }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult PrintingOverAllCosts_Destroy([DataSourceRequest]DataSourceRequest request, PrintingOverAllCost printingOverAllCost)
        {
            if (ModelState.IsValid)
            {
                var entity = new PrintingOverAllCost
                {
                    PrintingOverAllCostId = printingOverAllCost.PrintingOverAllCostId,
                    MaterialCost = printingOverAllCost.MaterialCost,
                    LaborCost = printingOverAllCost.LaborCost,
                    TotalProductionCost = printingOverAllCost.TotalProductionCost,
                    AdminstrativeCost = printingOverAllCost.AdminstrativeCost,
                    ProfitMargin = printingOverAllCost.ProfitMargin,
                    GraphicsCost = printingOverAllCost.GraphicsCost,
                    UnitPrice = printingOverAllCost.UnitPrice,
                    TotalBeforeVAT = printingOverAllCost.TotalBeforeVAT,
                    VAT = printingOverAllCost.VAT,
                    GrandTotal = printingOverAllCost.GrandTotal,
                    PrintingCostEstimationId = printingOverAllCost.PrintingCostEstimationId
                };

                db.PrintingOverAllCosts.Attach(entity);
                db.PrintingOverAllCosts.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { printingOverAllCost }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
