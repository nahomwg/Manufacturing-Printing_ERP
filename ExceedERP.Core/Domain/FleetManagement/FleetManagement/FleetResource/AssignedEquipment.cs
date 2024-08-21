using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System.ComponentModel;
 using ExceedERP.Core.Domain.Common;

namespace ExceedERP.Core.Domain.FleetManagement.FleetResource
{
    public partial class AssignedEquipment : Operations
    {

        public Guid AssignedEquipmentID { get; set; }
        public Guid RequestedEquipmentId { get; set; }
        [DisplayName("Equipment Name")]
        public Guid EquipmentNameID { get; set; }
        public Guid RequestNumber { get; set; }

        [Required]
        [DisplayName("Plate No")]
        public Guid FleetId { get; set; }
        public string EquipmentName { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool IsArrived { get; set; }
	
        [Required]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
          [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? AssignedDate { get; set; }
        public DateTime? RequestedDate { get; set; }
          [DisplayName("Equipment Status")]
          public string EquipmentStatus { get; set; }
          public string RequestDesc { get; set; }
     
          public enum EquipmentStatusenum { New, Good, NeverMind }
        public bool IsAssigned { get; set; }


    }
}
