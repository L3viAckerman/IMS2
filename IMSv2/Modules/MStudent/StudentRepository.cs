using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MStudent
{
    public interface IStudentRepository
    {
        int Count(SearchStudentEntity SearchStudentEntity);
        bool Add(Student Student);
        Student Get(Guid StudentId);
        List<Student> List(SearchStudentEntity SearchStudentEntity);
        bool Update(Guid StudentId, Student Student);
        bool Delete(Guid StudentId);
    }
    public class StudentRepository : CommonRepository<Student>, IStudentRepository
    {
        public StudentRepository(IMSV2Context IMSV2Context) : base(IMSV2Context)
        {

        }
        public bool Add(Student Student)
        {
            if (Student.Id == Guid.Empty) Student.Id = Guid.NewGuid();
            context.Student.Add(Student);
            return true;
        }

        public int Count(SearchStudentEntity SearchStudentEntity)
        {
            if (SearchStudentEntity == null) SearchStudentEntity = new SearchStudentEntity();
            IQueryable<Student> students = context.Student;
            students = Apply(students, SearchStudentEntity);
            return students.Count();
        }

        public bool Delete(Guid StudentId)
        {
            Student Student = context.Student.Where(w => w.Id == StudentId).FirstOrDefault();
            if (Student == null) throw new BadRequestException("Khong ton tai sinh vien");
            context.Student.Remove(Student);
            return true;
        }

        public Student Get(Guid StudentId)
        {
            Student Student = context.Student.Where(w => w.Id == StudentId).FirstOrDefault();
            if (Student == null) throw new BadRequestException("Khong ton tai sinh vien");
            return Student;
        }

        public List<Student> List(SearchStudentEntity SearchStudentEntity)
        {
            if (SearchStudentEntity == null) SearchStudentEntity = new SearchStudentEntity();
            IQueryable<Student> students = context.Student;
            students = Apply(students, SearchStudentEntity);
            students = SkipAndTake(students, SearchStudentEntity);
            return students.ToList();
        }

        public bool Update(Guid StudentId, Student Student)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Student> Apply(IQueryable<Student> students, SearchStudentEntity SearchStudentEntity)
        {
            if (!String.IsNullOrEmpty(SearchStudentEntity.Fullname))
                students = students.Where(w => w.Fullname == SearchStudentEntity.Fullname);
            if (!String.IsNullOrEmpty(SearchStudentEntity.Vnumail))
                students = students.Where(w => w.Vnumail == SearchStudentEntity.Vnumail);
            return students;
        }
    }
}
