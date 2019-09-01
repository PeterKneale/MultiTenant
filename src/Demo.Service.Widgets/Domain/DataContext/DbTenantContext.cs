using Demo.Service.Common.Context;
using Demo.Service.Widgets.Domain.DataModel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Service.Widgets.Domain.DataContext
{
    public class DbTenantContext : DbContext
    {
        private readonly ITenantContext _context;

        public DbTenantContext(ITenantContext context, DbContextOptions<DbTenantContext> options) : base(options)
        {
            _context = context;
        }

        public DbSet<Widget> Widgets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Widget>().HasQueryFilter(x => x.Id == _context.TenantId);
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetTenantId();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetTenantId();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void SetTenantId()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                // only on adds
                if (entry.State != EntityState.Added)
                {
                    continue;
                }
                // only on tenant data
                if (!(entry.Entity is ITenantData data))
                {
                    continue;
                }
                data.TenantId = _context.TenantId;
            }
        }
    }
}