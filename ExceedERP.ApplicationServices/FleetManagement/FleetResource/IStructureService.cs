using System;
using System.Collections.Generic;
using ExceedERP.Core.Domain.Common.HRM;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetResource
{
    public interface IStructureService
    {
        bool Insert(Structure entity);
        bool InsertBatch(List<Structure> entityList);
        bool Update(Structure entity);

        bool Delete(Structure entity);
        Structure GetById(Guid id);
        List<Structure> GetAll();
    }
}
