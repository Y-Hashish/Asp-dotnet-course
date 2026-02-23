using System;
using System.Collections.Generic;
using System.Text;

namespace Day7
{
    internal abstract class Payment
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        protected Payment(int trans, decimal amount)
        {
            this.TransactionId = trans;
            this.Amount = amount;
        }

        public abstract bool ProcessPayment();
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Transaction ID: {TransactionId}, Amount: {Amount:C}");
        }
        
    }
}
