using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IMaintenanceCenterService
    {
        bool Insert(MaintenanceCenter entity);
        bool InsertBatch(List<MaintenanceCenter> entityList);
        bool Update(MaintenanceCenter entity);

        bool Delete(MaintenanceCenter entity);
        MaintenanceCenter GetById(Guid id);
        List<MaintenanceCenter> GetAll();
    }
}
