using IssueTracker.Core.Data;
using IssueTracker.Core.Data.Repositories;
using IssueTracker.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IssueTracker.Data
{
    public class IssueTrackerUow : IUow, IDisposable
    {
        public IssueTrackerUow(IRepositoryProvider repositoryProvider, EFDbContext context)
        {
            DbContext = context;
            RepositoryProvider = repositoryProvider;
            repositoryProvider.Context = context;
        }

        public ICompanyRepository Companies { get { return GetRepo<ICompanyRepository>(); } }

        private DbContext DbContext { get; set; }
        protected IRepositoryProvider RepositoryProvider { get; set; }

        protected T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        protected IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            //this.ApplyRules();
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Save pending changes to the database asynchoronously
        /// </summary>
        public Task CommitAsync()
        {
            //this.ApplyRules();
            return DbContext.SaveChangesAsync();
        }
        public void Add(object entity)
        {
            DbContext.Add(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
