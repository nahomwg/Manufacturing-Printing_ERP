
using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface IAccessoriesService
    {
        bool Insert(Accessories entity);
        bool InsertBatch(List<Accessories> entityList);
        bool Update(Accessories entity);
       
        bool Delete(Accessories entity);
        Accessories GetById(Guid id);
        List<Accessories> GetAll();
    }
}
