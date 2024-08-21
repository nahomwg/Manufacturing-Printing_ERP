using ExceedERP.Core.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ExceedERP.Core.Domain.CheckPrint
{
    public class CPCheckBook : TrackUserSettingOperation
    {
        [Key]
        public int CPCheckBookId { get; set; }

        [Display(Name ="Bank")]
        public int CPBankId { get; set; }

        [Display(Name ="Account")]
        public int CPBankAccountId { get; set; }

        //public string Concat { get; set; }

        // check book detail
        [Display(Name = "No. of Checks")]
        public int NumberOfChecks { get; set; }
        [Display(Name = "Start Check No.")]
        public int StartCheckNumber { get; set; }
        [Display(Name = "End Check No")]
        public int EndCheckNumber { get; set; }

        [Display(Name ="Check Description")]
        public string Description { get; set; }

        [Display(Name = "Optional Description (For Reference)")]
        public string Reference { get; set; }

       

        [NotMapped]
        public bool HasChecks { get; set; }

    }
    public class CPCheckBookCheckNumber : TrackUserSettingOperation
    {
        [Key]
        public int CPCheckBookCheckNumberId { get; set; }
        public int CPCheckBookId { get; set; }
        public virtual CPCheckBook CheckBook { get; set; }
        public int CheckNumber { get; set; }
        public CheckNumberStatus Status { get; set; }
    }
}
