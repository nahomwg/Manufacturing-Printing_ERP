using ExceedERP.Core.Domain.FleetManagement.FleetRegistration;
using ExceedERP.Repository;
using System;
using System.Collections.Generic;

namespace ExceedERP.ApplicationServices.FleetManagement.FleetRegistration
{
    public class AccidentService : IAccidentService
    {
          private readonly UnitOfWork _uow;
        public AccidentService()
        {
            _uow = new UnitOfWork();
        }
        public bool Insert(Accident entity)
        {
            _uow.AccidentRepository.Add(entity);
            return _uow.SaveChanges();
        }

        public bool InsertBatch(List<Accident> entityList)
        {
            _uow.AccidentRepository.AddRange(entityList);
            return _uow.SaveChanges();
        }

        public bool Update(Accident entity)
        {
            _uow.AccidentRepository.Edit(entity);
            return _uow.SaveChanges();
        }

        public bool Delete(Accident entity)
        {
            _uow.AccidentRepository.Delete(entity);
            return _uow.SaveChanges();
        }

        public Accident GetById(Guid id)
        {
         Accident Accident =   _uow.AccidentRepository.FindById(id);
         return Accident;
        }

        public List<Accident> GetAll()
        {
         List<Accident> Accident=   _uow.AccidentRepository.GetAll();
         return Accident;
          
        }
    }
}
