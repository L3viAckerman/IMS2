using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MHrEmployee
{
    public interface IHrEmployeeRepository
    {
        int Count(SearchHrEmployeeEntity SearchHrEmployeeEntity);
        HrEmployee Get(Guid Id);
        List<HrEmployee> List(SearchHrEmployeeEntity SearchHrEmployeeEntity);
        bool Add(HrEmployee HrEmployee);
        bool Update(Guid HrEmPloyeeId, HrEmployeeEntity HrEmployeeEntity);
        bool Delete(Guid HrEmployeeId);

    }
    public class HrEmployeeRepository : CommonRepository<HrEmployee>, IHrEmployeeRepository
    {
        public HrEmployeeRepository(IMSV2Context IMSV2Context) : base(IMSV2Context)
        {

        }
        public bool Add(HrEmployee HrEmployee)
        {
            if (HrEmployee.Id == null) HrEmployee.Id = Guid.NewGuid();
            context.HrEmployee.Add(HrEmployee);
            return true; 
        }

        public int Count(SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            if (SearchHrEmployeeEntity == null) SearchHrEmployeeEntity = new SearchHrEmployeeEntity();
            IQueryable<HrEmployee> hrEmployees = context.HrEmployee;
            hrEmployees = Apply(hrEmployees, SearchHrEmployeeEntity);
            return hrEmployees.Count();
        }

        public bool Delete(Guid HrEmployeeId)
        {
            HrEmployee hrEmployee = context.HrEmployee.Where(w => w.Id == HrEmployeeId).FirstOrDefault();
            if (hrEmployee == null) throw new BadRequestException("Khong ton tai nhan vien HR");
            context.HrEmployee.Remove(hrEmployee);
            return true;
        }

        public HrEmployee Get(Guid Id)
        {
            HrEmployee hrEmployee = context.HrEmployee.Where(w => w.Id == Id).FirstOrDefault();
            if (hrEmployee == null) throw new BadRequestException("Khong tim thay nhan vien HR");
            return hrEmployee;
        }

        public List<HrEmployee> List(SearchHrEmployeeEntity SearchHrEmployeeEntity)
        {
            if (SearchHrEmployeeEntity == null) SearchHrEmployeeEntity = new SearchHrEmployeeEntity();
            IQueryable<HrEmployee> hrEmployees = context.HrEmployee;
            hrEmployees = Apply(hrEmployees, SearchHrEmployeeEntity);
            hrEmployees = SkipAndTake(hrEmployees, SearchHrEmployeeEntity);
            return hrEmployees.ToList();
        }

        public bool Update(Guid HrEmPloyeeId, HrEmployeeEntity HrEmployeeEntity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<HrEmployee> Apply(IQueryable<HrEmployee>hrEmployees, SearchHrEmployeeEntity searchHrEmployeeEntity)
        {
            if (searchHrEmployeeEntity.CompanyId.HasValue)
            {
                hrEmployees = hrEmployees.Where(w => w.CompanyId == searchHrEmployeeEntity.CompanyId.Value);
            }
            if (!String.IsNullOrEmpty(searchHrEmployeeEntity.Phone))
                hrEmployees = hrEmployees.Where(w => w.Phone == searchHrEmployeeEntity.Phone);
            return hrEmployees;
        }
    }
}
