using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IServiceToolService
    {
         bool Insert(ServiceTool entity);
         bool InsertBatch(List<ServiceTool> entityList);
         bool Update(ServiceTool entity);

         bool Delete(ServiceTool entity);
         ServiceTool GetById(Guid id);
         List<ServiceTool> GetAll();
    }
}
