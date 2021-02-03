using Microsoft.EntityFrameworkCore;
using StockControl.Models;



    public class StockControlContext : DbContext
    {
        public StockControlContext(DbContextOptions<StockControlContext> options)
            : base(options)
        {
        }

        public DbSet<Operation> Operation { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<TaxOperation> TaxOperation { get; set; }

    }

