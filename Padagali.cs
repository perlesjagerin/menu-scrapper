using System;
namespace MenuScrapper
{
    public class Padagali : Restaurant
    {
        public override string GetDayMenuStr(int day)
        {
            return Nodes[day].InnerText;
        }

        public override void LoadSoup(int day, string[] dayMenuArray)
        {
            WeekMenu[day].Menu[0] = dayMenuArray[2];
            int startIndex = dayMenuArray[1].Length - 6;
            WeekMenu[day].MenuPrices[0] = Utils.GetSubstring(dayMenuArray[1], startIndex, " CZK");
        }

        public override void LoadConcreteMenu(string[] dayMenuArray, int i, int day)
        {
            WeekMenu[day].Menu[i] = dayMenuArray[i * 2 + 2];
            int startIndex = dayMenuArray[i * 2 + 1].Length - 7;
            WeekMenu[day].MenuPrices[i] = Utils.GetSubstring(dayMenuArray[i * 2 + 1], startIndex, " CZK");
        }
    }
}

