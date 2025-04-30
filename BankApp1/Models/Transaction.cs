using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankApp1.Models;

[Index("AccountId", Name = "IX_Transactions_AccountId")]
public partial class Transaction
{
    public int TransactionId { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public string Operation { get; set; }
    public DateTime Date { get; set; }
    public decimal Balance { get; set; }

    [StringLength(50)]
    public string? Symbol { get; set; }

    [StringLength(50)]
    public string? Bank { get; set; }


