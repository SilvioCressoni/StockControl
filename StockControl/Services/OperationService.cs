using System;
using System.Collections.Generic;
using System.Linq;
using StockControl.Data;
using StockControl.Models;

namespace StockControl.Services
{
    public class OperationService
    {
        StockControlContext _context;

        public OperationService(StockControlContext context)
        {
            _context = context;
        }

        public List<Operation> FindAll()
        {
            return _context.Operation.ToList();
        }
    }
}
