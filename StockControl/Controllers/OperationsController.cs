using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockControl.Data;
using StockControl.Models;
using StockControl.Models.Enum;
using StockControl.Models.ViewModel;
using StockControl.Services;
using System.Diagnostics;

namespace StockControl.Controllers
{
    public class OperationsController : Controller
    {
        
        private readonly OperationService _operationService;


        public OperationsController(OperationService operationService)
        {
            _operationService = operationService;
        }

        // GET: Operations
        public async Task<IActionResult> Index()
        {
            var list = await _operationService.FindAllAsync();

            return View(list);
        }


        public IActionResult Create()
        {
            //var operation = _operationService.FindAll();
            //var viewModel = new OperationFormViewModel { Operation = new Operation() };

            var operation = new Operation();

            return View(operation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Operation operation)
        {
        //    if (!ModelState.IsValid)
        //    {
        //
        //        return View();
        //    }

            await _operationService.InsertAsync(operation);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            var obj = await _operationService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not found" });
            }

            return View(obj);


        }

        public async Task<IActionResult> EditAsync(int? id)
        {
            if(id == null)
            {
               return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
                
            }

            var obj = await _operationService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Operation operation)
        {
            if (id != operation.Id)
            {
               return RedirectToAction(nameof(Error), new { message = "Id mismatch" });

            }

            try
            {
                await _operationService.UpdateAsync(operation);
                return RedirectToAction(nameof(Index));
                
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
                
            }
        }

        public async Task<IActionResult> DeleteAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            var obj = await _operationService.FindByIdAsync(id.Value);
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
           await _operationService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message)
        {

            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
