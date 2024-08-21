using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IAdministrativeApprovalService
    {

        bool Insert(AdministrativeJobApproval entity);
        bool InsertBatch(List<AdministrativeJobApproval> entityList);
        bool Update(AdministrativeJobApproval entity);

        bool Delete(AdministrativeJobApproval entity);
        AdministrativeJobApproval GetById(Guid id);
        List<AdministrativeJobApproval> GetAll();
    }
}
