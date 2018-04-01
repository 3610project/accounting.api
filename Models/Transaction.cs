using System;

namespace Accounting.Api.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Vendor { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Account { get; set; }

    }
}