using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MHrEmployee
{
    public interface IHrEmployeeSevice : ITransientService
    {
        int Count(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity);
        List<HrEmployeeEntity> Get(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity);
        HrEmployeeEntity Get(UserEntity UserEntity, Guid HrEmployeeId);
        HrEmployeeEntity Create(UserEntity UserEntity, HrEmployeeEntity HrEmployeeEntity);
        HrEmployeeEntity Update(UserEntity UserEntity, Guid HrEmployeeEntityId, HrEmployeeEntity HrEmployeeEentity);
        bool Delete(UserEntity UserEntity, Guid HrEmployeeId);
    }
    public class HrEmployeeService : CommonService, IHrEmployeeSevice
    {
        private IHrEmployeeValidator HrEmployeeValidator;
        public HrEmployeeService(IUnitOfWork unitOfWork,IHrEmployeeValidator hrEmployeeValidator) : base(unitOfWork)
        {
            this.HrEmployeeValidator = hrEmployeeValidator;
        }
        public int Count(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            return UnitOfWork.HrEmployeeRepository.Count(SearchHrEmployeeEntity);
        }

        public HrEmployeeEntity Create(UserEntity UserEntity, HrEmployeeEntity HrEmployeeEntity)
        {
            if (HrEmployeeEntity == null) throw new BadRequestException("");
            if (HrEmployeeEntity.Id == null) HrEmployeeEntity.Id = Guid.NewGuid();
            HrEmployee hrEmployee = new HrEmployee(HrEmployeeEntity);
            UnitOfWork.HrEmployeeRepository.Add(hrEmployee);
            UnitOfWork.Complete();
            return HrEmployeeEntity;
        }

        public bool Delete(UserEntity UserEntity, Guid HrEmployeeId)
        {
            UnitOfWork.HrEmployeeRepository.Delete(HrEmployeeId);
            UnitOfWork.Complete();
            return true;
        }

        public List<HrEmployeeEntity> Get(UserEntity UserEntity, SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            if (SearchHrEmployeeEntity == null) SearchHrEmployeeEntity = new SearchHrEmployeeEntity();
            List<HrEmployeeEntity> hrEmployeeEntities = UnitOfWork.HrEmployeeRepository.List(SearchHrEmployeeEntity).Select(s => new HrEmployeeEntity(s)).ToList();
            return hrEmployeeEntities;
        }

        public HrEmployeeEntity Get(UserEntity UserEntity, Guid HrEmployeeId)
        {
            HrEmployeeEntity hrEmployeeEntity = new HrEmployeeEntity(UnitOfWork.HrEmployeeRepository.Get(HrEmployeeId));
            return hrEmployeeEntity;
        }

        public HrEmployeeEntity Update(UserEntity UserEntity, Guid HrEmployeeEntityId, HrEmployeeEntity HrEmployeeEentity)
        {
            throw new NotImplementedException();
        }
    }
}
