using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankApp1.Models;

namespace BankApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly BankContext _context;

        public TransactionsController(BankContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            var transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }
        // GET: api/transactions/account/5
        [HttpGet("account/{accountId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByAccount(int accountId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();

            if (!transactions.Any())
                return NotFound($"No transactions found for account {accountId}");

            return Ok(transactions);
        }

    }
}
