


namespace BankApp.Client.DTOs
{
    

    public class AmountRequest
{

    public decimal Amount { get; set; }
    public AmountRequest() { }
    public AmountRequest(decimal amount)
    {
        Amount = amount;
    }
}
}
