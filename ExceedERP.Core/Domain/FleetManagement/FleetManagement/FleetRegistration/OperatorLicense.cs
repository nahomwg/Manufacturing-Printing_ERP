﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using ExceedERP.Core.Domain.Common;

namespace ExceedERP.Core.Domain.FleetManagement.FleetRegistration
{
    public partial class OperatorLicense : TrackUserSettingOperation
    {

        public int OperatorLicenseId { get; set; }
        public Guid OperatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}