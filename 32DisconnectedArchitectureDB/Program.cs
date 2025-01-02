using Microsoft.Data.SqlClient;
using System.Data;

namespace DisconnectedArchitectureDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conStr = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=vikram;Integrated Security=True";

            SqlConnection con = new SqlConnection(conStr);
            string selectQueryText = "SELECT * FROM Emp";

            // Setup the Data Adapter and CommandBuilder
            SqlDataAdapter da = new SqlDataAdapter(selectQueryText, con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey; // Important for primary key handling
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            DataTable dt = new DataTable();
            da.Fill(dt);

            Console.WriteLine("Current Employees:");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Address: {row["Address"]}");
            }

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Insert Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Insert Query
                        Console.WriteLine("Enter Id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string address = Console.ReadLine();

                        DataRow newRow = dt.NewRow();
                        newRow["Id"] = id;
                        newRow["Name"] = name;
                        newRow["Address"] = address;
                        dt.Rows.Add(newRow);

                        da.Update(dt);
                        Console.WriteLine("Employee inserted successfully.");
                        break;

                    case "2":
                        // Update Query
                        Console.Write("Enter Id to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            DataRow empToEdit = dt.Rows.Find(updateId);
                            if (empToEdit != null)
                            {
                                Console.Write("Enter new Name: ");
                                empToEdit["Name"] = Console.ReadLine();
                                Console.Write("Enter new Address: ");
                                empToEdit["Address"] = Console.ReadLine();

                                da.Update(dt);
                                Console.WriteLine("Employee updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Employee with the given Id not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id.");
                        }
                        break;

                    case "3":
                        // Delete Query
                        Console.Write("Enter Id to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            DataRow empToDelete = dt.Rows.Find(deleteId);
                            if (empToDelete != null)
                            {
                                empToDelete.Delete();
                                da.Update(dt);
                                Console.WriteLine("Employee deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Employee with the given Id not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
