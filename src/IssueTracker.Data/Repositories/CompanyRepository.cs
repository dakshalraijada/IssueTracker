using IssueTracker.Core;
using IssueTracker.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IssueTracker.Data.Repositories
{
    public class CompanyRepository : EFRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context)
            : base(context)
        {
        }

        public Company GetBySubDomain(string subDomain)
        {
            return DbSet.FirstOrDefault(o => o.SubDomain.ToLower() == subDomain.ToLower());
        }
    }
}
