using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace IssueTracker.Core
{
    public class User : IdentityUser<int>
    {
        public virtual ICollection<CompanyUser> Companies { get; set; }
    }
}
