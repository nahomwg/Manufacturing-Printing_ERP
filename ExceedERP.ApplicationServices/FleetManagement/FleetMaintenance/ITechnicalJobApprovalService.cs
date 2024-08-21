using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public  interface ITechnicalJobApprovalService
    {
        bool Insert(TechnicalJobApproval entity);
        bool InsertBatch(List<TechnicalJobApproval> entityList);
        bool Update(TechnicalJobApproval entity);

        bool Delete(TechnicalJobApproval entity);
        TechnicalJobApproval GetById(Guid id);
        List<TechnicalJobApproval> GetAll();
    }
}
