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
    public class CheckBookCheckNumbersController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult Books_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            IQueryable<CPCheckBookCheckNumber> books = db.CPCheckBookCheckNumbers.Where(bn => bn.CPCheckBookId == id);
            List<CPCheckBookCheckNumber> list = new List<CPCheckBookCheckNumber>();
            var checkBook = db.CPCheckBooks.Find(id);
            if(books.Any() == false && checkBook != null)
            {
                for(int i=0; i<checkBook.NumberOfChecks; i++)
                {
                    var record = new CPCheckBookCheckNumber
                    {
                        CPCheckBookId = id,
                        CheckNumber = checkBook.StartCheckNumber + i,
                        Status = CheckNumberStatus.New,

                        DateCreated = DateTime.Now,
                        CreatedBy = User.Identity.Name,

                    };
                    db.CPCheckBookCheckNumbers.Add(record);
                    db.SaveChanges();
                    list.Add(record);
                }

            }
            else
            {
                list.AddRange(books);
            }
            return Json(list.AsQueryable().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Create([DataSourceRequest]DataSourceRequest request, CPCheckBookCheckNumber book, int id)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPCheckBookCheckNumber
                {
                    CPCheckBookCheckNumberId = book.CPCheckBookCheckNumberId,
                    CPCheckBookId =id,
                    CheckNumber = book.CheckNumber,
                    Status = book.Status,

                    DateCreated = DateTime.Now,
                    LastModified = book.LastModified,
                    CreatedBy = User.Identity.Name,
                    ModifiedBy = book.ModifiedBy
                };

               
                db.CPCheckBookCheckNumbers.Add(entity);
                db.SaveChanges();
                book.CPCheckBookCheckNumberId = entity.CPCheckBookCheckNumberId;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Update([DataSourceRequest]DataSourceRequest request, CPCheckBookCheckNumber book)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPCheckBookCheckNumber
                {
                    CPCheckBookCheckNumberId = book.CPCheckBookCheckNumberId,
                    CPCheckBookId = book.CPCheckBookId,
                    CheckNumber = book.CheckNumber,
                    Status = book.Status,

                    DateCreated = book.DateCreated,
                    LastModified = DateTime.Now,
                    CreatedBy = book.CreatedBy,
                    ModifiedBy = User.Identity.Name
                };
               
                db.CPCheckBookCheckNumbers.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Books_Destroy([DataSourceRequest]DataSourceRequest request, CPCheckBookCheckNumber book)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPCheckBookCheckNumber
                {
                    CPCheckBookCheckNumberId = book.CPCheckBookCheckNumberId,
                    CPCheckBookId = book.CPCheckBookId,
                    CheckNumber = book.CheckNumber,
                    Status = book.Status,

                    DateCreated = book.DateCreated,
                    LastModified = book.LastModified,
                    CreatedBy = book.CreatedBy,
                    ModifiedBy = book.ModifiedBy
                };

                db.CPCheckBookCheckNumbers.Attach(entity);
                db.CPCheckBookCheckNumbers.Remove(entity);
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
