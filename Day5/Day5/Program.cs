namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("yousef", "303090", "saving", 1000);
            account1.DisplayAccountInfo();
            BankAccount account2 = new BankAccount("Hashish", "404080");
            account2.DisplayAccountInfo();

            BankAccount acc1 = account1 + account2;
            acc1.DisplayAccountInfo();

            BankAccount acc2 = account1 - account2;
            acc2.DisplayAccountInfo();

            account1.Deposit(500);
            account1.Deposit(500, "EGP");
            account1.Deposit(500, "USD", true);

            account1.Withdraw(100);
            account1.Withdraw(100,true);
            account1.Withdraw(100,"USD");



            //if (account1 == account2)
            //    Console.WriteLine("Accounts are equal.");
            //else
            //    Console.WriteLine("Accounts are not equal.");

            //if(account1 != account2)
            //    Console.WriteLine("Accounts are not equal.");
            //else
            //    Console.WriteLine("Accounts are equal.");

            //if(account1 > account2)
            //    Console.WriteLine("Account1 has a greater balance than Account2.");
            //else
            //    Console.WriteLine("Account1 does not have a greater balance than Account2.");

            //if(account1 < account2)
            //    Console.WriteLine("Account1 has a smaller balance than Account2.");
            //else
            //    Console.WriteLine("Account1 does not have a smaller balance than Account2.");
        }
    }
}
