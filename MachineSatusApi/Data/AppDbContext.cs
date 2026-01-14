using Microsoft.EntityFrameworkCore;
using MachineStatusApi.Models;

namespace MachineStatusApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
    }
}
