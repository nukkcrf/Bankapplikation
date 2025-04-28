using BankApp1.Data; // Add this using directive

namespace BankApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController
    {
        private readonly BankApp1Context _context;

        public TransactionController(BankApp1Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }
    }
}
