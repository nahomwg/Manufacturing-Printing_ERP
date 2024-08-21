using ExceedERP.Core.Domain.FleetManagement.EquipmentInspection;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.EquipmentInspection
{
    public interface IAnnualEquipmentInventoryInspectionService
    {
        bool Insert(AnnualEquipmentInventoryInspection entity);
        bool InsertBatch(List<AnnualEquipmentInventoryInspection> entityList);
        bool Update(AnnualEquipmentInventoryInspection entity);

        bool Delete(AnnualEquipmentInventoryInspection entity);
        AnnualEquipmentInventoryInspection GetById(Guid id);
        List<AnnualEquipmentInventoryInspection> GetAll();
    }
}
