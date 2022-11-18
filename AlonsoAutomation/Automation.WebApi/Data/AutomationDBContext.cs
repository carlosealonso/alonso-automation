using Automation.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Automation.WebApi.Data
{
    public class AutomationDBContext : DbContext
    {
        public DbSet<Humidity> Humidities => Set<Humidity>();
        public DbSet<Device> Devices => Set<Device>();

        public AutomationDBContext(DbContextOptions<AutomationDBContext> options)
            : base(options) { }
    }
}