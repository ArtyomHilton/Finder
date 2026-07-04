using Finder.Identity.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Finder.Identity.Infrastructure.DataAccess;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
}
