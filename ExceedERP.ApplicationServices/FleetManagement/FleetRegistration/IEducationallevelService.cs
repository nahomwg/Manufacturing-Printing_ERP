﻿using System;
using System.Collections.Generic;
using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface IEducationallevelService
    {
        bool Insert(Educationallevel entity);
        bool InsertBatch(List<Educationallevel> entityList);
        bool AddOrUpdate(Educationallevel entity);

        bool Delete(Educationallevel entity);
        Educationallevel GetById(Guid id);
        List<Educationallevel> GetAll();
    }
}
