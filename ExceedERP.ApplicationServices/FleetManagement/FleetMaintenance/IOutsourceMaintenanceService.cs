using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IOutsourceMaintenanceService
    {
        bool Insert(OutsourceMaintenance entity);
        bool InsertBatch(List<OutsourceMaintenance> entityList);
        bool Update(OutsourceMaintenance entity);

        bool Delete(OutsourceMaintenance entity);
        OutsourceMaintenance GetById(Guid id);
        List<OutsourceMaintenance> GetAll();
    }
}
