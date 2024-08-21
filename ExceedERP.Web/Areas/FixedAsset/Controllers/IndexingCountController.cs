using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.DataAccess.Context;
using System.IO;
using ExceedERP.Core.Domain.FixedAsset;

namespace ExceedERP.Web.Areas.FixedAsset.Controllers
{
    public class IndexingCountController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult IndexingCount_Read([DataSourceRequest]DataSourceRequest request)
        {
            
            IQueryable<IndexingCount> indexingCounts  = db.IndexingCount;
            DataSourceResult result = indexingCounts.ToDataSourceResult(request, indexingCount => new IndexingCount
            {
                IndexCode = indexingCount.IndexCode,
                SubCategoryCode = indexingCount.SubCategoryCode,
                CurrentValue = indexingCount.CurrentValue,
                DateCreated = indexingCount.DateCreated,
                LastModified = indexingCount.LastModified,
                CreatedBy = indexingCount.CreatedBy,
                ModifiedBy = indexingCount.ModifiedBy
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IndexingCount_Create([DataSourceRequest]DataSourceRequest request, IndexingCount indexingCount)
        {
           
            if (ModelState.IsValid)
            {
                var entity = new IndexingCount
                {
                    IndexCode = new Guid().ToString(),
                    SubCategoryCode = indexingCount.SubCategoryCode,
                    CurrentValue = indexingCount.CurrentValue,
                    DateCreated = indexingCount.DateCreated,
                    LastModified = indexingCount.LastModified,
                    CreatedBy = indexingCount.CreatedBy,
                    ModifiedBy = indexingCount.ModifiedBy
                };

                db.IndexingCount.Add(entity);
                db.SaveChanges();
                indexingCount.IndexCode = entity.IndexCode;
            }

            return Json(new[] { indexingCount }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IndexingCount_Update([DataSourceRequest]DataSourceRequest request, IndexingCount indexingCount)
        {
           
            if (ModelState.IsValid)
            {
                var entity = new IndexingCount
                {
                    IndexCode = indexingCount.IndexCode,
                    SubCategoryCode = indexingCount.SubCategoryCode,
                    CurrentValue = indexingCount.CurrentValue,
                    DateCreated = indexingCount.DateCreated,
                    LastModified = indexingCount.LastModified,
                    CreatedBy = indexingCount.CreatedBy,
                    ModifiedBy = indexingCount.ModifiedBy
                };

                db.IndexingCount.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { indexingCount }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult IndexingCount_Destroy([DataSourceRequest]DataSourceRequest request, IndexingCount indexingCount)
        {
            //if (HasRelatedCheckBook(missingPayrollBack))
            //{
            //    ModelState.AddModelError("", "This bank has linked check book. you cannot delete it.");
            //}
            if (ModelState.IsValid)
            {
                var entity = new IndexingCount
                {
                    IndexCode = indexingCount.IndexCode,
                    SubCategoryCode = indexingCount.SubCategoryCode,
                    CurrentValue = indexingCount.CurrentValue,
                    DateCreated = indexingCount.DateCreated,
                    LastModified = indexingCount.LastModified,
                    CreatedBy = indexingCount.CreatedBy,
                    ModifiedBy = indexingCount.ModifiedBy
                };

                db.IndexingCount.Attach(entity);
                db.IndexingCount.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { indexingCount }.ToDataSourceResult(request, ModelState));
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
