﻿using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;

using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface IFleetHistoryService 
    {
        bool Insert(FleetHistory entity);
        bool InsertBatch(List<FleetHistory> entityList);
        bool Update(FleetHistory entity);

        bool Delete(FleetHistory entity);
        FleetHistory GetById(Guid id);
        List<FleetHistory> GetAll();
    }
}
