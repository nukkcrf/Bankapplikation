namespace BankApp1.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;   

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
