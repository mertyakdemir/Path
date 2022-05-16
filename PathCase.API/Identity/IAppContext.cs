using PathCase.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PathCaseAPI.Identity
{
    public class IAppContext : IdentityDbContext<User>
    {
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public IAppContext(DbContextOptions<IAppContext> options) : base(options)
        {

        }
    }
}
