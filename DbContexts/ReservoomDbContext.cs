using Microsoft.EntityFrameworkCore;
using Reservoom.DTOs;
using Reservoom.Models;

namespace Reservoom.DbContexts
{
    public class ReservoomDbContext : DbContext
    {
        private static ReservoomDbContext instance = new ReservoomDbContext( new DbContextOptionsBuilder().UseSqlite("DataSource=reservoom.db").Options);
        public static ReservoomDbContext getInstance()
        {
            return instance;
        }
        public DbSet<ReservationDTO> Reservations { get; set; }
        public ReservoomDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}