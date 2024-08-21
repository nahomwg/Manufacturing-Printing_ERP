using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IPlannerService
    {
        bool Insert(Planner entity);
        bool InsertBatch(List<Planner> entityList);
        bool Update(Planner entity);

        bool Delete(Planner entity);
        Planner GetById(Guid id);
        List<Planner> GetAll();
    }
}
