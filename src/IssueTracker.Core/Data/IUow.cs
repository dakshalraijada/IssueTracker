using IssueTracker.Core.Data.Repositories;

namespace IssueTracker.Core.Data
{
    public interface IUow
    {
        void Commit();
        ICompanyRepository Companies { get; }
    }
}
