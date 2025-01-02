using _34EntityFramework.DAl;
using _34EntityFramework.Model;

namespace _34EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IETDbContext dbContext = new IETDbContext();
            int choice = 0; 
            do {
                Console.WriteLine("Enter operation choice 1. Select, 2. Insert, 3.Update, 4.Delete" +
                   " 5. Get Employee by Id using SP, 6. Get All Employess based on Address start Letter");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice) {
                    case 1:
                        var allemployees = dbContext.Employees.ToList();
                        foreach (var emp in allemployees) {
                            Console.WriteLine($"Id: {emp.Id}, Name: {emp.EName}, Address: {emp.Address}");
                        }
                        break;
                    case 2:
                        Employee empRecordToBeInserted = new Employee();
                        Console.WriteLine("Enter Name:");
                        empRecordToBeInserted.EName = Console.ReadLine();
                        Console.WriteLine("Enter Address:");
                        empRecordToBeInserted.Address = Console.ReadLine();

                        dbContext.Employees.Add(empRecordToBeInserted);
                        dbContext.SaveChanges();
                        break;

                    case 3:
                        Console.WriteLine("Enter Id");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Employee empRecordToBeUpdated = dbContext.Employees.Find(id);

                        Console.WriteLine("Enter Name:");
                        empRecordToBeUpdated.EName = Console.ReadLine();
                        Console.WriteLine("Enter Address:");
                        empRecordToBeUpdated.Address = Console.ReadLine();

                        dbContext.SaveChanges();
                        break;
                }

            } while(choice!=7);

        }
    }
}
