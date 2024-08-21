using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IServiceService
    {

        bool Insert(Service entity);
        bool InsertBatch(List<Service> entityList);
        bool Update(Service entity);

        bool Delete(Service entity);
        Service GetById(Guid id);
        List<Service> GetAll();
    }
}
