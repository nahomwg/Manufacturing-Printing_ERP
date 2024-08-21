using ExceedERP.Core.Domain.FleetManagement.FleetResource;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetResource
{
    public interface IDriverVehicleTransferService
    {
        bool Insert(DriverVehicleTransfer entity);
        bool InsertBatch(List<DriverVehicleTransfer> entityList);
        bool Update(DriverVehicleTransfer entity);

        bool Delete(DriverVehicleTransfer entity);
        DriverVehicleTransfer GetById(Guid id);

     
        List<DriverVehicleTransfer> GetAll();
    }
}
