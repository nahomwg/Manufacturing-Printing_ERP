using System.Collections.Generic;

namespace ExceedERP.Reporting.CheckPrint.ViewModel
{
    public class CheckReportViewModel
    {
        public string Bank { get; set; }
        public string CheckBook { get; set; }

        public virtual ICollection<CheckReportLineViewModel> ChecksList { get; set; } = new List<CheckReportLineViewModel>();
    }
    public class CheckReportLineViewModel
    {
        public int CheckNumber { get; set; }
        public string Date { get; set; }
        public string Payee { get; set; }
        public decimal CheckAmount { get; set; }
    }
}
