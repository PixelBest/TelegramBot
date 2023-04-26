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
        private readonly static string token = "6104982128:AAFlG61y44DFOegDeIbslhSOSyEAK8WuU9U";
        public static TelegramBotClient? client;

        static void Main(string[] args)
        {
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
                Console.Write(update);
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
