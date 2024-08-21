using ExceedERP.Core.Domain.FleetManagement.FleetResource;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetResource
{
    public  interface IVehicleDistributionService
    {

        bool Insert(VehicleDistribution entity);
        bool InsertBatch(List<VehicleDistribution> entityList);
        bool Update(VehicleDistribution entity);

        bool Delete(VehicleDistribution entity);
        VehicleDistribution GetById(Guid id);
        List<VehicleDistribution> GetAll();
    }
    }
