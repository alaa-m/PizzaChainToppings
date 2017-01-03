using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaChainToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get the data from the server
            var wc = new WebClient();
            var json = wc.DownloadString("http://files.olo.com/pizzas.json");

            //Select specified data 
            JArray jArr = (JArray)JsonConvert.DeserializeObject(json);
            var lst = jArr.GroupBy(item => item["toppings"].ToString()).Select(
                group => new {
                    Toppings = group.Key,
                    Count = group.Count()
                }).OrderByDescending(x => x.Count).Take(20).ToList();

            //show data 
            foreach (var item in lst)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("=================================");
            }

            Console.ReadLine();
            
            
        }
    }
}
