using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace waproject.Identity.Contexts
{
    public class IdentityApplicationDbContext : IdentityDbContext
    {
        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
