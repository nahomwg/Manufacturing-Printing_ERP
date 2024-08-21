﻿using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public interface IEquipmentIdentityService
    {
        bool Insert(EquipmentIdentity entity);
        bool InsertBatch(List<EquipmentIdentity> entityList);
        bool AddOrUpdate(EquipmentIdentity entity);

        bool Delete(EquipmentIdentity entity);
        EquipmentIdentity GetById(Guid id);
        List<EquipmentIdentity> GetAll();
    }
}
