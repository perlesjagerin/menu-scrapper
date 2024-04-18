using System;
using HtmlAgilityPack;

namespace MenuScrapper
{
    public abstract class Restaurant
    {
        public string Name { get; set; }
        public DayMenu[] WeekMenu { get; set; } = new DayMenu[5];
        public HtmlNodeCollection Nodes { get; set; }

        public Restaurant()
        {
            for (int day = 0; day < 5; day++)
            {
                WeekMenu[day] = new DayMenu();
                WeekMenu[day].Day = Utils.GetDay(day);
            }
        }

        public virtual void LoadRestaurant()
        {
            for (int day = 0; day < 5; day++)
            {
                string dayMenuStr = GetDayMenuStr(day);
                string[] dayMenuArray = Utils.CreateArrayWithoutWhiteChars(dayMenuStr);

                LoadMenu(day, dayMenuArray);
            }
        }

        public abstract string GetDayMenuStr(int day);

        public void LoadMenu(int day, string[] dayMenuArray)
        {
            LoadSoup(day, dayMenuArray);

            for (int i = 1; i < 5; i++)
            {
                LoadConcreteMenu(dayMenuArray, i, day);
            }
        }

        public abstract void LoadConcreteMenu(string[] dayMenuArray, int i, int day);
        public abstract void LoadSoup(int day, string[] dayMenuArray);
    }
}

