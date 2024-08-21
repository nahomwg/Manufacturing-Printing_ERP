using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceedERP.Core.Domain.Common;
using ExceedERP.Core.Domain.Common.HRM;
using ExceedERP.Core.Domain.FixedAsset.Registrations;

namespace ExceedERP.Core.Domain.FixedAsset.UserCard
{
    public class UserCardItems : TrackUserOperation
    {
        public int UserCardItemsID { get; set; }
        [DisplayName("Employee")]
        public int EmployeeId { get; set; }
        public virtual Person_Employee UserCard { get; set; }
        [Required]
        [DisplayName("Asset")]
        public int AssetRegistrationId { get; set; }
        public virtual AssetRegistration AssetRegistration { get; set; }
        public string EmployeeFullName { get; set; }
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [Display(Name = "Unit of Measurement")]
        public string UOM { get; set; }
        public decimal Quanity { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "PIN/Tag")]
        public string Tag { get; set; }
        [Display(Name = "Serial/Part No.")]
        public string SerialNo { get; set; }
        [Display(Name = "SIV Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime IssueDate { get; set; }
        [Display(Name = "SIV No.")]
        public string SIVNo { get; set; }
        [Display(Name = "GRN Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? GRNDate { get; set; }
        [Display(Name = "GRN No.")]
        public string GRN { get; set; }
        public string Remark { get; set; }
        [Display(Name = "Active ?")]
        public bool Active { get; set; }
    }
}
