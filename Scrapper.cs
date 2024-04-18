using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MenuScrapper
{
    //TODO: Finish Scrapper - implement the load methods for three restaurants.
    public class Scrapper
    {
        public Restaurant[] Restaurants { get; set; } = new Restaurant[3];

        public Scrapper()
        {
            Restaurant[] restaurants = { new UDrevaka(), new AlCapone(), new Padagali() };

            for (int i = 0; i < 3; i++)
            {
                Restaurants[i] = restaurants[i];
                Restaurants[i].Name = Constants.restaurantNames[i];

                HtmlDocument htmlDoc = Utils.GetHtmlDoc(Constants.restaurantUrls[i]);
                Restaurants[i].Nodes = htmlDoc.DocumentNode.SelectNodes(Constants.restaurantXpaths[i]);

                Restaurants[i].LoadRestaurant();
            }
        }
    }
}
