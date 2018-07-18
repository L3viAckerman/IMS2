using IMSv2.Models;
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
    }


    public class UnitOfWork : IUnitOfWork
    {
        private IMSContext context;
        private IDbContextTransaction _transaction;

        private void InitTransaction()
        {
            if (_transaction == null)
                _transaction = context.Database.BeginTransaction();
        }

        public UnitOfWork()
        {
            this.context = new IMSContext();
        }

        public UnitOfWork(IMSContext context)
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
    }
}
