using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Core
{
    public class CompanyUser
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
