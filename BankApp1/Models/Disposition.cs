﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BankApp1.Models;

public partial class Disposition
{
    [Key]
    public int DispositionId { get; set; }

    public int CustomerId { get; set; }

    public int AccountId { get; set; }

    [StringLength(50)]
    public string Type { get; set; } = null!;

    [ForeignKey("AccountId")]
    [InverseProperty("Dispositions")]
    public virtual Account Account { get; set; } = null!;

    [InverseProperty("Disposition")]
    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Dispositions")]
    public virtual Customer Customer { get; set; } = null!;
}
