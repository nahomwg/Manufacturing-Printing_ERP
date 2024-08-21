using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace ExceedERP.Reporting.CheckPrint.ViewModel
{
    public class CheckPrintViewModel
    {

        // company info
        public string PayingCompanyAccountNumber { get; set; }
        [Display(Name = "Company Name")]
        public string PayingCompanyName { get; set; }
        public string PayingCompanyLogoFileName { get; set; }
        public string PayingCompanySignitureFileName { get; set; }
        public Image CompanyLogo { get; set; }
        public Image Signiture { get; set; }

        //bank info
        public string BankName { get; set; }
        public string BankAbbreviation { get; set; }
        public string BankLogoFileName { get; set; }
        public Image BankLogo { get; set; }
        //

        public string Code { get; set; }
        public int CheckTemplateId { get; set; }
        //public virtual CheckTemplate CheckTemplate { get; set; }

       
        public string Date { get; set; }
        public string PayableTo { get; set; }
        public string PayableFor { get; set; }

        public decimal BBF { get; set; }
        public decimal Deposits { get; set; }
        public decimal Total { get; set; }
        public decimal ThisCheck { get; set; }
        public decimal Balance { get; set; }

        [Display(Name = "CK. NO.")]
        public string CheckNumber { get; set; }
        public string Payee { get; set; }
        [Display(Name = "Amount")]
        public decimal CheckAmount { get; set; }
        public string CheckAmountInWords { get; set; }


        public bool IsSigned { get; set; }
        public string SignedBy { get; set; }
        public DateTime? SignedOn { get; set; }
    }
}
