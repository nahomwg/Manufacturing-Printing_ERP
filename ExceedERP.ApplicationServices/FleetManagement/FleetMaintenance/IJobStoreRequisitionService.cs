using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public  interface IJobStoreRequisitionService
    {
      bool Insert(JobStoreRequisition entity);
        bool InsertBatch(List<JobStoreRequisition> entityList);
        bool Update(JobStoreRequisition entity);

        bool Delete(JobStoreRequisition entity);
        JobStoreRequisition GetById(Guid id);
        List<JobStoreRequisition> GetAll();
    }
}
