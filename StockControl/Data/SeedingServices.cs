using System;
using System.Linq;
using StockControl.Data;
using StockControl.Models;
using StockControl.Models.Enum;

namespace StockControl.Data
{
    public class SeedingServices
    {
        private StockControlContext _context;

        public SeedingServices(StockControlContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Operation.Any() ||
                _context.Stock.Any() ||
                _context.TaxOperation.Any())
            {
                return;
            }

            TaxOperation tax1 = new TaxOperation(1, 5.62, 0.67, 4.90, 4.28, 1.02);
            TaxOperation tax2 = new TaxOperation(2, 6.00, 1.00, 4.90, 7.12, 2.05);
            TaxOperation tax3 = new TaxOperation(3, 4.30, 3.48, 4.90, 5.45, 1.13);
            TaxOperation tax4 = new TaxOperation(4, 5.14, 2.97, 4.90, 6.67, 2.27);

            Operation oper1 = new Operation(1, new DateTime(2020,01,01), "Itau Corretora", TypeOperation.Buy,
                1000, 27.00, 27000.00, StatusOperation.Open, tax1);

            Operation oper2 = new Operation(2, new DateTime(2020, 01, 01), "Itau Corretora", TypeOperation.Buy,
                1000, 18.60, 18600.00, StatusOperation.Open, tax2);

            Operation oper3 = new Operation(3, new DateTime(2020, 01, 01), "Itau Corretora", TypeOperation.Buy,
                2000, 9.00, 18000.00, StatusOperation.Open, tax3);

            Operation oper4 = new Operation(4, new DateTime(2020, 01, 01), "Itau Corretora", TypeOperation.Buy,
                1000, 29.70, 29700.00, StatusOperation.Open, tax4);

            Stock stck1 = new Stock(1, "ITUB4", "Itau-Unibanco", StockSector.Bank, oper1);
            Stock stck2 = new Stock(2, "BBDC4", "Bradesco", StockSector.Bank, oper2);
            Stock stck3 = new Stock(3, "MGLU3", "Magazine Luiza", StockSector.Retail, oper3);
            Stock stck4 = new Stock(4, "YDUQ3", "Estacio", StockSector.Educational, oper4);

            _context.TaxOperation.AddRange(tax1, tax2, tax3, tax4);
            _context.Operation.AddRange(oper1, oper2, oper3, oper4);
            _context.Stock.AddRange(stck1, stck2, stck3, stck4);

            _context.SaveChanges();
        }
    }
}
