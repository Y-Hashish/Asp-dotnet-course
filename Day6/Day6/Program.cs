using  Day6.Drived_classes;
namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee dev = new Developer(1,"Yousef Hashish",5000,10,50);
            dev.CalculateSalary();
            dev.DisplayInfo();

            Employee manger = new Manger(2,"Hashish up",500,20);
            manger.CalculateSalary();
            manger.DisplayInfo();

            Employee intern = new Intern(3,"MR Weed",2000);
            intern.CalculateSalary();
            intern.DisplayInfo();

            //////// MAIN METHOD ////////

            Developer developer = new Developer(4, "3aaa ", 6000, 15, 60);
            Manger manger1 = new Manger(5, "we are not..", 8000, 1000);
            Intern intern1 = new Intern(6, "ho lee sht", 3000);
            Employee[] employees = new Employee[]
            {
                developer,
                manger1,
                intern1
            };
            foreach (var item in employees)
            {
                item.DisplayInfo();
            }
        }
    }
}
