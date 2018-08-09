using IMSv2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MHrEmployee
{
    public interface IHrEmployeeValidator : IValidator<HrEmployeeEntity>, ITransientService 
    {

    }
    public class HrEmployeeValidator : IHrEmployeeValidator
    {
        public bool ValidateCreate(HrEmployeeEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool ValidateDelete(HrEmployeeEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUpdate(HrEmployeeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
