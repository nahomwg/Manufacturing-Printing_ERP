using System;
using System.Collections.Generic;
using ExceedERP.Core.Domain.Common.HRM;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetResource
{
    public interface IBranchService
    {

        bool Insert(Branch entity);
        bool InsertBatch(List<Branch> entityList);
        bool Update(Branch entity);

        bool Delete(Branch entity);
        Branch GetById(Guid id);
        List<Branch> GetAll();
    }
}
