using System;

namespace GBank.Models
{
    public record Transaction
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Settled { get; set; }

        public decimal Amount { get; set; }

        public Account Source { get; set; }

        public Account Target { get; set; } 
    }
}
