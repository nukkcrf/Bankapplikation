using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace BankApp1.Models;

public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [StringLength(50)]
    public string Frequency { get; set; } = null!;

    public DateOnly Created { get; set; }

    
    public decimal Balance { get; set; }

   
    public virtual ICollection<Disposition> Dispositions { get; set; } = new List<Disposition>();

    
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public virtual ICollection<PermenentOrder> PermenentOrders { get; set; } = new List<PermenentOrder>();

   
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}