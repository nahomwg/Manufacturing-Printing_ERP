using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public interface IEducationallevelService
    {

        bool Insert(Educationallevel entity);
        bool InsertBatch(List<Educationallevel> entityList);
        bool Update(Educationallevel entity);

        bool Delete(Educationallevel entity);
        Educationallevel GetById(Guid id);
        List<Educationallevel> GetAll();
    }
}
