using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuScrapper
{
    //Not necessary to edit this class. 
    public static class Constants
    {
        public static string[] days = { "Pondělí", "Úterý", "Středa", "Čtvrtek", "Pátek" };

        public static string option1 = "Zobraz dnešní menu všech restaurací";
        public static string option2 = "Zobraz dnešní menu konkrétní restaurace";
        public static string option3 = "Zobraz menu všech restaurací podle dne";
        public static string option4 = "Zobraz menu konkrétní restaurace podle dne";
        public static string option5 = "Zobraz týdenní menu všech restaurací";
        public static string option6 = "Najít jídlo";
        public static string option7 = "Ukončit aplikaci";

        public static string[] options = { option1, option2, option3, option4, option5, option6, option7 };

        public static string uDrevaka = "U Dřeváka Beer & Grill";
        public static string alCapone = "Al Capone - Pizzeria Ristorante";
        public static string padagali = "Padagali";

        public static string[] restaurantNames = { uDrevaka, alCapone, padagali };

        public static string udrevakaUrl = "https://www.udrevaka.cz/denni-menu/";
        public static string alCaponeUrl = "https://www.pizzaalcapone.cz/cz/poledni-menu";
        public static string padagaliUrl = "https://padagali.cz/denni-menu/";

        public static string[] restaurantUrls = { udrevakaUrl, alCaponeUrl, padagaliUrl };

        public static string udrevakaXpath = "//*[@id=\"menu\"]/div/div/div/ul[2]/*";
        public static string alCaponeXpath = "/html/body/section[1]/div[2]/div/*";
        public static string padagaliXpath = "//*[@id=\"post-75\"]/div[2]/div/div/div/div/div[2]/div/*[position() <= 5]";

        public static string[] restaurantXpaths = { udrevakaXpath, alCaponeXpath, padagaliXpath };

        public static string testHtml = "<!DOCTYPE html>" +
                                        "<html>" +
                                            "<body>" +
                                                "<h1>My First Heading</h1>" +
                                                "<a href='https://www.w3schools.com'>This is a link 1</a>" +
                                                "<p>My first paragraph.</p>" +
                                                "<div class='c1 c'>" +
                                                    "<a href='https://www.w3schools.com'>This is a link 2.1</a>" +
                                                    "<br/>" +
                                                    "<a href='https://www.w3schools.com'>This is a link 2.2</a>" +
                                                    "<div class='c2'>" +
                                                        "<p>My second paragraph.</p>" +
                                                        "<div id='id1'>" +
                                                            "<a href='https://www.w3schools.com'>This is a link 3</a>" +
                                                        "</div>" +
                                                    "</div>" +
                                                "</div>" +
                                            "</body>" +
                                        "</html>";
    }
}
