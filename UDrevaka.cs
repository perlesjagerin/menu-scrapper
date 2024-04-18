using System;
namespace MenuScrapper
{
    public class UDrevaka : Restaurant
    {
        public override string GetDayMenuStr(int day)
        {
            return Nodes[day].InnerText;
        }

        public override void LoadSoup(int day, string[] dayMenuArray)
        {
            WeekMenu[day].Menu[0] = Utils.GetSubstring(dayMenuArray[1], ": ", "");
        }

        public override void LoadConcreteMenu(string[] dayMenuArray, int i, int day)
        {
            if (dayMenuArray.Length != 10)
            {
                WeekMenu[day].Menu[i] = Utils.GetSubstring(dayMenuArray[i + 1], ") ", "");
            }
            else
            {
                WeekMenu[day].Menu[i] = Utils.GetSubstring(dayMenuArray[i * 2], ") ", "");
                WeekMenu[day].MenuPrices[i] = Utils.GetSubstring(dayMenuArray[i * 2 + 1], "", ",- Kč");
            }
        }
    }
}

