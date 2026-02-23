using System;
using System.Collections.Generic;
using System.Text;

namespace Day7.Drived
{
    internal class Paypa_: Payment
    {
        public string Email { get; set; }
        public override bool ProcessPayment()
        {
            return true;
        }
        public Paypa_(int trans , decimal amount , string email):
            base(trans, amount)
        {
            this.Email = email;
        }
        override public void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"PayPal Email: {Email}");
        }
    }
}
