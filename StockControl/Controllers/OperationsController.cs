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
        public IActionResult Index()
        {
            var list = _operationService.FindAll();

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
        public IActionResult Create(Operation operation)
        {
        //    if (!ModelState.IsValid)
        //    {
        //
        //        return View();
        //    }

            _operationService.Insert(operation);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            var obj = _operationService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "id not found" });
            }

            return View(obj);


        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
               return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
                
            }

            var obj = _operationService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Operation operation)
        {
            if (id != operation.Id)
            {
               return RedirectToAction(nameof(Error), new { message = "Id mismatch" });

            }

            try
            {
                _operationService.Update(operation);
                return RedirectToAction(nameof(Index));
                
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
                
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            var obj = _operationService.FindById(id.Value);
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id)
        {
            _operationService.Remove(id);

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
