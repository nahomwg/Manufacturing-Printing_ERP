﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using ExceedERP.Core.Domain.Common;

namespace ExceedERP.Core.Domain.FleetManagement.FleetRegistration
{
    public partial class FleetIFuelConsumption : TrackUserOperation
    {

        public int FleetIFuelConsumptionId { get; set; }
        [NotMapped]
      [Display(Name ="Equipment Category")]
        public Guid EquipmentIdentityID { get; set; }
        public Guid EquipmentTypeID { get; set; }
        public decimal MinConsupmtion { get; set; }
        public decimal MaxConsupmtion { get; set; }
        [ForeignKey("EquipmentTypeID")]
        public virtual EquipmentType EquipmentType { get; set; }
    }
}
