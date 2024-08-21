using ExceedERP.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceedERP.Core.Domain.FixedAsset
{
    public class IndexingCount : TrackUserOperation
    {
        [Key]
        public string IndexCode { get; set; }
        public string SubCategoryCode { get; set; }
        public int CurrentValue { get; set; }
    }
}
