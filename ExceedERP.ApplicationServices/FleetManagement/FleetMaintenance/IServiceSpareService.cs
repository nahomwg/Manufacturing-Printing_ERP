using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IServiceSpareService
    {

         bool Insert(ServiceSpare entity);
         bool InsertBatch(List<ServiceSpare> entityList);
         bool Update(ServiceSpare entity);

         bool Delete(ServiceSpare entity);
         ServiceSpare GetById(Guid id);
         List<ServiceSpare> GetAll();
    }
}
