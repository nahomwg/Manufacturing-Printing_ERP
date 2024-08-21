using ExceedERP.Reporting.SharedDataSources.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace ExceedERP.Reporting.CheckPrint.Printing.ViewModel
{
    public class VoucherPrintViewModel : Organization
    {
        public string Date { get; set; }
        public string VoucherNumber { get; set; }
        public string PaidTo { get; set; }
        //public string PayableFor { get; set; }

        [Display(Name = "CK. NO.")]
        public int CheckNumber { get; set; }
        public string Payee { get; set; }
        [Display(Name = "Amount")]
        public decimal CheckAmount { get; set; }
        public string CheckAmountInWords { get; set; }
        public string Purpose { get; set; }
        public string Bank { get; set; }
    }
}
