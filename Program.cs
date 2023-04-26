using Microsoft.VisualBasic;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using System.Threading;
using Telegram.Bot.Exceptions;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using Azure.Identity;

namespace TelegramBot
{
    internal class Program
    {
        private static string connectionString { get; } = @"Server=DESKTOP-9314GJ9;Database=telegramm;Integrated Security=False;Encrypt=false;User Id=sa;Password=1111";
        private readonly static string token = "6104982128:AAFlG61y44DFOegDeIbslhSOSyEAK8WuU9U";
        public static TelegramBotClient client;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving(Up.Update, Error.HandlePollingErrorAsync);
            Console.ReadLine();
        }

    }
}
