using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface IEquipmentNameService
    {

        bool Insert(EquipmentName entity);
        bool InsertBatch(List<EquipmentName> entityList);
        bool Update(EquipmentName entity);

        bool Delete(EquipmentName entity);
        EquipmentName GetById(Guid id);
        List<EquipmentName> GetAll();
    }

}
