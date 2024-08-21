using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.CheckPrint;
using ExceedERP.DataAccess.Context;
using System.IO;

namespace ExceedERP.Web.Areas.CheckPrint.Controllers
{
    public class CheckTemplatesController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            ViewData["Banks"] = db.CPBanks.Select(b => new { b.Name, b.CPBankId }).ToList();
            return View();
        }

        public ActionResult Templates_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CheckTemplate> templates = db.CheckTemplates;
            DataSourceResult result = templates.ToDataSourceResult(request, template => new CheckTemplate
            {
                CheckTemplateId = template.CheckTemplateId,
                PayingCompanyAccountNumber = template.PayingCompanyAccountNumber,
                PayingCompanyLogoFileName = template.PayingCompanyLogoFileName,
                PayingCompanyName = template.PayingCompanyName,
                PayingCompanySignitureFileName = template.PayingCompanySignitureFileName,
                CPBankId = template.CPBankId,
                BankLogoFileName = template.Bank.LogoFileName,
                
                DateCreated = template.DateCreated,
                LastModified = template.LastModified,
                CreatedBy = template.CreatedBy,
                ModifiedBy = template.ModifiedBy
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Template_Create([DataSourceRequest]DataSourceRequest request, CheckTemplate template)
        {
            if (ModelState.IsValid)
            {
                var entity = new CheckTemplate
                {
                    CheckTemplateId = template.CheckTemplateId,
                    PayingCompanyAccountNumber = template.PayingCompanyAccountNumber,
                    PayingCompanyLogoFileName = template.PayingCompanyLogoFileName,
                    PayingCompanyName = template.PayingCompanyName,
                    PayingCompanySignitureFileName = template.PayingCompanySignitureFileName,
                    CPBankId = template.CPBankId,

                    DateCreated = template.DateCreated,
                    LastModified = template.LastModified,
                    CreatedBy = template.CreatedBy,
                    ModifiedBy = template.ModifiedBy
                };

                db.CheckTemplates.Add(entity);
                db.SaveChanges();
                template.CPBankId = entity.CPBankId;
            }

            return Json(new[] { template }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Template_Update([DataSourceRequest]DataSourceRequest request, CheckTemplate template)
        {
            if (ModelState.IsValid)
            {
                var entity = new CheckTemplate
                {
                    CheckTemplateId = template.CheckTemplateId,
                    PayingCompanyAccountNumber = template.PayingCompanyAccountNumber,
                    PayingCompanyLogoFileName = template.PayingCompanyLogoFileName,
                    PayingCompanyName = template.PayingCompanyName,
                    PayingCompanySignitureFileName = template.PayingCompanySignitureFileName,
                    CPBankId = template.CPBankId,

                    DateCreated = template.DateCreated,
                    LastModified = template.LastModified,
                    CreatedBy = template.CreatedBy,
                    ModifiedBy = template.ModifiedBy
                };

                db.CheckTemplates.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { template }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Template_Destroy([DataSourceRequest]DataSourceRequest request, CheckTemplate template)
        {
            var checks = db.Checks.Where(c => c.CheckTemplateId == template.CheckTemplateId).ToList();
            if (checks.Any())
            {
                ModelState.AddModelError("", "There are cheks linked to this template. You cannot delete this template");
            }
            if (ModelState.IsValid)
            {
                var entity = new CheckTemplate
                {
                    CheckTemplateId = template.CheckTemplateId,
                    PayingCompanyAccountNumber = template.PayingCompanyAccountNumber,
                    PayingCompanyLogoFileName = template.PayingCompanyLogoFileName,
                    PayingCompanyName = template.PayingCompanyName,
                    PayingCompanySignitureFileName = template.PayingCompanySignitureFileName,
                    CPBankId = template.CPBankId,

                    DateCreated = template.DateCreated,
                    LastModified = template.LastModified,
                    CreatedBy = template.CreatedBy,
                    ModifiedBy = template.ModifiedBy
                };

                db.CheckTemplates.Attach(entity);
                db.CheckTemplates.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { template }.ToDataSourceResult(request, ModelState));
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
                        string path = HttpContext.Server.MapPath("~/Content/Images/CheckPrint/Logo/CheckTemplate/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        var newFileName = "company-logo-" + id + Path.GetExtension(file.FileName);
                        var filePath = path + newFileName;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        file.SaveAs(filePath);

                        var record = db.CheckTemplates.Find(id);
                        if (record != null)
                        {
                            record.PayingCompanyLogoFileName = newFileName;

                            db.CheckTemplates.Attach(record);
                            db.Entry(record).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        public void CheckTemplate_Signiture_Upload(int id, IEnumerable<HttpPostedFileBase> signiture)
        {
            if (ModelState.IsValid)
            {
                if (signiture != null && signiture.Count() > 0)
                {
                    foreach (var file in signiture)
                    {
                        string path = HttpContext.Server.MapPath("~/Content/Images/CheckPrint/Signiture/CheckTemplate/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        var newFileName = "template-signiture-" + id + Path.GetExtension(file.FileName);
                        var filePath = path + newFileName;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        file.SaveAs(filePath);

                        var record = db.CheckTemplates.Find(id);
                        if (record != null)
                        {
                            record.PayingCompanySignitureFileName = newFileName;

                            db.CheckTemplates.Attach(record);
                            db.Entry(record).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        [HttpPost]
        public JsonResult GetMainCompanyName()
        {
            var comp = db.Companies.FirstOrDefault(c => c.Category == "0");
            if(comp != null)
            {
                return Json(new { Name = comp.TradeName}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
             
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
