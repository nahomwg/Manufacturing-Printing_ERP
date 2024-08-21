using ExceedERP.Core.Domain.FleetManagement.FleetEquipmentRent;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetEquipmentRent
{
    public  interface IRentRequestService
    {

        bool Insert(RentRequest entity);
        bool InsertBatch(List<RentRequest> entityList);
        bool Update(RentRequest entity);

        bool Delete(RentRequest entity);
        RentRequest GetById(Guid id);
        List<RentRequest> GetAll();
    }
}
