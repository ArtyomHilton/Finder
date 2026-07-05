using System.Reflection;
using Finder.Identity.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Finder.Identity.Infrastructure.DataAccess;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(nameof(Identity));

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
