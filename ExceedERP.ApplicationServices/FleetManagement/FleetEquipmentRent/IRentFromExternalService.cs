using ExceedERP.Core.Domain.FleetManagement.FleetEquipmentRent;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetEquipmentRent
{
    public  interface IRentFromExternalService
    {

        bool Insert(RentFromExternal entity);
        bool InsertBatch(List<RentFromExternal> entityList);
        bool Update(RentFromExternal entity);

        bool Delete(RentFromExternal entity);
        RentFromExternal GetById(Guid id);
        List<RentFromExternal> GetAll();
    }
}
