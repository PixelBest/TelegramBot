﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    static internal class Writer
    {
        public static void WriteZakaz()
        {
            Order order = new Order(Up.data[1], Up.data[2], Up.data[3], Up.data[4], Up.data[5], DateTime.Now.ToString());
            string connectionString = @"Server=DESKTOP-9314GJ9;Database=telegramm;Integrated Security=False;Encrypt=false;User Id=sa;Password=1111";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT MAX(id) FROM dbo.customer", con);
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
            user.Id = id;
            reader.Close();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand($"INSERT INTO dbo.customer VALUES({user.Id},'{user.Phone}','@{user.UserName}')", con);
            adapter.InsertCommand.ExecuteNonQuery();
            con.Close();
            Console.WriteLine($"{user.Id},'{user.Phone}','{user.UserName} ");
        }
    }
}
