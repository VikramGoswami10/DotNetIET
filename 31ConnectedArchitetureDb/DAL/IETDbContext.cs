using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _31ConnectedArchitetureDb.Model;
using Microsoft.Data.SqlClient;

namespace _31ConnectedArchitetureDb.DAL
{
    public class IETDbContext
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=vikram;Integrated Security=True";
        public int affectedRows = 0;
        List<Emp> emps = new List<Emp>();

        public List<Emp> SelectRecords()
        {
            SqlConnection con = new SqlConnection(conStr);
            string query = "select * from Emp";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                emps.Add(new Emp() { Id = Convert.ToInt32(reader["Id"]), Name = reader["Name"].ToString(), Address = reader["Address"].ToString() });
            }
            con.Close();
            return emps;
        }

        public int InsertRecord(Emp empToBeInserted)
        {
            SqlConnection con = new SqlConnection(conStr); 
            string query = $"insert into Emp values({empToBeInserted.Id},'{empToBeInserted.Name}','{empToBeInserted.Address}')";
            SqlCommand cmd = new SqlCommand(query , con);
            con.Open();
            affectedRows = cmd.ExecuteNonQuery();
            con.Close();
            return affectedRows;
        }

        internal int UpdateRecord(Emp empToBeUpdated)
        {
            SqlConnection con = new SqlConnection(conStr);
            //string query = $"update Emp set Name ='{emp.Name}', Address ='{emp.Address}' where Id={emp.Id}";
            string query = $"update Emp set Name = '{empToBeUpdated.Name}' , Address = '{empToBeUpdated.Address}' where Id = {empToBeUpdated.Id}";
            SqlCommand cmd = new SqlCommand(query , con);
            con.Open();
            affectedRows = cmd.ExecuteNonQuery();
            con.Close();

            return affectedRows;
        }

        internal int DeleteRecord(int id)
        {
            SqlConnection con = new SqlConnection(conStr) ;
            string query = $"delete from Emp where Id = {id}";
            SqlCommand cmd = new SqlCommand(query , con);
            con.Open();
            affectedRows = cmd.ExecuteNonQuery ();
            con.Close();

            return affectedRows;
        }
    }
}
