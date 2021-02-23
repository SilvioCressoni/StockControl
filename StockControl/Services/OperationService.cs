using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockControl.Data;
using StockControl.Models;
using StockControl.Services.Exceptions;

namespace StockControl.Services
{
    public class OperationService
    {
        StockControlContext _context;

        public OperationService(StockControlContext context)
        {
            _context = context;
        }

        public async Task<List<Operation>> FindAllAsync()
        {
            return await _context.Operation.ToListAsync();
        }

        public async Task<Operation> FindByIdAsync(int id)
        {

            return await _context.Operation.FirstOrDefaultAsync(oper => oper.Id == id);
        }

        public async Task InsertAsync(Operation operation)
        {
            // this command just save in memory 
            _context.Add(operation);

            // this one at truth saving on Database and needs to be included Async and await
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Operation operation)
        {

            var hasAny = await _context.Operation.AnyAsync(x => x.Id == operation.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }

            try
            {
                _context.Update(operation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

        public async Task RemoveAsync(int id)
        {
            var obj = _context.Operation.Find(id);
            _context.Operation.Remove(obj);

            await _context.SaveChangesAsync();
        }

    }
}
