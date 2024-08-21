using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface IOperatorPositionService
    {
        bool Insert(OperatorPosition entity);
        bool InsertBatch(List<OperatorPosition> entityList);
        bool AddOrUpdate(OperatorPosition entity);

        bool Delete(OperatorPosition entity);
        OperatorPosition GetById(Guid id);
        List<OperatorPosition> GetAll();

    }
}
