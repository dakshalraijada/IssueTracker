using IssueTracker.Core;
using IssueTracker.Core.Data;
using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using System.Threading.Tasks;

namespace IssueTracker.Portal.Resolver
{
    public class CompanyDomainResolver : ITenantResolver<Company>
    {
        protected readonly IUow Uow;

        public CompanyDomainResolver(IUow uow)
        {
            Uow = uow;
        }

        public async Task<TenantContext<Company>> ResolveAsync(HttpContext context)
        {
            TenantContext<Company> tenantContext = null;

            var subdomain = context.Request.Host.Value.ToString()?.Split('.')[0];

            if (subdomain != null)
            {
                var company = Uow.Companies.GetBySubDomain(subdomain);
                if (company != null)
                {
                    //company found
                    tenantContext = new TenantContext<Company>(company);
                }

                if (context.Request.Host.Value != "localhost:58090" && subdomain != "www" && context.Request.Path.Value != "/error/404")
                {
                    context.Response.StatusCode = 404;                    
                }               
            }

            return tenantContext;
        }
    }
}
