using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedure_TASK_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string _connectionStr = "data source=HP-HIKE-444\\SQLEXPRESS; database=master; integrated security=SSPI";
            
            using(SqlConnection con = new SqlConnection(_connectionStr))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("GetORAddN", con);

                cmd1.CommandType = CommandType.StoredProcedure;

                Console.WriteLine("Enter your name: ");
                string nameInn = Console.ReadLine();
                Console.WriteLine("Enter your Place");
                string PlaceInn = Console.ReadLine();

                cmd1.Parameters.AddWithValue("flag", "add");
                cmd1.Parameters.AddWithValue("@Name", nameInn);
                cmd1.Parameters.AddWithValue("@Place", PlaceInn);

                cmd1.ExecuteNonQuery();






                SqlCommand cmd = new SqlCommand("GetORAddN", con);
               

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("flag", "get");


                SqlDataReader reder = cmd.ExecuteReader();

                while (reder.Read())
                {
                    int Id = (int)reder["Stud_Id"];
                    string Name = (string)reder["Stud_name"];
                    string Age = (string)reder["Stud_place"];
                    //Console.WriteLine($"{reder["Stud_Id"]}-{reder["Stud_name"]}-{reder["Stud_place"]} ");

                    Console.WriteLine($"Id is : {Id} - Name is : {Name} - Place is {Age}");
                }

                
                
            }
        }
    }
}
