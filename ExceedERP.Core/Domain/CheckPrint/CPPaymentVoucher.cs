using ExceedERP.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceedERP.Core.Domain.CheckPrint
{
    public class CPPaymentVoucher : TrackUserSettingOperation
    {
        [Key]
        public int CPPaymentVoucherId { get; set; }

        public int CheckId { get; set; }
        public virtual Check Check { get; set; }
    }
}
