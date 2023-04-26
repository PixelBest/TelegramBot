using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    internal class Order
    {
        public int Id { get; set; }
        public string? Gost { get; set; }
        public string? Number { get; set; }
        public string? Lenght1 { get; set; }
        public string? Lenght2 { get; set; }
        public string? Units { get; set; }
        public string? Date { get; set; }
        public Order(string? gost, string? number, string? lenght1, string? lenght2, string? units, string? date)
        {
            Gost = gost;
            Number = number;
            Lenght1 = lenght1;
            Lenght2 = lenght2;
            Units = units;
            Date = date;
        }
        public Order() { }
    }
}
