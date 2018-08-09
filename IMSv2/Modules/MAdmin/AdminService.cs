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
    public interface IAdminService : ITransientService
    {
        int Count(UserEntity UserEntity, AdminSearchEntity AdminSearchEntity);
        List<AdminEntity> Get(UserEntity UserEntity, AdminSearchEntity AdminSearchEntity);
        AdminEntity Get(UserEntity UserEntity, Guid Id);
        AdminEntity Create(UserEntity UserEntity, AdminEntity AdminEntity);
        AdminEntity Update(UserEntity UserEntity, Guid Id, AdminEntity AdminEntity);
        bool Delete(UserEntity UserEntity, Guid Id);
    }
    public class AdminService : CommonService, IAdminService
    {
        private IAdminValidator AdminValidator;

        public AdminService(IUnitOfWork UnitOfWork, IAdminValidator IAdminValidator) : base(UnitOfWork)
        {
            this.AdminValidator = IAdminValidator;
        }

        public int Count(UserEntity UserEntity, AdminSearchEntity AdminSearchEntity)
        {
            return UnitOfWork.AdminRepository.Count(AdminSearchEntity);
        }

        public AdminEntity Create(UserEntity UserEntity, AdminEntity AdminEntity)
        {
            if (AdminEntity == null) throw new NotFoundException();
            //Validator
            AdminEntity.Id = Guid.NewGuid();
            Admin Admin = new Admin(AdminEntity);
            UnitOfWork.AdminRepository.Add(Admin);
            UnitOfWork.Complete();
            return Get(UserEntity, AdminEntity.Id);
            
        }

        public bool Delete(UserEntity UserEntity, Guid Id)
        {
            UnitOfWork.AdminRepository.Delete(Id);
            UnitOfWork.Complete();
            return true;
        }

        public List<AdminEntity> Get(UserEntity UserEntity, AdminSearchEntity AdminSearchEntity)
        {
            List<Admin> Admins = UnitOfWork.AdminRepository.List(AdminSearchEntity);
            return Admins.Select(s => new AdminEntity(s)).ToList();
        }

        public AdminEntity Get(UserEntity UserEntity, Guid Id)
        {
            Admin Admin = UnitOfWork.AdminRepository.Get(Id);
            return new AdminEntity(Admin);
        }

        public AdminEntity Update(UserEntity UserEntity, Guid Id, AdminEntity AdminEntity)
        {
            AdminEntity.Id = Id;
            //if (!AdminValidator.ValidateUpdate(AdminEntity))
            //    throw new BadRequestException(AdminEntity);
            Admin Admin = new Admin(AdminEntity);
            UnitOfWork.AdminRepository.Update(Admin);
            UnitOfWork.Complete();
            return new AdminEntity(Admin);
        }
    }
}
