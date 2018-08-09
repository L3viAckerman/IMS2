using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MAdmin
{
    public interface IAdminRepository
    {
        int Count(AdminSearchEntity AdminSearchEntity);
        List<Admin> List(AdminSearchEntity AdminSearchEntity);
        Admin Get(Guid Id);
        bool Add(Admin Admin);
        bool Update(Admin Admin);
        bool Delete(Guid Id);
    }
    public class AdminRepository : CommonRepository<Admin>, IAdminRepository
    {
        public AdminRepository(IMSV2Context IMSV2Context) : base(IMSV2Context)
        {

        }
        public int Count(AdminSearchEntity AdminSearchEntity)
        {
            if (AdminSearchEntity == null) AdminSearchEntity = new AdminSearchEntity();
            IQueryable<Admin> Admin = context.Admin;
            Admin = Apply(Admin, AdminSearchEntity);
            return Admin.Count();
        }

        public List<Admin> List(AdminSearchEntity AdminSearchEntity)
        {
            if (AdminSearchEntity == null) AdminSearchEntity = new AdminSearchEntity();
            IQueryable<Admin> Admin = context.Admin;
            Admin = Apply(Admin, AdminSearchEntity);
            Admin = SkipAndTake(Admin, AdminSearchEntity);
            return Admin.ToList();
        }
        public Admin Get(Guid Id)
        {
            Admin Admin = context.Admin.Where(c => c.Id == Id).FirstOrDefault();
            if (Admin == null) throw new BadRequestException("Khong tim thay giang vien");
            return Admin;
        }

        public bool Add(Admin Admin)
        {
            if (Admin.Id == Guid.Empty) Admin.Id = Guid.NewGuid();
            context.Admin.Add(Admin);
            return true;
        }

        public bool Update(Admin Admin)
        {
            Admin Current = context.Admin.Where(m => m.Id == Admin.Id).FirstOrDefault();
            if (Current == null) throw new BadRequestException("Khong ton tai admin");
            Common<Admin>.Copy(Admin, Current);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            Admin Admin = Get(Id);
            if (Admin == null) throw new BadRequestException("Khong tom tai Admin");
            context.Admin.Remove(Admin);
            return true;
        }
        private IQueryable<Admin> Apply(IQueryable<Admin> Admin, AdminSearchEntity AdminSearchEntity)
        {
            if (AdminSearchEntity.Id.HasValue)
                Admin = Admin.Where(wh => wh.Id == AdminSearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(AdminSearchEntity.Vnumail))
                Admin = Admin.Where(T => T.Vnumail.ToLower().Contains(AdminSearchEntity.Vnumail.ToLower()));         
            return Admin;
        }
    }

   
}
