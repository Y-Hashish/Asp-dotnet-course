using System;
using System.Collections.Generic;
using System.Text;

namespace Day7.Drived
{
    internal class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public CreditCardPayment(int transid, decimal amount, string cardnumber,string CardHolderName):base (transid, amount)
        {
            this.CardNumber = cardnumber;   
            this.CardHolderName = CardHolderName;
        }

        public override bool ProcessPayment()
        {
            return true;
        }
        override public void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Card Number: {CardNumber}, Card Holder Name: {CardHolderName}");
        }
    }
}
