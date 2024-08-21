﻿using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface ITimeSheetService
    {
        bool Insert(TimeSheet entity);
        bool InsertBatch(List<TimeSheet> entityList);
        bool Update(TimeSheet entity);

        bool Delete(TimeSheet entity);
        TimeSheet GetById(Guid id);
        List<TimeSheet> GetAll();
 
    }
}
