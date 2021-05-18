using GBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBank.Repositories
{
    public interface ITransactionRepo
    {
        List<Transaction> AllTransactions(Guid accountId);
        void AddTransactionForAccount(Guid accountId, Transaction transaction);
    }

    public class FakeTransactionRepo : ITransactionRepo
    {
        internal static Dictionary<Guid, List<Transaction>> FakeStorage = new();

        public FakeTransactionRepo(IAccountRepo accountRepo)
        {
            var guid = Guid.Parse("a3539b0e-df06-4794-98ab-1c0fcbea8f65");
            var self = accountRepo.All().Find(x => x.AccountHolderId == guid);

            this.AddTransactionForAccount(guid, new Transaction()
            {
                Amount = 1000,
                Created = DateTime.Now,
                Id = Guid.NewGuid(),
                Settled = DateTime.Now,
                Target = self
            });
        }
        public void AddTransactionForAccount(Guid accountId, Transaction transaction)
        {
            if (!FakeStorage.ContainsKey(accountId))
            {
                FakeStorage.Add(accountId, new List<Transaction>());
            }
            FakeStorage[accountId].Add(transaction);
        }

        public List<Transaction> AllTransactions(Guid accountId)
        {
            if (!FakeStorage.ContainsKey(accountId))
            {
                return Array.Empty<Transaction>().ToList();
            }

            return FakeStorage[accountId].ToList();
        }
    }
}
