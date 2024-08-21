﻿using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IOtherCompanyMaintenanceService
    {
        bool Insert(OtherCompanyMaintenance entity);
        bool InsertBatch(List<OtherCompanyMaintenance> entityList);
        bool Update(OtherCompanyMaintenance entity);

        bool Delete(OtherCompanyMaintenance entity);
        OtherCompanyMaintenance GetById(Guid id);
        List<OtherCompanyMaintenance> GetAll();
    }
}
