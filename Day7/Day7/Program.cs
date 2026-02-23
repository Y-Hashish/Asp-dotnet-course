using Day7.Drived;
namespace Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Payment creditCardPayment = new CreditCardPayment(1, 100.50m, "404040", "John Doe");
            creditCardPayment.DisplayInfo();
            Console.WriteLine($"Payment Processed: {creditCardPayment.ProcessPayment()}");


            Payment paypalPayment = new Paypa_(2, 75.25m, "hashish@gmal.com");
            paypalPayment.DisplayInfo();
            Console.WriteLine($"Payment Processed: {paypalPayment.ProcessPayment()}");

            Payment bankTransferPayment = new BankTransferPayment(3, 200.00m, "El Hashish Bank", 010);
            bankTransferPayment.DisplayInfo();
            Console.WriteLine($"Payment Processed: {bankTransferPayment.ProcessPayment()}");


        }
    }
}
