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
    public class BankAccountsController : Controller
    {
        private ExceedDbContext db = new ExceedDbContext();

        public ActionResult CPBanks_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            List<CPBankAccount> cpbanks = db.CPBankAccounts.Where(b => b.CPBankId == id).ToList();
            DataSourceResult result = cpbanks.ToDataSourceResult(request, bankAccount => new CPBankAccount {
                CPBankId = bankAccount.CPBankId,
                CPBankAccountId = bankAccount.CPBankAccountId,
                AccountNumber = bankAccount.AccountNumber,
                HasLinkedCheckBook = HasLinkedCheckBook(bankAccount),

                DateCreated = bankAccount.DateCreated,
                LastModified = bankAccount.LastModified,
                CreatedBy = bankAccount.CreatedBy,
                ModifiedBy = bankAccount.ModifiedBy
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CPBanks_Create([DataSourceRequest]DataSourceRequest request, CPBankAccount bankAccount, int id)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPBankAccount
                {
                    CPBankId =id,
                    CPBankAccountId = bankAccount.CPBankAccountId,
                    AccountNumber = bankAccount.AccountNumber,

                    DateCreated = bankAccount.DateCreated,
                    LastModified = bankAccount.LastModified,
                    CreatedBy = bankAccount.CreatedBy,
                    ModifiedBy = bankAccount.ModifiedBy
                };

                db.CPBankAccounts.Add(entity);
                db.SaveChanges();
                bankAccount.CPBankId = entity.CPBankId;
            }

            return Json(new[] { bankAccount }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CPBanks_Update([DataSourceRequest]DataSourceRequest request, CPBankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPBankAccount
                {
                    CPBankId = bankAccount.CPBankId,
                    AccountNumber = bankAccount.AccountNumber,
                    CPBankAccountId = bankAccount.CPBankAccountId,
                    
                    DateCreated = bankAccount.DateCreated,
                    LastModified = bankAccount.LastModified,
                    CreatedBy = bankAccount.CreatedBy,
                    ModifiedBy = bankAccount.ModifiedBy
                };

                db.CPBankAccounts.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { bankAccount }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CPBanks_Destroy([DataSourceRequest]DataSourceRequest request, CPBankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                var entity = new CPBankAccount
                {
                    CPBankId = bankAccount.CPBankId,
                    AccountNumber = bankAccount.AccountNumber,
                    CPBankAccountId = bankAccount.CPBankAccountId,

                    DateCreated = bankAccount.DateCreated,
                    LastModified = bankAccount.LastModified,
                    CreatedBy = bankAccount.CreatedBy,
                    ModifiedBy = bankAccount.ModifiedBy
                };

                db.CPBankAccounts.Attach(entity);
                db.CPBankAccounts.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { bankAccount }.ToDataSourceResult(request, ModelState));
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
        private bool HasLinkedCheckBook(CPBankAccount cPBankAccount)
        {
            return db.CPCheckBooks.Any(c => c.CPBankAccountId == cPBankAccount.CPBankAccountId);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
