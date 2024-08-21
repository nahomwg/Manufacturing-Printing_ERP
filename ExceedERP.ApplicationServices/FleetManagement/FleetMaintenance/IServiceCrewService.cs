using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IServiceCrewService
    {

           bool Insert(ServiceCrew entity);
           bool InsertBatch(List<ServiceCrew> entityList);
           bool Update(ServiceCrew entity);

           bool Delete(ServiceCrew entity);
           ServiceCrew GetById(Guid id);
           List<ServiceCrew> GetAll();
    }
}
