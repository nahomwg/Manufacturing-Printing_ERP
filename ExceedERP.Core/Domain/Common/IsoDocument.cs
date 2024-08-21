using ExceedERP.Core.Domain.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceedERP.Core.Domain.Common
{
    public class IsoDocument : TrackUserSettingOperation
    {
        [Key]
        public int IsoDocumentId { get; set; }
        public Modules Module { get; set; }
        //
        // Summary:
        //     Type of report such as Master Report, BoQ report, Monthly EVA Report
        public string DocumentType { get; set; }
        //
        // Summary:
        //     Path of report in the system
        public string URL { get; set; }
        //
        // Summary:
        //     ISO form title
        public string FormTitle { get; set; }
        //
        // Summary:
        //     ISO number
        public string FormNumber { get; set; }
        public string Remark { get; set; }

    }
}
