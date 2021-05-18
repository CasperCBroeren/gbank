using System;
using System.Collections.Generic;

namespace GBank.Models
{
    public record Account
    {
        public Guid Id { get; set; }

        public Customer AccountHolder { get; set; }

        public Guid AccountHolderId { get; set; }

        public string Iban { get; set; }

        public IList<Transaction> Transactions { get; set; }

        public string Currency { get; set; }

        public AccountUsage Usage { get; set; }
    }
}
