using Microsoft.EntityFrameworkCore;
using WebAppAPI.DTOs;

namespace WebAppAPI.DataContext
{
    public class PrinterContext : DbContext
    {
        public PrinterContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        
        public DbSet<Printer> Printer { get; set; }
    }
}
