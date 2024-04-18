using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuScrapper
{
    //TODO: Create console UI and all 6 (5 + search) methods from pdf.
    public class MenuHandler
    {
        private readonly Scrapper scrapper = new Scrapper();
        private readonly DayOfWeek today = DateTime.Today.DayOfWeek;

        public void RunApp()
        {
            while (true)
            {
                PrintOptions(Constants.options);
                int option = GetOption(Constants.options.Length);

                switch (option)
                {
                    case 1:
                        PrintTodayMenus();
                        break;
                    case 2:
                        PrintTodayMenuForRestaurant();
                        break;
                    case 3:
                        PrintMenusByDay();
                        break;
                    case 4:
                        PrintMenuForRestaurantByDay();
                        break;
                    case 5:
                        PrintAllMenus();
                        break;
                    case 6:
                        Search();
                        break;
                    case 7:
                        return;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void PrintMenus(int dayOption) // 1, 3
        {
            Console.WriteLine();

            foreach (Restaurant restaurant in scrapper.Restaurants)
            {
                Console.WriteLine(restaurant.Name.ToUpper());
                Console.WriteLine(restaurant.WeekMenu[dayOption].ToString());
            }

            PrintSeparator();
        }

        private void PrintMenu(int dayOption) // 2, 4
        {
            int restaurantOption = PrintAndGetOption(Constants.restaurantNames) - 1;
            Restaurant restaurant = scrapper.Restaurants[restaurantOption];
            DayMenu dayMenu = restaurant.WeekMenu[dayOption];

            Console.WriteLine();
            Console.WriteLine(scrapper.Restaurants[restaurantOption].Name.ToUpper());
            Console.WriteLine(dayMenu.ToString());

            PrintSeparator();
        }

        public void PrintTodayMenus() // 1
        {
            int dayOption = Utils.GetDayIndex(today);
            PrintMenus(dayOption);
        }

        public void PrintTodayMenuForRestaurant() // 2
        {
            int dayOption = Utils.GetDayIndex(today);
            PrintMenu(dayOption);
        }

        public void PrintMenusByDay() // 3
        {
            int dayOption = PrintAndGetOption(Constants.days) - 1;
            PrintMenus(dayOption);
        }

        public void PrintMenuForRestaurantByDay() // 4
        {
            int dayOption = PrintAndGetOption(Constants.days) - 1;
            PrintMenu(dayOption);
        }

        public void PrintAllMenus() // 5
        {
            Console.WriteLine();

            foreach (Restaurant restaurant in scrapper.Restaurants)
            {
                Console.WriteLine(restaurant.Name.ToUpper());

                foreach (DayMenu dayMenu in restaurant.WeekMenu)
                {
                    Console.WriteLine(dayMenu.ToString());
                }
            }

            PrintSeparator();
        }

        public void Search() // 6
        {
            Console.WriteLine();

            Console.Write("Napiš hledané jídlo nebo jeho část: ");
            string input = Console.ReadLine().ToLower();
            Console.WriteLine();

            foreach (Restaurant restaurant in scrapper.Restaurants)
            {
                foreach (DayMenu dayMenu in restaurant.WeekMenu)
                {
                    foreach (string food in dayMenu.Menu)
                    {
                        if (food.Contains(input))
                        {
                            Console.WriteLine(restaurant.Name.ToUpper());
                            Console.WriteLine(dayMenu.ToString());
                            break;
                        }
                    }
                }
            }

            PrintSeparator();
        }

        private void PrintOptions(string[] options)
        {
            Console.WriteLine();

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {options[i]}");
            }

            PrintAllowedOptions(options.Length);
        }

        private void PrintAllowedOptions(int lastOption)
        {
            Console.WriteLine();
            Console.WriteLine($"VYBERTE Z MOŽNOSTÍ <1,{lastOption}>:");
            Console.WriteLine(new string('-', Console.WindowWidth));
        }

        private bool IsOptionAllowed(int lastOption, string input)
        {
            if (!int.TryParse(input, out int option))
            {
                return false;
            }

            if (option <= lastOption && option >= 1)
            {
                return true;
            }

            return false;
        }

        private int GetOption(int lastOption)
        {
            int option = 0;
            bool repeat = true;

            do
            {
                string input = Console.ReadLine();

                if (!IsOptionAllowed(lastOption, input))
                {
                    PrintAllowedOptions(lastOption);
                }
                else
                {
                    option = int.Parse(input);
                    repeat = false;
                }
            }
            while (repeat);

            return option;
        }

        private int PrintAndGetOption(string[] options)
        {
            PrintOptions(options);
            return GetOption(options.Length);
        }

        private void PrintSeparator()
        {
            string separator = "";

            for (int i = 0; i < 24; i++)
            {
                separator += "- ";
            }

            Console.WriteLine(separator);
        }
    }
}
