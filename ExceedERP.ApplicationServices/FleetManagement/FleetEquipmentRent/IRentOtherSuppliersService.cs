using ExceedERP.Core.Domain.FleetManagement.FleetEquipmentRent;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetEquipmentRent
{
    public interface IRentOtherSuppliersService
    {
        bool Insert(RentOtherSuppliers entity);
        bool InsertBatch(List<RentOtherSuppliers> entityList);
        bool Update(RentOtherSuppliers entity);

        bool Delete(RentOtherSuppliers entity);
        RentOtherSuppliers GetById(Guid id);
        List<RentOtherSuppliers> GetAll();
    }
}
