﻿using ExceedERP.Core.Domain.FleetManagement.FleetEquipmentRent;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetEquipmentRent
{
    public interface IRentCustomerFeedBackService
    {
        bool Insert(RentCustomerFeedBack entity);
        bool InsertBatch(List<RentCustomerFeedBack> entityList);
        bool Update(RentCustomerFeedBack entity);

        bool Delete(RentCustomerFeedBack entity);
        RentCustomerFeedBack GetById(Guid id);
        List<RentCustomerFeedBack> GetAll();
    }
}
