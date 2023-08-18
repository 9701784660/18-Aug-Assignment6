using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assignment_6
{
    internal class Program
    {
        static SqlDataReader reader;
        static SqlCommand cmd;
        static SqlConnection con;
        static string conStr = "server=LAPTOP-CKG2KTF0;database=ProductInventoryDB;trusted_connection=true;";


        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand();
                Console.WriteLine("Find out 1.View 2.Insert into 3.Update 4.Delete , Enter your choice 1,2,3 or 4");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand("select * from Products", con);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            Console.WriteLine("ProductId \t ProductName \t Price  \t Quantity \t MfDate \t ExpDate");
                            while (reader.Read())
                            {
                                Console.Write(reader["ProductId"] + "\t ");
                                Console.Write(reader["ProductName"] + "\t \t");
                                Console.Write(reader["Price"] + "\t  \t");
                                Console.Write(reader["Quantity"] + "\t \t");
                                Console.Write(reader["MfDate"] + "\t \t");
                                Console.Write(reader["ExpDate"] + "\t \t");
                                Console.WriteLine("\n");

                            }
                            break;
                        }
                    case 2:
                        {
                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()

                            {
                                CommandText = "insert into Products(ProductId,ProductName,Price,Quantity,MfDate,ExpDate) values (@pid,@pn,@pri,@quan,@mfd,@expd)",
                                Connection = con

                            };
                            Console.WriteLine("Enter  Product Id");
                            cmd.Parameters.AddWithValue("@pid", int.Parse(Console.ReadLine()));

                            Console.WriteLine("Enter Product Name");
                            cmd.Parameters.AddWithValue("@pn", Console.ReadLine());
                            Console.WriteLine("Enter Product Price");
                            cmd.Parameters.AddWithValue("@pri", int.Parse(Console.ReadLine()));

                            Console.WriteLine("Enter Quantity");
                            cmd.Parameters.AddWithValue("@quan", int.Parse(Console.ReadLine()));

                            Console.WriteLine("Enter MfDate");
                            cmd.Parameters.AddWithValue("@mfd", Console.ReadLine());
                            Console.WriteLine("Enter ExpDate");
                            cmd.Parameters.AddWithValue("@expd", Console.ReadLine());


                            con.Open();
                            int nor = cmd.ExecuteNonQuery();
                            if (nor >= 1)
                            {
                                Console.WriteLine("Record Inserted!!!");

                            }
                            break;
                        }
                    case 3:
                        {
                            int Productid;
                            Console.WriteLine("Enter product ID to update Details");
                            Productid = int.Parse(Console.ReadLine());
                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()

                            {
                                CommandText = "select * from Products where ProductId=@pid",
                                Connection = con

                            };
                            cmd.Parameters.AddWithValue("@pid", Productid);
                            con.Open();
                            reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                con.Close();
                                con.Open();
                                cmd.CommandText = "update Products set ProductName=@pn, Price=@pri,Quantity=@quan,MfDate=@mfd,ExpDate=@expd where ProductId=@id";

                                Console.WriteLine("Enter Product Name");
                                cmd.Parameters.AddWithValue("@pn", Console.ReadLine());
                                Console.WriteLine("Enter Product price");
                                cmd.Parameters.AddWithValue("@pri", int.Parse(Console.ReadLine()));

                                Console.WriteLine("Enter Quantity");
                                cmd.Parameters.AddWithValue("@quan", int.Parse(Console.ReadLine()));

                                Console.WriteLine("Enter MfDate");
                                cmd.Parameters.AddWithValue("@mfd", Console.ReadLine());
                                Console.WriteLine("Enter ExpDate");
                                cmd.Parameters.AddWithValue("@expd", Console.ReadLine());
                                cmd.Parameters.AddWithValue("@id", Productid);
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("Record Updated!!!");
                            }
                            else
                            {
                                Console.WriteLine($"No such  Id {Productid} exist in our database");

                            }
                            break;
                        }


                    case 4:
                        {

                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()

                            {
                                CommandText = "delete from Products where ProductId=@pid",
                                Connection = con

                            };
                            Console.WriteLine("Enter Product Id to Delete");
                            cmd.Parameters.AddWithValue("@pid", int.Parse(Console.ReadLine()));

                            con.Open();
                            int nor = cmd.ExecuteNonQuery();
                            if (nor >= 1)
                            {
                                Console.WriteLine("Record Deleted!!!");

                            }
                            break;

                        }


                    default:
                        {
                            Console.WriteLine("Invalid Operation Choice");
                            return;
                        }



                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
    

