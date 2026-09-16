using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpenseService : IExpensesService
    {
        private readonly FinanceAppContext _context;

        public ExpenseService(FinanceAppContext context)
        {
            _context = context;
        }
        public async Task Add(Expense expense)
        {
            expense.Date = DateTime.UtcNow;
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expenses
                .GroupBy(e => e.Category)
                .Select( g => new 
                { 
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount) 
                });

            return data;
        }
    }
}
