using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MenuScrapper
{
    //This class represents menu of the one day in week.
    public class DayMenu
    {
        public string Day { get; set; }
        public string[] Menu { get; set; } = new string[5];
        public string[] MenuPrices { get; set; } = { null, null, null, null, null};

        public override string ToString()
        {
            string dayMenu = $"Den: {Day}\n";

            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    dayMenu += GetMenuRow($"Polévka: ", Menu[i], MenuPrices[i]);
                }
                else
                {
                    dayMenu += GetMenuRow($"{i}) ", Menu[i], MenuPrices[i]);
                }
            }

            return dayMenu;
        }

        private string GetPrice(string item)
        {
            if (item == null)
            {
                return "BEZ CENY\n";
            }

            return $"{item} Kč\n";
        }

        private string GetMenuRow(string prefix, string item, string itemPrice)
        {
            int totalWidth = Console.WindowWidth - 8;
            return $"{prefix}{item}".PadRight(totalWidth, '.') + GetPrice(itemPrice);
        }
    }
}
