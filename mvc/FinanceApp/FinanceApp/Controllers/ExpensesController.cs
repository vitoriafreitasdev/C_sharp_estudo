using FinanceApp.Data;
using Microsoft.AspNetCore.Mvc;
using FinanceApp.Models;
using FinanceApp.Data.Services;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _service;

        public ExpensesController(IExpensesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _service.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _service.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }
        public IActionResult GetChart()
        {
            var data = _service.GetChartData();
            return Json(data);
        }
    }
}
