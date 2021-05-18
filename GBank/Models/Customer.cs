using GBank.Repositories;
using System;
using System.Collections.Generic;

namespace GBank.Models
{
    public record Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDay { get; set; } 
    }
}
