using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ExceedERP.Core.Domain.CheckPrint;
using ExceedERP.DataAccess.Context;

namespace ExceedERP.Web.Areas.CheckPrint.Controllers
{
    public class CheckBooksController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Index()
        {
            ViewData["Banks"] = db.CPBanks.Select(b => new { b.Name, b.CPBankId }).ToList();
            ViewData["BankAccounts"] = db.CPBankAccounts.Select(b => new { b.AccountNumber, b.CPBankAccountId }).ToList();


            return View();
        }

        public ActionResult Books_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CPCheckBook> books = db.CPCheckBooks;
            List<CPCheckBook> list = new List<CPCheckBook>();
            foreach (var book in books)
            {
                var hasChecks = HasLinkedChecks(book);
                book.HasChecks = hasChecks;
                list.Add(book);
            }

            return Json(list.AsQueryable().ToDataSourceResult(request));
        }

        private bool HasLinkedChecks(CPCheckBook book)
        {
            return db.Checks.Any(c => c.CPCheckBookId == book.CPCheckBookId);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Create([DataSourceRequest]DataSourceRequest request, CPCheckBook book)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPCheckBook
                {
                    CPCheckBookId = book.CPCheckBookId,
                    CPBankId = book.CPBankId,
                    CPBankAccountId = book.CPBankAccountId,

                    NumberOfChecks = book.NumberOfChecks,
                    StartCheckNumber = book.StartCheckNumber,
                    EndCheckNumber = book.EndCheckNumber,
                    Description = book.Description,
                    Reference = book.Reference,

                    DateCreated = DateTime.Now,
                    LastModified = book.LastModified,
                    CreatedBy = User.Identity.Name,
                    ModifiedBy = book.ModifiedBy
                };

                entity.EndCheckNumber = entity.StartCheckNumber + (entity.NumberOfChecks - 1);
                entity.Description = $"({entity.StartCheckNumber} - {entity.EndCheckNumber})";

                db.CPCheckBooks.Add(entity);
                db.SaveChanges();
                book.CPCheckBookId = entity.CPCheckBookId;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Update([DataSourceRequest]DataSourceRequest request, CPCheckBook book)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPCheckBook
                {
                    CPCheckBookId = book.CPCheckBookId,
                    CPBankId = book.CPBankId,
                    CPBankAccountId = book.CPBankAccountId,

                    NumberOfChecks = book.NumberOfChecks,
                    StartCheckNumber = book.StartCheckNumber,
                    EndCheckNumber = book.EndCheckNumber,
                    Description = book.Description,
                    Reference = book.Reference,

                    DateCreated = book.DateCreated,
                    LastModified = DateTime.Now,
                    CreatedBy = book.CreatedBy,
                    ModifiedBy = User.Identity.Name
                };
                entity.EndCheckNumber = entity.StartCheckNumber + (entity.NumberOfChecks - 1);
                entity.Description = $"({entity.StartCheckNumber} - {entity.EndCheckNumber})";

                db.CPCheckBooks.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Destroy([DataSourceRequest]DataSourceRequest request, CPCheckBook book)
        {
            if (HasLinkedChecks(book))
            {
                ModelState.AddModelError("", "This check book contains check(s). It cannot be deleted ");
            }
            if (ModelState.IsValid)
            {
                var entity = new CPCheckBook
                {
                    CPCheckBookId = book.CPCheckBookId,
                    CPBankId = book.CPBankId,
                    CPBankAccountId = book.CPBankAccountId,

                    NumberOfChecks = book.NumberOfChecks,
                    StartCheckNumber = book.StartCheckNumber,
                    EndCheckNumber = book.EndCheckNumber,
                    Description = book.Description,
                    Reference = book.Reference,

                    DateCreated = book.DateCreated,
                    LastModified = book.LastModified,
                    CreatedBy = book.CreatedBy,
                    ModifiedBy = book.ModifiedBy
                };

                db.CPCheckBooks.Attach(entity);
                db.CPCheckBooks.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
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
       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
