using ExceedERP.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceedERP.Core.Domain.CheckPrint
{
    public class CheckTemplate : TrackUserSettingOperation
    {
        [Key]
        public int CheckTemplateId { get; set; }

        // paying company informatin

        [Display(Name = "Ac. No.")]
        public string PayingCompanyAccountNumber { get; set; }
        [Display(Name = "Company Name")]
        public string PayingCompanyName { get; set; }
        public string PayingCompanyLogoFileName { get; set; }
        public string PayingCompanySignitureFileName { get; set; }

        // bak information
        [Display(Name = "Bank")]
        public int CPBankId { get; set; }
        public virtual CPBank Bank { get; set; }

        [NotMapped]
        public string BankLogoFileName { get; set; }
    }
}
