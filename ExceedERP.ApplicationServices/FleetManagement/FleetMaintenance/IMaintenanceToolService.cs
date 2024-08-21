using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IMaintenanceToolService
    {
        bool Insert(MaintenanceTool entity);
        bool InsertBatch(List<MaintenanceTool> entityList);
        bool Update(MaintenanceTool entity);

        bool Delete(MaintenanceTool entity);
        MaintenanceTool GetById(Guid id);
        List<MaintenanceTool> GetAll();
    }
}
