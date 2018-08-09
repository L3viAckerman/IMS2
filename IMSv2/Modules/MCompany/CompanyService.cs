using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MCompany
{
    public interface ICompanyService : ITransientService
    {
        int Count(UserEntity UserEntity, CompanySearchEntity companySearchEntity);
        List<CompanyEntity> Get(UserEntity userEntity, CompanySearchEntity companySearchEntity);
        CompanyEntity Get(UserEntity userEntity, Guid Id);
        CompanyEntity Create(UserEntity userEntity, CompanyEntity companyEntity);
        CompanyEntity Update(UserEntity userEntity, Guid Id);
        bool Delete(UserEntity userEntity, Guid Id);
    }
    public class CompanyService : CommonService, ICompanyService
    {
        private ICompanyValidator companyValidator;
        public CompanyService(IUnitOfWork unitOfWork, ICompanyValidator companyValidator) : base(unitOfWork)
        {
            this.companyValidator = companyValidator;
        }
        public int Count(UserEntity UserEntity, CompanySearchEntity companySearchEntity)
        {
            return UnitOfWork.CompanyRepository.Count(companySearchEntity);
        }

        public CompanyEntity Create(UserEntity userEntity, CompanyEntity companyEntity)
        {
            if (companyEntity == null) throw new NotFoundException();
            companyEntity.Id = Guid.NewGuid();
            Company Company = new Company(companyEntity);
            UnitOfWork.CompanyRepository.Add(Company);
            UnitOfWork.Complete();
            return companyEntity;

        }

        public bool Delete(UserEntity userEntity, Guid Id)
        {
            UnitOfWork.CompanyRepository.Delete(Id);
            UnitOfWork.Complete();
            return true;
        }

        public List<CompanyEntity> Get(UserEntity userEntity, CompanySearchEntity companySearchEntity)
        {
            List<Company> companies = UnitOfWork.CompanyRepository.Get(companySearchEntity);
            UnitOfWork.Complete();
            List<CompanyEntity> companyEntities = companies.Select(s => new CompanyEntity(s)).ToList();
            return companyEntities;
        }

        public CompanyEntity Get(UserEntity userEntity, Guid Id)
        {
            Company Company = UnitOfWork.CompanyRepository.Get(Id);
            CompanyEntity CompanyEntity = new CompanyEntity(Company);
            return CompanyEntity;
        }

        public CompanyEntity Update(UserEntity userEntity, Guid Id)
        {
            throw new NotImplementedException();
        }

       
    }
}
