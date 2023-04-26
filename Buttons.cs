using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class Buttons
    {
        public static IReplyMarkup? GetButtons7()
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

        public static IReplyMarkup? GetButtons9()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup11 = new(new[]
            {
                KeyboardButton.WithRequestContact("Оставить контакт"),})
            {
                ResizeKeyboard = true

            };
            return replyKeyboardMarkup11;
        }

        public static IReplyMarkup? GetButtons8()
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

        public static IReplyMarkup? GetButtons6()
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

        public static IReplyMarkup? GetButtons5()
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

        public static IReplyMarkup? GetButtons4()
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

        public static IReplyMarkup? GetInlineButton()
        {
            return new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
                {
                    new List<InlineKeyboardButton> { InlineKeyboardButton.WithUrl("Каталог киберстали", "https://cybersteel.com/catalog/")}
                });
        }

        public static IReplyMarkup? GetButtons3()
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

        public static IReplyMarkup? GetButtons2()
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

        public static IReplyMarkup? GetButtons1()
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

        public static IReplyMarkup? GetButtons()
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
    }
}
