using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAppConsole
{
    class Program
    {
        /// <summary>
        /// This method attempts to create the Dogs1 SQL table.
        /// If will do nothing but print an error if the table already exists.
        /// </summary>
        static void TryCreateTable()
        {
            using (SqlConnection con = new SqlConnection(
                Program.Properties.Settings.Default.masterConnectionString))
            {
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "CREATE TABLE Dogs1 (Weight INT, Name TEXT, Breed TEXT)", con))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine("Table not created.");
                }
            }
        }
    }
}
