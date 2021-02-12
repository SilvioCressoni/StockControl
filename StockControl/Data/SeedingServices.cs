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
            if (_context.Operation.Any())
            {
                return;
            }


            Operation oper1 = new Operation(1, new DateTime(2020, 01, 01), "Itau Corretora", "ITUB4", "Itau-Unibanco", TypeOperation.Buy,
                1000, 27.00, 27000.00, StatusOperation.Open);

            Operation oper2 = new Operation(2, new DateTime(2020, 01, 01), "Itau Corretora", "BBDC4", "Bradesco", TypeOperation.Buy,
                1000, 18.60, 18600.00, StatusOperation.Open);

            Operation oper3 = new Operation(3, new DateTime(2020, 01, 01), "Itau Corretora", "MGLU3", "Magazine-Luiza", TypeOperation.Buy,
                2000, 9.00, 18000.00, StatusOperation.Open);

            Operation oper4 = new Operation(4, new DateTime(2020, 01, 01), "Itau Corretora", "YDUQ3", "Estacio", TypeOperation.Buy,
                1000, 29.70, 29700.00, StatusOperation.Open);

           
            _context.Operation.AddRange(oper1, oper2, oper3, oper4);

            _context.SaveChanges();
        }
    }
}
