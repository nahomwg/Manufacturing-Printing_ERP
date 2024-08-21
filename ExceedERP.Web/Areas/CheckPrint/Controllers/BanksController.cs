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

namespace ExceedERP.Web.Areas.CheckPrint.Controllers
{
    public class BanksController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CPBanks_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CPBank> cpbanks = db.CPBanks;
            List<CPBank> list = new List<CPBank>();
            foreach (var bank in cpbanks)
            {
                bank.HasLinkedCheckBook = HasRelatedCheckBook(bank);
                list.Add(bank);
            }
            //DataSourceResult result = cpbanks.ToDataSourceResult(request, cPBank => new {
            //    CPBankId = cPBank.CPBankId,
            //    Name = cPBank.Name,
            //    Abbreviation = cPBank.Abbreviation,
            //    LogoFileName = cPBank.LogoFileName,
            //    DateCreated = cPBank.DateCreated,
            //    LastModified = cPBank.LastModified,
            //    CreatedBy = cPBank.CreatedBy,
            //    ModifiedBy = cPBank.ModifiedBy
            //});

            return Json(list.AsQueryable().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CPBanks_Create([DataSourceRequest]DataSourceRequest request, CPBank cPBank)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPBank
                {
                    Name = cPBank.Name,
                    Abbreviation = cPBank.Abbreviation,
                    LogoFileName = cPBank.LogoFileName,
                    DateCreated = cPBank.DateCreated,
                    LastModified = cPBank.LastModified,
                    CreatedBy = cPBank.CreatedBy,
                    ModifiedBy = cPBank.ModifiedBy
                };

                db.CPBanks.Add(entity);
                db.SaveChanges();
                cPBank.CPBankId = entity.CPBankId;
            }

            return Json(new[] { cPBank }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CPBanks_Update([DataSourceRequest]DataSourceRequest request, CPBank cPBank)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPBank
                {
                    CPBankId = cPBank.CPBankId,
                    Name = cPBank.Name,
                    Abbreviation = cPBank.Abbreviation,
                    LogoFileName = cPBank.LogoFileName,
                    DateCreated = cPBank.DateCreated,
                    LastModified = cPBank.LastModified,
                    CreatedBy = cPBank.CreatedBy,
                    ModifiedBy = cPBank.ModifiedBy
                };

                db.CPBanks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { cPBank }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CPBanks_Destroy([DataSourceRequest]DataSourceRequest request, CPBank cPBank)
        {
            if (HasRelatedCheckBook(cPBank))
            {
                ModelState.AddModelError("", "This bank has linked check book. you cannot delete it.");
            }
            if (ModelState.IsValid)
            {
                var entity = new CPBank
                {
                    CPBankId = cPBank.CPBankId,
                    Name = cPBank.Name,
                    Abbreviation = cPBank.Abbreviation,
                    LogoFileName = cPBank.LogoFileName,
                    DateCreated = cPBank.DateCreated,
                    LastModified = cPBank.LastModified,
                    CreatedBy = cPBank.CreatedBy,
                    ModifiedBy = cPBank.ModifiedBy
                };

                db.CPBanks.Attach(entity);
                db.CPBanks.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { cPBank }.ToDataSourceResult(request, ModelState));
        }
        private bool HasRelatedCheckBook(CPBank bank)
        {
           return db.CPCheckBooks.Any(b => b.CPBankId == bank.CPBankId);
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
