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
    public partial class FleetInsuranceTypeDetail : TrackUserOperation
    {

        public int FleetInsuranceTypeDetailId { get; set; }

        public Guid InsuranceId { get; set; }
          [Required]
       public string Name { get; set; }
       public string Description { get; set; }
   
    }
}
