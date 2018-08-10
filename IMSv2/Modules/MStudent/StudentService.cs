using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MStudent
{
    public interface IStudentService : ITransientService
    {
        int Count(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity);
        StudentEntity Get(UserEntity UserEntity, Guid StudentId);
        List<StudentEntity> Get(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity);
        bool Delete(UserEntity UserEntity, Guid StudentId);
        StudentEntity Update(UserEntity UserEntity, Guid StudentId, StudentEntity StudentEntity);
        StudentEntity Create(UserEntity UserEntity, StudentEntity StudentEntity);
    }
    public class StudentService : CommonService, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public int Count(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity)
        {
            return UnitOfWork.StudentRepository.Count(SearchStudentEntity);
        }

        public StudentEntity Create(UserEntity UserEntity, StudentEntity StudentEntity)
        {
            if (StudentEntity == null) throw new NotFoundException();
            StudentEntity.Id = Guid.NewGuid();
            Student Student = new Student(StudentEntity);
            UnitOfWork.StudentRepository.Add(Student);
            UnitOfWork.Complete();
            return Get(UserEntity, Student.Id);
        }

        public bool Delete(UserEntity UserEntity, Guid StudentId)
        {
            UnitOfWork.StudentRepository.Delete(StudentId);
            UnitOfWork.Complete();
            return true;
        }

        public StudentEntity Get(UserEntity UserEntity, Guid StudentId)
        {
            Student Student = UnitOfWork.StudentRepository.Get(StudentId);
            StudentEntity studentEntity = new StudentEntity(Student);
            return studentEntity;
        }

        public List<StudentEntity> Get(UserEntity UserEntity, SearchStudentEntity SearchStudentEntity)
        {
            List<Student> students = UnitOfWork.StudentRepository.List(SearchStudentEntity);
            return students.Select(s => new StudentEntity(s)).ToList();
        }

        public StudentEntity Update(UserEntity UserEntity, Guid StudentId, StudentEntity StudentEntity)
        {
            throw new NotImplementedException();
        }
    }
}
