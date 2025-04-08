using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankApp1.Models;


namespace BankApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly BankContext _context;

        public CustomersController(BankContext context)
        {
            _context = context;
        }

        // GET: api/customers/1/accounts
        [HttpGet("{id}/accounts")]
        public async Task<IActionResult> GetCustomerAccounts(int id)
        {
            var accounts = await _context.Dispositions
                .Where(d => d.CustomerId == id)
                .Include(d => d.Account)
                .Select(d => new {
                    d.AccountId,
                    d.Account.Balance,
                    d.Account.Frequency
                })
                .ToListAsync();

            if (!accounts.Any())
            {
                return NotFound($"No accounts found for customer {id}");
            }

            return Ok(accounts);
        }
    }
}
