using ExceedERP.Core.Domain.FleetManagement.FleetResource;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetResource
{
    public  interface ISitesVehicleTransferService
    {
      bool Insert(SitesVehicleTransfer entity);
        bool InsertBatch(List<SitesVehicleTransfer> entityList);
        bool Update(SitesVehicleTransfer entity);

        bool Delete(SitesVehicleTransfer entity);
        SitesVehicleTransfer GetById(Guid id);
        List<SitesVehicleTransfer> GetAll();
    }
}
