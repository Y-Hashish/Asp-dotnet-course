namespace Day7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VisitorCustomer.Totla);
            Visitor v = new Visitor();
            Console.WriteLine(VisitorCustomer.Totla);
            Visitor v2 = new Visitor();
            Console.WriteLine(VisitorCustomer.Totla);
        }
    }
}
