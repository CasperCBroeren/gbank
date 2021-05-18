using GBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBank.Repositories
{
    public interface IAccountRepo
    {
        List<Account> GetAccounts(Guid customerId);
    }

    public class FakeAccountRepo : IAccountRepo
    {
        public List<Account> GetAccounts(Guid customerId)
        {
            var items = new List<Account>();
            items.Add(new Account() { AccountHolderId = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), Currency = "EUR", Iban = "1", Usage = AccountUsage.Courant, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), Currency = "USD", Iban = "2", Usage = AccountUsage.Courant, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), Currency = "EUR", Iban = "3", Usage = AccountUsage.Savings, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), Currency = "EUR", Iban = "11", Usage = AccountUsage.Courant, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), Currency = "USD", Iban = "12", Usage = AccountUsage.Courant, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65"), Currency = "EUR", Iban = "23", Usage = AccountUsage.Savings, Id = Guid.NewGuid() });


            items.Add(new Account() { AccountHolderId = Guid.Parse("5bb3190a-56e6-402f-9903-2e75b6697094"), Currency = "EUR", Iban = "4", Usage = AccountUsage.Courant, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("5bb3190a-56e6-402f-9903-2e75b6697094"), Currency = "EUR", Iban = "5", Usage = AccountUsage.Savings, Id = Guid.NewGuid() });
            items.Add(new Account() { AccountHolderId = Guid.Parse("5bb3190a-56e6-402f-9903-2e75b6697094"), Currency = "EUR", Iban = "6", Usage = AccountUsage.Debt, Id = Guid.NewGuid() });

            return items.Where(x => x.AccountHolderId == customerId).ToList();
        }
    }
}
