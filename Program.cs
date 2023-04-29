using Microsoft.VisualBasic;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Collections.Generic;
using Telegram.Bot.Exceptions;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using Timer = System.Timers.Timer;
using System.Runtime.InteropServices;
using Email = EmailSender;

namespace TelegramBot
{
    internal class Program
    {
        private readonly static string token = "";
        public static TelegramBotClient? client;
        public static string? phoneNumber;
        public static string? userName;

        static void Main(string[] args)
        {
            Email.Program.Main();
            client = new TelegramBotClient(token);
            client.StartReceiving(HandleUpdateAsunc, HandlePollingErrorAsync);
            Console.ReadLine();
        }


        private static async Task HandleUpdateAsunc(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken token)
        {
            Console.WriteLine($"{update?.Message?.Chat.Username} | {update?.Message?.Text} | {update?.Message?.Contact?.PhoneNumber}");
            if(update?.Type == UpdateType.Message && update.Message != null)
            {
                await Up.Update(botClient, update, token);
                if (update?.Message?.Contact != null)
                {
                    phoneNumber = update.Message.Contact.PhoneNumber;
                    userName = update?.Message?.Chat.Username;
                    Writer.WriteCustomer();
                    await Up.Gratitude(botClient, update, token);
                }
                /*Console.Write(update);*/
            }
        }

        public static Task HandlePollingErrorAsync(ITelegramBotClient botClient,
                                     Exception exception,
                                     CancellationToken cancellation)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
