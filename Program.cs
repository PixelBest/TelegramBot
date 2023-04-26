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
        private static TelegramBotClient client;
        private static string connectionString { get; } = @"Server=DESKTOP-9314GJ9;Database=telegramm;Integrated Security=False;Encrypt=false;User Id=sa;Password=1111";
        private static string token { get;} = "6104982128:AAFlG61y44DFOegDeIbslhSOSyEAK8WuU9U";
        private static string[] data = new string[5];
        private static bool check = true;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving(Update, HandlePollingErrorAsync);
            Console.ReadLine();
        }

        async private static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            Message? message = update.Message;
            string phoneNumber = "";

            /*await botClient.SendTextMessageAsync(message.Chat.Id, "Оставить данные", replyMarkup: GetButtons9());
            SqlConnection con1 = new SqlConnection(connectionString);
            con1.Open();
            SqlCommand com1 = new SqlCommand("SELECT MAX(id) FROM dbo.customer", con1);
            SqlDataReader reader1 = com1.ExecuteReader();
            int id1 = 0;
            try
            {
                while (reader1.Read())
                    id1 += Convert.ToInt32(reader1[0]);
            }
            catch
            {
                id1 = 0;
            }
            reader1.Close();
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.InsertCommand = new SqlCommand($"INSERT INTO dbo.customer VALUES({id1 + 1},'@{message.Chat.Username}','{message.Chat.FirstName} {message.Chat.LastName}')", con1);
            adapter1.InsertCommand.ExecuteNonQuery();
            con1.Close();*/

            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName} {message.Chat.LastName}    |    {message.Text}");
                if (message.Text == "Сделать заявку")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons1());
                else if (message.Text == "Показать на карте")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons3());
                }  
                else if (message.Text == "Первоуральск")
                    await botClient.SendVenueAsync(message.Chat.Id, 56.906345828305895f, 59.97368661811358f, "Киберсталь Первоуральск" ,"623100, Свердловская область, г. Первоуральск, территория Киберсталь, Клиентский проезд, здание 1");
                else if (message.Text == "Москва")
                    await botClient.SendVenueAsync(message.Chat.Id, 55.69511092256764f, 37.347150717827255f, "Киберсталь Москва" , "121205, г. Москва, Инновационный центр Сколково, Большой бульвар, 40, БЦ \"Амальтея\", сектор B, 4 этаж");
                else if (message.Text == "Выбрать из наличия")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Самый сочный мощный каталог труб", replyToMessageId: update.Message.MessageId, replyMarkup: GetInlineButton());
                else if (message.Text == "Контакты")
                {
                    await client.SendContactAsync(message.Chat.Id, "+1234567890", "Киберсталь", "Москва", token.ToString());
                    await client.SendContactAsync(message.Chat.Id, "+0987654321", "Киберсталь", "Первоуральск", token.ToString());
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Почта:\nкиберсталь@cybersteel.com", replyMarkup: GetButtons());
                }
                else if (message.Text == "Под заказ")
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons2());
                else if (message.Text == "ГОСТ 9941-81")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons4());
                    data[0] = message.Text;
                }
                else if (message.Text == "ГОСТ 9940-81")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons4());
                    data[0] = message.Text;
                }
                else if (message.Text == "ТУ 14-3Р-55-2001")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons5());
                    data[0] = message.Text;
                }
                else if (message.Text == "08Х18Н10Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons6());
                    data[1] = message.Text;
                }
                else if (message.Text == "12Х18Н10Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons6());
                    data[1] = message.Text;
                }
                else if (message.Text == "08Х13")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons6());
                    data[1] = message.Text;
                }
                else if (message.Text == "10Х17Н13М2Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons6());
                    data[1] = message.Text;
                }
                else if (message.Text == "12Х13")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons6());
                    data[1] = message.Text;
                }
                else if (message.Text == "12Х18Н12Т")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons6());
                    data[1] = message.Text;
                }
                else if (message.Text == "1-32")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons7());
                    data[2] = message.Text;
                }
                else if (message.Text == "33-65")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons7());
                    data[2] = message.Text;
                }
                else if (message.Text == "66-99")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons7());
                    data[2] = message.Text;
                }
                else if (message.Text == "100-134")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons7());
                    data[2] = message.Text;
                }
                else if (message.Text == "0,1-3,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons8());
                    data[3] = message.Text;
                }
                else if (message.Text == "3,1-6,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons8());
                    data[3] = message.Text;
                }
                else if (message.Text == "6,1-9,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons8());
                    data[3] = message.Text;
                }
                else if (message.Text == "9,1-12,0")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите", replyMarkup: GetButtons8());
                    data[3] = message.Text;
                }
                else if (message.Text == "В метрах")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправляется");
                    data[4] = message.Text;
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
                    reader.Close();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    Console.WriteLine();
                    adapter.InsertCommand = new SqlCommand($"INSERT INTO dbo.zakaz VALUES({id + 1},'{data[0]}','{data[1]}','{data[2]}','{data[3]}','{data[4]}','{DateTime.Now.ToString()}')", con);
                    adapter.InsertCommand.ExecuteNonQuery();
                    con.Close();
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправлена, отсавьте номер чтобы связаться с нами", replyMarkup: GetButtons9());
                }
                else if (message.Text == "В тоннах")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправляется");
                    data[4] = message.Text;
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
                    reader.Close();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = new SqlCommand($"INSERT INTO dbo.zakaz VALUES({id + 1},'{data[0]}','{data[1]}','{data[2]}','{data[3]}','{data[4]}','{DateTime.Now.ToString()}')", con);
                    adapter.InsertCommand.ExecuteNonQuery();
                    con.Close();
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Заявка отправлена, оставьте номер чтобы мы с вами связались", replyMarkup: GetButtons9());
                }
                else if(message.Text != "Оставить данные")
                {
                    Console.WriteLine(message.Chat.Username.ToString());
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери", replyMarkup: GetButtons());
                }
            }
        }

        private static IReplyMarkup? GetButtons7()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton("0,1-3,0"), new KeyboardButton("3,1-6,0") },
                    new List<KeyboardButton> { new KeyboardButton("6,1-9,0"), new KeyboardButton("9,1-12,0") },
                    new List<KeyboardButton> { new KeyboardButton("В начало") }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons9()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup11 = new(new[]
            {
                KeyboardButton.WithRequestContact("Оставить контакт"),})
            {
                ResizeKeyboard = true
            };
            return replyKeyboardMarkup11;

        }

        private static IReplyMarkup? GetButtons8()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton("В метрах"), new KeyboardButton("В тоннах") },
                    new List<KeyboardButton> { new KeyboardButton("В начало") }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons6()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton("1-32"), new KeyboardButton("33-65") },
                    new List<KeyboardButton> { new KeyboardButton("66-99"), new KeyboardButton("100-134") },
                    new List<KeyboardButton> { new KeyboardButton("В начало") }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons5()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton("12Х18Н12Т") },
                    new List<KeyboardButton> { new KeyboardButton("В начало") }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons4()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton("08Х18Н10Т"), new KeyboardButton("12Х18Н10Т") },
                    new List<KeyboardButton> { new KeyboardButton("08Х13"), new KeyboardButton("10Х17Н13М2Т") },
                    new List<KeyboardButton> { new KeyboardButton("12Х13") },
                    new List<KeyboardButton> { new KeyboardButton("В начало") }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetInlineButton()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton> { InlineKeyboardButton.WithUrl("Каталог киберстали", "https://cybersteel.com/catalog/")}
                });
        }

        private static IReplyMarkup? GetButtons3()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton("Первоуральск"), new KeyboardButton("Москва") },
                    new List<KeyboardButton> { new KeyboardButton("В начало") }
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons2()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("ГОСТ 9941-81"), new KeyboardButton("ГОСТ 9940-81")},
                    new List<KeyboardButton>{ new KeyboardButton("ТУ 14-3Р-55-2001")},
                    new List<KeyboardButton>{ new KeyboardButton("В начало")}
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons1()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Выбрать из наличия"), new KeyboardButton("Под заказ")},
                    new List<KeyboardButton>{ new KeyboardButton("В начало")}
                },
                ResizeKeyboard = true
            };
        }

        private static IReplyMarkup? GetButtons()
        {
            return new ReplyKeyboardMarkup("Хз что тут писать")
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton("Показать на карте"), new KeyboardButton("Контакты")},
                    new List<KeyboardButton>{ new KeyboardButton("Сделать заявку") }
                },
                ResizeKeyboard = true
            };
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient,
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
