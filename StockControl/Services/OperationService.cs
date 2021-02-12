using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Operation FindById(int id)
        {

            return _context.Operation.FirstOrDefault(oper => oper.Id == id);
        }

        public void Insert(Operation operation)
        {
            _context.Operation.Add(operation);

            _context.SaveChanges();
        }

        public void Update(Operation operation)
        {

            if(!_context.Operation.Any(x => x.Id == operation.Id ))
            {
                return;
            }

            try
            {
                _context.Update(operation);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return;
            }

        }

    }
}
