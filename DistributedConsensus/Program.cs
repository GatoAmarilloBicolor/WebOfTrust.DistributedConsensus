using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebOfTrustConsensus
{
    class Program
    {
        public static void Main()
        {
            using (var db = new ConsensusContext())
            {
                List<KVPendingChanges> changes = null;
                List<KVPendingChanges> changes2 = null;

                changes = new List<KVPendingChanges>();
                changes.Add(new KVPendingChanges() { Key = "1", Value = "1", Proof = "" });
                changes.Add(new KVPendingChanges() { Key = "2", Value = "1", Proof = "" });
                changes.Add(new KVPendingChanges() { Key = "3", Value = "1", Proof = "" });
                changes.Add(new KVPendingChanges() { Key = "4", Value = "1", Proof = "" });
                changes.Add(new KVPendingChanges() { Key = "5", Value = "1", Proof = "" });
                changes.Add(new KVPendingChanges() { Key = "6", Value = "1", Proof = "" });
                changes.Add(new KVPendingChanges() { Key = "7", Value = "1", Proof = "" });
                db.Transactions.Add(new Transaction { DateCommitted = DateTime.UtcNow, PendingChanges = changes});

                changes2 = new List<KVPendingChanges>();
                changes2.Add(new KVPendingChanges() { Key = "11", Value = "1", Proof = "" });
                changes2.Add(new KVPendingChanges() { Key = "22", Value = "1", Proof = "" });
                changes2.Add(new KVPendingChanges() { Key = "33", Value = "1", Proof = "" });
                changes2.Add(new KVPendingChanges() { Key = "44", Value = "1", Proof = "" });
                changes2.Add(new KVPendingChanges() { Key = "55", Value = "1", Proof = "" });
                changes2.Add(new KVPendingChanges() { Key = "66", Value = "1", Proof = "" });
                changes2.Add(new KVPendingChanges() { Key = "77", Value = "1", Proof = "" });
                db.Transactions.Add(new Transaction { DateCommitted = DateTime.UtcNow, PendingChanges = changes2 });

                var count = db.SaveChanges();
                Console.WriteLine("{0} transactions saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All keys in database:");
                foreach (var transaction in db.Transactions)
                {
                    Console.WriteLine(" - {0}", transaction.DateCommitted);
                    foreach (var change in transaction.PendingChanges)
                    {
                        Console.WriteLine(" -- {0} = {1}", change.Key, change.Value);
                    }
                }
            }
        }
    }

    public class ConsensusContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<KVPendingChanges> KeyValuePairHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Consensus.db");
        }
    }

    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime DateCommitted { get; set; }

        public List<KVPendingChanges> PendingChanges { get; set; } 
    }
     
    public class KVPendingChanges
    {
        public int KVPendingChangesID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Proof { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }

    public class KVCurrentValue
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public List<int> TransactionId { get; set; }
        public List<Transaction> RelatedTransactions { get; set; }
    }
}
