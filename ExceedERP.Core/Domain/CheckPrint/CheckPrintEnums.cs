using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceedERP.Core.Domain.CheckPrint
{
    public enum CheckNumberStatus
    {
        New,
        CheckCreated,
        CheckPrinted,
        CheckIssued,
        CheckCanceled
    }
    public enum CheckStatus
    {
        New,
        Printed,
        Issued,
        Canceled
    }
}
