using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegramBot
{
    internal class Up
    {
        async public static Task Update(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken token)
        {
            Message? message = update.Message;

            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName} {message.Chat.LastName}    |    {message.Text}");
                if (message.Text == "Сделать заявку")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons1());
                else if (message.Text == "Показать на карте")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons3());
                }
                else if (message.Text == "Первоуральск")
                    await botClient.SendVenueAsync(message.Chat.Id, 56.906345828305895f, 59.97368661811358f, "Киберсталь Первоуральск", "623100, Свердловская область, г. Первоуральск, территория Киберсталь, Клиентский проезд, здание 1");
                else if (message.Text == "Москва")
                    await botClient.SendVenueAsync(message.Chat.Id, 55.69511092256764f, 37.347150717827255f, "Киберсталь Москва", "121205, г. Москва, Инновационный центр Сколково, Большой бульвар, 40, БЦ \"Амальтея\", сектор B, 4 этаж");
                else if (message.Text == "Выбрать из наличия")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Самый сочный мощный каталог труб", replyToMessageId: update.Message.MessageId, replyMarkup: Buttons.GetInlineButton());
                else if (message.Text == "Контакты")
                {
                    await Program.client.SendContactAsync(message.Chat.Id, "+1234567890", "Киберсталь", "Москва", token.ToString());
                    await Program.client.SendContactAsync(message.Chat.Id, "+0987654321", "Киберсталь", "Первоуральск", token.ToString());
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Почта:\nкиберсталь@cybersteel.com", replyMarkup: Buttons.GetButtons());
                }
                else if (message.Text == "Под заказ")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons2());
                else if (message.Text == "ГОСТ 9941-81")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons4());
                }
                else if (message.Text == "ГОСТ 9940-81")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons4());
                }
                else if (message.Text == "ТУ 14-3Р-55-2001")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons5());
                }
                else if (message.Text == "08Х18Н10Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons6());
                }
                else if (message.Text == "12Х18Н10Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons6());
                }
                else if (message.Text == "08Х13")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons6());
                }
                else if (message.Text == "10Х17Н13М2Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons6());
                }
                else if (message.Text == "12Х13")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons6());
                }
                else if (message.Text == "12Х18Н12Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons6());
                }
                else if (message.Text == "1-32")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons7());
                }
                else if (message.Text == "33-65")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons7());
                }
                else if (message.Text == "66-99")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons7());
                }
                else if (message.Text == "100-134")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons7());
                }
                else if (message.Text == "0,1-3,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons8());
                }
                else if (message.Text == "3,1-6,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons8());
                }
                else if (message.Text == "6,1-9,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons8());
                }
                else if (message.Text == "9,1-12,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: Buttons.GetButtons8());
                }
                else if (message.Text == "В метрах")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправляется");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправлена, отсавьте номер чтобы связаться с нами", replyMarkup: Buttons.GetButtons9());
                }
                else if (message.Text == "В тоннах")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправляется");
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправлена, оставьте номер чтобы мы с вами связались", replyMarkup: Buttons.GetButtons9());
                }
                else if (message.Text != "Оставить данные")
                {
                    Console.WriteLine(message.Chat.Username.ToString());
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери", replyMarkup: Buttons.GetButtons());
                }
            }
        }
    }
}
