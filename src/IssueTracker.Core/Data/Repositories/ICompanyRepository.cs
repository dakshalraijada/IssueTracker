namespace IssueTracker.Core.Data.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetBySubDomain(string subDomain);
    }
}
