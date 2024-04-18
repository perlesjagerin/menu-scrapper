using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MenuScrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuHandler menuHandler = new MenuHandler();
            menuHandler.RunApp();
        }
    }
}
