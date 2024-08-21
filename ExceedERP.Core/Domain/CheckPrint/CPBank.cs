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
    public class CPBank : TrackUserSettingOperation
    {
        [Key]
        public int CPBankId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string LogoFileName { get; set; }
        public ICollection<CPBankAccount> BankAccounts { get; set; }

        [NotMapped]
        public bool HasLinkedCheckBook { get; set; }
    }
    public class CPBankAccount : TrackUserSettingOperation
    {
        [Key]
        public int CPBankAccountId { get; set; }
        public int CPBankId { get; set; }
        public virtual CPBank Bank { get; set; }
        public string AccountNumber { get; set; }
        [NotMapped]
        public bool HasLinkedCheckBook { get; set; }

    }
    //public class CPBankBranch : TrackUserSettingOperation
    //{
    //    [Key]
    //    public int CPBankBranchId { get; set; }
    //    public string Name { get; set; }
    //    public int CPBankId { get; set; }
    //    public virtual CPBank Banck { get; set; }
    //}
}
