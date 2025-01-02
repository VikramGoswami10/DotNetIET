using System.Net;
using _31ConnectedArchitetureDb.DAL;
using _31ConnectedArchitetureDb.Model;

namespace _31ConnectedArchitetureDb
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IETDbContext dbContext = new IETDbContext();
            int choice = 0;
            int affectedRows  = 0 ;
            do
            {
                Console.WriteLine("Enter DB Operation Choice: 1. Select, 2.Insert, 3.Update, 4.Delete, 5.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        List<Emp> emps = dbContext.SelectRecords();
                        if (emps != null)
                        {
                            Console.WriteLine("Employee Details -->");
                            foreach (Emp e in emps)
                            {
                                Console.WriteLine($"Employee Id : {e.Id} , Name : {e.Name} , Address : {e.Address}");
                            }
                        }
                        else {
                            Console.WriteLine("No records");
                        }
                        Console.WriteLine("---------------------------------------");
                        break;
                    case 2:
                        Emp empToBeInserted = new Emp();
                        Console.WriteLine("Enter Id to Be Inserted");
                        empToBeInserted.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Name of Emp");
                        empToBeInserted.Name = Console.ReadLine();
                        Console.WriteLine("enter Address of Emp");
                        empToBeInserted.Address = Console.ReadLine();
                        affectedRows = dbContext.InsertRecord(empToBeInserted);
                        if (affectedRows > 0)
                        {
                            Console.WriteLine("Record Inserted Successfully");
                        }
                        else {
                            Console.WriteLine("Record Insert Error");
                        }
                        Console.WriteLine("---------------------------------------");
                        break;
                    case 3:
                        Emp empToBeUpdated = new Emp();
                        Console.WriteLine("enter id of employee to update");
                        empToBeUpdated.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter Name of Emp");
                        empToBeUpdated.Name = Console.ReadLine();
                        Console.WriteLine("enter Address of Emp");
                        empToBeUpdated.Address = Console.ReadLine();
                        affectedRows = dbContext.UpdateRecord(empToBeUpdated);
                        if (affectedRows > 0)
                        {
                            Console.WriteLine("Record Updated Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Record Update Error");
                        }
                        Console.WriteLine("---------------------------------------");
                        break;
                    case 4:
                        Console.WriteLine("enter id of employee to delete");
                        int id = Convert.ToInt32(Console.ReadLine());
                        affectedRows = dbContext.DeleteRecord(id);
                        if (affectedRows > 0)
                        {
                            Console.WriteLine("Record Deleted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Record Delete Error");
                        }
                        Console.WriteLine("---------------------------------------");
                        break;
                    case 5:
                        Console.WriteLine("Thanks for coming...byee");
                        Console.WriteLine("---------------------------------------");
                        break;
                    default:
                        Console.WriteLine("Invalid Input..try Again");
                        Console.WriteLine("---------------------------------------");
                        break;
                }

            } while (choice!=5);
           
        }
    }
}
