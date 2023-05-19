using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Reservoom.DbContexts
{
    public class ReservoomDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReservoomDbContext>
    {
        public ReservoomDbContext CreateDbContext(string[] args)
        {
           DbContextOptions options= new DbContextOptionsBuilder().UseSqlite("DataSource=reservoom.db").Options;
            return new ReservoomDbContext(options);
        }
    }
}
