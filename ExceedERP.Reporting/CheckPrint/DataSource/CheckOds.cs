using ExceedERP.DataAccess.Context;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using ExceedERP.Reporting.CheckPrint.ViewModel;
using System.Data.Entity;

namespace ExceedERP.Reporting.CheckPrint.DataSource
{
    [DataObject]
    public class CheckOds
    {
        private readonly ExceedDbContext db = new ExceedDbContext();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<CheckReportViewModel> GetData(string bankId, string accountId, string checkBookId, DateTime? startDate, DateTime? endDate, string minAmount, string maxAmount)
        {

            List<CheckReportViewModel> list = new List<CheckReportViewModel>();
            var checkBooks = db.CPCheckBooks.ToList();

            if (string.IsNullOrEmpty(bankId) == false)
            {
                if (int.TryParse(bankId, out int bId))
                {
                    checkBooks = checkBooks.Where(c => c.CPBankId == bId).ToList();
                }
            }
            if (string.IsNullOrEmpty(accountId) == false)
            {
                if (int.TryParse(accountId, out int aId))
                {
                    checkBooks = checkBooks.Where(c => c.CPBankAccountId == aId).ToList();
                }
            }
            if (string.IsNullOrEmpty(checkBookId) == false)
            {
                if (int.TryParse(checkBookId, out int bookId))
                {
                    checkBooks = checkBooks.Where(c => c.CPCheckBookId == bookId).ToList();
                }
            }
            foreach (var checkBook in checkBooks)
            {
                var record = new CheckReportViewModel
                {
                    CheckBook = checkBook.Description,

                };
                var bank = db.CPBanks.Find(checkBook.CPBankId);
                var account = db.CPBankAccounts.Find(checkBook.CPBankAccountId);
                if (bank != null && account != null)
                {
                    record.Bank = $"{bank.Name}-{account.AccountNumber}";
                }
                var checksUnderCheckBook = db.Checks.Where(c => c.CPCheckBookId == checkBook.CPCheckBookId).ToList();
                if (startDate != null)
                {
                    checksUnderCheckBook = checksUnderCheckBook
                        .Where(d => DbFunctions.TruncateTime(d.Date) >= DbFunctions.TruncateTime(startDate)).ToList();
                }
                if (endDate != null)
                {
                    checksUnderCheckBook = checksUnderCheckBook
                        .Where(d => DbFunctions.TruncateTime(d.Date) <= DbFunctions.TruncateTime(endDate)).ToList();
                }
                if (string.IsNullOrEmpty(minAmount) == false)
                {
                    if (decimal.TryParse(minAmount, out decimal min))
                    {
                        checksUnderCheckBook = checksUnderCheckBook.Where(c => c.CheckAmount >= min).ToList();
                    }
                }
                if (string.IsNullOrEmpty(maxAmount) == false)
                {
                    if (decimal.TryParse(maxAmount, out decimal max))
                    {
                        checksUnderCheckBook = checksUnderCheckBook.Where(c => c.CheckAmount <= max).ToList();
                    }
                }
                foreach (var check in checksUnderCheckBook)
                {
                    var lineRecord = new CheckReportLineViewModel
                    {
                        CheckNumber = check.CheckNumber,
                        Date = check.Date.ToString("yyyy-MM-dd"),
                        Payee = check.Payee,
                        CheckAmount = check.CheckAmount
                    };
                    record.ChecksList.Add(lineRecord);
                }
                if (record.ChecksList.Any())
                {
                    list.Add(record);
                }
            }

            return list;

        }

    }
}
