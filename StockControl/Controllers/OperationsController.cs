using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockControl.Data;
using StockControl.Services;

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

        

     }
}
