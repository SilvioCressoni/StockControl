using Microsoft.EntityFrameworkCore;
using StockControl.Models;



    public class StockControlContext : DbContext
    {
        public StockControlContext(DbContextOptions<StockControlContext> options)
            : base(options)
        {
        }

        public DbSet<Operation> Operation { get; set; }

    }

