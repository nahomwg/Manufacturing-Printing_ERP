using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface ISparePartService
    {
        bool Insert(SparePart entity);
        bool InsertBatch(List<SparePart> entityList);
        bool Update(SparePart entity);

        bool Delete(SparePart entity);
        SparePart GetById(Guid id);
        List<SparePart> GetAll();
    }
}
