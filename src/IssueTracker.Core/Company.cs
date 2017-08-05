using System;

namespace IssueTracker.Core
{
    public class Company
    {
        public int Id { get; set; }
        public string SubDomain { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
