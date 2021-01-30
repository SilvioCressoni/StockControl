using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockControl.Models;

    public class StockControlContext : DbContext
    {
        public StockControlContext (DbContextOptions<StockControlContext> options)
            : base(options)
        {
        }

        public DbSet<StockControl.Models.Operation> Operation { get; set; }
    }
