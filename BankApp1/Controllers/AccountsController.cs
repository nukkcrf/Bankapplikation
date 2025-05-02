using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BankApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using BankApp1.Models;
using BankApp1.DTOs;



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
        // GET: api/accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // POST: api/accounts/123/deposit
        [HttpPost("{id}/deposit")]
        public async Task<IActionResult> Deposit(int id, [FromBody] AmountRequest request)
        {
            if (request.Amount <= 0)
                return BadRequest("Amount must be greater than zero.");

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return NotFound("Account not found.");

            account.Balance += request.Amount;

            var transaction = new Transaction
            {
                AccountId = id,
                Amount = request.Amount,
                Date = DateTime.Now,
                Operation = "Deposit",
                Type = "Credit",
                Balance = account.Balance
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Deposit successful", newBalance = account.Balance });
        }

        // POST: api/accounts/123/withdraw
        [HttpPost("{id}/withdraw")]
        public async Task<IActionResult> Withdraw(int id, [FromBody] AmountRequest amount)
        {
            try
            {
                if (amount.Amount <= 0)
                    return BadRequest("Amount must be greater than zero.");

                var account = await _context.Accounts.FindAsync(id);
                if (account == null)
                    return NotFound("Account not found.");

                if (account.Balance < amount.Amount)
                    return BadRequest("Insufficient funds.");

                account.Balance -= amount.Amount;

                var transaction = new Transaction
                {
                    AccountId = id,
                    Amount = -amount.Amount, 
                    Date = DateTime.Now,
                    Operation = "Withdraw",
                    Type = "Debit",
                    Balance = account.Balance
                };

                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Withdraw successful", newBalance = account.Balance });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A server error occurred: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return NotFound("Account not found.");

            return Ok(account);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferRequest request)
        {
            try
            {
                if (request.Amount <= 0)
                    return BadRequest("Amount must be greater than zero.");
                if (request.FromAccountId == request.ToAccountId)
                    return BadRequest("Cannot transfer to the same account.");

                var fromAccount = await _context.Accounts.FindAsync(request.FromAccountId);
                var toAccount = await _context.Accounts.FindAsync(request.ToAccountId);

                if (fromAccount == null || toAccount == null)
                    return NotFound("One or both accounts not found.");

                if (fromAccount.Balance < request.Amount)
                    return BadRequest("Insufficient funds.");

                // Widraw
                fromAccount.Balance -= request.Amount;
                var withdrawTransaction = new Transaction
                {
                    AccountId = fromAccount.AccountId,
                    Amount = -request.Amount,
                    Date = DateTime.Now,
                    Operation = "Transfer out",
                    Type = "Debit",
                    Balance = fromAccount.Balance
                };

                // Deposit
                toAccount.Balance += request.Amount;
                var depositTransaction = new Transaction
                {
                    AccountId = toAccount.AccountId,
                    Amount = request.Amount,
                    Date = DateTime.Now,
                    Operation = "Transfer in",
                    Type = "Credit",
                    Balance = toAccount.Balance
                };

                _context.Transactions.AddRange(withdrawTransaction, depositTransaction);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Transfer successful",
                    fromAccountNewBalance = fromAccount.Balance,
                    toAccountNewBalance = toAccount.Balance
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"A server error occurred: {ex.Message}");
            }
        }


    }
}
