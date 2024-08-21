using ExceedERP.Core.Domain.FleetManagement.FuelManagement;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FuelManagement
{
    public interface IFuelService
    {
        bool Insert(Fuel entity);
        bool InsertBatch(List<Fuel> entityList);
        bool Update(Fuel entity);

        bool Delete(Fuel entity);
        Fuel GetById(Guid id);
        List<Fuel> GetAll();
    }
}
