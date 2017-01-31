using FailTracker.Web.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FailTracker.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConntection") { }
    }
}