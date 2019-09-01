using Demo.Service.Widgets.Domain.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Widgets.Domain.DataContext
{
    public class DbGlobalContext : DbContext
    {
        public DbGlobalContext(DbContextOptions<DbGlobalContext> options) : base(options)
        {
        }

        public DbSet<Widget> Widgets { get; set; }
    }
}