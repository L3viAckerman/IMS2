using IMSv2.Models;
using IMSv2.Modules.MAdmin;
using IMSv2.Modules.MCompany;
using IMSv2.Modules.MHrEmployee;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Modules
{
    public interface IUnitOfWork : ITransientService, IDisposable
    {
        void Complete();
        IAdminRepository AdminRepository { get; }
        ICompanyRepository CompanyRepository { get;  } 
        IHrEmployeeRepository HrEmployeeRepository { get;  }

    }


    public class UnitOfWork : IUnitOfWork
    {
        private IMSV2Context context;
        private IDbContextTransaction _transaction;
        private IAdminRepository _adminRepository;
        private ICompanyRepository _companyRepository;
        private IHrEmployeeRepository _hrEmployeeRepository;

        private void InitTransaction()
        {
            if (_transaction == null)
                _transaction = context.Database.BeginTransaction();
        }

        public UnitOfWork()
        {
            this.context = new IMSV2Context();
        }

        public UnitOfWork(IMSV2Context context)
        {
            this.context = context;
        }

        ~UnitOfWork()
        {
            context.Dispose();
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public void Complete()
        {
            try
            {
                context.SaveChanges();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public IAdminRepository AdminRepository
        {
            get
            {
                InitTransaction();
                if (_adminRepository == null) _adminRepository = new AdminRepository(context);
                return _adminRepository;
            }
        }

        public ICompanyRepository CompanyRepository
        {
            get
            {
                InitTransaction();
                if (_companyRepository == null) _companyRepository = new CompanyRepository(context);
                return _companyRepository;
            }
        }

        public IHrEmployeeRepository HrEmployeeRepository
        {
            get
            {
                InitTransaction();
                if (_hrEmployeeRepository == null) _hrEmployeeRepository = new HrEmployeeRepository(context);
                return _hrEmployeeRepository;
            }
        }
    }
}
