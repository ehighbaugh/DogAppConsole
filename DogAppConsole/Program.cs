using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAppConsole
{
    class Program
    {
        static void Main()
        {
            DataTable table1 = new DataTable("dogs");
            table1.Columns.Add("name");
            table1.Columns.Add("age");
            table1.Rows.Add("spot", 1);
            table1.Rows.Add("buddy", 2);

            DataTable table2 = new DataTable("breeds");
            table2.Columns.Add("breed");
            table2.Columns.Add("color");
            table2.Rows.Add("boston terrier", "black/white");
            table2.Rows.Add("boxer", "brindle");

            // create DataSet and put both tables in it
            //using (DataSet set = new DataSet("dogBreeds"))
            //{
            //    set.Tables.Add(table1);
            //    set.Tables.Add(table2);
            //    set.Namespace = "y";
            //    set.Prefix = "x";

            //    // copy dataset
            //    DataSet copy = set.Copy();

            //    // visualize dataset
            //    Console.WriteLine("set: {0}", set.GetXml());
            //    Console.WriteLine("set: {1}", copy.GetXml());
            //}

            DataSet set = new DataSet("dogBreeds2");
            set.Tables.Add(table1);
            set.Tables.Add(table2);

            // loop over datatables in dataset
            DataTableCollection collection = set.Tables;
            for (int i = 0; i < collection.Count; i++)
            {
                DataTable table = collection[i];
                Console.WriteLine("{0}: {1}", i, table.TableName);
            }

            // write first table name
            Console.WriteLine("x: {0}", set.Tables[0].TableName);

            // write row count of breeds table
            Console.WriteLine("y: {0}", set.Tables["breeds"].Rows.Count);
            Console.ReadLine();

            
        }
    }
}
