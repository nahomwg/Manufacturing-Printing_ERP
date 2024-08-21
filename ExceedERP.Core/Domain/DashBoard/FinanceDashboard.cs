using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExceedERP.Core.Domain.Dashboard
{

    public enum FinanceDashboradCategory
    {
        CashAndBank,
        INVENTORY,
        COST_OF_GOOD_SOLD,
        RECEIVABLES,
        SALES_ON_CREDIT,
        FIXED_ASSETS,
        TOTAL_ASSETS,
        RECEIVABLE_TURN_OVER,
        CURRENT_ASSET,
        CURRENT_LIABLITIES,
        SHORT_TERM_MARKETABLE_SECURITIES,
        CASH,
        TOTAL_LIABLITIES,
        TOTAL_DEBT,
        TOTAL_SHAREHOLDERS_EQUITY,
        GROSS_INCOME,
        OPERATING_INCOME,
        NET_INCOME,
        COST_OF_SERVICES,
        SALES,
        Other
    }
    public class FinanceDashboard
    {
 
        public int FinanceDashboardId { get; set; }
        [Required]
        public FinanceDashboradCategory Category { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public ICollection<FinanceDashboardRange> FinanceDashboardRanges { get; set; }
    }
    public class FinanceDashboardRange : ReportSetupBase
    {
        public int FinanceDashboardRangeId { get; set; }
        public int FinanceDashboardId { get; set; }
        public virtual FinanceDashboard FinanceDashboard { get; set; }
    }


    public class ReportSetupBase
    {
        [Required]
        [Display(Name = "Account From")]
        public string AccountFrom { get; set; }
        [Required]
        [Display(Name = "Account To")]
        public string AccountTo { get; set; }
    }
}
