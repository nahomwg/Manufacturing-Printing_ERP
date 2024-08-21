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
    public class Check : TrackUserSettingOperation
    {
        public Check()
        {
            this.Code = Guid.NewGuid().ToString();
        }
        [Key]
        public int CheckId { get; set; }
        public int CPCheckBookId { get; set; }
        public virtual CPCheckBook CheckBook { get; set; }
        public string Code { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }
        public string PayableTo { get; set; }
        public string PayableFor { get; set; }

        public decimal BBF { get; set; }
        public decimal Deposits { get; set; }
        public decimal Total { get; set; }
        public decimal ThisCheck { get; set; }
        public decimal Balance { get; set; }

        [Display(Name ="CK. NO.")]
        public int CheckNumber { get; set; }
        public string Payee { get; set; }
        [Display(Name ="Amount")]
        public decimal CheckAmount { get; set; }

        public string Purpose { get; set; }
        public CheckStatus Status { get; set; }

        [NotMapped]
        public bool IsVoucherPrepared { get; set; }
        //public bool IsSigned { get; set; }
        //public string SignedBy { get; set; }
        //public DateTime? SignedOn { get; set; }

        public virtual List<CPPaymentVoucher> PaymentVouchers { get; set; }
    }
}
