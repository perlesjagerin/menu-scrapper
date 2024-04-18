using System;
using System.Linq;
using HtmlAgilityPack;
using static System.Net.Mime.MediaTypeNames;

namespace MenuScrapper
{
    public static class Utils
    {
        //Use this method to get HtmlDocument by url (see Constants.cs).
        //HtmlAgilityPack is required

        public static HtmlDocument GetHtmlDoc(string url)
        {
            var web = new HtmlWeb();
            return web.Load(url);
        }

        public static string GetDay(int index)
        {
            switch (index)
            {
                case 0:
                    return Constants.days[0];
                case 1:
                    return Constants.days[1];
                case 2:
                    return Constants.days[2];
                case 3:
                    return Constants.days[3];
                case 4:
                    return Constants.days[4];
                default:
                    throw new NotImplementedException();
            }
        }

        public static int GetDayIndex(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return 0;
                case DayOfWeek.Tuesday:
                    return 1;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 3;
                case DayOfWeek.Friday:
                    return 4;
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetSubstring(string text, string startStr, string endStr)
        {
            int startIndex = GetStartIndex(text, startStr);
            int endIndex = GetEndIndex(text, endStr);

            return text.Substring(startIndex, endIndex - startIndex);
        }

        public static string GetSubstring(string text, string startStr, int endIndex)
        {
            int startIndex = GetStartIndex(text, startStr);
            return text.Substring(startIndex, endIndex - startIndex);
        }

        public static string GetSubstring(string text, int startIndex, string endStr)
        {
            int endIndex = GetEndIndex(text, endStr);
            return text.Substring(startIndex, endIndex - startIndex);
        }

        private static int GetStartIndex(string text, string startStr)
        {
            if (startStr == "")
            {
                return 0;
            }

            return text.IndexOf(startStr) + startStr.Length;
        }

        private static int GetEndIndex(string text, string endStr)
        {
            if (endStr == "")
            {
                return text.Length;
            }

            return text.LastIndexOf(endStr);
        }

        public static string[] CreateArrayWithoutWhiteChars(string text)
        {
            return text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(line => line.Trim())
                       .Where(line => !string.IsNullOrEmpty(line))
                       .ToArray();
        }
    }
}
