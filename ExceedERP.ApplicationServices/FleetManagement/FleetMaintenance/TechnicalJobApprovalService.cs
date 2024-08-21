﻿using ExceedERP.Core.Domain.FleetManagement.FleetMaintenance;
using ExceedERP.Repository;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetMaintenance
{
    public  class TechnicalJobApprovalService : ITechnicalJobApprovalService
    {

        
             
       private readonly UnitOfWork _uow;
        public TechnicalJobApprovalService()
        {
            _uow = new UnitOfWork();
        }
        public bool Insert(TechnicalJobApproval entity)
        {
            _uow.TechnicalJobApprovalRepository.Add(entity);
            return _uow.SaveChanges();
        }

        public bool InsertBatch(List<TechnicalJobApproval> entityList)
        {
            _uow.TechnicalJobApprovalRepository.AddRange(entityList);
            return _uow.SaveChanges();
        }

        public bool Update(TechnicalJobApproval entity)
        {
            _uow.TechnicalJobApprovalRepository.AddOrUpdate(entity);
            return _uow.SaveChanges();
        }

        public bool Delete(TechnicalJobApproval entity)
        {
            _uow.TechnicalJobApprovalRepository.Delete(entity);
            return _uow.SaveChanges();
        }

        public TechnicalJobApproval GetById(Guid id)
        {
         TechnicalJobApproval TechnicalJobApproval =   _uow.TechnicalJobApprovalRepository.FindById(id);
         return TechnicalJobApproval;
        }

        public List<TechnicalJobApproval> GetAll()
        {
         List<TechnicalJobApproval> TechnicalJobApproval=   _uow.TechnicalJobApprovalRepository.GetAll();
         return TechnicalJobApproval;
          
        }
    }
}
