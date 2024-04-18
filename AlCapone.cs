using System;
namespace MenuScrapper
{
    public class AlCapone : Restaurant
    {
        public override string GetDayMenuStr(int day)
        {
            string weekMenuStr = Nodes[2].InnerText;
            string startDay = Utils.GetDay(day);
            string endDay;

            if (day == 4)
            {
                endDay = "";
            }
            else
            {
                endDay = Utils.GetDay(day + 1);
            }

            return Utils.GetSubstring(weekMenuStr, startDay, endDay);
        }

        public override void LoadSoup(int day, string[] dayMenuArray)
        {
            if (day == 0)
            {
                WeekMenu[day].Menu[0] = Utils.GetSubstring(dayMenuArray[0], "Polévka:&nbsp;", "");
            }
            else
            {
                WeekMenu[day].Menu[0] = Utils.GetSubstring(dayMenuArray[0], "Polévka: ;", "");
            }
        }

        public override void LoadConcreteMenu(string[] dayMenuArray, int i, int day)
        {
            int endIndex = dayMenuArray[i].Length - 6;
            WeekMenu[day].Menu[i] = Utils.GetSubstring(dayMenuArray[i], "", endIndex);
            WeekMenu[day].MenuPrices[i] = Utils.GetSubstring(dayMenuArray[i], endIndex, " Kč");
        }
    }
}

