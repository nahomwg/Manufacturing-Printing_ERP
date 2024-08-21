using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IJobOrderDetailService
    {

        bool Insert(JobOrderDetail entity);
        bool InsertBatch(List<JobOrderDetail> entityList);
        bool Update(JobOrderDetail entity);

        bool Delete(JobOrderDetail entity);
        JobOrderDetail GetById(Guid id);
        List<JobOrderDetail> GetAll();
    }
}
