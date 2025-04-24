namespace BankApp1.DTOs
{
    public class TransferRequest
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public TransferRequest() { }
        public TransferRequest(int fromAccountId, int toAccountId, decimal amount)
        {
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            Amount = amount;
        }
    }
}
