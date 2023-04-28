using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Telegram.Bot.Types;
using OfficeOpenXml.Core.ExcelPackage;
using System.IO;
using DocumentFormat.OpenXml;
using Excel = ExcelWriter;

namespace TelegramBot
{
    static internal class Writer
    {
        static string path = Directory.GetCurrentDirectory();
        public static void WriteZakaz()
        {
            Order order = new Order(Up.data[1], Up.data[2], Up.data[3], Up.data[4], Up.data[5], DateTime.Now.ToString());
            string connectionString = @"Server=DESKTOP-9314GJ9;Database=telegramm;Integrated Security=False;Encrypt=false;User Id=sa;Password=1111";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT MAX(id) FROM dbo.zakaz", con);
            SqlDataReader reader = com.ExecuteReader();
            int id = 0;
            try
            {
                while (reader.Read())
                    id += Convert.ToInt32(reader[0]);
            }
            catch
            {
                id = 0;
            }
            order.Id = id + 1;
            Up.data[0] = order.Id.ToString();
            reader.Close();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO dbo.zakaz VALUES({order.Id},'{order.Gost}','{order.Number}','{order.Lenght1}','{order.Lenght2}','{order.Units}','{order.Date}')", con);
            adapter.InsertCommand.ExecuteNonQuery();
            con.Close();
            Console.WriteLine($"{order.Gost} {order.Number} {order.Lenght1} {order.Lenght2} {order.Units} {order.Date} ");
        }
        public static void WriteCustomer()
        {
            User user = new User(Program.phoneNumber, Program.userName);
            Up.data[7] = Program.phoneNumber;
            Up.data[8] = Program.userName;
            Up.data[6] = DateTime.Now.ToString();
            string connectionString = @"Server=DESKTOP-9314GJ9;Database=telegramm;Integrated Security=False;Encrypt=false;User Id=sa;Password=1111";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT phone FROM dbo.customer WHERE phone = @1", con);
            com.Parameters.AddWithValue("@1", Program.phoneNumber);
            SqlDataReader reader = com.ExecuteReader();
            string phone = String.Empty;
            try
            {
                while (reader.Read())
                    phone += reader["phone"];
            }
            catch
            {
                phone = "";
            }
            reader.Close();
            if (phone == "")
            {
                SqlCommand com1 = new SqlCommand("SELECT MAX(id) FROM dbo.customer", con);
                SqlDataReader reader1 = com1.ExecuteReader();
                int id = 0;
                try
                {
                    while (reader1.Read())
                        id += Convert.ToInt32(reader1[0]);
                }
                catch
                {
                    id = 0;
                }
                user.Id = id + 1;
                reader1.Close();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand($"INSERT INTO dbo.customer VALUES({user.Id},'{user.Phone}','@{user.UserName}')", con);
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
                Console.WriteLine($"{user.Id},'{user.Phone}','{user.UserName} ");
                ExportToExcel();
            }
            else
            {
                Console.WriteLine("Такой номер уже есть");
                Console.WriteLine($"{user.Id},'{user.Phone}','{user.UserName} ");
                ExportToExcel();
            }
        }
        public static void ExportToExcel()
        {
            Excel.Program.Main(Up.data);
        }
    }
}
