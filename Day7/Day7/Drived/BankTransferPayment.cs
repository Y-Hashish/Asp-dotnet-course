using System;
using System.Collections.Generic;
using System.Text;

namespace Day7.Drived
{
    internal class BankTransferPayment : Payment
    {
        public string BankName { get; set; }
        public int AccountNumber { get; set; }

        public override bool ProcessPayment()
        {
            return true;
        }
        public BankTransferPayment(int trans, decimal amount, string name, int account):
            base(trans, amount)
        {
            BankName = name;
            AccountNumber = account;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Bank Name: {BankName}, Account Number: {AccountNumber}");
        }
    }
}
