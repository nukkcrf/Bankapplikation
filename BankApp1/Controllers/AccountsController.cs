using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BankApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using BankApp1.Models;

namespace BankApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly BankContext _context;

        public AccountsController(BankContext context)
        {
            _context = context;
        }

        // POST: api/accounts/123/deposit
        [HttpPost("{id}/deposit")]
        public async Task<IActionResult> Deposit(int id, [FromBody] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Amount must be greater than zero.");

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return NotFound("Account not found.");

            account.Balance += amount;

            var transaction = new Transaction
            {
                AccountId = id,
                Amount = amount,
                Date = DateTime.Now,
                Operation = "Deposit",
                Type = "Credit",
                Balance = account.Balance
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deposit successful", newBalance = account.Balance });
        }
    }
}
