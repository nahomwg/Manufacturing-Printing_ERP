using ExceedERP.DataAccess.Context;
using System.ComponentModel;
using ExceedERP.Reporting.CheckPrint.ViewModel;

namespace ExceedERP.Reporting.CheckPrint.DataSource
{
    [DataObject]
    public class CheckPrintOds
    {
        private readonly ExceedDbContext db = new ExceedDbContext();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public CheckPrintViewModel GetCustomerTicketList(string code)
        {

            if (string.IsNullOrEmpty(code))
            {
                return null;
            }
            else
            {
                var vm = new CheckPrintViewModel();

                //var check = db.Checks.FirstOrDefault(c => c.Code == code);
                //if (check != null)
                //{
                //    vm.PayingCompanyName = check.CheckTemplate.PayingCompanyName;
                //    vm.PayingCompanyAccountNumber = check.CheckTemplate.PayingCompanyAccountNumber;

                //    string companyLogoFile = HostingEnvironment.MapPath("~/Content/Images/CheckPrint/Logo/CheckTemplate/" + check.CheckTemplate.PayingCompanyLogoFileName);
                //    if (File.Exists(companyLogoFile))
                //    {
                //        byte[] companyLogoBytes = System.IO.File.ReadAllBytes(companyLogoFile);
                //        vm.CompanyLogo = OrganizationObjectDataSource.ByteArrayToImage(companyLogoBytes);
                //    }
                //    string signitureFile = HostingEnvironment.MapPath("~/Content/Images/CheckPrint/Signiture/CheckTemplate/" + check.CheckTemplate.PayingCompanySignitureFileName);
                //    if (File.Exists(signitureFile))
                //    {
                //        byte[] signitureBytes = System.IO.File.ReadAllBytes(signitureFile);
                //        vm.Signiture = OrganizationObjectDataSource.ByteArrayToImage(signitureBytes);

                //    }
                //    vm.BankName = check.CheckTemplate.Bank.Name;

                //    vm.CheckTemplateId = check.CheckTemplateId;
                //    vm.Date = check.Date.ToString("yyyy-MM-dd");
                //    vm.PayableTo = check.PayableTo;
                //    vm.PayableFor = check.PayableFor;
                //    vm.BBF = check.BBF;
                //    vm.Deposits = check.Deposits;
                //    vm.Total = check.Total;
                //    vm.ThisCheck = check.ThisCheck;
                //    vm.Balance = check.Balance;
                //    vm.CheckNumber = check.CheckNumber;
                //    vm.Payee = check.Payee;
                //    vm.CheckAmount = check.CheckAmount;
                //    vm.CheckAmountInWords = NumberExtensions.toWords((int)check.CheckAmount) + " Birr ";
                //    vm.IsSigned = check.IsSigned;
                //    vm.Code = check.Code;
                //    vm.SignedBy = check.SignedBy;
                //    vm.SignedOn = check.SignedOn;
                //}

                return vm;
            }
        }


    }
}
