using IMSv2.AppStart;
using IMSv2.Entities;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules.MCompany
{
    public interface ICompanyReopitory
    {
        int Count( CompanySearchEntity companySearchEntity);
        List<Company> Get(CompanySearchEntity companySearchEntity);
        Company Get(Guid Id);
        bool Add(Company company);
        bool Update(Company company);
        bool Delete(Guid Id);
    }
    public class CompanyRepository : CommonRepository<Company> , ICompanyReopitory
    {
        public CompanyRepository(IMSV2Context iMSV2Context) : base(iMSV2Context)
        {

        }
        public bool Add(Company company)
        {
            if (company.Id == null) company.Id = Guid.NewGuid();
            context.Company.Add(company);
            return true;
        }

        public int Count(CompanySearchEntity companySearchEntity)
        {
            if (companySearchEntity == null) companySearchEntity = new CompanySearchEntity();
            IQueryable<Company> company = context.Company;
            company = Apply(company, companySearchEntity);
            return company.Count();
        }

        public bool Delete(Guid Id)
        {
            Company company = context.Company.Where(m => m.Id == Id).FirstOrDefault();
            if (company == null) throw new BadRequestException("Khong ton tai Cong ty");
            context.Company.Remove(company);
            return true;
        }

        public List<Company> Get(CompanySearchEntity companySearchEntity)
        {
            if (companySearchEntity == null) companySearchEntity = new CompanySearchEntity();
            IQueryable<Company> companies = context.Company;
            companies = Apply(companies, companySearchEntity);
            companies = SkipAndTake(companies, companySearchEntity);
            return companies.ToList();
        }

        public Company Get(Guid Id)
        {
            Company company = context.Company.Where(m => m.Id == Id).FirstOrDefault();
            if (company == null) throw new BadRequestException("Khong tim thay cong ty");
            return company;
        }

        public bool Update(Company company)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Company> Apply(IQueryable<Company> company, CompanySearchEntity companySearchEntity)
        {
            if (companySearchEntity.Id.HasValue)
                company = company.Where(m => m.Id == companySearchEntity.Id.Value);
            if (!String.IsNullOrEmpty(companySearchEntity.Name))
                company = company.Where(m => m.Name == companySearchEntity.Name);
            return company;
        }
    }
}
