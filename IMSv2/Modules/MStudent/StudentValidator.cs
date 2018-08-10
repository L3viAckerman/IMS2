using IMSv2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MStudent
{
    public interface IStudnetValidator : IValidator<StudentEntity>, ITransientService
    {

    }
    public class StudentValidator : CommonValidator, IStudnetValidator
    {
        public StudentValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public bool ValidateCreate(StudentEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool ValidateDelete(StudentEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUpdate(StudentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
