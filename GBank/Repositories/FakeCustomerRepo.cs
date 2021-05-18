using GBank.Models;
using System;
using System.Collections.Generic;

namespace GBank.Repositories
{
    public static class FakeCustomerRepo
    {
        public static List<Customer> GetCustomers()
        {
            var items = new List<Customer>();
            items.Add(new Customer() { Id = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), FirstName = "Casper", LastName = "Broeren", BirthDay = new DateTime(1984, 7, 20)});
            items.Add(new Customer() { Id = Guid.Parse("5bb3190a-56e6-402f-9903-2e75b6697094"), FirstName = "Joyce", LastName = "Kaper", BirthDay = new DateTime(1984, 3, 25) });

            return items;
        }
    }
}
