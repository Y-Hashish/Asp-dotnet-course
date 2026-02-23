using System.Security.Cryptography.X509Certificates;

namespace Day3
{
    internal class Program
    {
        public enum pizza_size
        {
            small = 1,
            medium,
            large
        }
        static void Main(string[] args)
        {
            // 1
            //Console.WriteLine("Enter 1 for small pizza\n" +
            //    "2 for medium pizza\n3 for large pizza");
            //int choice = Convert.ToInt32(Console.ReadLine());
            //pizza_size size = (pizza_size)choice;
            //Console.WriteLine("Selected size is : " + size);
            //switch(size)
            //{
            //    case pizza_size.small:
            //        Console.WriteLine("price 12");
            //        break;
            //    case pizza_size.medium:
            //        Console.WriteLine("price 16");
            //        break;
            //    case pizza_size.large:
            //        Console.WriteLine("price 18");
            //        break;
            //    default:
            //        Console.WriteLine("Invalid size selected");
            //        break;
            //}

            // 2
            //void increaseByValue(int n)
            //{
            //    n = n + 10;

            //}
            //void increaseByRef(ref int n)
            //{
            //    n = n + 10;
            //}

            //int num = 20;
            //Console.WriteLine("Test pass by value ");
            //Console.WriteLine($"before calling the fun {num}");
            //increaseByValue(num);
            //Console.WriteLine($"after calling the fun {num}");

            //Console.WriteLine("Test pass by reference ");
            //Console.WriteLine($"before calling the fun {num}");
            //increaseByRef(ref num);
            //Console.WriteLine($"after calling the fun {num}");

            // 3
            //int[] product_price= { 100, 200, 300};
            //void updatePrice(int[] prices)
            //{
            //    for(int i=0;i<prices.Length;i++)
            //    {
            //        prices[i] = prices[i] + 50;
            //    }
            //}
            //void ReplaceArray(ref int[] arr)
            //{
            //    arr = new int[] {500,600,700 };
            //}
            //void print(int[] a)
            //{
            //    foreach(var item in a)
            //    {
            //        Console.Write($" {item},");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine("Before updating the price ");
            //print(product_price);
            //updatePrice(product_price);
            //Console.WriteLine("After updating the price ");
            //print(product_price);

            //Console.WriteLine("Before updating the price ");
            //print(product_price);
            //ReplaceArray(ref product_price);
            //Console.WriteLine("After updating the price ");
            //print(product_price);

            //4
            employee emp1 = new employee(100,"Ahmend", 2000);
            Console.WriteLine("before call the increase fun : ");
            emp1.display();
            increaseSalary(emp1);
            Console.WriteLine("after call the increase fun : ");
            emp1.display();
        }
        public static void increaseSalary(employee emp)
        {
            emp.salary = emp.salary + emp.salary * 0.1;
        }
    }
}
