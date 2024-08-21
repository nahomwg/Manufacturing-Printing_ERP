using ExceedERP.DataAccess.Context;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace ExceedERP.Reporting.CheckPrint.DataSource
{
    [DataObject]
    public class CheckPrintParametersOds
    {
        private readonly ExceedDbContext db = new ExceedDbContext();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<object> GetBanks()
        {
            List<object> list = new List<object>();
            var banks = db.CPBanks.ToList();
            foreach (var bank in banks)
            {
                var record = new
                {
                    Text = bank.Name,
                    Value = bank.CPBankId
                };
                list.Add(record);
            }
            return list;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<object> GetAccountNumbers(string bankId)
        {
            List<object> list = new List<object>();
            if (string.IsNullOrEmpty(bankId))
            {
                return list;
            }
            else
            {
                int.TryParse(bankId, out int bId);
                var data = db.CPBankAccounts.Where(a => a.CPBankAccountId == bId).ToList();
                foreach (var account in data)
                {
                    var record = new
                    {
                        Text = account.AccountNumber,
                        Value = account.CPBankAccountId
                    };
                    list.Add(record);
                }
            }
            return list;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<object> GetCheckBooks(string bankId, string accountId)
        {
            List<object> list = new List<object>();
            if (string.IsNullOrEmpty(bankId) || string.IsNullOrEmpty(accountId))
            {
                return list;
            }
            else
            {
                int.TryParse(bankId, out int bId);
                int.TryParse(accountId, out int acId);
                var data = db.CPCheckBooks.Where(a => a.CPBankAccountId == bId && a.CPBankAccountId == acId).ToList();
                foreach (var account in data)
                {
                    var record = new
                    {
                        Text = account.Description,
                        Value = account.CPBankAccountId
                    };
                    list.Add(record);
                }
            }
            return list;
        }
    }
}
