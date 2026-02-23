using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Day5
{
    internal class BankAccount
    {
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string name , string number , string type , decimal balance)
        {
            AccountHolderName = name;
            AccountNumber = number;
            AccountType = type;
            Balance = balance; 
        }
        public BankAccount(string name, string number):this(name, number, "Savings", 0)
        {
            
        }
        public BankAccount(string name ,string number,  string type): this(name, number, type, 0)
        {
            
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited: {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }
        public void Deposit(decimal amount, string currency)
        {
            switch (currency)
            {
                case "EGP":
                    Deposit(amount);
                    break;
                case "USD":
                    Deposit(amount * 30);
                    break;
                default:
                    Console.WriteLine("please enter either EGP or USD");
                    break;

            }
        }
        public void Deposit(decimal amount, string currency, bool isBouns)
        {
            if (isBouns)
            {
                amount += amount * 0.1m;
            }
            Deposit(amount, currency);
        }
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew: {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }
        public void Withdraw(decimal amount, bool isATM)
        {
            decimal fee = isATM ? amount * 0.2m : 0; 
            Withdraw(amount + fee);
        }
        public void Withdraw(decimal amount,string currency)
        {
            
            switch (currency)
            {
                case "EGP":
                    Withdraw(amount);
                    break;
                case "USD":
                    Withdraw(amount * 30);
                    break;
                default:
                    Console.WriteLine("please enter either EGP or USD");
                    break;
            }
        }
        public static BankAccount operator +(BankAccount a1, BankAccount a2)
        {
            return new BankAccount(
                a1.AccountHolderName + " & " + a2.AccountHolderName,
                a1.AccountNumber + "-" + a2.AccountNumber,
                a1.AccountType,
                a1.Balance + a2.Balance
                );
        }
        public static BankAccount operator -(BankAccount a1, BankAccount a2)
        {
            return new BankAccount(
                a1.AccountHolderName + " || " + a2.AccountHolderName,
                a1.AccountNumber + "||" + a2.AccountNumber,
                a1.AccountType,
                a1.Balance - a2.Balance
                );
        }
        public static bool operator ==(BankAccount a1, BankAccount a2)
        {
            return a1.AccountNumber == a2.AccountNumber;
        }
        public static bool operator !=(BankAccount a1, BankAccount a2)
        {
            return a1.AccountNumber != a2.AccountNumber;
        }   
        public static bool operator <(BankAccount a1, BankAccount a2)
        {
            return a1.Balance < a2.Balance;
        }   
        public static bool operator >(BankAccount a1, BankAccount a2)
        {
            return a1.Balance > a2.Balance;
        }   
        public void DisplayAccountInfo()
        {
            Console.WriteLine("Account Holder: " + AccountHolderName);
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Balance: " + Balance.ToString("C"));
        }


    }
}
